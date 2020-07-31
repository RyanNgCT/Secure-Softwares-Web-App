using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;

namespace ssd_assignment_team1_draft1.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public CreateModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Review.Username = User.Identity.Name;
            Review.DateCreated = DateTime.Now;

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
