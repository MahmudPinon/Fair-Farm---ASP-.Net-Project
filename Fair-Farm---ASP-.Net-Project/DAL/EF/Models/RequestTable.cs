using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class RequestTable
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string RequestType { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Region { get; set; }

        public string Status { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }




        public virtual ICollection<RequestTableItem> RequestTableItems { get; set; }
        public virtual ICollection<AdminStoredItem> AdminStoredItems { get; set; }
        public virtual ICollection<ColdStorageItemList> ColdStorageItemLists { get; set; }
        public virtual ICollection<StoredItemInColdStorage> StoredItemInColdStorages { get; set; }
        public virtual ICollection<BuySellRequestBetweenFarmerAndTrader> BuySellRequestBetweenFarmerAndTraders { get; set; }

        public RequestTable()
        {
            RequestTableItems = new List<RequestTableItem>();
            AdminStoredItems = new List<AdminStoredItem>();
            ColdStorageItemLists = new List<ColdStorageItemList>();
            StoredItemInColdStorages = new List<StoredItemInColdStorage>();
            BuySellRequestBetweenFarmerAndTraders = new List<BuySellRequestBetweenFarmerAndTrader>();
        }
    }
}
