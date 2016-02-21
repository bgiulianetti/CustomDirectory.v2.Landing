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
                var langaugeSetterPath = string.Format(ConfigurationManager.AppSettings.Get("LanguageSetterPath"), GetLanguage());
                var file = new StreamWriter(HttpContext.Current.Server.MapPath(langaugeSetterPath));
                file.WriteLine(language);
                file.Close();
                var languageSettings = ConfigurationManager.AppSettings.Get("Url.Localhost") + "LanguageSettings.aspx";
                Response.Redirect(languageSettings, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            var language = File.ReadAllText(HttpContext.Current.Server.MapPath(languageSetterPath)).Replace("\r\n", "");
            return language;
        }
    }
}