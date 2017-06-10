using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DucksAndDinner.Api.DAL;
using RestSharp;

namespace DucksAndDinner.Api.Controllers
{
    public class ChickenController : ApiController
    {
        readonly IPermitRepository _permitRepository;

        public ChickenController(IPermitRepository permitRepository)
        {
            _permitRepository = permitRepository;
        }

        public IEnumerable<Permit> GetPermits()
        {
            return _permitRepository.Get();
        }
    }

    public class ApiPermit
    {
        public string mapped_location_city { get; set; }
        public string mapped_location_state { get; set; }
        public string mapped_location_zip { get; set; }
        public string permit { get; set; }
    }

    public class Permit
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PermitNumber { get; set; }
    }
}