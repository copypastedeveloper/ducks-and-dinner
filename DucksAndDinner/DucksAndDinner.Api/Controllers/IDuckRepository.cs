using System.Collections.Generic;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public interface IDuckRepository
    {
        void Save(Duck newDuck);
        Duck Get(int id);
        IEnumerable<Duck> GetAll();
    }
}