using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class Speakers
    {
        public int SpeakerID { get; set; }
       public int PlannerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Topic { get; set; }


       public Planner Planner { get; set; }
    }
}
