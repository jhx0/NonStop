using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonStop
{
    public partial class NonStopUI : Form
    {
        private NonStopTool nst;
        private Logger logger;

        public NonStopUI()
        {
            InitializeComponent();

            logger = new Logger();

            logger.WriteLog("Starting NonStop", "Info");

            nst = new NonStopTool();

            txtBoxHost.Text = Util.GetHost();

            nst.GetStatus(txtBoxStatus);
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            logger.WriteLog("Activating NonStop", "Info");

            nst.Activate();

            nst.GetStatus(txtBoxStatus);
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            logger.WriteLog("Deactivating NonStop", "Info");

            nst.Deactivate();

            nst.GetStatus(txtBoxStatus);
        }
    }
}
