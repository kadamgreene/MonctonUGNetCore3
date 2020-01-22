using System;
using System.Threading;
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
            Console.WriteLine("Press [ENTER] to start");
            Console.ReadLine();

            // This line is not required on Windows / Linux (only Mac)
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress("http://localhost:6000");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Adam" });
            Console.WriteLine($"Greeting {reply.Message}");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var cancelToken = cancellationTokenSource.Token;
            var index = 0;

            using (var weatherRequest = client.GetWeatherStream(new Empty(), new CallOptions()))
            {
                var weatherStream = weatherRequest.ResponseStream;

                await foreach (var (timestamp, temperature, summary) in weatherStream.ReadAllAsync(cancelToken))
                {
                    Console.WriteLine($"{timestamp} will be {temperature}C, which is {summary}");
                    index++;
                    if (index > 2)
                    {
                        break;
                    }
                }
            }

            string[] names = { "Adam", "Gaetan", "Andre" };
            using (var greetingClient = client.LotsOfGreetings())
            {
                var stream = greetingClient.RequestStream;

                foreach (var name in names)
                {
                    Console.WriteLine($"Sending {name}");
                    await stream.WriteAsync(new HelloRequest { Name = name });
                    await Task.Delay(1000);
                }

                await stream.CompleteAsync();

                var response = await greetingClient.ResponseAsync;

                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
