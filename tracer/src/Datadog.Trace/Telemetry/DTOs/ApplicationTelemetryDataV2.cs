﻿// <copyright file="ApplicationTelemetryDataV2.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

namespace Datadog.Trace.Telemetry;

internal class ApplicationTelemetryDataV2
{
    public ApplicationTelemetryDataV2(string serviceName, string env, string serviceVersion, string tracerVersion, string languageName, string languageVersion, string runtimeName, string runtimeVersion)
    {
        ServiceName = serviceName;
        Env = env;
        ServiceVersion = serviceVersion;
        TracerVersion = tracerVersion;
        LanguageName = languageName;
        LanguageVersion = languageVersion;
        RuntimeName = runtimeName;
        RuntimeVersion = runtimeVersion;
    }

    public string ServiceName { get; set; }

    public string Env { get; set; }

    public string ServiceVersion { get; set; }

    public string TracerVersion { get; set; }

    public string LanguageName { get; set; }

    public string LanguageVersion { get; set; }

    public string RuntimeName { get; set; }

    public string RuntimeVersion { get; set; }

    public string? RuntimePatches { get; set; }
}
