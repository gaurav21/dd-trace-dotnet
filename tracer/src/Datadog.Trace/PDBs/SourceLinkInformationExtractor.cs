﻿// <copyright file="SourceLinkInformationExtractor.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using Datadog.Trace.Logging;
using Datadog.Trace.Pdb.SourceLink;
using Datadog.Trace.Vendors.Newtonsoft.Json.Linq;
using Datadog.Trace.Vendors.Serilog;

#nullable enable

namespace Datadog.Trace.Pdb;

internal static class SourceLinkInformationExtractor
{
    private static IDatadogLogger Log { get; } = DatadogLogging.GetLoggerFor(typeof(SourceLinkInformationExtractor));

    public static bool TryGetSourceLinkInfo(Assembly assembly, [NotNullWhen(true)] out string? commitSha, [NotNullWhen(true)] out string? repositoryUrl)
    {
        // Extracting the SourceLink information from the assembly attributes will only work if:
        // 1. The assembly was built using the .NET Core SDK 2.1.300 or newer or MSBuild 15.7 or newer.
        // 2. The assembly was built using an SDK-Style project file (i.e. <Project Sdk="Microsoft.NET.Sdk">).
        // If these conditions weren't met, the attributes won't be there, so we'll need to extract the information from the PDB file.

        return ExtractFromAssemblyAttributes(assembly, out commitSha, out repositoryUrl) ||
               ExtractFromPdb(assembly, out commitSha, out repositoryUrl);
    }

    private static bool ExtractFromPdb(Assembly assembly, out string? commitSha, out string? repositoryUrl)
    {
        commitSha = null;
        repositoryUrl = null;

        var pdbReader = DatadogPdbReader.CreatePdbReader(assembly);
        if (pdbReader == null)
        {
            Log.Information("PDB file for assembly {AssemblyFullPath} could not be found", assembly.Location);
            return false;
        }

        var sourceLinkJsonDocument = pdbReader.GetSourceLinkJsonDocument();
        if (sourceLinkJsonDocument == null)
        {
            Log.Information("PDB file for assembly does not contain SourceLink information", pdbReader.PdbFullPath);
            return false;
        }

        // Grab the SourceLink mapping URL. For example,
        // From:
        //       {"documents":{"C:\\dev\\dd-trace-dotnet\\*":"https://raw.githubusercontent.com/DataDog/dd-trace-dotnet/dd35903c688a74b62d1c6a9e4f41371c65704db8/*"}}
        // Extract:
        //       https://raw.githubusercontent.com/DataDog/dd-trace-dotnet/dd35903c688a74b62d1c6a9e4f41371c65704db8/*
        var sourceLinkMappedUrl = JObject.Parse(sourceLinkJsonDocument).SelectTokens("$.documents.*").FirstOrDefault()?.ToString();
        if (string.IsNullOrWhiteSpace(sourceLinkMappedUrl) || !Uri.TryCreate(sourceLinkMappedUrl, UriKind.Absolute, out var sourceLinkMappedUri))
        {
            Log.Information("PDB file {PdbFullPath} contained SourceLink information, but we failed to parse it.", pdbReader.PdbFullPath);
            return false;
        }

        Log.Information("PDB file {PdbFullPath} contained SourceLink information, and we successfully parsed it. The mapping uri is {SourceLinkMappedUri}.", pdbReader.PdbFullPath, sourceLinkMappedUri);
        return CompositeSourceLinkUrlParser.Instance.ParseSourceLinkUrl(sourceLinkMappedUri, out commitSha, out repositoryUrl);
    }

    /// <summary>
    /// Extract the SourceLink information from the assembly attributes "AssemblyMetadataAttribute" and "AssemblyInformationalVersionAttribute".
    /// </summary>
    private static bool ExtractFromAssemblyAttributes(Assembly assembly, out string? commitSha, out string? repositoryUrl)
    {
        commitSha = null;
        repositoryUrl = null;

        foreach (var attribute in assembly.GetCustomAttributes())
        {
            switch (attribute)
            {
                case AssemblyMetadataAttribute { Key: "RepositoryUrl" } amAttr:
                    repositoryUrl = amAttr.Value;
                    break;
                case AssemblyInformationalVersionAttribute { InformationalVersion: { } informationalVersion }:
                {
                    var parts = informationalVersion.Split('+');
                    if (parts.Length == 2)
                    {
                        commitSha = parts[1];
                    }

                    break;
                }
            }

            if (repositoryUrl != null && commitSha != null)
            {
                return true;
            }
        }

        return false;
    }
}
