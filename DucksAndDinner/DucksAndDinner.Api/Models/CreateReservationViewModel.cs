using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DucksAndDinner.Api.Models
{
    public class CreateReservationViewModel
    {
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public int DuckId { get; set; }

        public List<SelectListItem> Ducks { get; set; }
    }
}