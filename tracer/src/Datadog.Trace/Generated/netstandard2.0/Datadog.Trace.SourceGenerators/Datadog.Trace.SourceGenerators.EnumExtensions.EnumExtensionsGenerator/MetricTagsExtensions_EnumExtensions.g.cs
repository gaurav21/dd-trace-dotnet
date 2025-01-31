﻿// <auto-generated />

#nullable enable

namespace Datadog.Trace.Telemetry.Metrics;

/// <summary>
/// Extension methods for <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" />
/// </summary>
internal static partial class MetricTagsExtensions
{
    /// <summary>
    /// The number of members in the enum.
    /// This is a non-distinct count of defined names.
    /// </summary>
    public const int Length = 102;

    /// <summary>
    /// Returns the string representation of the <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags"/> value.
    /// If the attribute is decorated with a <c>[Description]</c> attribute, then
    /// uses the provided value. Otherwise uses the name of the member, equivalent to
    /// calling <c>ToString()</c> on <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to retrieve the string value for</param>
    /// <returns>The string representation of the value</returns>
    public static string ToStringFast(this Datadog.Trace.Telemetry.Metrics.MetricTags value)
        => value switch
        {
            Datadog.Trace.Telemetry.Metrics.MetricTags.None => nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.None),
            Datadog.Trace.Telemetry.Metrics.MetricTags.Total => "component:total",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_ByRefPinvoke => "component:byref_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetStateByRefPinvoke => "component:calltarget_state_byref_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceAttributesPinvoke => "component:traceattributes_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Managed => "component:managed",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDefsPinvoke => "component:calltarget_defs_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Serverless => "component:serverless",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDerivedDefsPinvoke => "component:calltarget_derived_defs_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetInterfaceDefsPinvoke => "component:calltarget_interface_defs_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DiscoveryService => "component:discovery_service",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_RCM => "component:rcm",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DynamicInstrumentation => "component:dynamic_instrumentation",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceMethodsPinvoke => "component:tracemethods_pinvoke",
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Iast => "component:iast",
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SamplingDecision => "reason:sampling_decision",
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SingleSpanSampling => "reason:single_span_sampling",
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_OverfullBuffer => "reason:overfull_buffer",
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SerializationError => "reason:serialization_error",
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_ApiError => "reason:api_error",
            Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_New => "new_continued:new",
            Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_Continued => "new_continued:continued",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_200 => "status_code:200",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_201 => "status_code:201",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_202 => "status_code:202",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_204 => "status_code:204",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_2xx => "status_code:2xx",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_301 => "status_code:301",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_302 => "status_code:302",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_307 => "status_code:307",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_308 => "status_code:308",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_3xx => "status_code:3xx",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_400 => "status_code:400",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_401 => "status_code:401",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_403 => "status_code:403",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_404 => "status_code:404",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_405 => "status_code:405",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_4xx => "status_code:4xx",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_500 => "status_code:500",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_501 => "status_code:501",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_502 => "status_code:502",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_503 => "status_code:503",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_504 => "status_code:504",
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_5xx => "status_code:5xx",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_Timeout => "type:timeout",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_NetworkError => "type:network_error",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_StatusCode => "type:status_code",
            Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_LargeTrace => "reason:large_trace",
            Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_SingleSpanIngestion => "reason:single_span_ingestion",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_TraceContext => "header_style:tracecontext",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_Datadog => "header_style:datadog",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3Multi => "header_style:b3multi",
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3SingleHeader => "header_style:b3single",
            Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agent => "endpoint:agent",
            Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agentless => "endpoint:agentless",
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_TraceAnnotations => "component_name:trace_annotations",
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_DDTraceMethods => "component_name:dd_trace_methods",
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTarget => "component_name:calltarget",
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTargetDerived => "component_name:calltarget_derived",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HttpMessageHandler => "integrations_name:httpmessagehandler",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetCore => "integrations_name:aspnetcore",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AdoNet => "integrations_name:adonet",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNet => "integrations_name:aspnet",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetMvc => "integrations_name:aspnetmvc",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetWebApi2 => "integrations_name:aspnetwebapi2",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_GraphQL => "integrations_name:graphql",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HotChocolate => "integrations_name:hotchocolate",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MongoDb => "integrations_name:mongodb",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_XUnit => "integrations_name:xunit",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NUnit => "integrations_name:nunit",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MsTestV2 => "integrations_name:mstestv2",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Wcf => "integrations_name:wcf",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_WebRequest => "integrations_name:webrequest",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ElasticsearchNet => "integrations_name:elasticsearchnet",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceStackRedis => "integrations_name:servicestackredis",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_StackExchangeRedis => "integrations_name:stackexchangeredis",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceRemoting => "integrations_name:serviceremoting",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_RabbitMQ => "integrations_name:rabbitmq",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Msmq => "integrations_name:msmq",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Kafka => "integrations_name:kafka",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_CosmosDb => "integrations_name:cosmosdb",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSdk => "integrations_name:awssdk",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSqs => "integrations_name:awssqs",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ILogger => "integrations_name:ilogger",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Aerospike => "integrations_name:aerospike",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AzureFunctions => "integrations_name:azurefunctions",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Couchbase => "integrations_name:couchbase",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MySql => "integrations_name:mysql",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Npgsql => "integrations_name:npgsql",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Oracle => "integrations_name:oracle",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SqlClient => "integrations_name:sqlclient",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Sqlite => "integrations_name:sqlite",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Serilog => "integrations_name:serilog",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Log4Net => "integrations_name:log4net",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NLog => "integrations_name:nlog",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_TraceAnnotations => "integrations_name:traceannotations",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Grpc => "integrations_name:grpc",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Process => "integrations_name:process",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HashAlgorithm => "integrations_name:hashalgorithm",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SymmetricAlgorithm => "integrations_name:symmetricalgorithm",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_OpenTelemetry => "integrations_name:opentelemetry",
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsLambda => "integrations_name:aws_lambda",
            _ => value.ToString(),
        };

    /// <summary>
    /// Retrieves an array of the values of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// </summary>
    /// <returns>An array of the values defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" /></returns>
    public static Datadog.Trace.Telemetry.Metrics.MetricTags[] GetValues()
        => new []
        {
            Datadog.Trace.Telemetry.Metrics.MetricTags.None,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Total,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_ByRefPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetStateByRefPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceAttributesPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Managed,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDefsPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Serverless,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDerivedDefsPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetInterfaceDefsPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DiscoveryService,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_RCM,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DynamicInstrumentation,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceMethodsPinvoke,
            Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Iast,
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SamplingDecision,
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SingleSpanSampling,
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_OverfullBuffer,
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SerializationError,
            Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_ApiError,
            Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_New,
            Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_Continued,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_200,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_201,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_202,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_204,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_2xx,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_301,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_302,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_307,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_308,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_3xx,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_400,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_401,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_403,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_404,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_405,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_4xx,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_500,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_501,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_502,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_503,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_504,
            Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_5xx,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_Timeout,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_NetworkError,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_StatusCode,
            Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_LargeTrace,
            Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_SingleSpanIngestion,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_TraceContext,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_Datadog,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3Multi,
            Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3SingleHeader,
            Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agent,
            Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agentless,
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_TraceAnnotations,
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_DDTraceMethods,
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTarget,
            Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTargetDerived,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HttpMessageHandler,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetCore,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AdoNet,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNet,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetMvc,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetWebApi2,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_GraphQL,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HotChocolate,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MongoDb,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_XUnit,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NUnit,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MsTestV2,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Wcf,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_WebRequest,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ElasticsearchNet,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceStackRedis,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_StackExchangeRedis,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceRemoting,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_RabbitMQ,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Msmq,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Kafka,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_CosmosDb,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSdk,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSqs,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ILogger,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Aerospike,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AzureFunctions,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Couchbase,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MySql,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Npgsql,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Oracle,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SqlClient,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Sqlite,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Serilog,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Log4Net,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NLog,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_TraceAnnotations,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Grpc,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Process,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HashAlgorithm,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SymmetricAlgorithm,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_OpenTelemetry,
            Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsLambda,
        };

    /// <summary>
    /// Retrieves an array of the names of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// Ignores <c>[Description]</c> definitions.
    /// </summary>
    /// <returns>An array of the names of the members defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" /></returns>
    public static string[] GetNames()
        => new []
        {
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.None),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Total),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_ByRefPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetStateByRefPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceAttributesPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Managed),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDefsPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Serverless),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetDerivedDefsPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_CallTargetInterfaceDefsPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DiscoveryService),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_RCM),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_DynamicInstrumentation),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_TraceMethodsPinvoke),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.Component_Iast),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SamplingDecision),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SingleSpanSampling),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_OverfullBuffer),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_SerializationError),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason_ApiError),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_New),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.TraceCreated_Continued),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_200),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_201),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_202),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_204),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_2xx),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_301),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_302),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_307),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_308),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_3xx),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_400),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_401),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_403),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_404),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_405),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_4xx),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_500),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_501),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_502),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_503),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_504),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode_5xx),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_Timeout),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_NetworkError),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError_StatusCode),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_LargeTrace),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason_SingleSpanIngestion),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_TraceContext),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_Datadog),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3Multi),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle_B3SingleHeader),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agent),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryApi_Agentless),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_TraceAnnotations),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_DDTraceMethods),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTarget),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationCounts_CallTargetDerived),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HttpMessageHandler),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetCore),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AdoNet),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNet),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetMvc),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AspNetWebApi2),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_GraphQL),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HotChocolate),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MongoDb),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_XUnit),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NUnit),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MsTestV2),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Wcf),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_WebRequest),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ElasticsearchNet),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceStackRedis),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_StackExchangeRedis),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ServiceRemoting),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_RabbitMQ),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Msmq),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Kafka),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_CosmosDb),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSdk),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsSqs),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_ILogger),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Aerospike),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AzureFunctions),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Couchbase),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_MySql),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Npgsql),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Oracle),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SqlClient),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Sqlite),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Serilog),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Log4Net),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_NLog),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_TraceAnnotations),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Grpc),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_Process),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_HashAlgorithm),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_SymmetricAlgorithm),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_OpenTelemetry),
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName_AwsLambda),
        };

    /// <summary>
    /// Retrieves an array of the names of the members defined in
    /// <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" />.
    /// Note that this returns a new array with every invocation, so
    /// should be cached if appropriate.
    /// Uses <c>[Description]</c> definition if available, otherwise uses the name of the property
    /// </summary>
    /// <returns>An array of the names of the members defined in <see cref="Datadog.Trace.Telemetry.Metrics.MetricTags" /></returns>
    public static string[] GetDescriptions()
        => new []
        {
            nameof(Datadog.Trace.Telemetry.Metrics.MetricTags.None),
            "component:total",
            "component:byref_pinvoke",
            "component:calltarget_state_byref_pinvoke",
            "component:traceattributes_pinvoke",
            "component:managed",
            "component:calltarget_defs_pinvoke",
            "component:serverless",
            "component:calltarget_derived_defs_pinvoke",
            "component:calltarget_interface_defs_pinvoke",
            "component:discovery_service",
            "component:rcm",
            "component:dynamic_instrumentation",
            "component:tracemethods_pinvoke",
            "component:iast",
            "reason:sampling_decision",
            "reason:single_span_sampling",
            "reason:overfull_buffer",
            "reason:serialization_error",
            "reason:api_error",
            "new_continued:new",
            "new_continued:continued",
            "status_code:200",
            "status_code:201",
            "status_code:202",
            "status_code:204",
            "status_code:2xx",
            "status_code:301",
            "status_code:302",
            "status_code:307",
            "status_code:308",
            "status_code:3xx",
            "status_code:400",
            "status_code:401",
            "status_code:403",
            "status_code:404",
            "status_code:405",
            "status_code:4xx",
            "status_code:500",
            "status_code:501",
            "status_code:502",
            "status_code:503",
            "status_code:504",
            "status_code:5xx",
            "type:timeout",
            "type:network_error",
            "type:status_code",
            "reason:large_trace",
            "reason:single_span_ingestion",
            "header_style:tracecontext",
            "header_style:datadog",
            "header_style:b3multi",
            "header_style:b3single",
            "endpoint:agent",
            "endpoint:agentless",
            "component_name:trace_annotations",
            "component_name:dd_trace_methods",
            "component_name:calltarget",
            "component_name:calltarget_derived",
            "integrations_name:httpmessagehandler",
            "integrations_name:aspnetcore",
            "integrations_name:adonet",
            "integrations_name:aspnet",
            "integrations_name:aspnetmvc",
            "integrations_name:aspnetwebapi2",
            "integrations_name:graphql",
            "integrations_name:hotchocolate",
            "integrations_name:mongodb",
            "integrations_name:xunit",
            "integrations_name:nunit",
            "integrations_name:mstestv2",
            "integrations_name:wcf",
            "integrations_name:webrequest",
            "integrations_name:elasticsearchnet",
            "integrations_name:servicestackredis",
            "integrations_name:stackexchangeredis",
            "integrations_name:serviceremoting",
            "integrations_name:rabbitmq",
            "integrations_name:msmq",
            "integrations_name:kafka",
            "integrations_name:cosmosdb",
            "integrations_name:awssdk",
            "integrations_name:awssqs",
            "integrations_name:ilogger",
            "integrations_name:aerospike",
            "integrations_name:azurefunctions",
            "integrations_name:couchbase",
            "integrations_name:mysql",
            "integrations_name:npgsql",
            "integrations_name:oracle",
            "integrations_name:sqlclient",
            "integrations_name:sqlite",
            "integrations_name:serilog",
            "integrations_name:log4net",
            "integrations_name:nlog",
            "integrations_name:traceannotations",
            "integrations_name:grpc",
            "integrations_name:process",
            "integrations_name:hashalgorithm",
            "integrations_name:symmetricalgorithm",
            "integrations_name:opentelemetry",
            "integrations_name:aws_lambda",
        };
}