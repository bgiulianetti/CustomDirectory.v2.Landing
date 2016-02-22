using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LandingCustomDirectory.Model
{
    public class SettingsInterface
    {
        public string Title { get; set; }
        public string Prompt { get; set; }
        public string ItemLanguageSettingsName { get; set; }
        public string ItemLanguageSettingsUrl { get; set; }
        public string ItemCountryCodesName { get; set; }
        public string ItemCountryCodesUrl { get; set; }
        public string ButtonSelect { get; set; }
        public string ButtonCancel { get; set; }


        public string ToStringXML()
        {
            var xmlBody = "<CiscoIPPhoneMenu>" + Environment.NewLine +
                          "<Title>" + Title + "</Title>" + Environment.NewLine +
                          "<Prompt>" + Prompt + "</Prompt>" + Environment.NewLine +

                          "<MenuItem>" + Environment.NewLine +
                          "<Name>" + ItemLanguageSettingsName + "</Name>" + Environment.NewLine +
                          "<URL>" + ConfigurationManager.AppSettings.Get("Url.Localhost") + ItemLanguageSettingsUrl + "</URL>" + Environment.NewLine +
                          "</MenuItem>" + Environment.NewLine +

                          "<MenuItem>" + Environment.NewLine +
                          "<Name>" + ItemCountryCodesName + "</Name>" + Environment.NewLine +
                          "<URL>" + ConfigurationManager.AppSettings.Get("Url.Localhost") + ItemCountryCodesUrl + "</URL>" + Environment.NewLine +
                          "</MenuItem>" + Environment.NewLine;

            var selectButton = ButtonSelect.Split('-');
            var cancelButton = ButtonCancel.Split('-');

            xmlBody += "<SoftKeyItem>" + Environment.NewLine +
                       "<Position>1</Position>" + Environment.NewLine +
                       "<Name>" + selectButton[0] + "</Name>" + Environment.NewLine +
                       "<URL" + selectButton[1] + "</URL>" + Environment.NewLine +
                       "</SoftKeyItem>" + Environment.NewLine +

                       "<SoftKeyItem>" + Environment.NewLine +
                       "<Position>2</Position>" + Environment.NewLine +
                       "<Name>" + cancelButton[0] + "</Name>" + Environment.NewLine +
                       "<URL>" + ConfigurationManager.AppSettings.Get("Url.Localhost") + cancelButton[1] + "</URL>" + Environment.NewLine +
                       "</SoftKeyItem>" + Environment.NewLine +

                       "</CiscoIPPhoneMenu>" + Environment.NewLine;
            return xmlBody;
        }
    }
}
