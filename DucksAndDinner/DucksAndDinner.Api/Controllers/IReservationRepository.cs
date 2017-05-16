using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public interface IReservationRepository
    {
        void Save(Reservation reservation);
    }
}
