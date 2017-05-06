using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.Controllers
{
    public interface IDuckRepository
    {
        void Save(Duck newDuck);
    }
}