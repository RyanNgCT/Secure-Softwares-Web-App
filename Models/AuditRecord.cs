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
        [StringLength(150,MinimumLength = 5)]
        [Required]
        public string AuditActionType { get; set; }

        [Display(Name = "Performed By")]
        [StringLength(50, MinimumLength = 5)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Please enter valid email.")]
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
