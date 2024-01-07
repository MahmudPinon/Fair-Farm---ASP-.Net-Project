using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlantingCalendarDTO
    {
    
        public int Id { get; set; }
   
        public string SeasonName { get; set; }
      
        public string SeasonalYear { get; set; }
      
        public string CropsName { get; set; }
        
        public string ExpectedProduction { get; set; }
       
        public string LandSize { get; set; }
    
        public string Region { get; set; }

 
        public int FarmerUserId { get; set; }

    }

}
