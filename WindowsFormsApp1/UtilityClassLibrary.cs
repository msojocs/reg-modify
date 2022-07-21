using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ConfigHelp
    {
        public static string GetAppSettingValue(string key)
        {
            string val = "";

            try
            {
                val = System.Configuration.ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                val = "";
            }
            return val;
        }

        public static string GetConnectionString(string key)
        {
            string val = "";

            try
            {
                val = System.Configuration.ConfigurationManager.ConnectionStrings[key].ToString();
            }
            catch (Exception ex)
            {
                val = "";
            }
            return val;
        }


    }

}
