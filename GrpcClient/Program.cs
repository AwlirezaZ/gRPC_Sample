using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;

var channel = GrpcChannel.ForAddress("https://localhost:7254");
var greetInput = new HelloRequest { Name="Alireza",Age = 22,IsHim = true };
var greetClient = new Greeter.GreeterClient(channel);
var greetAnswer = greetClient.SayHello(greetInput);
Console.WriteLine(greetAnswer.Message);
Console.WriteLine();
var customerInput = new PostCustomerData { CustId = 2 };
var customerClient = new Customer.CustomerClient(channel);
var customerAnswer = customerClient.CustomerTransfer(customerInput);

Console.WriteLine($"{customerAnswer.Id} {customerAnswer.Name} {customerAnswer.Gender} {customerAnswer.Ispremium} {customerAnswer.Age}");

Console.WriteLine();
Console.WriteLine();

using (var call = customerClient.CustomerStreamingTransfer(new GetCustomersByStreaming()))
{
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.Id} {currentCustomer.Name} {currentCustomer.Gender} {currentCustomer.Ispremium} {currentCustomer.Age}");

    }
}
Console.ReadKey();