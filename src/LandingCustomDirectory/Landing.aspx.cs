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
            var menu = CreateStringMenu();
            //var xml = PrintXML(menu);
            Response.ContentType = "text/xml";
            Response.Write(menu);
        }


        public static string PrintXML(string XML)
        {
            string Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(XML);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }

        public static string CreateStringMenu()
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
    }
}