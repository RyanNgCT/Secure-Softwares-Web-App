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

namespace ssd_assignment_team1_draft1
{
    [Authorize(Roles = "Software Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public DeleteModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Software = await _context.Software.FirstOrDefaultAsync(m => m.ID == id);

            if (Software == null)
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

            Software = await _context.Software.FindAsync(id);

            if (Software != null)
            {
                _context.Software.Remove(Software);
                //await _context.SaveChangesAsync();
                if (await _context.SaveChangesAsync() > 0)
                {
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Delete Software Record (Software: " + Software.Name +")";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeySoftwareFieldID = Software.ID;
                    var userID = User.Identity.Name.ToString();
                    auditrecord.Username = userID;
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();

                }
            }

                return RedirectToPage("./Index");
            }
        }
}
