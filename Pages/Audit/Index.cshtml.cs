using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ssd_assignment_team1_draft1.Pages.Audit
{
    public class IndexModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public IndexModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        public IList<AuditRecord> AuditRecord { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AuditAction { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SearchSoftwareID { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> actionQuery = from a in _context.AuditRecords
                                             orderby a.AuditActionType
                                             select a.AuditActionType;

            var auditRecords = from a in _context.AuditRecords
                               select a;
            
            if (!string.IsNullOrEmpty(SearchName))
            {
                auditRecords = auditRecords.Where(s => s.Username.Contains(SearchName));
            }

            if (!string.IsNullOrEmpty(AuditAction))
            {
                auditRecords = auditRecords.Where(x => x.AuditActionType.Contains(AuditAction));
            }
            //if (!string.IsNullOrEmpty(SearchSoftwareID.ToString()))
            //{
            //    auditRecords = auditRecords.Where(s => s.KeySoftwareFieldID == SearchSoftwareID);
            //}

            AuditRecord = await auditRecords.ToListAsync();
        }
    }
}
