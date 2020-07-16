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
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SerialNumber { get; set; }
        public string Hash { get; set; }
        public int WarrantyPeriod { get; set; }
    }
}
