using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ssd_assignment_team1_draft1.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ssd_assignment_team1_draft1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;
        private readonly IConfiguration configuration;
        //private readonly IHttpClientFactory _clientFactory;
        
        public LoginModel(SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            IConfiguration configuration,
            //IHttpClientFactory clientFactory,
            ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            this.configuration = configuration;
            //_clientFactory = clientFactory;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Please enter valid email.")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //string recaptchaResponse = this.Request.Form["g-recaptcha-response"];
            //var client = _clientFactory.CreateClient();
            //try
            //{
            //    var parameters = new Dictionary<string, string>
            //{
            //    {"secret", this.configuration["reCAPTCHA:SecretKey"]},
            //    {"response", recaptchaResponse},
            //    {"remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()}
            //};

            //    HttpResponseMessage response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(parameters));
            //    response.EnsureSuccessStatusCode();

            //    string apiResponse = await response.Content.ReadAsStringAsync();
            //    dynamic apiJson = JObject.Parse(apiResponse);
            //    if (apiJson.success != true)
            //    {
            //        this.ModelState.AddModelError(string.Empty, "There was an unexpected problem processing this request. Please try again.");
            //    }
            //}
            //catch (HttpRequestException ex)
            //{
            //    // Something went wrong with the API. Let the request through.
            //    _logger.LogError(ex, "Unexpected error calling reCAPTCHA api.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    // Login successful attempt - create an audit record
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Successful Login";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeySoftwareFieldID = 0;
                    // 0 – dummy record (no software is affected during login)

                    auditrecord.Username = Input.Email;
                    // save the email used for the failed login
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();
                    return LocalRedirect(returnUrl);
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    // lockout- create an audit record
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Failed Login (Account Lockout)";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeySoftwareFieldID = 0;
                    // 0 – dummy record (no software is affected during login)
                    auditrecord.Username = Input.Email;
                    // save the email used for the failed login
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    // Login failed attempt - create an audit record
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Failed Login";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeySoftwareFieldID = 0;
                    // 0 – dummy record (no software is affected during login)

                    auditrecord.Username = Input.Email;
                    // save the email used for the failed login
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
