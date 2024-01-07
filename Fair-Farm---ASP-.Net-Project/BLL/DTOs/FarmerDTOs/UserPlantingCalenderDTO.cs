using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.FarmerDTOs
{
    public class UserPlantingCalenderDTO : UserDTO
    {
        public List<PlantingCalendarDTO> PlantingCalendars { get; set; }

        public UserPlantingCalenderDTO()
        {
            PlantingCalendars = new List<PlantingCalendarDTO>();
        }
    }
}
