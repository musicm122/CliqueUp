using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueUpModel.Model
{
    public class EventUser
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }

        public CategoryEvent Event { get; set; }
        public User User { get; set; }
    }
}
