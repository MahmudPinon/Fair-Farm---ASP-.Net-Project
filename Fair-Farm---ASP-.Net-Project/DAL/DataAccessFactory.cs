using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Interfaces.Admin;
using DAL.Repos;
using DAL.Repos.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, User> UserData()
        {

            return new UserRepo();
        }
        public static IRepo<TrainingTable, int, TrainingTable> TrainingData()
        {

            return new ManageTraningRepo();
        }
        public static IRepo<ManageColdStorage, int, ManageColdStorage> ColdStorageData()
        {

            return new ManageColdStorageRepo();
        }
        public static IRepo<FreeSeedsDistribution, int, FreeSeedsDistribution> FreeSeedReqData()
        {

            return new FreeSeedsDistributionManagementRepo();
        }

        public static IRepo<RequestTable, int, RequestTable> RequestCropData()
        {

            return new ManageBuySellRequestRepo();
        }
        public static IPreviousPrice<PreviousPrice, int, PreviousPrice> PreviousPriceData()
        {

            return new PreviousPriceRepo();
        }
        public static ICropBuySellRequest<RequestTableItem, int, RequestTableItem> RequestTableItemData()
        {

            return new ManageBuySellRequestItemRepo();
        }








        public static IRepo<StoredItemInColdStorage, int, StoredItemInColdStorage> ColdStorageStoreData()
        {

            return new ManageColdStorageRequestRepo(); //Store items in Cold Storage Aftter accepting
        }
        public static IColdStorageRequestManage<ColdStorageItemList, int, ColdStorageItemList> ColdStorageRequestItemData()
        {

            return new ColdStorageRequestItemRepo(); // manage and Get requested Items
        }
















        public static IRepo<AdminStoredItem, int, AdminStoredItem> AdminStoredItemData()
        {

            return new AdminStoredItemRepo();
        }

        public static IRepo<BuySellRequestBetweenFarmerAndTrader, int, BuySellRequestBetweenFarmerAndTrader> BuySellRequestBetweenFarmerAndTraderData()
        {

            return new BuySellRequestBetweenFarmerAndTraderRepo();
        }

        public static IRepo<RegularPriceUpdate, int, RegularPriceUpdate> RegularPriceData()
        {

            return new ManageRegularPriceUpdateRepo();
        }
        public static IRegularPriceDataByName<RegularPriceUpdate, string, RegularPriceUpdate> RegularPriceNameData()
        {

            return new ManageRegularPriceUpdateRepo();
        }



        public static IAuth AuthData()
        {

            return new UserRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IUserIdFormUname GetUserIdData()
        {

            return new UserRepo();
        }
    }
}
