// <copyright file="Count.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System.Diagnostics.CodeAnalysis;
using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Telemetry.Metrics;

// TODO: split these metrics as required
[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1134:Attributes should not share line", Justification = "It's easier to read")]
[TelemetryMetricType(TelemetryMetricType.Count)]
internal enum Count
{
    [TelemetryMetric("integrations_error", 3)] IntegrationsError,
    [TelemetryMetric("span_created", 2)] SpanCreated,
    [TelemetryMetric("span_finished", 0)] SpanFinished,
    [TelemetryMetric("span_dropped", 1)] SpanDropped,
    [TelemetryMetric("span_sampled", 0)] SpanSampled,
    [TelemetryMetric("trace_enqueued", 0)] TraceEnqueued,
    [TelemetryMetric("trace_created", 1)] TraceCreated,
    [TelemetryMetric("trace_dropped", 1)] TraceDropped,
    [TelemetryMetric("trace_sampled", 0)] TraceSampled,
    [TelemetryMetric("trace_sent", 0)] TraceSent,
    [TelemetryMetric("trace_api.requests", 0)] TraceApiRequests,
    [TelemetryMetric("trace_api.responses", 1)] TraceApiResponses,
    [TelemetryMetric("trace_api.errors", 1)] TraceApiErrors,
    [TelemetryMetric("trace_partial_flush", 1)] TracePartialFlush,
    [TelemetryMetric("context_header_style.injected", 1)] ContextHeaderStyleInjected,
    [TelemetryMetric("context_header_style.extracted", 1)] ContextHeaderStyleExtracted,
    [TelemetryMetric("stats_buckets", 0)] StatsBuckets,
    [TelemetryMetric("stats_api.responses", 1)] StatsApiResponses,
    [TelemetryMetric("stats_api.errors", 1)] StatsApiErrors,
    [TelemetryMetric("stats_api.requests", 1)] StatsApiRequests,
    [TelemetryMetric("telemetry_api.requests", 1)] TelemetryApiRequests,
    [TelemetryMetric("telemetry_api.responses", 2)] TelemetryApiResponses,
    [TelemetryMetric("telemetry_api.errors", 1)] TelemetryApiErrors,
}
