using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("click active");
            string regPath = ConfigHelp.GetAppSettingValue("RegPath");
            string regName = ConfigHelp.GetAppSettingValue("RegName");
            string regValue = ConfigHelp.GetAppSettingValue("RegValue");
            Console.WriteLine("" + regPath);
            if (regPath.StartsWith("HKEY_CURRENT_USER"))
                RegCurrentUser.update(regPath.Replace("HKEY_CURRENT_USER\\\\", ""), regName, regValue);
            else if (regPath.StartsWith("HKEY_LOCAL_MACHINE"))
                RegLocalMachine.update(regPath.Replace("HKEY_LOCAL_MACHINE\\\\", ""), regName, regValue);
            System.Windows.Forms.MessageBox.Show("执行完毕！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
