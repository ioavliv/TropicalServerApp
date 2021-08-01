using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TropicalServer.DAL;

namespace TropicalServer.BLL
{
    public class ReportsBLL
    {
        public DataSet GetProductByProductCategory_BLL(string newItemDescription)
        {
            return (new ReportsDAL().GetProductByProductCategory_DAL(newItemDescription));
        }

        public DataSet GetCustSalesRepNumber_BLL(int newCustSaleRepNum)
        {
            return (new ReportsDAL().GetCustSalesRepNumber_DAL(newCustSaleRepNum));
        }

        public DataSet GetUsersSetting_BLL(string key, string cId)
        {
            return (new ReportsDAL().GetUsersSetting_DAL(key, cId));
        }

        public DataSet GetCustomersSetting_BLL()
        {
            return (new ReportsDAL().GetCustomersSetting_DAL());
        }

        public DataSet GetPriceGroupSetting_BLL()
        {
            return (new ReportsDAL().GetPriceGroupSetting_DAL());
        }

        public DataSet GetRouteInfo_BLL(int newRouteID)
        {
            return (new ReportsDAL().GetRouteInfo_DAL(newRouteID));
        }
        public DataSet GetItemTypeID_BLL()
        {
            return (new ReportsDAL().GetItemTypeID_DAL());
        }

        public DataSet GetItemsDetail_BLL(string itemType)
        {
            return (new ReportsDAL().GetItemsDetail_DAL(itemType));
        }

        public DataSet GetOrders_BLL()
        {
            return (new ReportsDAL().GetOrders_DAL());
        }
        public DataSet GetFilteredOrders_BLL(string condition)
        {
            return (new ReportsDAL().GetFilteredOrders_DAL(condition));
        }
        
    }
}
