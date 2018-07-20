using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Planner
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.PlannerModel _context;

        public EditModel(SacramentMeetingPlanner.Models.PlannerModel context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Planner Planner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Planner = await _context.Planners.Include("Speakers").FirstOrDefaultAsync(m => m.PlannerId == id);

            if (Planner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<Models.Speaker> incomingSpeakerList = new List<Models.Speaker>(Planner.Speakers);
            List<int> incomingSpeakerIdList = incomingSpeakerList.Select(s => s.SpeakerId).ToList();

            // Look up the existing Planner if it exists
            _context.Planners.Attach(Planner);
            _context.Entry(Planner).State = EntityState.Modified;
            foreach (var sp in incomingSpeakerList)
            {
                if (sp.SpeakerId == 0)
                {
                    _context.Speaker.Add(sp);
                }
                else
                {
                    _context.Entry(sp).State = EntityState.Modified;
                }
            }

            var existingSpeakers = _context.Speaker.Where(x => x.PlannerId == Planner.PlannerId).ToList();

            foreach (var existingSpeaker in existingSpeakers)
            {
                if (!incomingSpeakerIdList.Contains(existingSpeaker.SpeakerId))
                {
                    _context.Speaker.Remove(existingSpeaker);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlannerExists(Planner.PlannerId))
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

        private bool PlannerExists(int id)
        {
            return _context.Planners.Any(e => e.PlannerId == id);
        }
    }
}
