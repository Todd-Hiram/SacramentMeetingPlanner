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

            // Look up the existing Planner if it exists
            var existingPlanner = _context.Planners.Include("Speakers").FirstOrDefault(x => x.PlannerId == Planner.PlannerId);

            if(existingPlanner != null)
            {
                // Update the database version with the received form posted version
                _context.Entry(existingPlanner).CurrentValues.SetValues(Planner);

                // Now check the Speakers received and make sure we update the database versions of them
                if (Planner != null && Planner.Speakers != null)
                {
                    foreach (var speaker in existingPlanner.Speakers.ToList())
                    {
                        var incomingSpeaker = Planner.Speakers.SingleOrDefault(i => i.SpeakerId == speaker.SpeakerId);
                        if (incomingSpeaker != null)
                        {
                            _context.Entry(speaker).CurrentValues.SetValues(incomingSpeaker);
                        }
                        else
                        {
                            // Remove any speakers that have been removed from the posted form version
                            _context.Speaker.Remove(speaker);
                        }
                    }  

                    // Add new speakers
                    foreach(var speaker in Planner.Speakers)
                    {
                        if(speaker.SpeakerId == 0)
                        {
                            existingPlanner.Speakers.Add(speaker);
                        }
                    }
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
