using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace MonctonUG.Grpc.Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task GetWeatherStream(Empty request, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            var rng = new Random();
            for(int index = 1; index <= 5; index++)
            {
                var tempC = rng.Next(-20, 55);
                var weather = MakeWeather(rng, index, tempC);

                Console.WriteLine($"Sending weather {weather.DateTimeStamp}");

                await responseStream.WriteAsync(weather);

                await Task.Delay(1000);

                if (context.CancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelling sending weather");
                    break;
                }
            }
        }

        public override async Task<HelloReply> LotsOfGreetings(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            StringBuilder greetings = new StringBuilder();
            await foreach(var greeting in requestStream.ReadAllAsync())
            {
                Console.WriteLine($"Received {greeting.Name}");
                greetings.AppendLine($"Hello {greeting.Name}");
            }

            Console.WriteLine("Sending Greeting(s)");
            return new HelloReply { Message = greetings.ToString() };
        }

        private static WeatherData MakeWeather(Random rng, int index, int tempC)
        {
            return new WeatherData
            {
                DateTimeStamp = new Timestamp
                {
                    Seconds = DateTimeOffset.Now.AddDays(index).ToUnixTimeSeconds()
                },
                TemperatureC = tempC,
                TemperatureF = (tempC * (9 / 5)),
                Summary = _summaries[rng.Next(_summaries.Length)]
            };
        }

        private static readonly string[] _summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
