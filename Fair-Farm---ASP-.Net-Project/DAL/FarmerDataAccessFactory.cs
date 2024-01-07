using DAL.EF.Models;
using DAL.Interfaces.Farmer;
using DAL.Interfaces;
using DAL.Repos.Farmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FarmerDataAccessFactory
    {
        public static IRepo<PlantingCalendar, int, PlantingCalendar> PlantingCalenderData()
        {

            return new FarmerPlantingCalenderRepo();
        }
        public static IFarmerRent<EquipmentRent, int, EquipmentRent, string> FarmerEquipmentRentData()
        {

            return new FarmerEqupmentRentRepo();
        }
        public static ICheckPlantingCalenderExisting<PlantingCalendar, int, string> ExistingPlantingCalenderData()
        {

            return new FarmerPlantingCalenderRepo();
        }
        public static ISeeTransportationFleet<TransportationFleetRegister, int, string> FarmerTransportationFleetRegisterData()
        {

            return new FarmerRegisteredTransportationFleetRepo();
        }
        public static ITransportationFleetRentbyFarmer<TransportationFleetRent, int, TransportationFleetRent> FarmerTransportationFleetRentData()
        {

            return new FarmerTransportationRentRepo();
        }

        public static IFarmerAccessRedList<User, int, string> FarmerAccesstoRedListUserData()
        {

            return new FarmerAccesstoRedListRepo();
        }
        public static ISeeTransportationFleet<TrainingTable, int, string> FarmerTrainingData()
        {

            return new FarmerTrainingDetailsRepo();
        }

        public static IRegularPriceandPreviousPrice<RegularPriceUpdate, int> FarmerRegularPriceData()
        {

            return new FarmerRegularPriceandRepo();
        }
        public static IRegularPriceandPreviousPrice<PreviousPrice, int> FarmerPreviousData()
        {

            return new FarmerPreviousPriceRepo();
        }
        public static ISeeTransportationFleet<FreeSeedsDistribution, int, string> FarmerFreeSeedDistributionData()
        {

            return new FarmerFreeSeedDistributionRepo();
        }
        public static IBuySellColdStorage<RequestTable, int, string> FarmersellandColdStorageRequestData()
        {
            return new FarmerRequestSellandColdStorageRepo();
        }


        public static IFarmerColdStorageandSellRequestItem<RequestTableItem, int, RequestTableItem> FarAddSellItemtotheRequestItemData()
        {

            return new FarmerSellItemRepo();
        }
        public static IFarmerColdStorageandSellRequestItem<ColdStorageItemList, int, ColdStorageItemList> FarAddColdStorageItemtotheRequestItemData()
        {

            return new FarmerColdStorageItemRepo();
        }


        public static IBuySellbetweenFarmerandTrader_User_Farmer<BuySellRequestBetweenFarmerAndTrader, string, int, BuySellRequestBetweenFarmerAndTrader> FarmerBuySellRequestBetweenFarmerandTrader()
        {
            return new FarmerBuySellBetweenFarmerandTraderRepo();
        }
    }
}
