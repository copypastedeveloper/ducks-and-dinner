using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DucksAndDinner.Api.Models
{
    public class Customer
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public int NumberOfDucksPerTypicalMeal { get; set; }
    }
}