﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LandingCustomDirectory.Model
{
    public class SearchInterface
    {

        public SearchInterface()
        {

        }

        public string ButtonCancel { get; protected set; }
        public string ButtonSearch { get; protected set; }
        public string Prompt { get; protected set; }
        public string SearchCountry { get; protected set; }
        public string SearchLastname { get; protected set; }
        public string SearchName { get; protected set; }
        public string SearchNumber { get; protected set; }
        public string Title { get; protected set; }

        public string ToStringXML()
        {
            var SearchInterface = "<CiscoIPPhoneInput>" + Environment.NewLine +
                                  "<Title>" + Title + "</Title>" + Environment.NewLine +
                                  "<Prompt>" + Prompt + "</Prompt>" + Environment.NewLine +
                                  "<URL>" + ConfigurationManager.AppSettings.Get("Url") + "</URL>" + Environment.NewLine +

                                  "<InputItem>" + Environment.NewLine +
                                  "<DisplayName>" + SearchName + "</DisplayName>" + Environment.NewLine +
                                  "<QueryStringParam>f</QueryStringParam>" + Environment.NewLine +
                                  "<InputFlags>A</InputFlags>" + Environment.NewLine +
                                  "<DefaultValue></DefaultValue>" + Environment.NewLine +
                                  "</InputItem>" + Environment.NewLine +

                                  "<InputItem>" + Environment.NewLine +
                                  "<DisplayName>" + SearchLastname + "</DisplayName>" + Environment.NewLine +
                                  "<QueryStringParam>l</QueryStringParam>" + Environment.NewLine +
                                  "<InputFlags>A</InputFlags>" + Environment.NewLine +
                                  "<DefaultValue></DefaultValue>" + Environment.NewLine +
                                  "</InputItem>" + Environment.NewLine +

                                  "<InputItem>" + Environment.NewLine +
                                  "<DisplayName>" + SearchNumber + "</DisplayName>" + Environment.NewLine +
                                  "<QueryStringParam>n</QueryStringParam>" + Environment.NewLine +
                                  "<InputFlags>T</InputFlags>" + Environment.NewLine +
                                  "<DefaultValue></DefaultValue>" + Environment.NewLine +
                                  "</InputItem>" + Environment.NewLine +

                                  "<InputItem>" + Environment.NewLine +
                                  "<DisplayName>" + SearchCountry + "</DisplayName>" + Environment.NewLine +
                                  "<QueryStringParam>p</QueryStringParam>" + Environment.NewLine +
                                  "<InputFlags>A</InputFlags>" + Environment.NewLine +
                                  "<DefaultValue></DefaultValue>" + Environment.NewLine +
                                  "</InputItem>" + Environment.NewLine +


                                  "<SoftKeyItem>" + Environment.NewLine +
                                  "<Position>1</Position>" + Environment.NewLine +
                                  "<Name>" + ButtonSearch + "</Name>" + Environment.NewLine +
                                  "<URL>SoftKey:Submit</URL>" + Environment.NewLine +
                                  "</SoftKeyItem>" + Environment.NewLine +

                                  "<SoftKeyItem>" + Environment.NewLine +
                                  "<Position>2</Position>" + Environment.NewLine +
                                  "<Name>&lt;&lt;</Name>" + Environment.NewLine +
                                  "<URL>SoftKey:&lt;&lt;</URL>" + Environment.NewLine +
                                  "</SoftKeyItem>" + Environment.NewLine +

                                  "<SoftKeyItem>" + Environment.NewLine +
                                  "<Position>3</Position>" + Environment.NewLine +
                                  "<Name>" + ButtonCancel + "</Name>" + Environment.NewLine +
                                  "<URL>SoftKey:Cancel</URL>" + Environment.NewLine +
                                  "</SoftKeyItem>" + Environment.NewLine +
                                  "</CiscoIPPhoneInput>";
                return SearchInterface;
        }

        protected string GetLanguage()
        {
            return "es";
        }
    }
}
