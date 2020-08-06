﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ssd_assignment_team1_draft1.Models;

namespace ssd_assignment_team1_draft1.Pages.Softwares.Roles
{
    [Authorize(Roles = "Head Admin")]
    public class EditModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public EditModel(RoleManager<ApplicationRole> roleManager,
                         ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationRole = await _roleManager.FindByIdAsync(id);

            if (ApplicationRole == null)
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

            ApplicationRole appRole = await _roleManager.FindByIdAsync(ApplicationRole.Id);

            appRole.Id = ApplicationRole.Id;
            appRole.Name = ApplicationRole.Name;
            appRole.Description = ApplicationRole.Description;

            IdentityResult roleRuslt = await _roleManager.UpdateAsync(appRole);

            // Create an auditrecord object
            var auditrecord = new AuditRecord();
            auditrecord.AuditActionType = "Edited a Role (Role: " + ApplicationRole.ToString() + ")";
            auditrecord.DateTimeStamp = DateTime.Now;
            auditrecord.KeySoftwareFieldID = 0;
            // Get current logged-in user
            var userID = User.Identity.Name.ToString();
            auditrecord.Username = userID;

            _context.AuditRecords.Add(auditrecord);
            await _context.SaveChangesAsync();


            if (roleRuslt.Succeeded)
            {
                return RedirectToPage("./Index");

            }

            return RedirectToPage("./Index");
        }

    }

}