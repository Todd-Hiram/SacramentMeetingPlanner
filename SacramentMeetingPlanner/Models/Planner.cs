using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Planner
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MeetingDate { get; set; }
        [Display(Name = "Conducting")]
        public string BishopricMemeber { get; set; }
        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayer { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }

        public IEnumerable<Speakers> Speakers { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }
        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayer { get; set; }

       
    }
}
