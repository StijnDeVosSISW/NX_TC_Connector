using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NX_TC_Connector
{
    class Program
    {
        static void Main(string[] args)
        {
            // INITIALIZATIONS
            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.PDM.PdmSession thePdmSession = theSession.PdmSession;
            NXOpen.ListingWindow lw = theSession.ListingWindow;

            lw.Open();
            lw.WriteFullline(
                " ----------------- " + Environment.NewLine +
                "| NX TC CONNECTOR |" + Environment.NewLine +
                " ----------------- ");

            // GET TC CONNECTION INFO
            string TCconnectString = "";
            string TCdiscriminator = "";
            thePdmSession.GetTcserverSettings(out TCconnectString, out TCdiscriminator);

            lw.WriteFullline(Environment.NewLine +
                "TC connect string =  " + TCconnectString + Environment.NewLine + 
                "TC discriminator =  " + TCdiscriminator);

            // GET TC USER INFO
            string userName = thePdmSession.GetUserName();
            string userGroup = thePdmSession.GetUserGroup();
            string userRole = thePdmSession.GetUserRole();

            lw.WriteFullline(Environment.NewLine +
                "User name =  " + userName + Environment.NewLine + 
                "User group =  " + userGroup + Environment.NewLine + 
                "User role =  " + userRole);
        }

        public static int GetUnloadOption(string arg)
        {
            //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
            return System.Convert.ToInt32(NXOpen.Session.LibraryUnloadOption.Immediately);
            // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
        }
    }
}
