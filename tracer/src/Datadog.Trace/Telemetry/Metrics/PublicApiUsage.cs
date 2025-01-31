﻿// <copyright file="PublicApiUsage.cs" company="Datadog">
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
internal enum PublicApiUsage
{
    [Description("spancontextextractor_extract")] SpanContextExtractor_Extract,
    [Description("spanextensions_setuser")] SpanExtensions_SetUser,
    [Description("spanextensions_settracesamplingpriority")] SpanExtensions_SetTraceSamplingPriority,
    [Description("tracer_ctor")] Tracer_Ctor,
    [Description("tracer_ctor_settings")] Tracer_Ctor_Settings,
    [Description("tracer_instance_set")] Tracer_Instance_Set,
    [Description("tracer_configure")] Tracer_Configure,
    [Description("tracer_forceflushasync")] Tracer_ForceFlushAsync,
    [Description("tracer_startactive")] Tracer_StartActive,
    [Description("tracer_startactive_settings")] Tracer_StartActive_Settings,

    // These are problematic, as we use them _everywhere_ so means a lot of code changes
    // [Description("tracer_instance_get")] Tracer_Instance_Get,
    // [Description("tracer_activescope_get")] Tracer_ActiveScope_Get,
    // [Description("tracer_defaultservicename_get")] Tracer_DefaultServiceName_Get,
    // [Description("tracer_settings_get")] Tracer_Settings_Get,

    // These are problematic as we need to use them internally in some cases (version conflict)
    // [Description("iscope_span")] IScope_Span,
    // [Description("iscope_close")] IScope_Close,
    // [Description("ispan_operationname_get")] ISpan_OperationName_Get,
    // [Description("ispan_operationname_set")] ISpan_OperationName_Set,
    // [Description("ispan_resourcename_get")] ISpan_ResourceName_Get,
    // [Description("ispan_resourcename_set")] ISpan_ResourceName_Set,
    // [Description("ispan_type_get")] ISpan_Type_Get,
    // [Description("ispan_type_set")] ISpan_Type_Set,
    // [Description("ispan_error_get")] ISpan_Error_Get,
    // [Description("ispan_error_set")] ISpan_Error_Set,
    // [Description("ispan_servicename_get")] ISpan_ServiceName_Get,
    // [Description("ispan_servicename_set")] ISpan_ServiceName_Set,
    // [Description("ispan_traceid_get")] ISpan_TraceId_Get,
    // [Description("ispan_spanid_get")] ISpan_SpanId_Get,
    // [Description("ispan_context_get")] ISpan_Context_Get,
    // [Description("ispan_settag")] ISpan_SetTag,
    // [Description("ispan_finish")] ISpan_Finish,
    // [Description("ispan_finish_datetimeoffset")] ISpan_Finish_DateTimeOffset,
    // [Description("ispan_setexception")] ISpan_SetException,
    // [Description("ispan_gettag")] ISpan_GetTag,

