// <copyright file="TracingIntegrationTest.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using Datadog.Trace.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Datadog.Trace.ClrProfiler.IntegrationTests
{
    public abstract class TracingIntegrationTest : TestHelper
    {
        private readonly Dictionary<string, string> _componentToServiceNameMapping = new()
        {
            { "webrequest", "http-client" }
        };

        public TracingIntegrationTest(string sampleAppName, ITestOutputHelper output)
            : base(sampleAppName, output)
        {
        }

        public TracingIntegrationTest(string sampleAppName, string samplePathOverrides, ITestOutputHelper output)
            : base(sampleAppName, samplePathOverrides, output)
        {
        }

        public abstract Result ValidateIntegrationSpan(MockSpan span);

        public void ValidateIntegrationSpans(IEnumerable<MockSpan> spans, string expectedServiceName, bool isExternalSpan = true)
        {
            foreach (var span in spans)
            {
                var result = ValidateIntegrationSpan(span);
                Assert.True(result.Success, result.ToString());

                List<string> serviceNameList = new();
                serviceNameList.Add(expectedServiceName);
                var componentName = span.GetTag("component").ToLower();
                if (_componentToServiceNameMapping.TryGetValue(componentName, out var value))
                {
                    serviceNameList.Add(expectedServiceName + "-" + value);
                }
                else
                {
                    serviceNameList.Add(expectedServiceName + "-" + componentName);
                }

                Assert.Contains(span.Service, serviceNameList);

                if (!(span.GetTag("span.kind") == "server" || span.GetTag("span.kind") == "consumer"))
                {
                    Assert.False(span.Tags?.ContainsKey(Tags.Version), "External service span should not have service version tag.");
                }
            }
        }
    }
}
