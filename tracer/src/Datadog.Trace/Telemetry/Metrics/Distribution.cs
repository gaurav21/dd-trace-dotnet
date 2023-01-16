// <copyright file="Distribution.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System.Diagnostics.CodeAnalysis;
using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Telemetry.Metrics;

[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1134:Attributes should not share line", Justification = "It's easier to read")]
[TelemetryMetricType(TelemetryMetricType.Distribution)]
internal enum Distribution
{
    [TelemetryMetric("init_time", 1)] InitTime,
    [TelemetryMetric("trace_size", 0)] TraceSize,
}
