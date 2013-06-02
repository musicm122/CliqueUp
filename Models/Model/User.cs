using System;
using System.Collections.Generic;

namespace CliqueUpModel.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual List<Event> Events { get; set; } 
    }
}
