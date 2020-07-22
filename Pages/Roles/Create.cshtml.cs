using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ssd_assignment_team1_draft1.Models;
using Microsoft.AspNetCore.Authorization;

namespace ssd_assignment_team1_draft1.Pages.Softwares.Roles
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public CreateModel(RoleManager<ApplicationRole> roleManager, 
                           ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationRole.CreatedDate = DateTime.UtcNow;
            ApplicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            IdentityResult roleRuslt = await _roleManager.CreateAsync(ApplicationRole);

            // Create an auditrecord object
            var auditrecord = new AuditRecord();
            auditrecord.AuditActionType = "Added New Role (Role: " + ApplicationRole.ToString() + ")";
            auditrecord.DateTimeStamp = DateTime.Now;
            auditrecord.KeySoftwareFieldID = 0;
            // Get current logged-in user
            var userID = User.Identity.Name.ToString();
            auditrecord.Username = userID;

            _context.AuditRecords.Add(auditrecord);
            await _context.SaveChangesAsync();


            return RedirectToPage("Index");
        }
    }

}