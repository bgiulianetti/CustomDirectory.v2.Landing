using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LandingCustomDirectory.Model
{
    public class LanguageSettingsInterface
    {
        public string Title { get; set; }
        public string Prompt { get; set; }
        public List<string> AvailableLanguages { get; set; }


        public string ToStringXML()
        {
            var xmlBody = "<CiscoIPPhoneMenu>" + Environment.NewLine +
                          "<Title>" + Title + "</Title>" + Environment.NewLine +
                          "<Prompt>" + Prompt + "</Prompt>" + Environment.NewLine;

            foreach (var item in AvailableLanguages)
            {
                var langauge = item.Split(':');
                xmlBody += "<MenuItem>" + Environment.NewLine +
                           "<Name>" + langauge[1] + "</Name>" + Environment.NewLine +
                           "<URL>" + ConfigurationManager.AppSettings.Get("Url.Localhost") + "LanguageSettings.aspx?language=" + langauge[0] + "</URL>" + Environment.NewLine;
            }
            xmlBody += "</CiscoIPPhoneMenu>";

            return xmlBody;
        }
    }
}
