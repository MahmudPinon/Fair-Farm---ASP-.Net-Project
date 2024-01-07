using DAL.EF.Models;
using DAL.Interfaces.Trader;
using DAL.Interfaces;
using DAL.Repos.Trader;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repos.Admin;

namespace DAL
{
    public class DataAccessFactoryTrader
    {
        public static IRepo<User, int, User> UserData()
        {

            return new UserRepo();
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
        public static ITransport<TransportationFleetRegister, int, TransportationFleetRegister> TransportContent()
        {
            return new TransportRepo();
        }



        public static ITraderRent<EquipmentRent, int, EquipmentRent, string> TraderEquipmentRentData()
        {

            return new TraderEquipmentRentRepo();
        }
        public static ITraderShowRedList<User, int, string> TraderShowRedListData()
        {
            return new TraderShowRedListRepo();
        }
        public static IRequestBuySellColdStorage<RequestTable, int, string> TradersellandColdStorageRequestData()
        {
            return new TraderRequestSellandColdStorageRepo();
        }
        public static ITraderColdStorageandSellRequestItem<RequestTableItem, int, RequestTableItem> TraderAddSellItemtotheRequestItemData()
        {

            return new TraderSellItemRepo();
        }
    }
}
