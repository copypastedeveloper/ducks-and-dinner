using System;
using System.ComponentModel.DataAnnotations;

namespace DucksAndDinner.Api.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        
        public int NumberOfPeople { get; set; }

        public virtual Duck DuckIAmEating { get; set; }
    }
}