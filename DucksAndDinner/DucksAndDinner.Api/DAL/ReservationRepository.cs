using DucksAndDinner.Api.Controllers;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.DAL
{
    public class ReservationRepository : IReservationRepository
    {
        readonly AppContext _context;

        public ReservationRepository(AppContext context)
        {
            _context = context;
        }

        public void Save(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
    }
}