using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndPoint.WinApp.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGetExcelSoHs frm= new FrmGetExcelSoHs();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Forms.User.FrmLogin frmLogin = new Forms.User.FrmLogin();
          
            frmLogin.ShowDialog();
           // if (frmLogin.autentication == false) { Application.Exit(); return; }
        }
    }
}
