using LandingCustomDirectory.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace LandingCustomDirectory
{
    public partial class Landing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["search"] == "true")
            {
                var directorySearch = ConfigurationManager.AppSettings.Get("Url");
                directorySearch += "?f=" + Request.QueryString["f"] +
                                   "&l=" + Request.QueryString["l"] +
                                   "&n=" + Request.QueryString["n"] +
                                   "&p=" + Request.QueryString["p"];
                Response.Redirect(directorySearch, false);
            }
            else
            {
                var searchInterface = CreateInterface();
                Response.ContentType = "text/xml; charset=utf-8";
                Response.Write(searchInterface.ToStringXML());
            }
        }

        private static SearchInterface CreateInterface()
        {
            var landingTextPath = string.Format(ConfigurationManager.AppSettings.Get("LandingPath"), GetLanguage());
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath(landingTextPath)))
            {
                string jsonFile = r.ReadToEnd();
                var searchInterface = JsonConvert.DeserializeObject<SearchInterface>(jsonFile);
                return searchInterface;
            }
        }
        private static string GetLanguage()
        {
            var languageSetterPath = ConfigurationManager.AppSettings.Get("LanguageSetterPath");
            return File.ReadAllText(HttpContext.Current.Server.MapPath(languageSetterPath)).Replace("\r\n", "");
        }

    }
}