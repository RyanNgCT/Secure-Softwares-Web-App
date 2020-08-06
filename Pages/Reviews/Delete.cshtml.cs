using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;

namespace ssd_assignment_team1_draft1.Pages.Reviews
{
    [Authorize(Roles = "Review Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public DeleteModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review.FirstOrDefaultAsync(m => m.ID == id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review.FindAsync(id);

            if (Review != null)
            {
                _context.Review.Remove(Review);

                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Deleted a Review";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeySoftwareFieldID = 0;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;

                _context.AuditRecords.Add(auditrecord);


                await _context.SaveChangesAsync();

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
