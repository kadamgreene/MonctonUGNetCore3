using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using MonctonUG.Grpc.Server;

namespace MonctonUG.Grpc.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This line is not required on Windows / Linux (only Mac)
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress("http://localhost:6000");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Adam" });
            Console.WriteLine($"Greeting {reply.Message}");

            await foreach(var data in client.GetWeatherStream(new Empty(), new CallOptions()).ResponseStream.ReadAllAsync())
            {
                Console.WriteLine($"{data.DateTimeStamp} will be {data.TemperatureC}C, which is {data.Summary}");
            }
        }
    }
}
