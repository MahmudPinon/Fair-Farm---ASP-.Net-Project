using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FreeSeedsDistributionDTO
    {

        public int Id { get; set; }

        public string SeedName { get; set; }

        public string PerheadQuantity { get; set; }

        public DateTime Date { get; set; }
   
        public string Location { get; set; }

    
        public string Region { get; set; }
        public string FinishedStatus { get; set; }

        public string DistributortoFarmerStatus { get; set; }



        public int AdminId { get; set; }

     
        public int FarmerId { get; set; }

    }
}
