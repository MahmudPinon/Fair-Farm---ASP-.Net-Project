using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class EquipmentRent
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string EquipmentName { get; set; }
        [Required]
        public decimal PerdayRent { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Location { get; set; }

        public string RentStatus { get; set; }

        [ForeignKey("OwnerUser")]
        public int OwnerUserId { get; set; }

        [ForeignKey("RenterUser")]
        public int RenterUserId { get; set; }

        public virtual User OwnerUser { get; set; }

        public virtual User RenterUser { get; set; }
    }
}
