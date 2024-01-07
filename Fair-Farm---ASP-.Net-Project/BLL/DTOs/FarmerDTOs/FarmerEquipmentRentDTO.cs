using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.FarmerDTOs
{
    public class FarmerEquipmentRentDTO : UserDTO
    {
        public List<EquipmentRentDTO> EquipmentRents { get; set; }

        public FarmerEquipmentRentDTO()
        {
            EquipmentRents = new List<EquipmentRentDTO>();
        }
    }
}
