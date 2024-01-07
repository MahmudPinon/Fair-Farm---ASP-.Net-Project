namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingAllTablesAndRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminStoredItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CropsName = c.String(nullable: false, maxLength: 70),
                        CropsQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Region = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StorageRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTables", t => t.StorageRequestId, cascadeDelete: false)
                .Index(t => t.StorageRequestId);
            
            CreateTable(
                "dbo.RegularPriceUpdates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CropName = c.String(nullable: false, maxLength: 70),
                        CropQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        AdminStoredItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminStoredItems", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PreviousPrices",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CropName = c.String(nullable: false, maxLength: 70),
                        CropQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        RegularpriceUpdateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegularPriceUpdates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RequestTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestType = c.String(nullable: false, maxLength: 70),
                        Date = c.DateTime(nullable: false),
                        Region = c.String(nullable: false),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BuySellRequestBetweenFarmerAndTraders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CropsName = c.String(nullable: false, maxLength: 70),
                        CropsQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        RequestType = c.String(),
                        Status = c.String(),
                        Userid = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTables", t => t.RequestId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Userid, cascadeDelete: false)
                .Index(t => t.Userid)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UsersUserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserPhoneNumber = c.String(nullable: false),
                        UserDateOfBirth = c.DateTime(nullable: false),
                        UserCity = c.String(nullable: false),
                        UserRegion = c.String(nullable: false),
                        UserEmail = c.String(nullable: false),
                        UserRedList = c.Boolean(nullable: false),
                        UserLogInValid = c.Boolean(nullable: false),
                        UserType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.EquipmentRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentName = c.String(nullable: false, maxLength: 70),
                        PerdayRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Region = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        RentStatus = c.String(),
                        OwnerUserId = c.Int(nullable: false),
                        RenterUserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.RenterUserId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.OwnerUserId)
                .Index(t => t.RenterUserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.FreeSeedsDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeedName = c.String(nullable: false, maxLength: 70),
                        PerheadQuantity = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Region = c.String(nullable: false),
                        FinishedStatus = c.String(),
                        DistributortoFarmerStatus = c.String(),
                        AdminId = c.Int(nullable: false),
                        FarmerId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.FarmerId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.AdminId)
                .Index(t => t.FarmerId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.ManageColdStorages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        PerdayPerkgPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminId, cascadeDelete: false)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.PlantingCalendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(nullable: false, maxLength: 70),
                        SeasonalYear = c.String(nullable: false),
                        CropsName = c.String(nullable: false),
                        ExpectedProduction = c.String(nullable: false),
                        LandSize = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        FarmerUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FarmerUserId, cascadeDelete: false)
                .Index(t => t.FarmerUserId);
            
            CreateTable(
                "dbo.TrainingTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainingName = c.String(nullable: false, maxLength: 70),
                        Duration = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Region = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        AvlaibleStatus = c.String(),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminId, cascadeDelete: false)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.TransportationFleetRegisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransportationName = c.String(nullable: false, maxLength: 70),
                        TransportationNumber = c.String(nullable: false),
                        PerdayRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capacity = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        RentedStatus = c.String(),
                        Userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Userid, cascadeDelete: false)
                .Index(t => t.Userid);
            
            CreateTable(
                "dbo.TransportationFleetRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransportationName = c.String(nullable: false, maxLength: 70),
                        TransportationNumber = c.String(nullable: false, maxLength: 12),
                        HowmanydaysforRent = c.Int(nullable: false),
                        TotalRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Approvestatus = c.String(),
                        TransportationFleetRegisterId = c.Int(nullable: false),
                        Renterid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Renterid, cascadeDelete: false)
                .ForeignKey("dbo.TransportationFleetRegisters", t => t.TransportationFleetRegisterId, cascadeDelete: false)
                .Index(t => t.TransportationFleetRegisterId)
                .Index(t => t.Renterid);
            
            CreateTable(
                "dbo.ColdStorageItemLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CropsName = c.String(nullable: false, maxLength: 70),
                        CropsQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        Region = c.String(nullable: false),
                        TotalRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTables", t => t.RequestId, cascadeDelete: false)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.RequestTableItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CropsName = c.String(nullable: false, maxLength: 70),
                        CropsQuantity = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTables", t => t.RequestId, cascadeDelete: false)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.StoredItemInColdStorages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CropsName = c.String(nullable: false, maxLength: 70),
                        CropsQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        Region = c.String(nullable: false),
                        TotalRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestId = c.Int(nullable: false),
                        ColdStorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTables", t => t.RequestId, cascadeDelete: false)
                .ForeignKey("dbo.ManageColdStorages", t => t.ColdStorageId, cascadeDelete: false)
                .Index(t => t.RequestId)
                .Index(t => t.ColdStorageId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        UserName = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.AdminStoredItems", "StorageRequestId", "dbo.RequestTables");
            DropForeignKey("dbo.RequestTables", "UserId", "dbo.Users");
            DropForeignKey("dbo.StoredItemInColdStorages", "ColdStorageId", "dbo.ManageColdStorages");
            DropForeignKey("dbo.StoredItemInColdStorages", "RequestId", "dbo.RequestTables");
            DropForeignKey("dbo.RequestTableItems", "RequestId", "dbo.RequestTables");
            DropForeignKey("dbo.ColdStorageItemLists", "RequestId", "dbo.RequestTables");
            DropForeignKey("dbo.BuySellRequestBetweenFarmerAndTraders", "Userid", "dbo.Users");
            DropForeignKey("dbo.TransportationFleetRegisters", "Userid", "dbo.Users");
            DropForeignKey("dbo.TransportationFleetRents", "TransportationFleetRegisterId", "dbo.TransportationFleetRegisters");
            DropForeignKey("dbo.TransportationFleetRents", "Renterid", "dbo.Users");
            DropForeignKey("dbo.TrainingTables", "AdminId", "dbo.Users");
            DropForeignKey("dbo.PlantingCalendars", "FarmerUserId", "dbo.Users");
            DropForeignKey("dbo.ManageColdStorages", "AdminId", "dbo.Users");
            DropForeignKey("dbo.FreeSeedsDistributions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.FreeSeedsDistributions", "FarmerId", "dbo.Users");
            DropForeignKey("dbo.FreeSeedsDistributions", "AdminId", "dbo.Users");
            DropForeignKey("dbo.EquipmentRents", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.EquipmentRents", "RenterUserId", "dbo.Users");
            DropForeignKey("dbo.EquipmentRents", "OwnerUserId", "dbo.Users");
            DropForeignKey("dbo.BuySellRequestBetweenFarmerAndTraders", "RequestId", "dbo.RequestTables");
            DropForeignKey("dbo.RegularPriceUpdates", "Id", "dbo.AdminStoredItems");
            DropForeignKey("dbo.PreviousPrices", "Id", "dbo.RegularPriceUpdates");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.StoredItemInColdStorages", new[] { "ColdStorageId" });
            DropIndex("dbo.StoredItemInColdStorages", new[] { "RequestId" });
            DropIndex("dbo.RequestTableItems", new[] { "RequestId" });
            DropIndex("dbo.ColdStorageItemLists", new[] { "RequestId" });
            DropIndex("dbo.TransportationFleetRents", new[] { "Renterid" });
            DropIndex("dbo.TransportationFleetRents", new[] { "TransportationFleetRegisterId" });
            DropIndex("dbo.TransportationFleetRegisters", new[] { "Userid" });
            DropIndex("dbo.TrainingTables", new[] { "AdminId" });
            DropIndex("dbo.PlantingCalendars", new[] { "FarmerUserId" });
            DropIndex("dbo.ManageColdStorages", new[] { "AdminId" });
            DropIndex("dbo.FreeSeedsDistributions", new[] { "User_UserId" });
            DropIndex("dbo.FreeSeedsDistributions", new[] { "FarmerId" });
            DropIndex("dbo.FreeSeedsDistributions", new[] { "AdminId" });
            DropIndex("dbo.EquipmentRents", new[] { "User_UserId" });
            DropIndex("dbo.EquipmentRents", new[] { "RenterUserId" });
            DropIndex("dbo.EquipmentRents", new[] { "OwnerUserId" });
            DropIndex("dbo.BuySellRequestBetweenFarmerAndTraders", new[] { "RequestId" });
            DropIndex("dbo.BuySellRequestBetweenFarmerAndTraders", new[] { "Userid" });
            DropIndex("dbo.RequestTables", new[] { "UserId" });
            DropIndex("dbo.PreviousPrices", new[] { "Id" });
            DropIndex("dbo.RegularPriceUpdates", new[] { "Id" });
            DropIndex("dbo.AdminStoredItems", new[] { "StorageRequestId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.StoredItemInColdStorages");
            DropTable("dbo.RequestTableItems");
            DropTable("dbo.ColdStorageItemLists");
            DropTable("dbo.TransportationFleetRents");
            DropTable("dbo.TransportationFleetRegisters");
            DropTable("dbo.TrainingTables");
            DropTable("dbo.PlantingCalendars");
            DropTable("dbo.ManageColdStorages");
            DropTable("dbo.FreeSeedsDistributions");
            DropTable("dbo.EquipmentRents");
            DropTable("dbo.Users");
            DropTable("dbo.BuySellRequestBetweenFarmerAndTraders");
            DropTable("dbo.RequestTables");
            DropTable("dbo.PreviousPrices");
            DropTable("dbo.RegularPriceUpdates");
            DropTable("dbo.AdminStoredItems");
        }
    }
}
