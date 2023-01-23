// <copyright file="IntegrationSettings.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using Datadog.Trace.SourceGenerators;
using Datadog.Trace.Telemetry.Metrics;
using Datadog.Trace.Util;

namespace Datadog.Trace.Configuration
{
#pragma warning disable SA1401 // field should be private
    /// <summary>
    /// Contains integration-specific settings.
    /// </summary>
    public partial class IntegrationSettings
    {
        /// <summary>
        /// Gets the name of the integration. Used to retrieve integration-specific settings.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.IntegrationSettings_IntegrationName_Get)]
        internal string IntegrationNameInternal;

        /// <summary>
        /// Gets or sets a value indicating whether
        /// this integration is enabled.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.IntegrationSettings_Enabled_Get, PublicApiUsage.IntegrationSettings_Enabled_Set)]
        internal bool? EnabledInternal;

        /// <summary>
        /// Gets or sets a value indicating whether
        /// Analytics are enabled for this integration.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.IntegrationSettings_AnalyticsEnabled_Get, PublicApiUsage.IntegrationSettings_AnalyticsEnabled_Set)]
        internal bool? AnalyticsEnabledInternal;

        /// <summary>
        /// Gets or sets a value between 0 and 1 (inclusive)
        /// that determines the sampling rate for this integration.
        /// </summary>
        [GeneratePublicApi(PublicApiUsage.IntegrationSettings_AnalyticsSampleRate_Get, PublicApiUsage.IntegrationSettings_AnalyticsSampleRate_Set)]
        internal double AnalyticsSampleRateInternal;
#pragma warning restore SA1401

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationSettings"/> class.
        /// </summary>
        /// <param name="integrationName">The integration name.</param>
        /// <param name="source">The <see cref="IConfigurationSource"/> to use when retrieving configuration values.</param>
        [PublicApi]
        public IntegrationSettings(string integrationName, IConfigurationSource source)
            : this(source, integrationName)
        {
            TelemetryMetrics.Instance.Record(PublicApiUsage.IntegrationSettings_Ctor);
        }

        internal IntegrationSettings(IConfigurationSource source, string integrationName)
        {
            if (integrationName is null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(integrationName));
            }

            IntegrationNameInternal = integrationName;

            if (source == null)
            {
                return;
            }

            EnabledInternal = source.GetBool(string.Format(ConfigurationKeys.Integrations.Enabled, integrationName)) ??
                      source.GetBool(string.Format("DD_{0}_ENABLED", integrationName));

#pragma warning disable 618 // App analytics is deprecated, but still used
            AnalyticsEnabledInternal = source.GetBool(string.Format(ConfigurationKeys.Integrations.AnalyticsEnabled, integrationName)) ??
                               source.GetBool(string.Format("DD_{0}_ANALYTICS_ENABLED", integrationName));

            AnalyticsSampleRateInternal = source.GetDouble(string.Format(ConfigurationKeys.Integrations.AnalyticsSampleRate, integrationName)) ??
                                  source.GetDouble(string.Format("DD_{0}_ANALYTICS_SAMPLE_RATE", integrationName)) ??
                                  // default value
                                  1.0;
#pragma warning restore 618
        }
    }
}
