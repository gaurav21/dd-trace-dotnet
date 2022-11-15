// <copyright file="IastRequestContext.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using Microsoft.AspNetCore.Http;

namespace Datadog.Trace.Iast;

internal class IastRequestContext
{
    private VulnerabilityBatch? _vulnerabilityBatch;
    private object _vulnerabilityLock = new();
    private TaintedObjects _taintedObjects;

    public static void AddsIastTagsToSpan(Span span, IastRequestContext? iastRequestContext)
    {
        span.Tags.SetTag(Trace.Tags.IastEnabled, "1");

        iastRequestContext?.AddIastVulnerabilitiesToSpan(span);
    }

    internal void AddIastVulnerabilitiesToSpan(Span span)
    {
        if (_vulnerabilityBatch != null)
        {
            span.Tags.SetTag(Tags.IastJson, _vulnerabilityBatch.ToString());
        }
    }

    internal void AddVulnerability(Vulnerability vulnerability)
    {
        lock (_vulnerabilityLock)
        {
            _vulnerabilityBatch ??= new();
            _vulnerabilityBatch.Add(vulnerability);
        }
    }

#if !NETFRAMEWORK
    internal void TaintHeaders(IHeaderDictionary headers)
    {
        foreach (var header in headers)
        {
            if (!string.IsNullOrEmpty(header.Key))
            {
                _taintedObjects.TaintInputString(header.Key, new Source(SourceType.RequestHeaderName.Item1, null, header.Key));
            }

            foreach (var value in header.Value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _taintedObjects.TaintInputString(value, new Source(SourceType.RequestHeaderValue.Item1, header.Key, value));
                }
            }
        }
    }
#endif
}
