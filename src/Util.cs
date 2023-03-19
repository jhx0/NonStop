using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStop
{
    internal static class Util
    {
        public static void AdminCheck()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("You need to run this tool with admin rights!", 
                                "NonStop", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);

                System.Environment.Exit(0);
            }
        }

        public static String GetHost()
        {
            return Dns.GetHostName();
        }
    }
}
