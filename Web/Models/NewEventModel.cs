using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CliqueUp.Models
{
    public class EventModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public List<string> Categories { get; set; }

        [Required]
        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }
        
        [Required]
        public double Longititude { get; set; }
        
        [Required]
        public double Latitude { get; set; }

    }
}