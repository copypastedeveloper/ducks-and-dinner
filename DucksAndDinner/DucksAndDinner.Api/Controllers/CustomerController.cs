using System.Net;
using System.Net.Http;
using System.Web.Http;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public class CustomerController : ApiController
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpPost]
        [Route("api/customer")]
        public HttpResponseMessage RegisterCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.UserName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            }

            _customerRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }   
}
