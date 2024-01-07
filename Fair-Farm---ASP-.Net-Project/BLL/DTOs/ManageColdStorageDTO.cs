using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ManageColdStorageDTO
    {
    
        public int Id { get; set; }
     
        public string StorageName { get; set; }
       
        public string City { get; set; }
  
        public string Region { get; set; }
      
        public decimal PerdayPerkgPrice { get; set; }
      
        public decimal Capacity { get; set; }

     
        public int AdminId { get; set; }
    
    }
}
