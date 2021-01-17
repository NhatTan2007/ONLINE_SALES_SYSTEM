using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ONLINE_SALES_SYSTEM.Ultilities
{
    class Common
    {
        public static T ReadFileJson<T>(string fullPath)
        {
            using (StreamReader sr = new StreamReader(fullPath, Encoding.UTF8))
            {
                string data = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(data);
            }

        }
        public static void WriteFileJson(object data, string fullPath, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, append, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(data));
            }
        }

        public static string ReadDataFromConsole()
        {
            return Console.ReadLine().Trim();
        }
    }

    public enum OrderStatus
    {
        Paid = 1,
        CashOnDelivery = 2,
    }
}
