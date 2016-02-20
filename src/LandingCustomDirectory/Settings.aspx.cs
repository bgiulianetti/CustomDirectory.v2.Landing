using System;
using System.Collections.Generic;
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

        }

        private string PrintXml()
        {
            var xmlBody = "<CiscoIPPhoneMenu>" + Environment.NewLine +
                          "<Title>Title text goes here </Title>" + Environment.NewLine +
                          "<Prompt>Prompt text goes here </Prompt>" + Environment.NewLine +
                          
                          "<MenuItem>" + Environment.NewLine +
                          "<Name>The name of each menu item </Name>" + Environment.NewLine +
                          "<URL>The URL associated with the menu item</URL>" + Environment.NewLine +
                          "</MenuItem>" + Environment.NewLine +

                          "<MenuItem>" + Environment.NewLine +
                          "<Name>The name of each menu item </Name>" + Environment.NewLine +
                          "<URL>The URL associated with the menu item</URL>" + Environment.NewLine +
                          "</MenuItem>" + Environment.NewLine +

                          "</CiscoIPPhoneMenu>";

            return null;
        }
    }
}