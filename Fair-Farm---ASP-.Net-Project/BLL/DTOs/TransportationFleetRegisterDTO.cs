using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransportationFleetRegisterDTO
    {
     
        public int Id { get; set; }
   
        public string TransportationName { get; set; }
        
        public string TransportationNumber { get; set; }
    
        public decimal PerdayRent { get; set; }
      
        public string Capacity { get; set; }
     
        public string Location { get; set; }
       
        public string Region { get; set; }
      
        public string PhoneNumber { get; set; }

        public string RentedStatus { get; set; }

        
        public int Userid { get; set; }
      
    }
}
