// <copyright file="AspNetCore2RateLimiter.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#if NETCOREAPP2_1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Datadog.Trace.TestHelpers;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.Security.IntegrationTests
{
    public class AspNetCore2RateLimiter : AspNetBase, IDisposable
    {
        public AspNetCore2RateLimiter(ITestOutputHelper outputHelper)
            : base("AspNetCore2", outputHelper, "/shutdown")
        {
        }

        [SkippableTheory(Skip = "Don't run in CI as test is slow, can be run manually by removing this attribute")]
        [InlineData(true, 90, 100)]
        [InlineData(false, 90, 100)]
        [InlineData(true, 110, 100)]
        [InlineData(false, 110, 100)]
        [InlineData(true, 30, 20)]
        [InlineData(false, 30, 20)]
        [Trait("RunOnWindows", "True")]
        [Trait("Category", "ArmUnsupported")]
        public async Task TestRateLimiterSecurity(bool enableSecurity, int totalRequests, int traceRateLimit, string url = DefaultAttackUrl)
        {
            var agent = RunOnSelfHosted(enableSecurity, traceRateLimit: traceRateLimit, externalRulesFile: DefaultRuleFile);
            await TestRateLimiter(enableSecurity, url, agent, traceRateLimit, totalRequests, 1);
        }
    }
}
#endif
