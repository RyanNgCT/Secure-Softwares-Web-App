using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ssd_assignment_team1_draft1.Models;

namespace ssd_assignment_team1_draft1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger,
            ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                // Logout - create an audit record
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Logout";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeySoftwareFieldID = 0;
                // 0 – dummy record (no software is affected during logout)

                auditrecord.Username = User.Identity.Name.ToString();
                // save the email used for the failed login
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();


                return LocalRedirect(returnUrl);

            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
