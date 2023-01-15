// <copyright file="AspNetCore5AsmRemoteRules.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#if NETCOREAPP3_0_OR_GREATER

using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Threading.Tasks;
using Datadog.Trace.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.Security.IntegrationTests.Rcm
{
    public class AspNetCore5AsmRemoteRules : RcmBase
    {
        public AspNetCore5AsmRemoteRules(AspNetCoreTestFixture fixture, ITestOutputHelper outputHelper)
            : base(fixture, outputHelper, enableSecurity: true, testName: nameof(AspNetCore5AsmRemoteRules))
        {
        }

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task TestNewRemoteRules()
        {
            var url = "/Health/?[$slice]=value";
            await TryStartApp();
            var agent = Fixture.Agent;
            using var logEntryWatcher = new LogEntryWatcher($"{LogFileNamePrefix}{Fixture.Process.ProcessName}*", LogDirectory);
            var settings = VerifyHelper.GetSpanVerifierSettings();

            var spans1 = await SendRequestsAsync(agent, url);

            await agent.SetupRcmAndWait(Output, new[] { (GetRules("2.22.222"), "1") }, "ASM_DD");
            await logEntryWatcher.WaitForLogEntry(WafUpdateRule(), LogEntryWatcherTimeout);
            var spans2 = await SendRequestsAsync(agent, url);

            await agent.SetupRcmAndWait(Output, new[] { (GetRules("3.33.333"), "2") }, "ASM_DD");
            await logEntryWatcher.WaitForLogEntry(WafUpdateRule(), LogEntryWatcherTimeout);
            var spans3 = await SendRequestsAsync(agent, url);

            var spans = new List<MockSpan>();
            spans.AddRange(spans1);
            spans.AddRange(spans2);
            spans.AddRange(spans3);

            await VerifySpans(spans.ToImmutableList(), settings);
        }

        private string GetRules(string version)
        {
            return File.ReadAllText("remote-rules.json").Replace("{VERSION}", version);
        }
    }
}
#endif
