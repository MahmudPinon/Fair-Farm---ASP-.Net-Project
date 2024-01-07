using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    // its need because of coldstorage request admin when acccept it he will insert coldstorage id
    //basicaly if other informaton need in future so that we can accept it by model
    public class ColdStorageUpdateModel 
    {
        public int ColdStorageId { get; set; }

    }
}
