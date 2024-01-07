using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TrainingTableDTO
    {
       
        public int Id { get; set; }
 
        public string TrainingName { get; set; }
      
        public string Duration { get; set; }
     
        public DateTime Date { get; set; }
 
        public string Region { get; set; }
      
        public string Location { get; set; }

        public string AvlaibleStatus { get; set; }

        public int AdminId { get; set; }
 
    }
}
