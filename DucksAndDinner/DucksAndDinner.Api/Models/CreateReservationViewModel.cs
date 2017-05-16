using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DucksAndDinner.Api.Models
{
    public class CreateReservationViewModel
    {
        [DisplayName("Reservation Date")]
        public DateTime Date { get; set; }
        [DisplayName("Number of People Eating Duck")]
        public int NumberOfPeople { get; set; }
        [DisplayName("Which Duck To Eat")]
        public int DuckId { get; set; }

        public List<SelectListItem> Ducks { get; set; }
    }
}