using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ManageColdStorage
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string StorageName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public decimal PerdayPerkgPrice { get; set; }
        [Required]
        public decimal Capacity { get; set; }

        [ForeignKey("AdminUser")]
        public int AdminId { get; set; }
        public virtual User AdminUser { get; set; }
    }
}
