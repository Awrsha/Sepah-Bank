using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Bank_Reporter
{
    public partial class frmzamen : Form
    {
        bool idExist;
        db db1 = new db();
        bool blnIsZamenInf;
        string sZamenNumber;
        public frmzamen()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        public string sZamendNum
        {
            set
            {
                sZamenNumber = value;
            }
        }
        private void ClearcolorText_Leave(object sender, EventArgs e)
        {
            TextBox t1;
            if (sender is TextBox)
            {
                t1 = sender as TextBox;
                t1.BackColor = Color.White;
                if (t1.Name == "txtpricecheque" || t1.Name == "txttashilatprice" || t1.Name == "txtpayprice")
                {
                    t1.Text = db.Number2Curreny(t1.Text);
                }
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            TextBox t1;
            if (sender is TextBox)
            {
                t1 = sender as TextBox;
                t1.BackColor = Color.FromArgb(253, 233, 137);
            }
        }

        private void frmperson_Load(object sender, EventArgs e)
        {
            
            //string myID;
            if (Applicant.txtcode != "" && Applicant.txtcode != null)
            {
                if (Zamens.Zamen1 == true)
                    btnprint.Text = "تعین ضامن شماره 2";

                if (sZamenNumber != "" && sZamenNumber != null && sZamenNumber == "1" && Zamen.txtcode != null && Zamen.txtcode != "")
                {
                    btnprint.Text = "عدم تعین ضامن";
                    autocomplete(Zamen.txtcode);
                    return;
                }
                else if (sZamenNumber != "" && sZamenNumber != null && sZamenNumber == "2" && Zamen2.txtcode != null && Zamen2.txtcode != "")
                {
                    btnprint.Text = "عدم تعین ضامن";
                    autocomplete(Zamen2.txtcode);
                    return;
                }

                //frmlistzamen fm1 = new frmlistzamen();
                //fm1.sID = Applicant.txtcode;
                //fm1.ShowDialog();
                //myID = fm1.sID;
                //if (myID != "" && myID != null)
                //{
                //    txtcode.Text = myID;
                //    autocomplete(myID);
                //}
            }
            db1.GetSourceText("SELECT codemeli FROM tbl_zamen", txtcode, "codemeli");
            db1.GetSourceText("SELECT fname FROM tbl_zamen", txtname, "fname");
            db1.GetSourceText("SELECT lname FROM tbl_zamen", txtfamily, "lname");
            txtcode.Select();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            db.ClearControls(this);
        }

        private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtjob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtcode.Text == "")
            {
                MessageBox.Show("لطفا کد ملی را وارد کتید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (chkedit.Checked == false)
            {
                if (idExist == true)
                {
                    MessageBox.Show("شما اطلاعاتی با این کد ملی ثبت کرده اید.دوباره تلاش کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                sql = "INSERT INTO tbl_zamen VALUES('" + txtcode.Text + "','" + txtname.Text + "','" + txtfamily.Text + "','" + txtfname.Text + "','" + txtbirthday.Text + "','" + txtbirthplace.Text + "','" + txtshsh.Text + "','" + txtssh.Text + "','" + (txtserishalphabet.Text + " " + txtserish.Text) + "','" + txtcodeposti.Text + "','" + txtaddress.Text + "','" + txtjob.Text + "','" + (rbman.Checked == true ? "Man" : "Woman") + "','" + txttabeiat.Text + "','" + txtsanadplace.Text + "','" + txtactiveplace.Text + "','" + txtmahalekasb.Text + "')";
                db1.InsertRecord(sql);
                sql = "INSERT INTO tbl_call(phone,mobile,phone_mahal,id_person_fk) VALUES('" + txtphone.Text + "','" + txtphone1.Text + "','" + txtphonemahalekasb.Text + "','" + txtcode.Text + "')";
                db1.InsertRecord(sql);
                sql = "INSERT INTO tbl_info_sand_zamen VALUES('" + txtactivetype.Text + "','" + txtactivetime.Text + "','" + txtmojabeztype.Text + "','" + txtsendmojavez.Text + "','" + txtvakhast.Text + "','" + txtshohrat.Text + "','" + txtdate.Text + "','" + txtdate1.Text + "','" + txtexpire.Text + "','" + txtaccounttype.Text + "','" + txtdateeftetah.Text + "','" + txtaccountnumber1.Text + "','" + txtcodeetebari.Text + "','" + txtcode.Text + "')";
                db1.InsertRecord(sql);
                Zamens.Zamen1 = true;
                panel1.Visible = true;
                lblres.Text = "اطلاعات با موفقیت ثبت شد";
            }
            else if (chkedit.Checked == true && idExist == true)
            {
                if (blnIsZamenInf == false)
                {
                    MessageBox.Show("شما فقط میتوانید اطلاعات غیرضامن را در قسمت اطلاعات وام گیرنده ویرایش کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                sql = "update tbl_zamen SET fname ='" + txtname.Text + "',lname ='" + txtfamily.Text + "',fathername ='" + txtfname.Text + "',b_date='" + txtbirthday.Text + "',m_date='" + txtbirthplace.Text + "',id_shen='" + txtshsh.Text + "',serial_shen='" + txtssh.Text + "',seri_shen='" + (txtserishalphabet.Text + " " + txtserish.Text) + "',code_posti='" + txtcodeposti.Text + "',address='" + txtaddress.Text + "',jop='" + txtjob.Text + "',sex='" + (rbman.Checked == true ? "Man" : "Woman") + "',tabiyat='" + txttabeiat.Text + "',m_setting_san='" + txtsanadplace.Text + "',add_local_active='" + txtactiveplace.Text + "' where codemeli = " + txtcode.Text;
                db1.EditRecord(sql);
                sql = "update tbl_call SET phone = '" + txtphone.Text + "',mobile ='" + txtphone1.Text + "',phone_mahal ='" + txtphonemahalekasb.Text + "' where id_person_fk = " + txtcode.Text;
                db1.EditRecord(sql);
                sql = "update tbl_info_sand_zamen SET type_active='" + txtactivetype.Text + "',time_active='" + txtactivetime.Text + "',type_access='" + txtmojabeztype.Text + "',corpratin_sodor_access='" + txtsendmojavez.Text + "',chek_recive='" + txtvakhast.Text + "',shohrat_type_get='" + txtshohrat.Text + "',num_access='" + txtdate.Text + "',date_access='" + txtdate1.Text + "',end_date='" + txtexpire.Text + "',account_type='" + txtaccounttype.Text + "',openacc_date='" + txtdateeftetah.Text + "',account_num='" + txtaccountnumber1.Text + "',code_etebari='" + txtcodeetebari.Text + "' where fk_code='" + txtcode.Text + "'";
                db1.EditRecord(sql);
                panel1.Visible = true;
                lblres.Text = "اطلاعات با موفقیت ویرایش شد";
                chkedit.Checked = false;
            }
            else if (chkedit.Checked == true && idExist == false)
            {
                MessageBox.Show("اطلاعاتی برای ویرایش موجود نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmzamen_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            autocomplete(txtcode.Text);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (btnprint.Text == "عدم تعین ضامن")
            {
                if (sZamenNumber == "1")
                {
                    Zamens.Zamen1 = Zamens.Zamen2 = false;
                    Zamen.txtaccountnumber1 = Zamen.txtaccounttype = Zamen.txtactiveplace = Zamen.txtactivetime = Zamen.txtactivetype = Zamen.txtaddress = Zamen.txtbirthday = Zamen.txtbirthplace = Zamen.txtcode = Zamen.txtcodeetebari = Zamen.txtcodeposti = Zamen.txtdateeftetah = Zamen.txtexpire = Zamen.txtfamily = Zamen.txtfname = Zamen.txtjob = Zamen.txtmahalekasb = Zamen.txtmojabeztype = Zamen.txtname = Zamen.txtphone = Zamen.txtphone1 = Zamen.txtphonemahalekasb = Zamen.txtsanadplace = Zamen.txtsendmojavez = Zamen.txtserish = Zamen.txtsex = Zamen.txtshohrat = Zamen.txtshomaremojavez = Zamen.txtshsh = Zamen.txtssh = Zamen.txttabeiat = Zamen.txtvakhast = "";
                    Zamen2.txtaccountnumber1 = Zamen2.txtaccounttype = Zamen2.txtactiveplace = Zamen2.txtactivetime = Zamen2.txtactivetype = Zamen2.txtaddress = Zamen2.txtbirthday = Zamen2.txtbirthplace = Zamen2.txtcode = Zamen2.txtcodeetebari = Zamen2.txtcodeposti = Zamen2.txtdateeftetah = Zamen2.txtexpire = Zamen2.txtfamily = Zamen2.txtfname = Zamen2.txtjob = Zamen2.txtmahalekasb = Zamen2.txtmojabeztype = Zamen2.txtname = Zamen2.txtphone = Zamen2.txtphone1 = Zamen2.txtphonemahalekasb = Zamen2.txtsanadplace = Zamen2.txtsendmojavez = Zamen2.txtserish = Zamen2.txtsex = Zamen2.txtshohrat = Zamen2.txtshomaremojavez = Zamen2.txtshsh = Zamen2.txtssh = Zamen2.txttabeiat = Zamen2.txtvakhast = "";
                    Applicant.txtaccountnumber = Applicant.txtaccountnumber1 = Applicant.txtaccounttype = Applicant.txtactiveplace = Applicant.txtactivetime = Applicant.txtactivetype = Applicant.txtaddress = Applicant.txtbirthday = Applicant.txtbirthplace = Applicant.txtchequekarmozd = Applicant.txtchequeowner = Applicant.txtchequeprice1 = Applicant.txtcity = Applicant.txtcode = Applicant.txtcodeetebari = Applicant.txtcodeposti = Applicant.txtcodesenfi = Applicant.txtdateeftetah = Applicant.txtdategharardad = Applicant.txtexpire = Applicant.txtfamily = Applicant.txtfname = Applicant.txtgharardadnumber = Applicant.txtjob = Applicant.txtmahalekasb = Applicant.txtmojabeztype = Applicant.txtname = Applicant.txtnerkh = Applicant.txtpayprice = Applicant.txtphone = Applicant.txtphone1 = Applicant.txtplacepay = Applicant.txtpricecheque = Applicant.txtsanadplace = Applicant.txtsendmojavez = Applicant.txtserish = Applicant.txtsex = Applicant.txtshobe = Applicant.txtshohrat = Applicant.txtshomaremojavez = Applicant.txtshsh = Applicant.txtssh = Applicant.txttabeiat = Applicant.txttashilatnumber = Applicant.txttashilatprice = Applicant.txttime = Applicant.txtvakhast = "";
                    MessageBox.Show("ضامن شماره 1 و 2 از لیست ضامن خارج شدند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                    return;
                }
                else if (sZamenNumber == "2")
                {
                    Zamens.Zamen2 = false;
                    Zamen2.txtaccountnumber1 = Zamen2.txtaccounttype = Zamen2.txtactiveplace = Zamen2.txtactivetime = Zamen2.txtactivetype = Zamen2.txtaddress = Zamen2.txtbirthday = Zamen2.txtbirthplace = Zamen2.txtcode = Zamen2.txtcodeetebari = Zamen2.txtcodeposti = Zamen2.txtdateeftetah = Zamen2.txtexpire = Zamen2.txtfamily = Zamen2.txtfname = Zamen2.txtjob = Zamen2.txtmahalekasb = Zamen2.txtmojabeztype = Zamen2.txtname = Zamen2.txtphone = Zamen2.txtphone1 = Zamen2.txtphonemahalekasb = Zamen2.txtsanadplace = Zamen2.txtsendmojavez = Zamen2.txtserish = Zamen2.txtsex = Zamen2.txtshohrat = Zamen2.txtshomaremojavez = Zamen2.txtshsh = Zamen2.txtssh = Zamen2.txttabeiat = Zamen2.txtvakhast = "";
                    MessageBox.Show("ضامن شماره 2 از لیست ضامن خارج شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                    return;
                }
            }

            if (Zamens.Zamen1 == false)
            {
                Zamens.Zamen1 = true;
                fillDataZamen();
                MessageBox.Show("ضامن شماره 1 تعین شد\r\nشما میتوانید ضامن شماره 2 را نیز تعیین کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            else if (Zamens.Zamen1 = true && Zamens.Zamen2 == false)
            {
                MessageBox.Show("ضامن ها توسط شما تعیین شده است\r\nبرای چاپ گزارشات گزینه چاپ را در منوی اصلی انتخاب کنید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Zamens.Zamen2 = true;
                fillDataZamen();
                Dispose();
            }

        }

        public void autocomplete(string sId)
        {
            string id = sId;
            DataTable d1;
            DataTable d3;
            if (id == "")
            {
                db.ClearControls(this);
                return;
            }
            id = id.Replace("'", "");
            d1 = db1.ReportRecord("SELECT * FROM tbl_zamen WHERE codemeli = " + id);
            blnIsZamenInf = true;
            if (d1.Rows.Count == 0)
            {
                d1 = db1.ReportRecord("SELECT * FROM tbl_person WHERE codemeli = " + id);
                blnIsZamenInf = false;
            }
            if (d1 != null && d1.Rows.Count > 0)
            {
                idExist = true;
                txtcode.Text = id;
                txtname.Text = d1.Rows[0][1].ToString();
                txtfamily.Text = d1.Rows[0][2].ToString();
                txtfname.Text = d1.Rows[0][3].ToString();
                txtbirthday.Text = d1.Rows[0][4].ToString();
                txtbirthplace.Text = d1.Rows[0][5].ToString();
                txtshsh.Text = d1.Rows[0][6].ToString();
                txtssh.Text = d1.Rows[0][7].ToString();
                txtserish.Text = d1.Rows[0][8].ToString();
                txtcodeposti.Text = d1.Rows[0][9].ToString();
                txtaddress.Text = d1.Rows[0][10].ToString();
                txtjob.Text = d1.Rows[0][11].ToString();
                if (d1.Rows[0][12].ToString() == "Man")
                    rbman.Checked = true;
                else
                    rbwoman.Checked = true;
                txttabeiat.Text = d1.Rows[0][13].ToString();
                txtsanadplace.Text = d1.Rows[0][14].ToString();
                txtactiveplace.Text = d1.Rows[0][15].ToString();
                txtmahalekasb.Text = d1.Rows[0][16].ToString();
                /////////////////////////////////////////////////
                DataTable d2 = db1.ReportRecord("SELECT * FROM tbl_call WHERE id_person_fk = " + id);
                if (d2 != null && d2.Rows.Count > 0)
                {
                    txtphone.Text = d2.Rows[0][1].ToString();
                    txtphone1.Text = d2.Rows[0][2].ToString();
                    txtphonemahalekasb.Text = d2.Rows[0][3].ToString();
                }
                //////////////////////////////////////////////////////////////////
                if (blnIsZamenInf == true)
                    d3 = db1.ReportRecord("SELECT * FROM tbl_info_sand_zamen WHERE fk_code = '" + id + "'");
                else
                    d3 = db1.ReportRecord("SELECT type_active,time_active,type_access,corpratin_sodor_access,chek_recive,type_get,num_access,end_date," +
                        "date_access,ip_date,type_account,start_date,num_account,code_valid FROM tbl_info_sanad WHERE id_person_fk = '" + id + "'");

                if (d3 != null && d3.Rows.Count > 0)
                {
                    txtactivetype.Text = d3.Rows[0]["type_active"].ToString();
                    txtactivetime.Text = d3.Rows[0]["time_active"].ToString();
                    txtmojabeztype.Text = d3.Rows[0]["type_access"].ToString();
                    txtsendmojavez.Text = d3.Rows[0]["corpratin_sodor_access"].ToString();
                    txtvakhast.Text = d3.Rows[0]["chek_recive"].ToString();
                    txtshohrat.Text = d3.Rows[0]["type_get"].ToString();
                    txtdate1.Text = d3.Rows[0]["num_access"].ToString();
                    txtdate.Text = d3.Rows[0]["date_access"].ToString();
                    txtexpire.Text = d3.Rows[0]["end_date"].ToString();
                    txtaccounttype.Text = d3.Rows[0]["type_account"].ToString();
                    txtdateeftetah.Text = d3.Rows[0]["start_date"].ToString();
                    txtaccountnumber1.Text = d3.Rows[0]["num_account"].ToString();
                    txtcodeetebari.Text = d3.Rows[0]["code_valid"].ToString();
                }
            }
            else
            {
                idExist = false;
                db.ClearControls(this);
            }
        }

        private void chkedit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkedit.Checked == true)
                btnsave.Text = "ویرایش اطلاعات فعلی";
            else
                btnsave.Text = "ثبت اطلاعات";
        }

        private void frmzamen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
                btnsave_Click(null, null); 
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{tab}");
        }

        private void fillDataZamen()
        {
            if (Zamens.Zamen1 == true && Zamens.Zamen2 == false)
            {
                Zamen.txtcode = txtcode.Text;
                Zamen.txtname = txtname.Text;
                Zamen.txtfamily = txtfamily.Text;
                Zamen.txtfname = txtfname.Text;
                Zamen.txtbirthday = txtbirthday.Text;
                Zamen.txtbirthplace = txtbirthplace.Text;
                Zamen.txtshsh = txtshsh.Text;
                Zamen.txtssh = txtssh.Text;
                Zamen.txtserish = txtserish.Text;
                Zamen.txtcodeposti = txtcodeposti.Text;
                Zamen.txtaddress = txtaddress.Text;
                Zamen.txtjob = txtjob.Text;
                Zamen.txtsex = (rbman.Checked == true ? "آقا" : "خانم");
                Zamen.txttabeiat = txttabeiat.Text;
                Zamen.txtsanadplace = txtsanadplace.Text;
                Zamen.txtactiveplace = txtactiveplace.Text;
                Zamen.txtmahalekasb = txtmahalekasb.Text;
                Zamen.txtactivetype = txtactivetype.Text;
                Zamen.txtactivetime = txtactivetime.Text;
                //////////////////for sanad
                Zamen.txtmojabeztype = txtmojabeztype.Text;
                Zamen.txtsendmojavez = txtsendmojavez.Text;
                Zamen.txtvakhast = txtvakhast.Text;
                Zamen.txtshohrat = txtshohrat.Text;
                Zamen.txtshomaremojavez = txtdate1.Text;
                Zamen.txtdatemojavez = txtdate.Text;
                Zamen.txtexpire = txtexpire.Text;
                Zamen.txtaccounttype = txtaccounttype.Text;
                Zamen.txtdateeftetah = txtdateeftetah.Text;
                Zamen.txtaccountnumber1 = txtaccountnumber1.Text;
                Zamen.txtcodeetebari = txtcodeetebari.Text;
                Zamen.txtphone = txtphone.Text;
                Zamen.txtphone1 = txtphone1.Text;
                Zamen.txtphonemahalekasb = txtphonemahalekasb.Text;
            }
            else if (Zamens.Zamen2 == true)
            {
                Zamen2.txtcode = txtcode.Text;
                Zamen2.txtname = txtname.Text;
                Zamen2.txtfamily = txtfamily.Text;
                Zamen2.txtfname = txtfname.Text;
                Zamen2.txtbirthday = txtbirthday.Text;
                Zamen2.txtbirthplace = txtbirthplace.Text;
                Zamen2.txtshsh = txtshsh.Text;
                Zamen2.txtssh = txtssh.Text;
                Zamen2.txtserish = txtserish.Text;
                Zamen2.txtcodeposti = txtcodeposti.Text;
                Zamen2.txtaddress = txtaddress.Text;
                Zamen2.txtjob = txtjob.Text;
                Zamen2.txtsex = (rbman.Checked == true ? "آقا" : "خانم");
                Zamen2.txttabeiat = txttabeiat.Text;
                Zamen2.txtsanadplace = txtsanadplace.Text;
                Zamen2.txtactiveplace = txtactiveplace.Text;
                Zamen2.txtmahalekasb = txtmahalekasb.Text;
                Zamen2.txtactivetype = txtactivetype.Text;
                Zamen2.txtactivetime = txtactivetime.Text;
                //////////////////for sanad
                Zamen2.txtmojabeztype = txtmojabeztype.Text;
                Zamen2.txtsendmojavez = txtsendmojavez.Text;
                Zamen2.txtvakhast = txtvakhast.Text;
                Zamen2.txtshohrat = txtshohrat.Text;
                Zamen2.txtshomaremojavez = txtdate.Text;
                Zamen2.txtdatemojavez = txtdate1.Text;
                Zamen2.txtexpire = txtexpire.Text;
                Zamen2.txtaccounttype = txtaccounttype.Text;
                Zamen2.txtdateeftetah = txtdateeftetah.Text;
                Zamen2.txtaccountnumber1 = txtaccountnumber1.Text;
                Zamen2.txtcodeetebari = txtcodeetebari.Text;
                Zamen2.txtphone = txtphone.Text;
                Zamen2.txtphone1 = txtphone1.Text;
                Zamen2.txtphonemahalekasb = txtphonemahalekasb.Text;
            }
        }

        private void txtserishalphabet_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtactivetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtmojabeztype_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }
    }
}
