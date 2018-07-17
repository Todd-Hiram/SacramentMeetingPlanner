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
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public IndexModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        public IList<Speaker> Speaker { get;set; }

        public async Task OnGetAsync()
        {
            Speaker = await _context.Speaker
                .Include(s => s.Planner).ToListAsync();
        }
    }
}
