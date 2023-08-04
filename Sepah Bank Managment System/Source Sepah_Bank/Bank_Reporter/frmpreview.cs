using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank_Reporter
{
    public partial class frmpreview : Form
    {
        public frmpreview()
        {
            InitializeComponent();
        }

        private void frmpreview_Load(object sender, EventArgs e)
        {
            txtname.Text = Applicant.txtname + " " + Applicant.txtfamily;
            txtshsh.Text = Applicant.txtshsh;
            txtphone.Text = Applicant.txtphone;
            txtcodeeteberi.Text = Applicant.txtcodeetebari;
            txtaccountnumber.Text = Applicant.txtaccountnumber;
            txtaccounttype.Text = Applicant.txtaccounttype;

            txtname1.Text = Zamen.txtname + " " + Zamen.txtfamily;
            txtshsh1.Text = Zamen.txtshsh;
            txtphone1.Text = Zamen.txtphone;
            txtcodeeteberi1.Text = Zamen.txtcodeetebari;
            txtaccountnumber1.Text = Zamen.txtaccountnumber1;
            txtaccounttype1.Text = Zamen.txtaccounttype;

            txtname2.Text = Zamen2.txtname + " " + Zamen2.txtfamily;
            txtshsh2.Text = Zamen2.txtshsh;
            txtphone2.Text = Zamen2.txtphone;
            txtcodeeteberi2.Text = Zamen2.txtcodeetebari;
            txtaccountnumber2.Text = Zamen2.txtaccountnumber1;
            txtaccounttype2.Text = Zamen2.txtaccounttype;

        }
    }
}
