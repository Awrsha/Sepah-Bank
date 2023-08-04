using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bank_Reporter
{

    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|bank.mdb");
        private void lblinput_MouseHover(object sender, EventArgs e)
        {
            Label l1 = sender as Label;
            l1.ForeColor = Color.RoyalBlue;

        }

        private void lblinput_MouseLeave(object sender, EventArgs e)
        {
            Label l1 = sender as Label;
            l1.ForeColor = Color.Black;
        }

        private void lblinput_Click(object sender, EventArgs e)
        {
            frmperson frm1 = new frmperson();
            frm1.MdiParent = frmmdi.frmMain;
            frm1.Show();
        }

        private void lblzamen1_Click(object sender, EventArgs e)
        {

        }

        private void lblzamen2_Click(object sender, EventArgs e)
        {
            frmzamen frm1 = new frmzamen();
            frm1.MdiParent = frmmdi.frmMain;
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmperson frm1 = new frmperson();
            frm1.MdiParent = frmmdi.frmMain;
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Applicant.txtcode == null || Applicant.txtcode == "")
            {
                MessageBox.Show("لطفا مشخصات تسهیلات گیرنده را وارد سپس  تعین کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmzamen frm1 = new frmzamen();
            frm1.sZamendNum = "1";
            frm1.MdiParent = frmmdi.frmMain;
            frm1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Zamens.Zamen1 == true)
            {
                frmzamen frm1 = new frmzamen();
                frm1.MdiParent = frmmdi.frmMain;
                frm1.sZamendNum = "2";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("اطلاعات لازم برای  شماره 1 کامل نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmpreview fv1 = new frmpreview();
            fv1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zamens.Zamen1 = Zamens.Zamen2 = false;
            Zamen.txtaccountnumber1 = Zamen.txtaccounttype = Zamen.txtactiveplace = Zamen.txtactivetime = Zamen.txtactivetype = Zamen.txtaddress = Zamen.txtbirthday = Zamen.txtbirthplace = Zamen.txtcode = Zamen.txtcodeetebari = Zamen.txtcodeposti = Zamen.txtdateeftetah = Zamen.txtexpire = Zamen.txtfamily = Zamen.txtfname = Zamen.txtjob = Zamen.txtmahalekasb = Zamen.txtmojabeztype = Zamen.txtname = Zamen.txtphone = Zamen.txtphone1 = Zamen.txtphonemahalekasb = Zamen.txtsanadplace = Zamen.txtsendmojavez = Zamen.txtserish = Zamen.txtsex = Zamen.txtshohrat = Zamen.txtshomaremojavez = Zamen.txtshsh = Zamen.txtssh = Zamen.txttabeiat = Zamen.txtvakhast = "";
            Zamen2.txtaccountnumber1 = Zamen2.txtaccounttype = Zamen2.txtactiveplace = Zamen2.txtactivetime = Zamen2.txtactivetype = Zamen2.txtaddress = Zamen2.txtbirthday = Zamen2.txtbirthplace = Zamen2.txtcode = Zamen2.txtcodeetebari = Zamen2.txtcodeposti = Zamen2.txtdateeftetah = Zamen2.txtexpire = Zamen2.txtfamily = Zamen2.txtfname = Zamen2.txtjob = Zamen2.txtmahalekasb = Zamen2.txtmojabeztype = Zamen2.txtname = Zamen2.txtphone = Zamen2.txtphone1 = Zamen2.txtphonemahalekasb = Zamen2.txtsanadplace = Zamen2.txtsendmojavez = Zamen2.txtserish = Zamen2.txtsex = Zamen2.txtshohrat = Zamen2.txtshomaremojavez = Zamen2.txtshsh = Zamen2.txtssh = Zamen2.txttabeiat = Zamen2.txtvakhast = "";
            Applicant.txtaccountnumber = Applicant.txtaccountnumber1 = Applicant.txtaccounttype = Applicant.txtactiveplace = Applicant.txtactivetime = Applicant.txtactivetype = Applicant.txtaddress = Applicant.txtbirthday = Applicant.txtbirthplace = Applicant.txtchequekarmozd = Applicant.txtchequeowner = Applicant.txtchequeprice1 = Applicant.txtcity = Applicant.txtcode = Applicant.txtcodeetebari = Applicant.txtcodeposti = Applicant.txtcodesenfi = Applicant.txtdateeftetah = Applicant.txtdategharardad = Applicant.txtexpire = Applicant.txtfamily = Applicant.txtfname = Applicant.txtgharardadnumber = Applicant.txtjob = Applicant.txtmahalekasb = Applicant.txtmojabeztype = Applicant.txtname = Applicant.txtnerkh = Applicant.txtpayprice = Applicant.txtphone = Applicant.txtphone1 = Applicant.txtplacepay = Applicant.txtpricecheque = Applicant.txtsanadplace = Applicant.txtsendmojavez = Applicant.txtserish = Applicant.txtsex = Applicant.txtshobe = Applicant.txtshohrat = Applicant.txtshomaremojavez = Applicant.txtshsh = Applicant.txtssh = Applicant.txttabeiat = Applicant.txttashilatnumber = Applicant.txttashilatprice = Applicant.txttime = Applicant.txtvakhast = "";
            MessageBox.Show("تسهیلات جدید برای انجام ارائه تسهیلات انجام شد\r\nاین گزینه فقط برای پاک کردن اطلاعات قبلی که بارگذاری کرده اید است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Zamens.Zamen1 == false)
            {
                chkrezayatz1.Checked = false;
                chkvazemaliz1.Checked = false;
            }
            if (Zamens.Zamen2 == false)
            {
                chkrezayatz2.Checked = false;
                chkvazemaliz2.Checked = false;
            }
            if (Applicant.txtcode == "" || Applicant.txtcode == null)
            {
                MessageBox.Show("اطلاعات لازم برای وام گیرنده موجود نیست و برنامه قادر با ارائه چاپ نیست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                db db1 = new db();
                if (Zamens.Zamen1 == true)
                {
                    if (db1.countRecord("SELECT * FROM tbl_zamens WHERE sZamenID = '" + Zamen.txtcode + "'") == 0)
                        db1.InsertRecord("INSERT INTO tbl_zamens VALUES('" + Applicant.txtcode + "','" + Zamen.txtcode + "')");
                    if (Zamens.Zamen2 == true)
                        if (db1.countRecord("SELECT * FROM tbl_zamens WHERE sZamenID = '" + Zamen2.txtcode + "'") == 0)
                            db1.InsertRecord("INSERT INTO tbl_zamens VALUES('" + Applicant.txtcode + "','" + Zamen2.txtcode + "')");
                }
            }
            catch (Exception)
            {
            }
            printClient();
            MessageBox.Show("اطلاعات با موفقیت وارد اسناد شده و اماده چاپ هستند", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printClient()
        {
            modifyWord md1 = new modifyWord();
            string[] keys = new string[120];
            string[] vals = new string[120];
            string[] filename = new string[16];
            //client information
            keys[0] = "{کد ملی}";
            vals[0] = Applicant.txtcode;
            keys[1] = "{نام}";
            vals[1] = Applicant.txtname;
            keys[2] = "{فامیلی}";
            vals[2] = Applicant.txtfamily;
            keys[3] = "{تاریخ تولد}";
            vals[3] = modifyWord.Reverse(Applicant.txtbirthday);
            keys[4] = "{شماره شناسنامه}";
            vals[4] = Applicant.txtshsh;
            keys[5] = "{نام پدر}";
            vals[5] = Applicant.txtfname;
            keys[6] = "{کد پستی}";
            vals[6] = Applicant.txtcodeposti;
            keys[7] = "{تلفن}";
            vals[7] = Applicant.txtphone;
            keys[8] = "{موبایل}";
            vals[8] = Applicant.txtphone1;
            keys[9] = "{محل تولد}";
            vals[9] = Applicant.txtbirthplace;
            keys[10] = "{محل تنظیم سند}";
            vals[10] = Applicant.txtsanadplace;
            keys[11] = "{سریال شناسنامه}";
            vals[11] = Applicant.txtssh;
            keys[12] = "{سری شناسنامه}";
            vals[12] = Applicant.txtserish;
            keys[13] = "{جنسیت}";
            vals[13] = Applicant.txtsex;
            keys[14] = "{شهرستان}";
            vals[14] = Applicant.txtcity;
            keys[15] = "{آدرس}";
            vals[15] = Applicant.txtaddress;
            keys[16] = "{نشانی محل فعالیت}";
            vals[16] = Applicant.txtactiveplace;
            keys[17] = "{شغل}";
            vals[17] = Applicant.txtjob;
            keys[18] = "{نوع فعالیت}";
            vals[18] = Applicant.txtactivetype;
            keys[19] = "{مدت فعالیت}";
            vals[19] = Applicant.txtactivetime;
            keys[20] = "{نوع مجوز}";
            vals[20] = Applicant.txtmojabeztype;
            keys[21] = "{صادر کننده مجوز}";
            vals[21] = Applicant.txtsendmojavez;
            keys[22] = "{واخواست}";
            vals[22] = Applicant.txtvakhast;
            keys[23] = "{شهرت}";
            vals[23] = Applicant.txtshohrat;
            keys[24] = "{شماره مجوز}";
            vals[24] = Applicant.txtshomaremojavez;
            keys[25] = "{تاریخ صدور}";
            vals[25] = modifyWord.Reverse(Applicant.txtdatemojavez);
            keys[26] = "{انقضا}";
            vals[26] = modifyWord.Reverse(Applicant.txtexpire);
            keys[27] = "{تاریخ قرارداد}";
            vals[27] = modifyWord.Reverse(Applicant.txtdategharardad);
            keys[28] = "{نوع حساب}";
            vals[28] = Applicant.txtaccounttype;
            keys[29] = "{تاریخ افتتاح}";
            vals[29] = modifyWord.Reverse(Applicant.txtdateeftetah);
            keys[30] = "{شماره حساب}";
            vals[30] = Applicant.txtaccountnumber1;
            keys[31] = "{شماره قرارداد}";
            vals[31] = Applicant.txtgharardadnumber;
            keys[32] = "{شماره تسهیلات}";
            vals[32] = Applicant.txttashilatnumber;
            keys[33] = "{کد اعتباری}";
            vals[33] = Applicant.txtcodeetebari;
            keys[34] = "{کد صنفی}";
            vals[34] = Applicant.txtcodesenfi;
            keys[35] = "{مبلغ تسهیلات}";
            vals[35] = Applicant.txttashilatprice;
            keys[36] = "{نرخ}";
            vals[36] = Applicant.txtnerkh;
            keys[37] = "{مدت}";
            vals[37] = Applicant.txttime;
            keys[38] = "{مبلغ پرداخت}";
            vals[38] = Applicant.txtpayprice;
            keys[39] = "{تابعیت}";
            vals[39] = Applicant.txttabeiat;
            keys[40] = "{گیرنده چک}";
            vals[40] = Applicant.txtchequeowner;
            keys[41] = "{محل پرداخت چک}";
            vals[41] = Applicant.txtplacepay;
            keys[42] = "{شماره حساب چک}";
            vals[42] = Applicant.txtaccountnumber;
            keys[43] = "{مبلغ چک}";
            vals[43] = Applicant.txtpricecheque;
            keys[44] = "{مبلغ حروف}";
            vals[44] = Applicant.txtchequeprice1;
            keys[45] = "{شعبه}";
            vals[45] = Applicant.txtshobe;
            keys[46] = "{کارمزد}";
            vals[46] = Applicant.txtchequekarmozd;
            keys[47] = "{کل}";
            try
            {
                vals[47] = (Convert.ToDouble(Applicant.txtchequekarmozd) + Convert.ToDouble(Applicant.txtpricecheque)).ToString();
            }
            catch (Exception)
            {
                vals[47] = "0";
            }
            keys[48] = "{محل کسب}";
            vals[48] = Applicant.txtmahalekasb;
            ////////////////////////////
            ///////zamen 1
            keys[49] = "{کد ملی1}";
            vals[49] = Zamen.txtcode;
            keys[50] = "{نام1}";
            vals[50] = Zamen.txtname;
            keys[51] = "{فامیلی1}";
            vals[51] = Zamen.txtfamily;
            keys[52] = "{تاریخ تولد1}";
            vals[52] = modifyWord.Reverse(Zamen.txtbirthday);
            keys[53] = "{شماره شناسنامه1}";
            vals[53] = Zamen.txtshsh;
            keys[54] = "{نام پدر1}";
            vals[54] = Zamen.txtfname;
            keys[55] = "{کد پستی1}";
            vals[55] = Zamen.txtcodeposti;
            keys[56] = "{تلفن1}";
            vals[56] = Zamen.txtphone;
            keys[57] = "{موبایل1}";
            vals[57] = Zamen.txtphone1;
            keys[58] = "{محل تولد1}";
            vals[58] = Zamen.txtbirthplace;
            keys[59] = "{محل تنظیم سند1}";
            vals[59] = Zamen.txtsanadplace;
            keys[60] = "{سریال شناسنامه1}";
            vals[60] = Zamen.txtssh;
            keys[61] = "{سری شناسنامه1}";
            vals[61] = Zamen.txtserish;
            keys[62] = "{جنسیت1}";
            vals[62] = Zamen.txtsex;
            keys[63] = "{کد اعتباری1}";
            vals[63] = Zamen.txtcodeetebari;
            keys[64] = "{آدرس1}";
            vals[64] = Zamen.txtaddress;
            keys[65] = "{نشانی محل فعالیت1}";
            vals[65] = Zamen.txtactiveplace;
            keys[66] = "{شغل1}";
            vals[66] = Zamen.txtjob;
            keys[67] = "{نوع فعالیت1}";
            vals[67] = Zamen.txtactivetype;
            keys[68] = "{مدت فعالیت1}";
            vals[68] = Zamen.txtactivetime;
            keys[69] = "{نوع مجوز1}";
            vals[69] = Zamen.txtmojabeztype;
            keys[70] = "{صادر کننده مجوز1}";
            vals[70] = Zamen.txtsendmojavez;
            keys[71] = "{واخواست1}";
            vals[71] = Zamen.txtvakhast;
            keys[72] = "{شهرت1}";
            vals[72] = Zamen.txtshohrat;
            keys[73] = "{شماره مجوز1}";
            vals[73] = Zamen.txtshomaremojavez;
            keys[74] = "{تاریخ صدور1}";
            vals[74] = modifyWord.Reverse(Zamen.txtdatemojavez);
            keys[75] = "{تاریخ انقضا1}";
            vals[75] = modifyWord.Reverse(Zamen.txtexpire);
            keys[76] = "{تاریخ افتتاح1}";
            vals[76] = modifyWord.Reverse(Zamen.txtdateeftetah);
            keys[77] = "{شماره حساب1}";
            vals[77] = Zamen.txtaccountnumber1;
            keys[78] = "{تلفن محل کسب1}";
            vals[78] = Zamen.txtphonemahalekasb;
            keys[79] = "{نوع حساب1}";
            vals[79] = Zamen.txtaccounttype;

            //zamen 2
            keys[80] = "{کد ملی2}";
            vals[80] = Zamen2.txtcode;
            keys[81] = "{نام2}";
            vals[81] = Zamen2.txtname;
            keys[82] = "{فامیلی2}";
            vals[82] = Zamen2.txtfamily;
            keys[83] = "{تاریخ تولد2}";
            vals[83] = modifyWord.Reverse(Zamen2.txtbirthday);
            keys[84] = "{شماره شناسنامه2}";
            vals[84] = Zamen2.txtshsh;
            keys[85] = "{نام پدر2}";
            vals[85] = Zamen2.txtfname;
            keys[86] = "{کد پستی2}";
            vals[86] = Zamen2.txtcodeposti;
            keys[87] = "{تلفن2}";
            vals[87] = Zamen2.txtphone;
            keys[88] = "{موبایل2}";
            vals[88] = Zamen2.txtphone1;
            keys[89] = "{محل تولد2}";
            vals[89] = Zamen2.txtbirthplace;
            keys[90] = "{محل تنظیم سند2}";
            vals[90] = Zamen2.txtsanadplace;
            keys[91] = "{سریال شناسنامه2}";
            vals[91] = Zamen2.txtssh;
            keys[92] = "{سری شناسنامه2}";
            vals[92] = Zamen2.txtserish;
            keys[93] = "{جنسیت2}";
            vals[93] = Zamen2.txtsex;
            keys[94] = "{کد اعتباری2}";
            vals[94] = Zamen2.txtcodeetebari;
            keys[95] = "{آدرس2}";
            vals[95] = Zamen2.txtaddress;
            keys[96] = "{نشانی محل فعالیت2}";
            vals[96] = Zamen2.txtactiveplace;
            keys[97] = "{شغل2}";
            vals[97] = Zamen2.txtjob;
            keys[98] = "{نوع فعالیت2}";
            vals[98] = Zamen2.txtactivetype;
            keys[99] = "{مدت فعالیت2}";
            vals[99] = Zamen2.txtactivetime;
            keys[100] = "{نوع مجوز2}";
            vals[100] = Zamen2.txtmojabeztype;
            keys[101] = "{صادر کننده مجوز2}";
            vals[101] = Zamen2.txtsendmojavez;
            keys[102] = "{واخواست2}";
            vals[102] = Zamen2.txtvakhast;
            keys[103] = "{شهرت2}";
            vals[103] = Zamen2.txtshohrat;
            keys[104] = "{شماره مجوز2}";
            vals[104] = Zamen2.txtshomaremojavez;
            keys[105] = "{تاریخ صدور2}";
            vals[105] = modifyWord.Reverse(Zamen2.txtdatemojavez);
            keys[106] = "{تاریخ انقضا2}";
            vals[106] = modifyWord.Reverse(Zamen2.txtexpire);
            keys[107] = "{تاریخ افتتاح2}";
            vals[107] = modifyWord.Reverse(Zamen2.txtdateeftetah);
            keys[108] = "{شماره حساب2}";
            vals[108] = Zamen2.txtaccountnumber1;
            keys[109] = "{تلفن محل کسب2}";
            vals[109] = Zamen2.txtphonemahalekasb;
            keys[110] = "{نوع حساب2}";
            vals[110] = Zamen2.txtaccounttype;
            keys[111] = "{تاریخ}";
            vals[111] = modifyWord.Reverse(db.getDate());
            keys[112] = "{تابعیت}";
            vals[112] = Applicant.txttabeiat;
            keys[113] = "{تابعیت2}";
            vals[113] = Zamen2.txttabeiat;
            keys[114] = "{تابعیت1}";
            vals[114] = Zamen.txttabeiat;
            keys[115] = "{محل کسب1}";
            vals[115] = Zamen.txtmahalekasb;
            keys[116] = "{محل کسب2}";
            vals[116] = Zamen2.txtmahalekasb;
            keys[117] = "{محل کسب}";
            vals[117] = Applicant.txtmahalekasb;
            //filename document
            filename[0] = "";
            filename[1] = "";
            filename[2] = "bdt.doc"; //برگه درخواست تسهیلات

            if (chkcheque.Checked == true)
                filename[3] = "fdch.doc"; //فرم درخواست چک
            else
                filename[3] = ""; //فرم درخواست چک

            if (chkkomision.Checked == true)
                filename[4] = "fk.doc";  //فرم کمیسیون
            else
                filename[4] = "";  //فرم کمیسیون

            if (chkmotammam.Checked == true)
                filename[5] = "mgd.doc"; //متمم قرارداد داخلی
            else
                filename[5] = ""; //متمم قرارداد داخلی

            if (chkvazemali.Checked == true)
                filename[6] = "mvsclient.doc"; //محرمانه،وضع مالی و شهرت پرداخت شریک یا عامل
            else
                filename[6] = "";

            if (chkmotammam.Checked == true)
                filename[7] = "resclient.doc";  //فرم رضایت نامه
            else
                filename[7] = "";

            if (chktaahod.Checked == true)
                filename[8] = "t&p.doc"; //تعهدنامه
            else
                filename[8] = "";

            //Fill Zamen 1 Data
            if (chkrezayatz1.Checked == true)
                filename[9] = "resz1.doc";  //فرم رضایت نامه
            else
                filename[9] = "";

            if (chkvazemaliz1.Checked == true)
                filename[10] = "mvsz1.doc"; //محرمانه،وضع مالی و شهرت پرداخت
            else
                filename[10] = "";

            ////////////
            //Fill Zamen 2 Data
            if (Zamens.Zamen2 == true)
            {
                if (chkrezayatz2.Checked == true)
                    filename[12] = "resz2.doc";  //فرم رضایت نامه
                else
                    filename[12] = "";

                if (chkvazemaliz2.Checked == true)
                    filename[13] = "mvsz2.doc"; //محرمانه،وضع مالی و شهرت پرداخت
                else
                    filename[13] = "";
            }
            ////////////
            MessageBox.Show("پردازش اطلاعات و چاپ آن ها کمی طول میکشد\r\nو در صورت موفقیت پیامی اعلام میشود", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            md1.OpenWord(Application.StartupPath, filename, keys, vals);
            System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + "\\temp");
            SendKeys.Send("^A");
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void frmmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
