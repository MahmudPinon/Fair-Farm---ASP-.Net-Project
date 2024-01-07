using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TransportationFleetRent
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string TransportationName { get; set; }
        [Required]
        [StringLength(12)]
        public string TransportationNumber { get; set; }
        [Required]
        public int HowmanydaysforRent { get; set; }
        [Required]
        public decimal TotalRent { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Region { get; set; }
        public string Approvestatus { get; set; }

        [ForeignKey("TrpFR")]
        public int TransportationFleetRegisterId { get; set; }
        public virtual TransportationFleetRegister TrpFR { get; set; }

        [ForeignKey("RenterUser")]
        public int Renterid { get; set; }
        public virtual User RenterUser { get; set; }


    }
}
