using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.TraderDTOs
{
    public class TraderEquipmentRentDTO : UserDTO
    {
        public List<EquipmentRentDTO> EquipmentRents { get; set; }

        public TraderEquipmentRentDTO()
        {
            EquipmentRents = new List<EquipmentRentDTO>();
        }
    }

}
