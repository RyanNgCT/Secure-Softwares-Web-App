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

namespace ssd_assignment_team1_draft1.Pages.Audit
{
    [Authorize(Roles = "Admin, Auditor")]
    public class DeleteModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public DeleteModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public AuditRecord AuditRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuditRecord = await _context.AuditRecords.FirstOrDefaultAsync(m => m.Audit_ID == id);

            if (AuditRecord == null)
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

            AuditRecord = await _context.AuditRecords.FindAsync(id);

            if (AuditRecord != null)
            {
                _context.AuditRecords.Remove(AuditRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
