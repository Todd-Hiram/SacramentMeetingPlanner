using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Speaker
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public DetailsModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speaker = await _context.Speaker
                .Include(s => s.Planner).FirstOrDefaultAsync(m => m.SpeakerId == id);

            if (Speaker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
