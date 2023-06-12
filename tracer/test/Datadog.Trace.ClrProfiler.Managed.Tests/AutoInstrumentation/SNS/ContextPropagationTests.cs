// <copyright file="ContextPropagationTests.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Datadog.Trace.ClrProfiler.AutoInstrumentation.AWS.SNS;
using FluentAssertions;
using Moq;
using Xunit;

namespace Datadog.Trace.ClrProfiler.Managed.Tests.AutoInstrumentation.AWS.SNS
{
    public class ContextPropagationTests
    {
        [Fact]
        public void TestSnsSendMessageTraceInjectionWithNoMessageAttributes()
        {
            // Arrange
            var mockSpanContext = new Mock<SpanContext>();
            var mockCarrier = new Mock<IContainsMessageAttributes>();
            var messageAttributes = new Dictionary<string, MockMessageAttributeValue>();
            mockCarrier.Setup(x => x.MessageAttributes).Returns(messageAttributes);

            // Act
            ContextPropagation.InjectHeadersIntoMessage<MockMessageAttributeValue>(mockCarrier.Object, mockSpanContext.Object);

            // Assert
            messageAttributes.Should().ContainKey("_datadog");
            messageAttributes["_datadog"].Should().NotBeNull();
        }

        [Fact]
        public void TestSnsSendMessageTraceInjectionWithMessageAttributes()
        {
            // Arrange
            var mockSpanContext = new Mock<SpanContext>();
            var mockCarrier = new Mock<IContainsMessageAttributes>();
            var messageAttributes = new Dictionary<string, MockMessageAttributeValue>
            {
                { "one", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("one")) } },
                { "two", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("two")) } },
                { "three", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("three")) } },
                { "four", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("four")) } },
                { "five", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("five")) } },
                { "six", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("six")) } },
                { "seven", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("seven")) } },
                { "eight", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("eight")) } },
                { "nine", new MockMessageAttributeValue { DataType = "Binary", BinaryValue = new MemoryStream(Encoding.UTF8.GetBytes("nine")) } }
            };
            mockCarrier.Setup(x => x.MessageAttributes).Returns(messageAttributes);

            // Act
            ContextPropagation.InjectHeadersIntoMessage<MockMessageAttributeValue>(mockCarrier.Object, mockSpanContext.Object);

            // Assert
            messageAttributes.Should().ContainKey("_datadog");
            messageAttributes["_datadog"].Should().NotBeNull();
            messageAttributes.Count.Should().Be(10); // original 9 attributes plus _datadog
        }

        private class MockMessageAttributeValue
        {
            public string DataType { get; set; }

            public MemoryStream BinaryValue { get; set; }
        }
    }
}
