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
    public partial class LanguageSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var language = Request.QueryString["language"];
            if (language != null)
                ChangeLanguage(language);

            var langaugeSettingsInterface = CreateInterface();
            Response.ContentType = "text/xml";
            Response.Write(langaugeSettingsInterface.ToStringXML());

        }

        private void ChangeLanguage(string language)
        {
            try
            {
                var file = new StreamWriter(ConfigurationManager.AppSettings.Get("LanguageSetterPath"));
                file.WriteLine(language);
                Response.Redirect(ConfigurationManager.AppSettings.Get("Url.Localhost") + "LanguageSettings.aspx");
            }
            catch { }
        }

        private static LanguageSettingsInterface CreateInterface()
        {
            var langaugeSettingsPath = string.Format(ConfigurationManager.AppSettings.Get("LangaugeSettingsPath"), GetLanguage());
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(langaugeSettingsPath)))
            {
                string jsonFile = r.ReadToEnd();
                var languageSettingsInterface = JsonConvert.DeserializeObject<LanguageSettingsInterface>(jsonFile);
                return languageSettingsInterface;
            }
        }

        private static string GetLanguage()
        {
            var languageSetterPath = ConfigurationManager.AppSettings.Get("LanguageSetterPath");
            return File.ReadAllText(HttpContext.Current.Server.MapPath(languageSetterPath));
        }
    }
}