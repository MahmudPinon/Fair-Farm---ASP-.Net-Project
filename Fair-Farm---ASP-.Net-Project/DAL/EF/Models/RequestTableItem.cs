using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class RequestTableItem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string CropsName { get; set; }

        [Required]
        public string CropsQuantity { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public virtual RequestTable Request { get; set; }
    }
}
