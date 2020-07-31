using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssd_assignment_team1_draft1.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string SoftwareName { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Ratings { get; set; }
        public string Content { get; set; }
    }
}
