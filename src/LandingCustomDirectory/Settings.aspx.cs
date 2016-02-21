using LandingCustomDirectory.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandingCustomDirectory
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var settingsInterface = CreateInterface();
            Response.ContentType = "text/xml";
            Response.Write(settingsInterface.ToStringXML());
        }

        private static SettingsInterface CreateInterface()
        {
            var landingTextPath = string.Format(ConfigurationManager.AppSettings.Get("SettingsPath"), GetLanguage());
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(landingTextPath)))
            {
                string jsonFile = r.ReadToEnd();
                var ssettingsInterface = JsonConvert.DeserializeObject<SettingsInterface>(jsonFile);
                return ssettingsInterface;
            }
        }

        private static string GetLanguage()
        {
            var languageSetterPath = ConfigurationManager.AppSettings.Get("LanguageSetterPath");
            return File.ReadAllText(HttpContext.Current.Server.MapPath(languageSetterPath)).Replace("\r\n", "");
        }
    }
}