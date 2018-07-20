using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Planner
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public IndexModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        public IList<Models.Planner> Planner { get;set; }

        public async Task OnGetAsync()
        {
            Planner = await _context.Planners.Include("Speakers").ToListAsync();
        }
    }
}
