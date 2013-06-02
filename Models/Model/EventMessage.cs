using System;

namespace CliqueUpModel.Model
{
    public class EventMessage
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }

        public Event Event { get; set; }
    }
}
