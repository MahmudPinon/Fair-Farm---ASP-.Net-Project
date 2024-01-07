using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StoredItemInColdStorageDTO
    {
    
        public int Id { get; set; }
      
        public string CropsName { get; set; }
      
        public decimal CropsQuantity { get; set; }
    
        public int Duration { get; set; }
       
        public string Region { get; set; }

      
        public decimal TotalRent { get; set; }

      
        public int RequestId { get; set; }
     
        public int ColdStorageId { get; set; }
      
    }
}
