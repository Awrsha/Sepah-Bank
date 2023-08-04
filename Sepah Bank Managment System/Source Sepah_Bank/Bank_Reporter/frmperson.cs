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
    public partial class frmperson : Form
    {
        db db1 = new db();
        string tempBtnText;
        bool idExist;
        public frmperson()
        {
            InitializeComponent();
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
            txtshobe.Text = db1.getValueRecord("SELECT sBranchName FROM tbl_branch");
            db1.GetSourceText("SELECT codemeli FROM tbl_person", txtcode, "codemeli");
            db1.GetSourceText("SELECT fname FROM tbl_person", txtname, "fname");
            db1.GetSourceText("SELECT lname FROM tbl_person", txtfamily, "lname");
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
        private void button1_Click(object sender, EventArgs e)
        {
            Dispose(); 
        }

        private void frmperson_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnsave_Click_1(object sender, EventArgs e)
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
                sql = "INSERT INTO tbl_person VALUES('" + txtcode.Text + "','" + txtname.Text + "','" + txtfamily.Text + "','" + txtfname.Text + "','" + txtbirthday.Text + "','" + txtbirthplace.Text + "','" + txtshsh.Text + "','" + (txtssh.Text) + "','" + (txtserishalphabet.Text + " " + txtserish.Text) + "','" + txtcodeposti.Text + "','" + txtaddress.Text + "','" + txtjob.Text + "','" + (rbman.Checked == true ? "Man" : "Woman") + "','" + txttabeiat.Text + "','" + txtsanadplace.Text + "','" + txtactiveplace.Text + "','" + txtmahalekasb.Text + "')";
                db1.InsertRecord(sql);
                sql = "INSERT INTO tbl_call(phone,mobile,phone_mahal,id_person_fk) VALUES('" + txtphone.Text + "','" + txtphone1.Text + "','','" + txtcode.Text + "')";
                db1.InsertRecord(sql);
                sql = "INSERT INTO tbl_info_sanad VALUES('" + txtactivetype.Text + "','" + txtactivetime.Text + "','" + txtmojabeztype.Text + "','" + txtsendmojavez.Text + "','" + txtvakhast.Text + "','" + txtshohrat.Text + "','" + txtshomaremojavez.Text + "','" + txtdate.Text + "','" + txtexpire.Text + "','" + txtdategharardad.Text + "','" + txtaccounttype.Text + "','" + txtdateeftetah.Text + "','" + txtaccountnumber1.Text + "','" + txtgharardadnumber.Text + "','" + txttashilatnumber.Text + "','" + txtcodeetebari.Text + "','" + txtcodesenfi.Text + "','" + txttashilatprice.Text + "','" + txtnerkh.Text + "','" + txttime.Text + "','" + txtpayprice.Text + "','" + txtcode.Text + "')";
                db1.InsertRecord(sql);
                sql = "INSERT INTO tbl_chek(fullname_reccive_chek, id_accuont_factor, m_pardakht_hc_bank, price_chek, price_chek_alfabet, branch, city, carmozd_chek, id_person_fk) VALUES('" + txtchequeowner.Text + "','" + txtaccountnumber.Text + "','" + txtplacepay.Text + "','" + txtpricecheque.Text + "','" + txtchequeprice1.Text + "','" + txtshobe.Text + "','" + txtcity.Text + "','" + txtchequekarmozd.Text + "','" + txtcode.Text + "')";
                db1.InsertRecord(sql);
                Applicant.txtcode = txtcode.Text;
                panel1.Visible = true;
                lblres.Text = "اطلاعات با موفقیت ثبت شد";
                btnsave.Text = "ثبت اطلاعات";
            }
            else if (chkedit.Checked == true && idExist == true)
            {
                sql = "update tbl_person SET fname ='" + txtname.Text + "',lname ='" + txtfamily.Text + "',fathername ='" + txtfname.Text + "',b_date='" + txtbirthday.Text + "',m_date='" + txtbirthplace.Text + "',id_shen='" + txtshsh.Text + "',serial_shen='" + txtssh.Text + "',seri_shen='" + (txtserishalphabet.Text + " " + txtserish.Text) + "',code_posti='" + txtcodeposti.Text + "',address='" + txtaddress.Text + "',jop='" + txtjob.Text + "',sex='" + (rbman.Checked == true ? "Man" : "Woman") + "',tabiyat='" + txttabeiat.Text + "',m_setting_sanad='" + txtsanadplace.Text + "',add_local_active='" + txtactiveplace.Text + "',mahalekasb='" + txtmahalekasb.Text + "' where codemeli = " + txtcode.Text;
                db1.EditRecord(sql);
                sql = "update tbl_call SET phone = '" + txtphone.Text + "',mobile ='" + txtphone1.Text + "',phone_mahal ='' where id_person_fk = " + txtcode.Text;
                db1.EditRecord(sql);
                sql = "update tbl_info_sanad SET type_active='" + txtactivetype.Text + "',time_active='" + txtactivetime.Text + "',type_access='" + txtmojabeztype.Text + "',corpratin_sodor_access='" + txtsendmojavez.Text + "',chek_recive='" + txtvakhast.Text + "',type_get='" + txtshohrat.Text + "',num_access='" + txtshomaremojavez.Text + "',date_access='" + txtdate.Text + "',end_date='" + txtexpire.Text + "',ip_date='" + txtdategharardad.Text + "',type_account='" + txtaccounttype.Text + "',start_date='" + txtdateeftetah.Text + "',num_account='" + txtaccountnumber1.Text + "',ip_num='" + txtgharardadnumber.Text + "',tashilat_num='" + txttashilatnumber.Text + "',code_valid='" + txtcodeetebari.Text + "',code_bisines='" + txtcodesenfi.Text + "',tashilat_price='" + txttashilatprice.Text + "',nerkh_to100='" + txtnerkh.Text + "',intime='" + txttime.Text + "',price_varizi='" + txtpayprice.Text + "' where id_person_fk='" + txtcode.Text + "'";
                db1.EditRecord(sql);
                sql = "update tbl_chek SET fullname_reccive_chek='" + txtchequeowner.Text + "', id_accuont_factor='" + txtaccountnumber.Text + "', m_pardakht_hc_bank='" + txtplacepay.Text + "', price_chek='" + txtpricecheque.Text + "', price_chek_alfabet='" + txtchequeprice1.Text + "', branch='" + txtshobe.Text + "', city='" + txtcity.Text + "', carmozd_chek='" + txtchequekarmozd.Text + "' where id_person_fk ='" + txtcode.Text + "'";
                db1.InsertRecord(sql);
                panel1.Visible = true;
                lblres.Text = "اطلاعات با موفقیت ویرایش شد";
                btnsave.Text = "ثبت اطلاعات";
                chkedit.Checked = false;
            }
            else if (chkedit.Checked == true && idExist == false)
            {
                MessageBox.Show("اطلاعاتی برای ویرایش موجود نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            string id = txtcode.Text;
            panel1.Visible = false;
            if (id == "")
            {
                db.ClearControls(this);
                return;
                button2.Visible = false;
            }
            id = id.Replace("'", "");
            DataTable d1 = db1.ReportRecord("SELECT * FROM tbl_person WHERE codemeli = " + id);
            if (d1 != null && d1.Rows.Count > 0)
            {
                idExist = true;
                button2.Visible = true;
                Applicant.txtcode = id;
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
                }
                //////////////////////////////////////////////////////////////////
                DataTable d3 = db1.ReportRecord("SELECT * FROM tbl_info_sanad WHERE id_person_fk = '" + id + "'");
                if (d3 != null && d3.Rows.Count > 0)
                {
                    txtactivetype.Text = d3.Rows[0][0].ToString();
                    txtactivetime.Text = d3.Rows[0][1].ToString();
                    txtmojabeztype.Text = d3.Rows[0][2].ToString();
                    txtsendmojavez.Text = d3.Rows[0][3].ToString();
                    txtvakhast.Text = d3.Rows[0][4].ToString();
                    txtshohrat.Text = d3.Rows[0][5].ToString();
                    txtshomaremojavez.Text = d3.Rows[0][6].ToString();
                    txtdate.Text = d3.Rows[0][7].ToString();
                    txtexpire.Text = d3.Rows[0][8].ToString();
                    txtdategharardad.Text = d3.Rows[0][9].ToString();
                    txtaccounttype.Text = d3.Rows[0][10].ToString();
                    txtdateeftetah.Text = d3.Rows[0][11].ToString();
                    txtaccountnumber1.Text = d3.Rows[0][12].ToString();
                    txtgharardadnumber.Text = d3.Rows[0][13].ToString();
                    txttashilatnumber.Text = d3.Rows[0][14].ToString();
                    txtcodeetebari.Text = d3.Rows[0][15].ToString();
                    txtcodesenfi.Text = d3.Rows[0][16].ToString();
                    txttashilatprice.Text = d3.Rows[0][17].ToString();
                    txtnerkh.Text = d3.Rows[0][18].ToString();
                    txttime.Text = d3.Rows[0][19].ToString();
                    txtpayprice.Text = d3.Rows[0][20].ToString();
                }
                //////////////////////////////////////////////////////////////////
                DataTable d4 = db1.ReportRecord("SELECT * FROM tbl_chek WHERE id_person_fk = '" + id + "'");
                if (d4 != null && d4.Rows.Count > 0)
                {
                    txtchequeowner.Text = d4.Rows[0][1].ToString();
                    txtaccountnumber.Text = d4.Rows[0][2].ToString();
                    txtplacepay.Text = d4.Rows[0][3].ToString();
                    txtpricecheque.Text = d4.Rows[0][4].ToString();
                    txtchequeprice1.Text = d4.Rows[0][5].ToString();
                    txtshobe.Text = d4.Rows[0][6].ToString();
                    txtcity.Text = d4.Rows[0][7].ToString();
                    txtchequekarmozd.Text = d4.Rows[0][8].ToString();
                }
            }
            else
            {
                idExist = false;
                Applicant.txtcode = "";
                button2.Visible = false;
                db.ClearControls(this);
            }
        }

        private void txtpricecheque_TextChanged(object sender, EventArgs e)
        {
            txtchequeprice1.Text = Persian_Number_To_String.GET_Number_To_PersianString(txtpricecheque.Text.Replace(",",""));
        }

        private void chkedit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkedit.Checked == true)
                btnsave.Text = "ویرایش اطلاعات فعلی";
            else
                btnsave.Text = "ثبت اطلاعات";
        }

        private void frmperson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                btnsave_Click_1(null, null);
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{tab}");

        }

        private void frmperson_SizeChanged(object sender, EventArgs e)
        {
           
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            frmzamen f1 = new frmzamen();
            f1.MdiParent = frmmdi.frmMain;
            f1.sZamendNum = "1";
            ////define data
            Applicant.txtname = txtname.Text;
            Applicant.txtfamily = txtfamily.Text;
            Applicant.txtfname = txtfname.Text;
            Applicant.txtbirthday = txtbirthday.Text;
            Applicant.txtbirthplace = txtbirthplace.Text;
            Applicant.txtshsh = txtshsh.Text;
            Applicant.txtssh = txtssh.Text;
            Applicant.txtserish = txtserish.Text;
            Applicant.txtcodeposti = txtcodeposti.Text;
            Applicant.txtaddress = txtaddress.Text;
            Applicant.txtjob = txtjob.Text;
            Applicant.txtsex = (rbman.Checked == true ? "آقا" : "خانم");
            Applicant.txttabeiat = txttabeiat.Text;
            Applicant.txtsanadplace = txtsanadplace.Text;
            Applicant.txtactiveplace = txtactiveplace.Text;
            Applicant.txtmahalekasb = txtmahalekasb.Text;
            Applicant.txtactivetype = txtactivetype.Text;
            Applicant.txtactivetime = txtactivetime.Text;
            //////////////////for sanad
            Applicant.txtmojabeztype = txtmojabeztype.Text;
            Applicant.txtsendmojavez = txtsendmojavez.Text;
            Applicant.txtvakhast = txtvakhast.Text;
            Applicant.txtshohrat = txtshohrat.Text;
            Applicant.txtshomaremojavez = txtshomaremojavez.Text;
            Applicant.txtdatemojavez = txtdate.Text;
            Applicant.txtexpire = txtexpire.Text;
            Applicant.txtdategharardad = txtdategharardad.Text;
            Applicant.txtaccounttype = txtaccounttype.Text;
            Applicant.txtdateeftetah = txtdateeftetah.Text;
            Applicant.txtaccountnumber1 = txtaccountnumber1.Text;
            Applicant.txtgharardadnumber = txtgharardadnumber.Text;
            Applicant.txttashilatnumber = txttashilatnumber.Text;
            Applicant.txtcodeetebari = txtcodeetebari.Text;
            Applicant.txtcodesenfi = txtcodesenfi.Text;
            Applicant.txttashilatprice = txttashilatprice.Text;
            Applicant.txtnerkh = txtnerkh.Text;
            Applicant.txttime = txttime.Text;
            Applicant.txtpayprice = txtpayprice.Text;
            Applicant.txtphone = txtphone.Text;
            Applicant.txtphone1 = txtphone1.Text;
            //////for cheque
            Applicant.txtchequeowner = txtchequeowner.Text;
            Applicant.txtaccountnumber = txtaccountnumber.Text;
            Applicant.txtplacepay = txtplacepay.Text;
            Applicant.txtpricecheque = txtpricecheque.Text;
            Applicant.txtchequeprice1 = txtchequeprice1.Text;
            Applicant.txtshobe = txtshobe.Text;
            Applicant.txtcity = txtcity.Text;
            Applicant.txtchequekarmozd = txtchequekarmozd.Text;
            Dispose();
            f1.Show();
        }

        private void txtbirthplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtserishalphabet_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtactivetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.OnlyPersion(e);
        }

        private void txtpricecheque_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                ClassNumbericToLetter numberic = new ClassNumbericToLetter();
                txtchequeprice1.Text = numberic.NumbericToLetters(txtpricecheque.Text.Replace(",", "").Trim());
            }
            catch(Exception)
            {

            }
        }
    }
}
