using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Aspose.Words;
namespace Bank_Reporter
{
    class modifyWord
    {

        public void OpenWord(string myPath, string[] sPath, string[] keys, string[] values)
        {
            try
            {
                Document doc1 ;
                DocumentBuilder db1;
                string st1, st2;
                string t1;
                System.Drawing.Printing.PrinterSettings printername;
                //printername = definePrinter();
                ReplaceHelper helper;
                foreach (string sfilename in sPath)
                {
                    string filename = myPath + "\\myfile\\" + sfilename;
                    //  if temp.doc available
                    if (File.Exists((string)filename))
                    {
                        if (Directory.Exists(Application.StartupPath + "\\temp"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\temp");
                        }
                        File.Copy(filename.ToString(), myPath + "\\temp\\" + sfilename, true);
                        t1 = myPath + "\\temp\\" + sfilename;
                        doc1 = new Document(t1);
                        helper = new ReplaceHelper(doc1);
                        db1 = new DocumentBuilder(doc1);
                        for (int i = 0; i <= keys.Length - 1; i++)
                        {
                            st1 = keys[i];
                            st2 = values[i];
                            if (st1 == null) continue ;
                            if (st2 == null) st2 = "";
                            helper.Replace(st1, st2);
                        }
                        doc1.Save(t1);
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("لطفا برنامه افیس ورد را نصب کنید\r\n" + e1.Message ,  "Internal Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KillProcess("WINWORD");
        }
        public static string Reverse(string s)
        {
            string[] s1 = new string[3];
            string s2;
            if (s == null) return "-";
            try
            {
                s1 = s.Split('/');
                s2 = s1[2] + "/" + s1[1] + "/" + s1[0];
                return s2;
            }
            catch(Exception)
            {
                return s;
            }
        }
        private void PrintDoc(string path, string printername)
        {
            ProcessStartInfo info = new ProcessStartInfo(path);
            info.Verb = "PrintTo";
            info.Arguments = printername;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }
        private System.Drawing.Printing.PrinterSettings definePrinter()
        {
            PrintDialog pd1 = new PrintDialog();
            pd1.ShowDialog();
            return pd1.PrinterSettings;
        }

        public static bool KillProcess(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }
    }
}

