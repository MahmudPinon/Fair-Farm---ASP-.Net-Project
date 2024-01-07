using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RequestTableItemDTO
    {
     
        public int Id { get; set; }
   
        public string CropsName { get; set; }

     
        public string CropsQuantity { get; set; }
       
        public string Price { get; set; }
      
        public string Region { get; set; }
        
        public string Description { get; set; }

      
        public int RequestId { get; set; }
       
    }
}
