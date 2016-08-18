using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LandingCustomDirectory
{
    public partial class CreateQueryString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p = string.Empty;
            if (!String.IsNullOrEmpty(Request.QueryString["p"]))
            {
                p = ValidateCountry(Request.QueryString["p"].ToLower());
                if (p == string.Empty)
                {
                    var countryCode = ConfigurationManager.AppSettings.Get("Url.Localhost") + "CountryCodes.aspx";
                    Response.Redirect(countryCode, true);
                }
            }

            var landing = ConfigurationManager.AppSettings.Get("Url.Localhost");
            landing += "Landing.aspx" + "?search=true" +
                                        "&f=" + Request.QueryString["f"] +
                                        "&l=" + Request.QueryString["l"] +
                                        "&n=" + Request.QueryString["n"] +
                                        "&p=" + p;
            Response.Redirect(landing, false);
        }

        private string ValidateCountry(string country)
        {
            if (country == "ar" || country == "arg" || country == "arge" || country == "argen" || country == "argent" || country == "agentina" || country == "arentina" || country == "rgentina" || country == "argentin" || country == "argenti" || country == "maradona" || country == "messi")
                return "ar";
            if (country == "au" || country == "aus" || country == "aust" || country == "austr" || country == "austra" || country == "austral" || country == "australi" || country == "autralia" || country == "stralia" || country == "austalia" || country == "astralia" || country == "austraia")
                return "au";
            if (country == "bo" || country == "bol" || country == "boli" || country == "boliv" || country == "bolivi" || country == "bolivia" || country == "blivia" || country == "olivia" || country == "bolvia")
                return "bo";
            if (country == "br" || country == "bra" || country == "bras" || country == "brasi" || country == "brasil" || country == "basil" || country == "brsil" || country == "brail" || country == "rasil" || country == "brasl" || country == "7a1" || country == "7 a 1" || country == "pele" || country == "debuto con un pibe")
                return "br";
            if (country == "co" || country == "col" || country == "colo" || country == "colom" || country == "colomb" || country == "colombi" || country == "colombia" || country == "clombia" || country == "olombia" || country == "colomia" || country == "coombia" || country == "colobia" || country == "pecho frio")
                return "co";
            if (country == "es" || country == "esp" || country == "espa" || country == "españ" || country == "espan" || country == "españa" || country == "span" || country == "espana" || country == "esaña" || country == "esoaña")
                return "es";
            if (country == "fr" || country == "fra" || country == "fran" || country == "franc" || country == "franci" || country == "francia" || country == "fancia" || country == "frncia" || country == "rancia" || country == "franca")
                return "fr";
            if (country == "pe" || country == "per" || country == "peru" || country == "peu" || country == "pru" || country == "eru")
                return "pe";
            if (country == "py" || country == "par" || country == "para" || country == "parag" || country == "paragu" || country == "paragua" || country == "paraguay" || country == "araguay" || country == "praguay" || country == "oaraguay" || country == "parauay" || country == "paraguai")
                return "py";
            if (country == "us" || country == "est" || country == "esta" || country == "estad" || country == "estado" || country == "estados" || country == "unidos" || country == "estados unidos" || country == "estado unidos" || country == "estados unido" || country == "america" || country == "america del norte" || country == "estados unidos de america" || country == "eeuu" || country == "usa" || country == "u.s.a." || country == "ee.uu")
                return "us";
            if (country == "uk" || country == "rei" || country == "rein" || country == "reino" || country == "reino unido" || country == "rino unido")
                return "uk";
            if (country == "ve" || country == "ven" || country == "vene" || country == "venez" || country == "venezu" || country == "venezue" || country == "venezuel" || country == "venezuela")
                return "ve";
            if (country == "cl" || country == "ch" || country == "chi" || country == "chil" || country == "chile" || country == "chle" || country == "hile" || country == "chie" || country == "cile")
                return "cl";
            if (country == "de" || country == "al" || country == "ale" || country == "alem" || country == "alema" || country == "aleman" || country == "alemani" || country == "alemania" || country == "aemania" || country == "alemaia")
                return "de";
            if (country == "mx" || country == "me" || country == "mex" || country == "mexi" || country == "mexic" || country == "mexico" || country == "me" || country == "mexco")
                return "mx";
            if (country == "nl" || country == "ho" || country == "hol" || country == "hola" || country == "holan" || country == "holand" || country == "holanda" || country == "hlanda" || country == "olanda")
                return "nl";
            if (country == "uy" || country == "ur" || country == "uru" || country == "urug" || country == "urugu" || country == "urugua" || country == "uruguay" || country == "urguay" || country == "charrua")
                return "uy";
            else
                return "";
        }
    }
}