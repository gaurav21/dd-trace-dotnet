// <copyright file="TracesTransportStrategy.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using Datadog.Trace.Configuration;
using Datadog.Trace.HttpOverStreams;

namespace Datadog.Trace.Agent
{
    internal static class TracesTransportStrategy
    {
        private static readonly TimeSpan TcpTimeout = TimeSpan.FromSeconds(15);

        public static IApiRequestFactory Get(ImmutableExporterSettings settings)
            => AgentTransportStrategy.Get(
                settings,
                productName: "trace",
                tcpTimeout: TcpTimeout,
                AgentHttpHeaderNames.DefaultHeaders,
                () => new TraceAgentHttpHeaderHelper(),
                uri => uri);
    }
}
