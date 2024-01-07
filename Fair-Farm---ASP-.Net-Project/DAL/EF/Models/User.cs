using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UsersUserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserPhoneNumber { get; set; }
        [Required]
        public DateTime UserDateOfBirth { get; set; }
        [Required]
        public string UserCity { get; set; }
        [Required]
        public string UserRegion { get; set; }
        [Required]
        public string UserEmail { get; set; }

        public bool UserRedList { get; set; }

        public bool UserLogInValid { get; set; }
        [Required]
        public string UserType { get; set; }


        public virtual ICollection<RequestTable> RequestTables { get; set; }
        public virtual ICollection<TransportationFleetRegister> TransportationFleetRegisters { get; set; }
        public virtual ICollection<EquipmentRent> EquipmentRents { get; set; }
        public virtual ICollection<ManageColdStorage> ManageColdStorages { get; set; }
        public virtual ICollection<FreeSeedsDistribution> FreeSeedsDistributions { get; set; }
        public virtual ICollection<TrainingTable> TrainingTables { get; set; }
        public virtual ICollection<PlantingCalendar> PlantingCalendars { get; set; }


        public User()
        {
            RequestTables = new List<RequestTable>();
            TransportationFleetRegisters = new List<TransportationFleetRegister>();
            EquipmentRents = new List<EquipmentRent>();
            ManageColdStorages = new List<ManageColdStorage>();
            FreeSeedsDistributions = new List<FreeSeedsDistribution>();
            TrainingTables = new List<TrainingTable>();
            PlantingCalendars = new List<PlantingCalendar>();
        }


    }
}
