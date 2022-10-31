// <copyright file="InstrumentationGatewaySecurityEventArgs.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using Datadog.Trace.AppSec.Transports;

namespace Datadog.Trace.AppSec
{
    internal class InstrumentationGatewaySecurityEventArgs : InstrumentationGatewayEventArgs
    {
        public InstrumentationGatewaySecurityEventArgs(IDictionary<string, object> eventData, ITransport transport, Span relatedSpan, bool overrideExistingAddress = true)
            : base(transport, relatedSpan)
        {
            EventData = eventData;
            OverrideExistingAddress = overrideExistingAddress;
        }

        public IDictionary<string, object> EventData { get; }

        public bool OverrideExistingAddress { get; }
    }
}
