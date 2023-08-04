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
    public partial class frmbranch : Form
    {
        db db1 = new db();
        ErrorProvider ep1 = new ErrorProvider();
        public frmbranch()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bool check;
            db.SetError(out check, ep1, txtbankname, txtbranchname, txtmanagername);
            if (check == false)
                return;
            
            string sql;
            int i;

            sql = String.Format("INSERT INTO tbl_branch(sBankName,sBranchName,sPhone,sManager,sAddress) VALUES('{0}','{1}','{2}','{3}','{4}')", txtbankname.Text, txtbranchname.Text, txtphone.Text, txtmanagername.Text, txtaddress.Text);
            i = db1.InsertRecord(sql);
            if (i == 1)
                MessageBox.Show("شعبه جديد در بانک تعريف شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtbankname_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }
    }
}
