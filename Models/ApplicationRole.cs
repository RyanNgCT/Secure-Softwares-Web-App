using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ssd_assignment_team1_draft1.Models
{
    public class ApplicationRole : IdentityRole
    {
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "The description contains inputs which are not valid.")]
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
    }

}
