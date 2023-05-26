﻿// <copyright file="MetricNamespaceConstants.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

namespace Datadog.Trace.Telemetry;

internal static class MetricNamespaceConstants
{
    public const string Tracer = "tracers";
    public const string Profiler = "profilers";
    public const string RealUserMonitoring = "rum";
    public const string ASM = "appsec";
}