    [Description("spancontext_ctor")] SpanContext_Ctor,
    // These are problematic as they're used in a _lot_ of places
    // [Description("spancontext_parent_get")] SpanContext_Parent_Get,
    // [Description("spancontext_parentid_get")] SpanContext_ParentId_Get,
    // [Description("spancontext_servicename_get")] SpanContext_ServiceName_Get,
    // [Description("spancontext_servicename_set")] SpanContext_ServiceName_Set,
    // [Description("spancontext_spanid_get")] SpanContext_SpanId_Get,
    // [Description("spancontext_traceid_get")] SpanContext_TraceId_Get,
    [Description("exportersettings_ctor")] ExporterSettings_Ctor,
    [Description("exportersettings_ctor_source")] ExporterSettings_Ctor_Source,
    [Description("exportersettings_agenturi_get")] ExporterSettings_AgentUri_Get,
    [Description("exportersettings_agenturi_set")] ExporterSettings_AgentUri_Set,
    [Description("exportersettings_dogstatsdport_get")] ExporterSettings_DogStatsdPort_Get,
    [Description("exportersettings_dogstatsdport_set")] ExporterSettings_DogStatsdPort_Set,
    [Description("exportersettings_metricspipename_get")] ExporterSettings_MetricsPipeName_Get,
    [Description("exportersettings_metricspipename_set")] ExporterSettings_MetricsPipeName_Set,
    [Description("exportersettings_metricsunixdomainsocketpath_get")] ExporterSettings_MetricsUnixDomainSocketPath_Get,
    [Description("exportersettings_metricsunixdomainsocketpath_set")] ExporterSettings_MetricsUnixDomainSocketPath_Set,
    [Description("exportersettings_partialflushenabled_get")] ExporterSettings_PartialFlushEnabled_Get,
    [Description("exportersettings_partialflushenabled_set")] ExporterSettings_PartialFlushEnabled_Set,
    [Description("exportersettings_partialflushminspans_get")] ExporterSettings_PartialFlushMinSpans_Get,
    [Description("exportersettings_partialflushminspans_set")] ExporterSettings_PartialFlushMinSpans_Set,
    [Description("exportersettings_tracespipename_get")] ExporterSettings_TracesPipeName_Get,
    [Description("exportersettings_tracespipename_set")] ExporterSettings_TracesPipeName_Set,
    [Description("exportersettings_tracespipetimeoutms_get")] ExporterSettings_TracesPipeTimeoutMs_Get,
    [Description("exportersettings_tracespipetimeoutms_set")] ExporterSettings_TracesPipeTimeoutMs_Set,
    [Description("exportersettings_tracesunixdomainsocketpath_get")] ExporterSettings_TracesUnixDomainSocketPath_Get,
    [Description("exportersettings_tracesunixdomainsocketpath_set")] ExporterSettings_TracesUnixDomainSocketPath_Set,
    [Description("globalsettings_debugenabled_get")] GlobalSettings_DebugEnabled_Get,
    [Description("globalsettings_fromdefaultsources")] GlobalSettings_FromDefaultSources,
    [Description("globalsettings_reload")] GlobalSettings_Reload,
    [Description("globalsettings_setdebugenabled")] GlobalSettings_SetDebugEnabled,
    [Description("immutableexportersettings_ctor_settings")] ImmutableExporterSettings_Ctor_Settings,
    [Description("immutableexportersettings_ctor_source")] ImmutableExporterSettings_Ctor_Source,
    [Description("immutableexportersettings_agenturi_get")] ImmutableExporterSettings_AgentUri_Get,
    [Description("immutableexportersettings_dogstatsdport_get")] ImmutableExporterSettings_DogStatsdPort_Get,
    [Description("immutableexportersettings_metricspipename_get")] ImmutableExporterSettings_MetricsPipeName_Get,
    [Description("immutableexportersettings_metricsunixdomainsocketpath_get")] ImmutableExporterSettings_MetricsUnixDomainSocketPath_Get,
    [Description("immutableexportersettings_partialflushenabled_get")] ImmutableExporterSettings_PartialFlushEnabled_Get,
    [Description("immutableexportersettings_partialflushminspans_get")] ImmutableExporterSettings_PartialFlushMinSpans_Get,
    [Description("immutableexportersettings_tracespipename_get")] ImmutableExporterSettings_TracesPipeName_Get,
    [Description("immutableexportersettings_tracespipetimeoutms_get")] ImmutableExporterSettings_TracesPipeTimeoutMs_Get,
    [Description("immutableexportersettings_tracesunixdomainsocketpath_get")] ImmutableExporterSettings_TracesUnixDomainSocketPath_Get,
    [Description("integrationsettings_ctor")] IntegrationSettings_Ctor,
    [Description("integrationsettings_analyticsenabled_get")] IntegrationSettings_AnalyticsEnabled_Get,
    [Description("integrationsettings_analyticsenabled_set")] IntegrationSettings_AnalyticsEnabled_Set,
    [Description("integrationsettings_analyticssamplerate_get")] IntegrationSettings_AnalyticsSampleRate_Get,
    [Description("integrationsettings_analyticssamplerate_set")] IntegrationSettings_AnalyticsSampleRate_Set,
    [Description("integrationsettings_enabled_get")] IntegrationSettings_Enabled_Get,
    [Description("integrationsettings_enabled_set")] IntegrationSettings_Enabled_Set,
    [Description("integrationsettings_integrationname_get")] IntegrationSettings_IntegrationName_Get,
    [Description("integrationsettingscollection_ctor_source")] IntegrationSettingsCollection_Ctor_Source,
    [Description("integrationsettingscollection_indexer_name")] IntegrationSettingsCollection_Indexer_Name,
    [Description("immutableintegrationsettings_analyticsenabled_get")] ImmutableIntegrationSettings_AnalyticsEnabled_Get,
    [Description("immutableintegrationsettings_analyticssamplerate_get")] ImmutableIntegrationSettings_AnalyticsSampleRate_Get,
    [Description("immutableintegrationsettings_enabled_get")] ImmutableIntegrationSettings_Enabled_Get,
    [Description("immutableintegrationsettings_integrationname_get")] ImmutableIntegrationSettings_IntegrationName_Get,
    [Description("immutableintegrationsettingscollection_indexer_name")] ImmutableIntegrationSettingsCollection_Indexer_Name,
    [Description("compositeconfigurationsource_ctor")] CompositeConfigurationSource_Ctor,
    [Description("jsonconfigurationsource_ctor_json")] JsonConfigurationSource_Ctor_Json,
    [Description("jsonconfigurationsource_fromfile")] JsonConfigurationSource_FromFile,
    [Description("stringconfigurationsource_ctor")] StringConfigurationSource_Ctor,
    [Description("environmentconfigurationsource_ctor")] EnvironmentConfigurationSource_Ctor,
    [Description("namevalueconfigurationsource_ctor")] NameValueConfigurationSource_Ctor,
    [Description("tracersettings_ctor")] TracerSettings_Ctor,
    [Description("tracersettings_ctor_source")] TracerSettings_Ctor_Source,
    [Description("tracersettings_ctor_usedefaultsources")] TracerSettings_Ctor_UseDefaultSources,
    [Description("tracersettings_analyticsenabled_get")] TracerSettings_AnalyticsEnabled_Get,
    [Description("tracersettings_analyticsenabled_set")] TracerSettings_AnalyticsEnabled_Set,
    [Description("tracersettings_customsamplingrules_get")] TracerSettings_CustomSamplingRules_Get,
    [Description("tracersettings_customsamplingrules_set")] TracerSettings_CustomSamplingRules_Set,
    [Description("tracersettings_diagnosticsourceenabled_get")] TracerSettings_DiagnosticSourceEnabled_Get,
    [Description("tracersettings_diagnosticsourceenabled_set")] TracerSettings_DiagnosticSourceEnabled_Set,
    [Description("tracersettings_disabledintegrationnames_get")] TracerSettings_DisabledIntegrationNames_Get,
    [Description("tracersettings_disabledintegrationnames_set")] TracerSettings_DisabledIntegrationNames_Set,
    [Description("tracersettings_environment_get")] TracerSettings_Environment_Get,
    [Description("tracersettings_environment_set")] TracerSettings_Environment_Set,
    [Description("tracersettings_exporter_get")] TracerSettings_Exporter_Get,
    [Description("tracersettings_exporter_set")] TracerSettings_Exporter_Set,
    [Description("tracersettings_globalsamplingrate_get")] TracerSettings_GlobalSamplingRate_Get,
    [Description("tracersettings_globalsamplingrate_set")] TracerSettings_GlobalSamplingRate_Set,
    [Description("tracersettings_globaltags_get")] TracerSettings_GlobalTags_Get,
    [Description("tracersettings_globaltags_set")] TracerSettings_GlobalTags_Set,
    [Description("tracersettings_grpctags_get")] TracerSettings_GrpcTags_Get,
    [Description("tracersettings_grpctags_set")] TracerSettings_GrpcTags_Set,
    [Description("tracersettings_headertags_get")] TracerSettings_HeaderTags_Get,
    [Description("tracersettings_headertags_set")] TracerSettings_HeaderTags_Set,
    [Description("tracersettings_integrations_get")] TracerSettings_Integrations_Get,
    [Description("tracersettings_kafkacreateconsumerscopeenabled_get")] TracerSettings_KafkaCreateConsumerScopeEnabled_Get,
    [Description("tracersettings_kafkacreateconsumerscopeenabled_set")] TracerSettings_KafkaCreateConsumerScopeEnabled_Set,
    [Description("tracersettings_logsinjectionenabled_get")] TracerSettings_LogsInjectionEnabled_Get,
    [Description("tracersettings_logsinjectionenabled_set")] TracerSettings_LogsInjectionEnabled_Set,
    [Description("tracersettings_maxtracessubmittedpersecond_get")] TracerSettings_MaxTracesSubmittedPerSecond_Get,
    [Description("tracersettings_maxtracessubmittedpersecond_set")] TracerSettings_MaxTracesSubmittedPerSecond_Set,
    [Description("tracersettings_servicename_get")] TracerSettings_ServiceName_Get,
    [Description("tracersettings_servicename_set")] TracerSettings_ServiceName_Set,
    [Description("tracersettings_serviceversion_get")] TracerSettings_ServiceVersion_Get,
    [Description("tracersettings_serviceversion_set")] TracerSettings_ServiceVersion_Set,
    [Description("tracersettings_startupdiagnosticlogenabled_get")] TracerSettings_StartupDiagnosticLogEnabled_Get,
    [Description("tracersettings_startupdiagnosticlogenabled_set")] TracerSettings_StartupDiagnosticLogEnabled_Set,
    [Description("tracersettings_statscomputationenabled_get")] TracerSettings_StatsComputationEnabled_Get,
    [Description("tracersettings_statscomputationenabled_set")] TracerSettings_StatsComputationEnabled_Set,
    [Description("tracersettings_traceenabled_get")] TracerSettings_TraceEnabled_Get,
    [Description("tracersettings_traceenabled_set")] TracerSettings_TraceEnabled_Set,
    [Description("tracersettings_tracermetricsenabled_get")] TracerSettings_TracerMetricsEnabled_Get,
    [Description("tracersettings_tracermetricsenabled_set")] TracerSettings_TracerMetricsEnabled_Set,
    [Description("tracersettings_build")] TracerSettings_Build,
    [Description("tracersettings_sethttpclienterrorstatuscodes")] TracerSettings_SetHttpClientErrorStatusCodes,
    [Description("tracersettings_sethttpservererrorstatuscodes")] TracerSettings_SetHttpServerErrorStatusCodes,
    [Description("tracersettings_setservicenamemappings")] TracerSettings_SetServiceNameMappings,
    [Description("tracersettings_createdefaultconfigurationsource")] TracerSettings_CreateDefaultConfigurationSource,
    [Description("tracersettings_fromdefaultsources")] TracerSettings_FromDefaultSources,
    [Description("immutabletracersettings_ctor_source")] ImmutableTracerSettings_Ctor_Source,
    [Description("immutabletracersettings_ctor_settings")] ImmutableTracerSettings_Ctor_Settings,
    [Description("immutabletracersettings_analyticsenabled_get")] ImmutableTracerSettings_AnalyticsEnabled_Get,
    [Description("immutabletracersettings_customsamplingrules_get")] ImmutableTracerSettings_CustomSamplingRules_Get,
    [Description("immutabletracersettings_environment_get")] ImmutableTracerSettings_Environment_Get,
    [Description("immutabletracersettings_exporter_get")] ImmutableTracerSettings_Exporter_Get,
    [Description("immutabletracersettings_globalsamplingrate_get")] ImmutableTracerSettings_GlobalSamplingRate_Get,
    [Description("immutabletracersettings_globaltags_get")] ImmutableTracerSettings_GlobalTags_Get,
    [Description("immutabletracersettings_grpctags_get")] ImmutableTracerSettings_GrpcTags_Get,
    [Description("immutabletracersettings_headertags_get")] ImmutableTracerSettings_HeaderTags_Get,
    [Description("immutabletracersettings_integrations_get")] ImmutableTracerSettings_Integrations_Get,
    [Description("immutabletracersettings_kafkacreateconsumerscopeenabled_get")] ImmutableTracerSettings_KafkaCreateConsumerScopeEnabled_Get,
    [Description("immutabletracersettings_logsinjectionenabled_get")] ImmutableTracerSettings_LogsInjectionEnabled_Get,
    [Description("immutabletracersettings_maxtracessubmittedpersecond_get")] ImmutableTracerSettings_MaxTracesSubmittedPerSecond_Get,
    [Description("immutabletracersettings_servicename_get")] ImmutableTracerSettings_ServiceName_Get,
    [Description("immutabletracersettings_serviceversion_get")] ImmutableTracerSettings_ServiceVersion_Get,
    [Description("immutabletracersettings_startupdiagnosticlogenabled_get")] ImmutableTracerSettings_StartupDiagnosticLogEnabled_Get,
    [Description("immutabletracersettings_statscomputationenabled_get")] ImmutableTracerSettings_StatsComputationEnabled_Get,
    [Description("immutabletracersettings_traceenabled_get")] ImmutableTracerSettings_TraceEnabled_Get,
    [Description("immutabletracersettings_tracermetricsenabled_get")] ImmutableTracerSettings_TracerMetricsEnabled_Get,
    [Description("immutabletracersettings_fromdefaultsources")] ImmutableTracerSettings_FromDefaultSources,
}
