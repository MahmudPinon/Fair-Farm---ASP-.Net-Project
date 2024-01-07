using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class AdminStoredItem
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
        public string Region { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("RequestTable")]
        public int StorageRequestId { get; set; }
        public virtual RequestTable RequestTable { get; set; }

        
        public virtual RegularPriceUpdate RegularPriceUpdate { get; set; }



    }



}
