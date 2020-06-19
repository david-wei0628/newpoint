using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
//using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "CPU  ID   :\n機板   ID    : \nBIOS  ID    : \n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagementClass mc_processor = new ManagementClass("Win32_Processor");
            ManagementClass mc_baseboard = new ManagementClass("Win32_BaseBoard");
            ManagementClass mc_bios = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection moc = mc_processor.GetInstances();
            ManagementObjectCollection moc2 = mc_baseboard.GetInstances();
            ManagementObjectCollection moc3 = mc_bios.GetInstances();
            string strID = null;
            string strID2 = null;
            string strID3 = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }

            foreach(ManagementObject mo in moc2)
            {
                strID2 = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }

            foreach (ManagementObject mo in moc3)
            {
                strID3 = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            label1.Text = "CPU ID : \t" + strID + "\n機板 ID : \t" + strID2 + "\n";
            label1.Text = label1.Text + "BIOS ID : \t" + strID3 + "\n";
        }
    }
}
