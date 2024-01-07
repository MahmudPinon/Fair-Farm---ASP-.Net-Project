using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class BuySellRequestBetweenFarmerAndTrader
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string CropsName { get; set; }
        [Required]
        public decimal CropsQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Region { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }


        [ForeignKey("User")]
        public int Userid { get; set; }
        public virtual User User { get; set; }


        [ForeignKey("RequestTable")]
        public int RequestId { get; set; }
        public virtual RequestTable RequestTable { get; set; }
    }
}
