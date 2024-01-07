using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class RegularPriceUpdate
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string CropName { get; set; }
        [Required]
        public decimal CropQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }


        
      /*  [ForeignKey("AdminStoredItem")]*/
        public int AdminStoredItemId { get; set; }
        /*[ForeignKey("AdminStoredItemId")]*/
        public virtual AdminStoredItem AdminStoredItem { get; set; }


        public virtual PreviousPrice PreviousPrice { get; set; }

    }

}
