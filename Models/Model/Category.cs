using System;
using System.Collections.Generic;

namespace CliqueUpModel.Model
{
    public class EventCategory
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
