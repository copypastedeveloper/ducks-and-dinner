using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public interface ICustomerRepository
    {
        void Save(Customer newCustomer);
    }
}