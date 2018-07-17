using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Speaker
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public CreateModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlannerId"] = new SelectList(_context.Planners, "PlannerId", "BishopricMemeber");
            return Page();
        }

        [BindProperty]
        public Models.Speaker Speaker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Speaker.Add(Speaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}