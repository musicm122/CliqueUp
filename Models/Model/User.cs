using System;
using System.Collections.Generic;

namespace CliqueUpModel.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual List<Event> Events { get; set; } 
    }
}
