using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NonStop
{
    internal class NonStopTool
    {
        private Logger logger;

        private readonly String[] RegistrySettings = new string[]
        {
            @"SOFTWARE\Microsoft\PolicyManager\default\Start\HideShutDown",
            @"SOFTWARE\Microsoft\PolicyManager\default\Start\HideRestart",
            @"SOFTWARE\Microsoft\PolicyManager\default\Start\HideHibernate",
            @"SOFTWARE\Microsoft\PolicyManager\default\Start\HideSleep",
            @"SOFTWARE\Microsoft\PolicyManager\default\Start\HidePowerButton"
        };

        public NonStopTool() {
            Util.AdminCheck();

            logger = new Logger();
        }

        private void AlterRegistrySettings(bool on)
        {
            /*
             * If "on" is true, set val to 0x1
             * If "on" is false, set val to 0x0
             */
            int val = on ? 0x1 : 0x0;

            foreach (String entry in RegistrySettings)
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(entry, true);
                try
                {
                    logger.WriteLog("Setting: " + entry, "Info");
                    key.SetValue("value", val);    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }

        public void GetStatus(System.Windows.Forms.TextBox tb)
        {
            int counter = 0;

            foreach (String entry in RegistrySettings)
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(entry, true);
                try
                {
                    if (key.GetValue("value", "none").ToString() == "1")
                    {
                        counter++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }

            if (counter == RegistrySettings.Length)
            {
                tb.Text = "Activated";
                tb.BackColor = Color.FromArgb(240,240,240);
                tb.ForeColor = Color.Red;

                return;
            }

            tb.Text = "Deactivated";
            tb.ForeColor = Color.Black;

            return;
        }

        public void Activate()
        {
            AlterRegistrySettings(true);
        }

        public void Deactivate() 
        {
            AlterRegistrySettings(false);
        }
    }
}
