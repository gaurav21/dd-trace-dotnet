// <copyright file="MetricTags.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Telemetry.Metrics;

[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1134:Attributes should not share line", Justification = "It's easier to read")]
[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "It's easier to read")]
[EnumExtensions]
internal enum MetricTags
{
    None,
    // Tracer components
    [Description("total")] Total,
    [Description("component:byref_pinvoke")] Component_ByRefPinvoke,
    [Description("component:calltarget_state_byref_pinvoke")] Component_CallTargetStateByRefPinvoke,
    [Description("component:traceattributes_pinvoke")] Component_TraceAttributesPinvoke,
    [Description("component:managed")] Component_Managed,
    [Description("component:calltarget_defs_pinvoke")] Component_CallTargetDefsPinvoke,
    [Description("component:serverless")] Component_Serverless,
    [Description("component:calltarget_derived_defs_pinvoke")] Component_CallTargetDerivedDefsPinvoke,
    [Description("component:calltarget_interface_defs_pinvoke")] Component_CallTargetInterfaceDefsPinvoke,
    [Description("component:discovery_service")] Component_DiscoveryService,
    [Description("component:rcm")] Component_RCM,
    [Description("component:dynamic_instrumentation")] Component_DynamicInstrumentation,
    [Description("component:tracemethods_pinvoke")] Component_TraceMethodsPinvoke,

    // Drop reasons
    [Description("drop_reason:overfull_buffer")] DropReason_OverfullBuffer,
    [Description("drop_reason:serialization_error")] DropReason_SerializationError,
    [Description("drop_reason:unsampled")] DropReason_Unsampled,
    [Description("drop_reason:api_error")] DropReason_ApiError,
}
