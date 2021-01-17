using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Ultilities
{
    public static class FilePath
    {
        public static string strRootDataPath => @"D:\LEARNING\MODULE 2\CASE STUDY\ONLINE SALES SYSTEM\ONLINE SALES SYSTEM\Data\";
        public static string strCustomerPath => @"Customer\";
        public static string strCustomerOrderHistoryFileName = "OrderHistory.json";
        public static string strOrderPath => @"Orders\";
        public static string strShopPath => @"Shop\";
        public static string strProductListFileName => @"ProductList.json";
        public static string strOrderFileName = String.Empty;
        public static string strCartFileName => "Cart.json";
    }
}
