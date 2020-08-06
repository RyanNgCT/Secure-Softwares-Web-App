using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace ssd_assignment_team1_draft1
{
    public class PaymentModel : PageModel
    {

        private readonly ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context _context;

        public PaymentModel(ssd_assignment_team1_draft1.Data.ssd_assignment_team1_draft1Context context)
        {
            _context = context;
        }
        public Software Software { get; set; }

        public int Id { get; set; }

        [BindProperty, EmailAddress, Required, Display(Name = "Your Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Credit Card Number"), Display(Name = "Credit Card Number")]
        public string CreditNumber { get; set; }
        [BindProperty, Required(ErrorMessage = "Please supply a Credit Card Name"), Display(Name = "Credit Card name")]
        public string CreditName { get; set; }

        [BindProperty, Required(ErrorMessage = "Please supply a Credit Card Exp Date"), Display(Name = "Credit Card Exp Date")]
        public string CreditEXP { get; set; }

        [BindProperty, Required(ErrorMessage = "Please supply a Credit Card CVV"), Display(Name = "Credit Card CVV")]
        public string CreditCVV { get; set; }

        [BindProperty, Display(Name = "Quantity")]
        public int OrderQuantity { get; set; } = 1;

        public async Task OnGetAsync(int Id) =>
        Software = await _context.Software.FindAsync(Id);

        public async Task<IActionResult> OnPostAsync()
        {
            Software = await _context.Software.FindAsync(Id);

            if (ModelState.IsValid)
            {
                int i = 0;
                List<string> keys = new List<string>();
                while (i < OrderQuantity)
                {
                    Random rnd = new Random();
                    keys.Add(rnd.Next(10000000, 99999999).ToString());
                    i++;
                }

                string keyList ="";
                foreach (string item in keys) {
                    keyList = item + ", " + keyList;
                }
                var body = $@"<p>Thank you, we have received your order!</p>                
                Your Product keys are {keyList}<br/>
                We will contact you if we have questions about your order.  Thanks!<br/>";
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = @"d:\mailpickup";
                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = "Buying Software - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("Softwaresss@gmail.com");
                    await smtp.SendMailAsync(message);
                }

                return RedirectToPage("OrderSuccess");

            }
            return Page();
        }

    }

}
