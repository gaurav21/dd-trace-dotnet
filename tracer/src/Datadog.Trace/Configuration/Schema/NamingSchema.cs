// <copyright file="NamingSchema.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System.Collections.Generic;

namespace Datadog.Trace.Configuration.Schema
{
    internal class NamingSchema
    {
        public NamingSchema(SchemaVersion version, bool peerServiceTagsEnabled, bool removeClientServiceNamesEnabled, string defaultServiceName, IDictionary<string, string>? serviceNameMappings)
        {
            Version = version;
            RemoveClientServiceNamesEnabled = removeClientServiceNamesEnabled;
            Client = new ClientSchema(version, peerServiceTagsEnabled, removeClientServiceNamesEnabled, defaultServiceName, serviceNameMappings);
            Database = new DatabaseSchema(version, peerServiceTagsEnabled, removeClientServiceNamesEnabled, defaultServiceName, serviceNameMappings);
            Messaging = new MessagingSchema(version, peerServiceTagsEnabled, removeClientServiceNamesEnabled, defaultServiceName, serviceNameMappings);
            Server = new ServerSchema(version);
        }

        // TODO: Temporary, we can probably delete this once we migrate all the code off MetadataSchemaVersion
        public SchemaVersion Version { get; }

        public ClientSchema Client { get; }

        public DatabaseSchema Database { get; }

        public MessagingSchema Messaging { get; }

        public ServerSchema Server { get; }

        public bool RemoveClientServiceNamesEnabled { get; }
    }
}
