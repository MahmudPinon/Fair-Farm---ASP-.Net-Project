using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class PlantingCalendar
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string SeasonName { get; set; }
        [Required]
        public string SeasonalYear { get; set; }
        [Required]
        public string CropsName { get; set; }
        [Required]
        public string ExpectedProduction { get; set; }
        [Required]
        public string LandSize { get; set; }
        [Required]
        public string Region { get; set; }

        [ForeignKey("FarmerUser")]
        public int FarmerUserId { get; set; }
        public virtual User FarmerUser { get; set; }

    }

}
