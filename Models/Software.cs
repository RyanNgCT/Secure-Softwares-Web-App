using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ssd_assignment_team1_draft1.Models
{
    public class Software
    {
        public int ID { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Please enter valid name.")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Serial Number")]
        [Required]
        public int SerialNumber { get; set; }
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Please enter valid hash.")]
        [Required]
        public string Hash { get; set; }
        [Display(Name = "Warranty Period (in Months)")]
        [Required]
        public int WarrantyPeriod { get; set; }
        public double Ratings { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
