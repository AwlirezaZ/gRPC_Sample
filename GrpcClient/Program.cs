using Grpc.Net.Client;
using GrpcClient;

var channel = GrpcChannel.ForAddress("https://localhost:7254");
var input = new HelloRequest { Name="Alireza",Age = 22,IsHim = true };
var client = new Greeter.GreeterClient(channel);
var answer = client.SayHello(input);
Console.WriteLine(answer.Message);
Console.ReadKey();