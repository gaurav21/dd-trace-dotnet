// <copyright file="AzureServiceBusSenderActivityHandler.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using Datadog.Trace.Activity.DuckTypes;

namespace Datadog.Trace.Activity.Handlers
{
    internal class AzureServiceBusSenderActivityHandler : IActivityHandler
    {
        public bool ShouldListenTo(string sourceName, string? version)
            => sourceName == "Azure.Messaging.ServiceBus.ServiceBusSender";

        public void ActivityStarted<T>(string sourceName, T activity)
            where T : IActivity
        {
            ActivityHandlerCommon.ActivityStarted(sourceName, activity, out var activityMapping);
        }

        public void ActivityStopped<T>(string sourceName, T activity)
            where T : IActivity
            => ActivityHandlerCommon.ActivityStopped(sourceName, activity);
    }
}
