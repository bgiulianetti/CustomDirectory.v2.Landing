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
    public partial class CountryCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var countryCodesInterface = CreateInterface();
            Response.ContentType = "text/xml";
            Response.Write(countryCodesInterface.ToStringXML());
        }

        private static CountryCodesInterface CreateInterface()
        {
            var landingTextPath = string.Format(ConfigurationManager.AppSettings.Get("CountryCodesPath"), GetLanguage());
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(landingTextPath)))
            {
                string jsonFile = r.ReadToEnd();
                var countryCodesInterface = JsonConvert.DeserializeObject<CountryCodesInterface>(jsonFile);
                return countryCodesInterface;
            }
        }

        private static string GetLanguage()
        {
            var languageSetterPath = ConfigurationManager.AppSettings.Get("LanguageSetterPath");
            return File.ReadAllText(HttpContext.Current.Server.MapPath(languageSetterPath));
        }
    }
}