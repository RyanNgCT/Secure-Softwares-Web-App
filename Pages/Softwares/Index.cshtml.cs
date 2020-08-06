using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace ssd_assignment_team1_draft1
{
    [Authorize(Roles = "Head Admin, Software Admin, Review Admin, User, Auditor")]
    public class IndexModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public IndexModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        public IList<Software> Software { get;set; }
        public IList<Review> Reviews { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchSoftware { get; set; }

        public async Task OnGetAsync()
        {
            var softwares = from s in _context.Software
                            select s;
            if (!string.IsNullOrEmpty(SearchSoftware))
            {
                softwares = softwares.Where(s => s.Name.Contains(SearchSoftware));
            }

            Software = await softwares.ToListAsync();
            //Software = await _context.Software.ToListAsync();
            Reviews = await _context.Review.ToListAsync();
        }
    }
}
