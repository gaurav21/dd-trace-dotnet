﻿// <copyright file="Sources.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Text;

namespace Datadog.Trace.SourceGenerators.TracerSettingsSnapshot;

internal class Sources
{
    public const string Attributes = """
        // <auto-generated/>
        #nullable enable

        namespace Datadog.Trace.SourceGenerators;

        /// <summary>
        /// Used to indicate the configuration key that this settable property corresponds to.
        /// Used for automatically generating a snapshot of the properties to track changes
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
        internal class ConfigKeyAttribute : System.Attribute
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ConfigKeyAttribute"/> class.
            /// </summary>
            /// <param name="configurationKey">The configuration key to record in config</param>
            public ConfigKeyAttribute(string configurationKey)
            {
                ConfigurationKey = configurationKey;
            }

            /// <summary>
            /// Gets the configuration key to record in config
            /// </summary>
            public string ConfigurationKey { get; }
        }

        /// <summary>
        /// Used to generate the snapshot class for the type
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
        internal class GenerateSnapshotAttribute : System.Attribute
        {
        }

        /// <summary>
        /// Used to ignore an otherwise eligible property from snapshotting
        /// </summary>
        [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
        internal class IgnoreForSnapshotAttribute : System.Attribute
        {
        }
        """;

    public static string GenerateSnapshotClass(StringBuilder sb, in SnapshotClass cls)
    {
        return $$"""
            // <auto-generated />

            using Datadog.Trace.Configuration.Telemetry;

            #nullable enable
            #pragma warning disable CS0618 // Type is obsolete

            namespace {{cls.Namespace}};

            internal partial class {{cls.SnapshotClassName}} : SettingsSnapshotBase
            {
                internal {{cls.SnapshotClassName}}({{cls.FullyQualifiedOriginalClassName}} settings)
                {{{GetConstructorProperties(sb, in cls)}}
                    AdditionalInitialization(settings);
                }
            {{GetPropertyDefinitions(sb, in cls)}}

                internal void RecordChanges({{cls.FullyQualifiedOriginalClassName}} settings, IConfigurationTelemetry telemetry)
                {{{GetRecordIfChangedDefinitions(sb, in cls)}}
                    RecordAdditionalChanges(settings, telemetry);
                }

                partial void AdditionalInitialization({{cls.FullyQualifiedOriginalClassName}} settings);
                partial void RecordAdditionalChanges({{cls.FullyQualifiedOriginalClassName}} settings, IConfigurationTelemetry telemetry);
            }
            """;
    }

    private static string GetConstructorProperties(StringBuilder sb, in SnapshotClass cls)
    {
        sb.Clear();
        foreach (var property in cls.Properties)
        {
            sb.AppendLine()
              .Append("        ")
              .Append(property.PropertyName);

            switch (property.ReturnType)
            {
                case "System.Collections.Generic.HashSet<string>":
                    sb.Append(" = GetHashSet(settings.").Append(property.PropertyName).Append(");");
                    break;
                case "System.Collections.Generic.Dictionary<string, string>":
                case "System.Collections.Generic.IDictionary<string, string>":
                    sb.Append(" = GetDictionary(settings.").Append(property.PropertyName).Append(");");
                    break;
                default:
                    sb.Append(" = settings.").Append(property.PropertyName).Append(';');
                    break;
            }
        }

        return sb.ToString();
    }

    private static string GetPropertyDefinitions(StringBuilder sb, in SnapshotClass cls)
    {
        sb.Clear();
        foreach (var property in cls.Properties)
        {
            sb.AppendLine()
              .Append("    private ")
              .Append(property.ReturnType);

            switch (property.ReturnType)
            {
                case "System.Collections.Generic.HashSet<string>":
                case "System.Collections.Generic.Dictionary<string, string>":
                case "System.Collections.Generic.IDictionary<string, string>":
                    sb.Append('?'); // collections need to be marked nullable
                    break;
            }

            sb.Append(' ')
              .Append(property.PropertyName)
              .Append(" { get; }");
        }

        return sb.ToString();
    }

    private static string GetRecordIfChangedDefinitions(StringBuilder sb, in SnapshotClass cls)
    {
        sb.Clear();

        foreach (var property in cls.Properties)
        {
            sb.AppendLine()
              .Append("        RecordIfChanged(telemetry, \"")
              .Append(property.ConfigurationKey)
              .Append("\", ")
              .Append(property.PropertyName);

            switch (property.ReturnType)
            {
                case "System.Collections.Generic.HashSet<string>":
                    sb.Append(", GetHashSet(settings.").Append(property.PropertyName).Append("));");
                    break;
                case "System.Collections.Generic.Dictionary<string, string>":
                case "System.Collections.Generic.IDictionary<string, string>":
                    sb.Append(", GetDictionary(settings.").Append(property.PropertyName).Append("));");
                    break;
                default:
                    sb.Append(", settings.").Append(property.PropertyName).Append(");");
                    break;
            }
        }

        return sb.ToString();
    }
}
