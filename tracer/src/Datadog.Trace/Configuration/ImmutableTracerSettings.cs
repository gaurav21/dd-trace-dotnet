// <copyright file="ImmutableTracerSettings.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Datadog.Trace.ExtensionMethods;
using Datadog.Trace.Logging.DirectSubmission;
using Datadog.Trace.SourceGenerators;
using Datadog.Trace.Telemetry.Metrics;
using Datadog.Trace.Util;

namespace Datadog.Trace.Configuration
{
    /// <summary>
    /// Contains Tracer settings.
    /// </summary>
    public partial class ImmutableTracerSettings
    {
#pragma warning disable SA1401 // field should be private
        private readonly DomainMetadata _domainMetadata;
        internal bool AnalyticsEnabledInternal;

        /// <summary>
        /// Gets the default environment name applied to all spans.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.Environment"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_Environment_Get)]
        internal string EnvironmentInternal;

        /// <summary>
        /// Gets the service name applied to top-level spans and used to build derived service names.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.ServiceName"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_ServiceName_Get)]
        internal string ServiceNameInternal;

        /// <summary>
        /// Gets the version tag applied to all spans.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.ServiceVersion"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_ServiceVersion_Get)]
        internal string ServiceVersionInternal;

        /// <summary>
        /// Gets a value indicating whether tracing is enabled.
        /// Default is <c>true</c>.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.TraceEnabled"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_TraceEnabled_Get)]
        internal bool TraceEnabledInternal;

        /// <summary>
        /// Gets the exporter settings that dictate how the tracer exports data.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_Exporter_Get)]
        internal ImmutableExporterSettings ExporterInternal;

        /// <summary>
        /// Gets a value indicating whether correlation identifiers are
        /// automatically injected into the logging context.
        /// Default is <c>false</c>.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.LogsInjectionEnabled"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_LogsInjectionEnabled_Get)]
        internal bool LogsInjectionEnabledInternal;

        /// <summary>
        /// Gets a value indicating the maximum number of traces set to AutoKeep (p1) per second.
        /// Default is <c>100</c>.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.TraceRateLimit"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_MaxTracesSubmittedPerSecond_Get)]
        internal int MaxTracesSubmittedPerSecondInternal;

        /// <summary>
        /// Gets a value indicating custom sampling rules.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.CustomSamplingRules"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_CustomSamplingRules_Get)]
        internal string CustomSamplingRulesInternal;

        /// <summary>
        /// Gets a value indicating a global rate for sampling.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.GlobalSamplingRate"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_GlobalSamplingRate_Get)]
        internal double? GlobalSamplingRateInternal;

        /// <summary>
        /// Gets a collection of <see cref="ImmutableIntegrationSettings"/> keyed by integration name.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_Integrations_Get)]
        internal ImmutableIntegrationSettingsCollection IntegrationsInternal;

        /// <summary>
        /// Gets the global tags, which are applied to all <see cref="Span"/>s.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_GlobalTags_Get)]
        internal IReadOnlyDictionary<string, string> GlobalTagsInternal;

        /// <summary>
        /// Gets the map of header keys to tag names, which are applied to the root <see cref="Span"/>
        /// of incoming and outgoing requests.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_HeaderTags_Get)]
        internal IReadOnlyDictionary<string, string> HeaderTagsInternal;

        /// <summary>
        /// Gets the map of metadata keys to tag names, which are applied to the root <see cref="Span"/>
        /// of incoming and outgoing GRPC requests.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_GrpcTags_Get)]
        internal IReadOnlyDictionary<string, string> GrpcTagsInternal;

        /// <summary>
        /// Gets a value indicating whether internal metrics
        /// are enabled and sent to DogStatsd.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_TracerMetricsEnabled_Get)]
        internal bool TracerMetricsEnabledInternal;

