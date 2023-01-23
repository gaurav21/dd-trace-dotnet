// <copyright file="IntegrationSettingsCollection.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using Datadog.Trace.Logging;
using Datadog.Trace.SourceGenerators;
using Datadog.Trace.Telemetry.Metrics;

namespace Datadog.Trace.Configuration
{
    /// <summary>
    /// A collection of <see cref="IntegrationSettings"/> instances, referenced by name.
    /// </summary>
    public class IntegrationSettingsCollection
    {
        private static readonly IDatadogLogger Log = DatadogLogging.GetLoggerFor<IntegrationSettingsCollection>();
        private readonly IntegrationSettings[] _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationSettingsCollection"/> class.
        /// </summary>
        /// <param name="source">The <see cref="IConfigurationSource"/> to use when retrieving configuration values.</param>
        [PublicApi]
        public IntegrationSettingsCollection(IConfigurationSource source)
            : this(GetIntegrationSettings(source))
        {
            TelemetryMetrics.Instance.Record(PublicApiUsage.IntegrationSettingsCollection_Ctor_Source);
        }

        private IntegrationSettingsCollection(IntegrationSettings[] settings)
        {
            _settings = settings;
        }

        internal IntegrationSettings[] Settings => _settings;

        /// <summary>
        /// Gets the <see cref="IntegrationSettings"/> for the specified integration.
        /// </summary>
        /// <param name="integrationName">The name of the integration.</param>
        /// <returns>The integration-specific settings for the specified integration.</returns>
        [PublicApi]
        public IntegrationSettings this[string integrationName]
        {
            get
            {
                TelemetryMetrics.Instance.Record(PublicApiUsage.IntegrationSettingsCollection_Indexer_Name);
                return Get(integrationName);
            }
        }

        internal static IntegrationSettingsCollection Create(IConfigurationSource source)
            => new(GetIntegrationSettings(source));

        internal IntegrationSettings Get(string integrationName)
        {
            if (IntegrationRegistry.TryGetIntegrationId(integrationName, out var integrationId))
            {
                return _settings[(int)integrationId];
            }

            Log.Warning(
                "Accessed integration settings for unknown integration {IntegrationName}. " +
                "Returning default settings, changes will not be saved",
                integrationName);

            return new IntegrationSettings(source: null, integrationName);
        }

        private static IntegrationSettings[] GetIntegrationSettings(IConfigurationSource source)
        {
            var integrations = new IntegrationSettings[IntegrationRegistry.Names.Length];

            for (int i = 0; i < integrations.Length; i++)
            {
                var name = IntegrationRegistry.Names[i];

                if (name != null)
                {
                    integrations[i] = new IntegrationSettings(source, name);
                }
            }

            return integrations;
        }
    }
}
