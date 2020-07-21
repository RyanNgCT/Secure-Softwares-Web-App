using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ssd_assignment_team1_draft1.Models
{
    public class AuditRecord
    {
        [Key]
        public int Audit_ID { get; set; }

        [Display(Name = "Audit Action")]
        [StringLength(50,MinimumLength = 5)]
        //[RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid string.")]
        [Required]
        public string AuditActionType { get; set; }

        [Display(Name = "Performed By")]
        [StringLength(30, MinimumLength = 5)]
        //[RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please enter valid email.")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Date/Time Stamp")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateTimeStamp { get; set; }

        [Display(Name = "Software Record ID ")]
        [Range(0,100)]
        [Required]
        public int KeySoftwareFieldID { get; set; }
    }
}
