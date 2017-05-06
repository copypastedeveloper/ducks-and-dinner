using System.Data.Entity;
using DucksAndDinner.Api.Models;

namespace DucksAndDinner.Api.DAL
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DucksAndDinner") {}

        public DbSet<Duck> Ducks { get; set; }
    }
}