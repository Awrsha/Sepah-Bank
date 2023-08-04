using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System .Data .OleDb;
using System.Drawing;
using System.Windows.Forms;
using System .IO;
using System .Globalization;
namespace Bank_Reporter
{
    class db
    {
        #region Variable

        private OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\bank.mdb");
        private OleDbCommand sc1 = new OleDbCommand();
        private OleDbDataAdapter sda1;
        private DataSet ds1 = new DataSet();
        private DataView dv1 = new DataView();
        private DataTable dt1 = new DataTable();
        private OleDbCommandBuilder scb1 = new OleDbCommandBuilder();
        public static string database;
        public static frmmdi frmMdi;
        public static ToolStripStatusLabel lblError;
        public static string Skin1;
        public static string sCurrentDate;
        #endregion

        #region Common Procedure
        public static void ChangeLang()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("FA"));
        }
        public static string getDate()
        {
            PersianCalendar date = new PersianCalendar();
            StringBuilder str1 = new StringBuilder();
            str1.Append(date.GetYear(DateTime.Now).ToString("0000"));
            str1.Append("/");
            str1.Append(date.GetMonth(DateTime.Now).ToString("00"));
            str1.Append("/");
            str1.Append(date.GetDayOfMonth(DateTime.Now).ToString("00"));
            return str1.ToString();
        }
        #endregion

        public OleDbConnection GetConnection()
        {
            try
            {
                //OleDbConnection OleDb1 = new OleDbConnection ( "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\bank.mdb;User Id=Admin;Jet OLEDB:Database Password=;" );
                connection.Open();

                return connection;
            }
            catch (OleDbException)
            {

            }
            catch (FormatException)
            {

            }
            return null;
        }
        public int countRecord(string sql)
        {
            try
            {
                int ctn;
                sc1.CommandText = sql;
                sc1.CommandType = CommandType.Text;
                sc1.Connection = GetConnection();
                ctn = (int)sc1.ExecuteScalar();
                connection.Close();
                return ctn;
            }
            catch (InvalidOperationException)
            {
                connection.Close();
            }
            catch (OleDbException)
            {
                connection.Close();
            }
            catch (FormatException)
            {
                connection.Close();
            }
            connection.Close();
            return 0;
        }
        public string getValueRecord(string sql)
        {
            try
            {
                string s1;
                sc1.CommandText = sql;
                sc1.CommandType = CommandType.Text;
                sc1.Connection = GetConnection();
                s1 = sc1.ExecuteScalar().ToString();
                connection.Close();

                return s1;
            }
            catch (InvalidOperationException)
            {
                connection.Close();

            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return "";
        }
        public int ExistRecord(string Sql)
        {
            try
            {
                sc1.CommandText = Sql;
                sc1.CommandType = CommandType.Text;
                sc1.Connection = GetConnection();
                OleDbDataReader sdr1 = sc1.ExecuteReader();
                sdr1.Read();
                if (sdr1.GetValue(0).ToString() != "")
                {
                    connection.Close();

                    return 1;
                }
            }
            catch (InvalidOperationException)
            {
                connection.Close();

            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return 0;
        }

        public int InsertRecord(string Sql)
        {

            sc1.CommandText = Sql;
            sc1.CommandType = CommandType.Text;
            sc1.Connection = GetConnection();
            try
            {
                if (sc1.ExecuteNonQuery() == 1)
                {
                    connection.Close();

                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return 0;
        }

        public int DeleteRecord(string Sql)
        {
            int i;
            try
            {
                sc1.CommandText = Sql;
                sc1.CommandType = CommandType.Text;
                sc1.Connection = GetConnection();
                i = sc1.ExecuteNonQuery();
                if (i > 0)
                {
                    connection.Close();

                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return 0;
        }

        public int EditRecord(string Sql)
        {
            int i;
            try
            {
                sc1.CommandText = Sql;
                sc1.CommandType = CommandType.Text;
                sc1.Connection = GetConnection();
                i = sc1.ExecuteNonQuery();
                if (i == 1)
                {

                    connection.Close();
                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return 0;
        }

        public DataView SearchRecord(string Sql)
        {
            try
            {
                DataView d;
                sda1 = new OleDbDataAdapter(Sql, GetConnection());
                sda1.Fill(ds1);
                d = new DataView(ds1.Tables[0]);

                connection.Close();
                return d;
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return null;
        }
        public static void ConvertColumnToCurreny(DataGridView GridView1, int column)
        {
            for (int i = 0; i < GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[column].Value = Number2Curreny(GridView1.Rows[i].Cells[column].Value.ToString()).ToString();
            }
        }
        public DataTable ReportRecord(string Sql)
        {
            try
            {
                DataTable tb1 = new DataTable();
                sda1 = new OleDbDataAdapter(Sql, GetConnection());
                sda1.Fill(tb1);
                connection.Close();

                return tb1;
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
            connection.Close();
            return null;
        }

        public void GetSourceText(string Sql, TextBox t1, string columname)
        {
            try
            {
                DataTable d1 = ReportRecord(Sql);
                t1.AutoCompleteMode = AutoCompleteMode.Suggest;
                t1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                foreach (DataRow r1 in d1.Rows)
                    t1.AutoCompleteCustomSource.Add(r1[columname].ToString());
                connection.Close();

            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
        }
        public void GetSourceCombo(string Sql, string columname, ComboBox cmb1)
        {
            try
            {
                StringBuilder s1 = new StringBuilder();
                DataTable d1 = ReportRecord(Sql);
                foreach (DataRow r1 in d1.Rows)
                    cmb1.Items.Add(r1[columname].ToString());

                connection.Close();
            }
            catch (OleDbException)
            {
                connection.Close();

            }
            catch (FormatException)
            {
                connection.Close();

            }
        }

        public static void SetError(out bool stat, ErrorProvider ep1, params Control[] t1)
        {
            foreach (Control t2 in t1)
                if (t2.Text == "")
                {
                    ep1.SetError(t2, "لطفا گزینه ها را درست وارد کنید");
                    t2.BackColor = Color.FromArgb(237, 59, 59);
                    stat = false;
                    return;
                }
                else
                {
                    ep1.Clear();
                    t2.BackColor = Color.White;
                }
            stat = true;
            return;
        }

        public static void ClearControls(Control _parent)
        {
            if (!_parent.HasChildren)
                if (_parent is TextBox && _parent.Name != "txtcode" || _parent is MaskedTextBox)
                    _parent.Text = "";
            foreach (Control ct in _parent.Controls)
                ClearControls(ct);
        }

        public int Getbackup(string databasename, string path)
        {
            try
            {
                if (File.Exists(path + "\\bank.mdb"))
                {
                    File.Delete(path + "\\bank.mdb");
                }
                File.Copy(Application.StartupPath + "\\bank.mdb", path + "\\bank.mdb");
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static void OnlyPersion(KeyPressEventArgs e)
        {
            //با قطعه کد زير کاراکتر هاي انگليسي به صورت خودکار تبديل به فارسي ميشود
            if (e.KeyChar == '[') e.KeyChar = 'ج';
            if (e.KeyChar == ']') e.KeyChar = 'چ';
            if (e.KeyChar == 'C') e.KeyChar = 'ژ';
            if (e.KeyChar == '\'') e.KeyChar = 'گ';
            if (e.KeyChar == ';') e.KeyChar = 'ک';
            if (e.KeyChar == ',') e.KeyChar = 'و';
            if (e.KeyChar == '`') e.KeyChar = 'پ';
            if (e.KeyChar == '-') e.KeyChar = '-';
            if (e.KeyChar == '/') e.KeyChar = '/';
            int i = 0;
            char[] en = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ';', '\'', '[', ']', '`', ',' };
            char[] fa = { 'ش', 'ذ', 'ز', 'ی', 'ث', 'ب', 'ل', 'ا', 'ه', 'ت', 'ن', 'م', 'ئ', 'د', 'خ', 'ح', 'ض', 'ق', 'س', 'ف', 'ع', 'ر', 'ص', 'ط', 'غ', 'ظ', 'ک', 'گ', 'ج', 'چ', 'پ', 'و' };
            foreach (char temp in en)
            {
                if (char.ToLower(temp) == char.ToLower(e.KeyChar)) e.KeyChar = fa[i];
                ++i;
            }
        }
        public static string getPersianDate()
        {
            PersianCalendar date = new PersianCalendar();
            StringBuilder str1 = new StringBuilder();
            str1.Append(date.GetYear(DateTime.Now).ToString("0000"));
            str1.Append("/");
            str1.Append(date.GetMonth(DateTime.Now).ToString("00"));
            str1.Append("/");
            str1.Append(date.GetDayOfMonth(DateTime.Now).ToString("00"));
            return str1.ToString();
        }
        public static string Number2Curreny(string sNumber)
        {
            for (int i = sNumber.Length; i >= 0; i -= 3)
            {
                if (i == sNumber.Length)
                    continue;
                sNumber = sNumber.Insert(i, ",");
            }
            if (sNumber.StartsWith(","))
                return sNumber.Remove(0, 1);
            else
                return sNumber;
        }
    }
}