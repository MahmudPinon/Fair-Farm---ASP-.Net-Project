using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminStoredItemDTO
    {
        
        public int Id { get; set; }
        public string CropsName { get; set; }

        public decimal CropsQuantity { get; set; }
        public decimal Price { get; set; }
        
        public string Region { get; set; }

        public string Description { get; set; }

        public int StorageRequestId { get; set; }

    }



}
