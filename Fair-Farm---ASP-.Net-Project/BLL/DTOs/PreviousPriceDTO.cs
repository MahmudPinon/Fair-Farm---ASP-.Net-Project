using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PreviousPriceDTO
    {
 
        public int Id { get; set; }
  
        public string CropName { get; set; }
      
        public decimal CropQuantity { get; set; }
 
        public decimal Price { get; set; }
    
        public string Description { get; set; }


    
        public int RegularpriceUpdateId { get; set; }




    }

}
