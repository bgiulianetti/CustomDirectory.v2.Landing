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

        private static string CreateStringMenu()
        {
            string menu = "<CiscoIPPhoneInput>" + Environment.NewLine +
                          "<Title>Directorio de busqueda</Title>" + Environment.NewLine +
                          "<Prompt>Ingrese criterio de busqueda</Prompt>" + Environment.NewLine +
                          "<URL>" + ConfigurationManager.AppSettings.Get("Url") + "</URL>" + Environment.NewLine +

                          "<InputItem>" + Environment.NewLine +
                          "<DisplayName>Nombre</DisplayName>" + Environment.NewLine +
                          "<QueryStringParam>f</QueryStringParam>" + Environment.NewLine +
                          "<InputFlags>A</InputFlags>" + Environment.NewLine +
                          "<DefaultValue></DefaultValue>" + Environment.NewLine +
                          "</InputItem>" + Environment.NewLine +

                          "<InputItem>" + Environment.NewLine +
                          "<DisplayName>Apellido</DisplayName>" + Environment.NewLine +
                          "<QueryStringParam>l</QueryStringParam>" + Environment.NewLine +
                          "<InputFlags>A</InputFlags>" + Environment.NewLine +
                          "<DefaultValue></DefaultValue>" + Environment.NewLine +
                          "</InputItem>" + Environment.NewLine +

                          "<InputItem>" + Environment.NewLine +
                          "<DisplayName>Numero</DisplayName>" + Environment.NewLine +
                          "<QueryStringParam>n</QueryStringParam>" + Environment.NewLine +
                          "<InputFlags>T</InputFlags>" + Environment.NewLine +
                          "<DefaultValue></DefaultValue>" + Environment.NewLine +
                          "</InputItem>" + Environment.NewLine +

                          "<InputItem>" + Environment.NewLine +
                          "<DisplayName>Pais</DisplayName>" + Environment.NewLine +
                          "<QueryStringParam>p</QueryStringParam>" + Environment.NewLine +
                          "<InputFlags>A</InputFlags>" + Environment.NewLine +
                          "<DefaultValue></DefaultValue>" + Environment.NewLine +
                          "</InputItem>" + Environment.NewLine +


                          "<SoftKeyItem>" + Environment.NewLine +
                          "<Position>1</Position>" + Environment.NewLine +
                          "<Name>Buscar</Name>" + Environment.NewLine +
                          "<URL>SoftKey:Submit</URL>" + Environment.NewLine +
                          "</SoftKeyItem>" + Environment.NewLine +
                          "<SoftKeyItem>" + Environment.NewLine +
                          "<Position>2</Position>" + Environment.NewLine +
                          "<Name>&lt;&lt;</Name>" + Environment.NewLine +
                          "<URL>SoftKey:&lt;&lt;</URL>" + Environment.NewLine +
                          "</SoftKeyItem>" + Environment.NewLine +
                          "<SoftKeyItem>" + Environment.NewLine +
                          "<Position>3</Position>" + Environment.NewLine +
                          "<Name>Cancel</Name>" + Environment.NewLine +
                          "<URL>SoftKey:Cancel</URL>" + Environment.NewLine +
                          "</SoftKeyItem>" + Environment.NewLine +
                          "</CiscoIPPhoneInput>";
            return menu;
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