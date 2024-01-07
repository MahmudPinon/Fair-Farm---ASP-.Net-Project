using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TransportationFleetRegister
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string TransportationName { get; set; }
        [Required]
        public string TransportationNumber { get; set; }
        [Required]
        public decimal PerdayRent { get; set; }
        [Required]
        public string Capacity { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public string RentedStatus { get; set; }

        [ForeignKey("User")]
        public int Userid { get; set; }
        public virtual User User { get; set; }



        public virtual ICollection<TransportationFleetRent> TransportationFleetRents { get; set; }
        public TransportationFleetRegister()
        {
            TransportationFleetRents = new List<TransportationFleetRent>();

        }
    }
}
