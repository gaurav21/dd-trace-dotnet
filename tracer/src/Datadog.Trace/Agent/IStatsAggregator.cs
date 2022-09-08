// <copyright file="IStatsAggregator.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Threading.Tasks;

namespace Datadog.Trace.Agent
{
    internal interface IStatsAggregator
    {
        /// <summary>
        /// Gets a value indicating whether the Datadog agent supports stats
        /// computation in tracers.
        ///
        /// This will return null if 1) enabled by configuration and 2) the
        /// endpoint discovery request has not yet completed.
        ///
        /// This will return true if 1) enabled by configuration, 2) the
        /// endpoint discovery request confirmed that the agent has a stats
        /// endpoint, and 3) the agent confirms it supports the feature
        /// "client_drop_p0s: true".
        ///
        /// This will return false otherwise.
        /// </summary>
        bool? CanComputeStats { get; }

        /// <summary>
        /// Receives an array of spans and computes stats points for them.
        /// </summary>
        /// <param name="spans">The array of spans to process.</param>
        void Add(params Span[] spans);

        /// <summary>
        /// Receives an array of spans and computes stats points for them.
        /// </summary>
        /// <param name="spans">The ArraySegment of spans to process.</param>
        void AddRange(ArraySegment<Span> spans);

        /// <summary>
        /// Runs a series of samplers over the entire trace chunk
        /// </summary>
        /// <param name="spans">The trace chunk to sample</param>
        /// <returns>True if the trace chunk should be sampled, false otherwise.</returns>
        bool ShouldKeepTrace(ArraySegment<Span> spans);

        ArraySegment<Span> ProcessTrace(ArraySegment<Span> trace);

        Task DisposeAsync();
    }
}
