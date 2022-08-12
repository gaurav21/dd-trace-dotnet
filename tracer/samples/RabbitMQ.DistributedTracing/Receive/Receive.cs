﻿using Datadog.Trace;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Receive
{
    class Receive
    {
        // This small application follows the RabbitMQ tutorial at https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
        public static void Main()
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        // Receive message
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        // Log message and properties to screen
                        Console.WriteLine(" [x] Received.");
                        Console.WriteLine("     Message: {0}", message);

                        // extract the context to this message as it has been lost when enqueuing
                        var messageHeaders = ea.BasicProperties?.Headers;
                        if (messageHeaders != null)
                        {
                            var spanContextExtractor = new SpanContextExtractor();
                            var parentContext = spanContextExtractor.Extract(messageHeaders, GetHeaderValues);
                            var spanCreationSettings = new SpanCreationSettings() {Parent = parentContext};

                            // Create child spans
                            using var scope = Tracer.Instance.StartActive("child.span", spanCreationSettings);
                            {
                                Console.WriteLine("You can safely add t");
                            }
                        }
                    };


                    channel.BasicConsume(queue: "hello",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }


        }

        static IEnumerable<string> GetHeaderValues(IDictionary<string, object> headers, string name)
        {
            if (headers == null)
                return Enumerable.Empty<string>();

            if (headers.TryGetValue(name, out object value) && value is byte[] bytes)
            {
                return new[] {Encoding.UTF8.GetString(bytes)};
            }

            return Enumerable.Empty<string>();
        }
    }
}
