// <copyright file="OpenTelemetrySdkTests.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datadog.Trace.Configuration;
using Datadog.Trace.TestHelpers;
using FluentAssertions;
using FluentAssertions.Execution;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.ClrProfiler.IntegrationTests
{
    [UsesVerify]
    public class OpenTelemetrySdkTests : TracingIntegrationTest
    {
        public OpenTelemetrySdkTests(ITestOutputHelper output)
            : base("OpenTelemetrySdk", output)
        {
            // Intentionally unset service name and version, which may be derived from OTEL SDK
            SetServiceName(string.Empty);
            SetServiceVersion(string.Empty);
        }

        public override Result ValidateIntegrationSpan(MockSpan span) =>
            span.IsOpenTelemetry(excludeTags: new HashSet<string>
            {
                "attribute-string",
                "attribute-int",
                "attribute-bool",
                "attribute-double",
                "attribute-stringArray",
                "attribute-stringArrayEmpty",
                "attribute-intArray",
                "attribute-intArrayEmpty",
                "attribute-boolArray",
                "attribute-boolArrayEmpty",
                "attribute-doubleArray",
                "attribute-doubleArrayEmpty",
            });

        [SkippableTheory]
        [Trait("Category", "EndToEnd")]
        [Trait("RunOnWindows", "True")]
        [MemberData(nameof(PackageVersions.OpenTelemetry), MemberType = typeof(PackageVersions))]
        public async Task SubmitsTraces(string packageVersion)
        {
            SetEnvironmentVariable("DD_TRACE_OTEL_ENABLED", "true");

            using (var telemetry = this.ConfigureTelemetry())
            using (var agent = EnvironmentHelper.GetMockAgent())
            using (RunSampleAndWaitForExit(agent, packageVersion: packageVersion))
            {
                const int expectedSpanCount = 11;
                var spans = agent.WaitForSpans(expectedSpanCount);

                using var s = new AssertionScope();
                spans.Count.Should().Be(expectedSpanCount);

                var myServiceNameSpans = spans.Where(s => s.Service == "MyServiceName");
                var otherLibrarySpans = spans.Where(s => s.Service != "MyServiceName");

                ValidateIntegrationSpans(myServiceNameSpans, expectedServiceName: "MyServiceName");
                ValidateIntegrationSpans(otherLibrarySpans, expectedServiceName: "OtherLibrary");

                // there's a bug in < 1.2.0 where they get the span parenting wrong
                // so use a separate snapshot
                var filename = nameof(OpenTelemetrySdkTests) + GetSuffix(packageVersion);

                var settings = VerifyHelper.GetSpanVerifierSettings();
                await VerifyHelper.VerifySpans(spans, settings)
                                  .UseFileName(filename)
                                  .DisableRequireUniquePrefix();

                telemetry.AssertIntegrationEnabled(IntegrationId.OpenTelemetry);
            }
        }

        [SkippableTheory]
        [Trait("Category", "EndToEnd")]
        [Trait("RunOnWindows", "True")]
        [MemberData(nameof(PackageVersions.OpenTelemetry), MemberType = typeof(PackageVersions))]
        public void IntegrationDisabled(string packageVersion)
        {
            using (var telemetry = this.ConfigureTelemetry())
            using (var agent = EnvironmentHelper.GetMockAgent())
            using (RunSampleAndWaitForExit(agent, packageVersion: packageVersion))
            {
                var spans = agent.WaitForSpans(1, 2000);

                using var s = new AssertionScope();
                spans.Should().BeEmpty();
                telemetry.AssertIntegrationDisabled(IntegrationId.OpenTelemetry);
            }
        }

        private static string GetSuffix(string packageVersion)
        {
            // The snapshots are only different in .NET Core 2.1 - .NET 5 with package version 1.0.1
#if !NET6_0_OR_GREATER
            if (!string.IsNullOrEmpty(packageVersion)
             && new Version(packageVersion) < new Version("1.2.0"))
            {
                return "_1_0";
            }
#endif

            return string.Empty; // default is >= 1.2.0
        }
    }
}