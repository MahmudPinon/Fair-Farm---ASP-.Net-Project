using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EquipmentRentDTO
    {
  
        public int Id { get; set; }

        public string EquipmentName { get; set; }
 
        public decimal PerdayRent { get; set; }
    
        public string Region { get; set; }
        
        public string Location { get; set; }

        public string RentStatus { get; set; }

        
        public int OwnerUserId { get; set; }

       
        public int RenterUserId { get; set; }


    }
}
