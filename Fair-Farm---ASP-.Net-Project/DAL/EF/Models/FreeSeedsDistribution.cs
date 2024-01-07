using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class FreeSeedsDistribution
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string SeedName { get; set; }
        [Required]
        public string PerheadQuantity { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public string Region { get; set; }
        public string FinishedStatus { get; set; }

        public string DistributortoFarmerStatus { get; set; }



        [ForeignKey("AdminUser")]
        public int AdminId { get; set; }

        [ForeignKey("FarmerUser")]
        public int FarmerId { get; set; }

        public virtual User AdminUser { get; set; }

        public virtual User FarmerUser { get; set; }
    }
}
