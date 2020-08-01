using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ssd_assignment_team1_draft1.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string SoftwareName { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ratings { get; set; }
        public string Content { get; set; }
    }
}
