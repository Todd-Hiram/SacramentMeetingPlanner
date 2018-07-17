using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Speaker
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Speaker Speaker { get; set; }

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
           ViewData["PlannerId"] = new SelectList(_context.Planners, "PlannerId", "BishopricMemeber");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(Speaker.SpeakerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.SpeakerId == id);
        }
    }
}
