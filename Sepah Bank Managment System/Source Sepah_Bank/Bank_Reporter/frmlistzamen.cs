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
    public partial class frmlistzamen : Form
    {
        string myID;
        db db1 = new db();
        public frmlistzamen()
        {
            InitializeComponent();
        }
        public string sID
        {
            set
            {
                myID = value;
            }
            get
            {
                return myID;
            }
        }

        private void frmlistzamen_Load(object sender, EventArgs e)
        {
            string sql = "SELECT DISTINCT sZamenID as  `کد ملی` ,fname + ' ' + lname as `نام و نام خانوادگی`,phone as `تلفن`,mobile as `موبایل`,account_num as `شماره حساب` FROM tbl_zamens,tbl_zamen,tbl_call,tbl_info_sand_zamen WHERE sPersonID = '" + myID + "' AND tbl_call.id_person_fk = " + myID + " AND tbl_info_sand_zamen.fk_code = tbl_zamens.sZamenID";

            DataTable d1 = db1.ReportRecord(sql);
            dg1.DataSource = d1;
            dg1.Refresh();
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string codemeli = dg1.Rows[row].Cells[0].Value.ToString();
            myID = codemeli;
            Hide();
        }
    }
}
