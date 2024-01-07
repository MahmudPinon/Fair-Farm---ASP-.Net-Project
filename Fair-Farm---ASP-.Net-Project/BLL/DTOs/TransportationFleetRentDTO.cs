using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransportationFleetRentDTO
    {
    
        public int Id { get; set; }
      
        public string TransportationName { get; set; }
 
        public string TransportationNumber { get; set; }
     
        public int HowmanydaysforRent { get; set; }
      
        public decimal TotalRent { get; set; }
 
        public string Location { get; set; }
      
        public string Region { get; set; }
        public string Approvestatus { get; set; }

    
        public int TransportationFleetRegisterId { get; set; }
     

 
        public int Renterid { get; set; }
 


    }
}