        /// <summary>
        /// Gets a value indicating whether stats are computed on the tracer side
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_StatsComputationEnabled_Get)]
        internal bool StatsComputationEnabledInternal;

        /// <summary>
        /// Gets a value indicating whether a span context should be created on exiting a successful Kafka
        /// Consumer.Consume() call, and closed on entering Consumer.Consume().
        /// </summary>
        /// <seealso cref="ConfigurationKeys.KafkaCreateConsumerScopeEnabled"/>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_KafkaCreateConsumerScopeEnabled_Get)]
        internal bool KafkaCreateConsumerScopeEnabledInternal;

        /// <summary>
        /// Gets a value indicating whether the diagnostic log at startup is enabled
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.ImmutableTracerSettings_StartupDiagnosticLogEnabled_Get)]
        internal bool StartupDiagnosticLogEnabledInternal;
#pragma warning restore SA1401

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableTracerSettings"/> class
        /// using the specified <see cref="IConfigurationSource"/> to initialize values.
        /// </summary>
        /// <param name="source">The <see cref="IConfigurationSource"/> to use when retrieving configuration values.</param>
        [PublicApi]
        public ImmutableTracerSettings(IConfigurationSource source)
            : this(new TracerSettings(source, true), true)
        {
            TelemetryMetrics.Instance.Record(PublicApiUsage.ImmutableTracerSettings_Ctor_Source);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableTracerSettings"/> class from
        /// a TracerSettings instance.
        /// </summary>
        /// <param name="settings">The tracer settings to use to populate the immutable tracer settings</param>
        [PublicApi]
        public ImmutableTracerSettings(TracerSettings settings)
            : this(settings, true)
        {
            TelemetryMetrics.Instance.Record(PublicApiUsage.ImmutableTracerSettings_Ctor_Settings);
        }

        internal ImmutableTracerSettings(TracerSettings settings, bool calledInternally)
        {
            // DD_ENV has precedence over DD_TAGS
            if (!string.IsNullOrWhiteSpace(settings.EnvironmentInternal))
            {
                EnvironmentInternal = settings.EnvironmentInternal.Trim();
            }
            else
            {
                var env = settings.GlobalTagsInternal.GetValueOrDefault(Tags.Env);

                if (!string.IsNullOrWhiteSpace(env))
                {
                    EnvironmentInternal = env.Trim();
                }
            }

            // DD_VERSION has precedence over DD_TAGS
            if (!string.IsNullOrWhiteSpace(settings.ServiceVersionInternal))
            {
                ServiceVersionInternal = settings.ServiceVersionInternal.Trim();
            }
            else
            {
                var version = settings.GlobalTagsInternal.GetValueOrDefault(Tags.Version);

                if (!string.IsNullOrWhiteSpace(version))
                {
                    ServiceVersionInternal = version.Trim();
                }
            }

            // create dictionary copy without "env" or "version",
            // these value are used for "Environment" and "ServiceVersion"
            // or overriden with DD_ENV and DD_VERSION
            var globalTags = settings.GlobalTagsInternal
                                     .Where(kvp => kvp.Key is not (Tags.Env or Tags.Version))
                                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            GlobalTagsInternal = new ReadOnlyDictionary<string, string>(globalTags);

            ServiceNameInternal = settings.ServiceNameInternal;
            TraceEnabledInternal = settings.TraceEnabledInternal;
            ExporterInternal = new ImmutableExporterSettings(settings.ExporterInternal, true);
#pragma warning disable 618 // App analytics is deprecated, but still used
            AnalyticsEnabledInternal = settings.AnalyticsEnabledInternal;
#pragma warning restore 618
            MaxTracesSubmittedPerSecondInternal = settings.MaxTracesSubmittedPerSecondInternal;
            CustomSamplingRulesInternal = settings.CustomSamplingRulesInternal;
            SpanSamplingRules = settings.SpanSamplingRules;
            GlobalSamplingRateInternal = settings.GlobalSamplingRateInternal;
            IntegrationsInternal = new ImmutableIntegrationSettingsCollection(settings.IntegrationsInternal, settings.DisabledIntegrationNamesInternal);
            HeaderTagsInternal = new ReadOnlyDictionary<string, string>(settings.HeaderTagsInternal);
            GrpcTagsInternal = new ReadOnlyDictionary<string, string>(settings.GrpcTagsInternal);
            IpHeader = settings.IpHeader;
            IpHeaderEnabled = settings.IpHeaderEnabled;
            TracerMetricsEnabledInternal = settings.TracerMetricsEnabledInternal;
            StatsComputationEnabledInternal = settings.StatsComputationEnabledInternal;
            StatsComputationInterval = settings.StatsComputationInterval;
            RuntimeMetricsEnabled = settings.RuntimeMetricsEnabled;
            KafkaCreateConsumerScopeEnabledInternal = settings.KafkaCreateConsumerScopeEnabledInternal;
            StartupDiagnosticLogEnabledInternal = settings.StartupDiagnosticLogEnabledInternal;
            HttpClientExcludedUrlSubstrings = settings.HttpClientExcludedUrlSubstrings;
            HttpServerErrorStatusCodes = settings.HttpServerErrorStatusCodes;
            HttpClientErrorStatusCodes = settings.HttpClientErrorStatusCodes;
            ServiceNameMappings = settings.ServiceNameMappings;
            TraceBufferSize = settings.TraceBufferSize;
            TraceBatchInterval = settings.TraceBatchInterval;
            RouteTemplateResourceNamesEnabled = settings.RouteTemplateResourceNamesEnabled;
            DelayWcfInstrumentationEnabled = settings.DelayWcfInstrumentationEnabled;
            WcfObfuscationEnabled = settings.WcfObfuscationEnabled;
            PropagationStyleInject = settings.PropagationStyleInject;
            PropagationStyleExtract = settings.PropagationStyleExtract;
            TraceMethods = settings.TraceMethods;
            IsActivityListenerEnabled = settings.IsActivityListenerEnabled;
            IsDataStreamsMonitoringEnabled = settings.IsDataStreamsMonitoringEnabled;
            IsRareSamplerEnabled = settings.IsRareSamplerEnabled;

            LogSubmissionSettings = ImmutableDirectLogSubmissionSettings.Create(settings.LogSubmissionSettings);
            // Logs injection is enabled by default if direct log submission is enabled, otherwise disabled by default
            LogsInjectionEnabledInternal = settings.LogSubmissionSettings.LogsInjectionEnabled ?? LogSubmissionSettings.IsEnabled;

            // we cached the static instance here, because is being used in the hotpath
            // by IsIntegrationEnabled method (called from all integrations)
            _domainMetadata = DomainMetadata.Instance;

            ExpandRouteTemplatesEnabled = settings.ExpandRouteTemplatesEnabled || !RouteTemplateResourceNamesEnabled;

            // tag propagation
            OutgoingTagPropagationHeaderMaxLength = settings.OutgoingTagPropagationHeaderMaxLength;

            // query string related env variables
            ObfuscationQueryStringRegex = settings.ObfuscationQueryStringRegex;
            QueryStringReportingEnabled = settings.QueryStringReportingEnabled;
            ObfuscationQueryStringRegexTimeout = settings.ObfuscationQueryStringRegexTimeout;

            IsRunningInAzureAppService = settings.IsRunningInAzureAppService;
            AzureAppServiceMetadata = settings.AzureAppServiceMetadata;
        }

        /// <summary>
        /// Gets a value indicating whether default Analytics are enabled.
        /// Settings this value is a shortcut for setting
        /// <see cref="IntegrationSettings.AnalyticsEnabled"/> on some predetermined integrations.
        /// See the documentation for more details.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.GlobalAnalyticsEnabled"/>
        [Obsolete(DeprecationMessages.AppAnalytics)]
        public bool AnalyticsEnabled
        {
            get
            {
                TelemetryMetrics.Instance.Record(PublicApiUsage.ImmutableTracerSettings_AnalyticsEnabled_Get);
                return AnalyticsEnabledInternal;
            }
        }

        /// <summary>
        /// Gets a value indicating the span sampling rules.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.SpanSamplingRules"/>
        internal string SpanSamplingRules { get; }

        /// <summary>
        /// Gets a custom request header configured to read the ip from. For backward compatibility, it fallbacks on DD_APPSEC_IPHEADER
        /// </summary>
        internal string IpHeader { get; }

        /// <summary>
        /// Gets a value indicating whether the ip header should be collected. The default is false.
        /// </summary>
        internal bool IpHeaderEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether runtime metrics
        /// are enabled and sent to DogStatsd.
        /// </summary>
        internal bool RuntimeMetricsEnabled { get; }

        /// <summary>
        /// Gets a value indicating the time interval (in seconds) for sending stats
        /// </summary>
        internal int StatsComputationInterval { get; }

        /// <summary>
        /// Gets the comma separated list of url patterns to skip tracing.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.HttpClientExcludedUrlSubstrings"/>
        internal string[] HttpClientExcludedUrlSubstrings { get; }

        /// <summary>
        /// Gets the HTTP status code that should be marked as errors for server integrations.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.HttpServerErrorStatusCodes"/>
        internal bool[] HttpServerErrorStatusCodes { get; }

        /// <summary>
        /// Gets the HTTP status code that should be marked as errors for client integrations.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.HttpClientErrorStatusCodes"/>
        internal bool[] HttpClientErrorStatusCodes { get; }

        /// <summary>
        /// Gets configuration values for changing service names based on configuration
        /// </summary>
        internal ServiceNames ServiceNameMappings { get; }

        /// <summary>
        /// Gets a value indicating the size in bytes of the trace buffer
        /// </summary>
        internal int TraceBufferSize { get; }

        /// <summary>
        /// Gets a value indicating the batch interval for the serialization queue, in milliseconds
        /// </summary>
        internal int TraceBatchInterval { get; }

        /// <summary>
        /// Gets a value indicating whether the feature flag to enable the updated ASP.NET resource names is enabled
        /// </summary>
        /// <seealso cref="ConfigurationKeys.FeatureFlags.RouteTemplateResourceNamesEnabled"/>
        internal bool RouteTemplateResourceNamesEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether route parameters in ASP.NET and ASP.NET Core resource names
        /// should be expanded with their values. Only applies when  <see cref="RouteTemplateResourceNamesEnabled"/>
        /// is enabled.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.ExpandRouteTemplatesEnabled"/>
        internal bool ExpandRouteTemplatesEnabled { get; }

        /// <summary>
        /// Gets a value indicating the regex to apply to obfuscate http query strings.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.ObfuscationQueryStringRegex"/>
        internal string ObfuscationQueryStringRegex { get; }

        /// <summary>
        /// Gets a value indicating whether or not http.url should contain the query string, enabled by default with DD_HTTP_SERVER_TAG_QUERY_STRING
        /// </summary>
        internal bool QueryStringReportingEnabled { get; }

        /// <summary>
        /// Gets a value indicating a timeout in milliseconds to the execution of the query string obfuscation regex
        /// Default value is 200ms
        /// </summary>
        internal double ObfuscationQueryStringRegexTimeout { get; }

        internal ImmutableDirectLogSubmissionSettings LogSubmissionSettings { get; }

        /// <summary>
        /// Gets a value indicating whether to enable the updated WCF instrumentation that delays execution
        /// until later in the WCF pipeline when the WCF server exception handling is established.
        /// </summary>
        internal bool DelayWcfInstrumentationEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether to obfuscate the <c>LocalPath</c> of a WCF request that goes
        /// into the <c>resourceName</c> of a span.
        /// </summary>
        internal bool WcfObfuscationEnabled { get; }

        /// <summary>
        /// Gets a value indicating the injection propagation style.
        /// </summary>
        internal string[] PropagationStyleInject { get; }

        /// <summary>
        /// Gets a value indicating the extraction propagation style.
        /// </summary>
        internal string[] PropagationStyleExtract { get; }

        /// <summary>
        /// Gets a value indicating the trace methods configuration.
        /// </summary>
        internal string TraceMethods { get; }

        /// <summary>
        /// Gets a value indicating whether the activity listener is enabled or not.
        /// </summary>
        internal bool IsActivityListenerEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether data streams monitoring is enabled or not.
        /// </summary>
        internal bool IsDataStreamsMonitoringEnabled { get; }

        /// <summary>
        /// Gets the maximum length of an outgoing propagation header's value ("x-datadog-tags")
        /// when injecting it into downstream service calls.
        /// </summary>
        /// <seealso cref="ConfigurationKeys.TagPropagation.HeaderMaxLength"/>
        /// <remarks>
        /// This value is not used when extracting an incoming propagation header from an upstream service.
        /// </remarks>
        internal int OutgoingTagPropagationHeaderMaxLength { get; }

        /// <summary>
        /// Gets a value indicating whether the rare sampler is enabled
        /// </summary>
        internal bool IsRareSamplerEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the tracer is running in AAS
        /// </summary>
        internal bool IsRunningInAzureAppService { get; }

        /// <summary>
        /// Gets the AAS settings
        /// </summary>
        internal ImmutableAzureAppServiceSettings AzureAppServiceMetadata { get; }

        /// <summary>
        /// Create a <see cref="ImmutableTracerSettings"/> populated from the default sources
        /// returned by <see cref="GlobalConfigurationSource.Instance"/>.
        /// </summary>
        /// <returns>A <see cref="ImmutableTracerSettings"/> populated from the default sources.</returns>
        [PublicApi]
        public static ImmutableTracerSettings FromDefaultSources()
        {
            TelemetryMetrics.Instance.Record(PublicApiUsage.ImmutableTracerSettings_FromDefaultSources);
            return FromDefaultSourcesInternal();
        }

        internal static ImmutableTracerSettings FromDefaultSourcesInternal()
            => new(new TracerSettings(GlobalConfigurationSource.Instance, true), true);

        internal bool IsErrorStatusCode(int statusCode, bool serverStatusCode)
        {
            var source = serverStatusCode ? HttpServerErrorStatusCodes : HttpClientErrorStatusCodes;

            if (source == null)
            {
                return false;
            }

            if (statusCode >= source.Length)
            {
                return false;
            }

            return source[statusCode];
        }

        internal bool IsIntegrationEnabled(IntegrationId integration, bool defaultValue = true)
        {
            if (TraceEnabledInternal && !_domainMetadata.ShouldAvoidAppDomain())
            {
                return IntegrationsInternal[integration].EnabledInternal ?? defaultValue;
            }

            return false;
        }

        [Obsolete(DeprecationMessages.AppAnalytics)]
        internal double? GetIntegrationAnalyticsSampleRate(IntegrationId integration, bool enabledWithGlobalSetting)
        {
            var integrationSettings = IntegrationsInternal[integration];
            var analyticsEnabled = integrationSettings.AnalyticsEnabledInternal ?? (enabledWithGlobalSetting && AnalyticsEnabledInternal);
            return analyticsEnabled ? integrationSettings.AnalyticsSampleRateInternal : (double?)null;
        }

        internal string GetServiceName(Tracer tracer, string serviceName)
        {
            return ServiceNameMappings.GetServiceName(tracer.DefaultServiceName, serviceName);
        }

        internal bool TryGetServiceName(string key, out string serviceName)
        {
            return ServiceNameMappings.TryGetServiceName(key, out serviceName);
        }
    }
}
