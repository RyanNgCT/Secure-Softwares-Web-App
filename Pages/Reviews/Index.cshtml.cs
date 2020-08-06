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
    [Authorize(Roles = "Review Admin, User, Head Admin, Software Admin, Auditor")]
    public class IndexModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public IndexModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; }
        [BindProperty(SupportsGet = true)]
        public string searchReviews { get; set; }

        public async Task OnGetAsync()
        {
            var reviews = from r in _context.Review
                          select r;
            if (!string.IsNullOrEmpty(searchReviews))
            {
                reviews = reviews.Where(r => r.SoftwareName.Contains(searchReviews));
            }

            Review = await reviews.ToListAsync();
        }
    }
}
