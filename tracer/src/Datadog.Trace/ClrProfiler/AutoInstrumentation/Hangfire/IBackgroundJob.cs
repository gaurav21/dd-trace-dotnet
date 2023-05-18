// <copyright file="IBackgroundJob.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Hangfire
{
    internal interface IBackgroundJob
    {
        string Id { get; }

        IJob? Job { get;  }

        DateTime CreatedAt { get; }
    }
}
