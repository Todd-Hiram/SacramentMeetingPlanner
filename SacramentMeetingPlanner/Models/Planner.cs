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
        [Required]
        public DateTime MeetingDate { get; set; }

        [Display(Name = "Conducting")]
        [Required]
        public string BishopricMemeber { get; set; }

        [Display(Name = "Opening Hymn")]
        [Required]
        public string OpeningHymn { get; set; }

        [Display(Name = "Opening Prayer")]
        [Required]
        public string OpeningPrayer { get; set; }

        [Display(Name = "Sacrament Hymn")]
        [Required]
        public string SacramentHymn { get; set; }

        public IEnumerable<Speakers> Speakers { get; set; }

        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }

        [Display(Name = "Closing Hymn")]
        [Required]
        public string ClosingHymn { get; set; }

        [Display(Name = "Closing Prayer")]
        [Required]
        public string ClosingPrayer { get; set; }

       
    }
}
