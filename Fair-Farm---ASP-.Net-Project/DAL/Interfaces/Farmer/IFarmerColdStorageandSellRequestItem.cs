using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Farmer
{
    public interface IFarmerColdStorageandSellRequestItem<CLASS, ID, RET>
    {
        List<CLASS> Create(List<CLASS> itemsToCreate);
        List<CLASS> Update(List<CLASS> itemsToUpdate);
        List<CLASS> Get(ID id);
        CLASS GetSingleItem(ID id1, ID id2);
        bool Delete(ID obj);
    }
}
