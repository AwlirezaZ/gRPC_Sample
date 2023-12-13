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
    }
}
