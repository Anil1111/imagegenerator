using System.Configuration;
using Newtonsoft.Json;

namespace ImageGenerator.Utilities
{
    public static class AppSettings
    {
        private static string ReadWebConfigKeys(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }

        public static string PathToDocuments => ReadWebConfigKeys("Path_To_Documents");

        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
