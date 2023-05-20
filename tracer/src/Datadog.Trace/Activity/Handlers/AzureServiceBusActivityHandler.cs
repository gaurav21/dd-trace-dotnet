// <copyright file="AzureServiceBusActivityHandler.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using Datadog.Trace.Activity.DuckTypes;

namespace Datadog.Trace.Activity.Handlers
{
    /// <summary>
    /// The Activity handler that catches an activity from Azure Service Bus,
    /// creates a datadog span from it, and performs additional customized instrumentation.
    /// </summary>
    internal class AzureServiceBusActivityHandler : IActivityHandler
    {
        public bool ShouldListenTo(string sourceName, string? version)
            => sourceName == "Azure.Messaging.ServiceBus";

        public void ActivityStarted<T>(string sourceName, T activity)
            where T : IActivity
        {
            ActivityHandlerCommon.ActivityStarted(sourceName, activity, out var activityMapping);
            // W3CTraceContextPropagator.CreateTraceStateHeader(activityMapping.Scope.Span.Context);
        }

        public void ActivityStopped<T>(string sourceName, T activity)
            where T : IActivity
            => ActivityHandlerCommon.ActivityStopped(sourceName, activity);
    }
}
