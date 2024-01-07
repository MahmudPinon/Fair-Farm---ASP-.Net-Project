using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class FairFarmContext:DbContext
    {
        public DbSet<TransportationFleetRent> TransportationFleetRents { get; set; }
        public DbSet<TransportationFleetRegister> TransportationFleetRegisters { get; set; }
        public DbSet<EquipmentRent> EquipmentRents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<PlantingCalendar> PlantingCalendars { get; set; }
        public DbSet<TrainingTable> TrainingTables { get; set; }
        public DbSet<RequestTable> RequestTables { get; set; }
        public DbSet<RequestTableItem> RequestTableItems { get; set; }
        public DbSet<AdminStoredItem> AdminStoredItems { get; set; }


        public DbSet<BuySellRequestBetweenFarmerAndTrader> BuySellRequestBetweenFarmerAndTraders { get; set; }
        public DbSet<RegularPriceUpdate> RegularPriceUpdates { get; set; }
        public DbSet<PreviousPrice> PreviousPrices { get; set; }
        public DbSet<ManageColdStorage> ManageColdStorages { get; set; }


        public DbSet<ColdStorageItemList> ColdStorageItemLists { get; set; }
        public DbSet<StoredItemInColdStorage> StoredItemInColdStorages { get; set; }
        public DbSet<FreeSeedsDistribution> FreeSeedsDistributions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminStoredItem>()
                .HasOptional(u => u.RegularPriceUpdate)
                .WithRequired(up => up.AdminStoredItem)
                .WillCascadeOnDelete(false); // Optional: if you want cascading delete


            modelBuilder.Entity<RegularPriceUpdate>()
           .HasOptional(u => u.PreviousPrice)
           .WithRequired(a => a.RegularPriceUpdate)
           .WillCascadeOnDelete(false); // Optional: if you want cascading delete
        }

    }

}
