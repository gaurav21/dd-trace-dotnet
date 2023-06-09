﻿// <auto-generated/>
#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class CosmosDbV1Tags
    {
        // PeerServiceBytes = MessagePack.Serialize("peer.service");
#if NETCOREAPP
        private static ReadOnlySpan<byte> PeerServiceBytes => new byte[] { 172, 112, 101, 101, 114, 46, 115, 101, 114, 118, 105, 99, 101 };
#else
        private static readonly byte[] PeerServiceBytes = new byte[] { 172, 112, 101, 101, 114, 46, 115, 101, 114, 118, 105, 99, 101 };
#endif
        // PeerServiceSourceBytes = MessagePack.Serialize("_dd.peer.service.source");
#if NETCOREAPP
        private static ReadOnlySpan<byte> PeerServiceSourceBytes => new byte[] { 183, 95, 100, 100, 46, 112, 101, 101, 114, 46, 115, 101, 114, 118, 105, 99, 101, 46, 115, 111, 117, 114, 99, 101 };
#else
        private static readonly byte[] PeerServiceSourceBytes = new byte[] { 183, 95, 100, 100, 46, 112, 101, 101, 114, 46, 115, 101, 114, 118, 105, 99, 101, 46, 115, 111, 117, 114, 99, 101 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "peer.service" => PeerService,
                "_dd.peer.service.source" => PeerServiceSource,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "peer.service": 
                    PeerService = value;
                    break;
                case "_dd.peer.service.source": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(CosmosDbV1Tags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (PeerService is not null)
            {
                processor.Process(new TagItem<string>("peer.service", PeerService, PeerServiceBytes));
            }

            if (PeerServiceSource is not null)
            {
                processor.Process(new TagItem<string>("_dd.peer.service.source", PeerServiceSource, PeerServiceSourceBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (PeerService is not null)
            {
                sb.Append("peer.service (tag):")
                  .Append(PeerService)
                  .Append(',');
            }

            if (PeerServiceSource is not null)
            {
                sb.Append("_dd.peer.service.source (tag):")
                  .Append(PeerServiceSource)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
