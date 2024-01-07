using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TrainingTable
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string TrainingName { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Location { get; set; }

        public string AvlaibleStatus { get; set; }

        [ForeignKey("AdminUser")]
        public int AdminId { get; set; }
        public virtual User AdminUser { get; set; }
    }
}
