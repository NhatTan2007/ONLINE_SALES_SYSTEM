using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ONLINE_SALES_SYSTEM.Ultilities
{
    class common
    {
        public enum OderStatus
        {
            Empty = 1,
            Available =2,

        }
        public static T ReadFileJson<T>(string fullPath)
        {
            using (StreamReader sd = new StreamReader(fullPath,Encoding.UTF8))
            {
                var data = sd.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(data);
            }

        }
        public static void WriteFileJson(object data, string fullPath)
        {
            using (StreamWriter sw = new StreamWriter(fullPath,append: false, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(data));
            }
        }

    }
}
