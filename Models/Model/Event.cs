using System;
using System.Collections.Generic;

namespace CliqueUpModel.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime DisabledOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool IsActive { get; set; }

        public virtual List<EventMessage> Messages { get; set; } 
        public virtual List<Category> Categories { get; set; }
    }
}
