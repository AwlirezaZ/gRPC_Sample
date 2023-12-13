using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            this.logger = logger;
        }
        public override Task<GetCustomers> CustomerTransfer(PostCustomerData request, ServerCallContext context)
        {
            var customer = new GetCustomers();

            if (request.CustId == 1)
            {
                customer.Name = "Helia";
                customer.Age = 21;
                customer.Gender = "She";
                customer.Ispremium = false;
                customer.Id = request.CustId;
            }
            else
            {
                customer.Name = "Alireza";
                customer.Age = 22;
                customer.Gender = "He";
                customer.Ispremium = true;
                customer.Id = request.CustId;
            }
            return Task.FromResult(customer);
        }
        public override async Task CustomerStreamingTransfer(GetCustomersByStreaming request, IServerStreamWriter<GetCustomers> responseStream, ServerCallContext context)
        {
            var customers = new List<GetCustomers>()
            {
                new GetCustomers()
                {
                    Id = 1,
                    Age = 21,
                    Gender = "Male",
                    Ispremium = false,
                    Name = "Ferdinand"
                },
                new GetCustomers()
                {
                    Id = 2,
                    Age = 13,
                    Gender = "Male",
                    Ispremium = true,
                    Name = "Mike"
                },
                new GetCustomers()
                {
                    Id = 3,
                    Age = 19,
                    Gender = "Female",
                    Ispremium = false,
                    Name = "Jane"
                },
                 new GetCustomers()
                {
                    Id =4,
                    Age = 26,
                    Gender = "Male",
                    Ispremium = true,
                    Name = "Bron"
                }
            };
            foreach (var customer in customers)
            {
                Task.Delay(2000).Wait();
               await responseStream.WriteAsync(customer);
            }
        }
    }
}
