using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandingCustomDirectory.Model
{
    public class CountryCodesInterface
    {
        public string Title { get; set; }
        public string Prompt { get; set; }
        public List<string> Countries { get; set; }
        public string Text { get; set; }


        public string ToStringXML()
        {
            var xmlBody = "<CiscoIPPhoneText>" + Environment.NewLine +
                          "<Title>" + Title + "</Title>" + Environment.NewLine +
                          "<Prompt>" + Prompt + "</Prompt>" + Environment.NewLine +
                          "<Text>";

            foreach (var item in Countries)
                xmlBody += item + Environment.NewLine;

            xmlBody += "</Text>" + Environment.NewLine + 
                       "</CiscoIPPhoneText>";

            return xmlBody;
        }
    }

}
