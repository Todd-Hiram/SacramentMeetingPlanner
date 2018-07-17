using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
       
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Topic { get; set; }
        [Required]
        public int Order { get; set; }

        public int PlannerId { get; set; }
        public Planner Planner { get; set; }
    }
}
