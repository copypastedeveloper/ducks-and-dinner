using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public class ReservationController : Controller
    {
        readonly IReservationRepository _reservationRepository;
        readonly IDuckRepository _duckRepository;

        public ReservationController(IReservationRepository reservationRepository, IDuckRepository duckRepository)
        {
            _reservationRepository = reservationRepository;
            _duckRepository = duckRepository;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            var ducks = _duckRepository.GetAll();
            var viewModel = new CreateReservationViewModel
            {
                Ducks = ducks.Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()}).ToList(),
                NumberOfPeople = 5,
                DuckId = 7,
                Date = new DateTime(2017,5,19)
            };

            return View("Index",viewModel);
        }

        [HttpPost]
        public ActionResult CreateReservation(CreateReservationViewModel reservation)
        {
            var res = new Reservation
            {
                Date = reservation.Date,
                NumberOfPeople = reservation.NumberOfPeople
            };

            res.DuckIAmEating = _duckRepository.Get(reservation.DuckId);

            _reservationRepository.Save(res);

            return RedirectToAction("Index");
        }
    }
}