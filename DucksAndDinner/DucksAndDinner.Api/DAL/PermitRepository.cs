using System.Collections.Generic;
using System.Net;
using DucksAndDinner.Api.Controllers;
using RestSharp;

namespace DucksAndDinner.Api.DAL
{
    public class PermitRepository : IPermitRepository
    {
        public IEnumerable<Permit> Get()
        {
            var client = new RestClient("http://data.nashville.gov/");
            var request = new RestRequest($"resource/8fb8-y573.json");

            request.AddHeader("X-App-Token", "");
            request.AddQueryParameter("myParam", "jkasdfjlk;adsfjk;lasfd;kjl");

            var restResponse = client.Get<List<ApiPermit>>(request);

            if (restResponse.StatusCode != HttpStatusCode.OK) yield return null;

            foreach (var permit in restResponse.Data)
            {
                var p = new Permit
                {
                    PermitNumber = permit.permit,
                    City = permit.mapped_location_city,
                    State = permit.mapped_location_state,
                    ZipCode = permit.mapped_location_zip
                };

                yield return p;
            }
        }
    }

    public interface IPermitRepository
    {
        IEnumerable<Permit> Get();
    }
}