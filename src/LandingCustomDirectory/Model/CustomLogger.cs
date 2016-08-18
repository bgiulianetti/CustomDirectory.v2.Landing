using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LandingCustomDirectory.Model
{
    public static class CustomLogger
    {
        public static void Log(string ErrorMessage)
        {
            try
            {
                var customLog = string.Format(ConfigurationManager.AppSettings.Get("CustomLog"));
                var file = new StreamWriter(HttpContext.Current.Server.MapPath(customLog));
                file.WriteLine("Log Entry " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - "  + ErrorMessage);
                file.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
