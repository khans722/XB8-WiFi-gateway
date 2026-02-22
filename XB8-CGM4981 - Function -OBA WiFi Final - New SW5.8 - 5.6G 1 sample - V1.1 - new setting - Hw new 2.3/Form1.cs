using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CmdApp;
using System.IO.Ports;
using sAudio;
using System.IO;
using Gecko.DOM;
using System.Net.Sockets;
using System.Net;
using Gecko;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Newtonsoft.Json;
using Renci.SshNet;


namespace Automatic
{
    public partial class ProForm : Form
    {
        public ProForm()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(Application.StartupPath + "\\xulrunner");
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string[] ports = SerialPort.GetPortNames();
          

        }
        static ASCIIEncoding encoding = new ASCIIEncoding();
        AutoClickPosition.Autoclick autoClickPosition = new AutoClickPosition.Autoclick();
        msnmp cable = new msnmp();
        cmdApp cmd = new cmdApp();
        Thread thVoip = null;
        Thread thMutiple1 = null;
        Thread thMutiple2 = null;
        Thread thMutiple_new = null;
        Thread thMutiple3 = null;
        Thread thMutiple4 = null;
        Thread thMutiple5 = null;
        Thread thMutiple6 = null;
        Thread thMutiple7 = null;
        Thread thMutiple8 = null;
        Thread thMutiple11 = null;
        string sModem = "COM";
        string CoutCH2G = "1234567891011";
        string CoutCH5G = "3640444852566064100104108112116120124128132136140144149153157161165";
        string CoutCH6G = "53769101133165197";

        string Result = "";
        string Err_code = "";
        string WPSPairingfunction = "";
        double TotalTest_Time = 0.00;

        public class jsonNian
        {
            public string modelName { get; set; }
            public string route { get; set; }
            public string station { get; set; }
            public string sn { get; set; }
            public string result { get; set; }
            public string errorCode { get; set; }
            public double totalTime { get; set; }
            public List<functionTime> FunctionTime { get; set; }
            public List<testData> TestData { get; set; }
        }
        public class testData
        {
            public string itemName { get; set; }
            public double itemValue { get; set; }
        }
        public class functionTime
        {
            public string name { get; set; }
            public double testTime { get; set; }
        }

        SerialPort serial = new SerialPort();
        SerialPort serialsfc = new SerialPort();
        //SerialPort serialThread = new SerialPort();
        Socket sck;
        Common cmn = new Common();
        sAudio.Voip voip = new Voip();
        private List<double> value = new List<double>();
        private GeckoWebBrowser brower;
        private Telnet.TelnetClient telnet = new Telnet.TelnetClient();
        string InfoIP = "10.0.0.1";
        private const int volum_up = 0xA0000;
        private const int volum_down = 0x90000;
        private const int appcomand = 0x319;
        [DllImport("User32.dll")]

        public static extern IntPtr SendMessageW(IntPtr Wnd, int Msg, IntPtr Wpram, IntPtr Ipram);
        private int fails;
        private int pass;
        private int countTimeTest;
        private int pingCmts;
        private double values = 0;
        bool Dklognewpassword = false;
        bool thStattus1 = false;
        bool config2G = false;
        bool config5G = false;
        bool config6G = false;
        bool Item2G = true;
        bool Item5G = true;
        bool Item6G = true;
        bool nk = false;
        bool bug = true;
        bool suscessfulsetingWifi5G = false;
        bool suscessfulsetingWifi6G = false;
        bool Pass2GCH1 = false;
        bool Pass2GCH6 = false;
        bool Pass2GCH11 = false;
        bool Pass5GCH36 = false;
        bool Pass5GCH48 = false;
        bool Pass5GCH153 = false;
        string pathfile1 = Directory.GetCurrentDirectory();
        string errs;
        string linkWeb = "http://10.0.0.1/";
        string linkWeb1 = "http://10.0.0.1/at_a_glance.jst";
        string linkWebChangePassword = "http://10.0.0.1/admin_password_change.jst";
        string linkWebNetwork = "http://10.0.0.1/wireless_network_configuration.jst";
        string linkReset = "http://10.0.0.1/restore_reboot.jst";
        string linkSW = "http://10.0.0.1/software.jst";
        string linkInfor = "http://10.0.0.1/network_setup.jst";
        string linkwifi = "http://10.0.0.1/wireless_network_configuration.jst";
        string linkwifi2G = "http://10.0.0.1/wireless_network_configuration_edit.jst?id=1";
        string linkwifi5G = "http://10.0.0.1/wireless_network_configuration_edit.jst?id=2";
        string linkwifi6G = "http://10.0.0.1/wireless_network_configuration_edit.jst?id=17";
        string DocumentTitleWEBSSID1 = "XFINITY Smart Internet";
        string DocumentTitleWEBSSID2 = "Login";
        string DocumentTitleChangPassword = "Change Password";
        string DocumentTitleInfor = "Gateway > Connection > XFINITY Network";
        string DocumentTitleWifi = "Gateway > Connection";
        string DocumentTitleRST = "Troubleshooting > Reset / Restore Gateway";
        string HW = "2.0";
        string boot = "S1TC-3.81.21.97"; //97
        string SW = "CGM4981COM_4.14p6s4_PROD_sey";
        int SNlength = 18;
        double SpecWifi2G = 100;
        double SpecWifi5G = 500;
        double SpecWifi6G = 500;

        string pathsaveftp = "";
        string pathsaveftp1 = "";
        string pathsaveftp2 = "";
        string snvalue;
        bool SFC_flag = false;

        string sComSFC = "";
        string OP = "";
        string Nian = "";
        string ModelnameFile = "";
        GeckoInputElement geckinputelement;
        double DUTalive = 0.0;
        double Loginweb = 0.0;
        double TimeWifi2GCH1 = 0.0;
        double TimeWifi2GCH6 = 0.0;
        double TimeWifi2GCH11 = 0.0;
        double TimeWifi5GCH36 = 0.0;
        double TimeWifi5GCH48 = 0.0;
        double TimeWifi5GCH153 = 0.0;
        double TimeWifi6GCH5 = 0.0;
        double TimeWifi6GCH37 = 0.0;
        double TimeWifi6GCH197 = 0.0;
        double FactoryRST = 0.0;

        double Wifi2GTXCH1 = 000.0;
        double Wifi2GRXCH1 = 000.0;
        double Wifi2GTXCH6 = 000.0;
        double Wifi2GRXCH6 = 000.0;
        double Wifi2GTXCH11 = 0.0;
        double Wifi2GRXCH11 = 0.0;
        double Wifi5GTXCH36 = 0.0;
        double Wifi5GRXCH36 = 0.0;
        double Wifi5GTXCH48 = 0.0;
        double Wifi5GRXCH48 = 0.0;
        double Wifi5GTXCH153 = 0.0;
        double Wifi5GRXCH153 = 0.0;
        double Wifi6GTXCH5 = 0.0;
        double Wifi6GRXCH5 = 0.0;
        double Wifi6GTXCH37 = 0.0;
        double Wifi6GRXCH37 = 0.0;
        double Wifi6GTXCH197 = 0.0;
        double Wifi6GRXCH197 = 0.0;

        string note = "";
        string WF2GCh1TX = "";
        string WF2GCh1RX = "";
        string WF2GCh6TX = "";
        string WF2GCh6RX = "";
        string WF2GCh11TX = "";
        string WF2GCh11RX = "";

        string WF5GCh36TX = "";
        string WF5GCh36RX = "";
        string WF5GCh48TX = "";
        string WF5GCh48RX = "";
        string WF5GCh153TX = "";
        string WF5GCh153RX = "";

        string WF6GCh5TX = "";
        string WF6GCh5RX = "";
        string WF6GCh37TX = "";
        string WF6GCh37RX = "";
        string WF6GCh197TX = "";
        string WF6GCh197RX = "";

        string Card2G = "GOLDEN2G";
        string Card5G = "GOLDEN5G";
        string Card6G = "GOLDEN5G";
        string IP2G = "192.168.1.101";
        string IP5G = "192.168.2.101";
        string IP6G = "192.168.2.101";
        string SSID2G = "OBA2GT08";
        string SSID5G = "OBA5GT08";
        string SSID6G = "OBA5GT08";
        string Test = "2G5G";
        private bool LoadInforOP()
        {
            bool a = false;
            string uu = txtUser.Text.Trim();
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory();
                string file_path = pathfile1 + "\\OBA.txt";
                StreamReader loadinfor = new StreamReader(file_path, Encoding.UTF8);
                string NoteOP = loadinfor.ReadToEnd();
                loadinfor.Close();
                string ii = getKeyEndNian(NoteOP, uu);
                if (ii == "")
                {
                    a = false;
                }
                else
                {
                    a = true;
                }
            }
            catch
            {
                a = false;
            }
            return a;
        }
        private double GettimeStart(string Function)
        {
            string timestart = DateTime.Now.ToString();
            msg(Function + " " + timestart + " START");
            double TimeNow = DateTime.Now.Ticks;///DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Millisecond;
            return TimeNow;
        }
        private double GettimeEnd(string Function)
        {
            string timeend = DateTime.Now.ToString();
            msg(Function + "  " + timeend + " END");
            double TimeNow = DateTime.Now.Ticks;//DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            return TimeNow;
        }
        private double CountTime(string Function, double TimeStart, double TimeEnd)
        {
            double TotalTime = Math.Round((TimeEnd - TimeStart) / 10000000, 2);
            msg("Total time " + Function + ": " + TotalTime);
            return TotalTime;
        }
        private bool WebAutoNian()
        {
            geckoWebBrowser1.Visible = true;
            double TimeStart = GettimeStart("Setting_WEB_UI");
            if (sModem != "CGM4981COX" & sModem != "CGM4981SHW")
            {
                if (!ConfigSSIDPassword()) {  return false; }
                txtboxsetupssid.BackColor = Color.Lime;
            }
            if (!LoginWEBFirst()) { return false; }
            txtboxchangpassword.BackColor = Color.Lime;
            if (Dklognewpassword == true)
            {
              ///  if (!changePasswordWebsite()) { return false; }
            }
            else { msg("Wating!! Login new password"); }
            if (!LoginWithNewPassword()) { return false; }
            if (sModem == "CGM4981COM" | sModem == "CGM4981COX" | sModem == "CGM4981SHW" | sModem == "CGM4981ROG")
            {
                if (!GetMACInforWEBUISW58()) { return false; }
            }
            else
            {
                if (!GetMACInforWEBUI()) { return false; }
            }
            if (cmmType.SelectedIndex == 1) { txtboxcheckinformation.BackColor = Color.Lime; }
            else { if (!Check_SN(SNNN)) { ErrorNian("Err_Check_SN_SFC"); return false; } }
            if (!GetSWWEBUI()) { return false; }
            if (!GeWifiInforWEBUI()) { return false; }
            double TimeEnd = GettimeEnd("Setting_WEB_UI");
            Loginweb = CountTime("Setting_WEB_UI", TimeStart, TimeEnd);
            return true;
        }
        private bool WebAutoNianRST()
        {
            thStattus1 = true;
            geckoWebBrowser1.Visible = true;
            if (!ConfigSSIDPassword()) { return false; }
            if (!LoginWEBFirst()) { return false; }
            if (Dklognewpassword == true)
            {
                if (!changePasswordWebsite()) { return false; }
            }
            else { msg("Wating!! Login new password"); }
            if (!LoginWithNewPassword()) { return false; }
            ResetFactorySeting();

            return true;
        }
        public void DeleteResult(string namepath,string part2)
        {
            // string file_path = @"D:\Test_Program\setup\Ixia\IxChariot\Tests";
            try
            {
                string file_path = @"D:\Test_Program\CGM4981-Wifi";
                string file_path1 = file_path + "\\" + namepath + ".txt";
                cmn.deleteFile(file_path1);
                string file_path2 = file_path + "\\" + part2 + ".txt";
                cmn.deleteFile(file_path2);
            }
            catch { }
        }
        public double ReturnResult(string namepath, string CH)
        {
            double dd = 0.0;
            int count = 0;
            int count1 = 0;
            string Result = "";
            string file_path = @"D:\Test_Program\CGM4981-Wifi";
            string file_path1 = file_path + "\\" + namepath + ".txt";
            Delay(10000);
            while (true)
            {
                if (cmn.FindFile(file_path1))
                {
                    while (true)
                    {
                        try
                        {
                            msg("read file result");
                            string data = File.ReadLines(file_path1).Skip(600).Take(1).First().Trim();
                            StreamReader loadinfor = new StreamReader(file_path1, Encoding.UTF8);
                            string RR = loadinfor.ReadToEnd();
                            loadinfor.Close();
                            msg(RR);
                            Result = getKey(RR, "Totals:", 14).Trim();
                            msg(namepath + "_" + CH + ": " + Result);
                            try { dd = Convert.ToDouble(Result); }
                            catch { dd = 0.0; }
                            return dd;
                        }
                        catch
                        {
                            count++;
                            if (count >= 30)
                            {
                                dd = 0.0;
                                // cmn.kill("cmd");
                                cmn.kill("runtst");
                                return dd;
                            }
                            delay(1000);
                        }
                    }
                }
                else
                {
                    count1++;
                    if (count1 >= 20)
                    {
                        dd = 0;
                        msg("Can't_find_the_file" + namepath);
                        //cmn.kill("cmd");
                        cmn.kill("runtst");
                        return dd;
                    }
                    delay(1000);
                }
            }
            return dd;
        }
        public string getKeyEnd1(string databuffer, string start, int length)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            try
            {
                if (databuffer.Contains(start))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = (istart + databuffer.IndexOf(start)) - start.Length;
                    int datalength = data - value - 1;
                    result = databuffer.Substring(value, (start.Length + length)).Trim();
                }
                else
                {
                    result = sModem;
                }
            }
            catch
            {
                result = sModem;
            }
            return result;
        }
        public string getKeyEnd(string databuffer, string start)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                if (databuffer.Contains(start))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = istart + databuffer.IndexOf(start);
                    int datalength = data - value - 1;
                    result = databuffer.Substring(value, datalength + 1);
                }
                else
                {
                    result = "";
                }
            }

            return result;
        }
        public string getKeyEnd11(string databuffer, string start)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                if (databuffer.Contains(start))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = databuffer.IndexOf(start);
                    int datalength = data - value - 1;
                    result = databuffer.Substring(value, 15);
                }
                else
                {
                    result = "";
                }
            }

            return result;
        }
        public string getKeyEndNian(string databuffer, string start)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                if (databuffer.Contains(start))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = databuffer.IndexOf(start);
                    int datalength = data - value - 1;
                    string tt = databuffer.Substring(value, datalength + 1);
                    int ee = tt.IndexOf("\r\n");
                    result = tt.Substring(0, ee).Replace("\t", " -- ");
                    OP = result;
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }
        public string getKeyVDT(string databuffer, string start)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                int data = databuffer.Length;
                int istart = start.Length;
                int value = istart + databuffer.IndexOf(start);
                int datalength = data - value - 1;
                result = databuffer.Substring(value, datalength + 1);
            }
            return result;
        }
        public string getKey(string databuffer, string start, int datalength)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                int data = databuffer.Length;
                int istart = start.Length;
                int value = istart + databuffer.IndexOf(start);
                result = databuffer.Substring(value + 1, datalength);
            }
            return result;
        }
        public void GetData()
        {
            string data = null;
            bool a = true;
            while (a)
            {
                data = telnet.GetStream() + "\r\n";
                if (data.IndexOf("Object") < 0)
                {
                    if (data.IndexOf("ERRO") < 0)
                    {
                        if (!data.Contains("A request to send or receive data was disallowed because the socket is not connected and (when sending on a datagram socket using a sendto call) no address was supplied"))
                        {
                            appenTextBox(data);
                        }

                    }

                }
                System.Threading.Thread.Sleep(100);
            }
        }
        private void appenTextBox(String strCongtent)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<String>(appenTextBox), new Object[] { strCongtent + "\r\n" });
                    //this.Invoke(new Action(()=>txtOutput.AppendText(strCongtent + "\r\n")));
                }
                else
                {

                    txtHistory.AppendText(strCongtent + "\n");

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void telnetSend(string comand)
        {
            telnet.SendCmd(comand + "\n");
        }
        private void telnetclose()
        {
            telnet.close();

        }
        private void sendDataToSer(int value)//client
        {

        }
        private void monitorStepTest()
        {

        }



        private void msg(string Message)
        {
            bool n = true;
            while (n)
            {
                try
                {
                    if (txtOutput.InvokeRequired)
                    {
                        txtOutput.Invoke(new Action(() =>
                        {
                            txtOutput.AppendText(Message + "\r\n");
                            n = false;
                        }));
                    }
                    else
                    {
                        txtOutput.AppendText(Message + "\r\n");
                        n = false;
                    }

                }
                catch
                { }
            }
        }

        private void msgsfc(string Message)
        {
            try
            {
                if (txtSFC.InvokeRequired)
                {
                    txtSFC.Invoke(new Action(() =>
                    {
                        txtSFC.Clear();
                        txtSFC.AppendText(Message);
                    }));
                }
                else
                {
                    txtSFC.Clear();
                    txtSFC.AppendText(Message);
                }

            }
            catch
            { }
        }
        private void msgPass(string Message)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() => txtOutput.AppendText(Message + "  (" + "\"" + "_" + "\"" + ")Pass" + "\r\n")));
            }
            else txtOutput.AppendText(Message + "  (" + "\"" + "_" + "\"" + ")Pass" + "\r\n");
        }
        private void fail(string ErroCode)//loi
        {
            errs = "";
            if (thStattus1 == true)
            {
                thStattus1 = false;
                timeTest.Enabled = false;
                StopPGram();
                FailOKOK();
                nk = true;
                msg("->ShowErr");
                if (ErroCode.Contains("ETIME0"))
                {
                    msg("->Err_Timeout");
                }
                try
                {
                    snvalue = Barcode2D_SN;
                    errs = ErroCode;
                    msg(errs);
                    msg("(" + "\"" + "^" + "\"" + ")" + errs);                                           
                    fails++;
                    if (lbFail.InvokeRequired)
                    {
                        lbFail.Invoke(new Action(() => lbFail.Text = fails.ToString()));
                    }
                    else lbFail.Text = fails.ToString();
                    msg("->Check_ERRCODE");
                    Check_ERRCODE(errs);
                   // ResetFactorySeting();
                    ErroCode = "";
                    errs = "";
                    bug = true;
                }
                catch (Exception ex)
                {
                    msg("Save & Send Err ->Fail__" + ex.Message.ToString());
                }
            }
        }
        private void SaveMaintainCounter(string passFail)
        {
            try
            {

                string infor = "";
                ModelnameFile = sModem;
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                string ttotest = "";
                // msg(DateTime.Now.ToString());
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath1 = Directory.GetCurrentDirectory();

                string filePathSN = directoryPath1 + @"\maintain.txt";
                if (File.Exists(filePathSN))
                {
                    File.Delete(filePathSN);
                }
                else
                {
                    File.CreateText(filePathSN);
                }
                // string filePathSN2 = directoryPath1 + @"\SN2.txt";
                StreamWriter strWrite1 = new StreamWriter(filePathSN, true);


                strWrite1.WriteLine(passFail);
                delay(1000);
                strWrite1.Flush();
                strWrite1.Close();
                // strWrite2.Flush();
                //strWrite2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
            //ResetRelay();
        }
        private void MoveFile(int kk, string file, string time, string newname)
        {
            string filename1 = "AudioTest.mp3";
            string filename2 = "nsTest.mp3";
            string fileNewname = "AudioTest" + newname + ".mp3";
            string sourcepathFile = file;// + "AudioTest.mp3";
            ModelnameFile = sModem;
            string date = DateTime.Now.ToString("MM / dd / yyyy");
            date = DateTime.Now.ToString("dd-MM-yyyy");
            date = date.Replace("-", ".");
            string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile + "-VOiP-" + time;
            if (kk == 0)
            {
                try
                {
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }
                    string sourceFile = System.IO.Path.Combine(sourcepathFile, filename1);
                    string destFile = System.IO.Path.Combine(directoryPath, fileNewname);
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch
                {
                    MessageBox.Show("MoveFile-->FAIL");
                }
            }
            else if (kk == 1)
            {

                try
                {
                    if (!System.IO.Directory.Exists(directoryPath))
                    {
                        System.IO.Directory.CreateDirectory(directoryPath);
                    }
                    string sourceFile = System.IO.Path.Combine(sourcepathFile, filename2);
                    string destFile = System.IO.Path.Combine(directoryPath, fileNewname);
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch
                {
                    MessageBox.Show("MoveFile-->FAIL");
                }
            }

            //string path1 = directoryPath + "//" +filename;
            //string path2 = directoryPath + "//" + newname;
            //System.IO.File.Move(path1, path2);
        }
        private void LogFile(string passFail,string error)
        {
            try
            {
               /// cmn.openExe1(pathfile1, "disableDUT");
                prinhistory();               
                ModelnameFile = sModem;
                string time11 = "";
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                msg(DateTime.Now.ToString());
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                string sns = lbsndut.Text.Trim();
                string filePath = directoryPath + @"\" + sns + "_" + passFail + "_" + lbTimecc.Text + ".txt";
                pathsaveftp = filePath;
                if (lbTimecc.InvokeRequired)
                {
                    lbTimecc.Invoke(new Action(() =>
                    {
                        time11 = lbTimecc.Text;
                        msg("Tottal_TestTime:" + lbTimecc.Text);

                    }));
                }
                else
                {
                    time11 = lbTimecc.Text;
                    msg("Tottal_TestTime:" + lbTimecc.Text);
                }
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                StreamWriter strWrite = new StreamWriter(filePath, true);
                strWrite.WriteLine(txtOutput.Text);
                strWrite.Flush();
                strWrite.Close();
                if (passFail.Contains("PASS"))
                {
                    if (txtOutput.InvokeRequired){txtOutput.Invoke(new Action(() => txtOutput.Clear()));}
                    else{txtOutput.Clear();}
                }
                if (cmmType.InvokeRequired)
                {
                    cmmType.Invoke(new Action(() =>
                    {
                        if (cmmType.SelectedIndex == 1) { }                     
                        else
                        {
                            //cmn.openExe1(pathfile1, "disableDUT");
                            delay(1000);
                            Save_Time_test(sns, passFail, error, time11);
                            try
                            {
                                SeveFile(pathsaveftp);
                                Save_logfile_SFTP(sModem, pathsaveftp);
                                //SeveFile(pathsaveftp1);
                                //SeveFile(pathsaveftp2);
                            }
                            catch
                            {
                                MessageBox.Show("CANNOT Send to SFTP ==> CALL TQE/n Không gửi đựơc lên SFTP ==> Gọi TQE");
                            }
                        }
                    }));
                }
                else
                {
                    if (cmmType.SelectedIndex == 1) { }                
                    else
                    {
                       // cmn.openExe1(pathfile1, "disableDUT");
                        delay(1000);
                        Save_Time_test(sns, passFail, error, time11);
                        try {
                            SeveFile(pathsaveftp);
                            Save_logfile_SFTP(sModem, pathsaveftp);
                            //// SeveFile(pathsaveftp1);
                            // SeveFile(pathsaveftp2);
                        }
                        catch
                        {
                            MessageBox.Show("CANNOT Send to SFTP ==> CALL TQE/n Không gửi đựơc lên SFTP ==> Gọi TQE");
                        }
                    }
                }
                cmn.openExe1(pathfile1, "enableDUT");
                delay(5000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
        }
        private bool SeveFile(string pathlog)
        {
            bool result = false;
            ModelnameFile = sModem;
            string ftp = "ftp://200.168.104.98";
            string username = "Logs";
            string password = "Logs";
            string date = DateTime.Now.ToString("MM / dd / yyyy");
            date = DateTime.Now.ToString("dd-MM-yyyy");
            string patth = "/Logs/OBA/" + Computer_name + "/" + date + "/" + ModelnameFile;
            string patth1 = "/Logs/OBA/" + Computer_name;
            string patth2 = "/Logs/OBA/" + Computer_name + "/" + date;
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (File.Exists(pathlog))
                    {
                        try
                        {
                            string aa = FTP_Transfer.ftp_transfer.UploadFile(ftp, pathlog, patth1, patth2, username, password, patth);
                            if (aa.Contains("complete"))
                            {
                                result = true;
                                return true;
                            }
                            else
                            {
                                if (i == 5)
                                {
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            if (i == 5)
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        delay(500);
                    }
                }
            }
            return result;
        }
        private bool Save_logfile_SFTP(string modelName, string fordel_path)
        {
            //bool result = false;
            //ModelnameFile = sModem;

            string date = DateTime.Now.ToString("MM / dd / yyyy");
            date = DateTime.Now.ToString("dd-MM-yyyy");
            bool huyen_dz = false;
            using (SftpClient clinet = new SftpClient("200.168.104.98", 22, "sftp", "tenpi"))
            {
                clinet.Connect();
                try
                {
                    string pat = @"//Logs//OBA";
                    if (!clinet.Exists(pat))
                    {
                        clinet.CreateDirectory(pat);
                    }
                    string pat2 = pat + @"//" + modelName;
                    string pat3 = pat2 + @"//" + Computer_name;
                    string pat4 = pat3 + @"//" + date;
                    if (!clinet.Exists(pat2))
                    {
                        clinet.CreateDirectory(pat2);
                    }
                    clinet.ChangeDirectory(pat2);
                    if (!clinet.Exists(pat3))
                    {
                        clinet.CreateDirectory(pat3);
                    }
                    clinet.ChangeDirectory(pat3);
                    if (!clinet.Exists(pat4))
                    {
                        clinet.CreateDirectory(pat4);
                    }
                    clinet.ChangeDirectory(pat4);
                }
                catch
                {
                    MessageBox.Show("Can not send logfile to SFTP ===> CALL TQE\n Không gửi đuợc logfile lên SFTP ===> GỌi TQE");
                    msg("CreateDirectory_SFTP ==> FAIL");
                }
                try
                {
                    using (FileStream fs = new FileStream(fordel_path, FileMode.Open))
                    {
                        clinet.BufferSize = 4 * 1024;
                        clinet.UploadFile(fs, Path.GetFileName(fordel_path));
                    }
                    huyen_dz = true;
                }
                catch
                {
                    MessageBox.Show("Can not send logfile to SFTP ===> CALL TQE\n Không gửi đuợc logfile lên SFTP ===> GỌi TQE");
                    msg("Send logfile SFTP server ==> FAIL");
                }
                clinet.Disconnect();
            }
            return huyen_dz;
        }
        private void LogFilePass()
        {
            pathsaveftp2 = "";
            string WPSPairing = "";
            try
            {               
                string time = "";
                ModelnameFile = sModem;
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                string sns = "wxwx";
                if (lbTimecc.InvokeRequired)
                {
                    lbTimecc.Invoke(new Action(() => time = lbTimecc.Text));
                }
                else
                {
                    time = lbTimecc.Text;
                }
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                }
                else
                {
                    sns = lbsndut.Text;
                }
                string filePathSN3 = directoryPath + @"\SummaryPass.ini";
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);                  
                }
                if (!File.Exists(filePathSN3))
                {
                    StreamWriter strWrite1 = new StreamWriter(filePathSN3, true);
                    strWrite1.WriteLine("Model \tSN \t Time \t 2.4G-CH1 \t\t 2.4G-CH6 \t\t 2.4G-CH11 \t\t 5G-CH36 \t\t 5G-CH48 \t\t 5G-CH153 \t\t 6G-CH5 \t\t 6G-CH37 \t\t 6G-CH197 \t\t Note \t\t Employee");
                    strWrite1.Flush();
                    strWrite1.Close();
                    delay(1000);
                }
                StreamWriter strWrite = new StreamWriter(filePathSN3, true);
                strWrite.WriteLine(sModem + "\t" + sns + "\t" + time + "\t" +
                Wifi2GTXCH1 + "\t" + Wifi2GRXCH1 + "\t" +
                Wifi2GTXCH6 + "\t" + Wifi2GRXCH6 + "\t" +
                Wifi2GTXCH11 + "\t" + Wifi2GRXCH11 + "\t" +
                Wifi5GTXCH36 + "\t" + Wifi5GRXCH36 + "\t" +
                Wifi5GTXCH48 + "\t" + Wifi5GRXCH48 + "\t" +
                Wifi5GTXCH153 + "\t" + Wifi5GRXCH153 + "\t" +
                Wifi6GTXCH5 + "\t" + Wifi6GRXCH5 + "\t" +
                Wifi6GTXCH37 + "\t" + Wifi6GRXCH37 + "\t" +
                Wifi6GTXCH197 + "\t" + Wifi6GRXCH197 + "\t" +
                WPSPairingfunction + "\t" + OP.Substring(0,8));
                strWrite.Flush();
                strWrite.Close();
                pathsaveftp2 = filePathSN3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
        }
        private void LogFileFail(string passFail, string Error)
        {
            try
            {
                pathsaveftp1 = "";
                ModelnameFile = sModem;
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                string sns = "xxxxx";
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                }
                else
                {
                    sns = lbsndut.Text;
                }
                string filePathSN3 = directoryPath + @"\summaryFail.ini";
                StreamWriter strWrite3 = new StreamWriter(filePathSN3, true);
                strWrite3.WriteLine(sns + "\t" + passFail + "\t" + Error + "\t" + DateTime.Now.ToString());
                strWrite3.Flush();
                strWrite3.Close();
                pathsaveftp1 = filePathSN3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
        }
        private void _comSfc_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bufSFC = "";
            bufSFC = ComSFC.ReadLine();
            str_SFC = bufSFC.Replace("\r","").Replace("\n", "").Trim();
            msgsfc(str_SFC);
        }

        private void ErrorNian(string maloi)
        {
            FailOKOK();
            Nian = "";
            Nian = maloi;
            thMutiple8 = new Thread(new ThreadStart(thrMultFail));
            thMutiple8.IsBackground = true;
            thMutiple8.Start();
            cmmType.Enabled = true;

        } 
        private bool checkPingTimeout()
        {
            bool a = false;
            int pingtimeout1 = 0;
            bool b = true;
            int countPing = 0;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkReset);
                for (int n = 0; n <= 40; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals((linkReset)))
                    {
                        if (WaitLog(DocumentTitleRST, DocumentTitleRST)) {
                            try {
                                GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                            }
                            catch { delay(1000); }
                            break; }
                        else { if (!LoginWithNewPassword()) ; }
                    }
                    else
                    {
                        if (n == 7)
                        {
                            geckoWebBrowser1.Navigate(linkReset);
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleRST, DocumentTitleRST)) { }
                            else { WebAutoNian(); }
                        }
                        if (n >= 35)
                        {
                            b = false;
                            return false;
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    cout1++;
                    try
                    {
                        GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                        Submit_reset.Click();
                        delay(500);
                        try
                        {
                            GeckoInputElement ss = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_title").DomObject);
                            string dd = ss.TextContent;
                            if (dd.Contains("Are You Sure?"))
                            {
                                string okclick = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                delay(200);
                                click.Click();
                                delay(35000);
                                msgPass("Reset_DUT_WEBUI");
                                a = true;
                                b = false;
                                while (true)
                                {
                                    cmn.pingToAddress(InfoIP);
                                    msg(cmn.pingdata);
                                    if (!string.IsNullOrEmpty(cmn.pingdata))
                                    {
                                        if (cmn.pingdata.Contains("Can not ping to"))
                                        {
                                            countPing = 0;
                                            pingtimeout1++;
                                            if (pingtimeout1 >= 5)
                                            {
                                                countPing = 0;
                                                pingtimeout1 = 0;
                                                msgPass("PingTimeout");
                                                a = true;
                                                b = false;
                                                return true;
                                            }
                                        }
                                        else
                                        {
                                            Status("Wait Ping TimeOut: " + countPing.ToString());
                                            countPing++;
                                            pingtimeout1 = 0;
                                            if (countPing >= 60) //30
                                            {
                                                msg("PingTimeout Fail !!");
                                                if (cout1 >= 3)
                                                {
                                                    msg("Error Ping TimeOut ");
                                                    b = false;
                                                    a = false;
                                                    pingtimeout1 = 0;
                                                    countPing = 0;
                                                    ErrorNian("Err_Ping_Timeout");
                                                    return false;
                                                }                                              
                                            }
                                            delay(500);
                                        }
                                        delay(500);
                                    }
                                } 
                            }
                        }
                        catch { }
                    }
                    catch (Exception ex)
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_ResetFactory_WEB " + ex);
                            ErrorNian("Err_ResetFactory_WEB");
                            b = false;
                        }
                        geckoWebBrowser1.Navigate(linkReset);
                        delay(3000);
                    }
                }
            }
            else
            {
                return false;
            }

            return a;
        }
        private bool checkPingtoDUT(string PingInformation, string EthCardName, string EthCardNameDisable, string iptest, int pingtimeout, int countPing)
        {
            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(iptest);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("TTL=64") || cmn.pingdata.Contains("TTL=128"))
                    {
                        ping++;
                        pingtimeout1 = 0;
                        if (ping >= 5)
                        {
                            msgPass(PingInformation);
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    else
                    {
                        pingtimeout1++;
                        ping = 0;
                        if (pingtimeout1 == 5)
                        {
                            cmn.openExe1(pathfile1, "disable" + EthCardName);
                            delay(100);
                            cmn.openExe1(pathfile1, "enable" + EthCardName);
                            delay(10000);
                        }
                        if (pingtimeout1 >= 15)
                        {
                            msg(PingInformation + " can not ping");
                            return false;
                        }
                    }
                }
            }
            return a;
        }
        private bool checkPingtoDUT11(string iptest, int pingtimeout, int countPing)
        {
            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            while (b)
            {
                cmn.pingToAddress(iptest);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {              
                    if (cmn.pingdata.Contains("TTL=64") || cmn.pingdata.Contains("TTL=128"))
                    {
                        ping++;
                        pingtimeout1 = 0;
                        if (ping >= 5)
                        {

                            a = true;
                            b = false;
                            return true;
                        }
                        delay(200);
                    }
                    else
                    {
                        pingtimeout1++;
                        ping = 0;
                        if (pingtimeout1 >= pingtimeout)
                        {
                            b = false;
                            a = false;
                            return false;
                        }
                        delay(1000);
                    }
                }                            
            }
            return a;
        }
        private bool checkPingResetToSefoul(string PingInformation, string EthCardName, string EthCardNameDisable, string iptest, int pingtimeout, int countPing)
        {
            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(iptest);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        delay(1000);
                        pingtimeout1++;
                        if (pingtimeout1 == 50)
                        {
                            MyMessagesBox.Show("\n----------------!!WARING!!----------------\n            HÃY KIỂM TRA DUT \n      HOẠT ĐỘNG HAY KHÔNG ?");
                        }
                        if (pingtimeout1 >= pingtimeout)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + " can not ping");
                            b = false;
                            a = false;
                        }
                    }
                    else if (cmn.pingdata.Contains("TTL=64") || cmn.pingdata.Contains("TTL=128"))
                    {
                        ping++;
                        delay(500);
                        if (ping >= countPing)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msgPass(PingInformation);
                            a = true;
                            b = false;
                        }
                    }
                }
            }
            return a;
        }
        private bool checkPingProductDHCP(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, int pingtimeout, int countPing, string mt)
        {

            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            string pathfile1 = Directory.GetCurrentDirectory();
            //cmn.openExe1(pathfile1, "enable" + EthCardName);
            //Delay(2000);
            int pingtimeout1 = 0;
            int pingtimeout2 = 0;
            int ping = 0;
            msg(PingInformation);
            while (b)
            {
                //cmn.pingToAddress(ipAddress);
                cmn.pingToAddress(ipAddress);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;
                        pingtimeout2++;
                        delay(200);

                        if (pingtimeout1 >= pingtimeout)
                        {

                            //////cmn.openExe1(pathfile1, "enableEth2");
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + " can not ping");
                            b = false;
                        }
                    }
                    else
                    {
                        ping++;
                        delay(500);
                        if (ping > 4 && ping < 6)
                        {
                            //delay(1000);
                            //cmn.openExe1(pathfile1, "enable" + EthCardName);
                            //delay(500);

                        }
                        if (ping >= countPing)
                        {
                            //if(!EthCardName.Contains("Eth2"))
                            //{
                            //    cmn.openExe1(pathfile1, "disable" + EthCardName);
                            //}                          
                            countPing = 0;
                            pingtimeout = 0;
                            msgPass(PingInformation);
                            a = true;
                            b = false;
                        }
                    }
                }
                Delay(150);
            }
            return a;
        }

        private bool CheckDUTlive()
        {
            bool a = false;
            Status("Check_DUT_Alive...");
            double TimeStart = GettimeStart("Ckeck_DUT_Alive");
            if (thStattus1 == true)
            {              
                if (checkPingtoDUT("Ping to DUT", "DUT", " ", InfoIP, 10, 4))
                {
                    if (!EnabelEthAllDHCP()) { return false;}
                    msgPass("Ckeck_DUT_Alive");
                    txtboxcheckdutalive.BackColor = Color.Lime;
                    double TimeEnd = GettimeEnd("Ckeck_DUT_Alive");
                    DUTalive = CountTime("Ckeck_DUT_Alive", TimeStart, TimeEnd);
                    a = true;
                    return true;
                }
                else
                {
                    ErrorNian("Err_Ckeck_DUT_Alive");
                    double TimeEnd = GettimeEnd("Ckeck_DUT_Alive");
                    DUTalive = CountTime("Ckeck_DUT_Alive", TimeStart, TimeEnd);
                    a = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool PingToWifi(string Name, string IP,string Wifiname)
        {
            bool a = false;
            bool b = true;
            int count = 0;
            if (thStattus1 == true)
            {
                if (!cmdNian1("WiFiOBACXB8-PC.exe CONNECT 192.168.200.2 " + Wifiname))
                {
                    msg("Can't connect to " + Wifiname);
                    return false;
                }
                else
                {
                    while (b)
                    {
                        count++;
                        if (checkPingtoDUT11(IP, 10, 6))
                        {
                            msgPass(Name);
                            a = true;
                            return true;
                        }
                        else
                        {
                            if (Wifiname.Contains("2G"))
                            {
                                Resetcard2G();
                            }
                            else if (Wifiname.Contains("5G"))
                            {
                                Resetcard5G();
                            }
                            else if (Wifiname.Contains("6G"))
                            {
                                Resetcard6G();
                            }
                            if (count >= 3)
                            {
                                msg("Can't_Ping_to_" + count + "_" + Name + "_" + IP);
                                a = false;
                                b = false;
                                return false;
                            }
                            delay(15000);
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool PlugRFMOCA()
        {
            timeTest.Enabled = false;
            DialogResult va = MyMessagesBox.Show("\n\r           !!!!--WARNING--!!!!\n\r            CẮM DÂY RF MOCA\n\r        VÀO SẢN PHẨM!");
            if (va == DialogResult.Yes | va == DialogResult.No)
            {
                timeTest.Enabled = true;
                return true;
            }
            return true;
        }
        private void Reset_to_default()
        {
            geckoWebBrowser1.Navigate("http://10.0.0.1/restore_reboot.jst");
            for (int n = 0; n <= 20; n++)
            {
                if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(("http://10.0.0.1/restore_reboot.jst")))
                {
                    break;
                }
                else
                {
                    delay(1000);
                }
            }
            Gecko.GeckoElementCollection geckoElementCollection = geckoWebBrowser1.Document.GetElementsByTagName("a");
            geckoWebBrowser1.Document.GetElementsByTagName("a")[51].Click();
            delay(200);
            string infweb = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
            delay(3000);
            if ((infweb.Contains("popup_ok")))
            {
                GeckoInputElement Reset_to_default = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                delay(1000);
                Reset_to_default.Click();
                delay(10000);
                StopWEB();

            }
        }
        private bool checkPingResetTodefault()
        {
            bool a = false;
            double TimeStart = GettimeStart("Factory_RST");       
            if (thStattus1 == true)
            {
                Status("Factory_Reset...");
                if (!checkPingTimeout())
                {
                    return false;
                }
                //delay(20000);
                //if (checkPingResetToSefoul("Ping_After_Reset_Todefault", "EthAll", "", InfoIP, 60, 10))
                //{
                for (int i = 0; i <= 5; i++)
                {
                    if (Send_To_SFC_PASS())
                    {
                        txtboxfactoryreset.BackColor = Color.Lime;
                        timStart.Enabled = true;
                        timeTest.Enabled = false;
                        pass++;
                        msgPass("Ping_Reset_Todefault");
                        msgPass("All_Wi-Fi_Function-> Pass");
                        double TimeEnd = GettimeEnd("Factory_RST");
                        FactoryRST = CountTime("Factory_RST", TimeStart, TimeEnd);
                        SummaryWifi();
                        okok1();                    
                        lbPass.Text = pass.ToString();
                        PASSOK();
                        LogFilePass();
                        LogFile("PASS", "");
                        cmn.openExe1(pathfile1, "enableDUT");
                        thStattus1 = false;
                        bug = true;
                        return true;
                    }
                    else
                    {
                        msg("Send_To_SFC_Error: " + i);
                        if (i>2)
                        {
                            MessageBox.Show("Send_To_SFC_Error");
                        }
                        if (i == 4)
                        {
                            ErrorNian("Err_Send_SFC_Pass!!");
                            return false;
                        }
                        Delay(3000);
                    }
                }
                //}
                //else
                //{
                //    thStattus1 = false;
                //    ErrorNian("Err_PingafterReset");
                //    double TimeEnd = GettimeEnd("Factory_RST");
                //    FactoryRST = CountTime("Factory_RST", TimeStart, TimeEnd);
                //    return false;
                //}
            }
            else
            {
                bug = true;
                return false;
            }         
            return a;
        }
        private string pass1;
        private string Pass1
        {
            get { return pass1; }
            set { pass1 = value; }
        }
        private string pass2;
        private string Pass2
        {
            get { return pass2; }
            set { pass2 = value; }
        }
        private string pass3;
        private string Pass3
        {
            get { return pass3; }
            set { pass3 = value; }
        }
        private string network1;
        private string Network1
        {
            get { return network1; }
            set { network1 = value; }
        }
        private string network2;
        private string Network2
        {
            get { return network2; }
            set { network2 = value; }
        }
        private string wpsPin;
        private string WpsPin
        {
            get { return wpsPin; }
            set { wpsPin = value; }
        }
        private string barcode2D;
        private string Barcode2D
        {
            get { return barcode2D; }
            set { barcode2D = value; }
        }
        private string barcode2D_SN;
        private string Barcode2D_SN
        {
            get { return barcode2D_SN; }
            set { barcode2D_SN = value; }
        }
        private string barcode2D_CMMAC;
        private string Barcode2D_CMMAC
        {
            get { return barcode2D_CMMAC; }
            set { barcode2D_CMMAC = value; }
        }
        private string barcode2D_MTAMAC;
        private string Barcode2D_MTAMAC
        {
            get { return barcode2D_MTAMAC; }
            set { barcode2D_MTAMAC = value; }
        }
        private void openledprogram(string fileRun, string fileResult)
        {
            string pathfile1 = Directory.GetCurrentDirectory();            
            cmn.openExe(pathfile1, fileRun);
            Delay(2000);
            openledprogram("StartLedOnline", "");
        }
        bool SNHieuPC = true;
    
      
      
        private void thrMultSENSFC()
        {
            Check_ERRCODE(errs);
        }
        private void thrMultFail()
        {
            delay(3000);
            fail(Nian);
            FailOKOK();
        }
        private string getValue(string buff, string Contains, string Indexof)
        {

            string result = "";
            // if (!string.IsNullOrWhiteSpace(buff) && buff.Contains("WAN IP Address (IPv4):"))
            {

                buff = buff.Replace("\n\t\t", "");
                int sta = buff.Length;
                string start = Indexof;
                int tr = buff.IndexOf(start);
                int str = buff.Length - tr - start.Length;
                result = buff.Substring(tr + start.Length, str);
                // MessageBox.Show(buff.Substring(tr + start.Length, str));
                //Rogers_Network_DS_Odd();
            }
            return result;
        }
        private void WriteNormal()
        {
            try
            {
                cmn.kill("notepad");
                string a = DateTime.Now.ToString();
                string pathfile = Directory.GetCurrentDirectory() + "\\WPSpairing.txt";
                FileStream fs;
                fs = new FileStream(pathfile, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine("No");
                write.WriteLine("No");
                write.WriteLine(a);
                write.Flush();
                fs.Close();
            }
            catch { }
        }
        private void Write(string note)
        {
            try
            {
                cmn.kill("notepad");
                string a = DateTime.Now.ToString();
                string pathfile = Directory.GetCurrentDirectory() + "\\WPSpairing.txt";
                FileStream fs;
                fs = new FileStream(pathfile, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                if (note.Contains("DayOK"))
                {
                    write.WriteLine("DayOK");
                    write.WriteLine("No");
                    write.WriteLine(a);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    write.WriteLine("No");
                    write.WriteLine("NightOK");
                    write.WriteLine(a);
                    write.Flush();
                    fs.Close();
                }
            }
            catch { }
        }
        private void WPSPairing()
        {
            string a = DateTime.Now.ToString();
            //Write("Yes",a);
            delay(2000);
            string pathfile = Directory.GetCurrentDirectory() + "\\WPSpairing.txt";
            StreamReader load = new StreamReader(pathfile, Encoding.UTF8);
            string Status = load.ReadLine().Trim();
            string Time = load.ReadLine().Trim();
            load.Close();
            DateTime cc = Convert.ToDateTime(Time);
            DateTime b = DateTime.Now;

            int result = DateTime.Compare(b, cc);
        }
        private void wpspNian()
        {
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 7:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);

            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;

            string pathfile = Directory.GetCurrentDirectory() + "\\WPSpairing.txt";
            string Statusday = "";
            string Statusnight = "";
            string Timecompare = "";
            try
            {
                StreamReader load = new StreamReader(pathfile, Encoding.UTF8);
                Statusday = load.ReadLine().Trim();
                Statusnight = load.ReadLine().Trim();
                Timecompare = load.ReadLine().Trim();
                load.Close();
            }
            catch { }
            if (Statusday.Equals(""))
            {
                WriteNormal();
                return;
            }
            DateTime Time1 = Convert.ToDateTime(Timecompare);
            string dayCompare = Time1.DayOfYear.ToString();
            string dayCompare1 = DateTime.Now.DayOfYear.ToString();
            if (!dayCompare1.Equals(dayCompare))
            {
                WriteNormal();
            }
        }
        private void CkeckWPSPairing()
        {
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 7:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);

            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;

            string pathfile = Directory.GetCurrentDirectory() + "\\WPSpairing.txt";
            string Statusday = "";
            string Statusnight = "";
            string Timecompare = "";
            try
            {
                StreamReader load = new StreamReader(pathfile, Encoding.UTF8);
                Statusday = load.ReadLine().Trim();
                Statusnight = load.ReadLine().Trim();
                Timecompare = load.ReadLine().Trim();
                load.Close();
            }
            catch { }
            if (Statusday.Equals(""))
            {
                WriteNormal();
                return;
            }
            DateTime Time1 = Convert.ToDateTime(Timecompare);
            string dayCompare = Time1.DayOfYear.ToString();
            string dayCompare1 = DateTime.Now.DayOfYear.ToString();
            if (Timee3 < Timee2 & Timee3 > Timee1)
            {
                if (!Statusday.Equals("DayOK"))
                {
                    /// cmn.openExe1(pathfile1, "disableDUT");
                    MyMessagesBox.Show("\n               !!!WARNING!!!\nKiêm Tra chưc năng WPS PAIR!\n Pls. Test Function WPS Pairing!");
                    //SeveFile(pathsaveftp1);
                    ////SeveFile(pathsaveftp2);
                    //cmn.openExe1(pathfile1, "enableDUT");
                    //delay(5000);
                }

            }
            else if (!Statusnight.Equals("NightOK"))
            {
                MyMessagesBox.Show("\n               !!!WARNING!!!\nKiêm Tra chưc năng WPS PAIR!\n Pls. Test Function WPS Pairing!");
            }

        }
        private void prinhistory()
        {
            string nam = "\n\r" + lbsndut.Text.Trim() + "    " +
            Math.Round(Wifi2GTXCH1, 0) + "-" + Math.Round(Wifi2GRXCH1, 0) + "     " +
            Math.Round(Wifi2GTXCH6, 0) + "-" + Math.Round(Wifi2GRXCH6, 0) + "     " +
            Math.Round(Wifi2GTXCH11, 0) + "-" + Math.Round(Wifi2GRXCH11, 0) + "     " +
            Math.Round(Wifi5GTXCH36, 0) + "-" + Math.Round(Wifi5GRXCH36, 0) + "     " +
            Math.Round(Wifi5GTXCH48, 0) + "-" + Math.Round(Wifi5GRXCH48, 0) + "     " +
            Math.Round(Wifi5GTXCH153, 0) + "-" + Math.Round(Wifi5GRXCH153, 0) + "     " +
            Math.Round(Wifi6GTXCH5, 0) + "-" + Math.Round(Wifi6GRXCH5, 0) + "     " +
            Math.Round(Wifi6GTXCH37, 0) + "-" + Math.Round(Wifi6GRXCH37, 0) + "     " +
            Math.Round(Wifi6GTXCH197, 0) + "-" + Math.Round(Wifi6GRXCH197, 0) + "\n\r";
            if (txtHistory.InvokeRequired) { txtHistory.Invoke(new Action(() => txtHistory.AppendText(nam)));}
            else { txtHistory.AppendText(nam); }
           
        }    
        private void Form1_Load(object sender, EventArgs e)
        {
            txtComFB.Visible = false;
            // bug = true;
            OP = "";
            sComSFC = "COM2";
            blcomputer.Text = Computer_name;
            cmmModem.Items.Add("CGM4981COM");
            cmmModem.Items.Add("CGM4981COM-DEV");
            cmmModem.Items.Add("CGM4981COX");
            cmmModem.Items.Add("CGM4981ROG");
            cmmModem.Items.Add("CGM4981SHW");
            cmmModem.Items.Add("CGM4981VDT");
            cmmType.Text = "Online_Program";
            cmmType.Items.Add("Online_Program");
            cmmType.Items.Add("Offline_Program");
            btnstatus.Enabled = false;
            bntstat.Enabled = false;
            cmdNian();
            loadComport();
            //Disablecard5G();
            // Disablecard6G();
            Resetcard2G();
            label1.Focus();
            tabCtrInstall.Cursor = Cursors.Default;
            txtOutput.Cursor = Cursors.Default;
            wpspNian();
        }
        private bool checkStatustesting(string checkStatustesting)
        {
            bool a = true;
            if (!string.IsNullOrEmpty(checkStatustesting))
            {
                if (checkStatustesting.Equals("Checking"))
                {
                    // fail("mt8Checking");
                    a = false;
                }
            }
            return a;
        }
        private void loadComport()
        {
            
            string pathfile2 = Directory.GetCurrentDirectory();
            string file_path2 = pathfile2 + "\\ProSetting.txt";
            StreamReader loadinfor2 = new StreamReader(file_path2, Encoding.UTF8);
            try
            {
                string Card2G1 = loadinfor2.ReadLine();
                string Card5G1 = loadinfor2.ReadLine();
                string Card6G1 = loadinfor2.ReadLine();
                string IP2G1 = loadinfor2.ReadLine();
                string IP5G1 = loadinfor2.ReadLine();
                string IP6G1 = loadinfor2.ReadLine();
                string SSID2G1 = loadinfor2.ReadLine();
                string SSID5G1 = loadinfor2.ReadLine();
                string SSID6G1 = loadinfor2.ReadLine();
                //string Itemwifi = loadinfor2.ReadLine();
                Test = loadinfor2.ReadLine();
                loadinfor2.Close();
                Card2G = getKeyEnd(Card2G1, "Card2G:").Trim();
                Card5G = getKeyEnd(Card5G1, "Card5G:").Trim();
                Card6G = getKeyEnd(Card6G1, "Card6G:").Trim();
                IP2G = getKeyEnd(IP2G1, "Ping2G:").Trim();
                IP5G = getKeyEnd(IP5G1, "Ping5G:").Trim();
                IP6G = getKeyEnd(IP6G1, "Ping6G:").Trim();
                SSID2G = getKeyEnd(SSID2G1, "SSID2G:").Trim();
                SSID5G = getKeyEnd(SSID5G1, "SSID5G:").Trim();
                SSID6G = getKeyEnd(SSID6G1, "SSID6G:").Trim();
                if (Test.Contains("2G"))
                {
                    Item2G = true;
                }
                else
                {
                    Item2G = false;
                    suscessfulsetingWifi5G = true;
                }
                if (Test.Contains("5G"))
                {
                    Item5G = true;
                }
                else
                {
                    Item5G = false;
                }
                if (Test.Contains("6G"))
                {
                    Item6G = true;
                }
                else
                {
                    Item6G = false;
                }
            }
            catch
            {
                MyMessagesBox.Show("     Kiểm  tra File ProSeting.txt");
                return;
            }

        }
        private bool preTesting()
        {
            bool a = false;
            thStattus1 = true;
            snvalue = "";     
            a = true;
            return a;

        } 
        public void _set_net_enable()
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, "enableEthAll");
            delay(3000);
        }
        
        public void _set_net_disable()
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, "disableEthAll");
            delay(1000);
        }
        public void _set_net_enable_one(string name)
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, name);
            delay(1000);
        }

        public void _set_net_disable_one(string name)
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, name);
            delay(1000);  
        }

        public void runBatFile(string name)
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, name);
            delay(2000);
        }
        
        private bool checkStatus(string sta)
        {
            bool a = true;
            if (sta.Equals("Checking"))
            {
                a = false;
            }
            return a;   
        }
        private void log_sum_on_off(string data)
        {
            try
            {
                string ti = DateTime.Now.ToString("dd-MM-yyyy HH.mm.ss");
                string directoryPath1 = Directory.GetCurrentDirectory();
                string filePathSN = directoryPath1 + @"\logfile_sum.txt";
                StreamWriter strWrite1 = new StreamWriter(filePathSN, true);
                strWrite1.WriteLine(data + " ___" + ti);
                strWrite1.Flush();
                strWrite1.Close();
            }
            catch { msg("save system err"); }

        }
        private void btnStart_Click(object sender, EventArgs e)
        {

            //thStattus1 = true;
            //geckoWebBrowser1.Visible = true;
            //try
            //{
            //    geckoWebBrowser1.Navigate("about:blank");
            //    delay(100);
            //    geckoWebBrowser1.Document.Cookie = "";
            //    geckoWebBrowser1.Document.Cookie.Clone();
            //    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            //}
            //catch { }
            //LoginWithNewPassword1();
            //if (!SettingWifi2G_check_ssid("1", "1")) ;
            //Delay(2000);
            //geckoWebBrowser1.Navigate(linkwifi2G);
            ////SettingWifi5G_check_ssid("", "");
            //SettingWifi2G_off("", "");
            //Delay(10000);
            //SettingWifi2G_On("", "");
            //Delay(10000);
            //SettingWifi6G_off("", "");
            //Delay(10000);
            //SettingWifi6G_On("", "");




            bug = true;
            thStattus1 = true;
            errs = "";
            timStart.Enabled = true;
            if (bug == true) { testing(); }
        }
        private void khoitao()
        {
            Clear_SFC();
            txtSFC.Clear();
            bufSFC = "";
            WPSPairingfunction = "";
            StopWEB();
            config2G = false;
            config5G = false;
            config6G = false;
            Wifi2GTXCH1 = 0.0;
            Wifi2GRXCH1 = 0.0;
            Wifi2GTXCH6 = 0.0;
            Wifi2GRXCH6 = 0.0;
            Wifi2GTXCH11 = 0.0;
            Wifi2GRXCH11 = 0.0;
            Wifi5GTXCH36 = 0.0;
            Wifi5GRXCH36 = 0.0;
            Wifi5GTXCH48 = 0.0;
            Wifi5GRXCH48 = 0.0;
            Wifi5GTXCH153 = 0.0;
            Wifi5GRXCH153 = 0.0;
            Wifi6GTXCH5 = 0.0;
            Wifi6GRXCH5 = 0.0;
            Wifi6GTXCH37 = 0.0;
            Wifi6GRXCH37 = 0.0;
            Wifi6GTXCH197 = 0.0;
            Wifi6GRXCH197 = 0.0;
            lbsndut.Text = "-";
            txtresult2GTXCH1.Text = "-"; 
            txtresult2GRXCH1.Text = "-"; 
            txtresult2GTXCH6.Text = "-"; 
            txtresult2GRXCH6.Text = "-"; 
            txtresult2GTXCH11.Text = "-"; 
            txtresult2GRXCH11.Text = "-"; 
            txtresult5GTXCH36.Text = "-"; 
            txtresult5GRXCH36.Text = "-"; 
            txtresult5GRXCH48.Text = "-"; 
            txtresult5GTXCH48.Text = "-"; 
            txtresult5GTXCH153.Text = "-"; 
            txtresult5GRXCH153.Text = "-"; 
            txtresult6GTXCH5.Text = "-"; 
            txtresult6GRXCH5.Text = "-"; 
            txtresult6GTXCH37.Text = "-"; 
            txtresult6GRXCH37.Text = "-"; 
            txtresult6GTXCH197.Text = "-"; 
            txtresult6GRXCH197.Text = "-";
            txtboxcheckdutalive.BackColor = Color.LightYellow;
            txtboxsetupssid.BackColor = Color.LightYellow;
            txtboxchangpassword.BackColor = Color.LightYellow;
            txtboxcheckinformation.BackColor = Color.LightYellow;
            txtboxwifi2g.BackColor = Color.LightYellow;
            txtboxwifi2g.BackColor = Color.LightYellow;
            txtboxwifi5g.BackColor = Color.LightYellow;
            txtboxwifi6g.BackColor = Color.LightYellow;
            txtboxfactoryreset.BackColor = Color.LightYellow;
        }
        private void Status(string key)
        {
            if (btnstatus.InvokeRequired) { btnstatus.Invoke(new Action(() =>
            {
                btnstatus.Text = "";
                btnstatus.Text = key;
            }));}
            else
            {
                btnstatus.Text = "";
                btnstatus.Text = key;
            }
        }
        private void testing()
        {
            //for (int p = 0; p <= 9; p++)
            //{
            bug = false;
            wpspNian();
            timStart.Enabled = true;
            cmmType.Enabled = false;
            bug = false;
            lbTimeShow.Focus();
            CkeckWPSPairing();
            Status("Testing...");
            thStattus1 = true;
            errs = "";
            Pass2GCH1 = false;
            Pass2GCH6 = false;
            Pass2GCH11 = false;
            Pass5GCH36 = false;
            Pass5GCH48 = false;
            Pass5GCH153 = false;
            timStart.Enabled = true;
            suscessfulsetingWifi5G = false;
            suscessfulsetingWifi6G = false;
            txtOutput.Clear();
            countTimeTest = 0;
            cmn.openExe1(pathfile1, "enableDUT");
            timeTest.Enabled = true;
            timStart.Enabled = false;
            testingqq();
            khoitao();
            try
            {
                msg(DateTime.Now.ToString());
                msg("OP testing --> " + OP);
                WPSPairingfunction = "";
                if (ckboxwps.Checked == true)
                {
                    WPSPairingfunction = "WPS Pairing";
                    msgPass(WPSPairingfunction);
                }
                btnstatus.Enabled = true;
                if (!CheckDUTlive()) return;
                if (!WebAutoNian()) return;
                //
                if (Item2G == true)
                {
                    if (!SettingWifi2G("1", "1")) { return; } //
                    Delay(5000);
                    if (!SettingWifi2G_check_ssid("1", "1")) 
                    {
                        if (!SettingWifi2G("1", "1")) { return; }
                        if (!SettingWifi2G_check_ssid("1", "1"))
                        {
                            ErrorNian("Err_Setting_SSID_2G");
                            { return; }
                        }
                    }
                    Enablecard2G();
                    delay(4000);
                    thMutiple1 = new Thread(new ThreadStart(Test2GCH1));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    delay(5000);
                }
                else
                {
                    Pass2GCH1 = true;
                }
                if (Item5G == true)
                {
                    if (!SettingWifi5G("36", "1")) { return; }
                    Delay(5000);
                    if (!SettingWifi5G_check_ssid("36", "1"))
                    {
                        if (!SettingWifi5G("36", "1")) { return; }
                        if (!SettingWifi5G_check_ssid("36", "1"))
                        {
                            ErrorNian("Err_Setting_SSID_5G"); { return; }
                        }
                    }
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_2G_CH1...");
                        if (thStattus1 == false) { return; }
                        if (Pass2GCH1 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_2G_CH1"); }
                    }
                    thMutiple1 = new Thread(new ThreadStart(Test5GCH36));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                }
                else
                {
                    Pass5GCH36 = true;
                }
                if (Item2G == true)
                {
                    if (!SettingWifi2G("6", "1")) { return; }
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_5G_CH36...");
                        if (thStattus1 == false) { return; }
                        if (Pass5GCH36 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_5G_CH36"); }
                    }

                    thMutiple1 = new Thread(new ThreadStart(Test2GCH6));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                }
                else
                {
                    Pass2GCH6 = true;
                    //suscessfulsetingWifi5G = true;
                    //for (int d = 0; d <= 500; d++)
                    //{
                    //    Status("Test_WiFi_5G_CH36...");
                    //    if (thStattus1 == false) { return; }
                    //    if (Pass5GCH36 == true) break;
                    //    else
                    //    {
                    //        Delay(1000);
                    //    }
                    //    if (d >= 500) { ErrorNian("Fail_5G_CH36"); }
                    //}
                }
                if (Item5G == true)
                {
                    if (!SettingWifi5G("48", "1")) { return; }
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_2G_CH6...");
                        if (thStattus1 == false) { return; }
                        if (Pass2GCH6 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_2G_CH6"); }
                    }
                    
                    thMutiple1 = new Thread(new ThreadStart(Test5GCH48));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    if (!SettingWifi2G("11", "1")) { return; }
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_5G_CH48...");
                        if (thStattus1 == false) { return; }
                        if (Pass5GCH48 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_5G_CH48"); }
                    }
                }
                else
                {
                    Pass5GCH48 = true;
                }
                if (Item2G == true)
                {
                    thMutiple1 = new Thread(new ThreadStart(Test2GCH11));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    if (!SettingWifi5G("153", "1")) { return; }
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_2G_CH11...");
                        if (thStattus1 == false) { return; }
                        if (Pass2GCH11 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_2G_CH11"); }
                    }
                }
                else
                {
                    Pass2GCH11 = true;
                }
                if (Item5G == true)
                {
                    txtboxwifi2g.BackColor = Color.Lime;
                    thMutiple1 = new Thread(new ThreadStart(Test5GCH153));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    for (int d = 0; d <= 500; d++)
                    {
                        Status("Test_WiFi_5G_CH153...");
                        if (thStattus1 == false) { return; }
                        if (Pass5GCH153 == true) break;
                        else
                        {
                            Delay(1000);
                        }
                        if (d >= 500) { ErrorNian("Fail_5G_CH153"); }
                    }
                    txtboxwifi5g.BackColor = Color.Lime;
                }
                else
                {
                    Pass5GCH153 = true;
                }
                if (Item6G == true)
                {
                    if (!SettingWifi5GOtherSSID("36", "1")) { return; }
                    //Delay(5000);
                    if (!SettingWifi5G_check_ssid_OBA5GTest("36", "1"))
                    {
                        if (!SettingWifi5GOtherSSID("36", "1")) { return; }
                        if (!SettingWifi5G_check_ssid_OBA5GTest("36", "1"))
                        {
                            ErrorNian("Err_Setting_SSID_5G");
                            { return; }
                        }
                    }

                    if (!SettingWifi6G("5", "1")) { return; }
                    Delay(5000);
                    if (!SettingWifi6G_check_ssid("5", "1"))
                    {
                        if (!SettingWifi6G("5", "1")) { return; }
                        if (!SettingWifi6G_check_ssid("5", "1"))
                        {
                            ErrorNian("Err_Setting_SSID_6G"); return; ;
                        }
                    }
                    if (cmmModem.Text.Contains("CGM4981ROG"))
                    {
                        Delay(30000);
                    }
                    if (!TestWifi6GCH5()) { return; }
                    if (!TestWifi6GCH37()) { return; }
                    if (!TestWifi6GCH197()) { return; }
                }
                txtboxwifi6g.BackColor = Color.Lime;
                if (!checkPingResetTodefault()) { return; }
                Enablecard2G();
                cmmType.Enabled = true;
            }
            catch
            {
                StopPGram();
                //MyMessagesBox.Show("Bat lai chuong trihf")
            }
            //    delay(350000);
            //}
        }
        private void sotting2G()
        {

        }
        private void Save_Time_test(string SnDUT,string reult, string error, string time)
        {
            try
            {
                TotalTest_Time = Convert.ToDouble(time);
                Result = reult;
                Err_code = error;
                string pathfile = Directory.GetCurrentDirectory();
                string path2 = pathfile + "\\Sendjson.exe";
                var weatherForecast = new jsonNian
                {
                    modelName = sModem,
                    route = "OBA_WIFI",
                    station = Computer_name,
                    sn = SnDUT,
                    result = Result,
                    errorCode = Err_code,
                    totalTime = TotalTest_Time,
                    FunctionTime = new List<functionTime>
            {
                new functionTime{name ="ETH1",testTime=DUTalive},
                new functionTime{name ="INITIAL_SETUP",testTime=Loginweb},
                new functionTime{name ="WIFI2GCH1",testTime=TimeWifi2GCH1},
                new functionTime{name ="WIFI2GCH6",testTime=TimeWifi2GCH6},
                new functionTime{name ="WIFI2GCH11",testTime=TimeWifi2GCH11},
                new functionTime{name ="WIFI5GCH36",testTime=TimeWifi5GCH36},
                new functionTime{name ="WIFI5GCH48",testTime=TimeWifi5GCH48},
                new functionTime{name ="WIFI5GCH153",testTime=TimeWifi5GCH153},
                new functionTime{name ="WIFI6GCH5",testTime=TimeWifi6GCH5},
                new functionTime{name ="WIFI6GCH37",testTime=TimeWifi6GCH37},
                new functionTime{name ="WIFI6GCH197",testTime=TimeWifi6GCH197},
                new functionTime{name ="RESET",testTime=FactoryRST},
                new functionTime{name ="TEST_T_TIME",testTime=TotalTest_Time},
            },
                    TestData = new List<testData>
            {
                new testData{itemName ="W2GTXCH01",itemValue=Wifi2GTXCH1 }, 
                new testData{itemName ="W2GRXCH01",itemValue=Wifi2GRXCH1 },
                new testData{itemName ="W2GTXCH06",itemValue=Wifi2GTXCH6 },
                new testData{itemName ="W2GRXCH06",itemValue=Wifi2GRXCH6 },
                new testData{itemName ="W2GTXCH11",itemValue=Wifi2GTXCH11 },
                new testData{itemName ="W2GRXCH11",itemValue=Wifi2GRXCH11 },

                new testData{itemName ="W5GTXCH36",itemValue=Wifi5GTXCH36},
                new testData{itemName ="W5GRXCH36",itemValue=Wifi5GRXCH36},
                new testData{itemName ="W5GTXCH48",itemValue=Wifi5GTXCH48},
                new testData{itemName ="W5GRXCH48",itemValue=Wifi5GRXCH48},
                new testData{itemName ="W5GTXCH153",itemValue=Wifi5GTXCH153},
                new testData{itemName ="W5GRXCH153",itemValue=Wifi5GRXCH153},

                new testData{itemName ="W6GTXCH05",itemValue=Wifi6GTXCH5 },
                new testData{itemName ="W6GRXCH05",itemValue=Wifi6GRXCH5 },
                new testData{itemName ="W6GTXCH37",itemValue=Wifi6GTXCH37 },
                new testData{itemName ="W6GRXCH37",itemValue=Wifi6GRXCH37 },
                new testData{itemName ="W6GTXCH197",itemValue=Wifi6GTXCH197  },
                new testData{itemName ="W6GRXCH197",itemValue=Wifi6GRXCH197  },
            },
                };
                string Data = JsonConvert.SerializeObject(weatherForecast, Formatting.Indented);
                string pathfile1 = Directory.GetCurrentDirectory();
                string file_path = pathfile1 + "\\data.json";
                FileStream fs;
                fs = new FileStream(file_path, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine(Data);
                write.Flush();
                fs.Close();

                Process proci = new Process();
                proci.StartInfo.FileName = path2;
                proci.StartInfo.UseShellExecute = false;
                proci.StartInfo.RedirectStandardInput = true;
                proci.StartInfo.RedirectStandardOutput = true;
                proci.StartInfo.CreateNoWindow = false;
                proci.Start();
                string line = proci.StandardOutput.ReadToEnd();
            }
            catch { }
        }
        private void okok1()
        {
            if (ckboxwps.Checked == true)
            {
                string cc = "3/2/2022 7:30:00 AM";
                string cc1 = "3/2/2022 7:30:00 PM";
                DateTime cc2 = DateTime.Now;
                DateTime ccc1 = Convert.ToDateTime(cc);
                DateTime ccc2 = Convert.ToDateTime(cc1);
                TimeSpan Timee1 = ccc1.TimeOfDay;
                TimeSpan Timee2 = ccc2.TimeOfDay;
                TimeSpan Timee3 = cc2.TimeOfDay;
                if (Timee3 < Timee2 & Timee3 > Timee1)
                {
                    Write("DayOK");
                }
                else
                {
                    Write("");
                }
                ckboxwps.Checked = false;
            }
        }
        private void SummaryWifi()
        {
            string iDATA = "************************Summary***************************" + "\n" +
               "ModelName" + ":" + Modelname.Text + "\n" +
               "Station" + ":" + "'" + Computer_name + "\n" +
               "Sn" + ":" + "'" + lbsndut.Text + "\n"+
               "'Result'" + ":" + "'" + Result + "\n" +
               "'ErrorCode'" + ":" + "'" + Err_code + "\n" +
               "'TotalTime'" + ":" + lbTimecc.Text + "\n" +
               "'Using WPS Pairing'" + ":" + WPSPairingfunction + "\n" +
               "FunctionTime" + ":" + "{" + "\n" +
                     "\t" + "DUTAlive" + "\t" + "TestTime" + ":" + DUTalive + "\n" +
                     "\t" + "Setting_WEB_UI" + "\t" + "TestTime" + ":" + Loginweb + "\n" +
                     "\t" + "Wi-Fi2GTXCH1" + "\t" + "Value" + ":" + Wifi2GTXCH1 + "\n" +
                     "\t" + "Wi-Fi2GRXCH1" + "\t" + "Value" + ":" + Wifi2GRXCH1 + "\t" + "TestTime" + ":" + TimeWifi2GCH1 + "\n\n" +
                      "\t" + "Wi-Fi2GTXCH6" + "\t" + "Value" + ":" + Wifi2GTXCH6 + "\n" +
                     "\t" + "Wi-Fi2GRXCH6" + "\t" + "Value" + ":" + Wifi2GRXCH6 + "\t" + "TestTime" + ":" + TimeWifi2GCH6 + "\n\n" +
                      "\t" + "Wi-Fi2GTXCH11" + "\t" + "Value" + ":" + Wifi2GTXCH11 + "\n" +
                     "\t" + "Wi-Fi2GRXCH11" + "\t" + "Value" + ":" + Wifi2GRXCH11 + "\t" + "TestTime" + ":" + TimeWifi2GCH11 + "\n\n" +

                     "\t" + "Wi-Fi5GTXCH36" + "\t" + "Value" + ":" + Wifi5GTXCH36 + "\n" +
                     "\t" + "Wi-Fi5GRXCH36" + "\t" + "Value" + ":" + Wifi5GRXCH36 + "\t" + "TestTime" + ":" + TimeWifi5GCH36 + "\n\n" +
                      "\t" + "Wi-Fi5GTXCH48" + "\t" + "Value" + ":" + Wifi5GTXCH48 + "\n" +
                     "\t" + "Wi-Fi5GRXCH48" + "\t" + "Value" + ":" + Wifi5GRXCH48 + "\t" + "TestTime" + ":" + TimeWifi5GCH48 + "\n\n" +
                      "\t" + "Wi-Fi5GTXCH153" + "\t" + "Value" + ":" + Wifi5GTXCH153 + "\n" +
                     "\t" + "Wi-Fi5GRXCH153" + "\t" + "Value" + ":" + Wifi5GRXCH153 + "\t" + "TestTime" + ":" + TimeWifi5GCH153 + "\n\n" +

                     "\t" + "Wi-Fi6GTXCH5" + "\t" + "Value" + ":" + Wifi6GTXCH5 + "\n" +
                     "\t" + "Wi-Fi6GRXCH5" + "\t" + "Value" + ":" + Wifi6GRXCH5 + "\t" + "TestTime" + ":" + TimeWifi6GCH5 + "\n\n" +
                       "\t" + "Wi-Fi6GTXCH37" + "\t" + "Value" + ":" + Wifi6GTXCH37 + "\n" +
                     "\t" + "Wi-Fi6GRXCH37" + "\t" + "Value" + ":" + Wifi6GRXCH37 + "\t" + "TestTime" + ":" + TimeWifi6GCH37 + "\n\n" +
                      "\t" + "Wi-Fi6GTXCH197" + "\t" + "Value" + ":" + Wifi6GTXCH197 + "\n" +
                     "\t" + "Wi-Fi6GRXCH197" + "\t" + "Value" + ":" + Wifi6GRXCH197 + "\t" + "TestTime" + ":" + TimeWifi6GCH197 + "\n\n" +
                     "\t" + "Factory_RST" + "\t" + "TestTime" + ":" + FactoryRST + "\n"
                     + "}" + "\n" + "************************End***************************";
            msg(iDATA);

        }
        private void timeTest_Tick(object sender, EventArgs e)
        {
            countTimeTest++;
            if (lbTimecc.InvokeRequired)
            {
                lbTimecc.Invoke(new Action(() => lbTimecc.Text = countTimeTest.ToString()));
            }
            else
            {
                lbTimecc.Text = countTimeTest.ToString();  
            }
            //if (countTimeTest > 800)
            //{
            //    msg("Error Time Test 800 seconds ");
            //    ErrorNian("Error Time Test 800 seconds ");
            //    timStart.Enabled = false;
            //    timeTest.Enabled = false;
            //}
        }
        public void delaySuperTime()
        {
            try
            {
                delay(500);
            }
            catch
            {
                Delay(500);
            }

        }
        public void delay(int utime)
        {
             double star = Environment.TickCount;
            double delay = Environment.TickCount - star;
            while (delay < utime)
            {

                delay = Environment.TickCount - star;
                Application.DoEvents();               
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult va = MessageBox.Show("Do you wan close?", "Close...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                timStart.Enabled = false;
                timeTest.Enabled = false;
                //cmn.kill("Automatic");
                System.Environment.Exit(0);
            }
        }

        private void timStart_Tick(object sender, EventArgs e)
        {
           delay(100);
            //txtComFB.Text = "CLOSE_OK";
            ////timS = true;
            ////if (close == false)
            ////{
            ////    comCmd("close");
            ////    delay(10000);
            ////}
            //while (txtComFB.Text.Contains("CLOSE_OK") /*& timS == true*/)
            //{
            //    //close = true;
            //    timStart.Enabled = false;
            //    //timS = false;
            //    txtComFB.Clear();
            //    testing();
            //}

        }

        private void stopProgramingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopPGram();

        }

        private void StopPGram()
        {
            timStart.Enabled = false;
            timeTest.Enabled = false;
            thStattus1 = false;
            try
            {
                if (thMutiple1.IsAlive)
                {
                    try { thMutiple1.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple2.IsAlive)
                {
                    try { thMutiple2.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple3.IsAlive)
                {
                    try { thMutiple3.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple4.IsAlive)
                {
                    try { thMutiple4.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple5.IsAlive)
                {
                    try { thMutiple5.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple6.IsAlive)
                {
                    try { thMutiple6.Abort(); }
                    catch { }
                }
            }
            catch { }
            try
            {
                if (thMutiple11.IsAlive)
                {
                    try { thMutiple11.Abort(); }
                    catch { }
                }
            }
            catch { }

        }     
        private void StopWEB()
        {
            if (geckoWebBrowser1.InvokeRequired)
            {
                geckoWebBrowser1.Invoke(new Action(() =>
                {
                    geckoWebBrowser1.Navigate("about:blank");
                    geckoWebBrowser1.Document.Cookie = "";
                    geckoWebBrowser1.Document.Cookie.Clone();
                    geckoWebBrowser1.Stop();
                    geckoWebBrowser1.Visible = false;
                }));
            }
            else
            {
                geckoWebBrowser1.Navigate("about:blank");
                geckoWebBrowser1.Document.Cookie = "";
                geckoWebBrowser1.Document.Cookie.Clone();
                geckoWebBrowser1.Stop();
                geckoWebBrowser1.Visible = false;
            }
        }     
        private bool WaitWeb(string title)
        {
            bool a = false;
            bool b = true;
            int count = 0;
            while (b)
            {
                if (geckoWebBrowser1.DocumentTitle.Equals(title))
                {
                    a = true;
                    b = false;
                }
                else
                {
                    count++;              
                    delay(1000);
                    if (count > 1)
                    {
                        a = false;
                        b = false;
                    }
                }

            }
            return a;
        }
        private bool WaitWeb1(string title)
        {
            bool a = false;
            bool b = true;
            int count = 0;
            delay(500);
            while (b)
            {            
                if (geckoWebBrowser1.DocumentTitle.Contains(title))//Troubleshooting > Change Password - XFINITY
                {
                    a = true;
                    b = false;
                    return true;
                }
                else
                {
                    if (count > 1)
                    {
                        a = false;
                        b = false;
                        return false;
                    }
                    count++;
                    delay(1500);
                }
            }
            return a;
        }
        private bool WaitLog(string title1, string title2)
        {            
            bool a = false;
            bool b = true;
            int count = 0;
            delay(500);  
            while (b)
            {
                count++;             
                if (geckoWebBrowser1.DocumentTitle.Contains(title1))
                {
                    a = true;
                    b = false;
                    return true;
                }              
                else if (geckoWebBrowser1.DocumentTitle.Contains(title2))
                {
                    a = true;
                    b = false;
                    return true;
                }
                else
                {
                    if (count > 2)
                    {
                        a = false;
                        b = false;
                        return false;
                    }
                    delay(2000);
                }
            }
            return a;
        }
        private string Check_Cap(string title1, string title2)
        {
            string Check_Cap1 = "Not";
            bool a = false;
            bool b = true;
            int count = 0;
            int u = 0;
            geckoWebBrowser1.Visible = true;
            geckoWebBrowser1.Navigate("about:blank");
            geckoWebBrowser1.Document.Cookie = "";
            geckoWebBrowser1.Navigate("http://10.0.0.1");
            Delay(5000);
            geckoWebBrowser1.Document.DocumentElement.TextContent = "";

            //geckoWebBrowser1.Navigate("http://10.0.0.1");
            //delay(2000);
            //string tt = geckoWebBrowser1.DocumentTitle;
            while (b)
            {
                if (geckoWebBrowser1.DocumentTitle.Equals(title1))
                {
                    a = true;
                    b = false;
                    Check_Cap1 = "Cap";
                }
                else if (geckoWebBrowser1.DocumentTitle.Equals(title2))
                {
                    Check_Cap1 = "Use";
                    a = true;
                    b = false;

                }
                else
                {
                    count++;
                    geckoWebBrowser1.Visible = true;
                    geckoWebBrowser1.Navigate("http://10.0.0.1");
                    delay(5000);
                    if (count > 30)
                    {
                        a = false;
                        b = false;
                    }
                }
            }
            return Check_Cap1;
        }

        public string getKey1(string databuffer, string start, int datalength)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                int data = databuffer.Length;
                int istart = start.Length;
                int value = istart + databuffer.IndexOf(start);
                result = databuffer.Substring(value, datalength);
            }
            return result;
        }
        private bool ResetFactorySeting()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkReset);
                for (int n = 0; n <= 40; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains((linkReset)))
                    {
                        if (WaitLog(DocumentTitleRST, DocumentTitleRST)) { break; }
                        else { if (!LoginWithNewPassword()) ; }
                    }
                    else
                    {
                        if (n == 7)
                        {
                            geckoWebBrowser1.Navigate(linkReset);
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleRST, DocumentTitleRST)) { }
                            else { WebAutoNian(); }
                        }
                        if (n >= 35)
                        {
                            b = false;
                            return false;
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                        Submit_reset.Click();
                        delay(500);
                        try
                        {
                            GeckoInputElement ss = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_title").DomObject);
                            string dd = ss.TextContent;
                            if (dd.Contains("Are You Sure?"))
                            {
                                string okclick = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                delay(200);
                                click.Click();
                                delay(20000);
                                msgPass("Reset_DUT_WEBUI");
                                a = true;
                                b = false;
                                StopWEB();
                                txtboxfactoryreset.BackColor = Color.SkyBlue;
                                return true;
                            }
                        }
                        catch { }
                    }
                    catch (Exception ex)
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_ResetFactory_WEB " + ex);
                            ErrorNian("Err_ResetFactory_WEB");
                            b = false;
                        }
                        geckoWebBrowser1.Navigate(linkReset);
                        delay(3000);
                    }
                }
            }
            else
            {
                return false;
            }

            return a;
        }
        private bool ConfigSSIDPassword()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            geckoWebBrowser1.Navigate("about:blank");
            delay(100);
            geckoWebBrowser1.Document.Cookie = "";
            geckoWebBrowser1.Document.Cookie.Clone();
            try
            {
                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            }
            catch { }
            if (thStattus1 == true)
            {
                Status("Config_SSID_Password...");
                msg("loginWebsite_Config_SSID_Password");
                geckoWebBrowser1.Navigate(linkWeb);
                delay(500);
                for (int n = 0; n <= 45; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWeb))
                    {
                        if (WaitLog(DocumentTitleWEBSSID1, DocumentTitleWEBSSID2))
                        {
                            try
                            {
                                string va = "";
                                va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                if ((va.Contains("username")))
                                {
                                    ErrorNian("Err_config_web_black");
                                    return false;
                                }
                                else if (va.Contains("get_set_up"))
                                {
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                                    geckinputelement.Click();
                                    delay(1000);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Name").DomObject);
                                    geckinputelement.Value = "OBA-Wifi";
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Password").DomObject);
                                    geckinputelement.Value = "password";
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next").DomObject);
                                    geckinputelement.Click();
                                    delay(500);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next_01").DomObject);
                                    geckinputelement.Click();
                                    for (int i = 0; i < 35; i++)
                                    {
                                        Delay(1000);
                                    }
                                    a = true;
                                    b = false;
                                    geckoWebBrowser1.Navigate(linkWeb);
                                    for (int y = 0; y <= 45; y++)
                                    {
                                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb))
                                        {
                                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                                            {
                                                msgPass("Setup_SSID_Password");
                                                return true;
                                            }
                                            else
                                            {
                                                ErrorNian("Err_config_SSID_Password");
                                                return false;
                                            }
                                        }
                                        delay(1000);
                                    }
                                }
                            }
                            catch
                            {
                                cout1++;
                                if (cout1 > 5)
                                {
                                    ErrorNian("Err_config_SSID_Password");
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkWeb);
                                delay(2000);
                            }
                        }
                        else
                        {
                            msg("Err_config_SSID_Password_DocumentTitle_" + DocumentTitleWEBSSID1);
                            ErrorNian("Err_config_SSID_Password");
                            a = false;
                            return false;
                        }
                    }
                    else
                    {
                        if (n == 22)
                        {
                            geckoWebBrowser1.Navigate(linkWeb);
                            delay(3000);
                        }
                        else if (n == 45)
                        {
                            Status("Can't_Setup_Web_UI: " + linkWeb);
                            ErrorNian("Err_config_SSID_Password");
                            a = false;
                            return false;
                        }
                        delay(1000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool LoginWEBFirst()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            string dd = "";
            int cout1 = 0;
            if (thStattus1 == true)
            {
                Status("Login_With_Old_Password");
                msg("Login_With_Old_Password");
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                geckoWebBrowser1.Navigate(linkWeb);
                for (int n = 0; n <= 45; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb))
                    {
                        if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            msg("Old_user: admin");
                            msg("Old_Password: password");
                            string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                            msg(va);
                            break;
                        }
                        else
                        {
                            delay(1000);
                        }
                    }
                    else
                    {
                        if (n == 22)
                        {
                            geckoWebBrowser1.Navigate(linkWeb);
                            delay(8000);
                        }
                        else if (n == 45)
                        {
                            Status("Login_With_Old_Password" + linkWeb);
                            ErrorNian("Login_With_Old_Password");
                            b = false;
                            return false;
                        }
                        delay(1000);
                    }
                }
                for (int r = 0; r <= 9; r++)
                {
                    delay(1000);
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                        geckinputelement.Value = "admin";
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                        geckinputelement.Value = "password";
                        delay(200);
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        delay(4500);
                        try
                        {
                            GeckoInputElement ss = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_message").DomObject);
                            dd = ss.TextContent;
                        }
                        catch
                        {
                            dd = "";
                            if (r >= 1)
                            {
                                if (WaitWeb1(DocumentTitleWEBSSID2))
                                {
                                    Dklognewpassword = false;
                                    msg("Login with new password!!!");
                                    return true;
                                }
                            }
                        }
                        if (dd.Contains("Please change the password"))
                        {
                            GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                            click.Click();
                            Delay(2000);
                            Dklognewpassword = true;
                            break;
                        }
                    }
                    catch
                    {
                        cout++;
                        delay(3000);
                        if (cout > 5)
                        {
                            Status("Login_With_Old_Password");
                            ErrorNian("Login_With_Old_Password");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkWeb);
                        delay(8000);
                    }
                }
                for (int n = 0; n <= 40; n++)
                {
                    try
                    {
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebChangePassword))
                        {
                            msgPass("Change_Password");
                            msg("New_Password: password2");
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("oldPassword").DomObject);
                            geckinputelement.Value = "password";
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("userPassword").DomObject);
                            geckinputelement.Value = "password2";
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("verifyPassword").DomObject);
                            geckinputelement.Value = "password2";
                            delay(500);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_pwd").DomObject);
                            geckinputelement.Click();
                            delay(7000);

                            for (int o1 = 0; o1 <= 30; o1++)
                            {
                                try
                                {
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                    geckinputelement.Click();
                                    delay(10000);
                                    msgPass("Change_New_Pasword");
                                    return true;
                                }
                                catch
                                {
                                    if (n >= 3)
                                    {
                                        Status("Login_Save_New_Password");
                                        ErrorNian("Login_With_Old_Password");
                                        b = false;
                                        return false;
                                    }
                                }
                                delay(1000);
                            }
                            //geckoWebBrowser1.Navigate(linkWeb);
                            //for (int y = 0; y <= 45; y++)
                            //{
                            //    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb))
                            //    {
                            //        if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            //        {
                            //            msgPass("Change_New_Pasword");
                            //            return true;
                            //        }
                            //    }
                            //    delay(1000);
                            //}
                        }
                        else { delay(1000); }
                    }
                    catch
                    {
                        cout1++;
                        delay(3000);
                        if (cout1 > 5)
                        {
                            Status("Login_Save_New_Password");
                            ErrorNian("Login_With_Old_Password");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkWebChangePassword);
                        delay(8000);
                    }
                }
            }
            else
            {
                Status("Login_With_Old_Password");
                return false;
            }
            return a;
        }
        private bool changePasswordWebsite()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;           
            PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            if (thStattus1 == true)
            {
                Status("Change_New_Password...");
                msg("Start_Change_New_Password");              
                while (b)
                {
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("oldPassword").DomObject);
                        geckinputelement.Value = "password";
                        delay(100);
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("userPassword").DomObject);
                        geckinputelement.Value = "password2";
                        delay(100);
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("verifyPassword").DomObject);
                        geckinputelement.Value = "password2";
                        delay(100);
                        msg("New_Password: " + geckinputelement.Value);
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_pwd").DomObject);
                        delay(300);
                        geckinputelement.Click();
                        delay(2000);
                        txtboxchangpassword.BackColor = Color.Lime;
                        msgPass("Change_New_Pasword");
                        a = true;
                        b = false;
                        return true;
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 5)
                        {
                            ErrorNian("Err_Web_Change_Password");
                            b = false;
                        }
                        geckoWebBrowser1.Navigate(linkWebChangePassword);
                        delay(2000);
                        for (int n = 0; n <= 20; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWebChangePassword)) { break; }
                            else { delay(1000); }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool LoginWithNewPassword()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            int cout2 = 1;
            if (thStattus1 == true)
            {
                Status("Login_With_NewPassword");
                msg("Login_With_NewPassword");
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                geckoWebBrowser1.Navigate(linkWeb);
                delay(2000);
                for (int n = 0; n <= 45; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                    {
                        msg("New_user: admin");
                        msg("New_Password: password2");
                        break;
                    }
                    else
                    {
                        if (n == 45)
                        {
                            msg("Err_login_Web_New_Password" + linkWeb);
                            ErrorNian("Err_login_Web_New_Password");
                            a = false;
                            return false;
                        }
                        if (n == 22)
                        {
                            geckoWebBrowser1.Navigate(linkWeb);
                            delay(3000);
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    cout2++;
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                        geckinputelement.Value = "admin";
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                        geckinputelement.Value = "password2";
                        delay(200);
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        for (int p = 0; p <= 20; p++)
                        {
                            if (cout2 == 4)
                            {
                                ErrorNian("Err_login_Web_New_Password");
                                b = false;
                                return false;
                            }
                            else
                            {
                                if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb1))
                                {
                                    msgPass("LoginWithNewPassword");
                                    a = true;
                                    b = false;
                                    return true;
                                }
                                else if (p == 20)
                                {
                                    geckoWebBrowser1.Navigate(linkWeb);
                                    delay(5000);
                                }
                                delay(1000);
                            }
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 5)
                        {
                            ErrorNian("Err_login_Web_New_Password");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkWeb);
                        for (int n = 0; n <= 20; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWeb))
                            {
                                break;
                            }
                            else
                            {
                                delay(1000);
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return a;
        }
        string SNNN = "";
        private bool LoginWithNewPassword1()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            int cout2 = 1;
            if (thStattus1 == true)
            {
                //  Status("Login_With_NewPassword");
                // msg("Login_With_NewPassword");
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                geckoWebBrowser1.Navigate(linkWeb);
                Delay(5000);
                for (int n = 0; n <= 45; n++)
                {
                    msg("Load_web: " + linkWeb + "_" + n);
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                    {
                        try
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                            msg("Load_web: " + linkWeb + "===> OK");
                            delay(1000);
                            break;
                        }
                        catch { delay(1000); }
                    }
                    else
                    {
                        if (n == 22)
                        {
                            geckoWebBrowser1.Navigate(linkWeb);
                            delay(3000);
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    cout2++;
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                        geckinputelement.Value = "admin";
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                        geckinputelement.Value = "password2";
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        msg("Click_input ==> OK");
                        for (int p = 0; p <= 20; p++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb1))
                            {
                                msgPass("LoginWithNewPassword");
                                a = true;
                                b = false;
                                return true;
                            }
                            delay(1000);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 5)
                        {
                            //ErrorNian("Err_login_Web_New_Password");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkWeb);
                        for (int n = 0; n <= 20; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWeb))
                            {
                                break;
                            }
                            else
                            {
                                delay(1000);
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            return a;
        }
        private bool GetMACInforWEBUISW58()
        {
            SNNN = "";
            bool a = false;
            bool b = true;
            int cout1 = 0;
            string wanmac = "";
            string mtamac = "";
            string cmmac = "";
            string sns = "";
            string HW1 = "";
            string boot1 = "";
            if (thStattus1 == true)
            {
                Status("Check_Information_Web_UI...");
                msg("Get_Information_Web_UI");
                geckoWebBrowser1.Navigate(linkInfor);
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkInfor))
                    {
                        if (WaitWeb1(DocumentTitleInfor))
                        {
                            break;
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkInfor);
                                delay(5000);
                            }
                        }
                        else
                        {
                            if (n >= 20)
                            {
                                msg("Err_Get_infor_WEB");
                                ErrorNian("Err_Get_infor_WEB");
                                return false;
                            }
                            if (n == 10)
                            {
                                geckoWebBrowser1.Navigate(linkInfor);
                            }

                        }
                    }
                    else
                    {
                        //if ()
                        //{
                        //    geckoWebBrowser1.Navigate(linkInfor);
                        //}
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement Infor = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        string rr2 = Infor.TextContent.Replace(" ", "").Replace("\t", "").Replace("\n\n\n", "\n").Replace("\n\n", "\n");
                        GeckoInputElement Bootup_wifi2 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByClassName("module forms").ElementAt(1).DomObject);
                        GeckoInputElement Bootup_wifi3 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByClassName("module forms").ElementAt(3).DomObject);
                        var ll1 = Bootup_wifi2.GetElementsByTagName("div");
                        var ll2 = Bootup_wifi3.GetElementsByTagName("div");
                        try
                        {
                            var sn = ll1[3].GetElementsByTagName("span");
                            sns = sn[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { sns = ""; }
                        try
                        {
                            var Mac1 = ll1[4].GetElementsByTagName("span");
                            cmmac = Mac1[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { cmmac = ""; }
                        try
                        {
                            var Mac2 = ll1[5].GetElementsByTagName("span");
                            mtamac = Mac2[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { mtamac = ""; }
                        try
                        {
                            var Mac3 = ll1[6].GetElementsByTagName("span");
                            wanmac = Mac3[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { wanmac = ""; }
                        try
                        {
                            var hardware = ll2[0].GetElementsByTagName("span");
                            HW1 = hardware[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            var bootloatder = ll2[2].GetElementsByTagName("span");
                            boot1 = bootloatder[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { HW = ""; boot1 = ""; sns = ""; }




                        if (sns.Length == 16)
                        {
                            if (sns.Substring(4, 2).Contains("05"))
                            {
                                HW = "2.1";
                            }
                            else
                            {
                                HW = "2.0";
                            }
                        }
                        else
                        {
                            if (sns.Substring(6, 2).Contains("05"))
                            {
                                HW = "2.1";
                            }
                            else
                            {
                                HW = "2.3";
                            }
                        }
                        if (cmmac != "" & mtamac != "" & wanmac != "" & HW1.Equals(HW) & boot1.Equals(boot) & sns != "")
                        {
                            if (sns.Length == SNlength)
                            {
                                if (lbsndut.InvokeRequired)
                                {
                                    lbsndut.Invoke(new Action(() =>
                                    {
                                        lbsndut.Clear();
                                        lbsndut.AppendText(sns);
                                        SNNN = sns;
                                    }));
                                }
                                else
                                {
                                    lbsndut.Clear();
                                    lbsndut.AppendText(sns);
                                    SNNN = sns;
                                }
                                return true;
                            }
                            else
                            {
                                ErrorNian("Err_GetSN_Length");
                                return false;
                            }

                        }
                        else
                        {
                            cout1++;
                            if (cout1 > 3)
                            {
                                ErrorNian("Err_Information");
                                b = false;
                                return false;
                            }
                            geckoWebBrowser1.Navigate(linkInfor);
                            delay(3500);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 5)
                        {
                            ErrorNian("Err_Get_Infor_WEB");
                            b = false;
                            return false;
                        }
                        delay(3000);
                        geckoWebBrowser1.Navigate(linkInfor);
                        for (int n = 0; n <= 20; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkInfor))
                            {
                                break;
                            }
                            else
                            {
                                delay(1000);
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool GetMACInforWEBUI()
        {
            SNNN = "";
            bool a = false;
            bool b = true;
            int cout1 = 0;
            string wanmac = "";
            string mtamac = "";
            string cmmac = "";
            string sns = "";
            string HW1 = "";
            string boot1 = "";
            if (thStattus1 == true)
            {
                Status("Check_Information_Web_UI...");
                msg("Get_Information_Web_UI");
                geckoWebBrowser1.Navigate(linkInfor);
                delay(500);
                for (int n = 0; n <= 20; n++)
                {
                    msg("Load_web: " + linkInfor + "_" + n);
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkInfor))
                    {
                        if (WaitWeb1(DocumentTitleInfor))
                        {
                            msg("Load_web: " + linkInfor + "=> OK");
                            break;
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                msg("Load_web: " + linkInfor + "FAIL ===> Relogin" );
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkInfor);
                                delay(5000);
                            }
                        }
                        else
                        {
                            if (n >= 20)
                            {
                                msg("Err_Get_infor_WEB");
                                ErrorNian("Err_Get_infor_WEB");
                                return false;
                            }
                            if (n == 10)
                            {
                                geckoWebBrowser1.Navigate(linkInfor);
                            }

                        }
                    }
                    else
                    {
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement Bootup_wifi1 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByClassName("module forms").ElementAt(0).DomObject);
                        string rr = Bootup_wifi1.TextContent.Replace(" ", "").Replace("\t", "").Replace("\n\n\n", "\n").Replace("\n\n", "\n");
                        GeckoInputElement Bootup_wifi2 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByClassName("module forms").ElementAt(2).DomObject);
                        string rr1 = Bootup_wifi2.TextContent.Replace(" ", "").Replace("\t", "").Replace("\n\n\n", "\n").Replace("\n\n", "\n");
                        msg("Get_Infor_XFINITY Network => --------------\n\r" + rr +" \n "+ rr1 + "\nGet_Infor_XFINITY Network =>--------------End\n");
                        var ll = Bootup_wifi1.GetElementsByTagName("div");
                        var ll1 = Bootup_wifi2.GetElementsByTagName("div");
                        try
                        {
                            var Mac1 = ll[17].GetElementsByTagName("span");
                            wanmac = Mac1[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("WAN_MAC: " + wanmac);
                            
                        }
                        catch { wanmac = ""; msg("WAN_MAC_Web ==> FAIL"); }
                        try
                        {
                            var Mac2 = ll[18].GetElementsByTagName("span");
                            mtamac = Mac2[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("MTA_MAC: " + mtamac);
                        }
                        catch { mtamac = ""; msg("WAN_MAC_Web ==> FAIL"); }
                        try
                        {
                            var Mac3 = ll[19].GetElementsByTagName("span");
                            cmmac = Mac3[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("CM_MAC: " + cmmac);
                        }
                        catch { cmmac = ""; msg("WAN_MAC_Web ==> FAIL"); }
                        try
                        {
                            var hardware = ll1[0].GetElementsByTagName("span");
                            HW1 = hardware[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("HW: " + HW1);
                            var bootloatder = ll1[2].GetElementsByTagName("span");
                            boot1 = bootloatder[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("Bootloatder: " + boot1);
                            var sn = ll1[8].GetElementsByTagName("span");
                            sns = sn[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            msg("SN: " + sns);
                        }
                        catch { HW = ""; boot = ""; sns = "";}
                        if (sns.Length == 16)
                        {
                            if (sns.Substring(6, 2).Contains("05"))
                            {
                                HW = "2.1";                              
                            }
                            else
                            {
                                HW = "2.0";                              
                            }
                        }
                        else
                        {
                            if (sns.Substring(6, 2).Contains("05"))
                            {
                                HW = "2.1";                            
                            }
                            else
                            {
                                HW = "2.3";                              
                            }
                        }
                        if (cmmac != "" & mtamac != "" & wanmac != ""& HW1.Equals(HW) & boot1.Equals(boot)  & sns != "")
                        {
                            if (sns.Length == SNlength)
                            {
                                if (lbsndut.InvokeRequired)
                                {
                                    lbsndut.Invoke(new Action(() =>
                                    {
                                        lbsndut.Clear();
                                        lbsndut.AppendText(sns);
                                        SNNN = sns;
                                        }));
                                }
                                else
                                {
                                    lbsndut.Clear();
                                    lbsndut.AppendText(sns);
                                    SNNN = sns;
                                }
                                return true;
                            }
                            else
                            {
                                ErrorNian("Err_GetSN_Length");
                                return false;
                            }

                        }
                        else
                        {
                            cout1++;
                            if (cout1 > 3)
                            {
                                ErrorNian("Err_Information");
                                b = false;
                                return false;
                            }
                            geckoWebBrowser1.Navigate(linkInfor);
                            delay(3500);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 5)
                        {
                            ErrorNian("Err_Get_Infor_WEB");
                            b = false;
                            return false;
                        }
                        delay(3000);
                        geckoWebBrowser1.Navigate(linkInfor);
                        for (int n = 0; n <= 20; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkInfor))
                            {
                                break;
                            }
                            else
                            {
                                delay(1000);
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool SettingWifi2G(string Channal,string status)
        {
            config2G = false;
            msg("Setting_Web_2G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;

            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi2G);
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi2G))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 5 || n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi2G);
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkwifi2G);
                                delay(5000);
                            }
                        }
                        if (n >= 20)
                        {
                            //if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi2G);
                                ErrorNian("Err_Setting_Web_2G_firstly" +"_CH" +Channal);
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        if (config2G == false)
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_name").DomObject);
                            geckinputelement.Value = SSID2G;
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_bandwidth20").DomObject);
                            geckinputelement.Click();
                            GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_manual").DomObject);
                            channel_manual.Click();
                            geckoWebBrowser1.Navigate("javascript:void(showDialog())");
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("path5").DomObject);
                            geckinputelement.Click();
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("pop_ok").DomObject);
                            geckinputelement.Click();
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                            geckinputelement.Click();
                            delay(500);
                            GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_number").DomObject);
                            string countCH = channel_number.TextContent.Trim();
                            if (!countCH.Contains("1") | !countCH.Contains("6"))
                            {
                                ErrorNian("Err_WiFi_2GHz_Channel");
                                MyMessagesBox.Show("Fail_Channal: " + countCH);
                                return false;
                            }
                            config2G = true;
                        }
                        var options = geckoWebBrowser1.Document.GetElementsByTagName("option");
                        foreach (GeckoOptionElement optionEl in options)
                        {
                            string aa = optionEl.Value;
                            if (optionEl.Value == Channal)
                            {
                                optionEl.Selected = true;
                                break;
                            }
                        }
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        if (status.Contains("1"))
                        {
                            delay(20000);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {

                            ErrorNian("Err_Setting_Web_2G_firstly" + "_CH" + Channal);
                        b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi2G);
                        delay(3000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }

        private bool SettingWifi5G(string Channal, string status)
        {
            config5G = false;
            msg("Setting_Web_5G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi5G);
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi5G))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkwifi5G);
                                delay(5000);
                            }
                        }
                        if (n == 5 || n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi5G);
                            delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi5G);
                                ErrorNian("Err_Setting_Web_5G_firstly" + "_CH" + Channal);
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        if (config5G == false)
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_name").DomObject);
                            geckinputelement.Value = SSID5G;
                            GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_manual").DomObject);
                            channel_manual.Click();
                            geckoWebBrowser1.Navigate("javascript:void(showDialog())");
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("path5").DomObject);
                            geckinputelement.Click();
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("pop_ok").DomObject);
                            geckinputelement.Click();
                            delay(100);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                            geckinputelement.Click();
                            delay(500);
                            GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_number").DomObject);
                            string countCH = channel_number.TextContent.Trim();
                            if (!countCH.Contains("36") | !countCH.Contains("48") | !countCH.Contains("153"))
                            {
                                ErrorNian("Err_WiFi_5GHz_Channel");
                                MyMessagesBox.Show("Fail_Channal: " + countCH);
                                return false;
                            }
                            config5G = true;
                        }
                        var options = geckoWebBrowser1.Document.GetElementsByTagName("option");
                        foreach (GeckoOptionElement optionEl in options)
                        {
                            string aa = optionEl.Value;
                            if (optionEl.Value == Channal)
                            {
                                optionEl.Selected = true;
                                break;
                            }
                        }
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        if (status.Contains("1"))
                        {
                            delay(20000);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_5G_firstly" + "_CH" + Channal);
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi5G);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi5G_check_ssid_OBA5GTest(string Channal, string status)
        {
            string link = "http://10.0.0.1/wireless_network_configuration.jst";
            msg("Check_Setting_Web_5G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(link);
                delay(1000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(link))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(link);
                                delay(5000);
                            }
                        }
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(link);
                            delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + link);
                                //ErrorNian("Err_Setting_Web_2G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement hhh = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                        string hh = hhh.TextContent.Trim();

                        //geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        //string hh = geckinputelement.Value;
                        msg(hh);
                        if (hh.Contains("OBA5GTest"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_Setting_Web_5G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(link);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi5G_check_ssid(string Channal, string status)
        {
            string link = "http://10.0.0.1/wireless_network_configuration.jst";
            msg("Check_Setting_Web_5G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(link);
                delay(1000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(link))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(link);
                                delay(5000);
                            }
                        }
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(link);
                            delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + link);
                                //ErrorNian("Err_Setting_Web_2G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement hhh = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                        string hh = hhh.TextContent.Trim();

                        //geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        //string hh = geckinputelement.Value;
                        msg(hh);
                        if (hh.Contains(SSID5G))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_Setting_Web_5G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(link);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi6G_check_ssid(string Channal, string status)
        {
            string link = "http://10.0.0.1/wireless_network_configuration.jst";
            msg("Check_Setting_Web_6G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(link);
                delay(1000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(link))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(link);
                                delay(5000);
                            }
                        }
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(link);
                            delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + link);
                                //ErrorNian("Err_Setting_Web_2G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement hhh = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                        string hh = hhh.TextContent.Trim();

                        //geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        //string hh = geckinputelement.Value;
                        msg(hh);
                        if (hh.Contains(SSID6G))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_Setting_Web_6G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(link);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi2G_check_ssid(string Channal, string status)
        {
            string link = "http://10.0.0.1/wireless_network_configuration.jst";
            msg("Check_Setting_Web_2G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(link);
                delay(1000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(link))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(link);
                                delay(5000);
                            }
                        }
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(link);
                            delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + link);
                                //ErrorNian("Err_Setting_Web_2G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement hhh = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                        string hh = hhh.TextContent.Trim();

                        //geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        //string hh = geckinputelement.Value;
                        msg(hh);
                        if (hh.Contains(SSID2G))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_Setting_Web_2G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(link);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi2G_On(string Channal, string status)
        {
            msg("Setting_Web_2G CH:" + Channal);
            log_sum_on_off(lbsndut.Text +"_2G_"+ Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi2G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=2";
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                    string countCH = channel_number.TextContent.Trim();
                    msg(countCH);
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi2G))
                    {
                        break;
                    }

                    //if (countCH.Contains("Private Wi-Fi Network Configuration"))
                    //{
                    //    break;
                    //}
                    else
                    {
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi2G);
                            delay(5000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi2G);
                                ErrorNian("Err_Setting_Web_2G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_enable").DomObject);
                        channel_manual.Click();
                        Delay(1000);
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        return true;
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_2G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi2G);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        bool kq_ther = false;
        private void Test_on_off2G_RX()
        {
            kq_ther = false;
            SettingWifi2G_off("2RX", "");
            Delay(15000);
            SettingWifi2G_On("2RX", "");
            Delay(15000);
            kq_ther = true;
        }
        private void Test_on_off2G_TX()
        {
            kq_ther = false;
            SettingWifi2G_off("2TX", "");
            Delay(15000);
            SettingWifi2G_On("2TX", "");
            Delay(15000);
            kq_ther = true;
        }
        private bool SettingWifi2G_off(string Channal, string status)
        {
            //try
            //{
            //    geckoWebBrowser1.Navigate("about:blank");
            //    delay(100);
            //    geckoWebBrowser1.Document.Cookie = "";
            //    geckoWebBrowser1.Document.Cookie.Clone();
            //    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            //}
            //catch { }
            //LoginWithNewPassword1();

            msg("Setting_Web_2G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                for (int nn = 1; nn <= 2; nn++)
                {
                    try
                    {
                        geckoWebBrowser1.Navigate(linkwifi2G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=2";
                        delay(2000);
                        msg("hihi  ");
                        for (int n = 0; n <= 30; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi2G))
                            {
                                break;
                            }
                            //string countCH = "";
                            //try
                            //{
                            //GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                            //countCH = channel_number.TextContent.Trim();
                            //}
                            //catch { }

                                //msg(countCH);
                                //if (countCH.Contains("Private Wi-Fi Network Configuration"))
                                //{
                                //    break;
                                //}
                            else
                            {
                                if (n == 12)
                                {
                                    LoginWithNewPassword1();
                                    Delay(2000);
                                    geckoWebBrowser1.Navigate(linkwifi2G);
                                    delay(2000);
                                }

                                if (n == 10 || n == 18)
                                {
                                    geckoWebBrowser1.Navigate(linkwifi2G);
                                    delay(2000);
                                }
                                if (n >= 25)
                                {
                                    // if (CheckDUTlive())
                                    {
                                        msg("Can't Navigate " + linkwifi2G);
                                        ErrorNian("Err_Setting_Web_5G");
                                        b = false;
                                        return false;
                                    }
                                }
                            }
                            delay(2000);
                        }
                        while (b)
                        {
                            try
                            {
                                GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_disabled").DomObject);
                                channel_manual.Click();
                                Delay(1000);
                                GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                                save_settings.Click();
                                return true;
                            }
                            catch
                            {
                                cout1++;
                                if (cout1 > 3)
                                {
                                    ErrorNian("Err_Setting_Web_2G");
                                    b = false;
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkwifi2G);
                                delay(3000);
                            }
                        }
                    }
                    catch
                    {
                        //LoginWithNewPassword1();
                        //Delay(2000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi5G_On(string Channal, string status)
        {
            msg("Setting_Web_5G CH:" + Channal);
            log_sum_on_off(lbsndut.Text + "_5G_" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi5G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=2";
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                    string countCH = channel_number.TextContent.Trim();
                    msg(countCH);

                    if (countCH.Contains("Private Wi-Fi Network Configuration"))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi5G);
                            delay(5000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi5G);
                                ErrorNian("Err_Setting_Web_5G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_enable").DomObject);
                        channel_manual.Click();
                        Delay(1000);
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        return true;
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_5G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi5G);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi5G_off(string Channal, string status)
        {
            //try
            //{
            //    geckoWebBrowser1.Navigate("about:blank");
            //    delay(100);
            //    geckoWebBrowser1.Document.Cookie = "";
            //    geckoWebBrowser1.Document.Cookie.Clone();
            //    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            //}
            //catch { }
            //LoginWithNewPassword1();

            msg("Setting_Web_5G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                for (int nn = 1; nn <= 2; nn++)
                {
                    try
                    {
                        geckoWebBrowser1.Navigate(linkwifi5G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=2";
                        delay(2000);
                        for (int n = 0; n <= 20; n++)
                        {
                            //if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi5G))
                            //{
                            //    break;
                            //}
                            string countCH = "";
                            try
                            {
                                GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                                countCH = channel_number.TextContent.Trim();
                            }
                            catch { }
                           
                            msg(countCH);
                            if (countCH.Contains("Private Wi-Fi Network Configuration"))
                            {
                                break;
                            }
                            else
                            {
                                if (n == 12)
                                {
                                    LoginWithNewPassword1();
                                    Delay(2000);
                                    geckoWebBrowser1.Navigate(linkwifi5G);
                                    delay(2000);
                                }
                                if (n == 10 || n == 18)
                                {
                                    geckoWebBrowser1.Navigate(linkwifi5G);
                                    delay(2000);
                                }
                                if (n >= 25)
                                {
                                    // if (CheckDUTlive())
                                    {
                                        msg("Can't Navigate " + linkwifi5G);
                                        ErrorNian("Err_Setting_Web_5G");
                                        b = false;
                                        return false;
                                    }
                                }
                            }
                            delay(1000);
                        }
                        while (b)
                        {
                            try
                            {
                                GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_disabled").DomObject);
                                channel_manual.Click();
                                Delay(1000);
                                GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                                save_settings.Click();
                                return true;
                            }
                            catch
                            {
                                cout1++;
                                if (cout1 > 3)
                                {
                                    ErrorNian("Err_Setting_Web_5G");
                                    b = false;
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkwifi5G);
                                delay(3000);
                            }
                        }
                    }
                    catch
                    {
                        LoginWithNewPassword1();
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi6G_On(string Channal, string status)
        {
            msg("Setting_Web_6G CH:" + Channal);
            log_sum_on_off(lbsndut.Text + "_6G_" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi6G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=17";
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                    string countCH = channel_number.TextContent.Trim();
                    msg(countCH);

                    if (countCH.Contains("Private Wi-Fi Network Configuration"))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi6G);
                            delay(5000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi6G);
                                ErrorNian("Err_Setting_Web_6G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_enable").DomObject);
                        channel_manual.Click();
                        Delay(1000);
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        return true;
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_6G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi6G);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi6G_off(string Channal, string status)
        {
            //try
            //{
            //    geckoWebBrowser1.Navigate("about:blank");
            //    delay(100);
            //    geckoWebBrowser1.Document.Cookie = "";
            //    geckoWebBrowser1.Document.Cookie.Clone();
            //    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            //}
            //catch { }
            //LoginWithNewPassword1();

            msg("Setting_Web_6G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                for (int nn = 1; nn <= 2; nn++)
                {
                    try
                    {
                        geckoWebBrowser1.Navigate(linkwifi6G); // "http://10.0.0.1/wireless_network_configuration_edit.jst?id=17";
                        delay(2000);
                        for (int n = 0; n <= 20; n++)
                        {
                            //if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi5G))
                            //{
                            //    break;
                            //}
                            string countCH = "";
                            try
                            {
                                GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("priwificonf").DomObject);
                                countCH = channel_number.TextContent.Trim();
                            }
                            catch { }
                            msg(countCH);
                            if (countCH.Contains("Private Wi-Fi Network Configuration"))
                            {
                                break;
                            }
                            else
                            {

                                if (n == 12)
                                {
                                    LoginWithNewPassword1();
                                    Delay(2000);
                                    geckoWebBrowser1.Navigate(linkwifi6G);
                                    delay(2000);
                                }
                                if (n == 10 || n == 18)
                                {
                                    geckoWebBrowser1.Navigate(linkwifi6G);
                                    delay(2000);
                                }
                                if (n >= 25)
                                {
                                    // if (CheckDUTlive())
                                    {
                                        msg("Can't Navigate " + linkwifi6G);
                                        ErrorNian("Err_Setting_Web_6G");
                                        b = false;
                                        return false;
                                    }
                                }
                            }
                            delay(1000);
                        }
                        while (b)
                        {
                            try
                            {
                                GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("radio_disabled").DomObject);
                                channel_manual.Click();
                                Delay(1000);
                                GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                                save_settings.Click();
                                return true;
                            }
                            catch
                            {
                                cout1++;
                                if (cout1 > 3)
                                {
                                    ErrorNian("Err_Setting_Web_6G");
                                    b = false;
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkwifi6G);
                                delay(3000);
                            }
                        }
                    }
                    catch
                    {
                        LoginWithNewPassword1();
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi5GOtherSSID(string Channal, string status)
        {
            msg("Setting_Web_5G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            config5G = false;
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi5G);
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi5G))
                    {
                        msg("linkwifi5G load OK");
                        Delay(2000);
                        break;
                    }
                    else
                    {
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkwifi5G);
                                delay(5000);
                            }
                        }
                        if (n == 5 || n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi5G);
                            msg("linkwifi5G reload");
                            delay(3000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi5G);
                                ErrorNian("Err_Setting_Web_5G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        if (config5G == false)
                        {
                            msg("OBA5GTest");
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_name").DomObject);
                            geckinputelement.Value = "OBA5GTest";
                            delay(100);
                            config5G = true;
                        }
                        try
                        {
                            var options = geckoWebBrowser1.Document.GetElementsByTagName("option");
                            foreach (GeckoOptionElement optionEl in options)
                            {
                                string aa = optionEl.Value;
                                if (optionEl.Value == Channal)
                                {
                                    optionEl.Selected = true;
                                    break;
                                }
                            }
                        }
                        catch { }
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();

                        msg("click");
                        if (status.Contains("1"))
                        {
                            delay(20000);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_5G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi5G);
                        delay(3000);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool SettingWifi6G(string Channal,string key)
        {
            config6G = false;
            msg("Setting_Web_6G CH:" + Channal);
            bool a = false;
            bool b = true;
            int cout1 = 0;
            try
            {
                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            }
            catch { }
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi6G);
                delay(2000);
                for (int n = 0; n <= 20; n++)
                {
                    if (n == 15)
                    {
                        if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            LoginWithNewPassword1();
                            geckoWebBrowser1.Navigate(linkwifi6G);
                            delay(5000);
                        }
                    }
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkwifi6G))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 5 || n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi6G);
                            Delay(2000);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi6G);
                                ErrorNian("Err_Setting_Web_6G_firstly" + "_CH" + Channal);
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {
                        if (config6G == false)
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_name").DomObject);
                            geckinputelement.Value = SSID6G;
                            delay(500);
                            GeckoInputElement channel_manual = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_manual").DomObject);
                            channel_manual.Click();
                            delay(500);
                            GeckoInputElement password_show = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password_show").DomObject);
                            channel_manual.Click();
                            delay(500);
                            GeckoInputElement network_password = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_password").DomObject);
                            network_password.Value = "1234567890";
                            delay(500);
                            GeckoInputElement channel_number = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("channel_number").DomObject);
                            string countCH = channel_number.TextContent.Trim();
                            if (!countCH.Contains(CoutCH6G))
                            {
                                MessageBox.Show("Fail_Channal: " + countCH);
                                ErrorNian("Err_WiFi_6GHz_Channel");
                                return false;
                            }
                            config6G = true;
                        }
                        var options = geckoWebBrowser1.Document.GetElementsByTagName("option");
                        foreach (GeckoOptionElement optionEl in options)
                        {
                            string aa = optionEl.Value;
                            if (optionEl.Value == Channal)
                            {
                                optionEl.Selected = true;
                            }
                        }
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        if (key.Contains("1"))
                        {
                            delay(20000);
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg(ex.Message);
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_6G_firstly" + "_CH" + Channal);
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi6G);
                        delay(3000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool SettingWifi6GOtherSSID()
        {
            msg("Setting_Web_6G");
            bool a = false;
            bool b = true;
            int cout1 = 0;
            try
            {
                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            }
            catch { }
            if (thStattus1 == true)
            {
                geckoWebBrowser1.Navigate(linkwifi6G);
                delay(200);
                for (int n = 0; n <= 20; n++)
                {
                    if (n == 15)
                    {
                        if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            LoginWithNewPassword1();
                            geckoWebBrowser1.Navigate(linkwifi6G);
                            delay(5000);
                        }
                    }
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkwifi6G))
                    {
                        break;
                    }
                    else
                    {
                        if (n == 10)
                        {
                            geckoWebBrowser1.Navigate(linkwifi6G);
                        }
                        if (n >= 20)
                        {
                            // if (CheckDUTlive())
                            {
                                msg("Can't Navigate " + linkwifi6G);
                                ErrorNian("Err_Setting_Web_6G");
                                b = false;
                                return false;
                            }
                        }
                    }
                    delay(1000);
                }
                while (b)
                {
                    try
                    {

                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("network_name").DomObject);
                        geckinputelement.Value = "OtherWifi6G";
                        delay(100);
                        GeckoInputElement save_settings = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("save_settings").DomObject); //save_settings
                        save_settings.Click();
                        delay(13000);
                        return true;
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            ErrorNian("Err_Setting_Web_6G");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi6G);
                        delay(3000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool GetSWWEBUI()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                Status("Check_CSW_Web_UI...");
                msg("Check_CSW_Web_UI");
                geckoWebBrowser1.Navigate(linkSW);
                Delay(2000);
                for (int n = 0; n <= 30; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkSW)) // http://10.0.0.1/software.jst
                    {
                        try
                        {
                            GeckoInputElement Bootup_wifi = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("softmess1").DomObject);
                            break;
                        }
                        catch
                        {
                            if (n >= 20)
                            {
                                msg("Err_Get_Infor_WEB_1");
                                ErrorNian("Err_Get_Infor_WEB");
                                return false;
                            }
                            delay(1000);
                        }
                    }
                    else
                    {
                        if (n >= 20)
                        {
                            msg("Err_Get_Infor_WEB_2");
                            ErrorNian("Err_Get_Infor_WEB");
                            return false;
                        }
                        if (n == 7 || n == 15)
                        {
                            geckoWebBrowser1.Navigate(linkSW);
                            delay(7000);
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement Bootup_SW1 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("content").DomObject);
                        GeckoInputElement Bootup_SW = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("software_image").DomObject);
                        string rr = Bootup_SW.TextContent.Trim();

                        ///string rr = Bootup_SW1.TextContent.Replace(" ", "").Replace("\t", "").Replace("\n\n", "\n").Replace("\n\n\n", "\n");
                        msg("Get_System Software Version => --------------\n\r" + rr + "\nSystem Software Version =>--------------End\n");
                        if (Bootup_SW.TextContent.Trim().Contains(SW))
                        {
                            b = false;
                            a = true;
                            return true;
                        }
                        else
                        {
                            msg("Error SW => " + Bootup_SW.TextContent);
                            cout1++;
                            if (cout1 > 3)
                            {
                                msg("Err_Get_Infor_WEB_3");
                                ErrorNian("Err_Get_Infor_WEB");
                                b = false;
                                return false;
                            }
                            geckoWebBrowser1.Navigate(linkSW);
                            delay(3500);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            msg("Err_Get_Infor_WEB_4");
                            ErrorNian("Err_Get_Infor_WEB");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkSW);
                        delay(3500);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
        private bool GeWifiInforWEBUI()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            if (thStattus1 == true)
            {
                Status("Check_wifi_bootup_Web_UI...");
                msg("Check_wifi_bootup_Web_UI");
                geckoWebBrowser1.Navigate(linkwifi);
                for (int n = 0; n <= 20; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkwifi))
                    {
                        if (WaitWeb1(DocumentTitleWifi))
                        {
                            break;
                        }
                        if (n == 15)
                        {
                            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                            {
                                LoginWithNewPassword1();
                                geckoWebBrowser1.Navigate(linkwifi);
                                delay(5000);
                            }
                        }
                        else
                        {
                            if (n >= 20)
                            {
                                msg("Err_Wifi_bootup_WEB");
                                ErrorNian("Err_Wifi_bootup_WEB");
                                return false;
                            }
                            if (n == 10)
                            {
                                geckoWebBrowser1.Navigate(linkwifi);
                            }

                        }
                    }
                    else
                    {
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        GeckoInputElement Bootup_wifi = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                        string rr = Bootup_wifi.TextContent.Replace(" ", "").Replace("\t", "").Replace("\n\n", "\n").Replace("\n\n\n", "\n");
                        msg("Get_Wifi_Private Wi-Fi Network => --------------\n\r" + rr + "\nGet_Private Wi-Fi Network =>--------------End\n");
                        if (rr.Contains("2.4GHz") & rr.Contains("5GHz") & rr.Contains("6GHz"))
                        {
                            if (rr.Contains(SSID6G))
                            {
                                SettingWifi6GOtherSSID();
                            }
                            b = false;
                            a = true;
                            return true;
                        }
                        else
                        {

                            cout1++;
                            if (cout1 > 3)
                            {

                                ErrorNian("Err_Wifi_bootup_WEB");
                                b = false;
                                return false;
                            }
                            geckoWebBrowser1.Navigate(linkwifi);
                            delay(3500);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {

                            ErrorNian("Err_Wifi_bootup_WEB");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi);
                        delay(3500);
                    }
                }
            }
            else
            {

                return false;
            }
            return a;
        }
    


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timStart.Enabled = false;
            timeTest.Enabled = false;
            cmn.kill("Automatic");
        }
        //******************************************************************************************
        //******************************************************************************************
        //******************************************************************************************
        string SN_SFC = "";
        string STB_SN = "";
        string str_SFC = "";
        string buf = "";
        string bufSFC = "";
        string ERR_CODE = "ERRFQA1";
        string Computer_name = Environment.MachineName;

        //******************************************************************************************
        private void Delay(int uTime)
        {
            double start = Environment.TickCount;
            double delay = Environment.TickCount - start;
            while (delay < uTime)
            {
                delay = Environment.TickCount - start;
                Application.DoEvents();
            }
        }
        //******************************************************************************************
        private void btnLogin_Click(object sender, EventArgs e)
        {
            kq_Terminal_SFC = false;
            if (cmmModem.SelectedIndex == -1)
            {
                MessageBox.Show("Hay Chon Modem Name !!Pls");
            }
            if (txtUser.Text.Length == 8)
            {
                if (LoadInforOP())
                {
                    txtUser.ReadOnly = true;
                    btnLogin.Text = "Wait...";
                    btnLogin.Enabled = false;
                    txtUser.Enabled = false;
                    btnLogin.Text = "LoginOK";
                    grKey.Visible = false;
                    bntstat.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Tên tài khoản không đúng.\r\nMời bạn nhập lại.");
                    txtUser.Text = "";
                    txtUser.Focus();
                    return;
                }
                btnLogin.Focus();
                btnLogin.Text = "Waiting...";
                if (cmmType.SelectedIndex == 1)
                {
                    btnLogin.Enabled = false;
                    btnLogin.Text = "Disconnect";
                    btnstatus.Enabled = true;
                    btnLogin.Enabled = false;                    
                    return;
                }
                ThreadStart socket_SFC = new ThreadStart(SFC);
                Thread_SFC = new Thread(socket_SFC);
                Thread_SFC.IsBackground = true;
                Thread_SFC.Start();
                delay(8000);
                for (int i = 0; i <= 10; i++)
                {
                    if (kq_Terminal_SFC == true)
                    {
                        btnLogin.Enabled = false;
                        btnLogin.Text = "Disconnect";
                        btnstatus.Enabled = true;
                        btnLogin.Enabled = false;
                        cmmType.Enabled = false;
                        return;
                    }
                    else
                    {
                        if (i >= 5)
                        {
                            btnLogin.Enabled = true;
                            cmmType.Enabled = true;
                            btnLogin.Text = "Connect";
                            MyMessagesBox.Show("\n\n      Pls.Kiểm tra SFC trạm FQA1_1!!!");
                            return;
                        }
                        delay(1000);
                    }
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản không đúng.\r\nMời bạn nhập lại.");
                txtUser.Text = "";
                txtUser.Focus();
                return;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 8)
            {
                btnLogin.Focus();
            }
        }

        /// //////////////SFC
        public static TcpListener listener_SFC;
        public static Socket socket_SFC;
        public static NetworkStream stream_SFC;
        public static StreamReader reader_SFC;
        public static StreamWriter writer_SFC;
        Thread Thread_SFC = null;
        bool kq_Terminal_SFC = false;
        int c_sfc = 0;
        bool st1 = false;
        public void SFC()
        {
            Terminal_SFC();
        }
        public bool Terminal_SFC()
        {
            bool a = false;
            string str = "";
            while (true)
            {
                try
                {
                    // string read_config = Read_file_config_sfc("config.txt").Replace(" ", "").Trim();
                    name_connection_SFC("Connection Fail!");
                    Clear_SFC();
                    IPAddress address = IPAddress.Parse("0.0.0.0");
                    listener_SFC = new TcpListener(address, 55962);
                    // 1. listen
                    listener_SFC.Start();
                    socket_SFC = listener_SFC.AcceptSocket();
                    // string socket2 = socket.RemoteEndPoint.ToString(); //get ip connection

                    name_connection_SFC("Connection Ok!");
                    stream_SFC = new NetworkStream(socket_SFC);
                    reader_SFC = new StreamReader(stream_SFC);
                    reader_SFC.BaseStream.ReadTimeout = 3000;
                    writer_SFC = new StreamWriter(stream_SFC);
                    writer_SFC.AutoFlush = true;
                    byte[] data = encoding.GetBytes("config");
                    stream_SFC.Write(data, 0, data.Length);
                    Write_logfile_SFC("Send: config");
                    Delay(500);
                    // 2. receive
                    str = reader_SFC.ReadLine();
                    Write_logfile_SFC("Receive: " + str);
                    msg_SFC(str);
                    ////////////////////// 
                    if (str.Contains("@_@") && str.Contains("WF"))
                    {
                        kq_Terminal_SFC = true;
                        stream_SFC.Close();
                        socket_SFC.Close();
                        listener_SFC.Stop();
                        return true;
                        //while (true)
                        //{
                        //    try
                        //    {
                        //        writer_SFC.Write("\r\n");
                        //        Delay(1000);
                        //    }
                        //    catch
                        //    {
                        //        name_connection_SFC("Connection Fail!");
                        //        stream_SFC.Close();
                        //        socket_SFC.Close();
                        //        listener_SFC.Stop();
                        //        break;
                        //    }
                        //}
                    }
                    else
                    {
                        kq_Terminal_SFC = false;
                        st1 = true;
                        name_connection_SFC("Connection Fail!");
                        stream_SFC.Close();
                        socket_SFC.Close();
                        listener_SFC.Stop();
                        MyMessagesBox.Show("\n         --) Sai trạm FQA1_1 (--\n\nPls.Call IT chuyển về trạm FQA1_1!!");
                        return false;
                        //break;
                    }
                }
                catch (Exception ex)
                {
                    kq_Terminal_SFC = false;
                    msg_SFC("Disconnection: " + ex);
                    listener_SFC.Stop();
                    return false;
                }
                return a;
            }
        }

        private string SFC_tring(string data)
        {
            string result = "";
            try
            {
                IPAddress address = IPAddress.Parse("0.0.0.0");
                listener_SFC = new TcpListener(address, 55962);
                // 1. listen
                listener_SFC.Start();
                socket_SFC = listener_SFC.AcceptSocket();
                // string socket2 = socket.RemoteEndPoint.ToString(); //get ip connection

                name_connection_SFC("Connection Ok!");
                stream_SFC = new NetworkStream(socket_SFC);
                reader_SFC = new StreamReader(stream_SFC);
                writer_SFC = new StreamWriter(stream_SFC);
                writer_SFC.AutoFlush = true;
                Write_logfile_SFC("Send: " + data);
                Delay(500);
                // 2. receive
                result = reader_SFC.ReadLine();
                Write_logfile_SFC("Receive: " + result);
                msg_SFC(result);
            }
            catch
            {
                result = "";
            }
            return result;
        }
        public void Write_logfile_SFC(string WriteFile)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string file_pathh = @"D:\logfile_SFC\";
            string file_path = @"D:\logfile_SFC\" + date + "_log.txt";
            string path = file_path;
            if (!System.IO.Directory.Exists(file_pathh))
            {
                System.IO.Directory.CreateDirectory(file_pathh);
            }
            try
            {
                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Append);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time + ":  " + WriteFile + "\r\n");
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Append);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time + ":  " + WriteFile + "\r\n");
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
        private void send_data_SN_SFC(string data)
        {
            writer_SFC.Write("\x1b\x07" + data.PadRight(25, ' ') + "\r\n");
            //writer_SFC.Write(data + "\r\n");
            Write_logfile_SFC("Send: " + "\x1b\x07" + data.PadRight(25, ' ') + "\r\n");
            Delay(500);
            //string strrrr = reader_SFC.ReadLine();
            //Write_logfile_SFC("Resend: " + strrrr);
            //msg_SFC(strrrr.Replace("\0", "") + "\r\n");
        }
        private void send_data_SFC_PASS(string data)
        {
            writer_SFC.Write("\x1b\x07" + data.PadRight(25, ' ') + Computer_name + "\r\n");
            Write_logfile_SFC("Send: " + "\x1b\x07" + data.PadRight(25, ' ') + Computer_name + "\r\n");
            Delay(500);
        }
        private void send_data_SFC_FAIL(string data, string err)
        {
            writer_SFC.Write("\x1b\x07" + data.PadRight(25, ' ') + Computer_name + err + "\r\n");
            Write_logfile_SFC("Send: " + "\x1b\x07" + data.PadRight(25, ' ') + Computer_name + err + "\r\n");
            Delay(500);
        }

        private string Get_data_SFC()
        {
            string strrrrr = "";
            string strrrrr_2 = "";
            strrrrr = reader_SFC.ReadLine().ToString();
            delay(500);
            strrrrr_2 = reader_SFC.ReadLine();
            Write_logfile_SFC("Receive: " + strrrrr);
            msg_SFC(strrrrr.Replace("\0", "") + "\r\n");
            msg("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
            Write_logfile_SFC("Receive: " + strrrrr_2);
            msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
            msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
            return strrrrr;
        }
        private string Get_data_SFC1()
        {
            string strrrrr = "";
            string strrrrr_2 = "";
            string strrrrr_3 = "";
            string strrrrr_4 = "";
            string strrrrr_5 = "";
            try
            {
                delay(100);
                strrrrr = reader_SFC.ReadLine().ToString();
                delay(100);
                strrrrr_2 = reader_SFC.ReadLine();
                delay(100);
                Write_logfile_SFC("Receive: " + strrrrr);
                msg_SFC(strrrrr.Replace("\0", "") + "\r\n");
                msg("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
                Write_logfile_SFC("Receive: " + strrrrr_2);
                msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
                msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
                strrrrr_3 = reader_SFC.ReadLine();
                delay(100);
                strrrrr_4 = reader_SFC.ReadLine();
                delay(100);
                strrrrr_5 = reader_SFC.ReadLine();
            }
            catch
            {
                return strrrrr;
            }
            return strrrrr;
        }

        private void msg_SFC(string Message)
        {
            if (SFC_result.InvokeRequired)
            {
                SFC_result.Invoke(new Action(() => SFC_result.AppendText(Message + "\r\n")));
            }
            else
                SFC_result.AppendText(Message + "\r\n");
            if (txtSFC.InvokeRequired)
            {
                txtSFC.Invoke(new Action(() => txtSFC.AppendText(Message + "\r\n")));
            }
            else
                txtSFC.AppendText(Message + "\r\n");
        }
        private void name_connection_SFC(string Message)
        {
            if (name_connection.InvokeRequired)
            {
                name_connection.Invoke(new Action(() => name_connection.Text = Message));
            }
            else
                name_connection.Text = Message;
        }
        private void Clear_SFC()
        {
            if (SFC_result.InvokeRequired)
            {
                SFC_result.Invoke(new Action(() => SFC_result.Clear()));
            }
            else
                SFC_result.Clear();
        }
        private string Read_file_config_sfc(string Information1)//doc txt labview gui ve
        {
            int dem = 0;
            string a = "";
            while (dem < 5)
            {
                dem++;
                try
                {
                    string partSignalstart = Application.StartupPath + @"\" + Information1;
                    FileStream fs = new FileStream(partSignalstart, FileMode.Open);
                    StreamReader Read_File = new StreamReader(fs, Encoding.UTF8);
                    String Read_Signal = Read_File.ReadToEnd();
                    a = Read_Signal;
                    Read_File.Close();
                    dem = 10;
                    return a;
                }
                catch
                {
                    Delay(100);
                }

            }
            return a;
        }
        //******************************************************************************************
        private bool  connectComPort()
        {
            st1 = false;
            bool a = false;
            btnLogin.Focus();
            btnLogin.Text = "Waiting...";
            if (cmmType.SelectedIndex == 1) { return true; }
            else
            {
                if (!Terminal_SFC()) return false;
                else
                {
                    a= true;
                 //   btnstatus.Enabled = true;
                   // btnLogin.Enabled = false;
                    return true;
                }
                //if (kq_Terminal_SFC == false)
                //{
                //    Terminal_SFC();
                //   // ThreadStart socket_SFC = new ThreadStart(Terminal_SFC);
                //    //Thread_SFC = new Thread(socket_SFC);
                //    //Thread_SFC.IsBackground = true;
                //    //Thread_SFC.Start();
                //}
            }
            try
            {
                //delay(2000);
                //if (kq_Terminal_SFC == true)
                //{
                //    btnLogin.Text = "Disconnect";
                //    btnstatus.Enabled = true;
                //    btnLogin.Enabled = false;
                //    return;
                //}
                //else
                //{
                //    btnLogin.Enabled = true;
                //    btnLogin.Text = "Connect";
                //    if (st1 = true)
                //    {
                //        MyMessagesBox.Show("\n\n  Pls.Kiem tra ETh SFC!!");
                //    }
                //    return;
                //}
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                btnLogin.Text = "Connect";
                return false;
            }
            return a;
        }

        //******************************************************************************************
        private void cbbComSFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbbComSFC
            //serialsfc.PortName = cbbComSFC.SelectedItem.ToString();

            //if (!serialsfc.IsOpen)
            //{
            //    serialsfc.Close();
            //    comSfcConnect(cmbComport.Items[cbbComSFC.SelectedIndex].ToString(), 9600);
            //    delay(1000);
            //}


        }
        //******************************************************************************************
        private void ComSFC_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /* try
             {
                 buf = "";
                 buf = ComSFC.ReadExisting();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             * */
        }
        //******************************************************************************************
        private void Khoitao()
        {
           
            txtHistory.AppendText("ID worker: " + txtUser.Text);
            txtHistory.AppendText("\r\n");
            SFC_flag = false;
        }
        //******************************************************************************************
        //private string Send_To_SFC(string cmd)
        //{
        //    string strrrrr = "";
        //    string strrrrr_2 = "";
        //    string strrrrr_3 = "";
        //    string strrrrr_4 = "";
        //    string strrrrr_5 = "";
        //    try
        //    {
        //        IPAddress address = IPAddress.Parse("0.0.0.0");
        //        listener_SFC = new TcpListener(address, 55962);
        //        // 1. listen
        //        listener_SFC.Start();
        //        socket_SFC = listener_SFC.AcceptSocket();
        //        // string socket2 = socket.RemoteEndPoint.ToString(); //get ip connection

        //        name_connection_SFC("Connection Ok!");
        //        stream_SFC = new NetworkStream(socket_SFC);
        //        reader_SFC = new StreamReader(stream_SFC);
        //        reader_SFC.BaseStream.ReadTimeout = 3000;
        //        writer_SFC = new StreamWriter(stream_SFC);
        //        writer_SFC.AutoFlush = true;
        //      //  byte[] data = encoding.GetBytes("config");
        //       // stream_SFC.Write(data, 0, data.Length);
        //       // Write_logfile_SFC("Send: config");
        //        Delay(500);
        //        // 2. receive
        //        buf = "                        ";
        //        msg("Data_Send_SFC: " + cmd);
        //        writer_SFC.Write("\x1b\x07" + cmd + "\r\n");
        //        Write_logfile_SFC("Send: " + "\x1b\x07" + cmd + "\r\n");             
        //        try
        //        {
        //            delay(100);
        //            strrrrr = reader_SFC.ReadLine().ToString().Trim();                
        //            delay(100);
        //            strrrrr_2 = reader_SFC.ReadLine().Trim();                   
        //            delay(100);
        //            Write_logfile_SFC("Receive: " + strrrrr);
        //            msg_SFC(strrrrr.Replace("\0", "") + "\r\n");
        //            msg("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
        //            Write_logfile_SFC("Receive: " + strrrrr_2);
        //            msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
        //            msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
        //            //strrrrr_3 = reader_SFC.ReadLine();
        //            //delay(100);
        //            //strrrrr_4 = reader_SFC.ReadLine();
        //            //delay(100);
        //            //strrrrr_5 = reader_SFC.ReadLine();
        //        }
        //        catch
        //        {
        //            name_connection_SFC("Connection Fail!");
        //            stream_SFC.Close();
        //            socket_SFC.Close();
        //            listener_SFC.Stop();
        //            return strrrrr ;
        //        }
        //        stream_SFC.Close();
        //        socket_SFC.Close();
        //        listener_SFC.Stop();
        //        return strrrrr;
        //    }
        //    catch (Exception ex)
        //    {
        //        name_connection_SFC("Connection Fail!");
        //        MessageBox.Show("Gửi dữ liệu lên SFC Fail\r\n" + ex.Message);
        //        stream_SFC.Close();
        //        socket_SFC.Close();
        //        listener_SFC.Stop();
        //        return strrrrr;
        //    }
        //    return strrrrr;
        //}
        private string Send_To_SFC(string cmd)
        {
            string strrrrr = "";
            string strrrrr_2 = "";
            string strrrrr_3 = "";
            string strrrrr_4 = "";
            string strrrrr_5 = "";
            try
            {
                IPAddress address = IPAddress.Parse("0.0.0.0");
                listener_SFC = new TcpListener(address, 55962);
                //// 1. listen`
                listener_SFC.Start();
                for (int o = 0; o < 4; o++)
                {
                    try
                    {
                        socket_SFC = listener_SFC.AcceptSocket();
                        msg("Connect SFC ==> ok");
                        break;
                    }
                    catch
                    {
                        if (o == 3)
                        {
                            msg("Send_To_SFC_Error");
                            ErrorNian("Err_Send_SFC_Pass");
                        }
                        else
                        {
                            delay(2000);
                        }
                    }
                }

                //// string socket2 = socket.RemoteEndPoint.ToString(); //get ip connection

                name_connection_SFC("Connection Ok!");
                stream_SFC = new NetworkStream(socket_SFC);
                reader_SFC = new StreamReader(stream_SFC);
                //reader_SFC.BaseStream.ReadTimeout = 20000;
                writer_SFC = new StreamWriter(stream_SFC);
                writer_SFC.AutoFlush = true;
                ////  byte[] data = encoding.GetBytes("config");
                //// stream_SFC.Write(data, 0, data.Length);
                //// Write_logfile_SFC("Send: config");
                // Delay(2000);
                // 2. receive
                buf = "                        ";
                writer_SFC.Write("\x1b\x07" + cmd + "\r\n");
                msg("Data_Send_SFC: " + cmd);
                Write_logfile_SFC("Send: " + "\x1b\x07" + cmd + "\r\n");
                try
                {
                    reader_SFC.BaseStream.ReadTimeout = 7000;
                    delay(2000);
                    strrrrr = reader_SFC.ReadLine().ToString().Trim();
                    Write_logfile_SFC("Receive: " + strrrrr);
                    msg_SFC(strrrrr.Replace("\0", "") + "\r\n");
                    msg("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
                    delay(1000);
                    reader_SFC.BaseStream.ReadTimeout = 2000;
                    strrrrr_2 = reader_SFC.ReadLine().ToString().Trim();
                    Write_logfile_SFC("Receive: " + strrrrr_2);
                    msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
                    msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
                    //strrrrr_3 = strrrrr +"\n\r"+ strrrrr_2;
                    //return strrrrr_3;
                    //strrrrr_3 = reader_SFC.ReadLine();
                    //delay(100);
                    //strrrrr_4 = reader_SFC.ReadLine();
                    //delay(100);
                    //strrrrr_5 = reader_SFC.ReadLine();
                }
                catch
                {
                    msg("Connection Fail!..");
                    name_connection_SFC("Connection Fail!");
                    Write_logfile_SFC("Receive: " + strrrrr);
                    Write_logfile_SFC("Receive: " + strrrrr_2);
                    stream_SFC.Close();
                    socket_SFC.Close();
                    listener_SFC.Stop();
                    strrrrr_3 = strrrrr + "\n\r" + strrrrr_2;
                    return strrrrr_3;
                }
                stream_SFC.Close();
                socket_SFC.Close();
                listener_SFC.Stop();
                strrrrr_3 = strrrrr + "\n\r" + strrrrr_2;
                return strrrrr_3;
            }
            catch (Exception ex)
            {
                msg("Gửi dữ liệu lên SFC Fail\r\n" + ex.Message);
                name_connection_SFC("Connection Fail!");
                MessageBox.Show("Gửi dữ liệu lên SFC Fail\r\n" + ex.Message);
                listener_SFC.Stop();
                strrrrr_3 = strrrrr + "\n\r" + strrrrr_2;
                return strrrrr_3;
            }
            strrrrr_3 = strrrrr + "\n\r" + strrrrr_2;
            return strrrrr_3;
        }
        //******************************************************************************************
        private bool Check_SN(string SN_Box)
        {
            str_SFC = "";
            bool a = false;
            SN_SFC = SN_Box;
            SN_SFC = SN_SFC.PadRight(25, ' ');
            //Send_To_SFC(SN_SFC + "\r");
            for (int i = 0; i <= 1; i++)
            {
                str_SFC = "";
                str_SFC = Send_To_SFC(SN_SFC);
                delay(500);
               // str_SFC = Get_data_SFC1();
                if (!str_SFC.Contains("ERRO"))
                {
                    if (str_SFC.Contains("PASS") & str_SFC.Contains(SN_Box))
                    {
                        a = true;
                        txtboxcheckinformation.BackColor = Color.Lime;
                        return true;
                    }
                    else
                    {
                        if (i >= 1)
                        {
                            MessageBox.Show("      Sai lưu trinh!! \n" + SFC_result.Text);
                            msg(SFC_result.Text);
                            return false;
                        }
                        delay(1000);
                    }
                }
                else
                {
                    if (i >= 1)
                    {
                        MessageBox.Show("      Sai lưu trinh!! \n" + SFC_result.Text);
                        msg(SFC_result.Text);
                        return false;
                    }
                    delay(1000);
                }

            }
            return a;
        }
        //******************************************************************************************
        private bool Check_Feedback(string chuoi)
        {
            try
            {
                string temp = chuoi.Trim(); if ((temp.Contains("PASS")) | (temp.Contains("FAIL") | (temp.Contains("ERR"))))//ERR
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhận dữ liệu Fail\r\n" + ex.Message);
                return false;
            }
        }
        private void TakeDatasfc()
        {
            STB_SN = lbsndut.Text.PadRight(25, ' ');
            note = "".PadRight(20, ' ');
            WF2GCh1TX = Math.Round(Wifi2GTXCH1, 0).ToString().Trim().PadRight(10, ' ');
            WF2GCh1RX = Math.Round(Wifi2GRXCH1, 0).ToString().Trim().PadRight(10, ' ');
            WF2GCh6TX = Math.Round(Wifi2GTXCH6, 0).ToString().Trim().PadRight(10, ' ');
            WF2GCh6RX = Math.Round(Wifi2GRXCH6, 0).ToString().Trim().PadRight(10, ' ');
            WF2GCh11TX = Math.Round(Wifi2GTXCH11, 0).ToString().Trim().PadRight(10, ' ');
            WF2GCh11RX = Math.Round(Wifi2GRXCH11, 0).ToString().Trim().PadRight(10, ' ');

            WF5GCh36TX = Math.Round(Wifi5GTXCH36, 0).ToString().Trim().PadRight(10, ' ');
            WF5GCh36RX = Math.Round(Wifi5GRXCH36, 0).ToString().Trim().PadRight(10, ' ');
            WF5GCh48TX = Math.Round(Wifi5GTXCH48, 0).ToString().Trim().PadRight(10, ' ');
            WF5GCh48RX = Math.Round(Wifi5GRXCH48, 0).ToString().Trim().PadRight(10, ' ');
            WF5GCh153TX = Math.Round(Wifi5GTXCH153, 0).ToString().Trim().PadRight(10, ' ');
            WF5GCh153RX = Math.Round(Wifi5GRXCH153, 0).ToString().Trim().PadRight(10, ' ');

            WF6GCh5TX = Math.Round(Wifi6GTXCH5, 0).ToString().Trim().PadRight(10, ' ');
            WF6GCh5RX = Math.Round(Wifi6GRXCH5, 0).ToString().Trim().PadRight(10, ' ');
            WF6GCh37TX = Math.Round(Wifi6GTXCH37, 0).ToString().Trim().PadRight(10, ' ');
            WF6GCh37RX = Math.Round(Wifi6GRXCH37, 0).ToString().Trim().PadRight(10, ' ');
            WF6GCh197TX = Math.Round(Wifi6GTXCH197, 0).ToString().Trim().PadRight(10, ' ');
            WF6GCh197RX = Math.Round(Wifi6GRXCH197, 0).ToString().Trim().PadRight(10, ' ');
        }
        //******************************************************************************************
        private bool Send_To_SFC_PASS()
        {
            if (cmmType.SelectedIndex == 1)
            {
                return true;
            }
            else
            {
                msg("Send_To_SFC_PASS:" + lbsndut.Text);
                TakeDatasfc();
                string data = (STB_SN + WF2GCh1TX + WF2GCh1RX + "1  " +
                WF2GCh6TX + WF2GCh6RX + "6  " +
                WF2GCh11TX + WF2GCh11RX + "11 " +
                WF5GCh36TX + WF5GCh36RX + "36 " +
                WF5GCh48TX + WF5GCh48RX + "48 " +
                WF5GCh153TX + WF5GCh153RX + "153" +
                WF6GCh5TX + WF6GCh5RX + "5  " +
                WF6GCh37TX + WF6GCh37RX + "37 " +
                WF6GCh197TX + WF6GCh197RX + "197" +
               note + Computer_name + "\r");
                bufSFC = Send_To_SFC(data);
                msg("SFC_PASS_STB_SN:" + STB_SN);
                //msg("SFC_PASS_lbSN.Text:" + lbsndut.Text);
                //msg("SFC_PASS_LbSN:" + lbsndut);
                if (Check_Feedback(bufSFC))
                {
                    return true;
                }
                else
                {
                    msg("SFC_PASS_buf:" + bufSFC);
                   // MessageBox.Show("Send data Error!!");
                    return false;
                }
            }
        }

        //******************************************************************************************
        private bool Send_To_SFC_FAIL(string err)
        {
            msg("Send_To_SFC_FAIL:" + lbsndut.Text+ " " + err);
            TakeDatasfc();
            bufSFC = Send_To_SFC(STB_SN + WF2GCh1TX + WF2GCh1RX + "1  " +
            WF2GCh6TX + WF2GCh6RX + "6  " +
            WF2GCh11TX + WF2GCh11RX + "11 " +
            WF5GCh36TX + WF5GCh36RX + "36 " +
            WF5GCh48TX + WF5GCh48RX + "48 " +
            WF5GCh153TX + WF5GCh153RX + "153" +
            WF6GCh5TX + WF6GCh5RX + "5  " +
            WF6GCh37TX + WF6GCh37RX + "37 " +
            WF6GCh197TX + WF6GCh197RX + "197" +
            note + Computer_name + err + "\r");
            if (Check_Feedback(bufSFC))
            {
                return true;
            }
            else
            {
                msg("SFC_PASS_buf:" + bufSFC);
                MessageBox.Show("Send data Error!!");
                return false;
            }
        }
        private bool Send_To_SFC_FAIL11(string err)
        {
            msg("Send_To_SFC_FAIL:" + lbsndut.Text + " " + err);
            STB_SN = lbsndut.Text.PadRight(35, ' ');
            if (err.Length < 5 | err.Length > 7)
            {
                err = "ERRNOTDEFINE";
            }
            bufSFC = Send_To_SFC(STB_SN + "FUNCTIONFAIL" + Computer_name + err + "\r");
            Delay(2000);
            if (Check_Feedback(bufSFC))
            {
                Initial();
               
                return true;
            }
            else
            {
                Initial();
             
                return false;
            }
        }
        //******************************************************************************************
        private void Initial()
        {
            ERR_CODE = "";
            STB_SN = "";
            SN_SFC = "";
           
        }
        //*****************************************************************************************       
        private void Send_ErrCode(string ERR_CODE)
        {
            msg("Send data to SFC: Waiting Result...");
            if (Send_To_SFC_FAIL(ERR_CODE))
            {
                msg("Send data to SFC: PASS");
            }
            else
            {
                msg("Send data to SFC: FAIL");
            }
        }
        //*********************************************************************************************
        private void Check_ERRCODE(string err)
        {
            ///maloi    hhh
            ERR_CODE = "";
             nk = true;
            if (err == "Err_GetSN_MIB") ERR_CODE = "FSNMIB";
            if (err == "Err_SN_Length") ERR_CODE = "SNLENG";
            if (err == "Err_wifi_password") ERR_CODE = "FPASSM";
            if (err == "Login_With_Old_Password") ERR_CODE = "FLOG02";
            if (err == "Err_USB_TypeC") ERR_CODE = "FUSB00";
            if (err == "Err_config_SSID_Password") ERR_CODE = "EWEB00";//EWEB00
            if (err == "Err_config_web_black") ERR_CODE = "EWEBBL";



            if (err == "Err_login_Web_First") ERR_CODE = "EWEB01";
            if (err == "Err_Web_Change_Password") ERR_CODE = "EWEB02";
            if (err == "Err_login_Web_New_Password") ERR_CODE = "EWEB03";
            if (err == "Err_Wifi_bootup_WEB") ERR_CODE = "EWEWFB";

            if (err == "Err_Ckeck_DUT_Alive") ERR_CODE = "EH0001";
            if (err == "Err_Get_Infor_WEB") ERR_CODE = "INFO01";
            if (err == "Err_SN_Length") ERR_CODE = "SNLENG";

            if (err == "Err_WiFi_2GHz_Channel") ERR_CODE = "WF2GCH";
            if (err == "Err_Ping_WiFi_2GHz_Channel_1") ERR_CODE = "W2PI01";
            if (err == "Err_Ping_WiFi_2GHz_Channel_6") ERR_CODE = "W2PI06";
            if (err == "Err_Ping_WiFi_2GHz_Channel_11") ERR_CODE = "W2PI11";
            if (err == "Err_WiFi_2GHz_Channel_1_TX_Value") ERR_CODE = "W2T011";
            if (err == "Err_WiFi_2GHz_Channel_1_TX_Value_not") ERR_CODE = "NW2T01";
            if (err == "Err_WiFi_2GHz_Channel_1_RX_Value") ERR_CODE = "W2R012";
            if (err == "Err_WiFi_2GHz_Channel_1_RX_Value_not") ERR_CODE = "NW2R01";
            if (err == "Err_WiFi_2GHz_Channel_6_TX_Value") ERR_CODE = "W2T061";
            if (err == "Err_WiFi_2GHz_Channel_6_TX_Value_not") ERR_CODE = "NW2T06";
            if (err == "Err_WiFi_2GHz_Channel_6_RX_Value") ERR_CODE = "W2R062";
            if (err == "Err_WiFi_2GHz_Channel_6_RX_Value_not") ERR_CODE = "NW2R06";
            if (err == "Err_WiFi_2GHz_Channel_11_TX_Value") ERR_CODE = "W2T111";
            if (err == "Err_WiFi_2GHz_Channel_11_TX_Value_not") ERR_CODE = "NW2T11";
            if (err == "Err_WiFi_2GHz_Channel_11_RX_Value") ERR_CODE = "W2R112";
            if (err == "Err_WiFi_2GHz_Channel_11_RX_Value_not") ERR_CODE = "NW2R11";

            if (err == "Err_Setting_Web_2G") ERR_CODE = "ESET2G";
            if (err == "Err_Setting_Web_5G") ERR_CODE = "ESET5G";
            if (err == "Err_Setting_Web_6G") ERR_CODE = "ESET6G";

            if (err == "Err_Setting_SSID_2G") ERR_CODE = "FSID2G";
            if (err == "Err_Setting_SSID_5G") ERR_CODE = "FSID5G";
            if (err == "Err_Setting_SSID_6G") ERR_CODE = "FSID6G";


            if (err == "Err_Setting_Web_2G_firstly_CH1") ERR_CODE = "FS2001";
            if (err == "Err_Setting_Web_2G_firstly_CH6") ERR_CODE = "FS2006";
            if (err == "Err_Setting_Web_2G_firstly_CH11") ERR_CODE = "FS2011";

            if (err == "Err_Setting_Web_5G_firstly_CH36") ERR_CODE = "FS5036";
            if (err == "Err_Setting_Web_5G_firstly_CH48") ERR_CODE = "FS5048";
            if (err == "Err_Setting_Web_5G_firstly_CH153") ERR_CODE = "FS5153";

            if (err == "Err_Setting_Web_6G_firstly_CH5") ERR_CODE = "FS6005";
            if (err == "Err_Setting_Web_6G_firstly_CH37") ERR_CODE = "FS6037";
            if (err == "Err_Setting_Web_6G_firstly_CH197") ERR_CODE = "FS6197";


            if (err == "Err_WiFi_5GHz_Channel") ERR_CODE = "WF5GCH";
            if (err == "Err_Ping_WiFi_5GHz_Channel_36") ERR_CODE = "W5PI36";
            if (err == "Err_Ping_WiFi_5GHz_Channel_48") ERR_CODE = "W5PI48";
            if (err == "Err_Ping_WiFi_5GHz_Channel_153") ERR_CODE = "W5PI53";
            if (err == "Err_WiFi_5GHz_Channel_36_TX_Value") ERR_CODE = "W5T361";
            if (err == "Err_WiFi_5GHz_Channel_36_TX_Value_not") ERR_CODE = "NW5T36";
            if (err == "Err_WiFi_5GHz_Channel_36_RX_Value") ERR_CODE = "W5R362";
            if (err == "Err_WiFi_5GHz_Channel_36_RX_Value_not") ERR_CODE = "NW5R36";
            if (err == "Err_WiFi_5GHz_Channel_48_TX_Value") ERR_CODE = "W5T481";
            if (err == "Err_WiFi_5GHz_Channel_48_TX_Value_not") ERR_CODE = "NW5T48";
            if (err == "Err_WiFi_5GHz_Channel_48_RX_Value") ERR_CODE = "W5R482";
            if (err == "Err_WiFi_5GHz_Channel_48_RX_Value_not") ERR_CODE = "NW5R48";
            if (err == "Err_WiFi_5GHz_Channel_153_TX_Value") ERR_CODE = "W5T531";
            if (err == "Err_WiFi_5GHz_Channel_153_TX_Value_not") ERR_CODE = "NW5T53";
            if (err == "Err_WiFi_5GHz_Channel_153_RX_Value") ERR_CODE = "W5R532";
            if (err == "Err_WiFi_5GHz_Channel_153_RX_Value_not") ERR_CODE = "NW5R53";

            if (err == "Err_Ping_WiFi_6GHz_Channel_5") ERR_CODE = "W6PI05";
            if (err == "Err_Ping_WiFi_6GHz_Channel_37") ERR_CODE = "W6PI37";
            if (err == "Err_Ping_WiFi_6GHz_Channel_197") ERR_CODE = "W6PI97";
            if (err == "Err_WiFi_6GHz_Channel") ERR_CODE = "WF6GCH";
            if (err == "Err_WiFi_6GHz_Channel_5_TX_Value") ERR_CODE = "W6T051";
            if (err == "Err_WiFi_6GHz_Channel_5_RX_Value") ERR_CODE = "W6R052";
            if (err == "Err_WiFi_6GHz_Channel_37_TX_Value") ERR_CODE = "W6T371";
            if (err == "Err_WiFi_6GHz_Channel_37_RX_Value") ERR_CODE = "W6R372";
            if (err == "Err_WiFi_6GHz_Channel_197_TX_Value") ERR_CODE = "W6T931";
            if (err == "Err_WiFi_6GHz_Channel_197_RX_Value") ERR_CODE = "W6R932";

            if (err == "Err_WiFi_6GHz_Channel_5_TX_Value_not") ERR_CODE = "NW6T05";
            if (err == "Err_WiFi_6GHz_Channel_5_RX_Value_not") ERR_CODE = "NW6R05";
            if (err == "Err_WiFi_6GHz_Channel_37_TX_Value_not") ERR_CODE = "NW6T37";
            if (err == "Err_WiFi_6GHz_Channel_37_RX_Value_not") ERR_CODE = "NW6R37";
            if (err == "Err_WiFi_6GHz_Channel_197_TX_Value_not") ERR_CODE = "NW6T93";
            if (err == "Err_WiFi_6GHz_Channel_197_RX_Value_not") ERR_CODE = "NW6R93";
            if (err == "Err_Factory_Reset") ERR_CODE = "RTD001";
            msg(err + " ===> " + ERR_CODE);                   
            try
            {
                if (cmmType.InvokeRequired)
                {
                    cmmType.Invoke(new Action(() =>
                    {
                        if (cmmType.SelectedIndex == 1) { msg("TestOff"); }
                        else
                        {
                            if (ERR_CODE.Length == 6)
                            {
                                Send_ErrCode(ERR_CODE);
                            }
                        }
                    }
                ));
                }
                else
                {
                    if (cmmType.SelectedIndex == 1) { msg("TestOff"); }
                    else
                    {
                        if (ERR_CODE.Length == 6)
                        {
                            Send_ErrCode(ERR_CODE);
                        }
                    }
                }
            }
            catch
            {
                msg("SavelogErr");
            }
            LogFileFail(errs, ERR_CODE);
            LogFile("FAIL", ERR_CODE);
        }
        //*********************************************************************************************
        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string pathfile1 = Directory.GetCurrentDirectory();
            //cmn.openExe1(pathfile1, "mocaDyIp");
            //delay(2000);
            //cmn.switchEthcard("Eth1Eth2", "100");
            //delay(5000);
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmn.switchEthcard("Eth1Eth2", "1000");
            delay(5000);
        }

    
        private void txtSN_SFC_TextChanged(object sender, EventArgs e)
        {

        }
        private string cmdNianreturnIP(string Data, string caseNian, string Eth, string caseip)
        {
            string dataEth = "";
            string Output = Data;
            //for (int i = 0; i <= 3; i++)
            //{
            try
            {
                //Datacmd = "";
                //ThreadStart AnalysisVoip = new ThreadStart(ThreadVOIOP1);
                //Thread_FirstFAIL = new Thread(AnalysisVoip);
                //Thread_FirstFAIL.IsBackground = true;
                //Thread_FirstFAIL.Start();
                //while(Datacmd.Length < 10)
                //{
                //    delay(2000);
                //}
                //string Output = Datacmd;
                //string Output = "";
                //cmd.CmdConnect();
                //cmd.CmdWrite("ipconfig /allcompartments");
                //Delay(100);
                //Output = cmd.CmdRead();
                //cmd.CmdWrite("exit");
                if (Output.Contains(Eth))
                {
                    string data = getKeyEth(Output, Eth, "Ethernet adapter");
                    if (caseNian == "status")
                    {
                        if (data.Contains("Media disconnected"))
                        {
                            dataEth = "disconnected";
                            return dataEth;
                        }
                        else
                        {
                            dataEth = "connect";
                            return dataEth;
                        }
                    }
                    else
                    {
                        if (caseip == "IP")
                        {
                            dataEth = getKeyIPv4Address(data, "IPv4 Address", "Subnet Mask");
                        }
                        else
                        {
                            dataEth = data;
                        }
                        return dataEth;
                    }
                }
                else
                {
                    dataEth = "NoPort";
                    return dataEth;
                }
            }
            catch (Exception ex)
            {
                dataEth = "";
                msg("Exception-> " + ex.ToString());
                return dataEth;
                //if (i >= 2)
                //{
                //    return dataEth;
                //}
                //delay(500);
            }
            // }
            return dataEth;
        }
        public string getKeyEth(string databuffer, string start, string keyend)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(databuffer))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = databuffer.IndexOf(start);
                    result = databuffer.Substring(value, data - value);
                    int value1 = result.IndexOf(keyend);
                    result = result.Substring(0, value1);
                }
            }
            catch
            {
                int data = databuffer.Length;
                int istart = start.Length;
                int value = databuffer.IndexOf(start);
                result = databuffer.Substring(value, data - value);
            }
            return result;
        }
        public string getKeyIPv4Address(string databuffer, string start, string dataend)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(databuffer))
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value = istart + databuffer.IndexOf(start);
                    int valueend = databuffer.IndexOf(dataend);
                    result = databuffer.Substring(value, valueend - value).Trim();
                    int c = 1 + result.IndexOf(":");
                    result = result.Substring(c, result.Length - c).Trim();
                }
            }
            catch { }
            return result;
        }
        private bool EnabelEthAllDHCP()
        {
            bool Resutl = false;
            double TimeStart = GettimeStart("Check_Eth_DHCP");
            bool Eth = false;
            for (int i = 0; i <= 20; i++)
            {
                string Output = "";
                cmd.CmdConnect();
                cmd.CmdWrite("ipconfig /allcompartments");
                Delay(500);
                Output = cmd.CmdRead();
                cmd.CmdWrite("exit");              
                if (Eth == false)
                {
                    string statusEth2 = cmdNianreturnIP(Output, "IP", "DUT", "");
                    if (statusEth2.Contains("192.168.1.100") & statusEth2.Contains("192.168.2.100") 
                        & statusEth2.Contains("10.0.0.100") & statusEth2.Contains("192.168.0.100"))
                    {
                        return true;
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "SetIPDUT");
                        if (i == 2)
                        {
                            MyMessagesBox.Show("\n\nPls! Kiểm tra IP DUT");
                        }
                        if (i >= 5)
                        {
                            ErrorNian("Err_IP_Card");
                            return false;
                        }
                        delay(2000);
                    }
                }                           
            }
            return Resutl;
        }
        private void switchSppedToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        private void set_speed_Eth_port(string name_port, string speed)
        {

            string pathfile1 = Directory.GetCurrentDirectory();
            if (name_port == "All")
            {
                //cmn.openExe1(pathfile1, "enableEth1");
                //delay(200);
                //cmn.openExe1(pathfile1, "enableEth2");
                //delay(200);
                //cmn.openExe1(pathfile1, "enableEth3");
                //delay(200);
                //cmn.openExe1(pathfile1, "enableEth4");

                if (speed == "1000")
                {
                    cmn.openExe1(pathfile1, "speed1000All");
                    delay(1000);
                    delaySuperTime();
                }
                else
                {
                    cmn.openExe1(pathfile1, "speed100All");
                    delay(1000);
                    delaySuperTime();

                }
                //cmn.openExe1(pathfile1, "disable" + name_port);
                //delay(500);
                //cmn.openExe1(pathfile1, "enable" + name_port);
                //delay(6000);
                //cmn.openExe1(pathfile1, "enableEthAll");//
            }
                                            
        }



        /// <summary>
        /// namecheck = "All"
        /// speed = "100" or "1000"
        /// </summary>
        /// <param name="namecheck"></param>
        /// <param name="speed"></param>
      
        private void cmmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmmType.SelectedIndex == 1)
            {
                cmmType.ForeColor = Color.Red;
                //lbl_Type.Text = "Type: Warning!!!";
               // lbl_Type.ForeColor = Color.Red;
                btnstatus.ForeColor = Color.Red;
                btnstatus.BackColor = Color.Yellow;
                cmmType.Enabled = false;
            }
        }

        private void testingqq()
        {
            if (cmmType.SelectedIndex == 1)
            {
                cmmType.ForeColor = Color.Red;
                btnstatus.ForeColor = Color.Red;
                btnstatus.BackColor = Color.Yellow;

            }
            else
            {
                cmmType.ForeColor = Color.Blue;
                btnstatus.ForeColor = Color.Blue;
                btnstatus.BackColor = Color.Lime;
            }
            if (btnstatus.InvokeRequired) {
                btnstatus.Invoke(new Action(() =>
            {
                //btnstatus.ForeColor = Color.Blue;
               // btnstatus.BackColor = Color.Lime;
                float xx = btnstatus.Font.Size;
                xx = 20;
                btnstatus.Font = new Font(btnstatus.Font.Name, xx, btnstatus.Font.Style, btnstatus.Font.Unit);
            }
            )); }
            else
            {
                //btnstatus.ForeColor = Color.Blue;
                //btnstatus.BackColor = Color.Lime;
                //btnstatus.Text = "Testing...\n " + sModem;
                float xx = btnstatus.Font.Size;
                xx = 20;
                btnstatus.Font = new Font(btnstatus.Font.Name, xx, btnstatus.Font.Style, btnstatus.Font.Unit);
            }          
        }
        private void PASSOK()
        {
            if (btnstatus.InvokeRequired)
            {
                btnstatus.Invoke(new Action(() =>
                {
                    btnstatus.ForeColor = Color.Blue;
                    btnstatus.BackColor = Color.Lime;
                    btnstatus.Text = "PASS";
                    float xx = btnstatus.Font.Size;
                    xx = 36;
                    btnstatus.Font = new Font(btnstatus.Font.Name, xx,btnstatus.Font.Style,btnstatus.Font.Unit);
                }
            ));
            }
            else
            {
                btnstatus.ForeColor = Color.Blue;
                btnstatus.BackColor = Color.Lime;
                btnstatus.Text = "PASS";
                float xx = btnstatus.Font.Size;
                xx = 36;
                btnstatus.Font = new Font(btnstatus.Font.Name, xx, btnstatus.Font.Style, btnstatus.Font.Unit);
            }
        }
        private void FailOKOK()
        {
            if (btnstatus.InvokeRequired)
            {
                btnstatus.Invoke(new Action(() =>
                {
                    btnstatus.ForeColor = Color.Yellow;
                    btnstatus.BackColor = Color.Red;
                    btnstatus.Text = "FAIL";
                    float xx = btnstatus.Font.Size;
                    xx = 36;
                    btnstatus.Font = new Font(btnstatus.Font.Name, xx, btnstatus.Font.Style, btnstatus.Font.Unit);
                }
            ));
            }
            else
            {
                btnstatus.ForeColor = Color.Yellow;
                btnstatus.BackColor = Color.Red;
                btnstatus.Text = "FAIL";
                float xx = btnstatus.Font.Size;
                xx = 36;
                btnstatus.Font = new Font(btnstatus.Font.Name, xx, btnstatus.Font.Style, btnstatus.Font.Unit);
            }
        }

        private void result2GTXCH1(string key)
        {
            if (txtresult2GTXCH1.InvokeRequired)
            {
                txtresult2GTXCH1.Invoke(new Action(() =>
                {
                    txtresult2GTXCH1.Clear();
                    txtresult2GTXCH1.AppendText(key);
                }));
            }
            else
            {
                txtresult2GTXCH1.Clear();
                txtresult2GTXCH1.AppendText(key);
            }
        }
        private void result2GRXCH1(string key)
        {
            if (txtresult2GRXCH1.InvokeRequired)
            {
                txtresult2GRXCH1.Invoke(new Action(() =>
                {
                    txtresult2GRXCH1.Clear();
                    txtresult2GRXCH1.AppendText(key);
                }));
            }
            else
            {
                txtresult2GRXCH1.Clear();
                txtresult2GRXCH1.AppendText(key);
            }
        }
        private void result2GTXCH6(string key)
        {
            if (txtresult2GTXCH6.InvokeRequired)
            {
                txtresult2GTXCH6.Invoke(new Action(() =>
                {
                    txtresult2GTXCH6.Clear();
                    txtresult2GTXCH6.AppendText(key);
                }));
            }
            else
            {
                txtresult2GTXCH6.Clear();
                txtresult2GTXCH6.AppendText(key);
            }
        }
        private void result2GRXCH6(string key)
        {
            if (txtresult2GRXCH6.InvokeRequired)
            {
                txtresult2GRXCH6.Invoke(new Action(() =>
                {
                    txtresult2GRXCH6.Clear();
                    txtresult2GRXCH6.AppendText(key);
                }));
            }
            else
            {
                txtresult2GRXCH6.Clear();
                txtresult2GRXCH6.AppendText(key);
            }
        }

        private void result2GTXCH11(string key)
        {
            if (txtresult2GTXCH11.InvokeRequired)
            {
                txtresult2GTXCH11.Invoke(new Action(() =>
                {
                    txtresult2GTXCH11.Clear();
                    txtresult2GTXCH11.AppendText(key);
                }));
            }
            else
            {
                txtresult2GTXCH11.Clear();
                txtresult2GTXCH11.AppendText(key);
            }
        }
        private void result2GRXCH11(string key)
        {
            if (txtresult2GRXCH11.InvokeRequired)
            {
                txtresult2GRXCH11.Invoke(new Action(() =>
                {
                    txtresult2GRXCH11.Clear();
                    txtresult2GRXCH11.AppendText(key);
                }));
            }
            else
            {
                txtresult2GRXCH11.Clear();
                txtresult2GRXCH11.AppendText(key);
            }
        }
        private void result5GTXCH36(string key)
        {
            if (txtresult5GTXCH36.InvokeRequired)
            {
                txtresult5GTXCH36.Invoke(new Action(() =>
                {
                    txtresult5GTXCH36.Clear();
                    txtresult5GTXCH36.AppendText(key);
                }));
            }
            else
            {
                txtresult5GTXCH36.Clear();
                txtresult5GTXCH36.AppendText(key);
            }
        }
        private void result5GRXCH36(string key)
        {
            if (txtresult5GRXCH36.InvokeRequired)
            {
                txtresult5GRXCH36.Invoke(new Action(() =>
                {
                    txtresult5GRXCH36.Clear();
                    txtresult5GRXCH36.AppendText(key);
                }));
            }
            else
            {
                txtresult5GRXCH36.Clear();
                txtresult5GRXCH36.AppendText(key);
            }
        }
        private void result5GTXCH48(string key)
        {
            if (txtresult5GTXCH48.InvokeRequired)
            {
                txtresult5GTXCH48.Invoke(new Action(() =>
                {
                    txtresult5GTXCH48.Clear();
                    txtresult5GTXCH48.AppendText(key);
                }));
            }
            else
            {
                txtresult5GTXCH48.Clear();
                txtresult5GTXCH48.AppendText(key);
            }
        }
        private void result5GRXCH48(string key)
        {
            if (txtresult5GRXCH48.InvokeRequired)
            {
                txtresult5GRXCH48.Invoke(new Action(() =>
                {
                    txtresult5GRXCH48.Clear();
                    txtresult5GRXCH48.AppendText(key);
                }));
            }
            else
            {
                txtresult5GRXCH48.Clear();
                txtresult5GRXCH48.AppendText(key);
            }
        }
        private void result5GTXCH153(string key)
        {
            if (txtresult5GTXCH153.InvokeRequired)
            {
                txtresult5GTXCH153.Invoke(new Action(() =>
                {
                    txtresult5GTXCH153.Clear();
                    txtresult5GTXCH153.AppendText(key);
                }));
            }
            else
            {
                txtresult5GTXCH153.Clear();
                txtresult5GTXCH153.AppendText(key);
            }
        }
        private void result5GRXCH153(string key)
        {
            if (txtresult5GRXCH153.InvokeRequired)
            {
                txtresult5GRXCH153.Invoke(new Action(() =>
                {
                    txtresult5GRXCH153.Clear();
                    txtresult5GRXCH153.AppendText(key);
                }));
            }
            else
            {
                txtresult5GRXCH153.Clear();
                txtresult5GRXCH153.AppendText(key);
            }
        }
        private void result6GTXCH5(string key)
        {
            if (txtresult6GTXCH5.InvokeRequired)
            {
                txtresult6GTXCH5.Invoke(new Action(() =>
                {
                    txtresult6GTXCH5.Clear();
                    txtresult6GTXCH5.AppendText(key);
                }));
            }
            else
            {
                txtresult6GTXCH5.Clear();
                txtresult6GTXCH5.AppendText(key);
            }
        }
        private void result6GRXCH5(string key)
        {
            if (txtresult6GRXCH5.InvokeRequired)
            {
                txtresult6GRXCH5.Invoke(new Action(() =>
                {
                    txtresult6GRXCH5.Clear();
                    txtresult6GRXCH5.AppendText(key);
                }));
            }
            else
            {
                txtresult6GRXCH5.Clear();
                txtresult6GRXCH5.AppendText(key);
            }
        }
        private void result6GTXCH37(string key)
        {
            if (txtresult6GTXCH37.InvokeRequired)
            {
                txtresult6GTXCH37.Invoke(new Action(() =>
                {
                    txtresult6GTXCH37.Clear();
                    txtresult6GTXCH37.AppendText(key);
                }));
            }
            else
            {
                txtresult6GTXCH37.Clear();
                txtresult6GTXCH37.AppendText(key);
            }
        }
        private void result6GRXCH37(string key)
        {
            if (txtresult6GRXCH37.InvokeRequired)
            {
                txtresult6GRXCH37.Invoke(new Action(() =>
                {
                    txtresult6GRXCH37.Clear();
                    txtresult6GRXCH37.AppendText(key);
                }));
            }
            else
            {
                txtresult6GRXCH37.Clear();
                txtresult6GRXCH37.AppendText(key);
            }
        }
        private void result6GTXCH197(string key)
        {
            if (txtresult6GTXCH197.InvokeRequired)
            {
                txtresult6GTXCH197.Invoke(new Action(() =>
                {
                    txtresult6GTXCH197.Clear();
                    txtresult6GTXCH197.AppendText(key);
                }));
            }
            else
            {
                txtresult6GTXCH197.Clear();
                txtresult6GTXCH197.AppendText(key);
            }
        }
        private void result6GRXCH197(string key)
        {
            if (txtresult6GRXCH197.InvokeRequired)
            {
                txtresult6GRXCH197.Invoke(new Action(() =>
                {
                    txtresult6GRXCH197.Clear();
                    txtresult6GRXCH197.AppendText(key);
                }));
            }
            else
            {
                txtresult6GRXCH197.Clear();
                txtresult6GRXCH197.AppendText(key);
            }
        }
        private void cmdNian()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("ipconfig /allcompartments");
                Delay(100);
                string Output = cmd.CmdRead();
                string  IPSFC = getKeyEnd11(Output, "200.168").Trim();
                if (lbipsfc.InvokeRequired)
                {
                    lbipsfc.Invoke(new Action(() => lbipsfc.Text = IPSFC));
                }
                else lbipsfc.Text = IPSFC;
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private bool cmdNian1(string cm)
        {
            if (cm.Contains("6G") | cm.Contains("5G"))
            {
                if (cm.Contains("5G"))
                {
                    Resetcard5G();
                }
                else if (cm.Contains("6G"))
                {
                    Resetcard6G();
                }
                delay(5000);
                return true;
            }
            else
            {
                string result = "";
                //string key1 = "DONE";
                string key1 = "Connection request was completed successfully";
                string key2 = "no wireless interface";
                string key3 = "Connect Golden server failed";
                string key4 = " not available";
                string key5 = "Examples:";
                string key6 = "assigned to the specified interface";
                bool a = false;
                try
                {
                    delay(1000);
                    for (int i = 0; i <= 6; i++)
                    {
                        cmd.CmdConnect();
                        cmd.CmdWrite(cm);
                        delay(50);
                        string Output = cmd.CmdRead();
                        result = Output.Trim();
                        cmd.CmdWrite("exit");
                        Output = "";
                        if (result.Contains(key1))
                        {
                            a = true;
                            delay(2000);
                            i = 50;
                            return true;
                        }
                        else if (result.Contains(key2))
                        {
                            if (cm.Contains("2G"))
                            {
                                Resetcard2G();
                            }
                            else if (cm.Contains("5G"))
                            {
                                Resetcard5G();
                            }                         
                            delay(10000);
                        }
                        else if (result.Contains(key3))
                        {
                            MessageBox.Show("Hay kiểm tra chương trinh -WiFiOBASXB8- bên PC Golden!!");
                            delay(10000);
                        }
                        else if (result.Contains(key4))
                        {
                            msg(key4);
                            if (i > 0)
                            {
                                if (cm.Contains("2G"))
                                {
                                    Resetcard2G();
                                }
                                else if (cm.Contains("5G"))
                                {
                                    Resetcard5G();
                                }
                                else
                                {
                                    Resetcard6G();
                                    delay(15000);
                                }
                            }
                            delay(10000);
                        }
                        else if (result.Contains(key5))
                        {
                            msg(key5);
                            if (cm.Contains("2G"))
                            {
                                Disablecard5G();
                                Disablecard6G();
                                Enablecard2G();
                            }
                            else if(cm.Contains("5G"))
                            {                            
                                Disablecard2G();
                                Disablecard6G();
                                Enablecard5G();
                            }
                            else
                            {
                                Disablecard2G();
                                Disablecard5G();
                                Enablecard6G();
                            }
                            delay(2000);
                        }
                        else if (result.Contains(key6))
                        {
                            if (cm.Contains("2G"))
                            {
                                Disablecard5G();
                                Disablecard6G();
                                Enablecard2G();
                            }
                            else if (cm.Contains("5G"))
                            {
                                Disablecard2G();
                                Disablecard6G();
                                Enablecard5G();
                            }
                        }
                         if (i >= 4)
                        {
                            return false;
                        }
                        else { delay(2000);}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                return a;
            }
        }
        private void Resetcard5G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card5G + ", disable]\"");
                Delay(1000);
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card5G + ", enable]\"");
                Delay(5000);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Resetcard2G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card2G + ", disable]\"");
                Delay(1000);
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card2G + ", enable]\"");
                Delay(500);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }     
        private void Resetcard6G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card6G + ", disable]\"");
                Delay(1000);
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card6G + ", enable]\"");              
                Delay(5000);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }        
        private void Enablecard5G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card5G + ", enable]\"");
                Delay(100);             
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Disablecard6G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card6G + ", disable]\"");
                Delay(500);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Disablecard5G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card5G + ", disable]\"");
                Delay(500);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Disablecard2G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card2G + ", disable]\"");
                Delay(100);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Enablecard2G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card2G + ", enable]\"");
                Delay(500);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Enablecard6G()
        {
            try
            {
                cmd.CmdConnect();
                cmd.CmdWrite("WiFiOBACXB8-PC.exe GOLDENADAPTER 192.168.200.2 \"[" + Card6G + ", enable]\"");
                Delay(100);
                cmd.CmdWrite("exit");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void button6_Click_3(object sender, EventArgs e)
        {
            //cmdNian();
            //stoptestUSB = true;



            //if (!webAuto_COM2()) { StatusERR("Err->Web2"); return; }
            //enableMocaWebPss = true;
            //dkvoip = true;
            //checkPingTimeout();
            // checkDHCP();
            //if (!CheckLed_Online()) { StatusERR("Web_Module"); return; }
            // if (!Web_Module()) { StatusERR("Web_Module"); return; }
            //  checkPingMocaMian();
            // if (!checkPingResetTodefault()) { StatusERR("checkPingToEth1"); return; }
            // CheckLed_100Eth();
            //if (!Check_speed("All", "100")) return;
            //if (!CheckLed_100EthNian()) return;
            //CheckLed_WPSNian();
            //if (!CheckLed_100Eth()) return;
        }
        string pronam = "CGM4981COM";
        int snlength = 18;
        int modellength = 10;

        private void cmmModem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmmModem.SelectedIndex == 0 | cmmModem.SelectedIndex == -1)
            {
                SW = "CGM4981COM_5.8p3s1_PROD_sey";
                sModem = "CGM4981COM";
                pronam = "CGM4981COM";
                btnstatus.Text = "Start " + sModem;
                label14.Text = "Ver: 1.1";
            }
            if (cmmModem.SelectedIndex == 1)
            {
                sModem = "CGM4981COM-DEV";
                pronam = "CGM4981DEV";
                btnstatus.Text = "Start " + sModem;
                label14.Text = "Ver: 1.0";
            }
            if (cmmModem.SelectedIndex == 2)
            {
                SW = "CGM4981COM_5.8p3s1_PROD_sey";
                sModem = "CGM4981COX";
                pronam = "CGM4981COX";
                InfoIP = "192.168.0.1";
                linkWeb = "http://192.168.0.1/";
                linkWeb1 = "http://192.168.0.1/at_a_glance.jst";
                linkWebChangePassword = "http://192.168.0.1/admin_password_change.jst";
                linkWebNetwork = "http://192.168.0.1/wireless_network_configuration.jst";
                linkReset = "http://192.168.0.1/restore_reboot.jst";
                linkInfor = "http://192.168.0.1/network_setup.jst";
                linkwifi = "http://192.168.0.1/wireless_network_configuration.jst";
                linkSW = "http://192.168.0.1/software.jst";

                linkwifi2G = "http://192.168.0.1/wireless_network_configuration_edit.jst?id=1";
                linkwifi5G = "http://192.168.0.1/wireless_network_configuration_edit.jst?id=2";
                linkwifi6G = "http://192.168.0.1/wireless_network_configuration_edit.jst?id=17";

                DocumentTitleWEBSSID1 = "Smart Internet";
                DocumentTitleWEBSSID2 = "Login - Cox";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";
                btnstatus.Text = "Start " + sModem;
                label14.Text = "Ver: 1.0";
            }
            if (cmmModem.SelectedIndex == 3)
            {
                sModem = "CGM4981ROG";
                pronam = "CGM4981ROG";
                btnstatus.Text = "Start " + sModem;
                DocumentTitleWEBSSID1 = "Rogers";
                DocumentTitleWEBSSID2 = "Login";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";
                SNlength = 16;
                SW = "CGM4981COM_5.8p3s1_PROD_sey";
                label14.Text = "Ver: 1.0";
            }
            if (cmmModem.SelectedIndex == 4)
            {
                SW = "CGM4981COM_5.8p3s1_PROD_sey";
                sModem = "CGM4981SHW";
                pronam = "CGM4981SHW";
                btnstatus.Text = "Start " + sModem;
                DocumentTitleWEBSSID1 = "SHAW";
                DocumentTitleWEBSSID2 = "Login";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";
                SNlength = 16;
                label14.Text = "Ver: 1.0";
            }
            if (cmmModem.SelectedIndex == 5)//SHW
            {        
                sModem = "CGM4981VDT";
                pronam = "CGM4981VDT";
                btnstatus.Text = "Start " + sModem;
                DocumentTitleWEBSSID1 = "Helix";
                DocumentTitleWEBSSID2 = "Login";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";
                label14.Text = "Ver: 1.";
            }
            cmmModem.Enabled = false;
            txtUser.Focus();
            if (Modelname.InvokeRequired)
            {
                Modelname.Invoke(new Action(() =>
                {
                    Modelname.Clear();
                    Modelname.AppendText(sModem);
                }));
            }
            else
            {
                Modelname.Clear();
                Modelname.AppendText(sModem);
            }
        }

        private void cmbAudioDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("V");
            }        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("0");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("1");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("2");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("3");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("4");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("5");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("6");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("7");
            }
        }

        private void cmmModem_TextChanged(object sender, EventArgs e)
        {
            grKey.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lbipsfc_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void blcomputer_Click(object sender, EventArgs e)
        {

        }

        private void gg()
        {
            for (int i = 0; i <= 100; i++)
            {
                cmn.pingToAddress("10.0.0.1");
                msg(cmn.pingdata);
                delay(1000);
            }
        }
        private void wEBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebAutoNian();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("8");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length < 8)
            {
                txtUser.AppendText("9");
            }
        }

        private void tabCtrInstall_Click(object sender, EventArgs e)
        {

        }

        public class msnmp : cableConnectionsnmp.cablesnmp
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {


        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            //304930030077107932
            //SN_SFC = textSPSFC11.Text.Trim();
            SN_SFC = SN_SFC.PadRight(35, ' ');
            //SN_SFC = SN_SFC;
            SN_SFC = SN_SFC + "END";
            Send_To_SFC(SN_SFC + "\r");
            delay(2000);
              
        }

        private void Test2GCH1()
        {
                if (!TestWifi2GCH1()) { return; }
        }
        private void Test2GCH6()
        {
                if (!TestWifi2GCH6()) { return; }
        }
        private void Test2GCH11()
        {
                if (!TestWifi2GCH11()) { return; }
        }
        private void Test5GCH36()
        {
                if (!TestWifi5GCH36()) { return; }
        }
        private void Test5GCH48()
        {
                if (!TestWifi5GCH48()) { return; }
        }
        
        private void Test5GCH153()
        {
                if (!TestWifi5GCH153()) { return; }
        }
        private bool TestWifi2GCH1()
        {
            Pass2GCH1 = false;        
            bool PassWifi2GCH1 = false;
            Status("Test_WiFi_2.4G_CH1...");
            double TimeStart = GettimeStart("Test_WiFi_2.4G_CH1");
            for (int n = 1; n <= 5; n++)
            {
                msg("Test_WiFi_2G_CH1_times " + n);
                DeleteResult("ResultWF2GTX", "ResultWF2GRX");
                delay(500);
                if (!PingToWifi("WiFi_2G_CH1", IP2G, SSID2G))
                {
                    if (n == 3)
                    {
                        double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                        TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                        ErrorNian("Err_Ping_WiFi_2GHz_Channel_1");
                        return false;
                    }
                }
                else
                {
                    cmn.openExe1(pathfile1, "Wifi2G-TX");
                    Wifi2GTXCH1 = ReturnResult("ResultWF2GTX", "CH1");
                    if (Wifi2GTXCH1 >= SpecWifi2G & Wifi2GTXCH1 < 300)
                    {
                        result2GTXCH1(Wifi2GTXCH1.ToString());
                        cmn.openExe1(pathfile1, "Wifi2G-RX");
                        Wifi2GRXCH1 = ReturnResult("ResultWF2GRX", "CH1");
                        if (Wifi2GRXCH1 >= SpecWifi2G & Wifi2GRXCH1 < 300)
                        {
                            result2GRXCH1(Wifi2GRXCH1.ToString());
                            double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                            TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                            PassWifi2GCH1 = true;
                            suscessfulsetingWifi5G = true;
                            Pass2GCH1 = true;
                            return true;
                        }
                        else
                        {
                            result2GRXCH1(Wifi2GRXCH1.ToString());
                            if (n == 3)
                            {
                                if (Wifi2GRXCH1==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                                    TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_1_RX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                                    TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_1_RX_Value");
                                    return false;
                                }
                               
                            }
                            if (n == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_2G_CH1RX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi2G_off("2RX", "");
                                //Delay(15000);
                                //SettingWifi2G_On("2RX", "");
                                //Delay(15000);
                            }
                        }
                    }
                    else
                    {
                        result2GTXCH1(Wifi2GTXCH1.ToString());
                        if (n == 3)
                        {
                            if (Wifi2GTXCH1 == 0)
                            {
                                double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                                TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                                ErrorNian("Err_WiFi_2GHz_Channel_1_TX_Value_not");
                                return false;
                            }
                            else
                            {
                                double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH1");
                                TimeWifi2GCH1 = CountTime("Test_WiFi_2.4G_CH1", TimeStart, TimeEnd);
                                ErrorNian("Err_WiFi_2GHz_Channel_1_TX_Value");
                                return false;
                            }
                        }
                        if (n == 2)
                        {
                            cmd.CmdConnect();
                            cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                            delay(30000);
                            string Output = cmd.CmdRead();
                            cmd.CmdWrite("exit");
                            msg(Output);
                            if (Output.Contains("SW All Web success ==> PASS"))
                            {
                                log_sum_on_off(lbsndut.Text + "_2G_CH1TX");
                                msg("ON/OFF success");
                            }
                            //SettingWifi2G_off("2TX", "");
                            //Delay(15000);
                            //SettingWifi2G_On("2TX", "");
                            //Delay(15000);
                        }
                    }
                }
            }
            return PassWifi2GCH1;
        }
        private bool TestWifi2GCH6()
        {
            bool PassWifi2GCH6 = false;
            Pass2GCH6 = false;
            Status("Test_WiFi_2.4G_CH6...");
            double TimeStart = GettimeStart("Test_WiFi_2.4G_CH6");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_2G_CH6_times " + i);
                //if (i == 1)
                //{
                //    if (!SettingWifi2G("6", "1")) { return false; }
                //}
               // else
                {
                    DeleteResult("ResultWF2GTX", "ResultWF2GRX");
                    delay(500);
                    if (!PingToWifi("WiFi_2G_CH6", IP2G, SSID2G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                            TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_2GHz_Channel_6");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi2G-TX");
                        Wifi2GTXCH6 = ReturnResult("ResultWF2GTX", "CH6");
                        if (Wifi2GTXCH6 >= SpecWifi2G & Wifi2GTXCH6 < 300)
                        {
                            result2GTXCH6(Wifi2GTXCH6.ToString());
                            cmn.openExe1(pathfile1, "Wifi2G-RX");
                            Wifi2GRXCH6 = ReturnResult("ResultWF2GRX", "CH6");
                            if (Wifi2GRXCH6 >= SpecWifi2G & Wifi2GRXCH6 < 300)
                            {
                                result2GRXCH6(Wifi2GRXCH6.ToString());
                                PassWifi2GCH6 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                                TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                                Pass2GCH6 = true;
                                return true;
                            }
                            else
                            {
                                result2GRXCH6(Wifi2GRXCH6.ToString());
                                if (i == 3)
                                {
                                    if (Wifi2GRXCH6==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                                        TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_2GHz_Channel_6_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                                        TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_2GHz_Channel_6_RX_Value");
                                        return false;
                                    }
                                   
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_2G_CH6RX");
                                        msg("ON/OFF success");
                                    }

                                    //SettingWifi2G_off("2RX", "");
                                    //Delay(15000);
                                    //SettingWifi2G_On("2RX", "");
                                    //Delay(15000);
                                }
                            }
                        }
                        else
                        {
                            result2GTXCH6(Wifi2GTXCH6.ToString());
                            if (i == 3)
                            {
                                if (Wifi2GTXCH6==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                                    TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_6_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH6");
                                    TimeWifi2GCH6 = CountTime("Test_WiFi_2.4G_CH6", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_6_TX_Value");
                                    return false;
                                }
                                
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_2G_CH6RX");
                                    msg("ON/OFF success");
                                }
                                //thMutiple_new = new Thread(new ThreadStart(Test_on_off2G_TX));
                                //thMutiple_new.IsBackground = true;
                                //thMutiple_new.Start();
                                //Delay(30000);
                                //int lll = 0;
                                //while (true)
                                //{
                                //    if (kq_ther == true)
                                //    {
                                //        msg("Config ok");
                                //    }
                                //    else
                                //    {
                                //        msg("Wait config");
                                //        Delay(1000);
                                //        lll++;
                                //        if (lll >= 30)
                                //        {
                                //            msg("Config FAIL");
                                //            try
                                //            {
                                //                thMutiple_new.Abort();
                                //            }
                                //            catch { }
                                //            break;
                                //        }
                                //    }
                                //}
                                //SettingWifi2G_off("2TX", "");
                                //Delay(15000);
                                //SettingWifi2G_On("2TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
            return PassWifi2GCH6;
        }
        private bool TestWifi2GCH11()
        {
            bool PassWifi2GCH11 = false;
            Pass2GCH11 = false;
            Status("Test_WiFi_2.4G_CH11...");
            double TimeStart = GettimeStart("Test_WiFi_2.4G_CH11");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_2G_CH11_times " + i);
                //if (i == 1)
                //{
                //    if (!SettingWifi2G("11", "1")) { return false; }
                //}
                //else
                {
                    DeleteResult("ResultWF2GTX", "ResultWF2GRX");
                    delay(500);
                    if (!PingToWifi("WiFi_2G_CH11", IP2G, SSID2G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                            TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_2GHz_Channel_11");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi2G-TX");
                        Wifi2GTXCH11 = ReturnResult("ResultWF2GTX", "CH11");
                        if (Wifi2GTXCH11 >= SpecWifi2G & Wifi2GTXCH11 < 300)
                        {
                            result2GTXCH11(Wifi2GTXCH11.ToString());
                            cmn.openExe1(pathfile1, "Wifi2G-RX");
                            Wifi2GRXCH11 = ReturnResult("ResultWF2GRX", "CH11");
                            if (Wifi2GRXCH11 >= SpecWifi2G & Wifi2GRXCH11 < 300)
                            {
                                result2GRXCH11(Wifi2GRXCH11.ToString());
                                PassWifi2GCH11 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                                TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                                Pass2GCH11 = true;
                                return true;
                            }
                            else
                            {
                                result2GRXCH11(Wifi2GRXCH11.ToString());
                                if (i == 3)
                                {
                                    if (Wifi2GRXCH11==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                                        TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_2GHz_Channel_11_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                                        TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_2GHz_Channel_11_RX_Value");
                                        return false;
                                    }
                                   
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_2G_CH11RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi2G_off("2RX", "");
                                    //Delay(15000);
                                    //SettingWifi2G_On("2RX", "");
                                    //Delay(15000);
                                }
                            }
                        }
                        else
                        {
                            result2GTXCH11(Wifi2GTXCH11.ToString());
                            if (i == 3)
                            {
                                if (Wifi2GTXCH11==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                                    TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_11_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_2.4G_CH11");
                                    TimeWifi2GCH11 = CountTime("Test_WiFi_2.4G_CH11", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_2GHz_Channel_11_TX_Value");
                                    return false;
                                }
                                
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 2G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_2G_CH11TX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi2G_off("2TX", "");
                                //Delay(15000);
                                //SettingWifi2G_On("2TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
            return PassWifi2GCH11;
        }
        private bool TestWifi5GCH36()
        {
            bool PassWifi5GCH36 = false;
            Pass5GCH36 = false;
            Status("Test_WiFi_5G_CH36...");
            double TimeStart = GettimeStart("Test_WiFi_5G_CH36");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_5G_CH36_times " + i);
                //if (i > 1)
                //{                 
                //    if (!SettingWifi5G("36","1"))
                //    {
                //        return false;
                //    }
                //}
                if (!suscessfulsetingWifi5G) { return false;}
                else
                {
                    DeleteResult("ResultWF5GTX", "ResultWF5GRX");
                    if (!PingToWifi("WiFi_5G_CH36", IP5G, SSID5G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                            TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_5GHz_Channel_36");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi5G-TX");
                        Wifi5GTXCH36 = ReturnResult("ResultWF5GTX", "CH36");
                        if (Wifi5GTXCH36 >= SpecWifi5G)
                        {
                            result5GTXCH36(Wifi5GTXCH36.ToString());
                            cmn.openExe1(pathfile1, "Wifi5G-RX");
                            Wifi5GRXCH36 = ReturnResult("ResultWF5GRX", "CH36");
                            if (Wifi5GRXCH36 >= SpecWifi5G)
                            {
                                result5GRXCH36(Wifi5GRXCH36.ToString());
                                PassWifi5GCH36 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                                TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                                Pass5GCH36 = true;
                                return true;
                            }
                            else
                            {
                                result5GRXCH36(Wifi5GRXCH36.ToString());
                                if (i == 3)
                                {
                                    if (Wifi5GRXCH36==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                                        TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_36_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                                        TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_36_RX_Value");
                                        return false;
                                    }
                                    
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_5G_CH36RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi5G_off("36RX", "");
                                    //Delay(15000);
                                    //SettingWifi5G_On("36RX", "");
                                    //Delay(15000);
                                }
                                    
                            }
                        }
                        else
                        {
                            result5GTXCH36(Wifi5GTXCH36.ToString());
                            if (i == 3)
                            {
                                if (Wifi5GTXCH36==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                                    TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_36_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH36");
                                    TimeWifi5GCH36 = CountTime("Test_WiFi_5G_CH36", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_36_TX_Value");
                                    return false;
                                }
                                
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_5G_CH36TX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi5G_off("36TX", "");
                                //Delay(15000);
                                //SettingWifi5G_On("36TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
            return PassWifi5GCH36;
        }
        private bool TestWifi5GCH48()
        {
            bool PassWifi5GCH48 = false;
            Pass5GCH48 = false;
            Status("Test_WiFi_5G_CH48...");
            double TimeStart = GettimeStart("Test_WiFi_5G_CH48");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_5G_CH48_times " + i);
                {
                    DeleteResult("ResultWF5GTX", "ResultWF5GRX");
                    if (!PingToWifi("WiFi_5G_CH48", IP5G, SSID5G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                            TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_5GHz_Channel_48");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi5G-TX");
                        Wifi5GTXCH48 = ReturnResult("ResultWF5GTX", "CH48");
                        if (Wifi5GTXCH48 >= SpecWifi5G)
                        {
                            result5GTXCH48(Wifi5GTXCH48.ToString());
                            cmn.openExe1(pathfile1, "Wifi5G-RX");
                            Wifi5GRXCH48 = ReturnResult("ResultWF5GRX", "CH48");
                            if (Wifi5GRXCH48 >= SpecWifi5G)
                            {
                                result5GRXCH48(Wifi5GRXCH48.ToString());
                                PassWifi5GCH48 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                                TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                                Pass5GCH48 = true;
                                return true;
                            }
                            else
                            {
                                result5GRXCH48(Wifi5GRXCH48.ToString());
                                if (i == 3)
                                {
                                    if (Wifi5GRXCH48==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                                        TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_48_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                                        TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_48_RX_Value");
                                        return false;
                                    }
                                   
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_5G_CH48RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi5G_off("48RX", "");
                                    //Delay(15000);
                                    //SettingWifi5G_On("48RX", "");
                                    //Delay(15000);
                                }

                            }
                        }
                        else
                        {
                            result5GTXCH48(Wifi5GTXCH48.ToString());
                            if (i == 3)
                            {
                                if (Wifi5GTXCH48==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                                    TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_48_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH48");
                                    TimeWifi5GCH48 = CountTime("Test_WiFi_5G_CH48", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_48_TX_Value");
                                    return false;
                                }
                               
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_5G_CH48TX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi5G_off("48TX", "");
                                //Delay(15000);
                                //SettingWifi5G_On("48TX", "");
                                //Delay(15000);
                            }

                        }
                    }
                }
            }
            return PassWifi5GCH48;
        }
        private bool TestWifi5GCH153()
        {
            bool PassWifi5GCH153 = false;
            Pass5GCH153 = false;
            Status("Test_WiFi_5G_CH153...");
            double TimeStart = GettimeStart("Test_WiFi_5G_CH153");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_5G_CH153_times " + i);
                //if (i == 1| i ==3)
                //{
                //    if (!SettingWifi5G("153", "1")) { return false; }
                //}
                //if (!SettingWifi5G("153", "1")) { return false; }
                // else
                {
                    DeleteResult("ResultWF5GTX", "ResultWF5GRX");
                    delay(500);
                    if (!PingToWifi("WiFi_5G_CH153", IP5G, SSID5G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                            TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_5GHz_Channel_153");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi5G-TX");
                        Wifi5GTXCH153 = ReturnResult("ResultWF5GTX", "CH153");
                        if (Wifi5GTXCH153 >= SpecWifi5G)
                        {
                            result5GTXCH153(Wifi5GTXCH153.ToString());
                            cmn.openExe1(pathfile1, "Wifi5G-RX");
                            Wifi5GRXCH153 = ReturnResult("ResultWF5GRX", "CH153");
                            if (Wifi5GRXCH153 >= SpecWifi5G)
                            {
                                result5GRXCH153(Wifi5GRXCH153.ToString());
                                PassWifi5GCH153 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                                TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                                Pass5GCH153 = true;
                                return true;
                            }
                            else
                            {
                                result5GRXCH153(Wifi5GRXCH153.ToString());
                                if (i == 3)
                                {
                                    if (Wifi5GRXCH153==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                                        TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_153_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                                        TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_5GHz_Channel_153_RX_Value");
                                        return false;
                                    }
                                   
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_5G_CH153RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi5G_off("153RX", "");
                                    //Delay(15000);
                                    //SettingWifi5G_On("153RX", "");
                                    //Delay(15000);
                                }

                            }
                        }
                        else
                        {
                            result5GTXCH153(Wifi5GTXCH153.ToString());
                            if (i == 3)
                            {
                                if (Wifi5GTXCH153==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                                    TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_153_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_5G_CH153");
                                    TimeWifi5GCH153 = CountTime("Test_WiFi_5G_CH153", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_5GHz_Channel_153_TX_Value");
                                    return false;
                                }
                               
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 5G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_5G_CH153TX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi5G_off("153TX", "");
                                //Delay(15000);
                                //SettingWifi5G_On("153TX", "");
                                //Delay(15000);
                            }

                        }
                    }
                }
            }
            return PassWifi5GCH153;
        }
        private bool TestWifi6GCH5()
        {
            bool PassWifi6GCH1 = false;
            Status("Test_WiFi_6G_CH5...");
            double TimeStart = GettimeStart("Test_WiFi_6G_CH5");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_6G_CH5_times " + i);
                //if (i > 1)
                //{
                //    if (!SettingWifi6G("5","1"))
                //    {
                //        return false;
                //    }
                //}
                if (!suscessfulsetingWifi5G) { return false; }
                else
                {
                    DeleteResult("ResultWF6GTX", "ResultWF6GRX");
                    if (!PingToWifi("WiFi_6G_CH5", IP6G, SSID6G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                            TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_6GHz_Channel_5");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi6G-TX");
                        Wifi6GTXCH5 = ReturnResult("ResultWF6GTX", "CH5");
                        if (Wifi6GTXCH5 >= SpecWifi6G)
                        {
                            result6GTXCH5(Wifi6GTXCH5.ToString());
                            cmn.openExe1(pathfile1, "Wifi6G-RX");
                            Wifi6GRXCH5 = ReturnResult("ResultWF6GRX", "CH5");
                            if (Wifi6GRXCH5 >= SpecWifi6G)
                            {
                                result6GRXCH5(Wifi6GRXCH5.ToString());
                                PassWifi6GCH1 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                                TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                                return true;
                            }
                            else
                            {
                                result6GRXCH5(Wifi6GRXCH5.ToString());
                                if (i == 3)
                                {
                                    if (Wifi6GRXCH5==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                                        TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_5_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                                        TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_5_RX_Value");
                                        return false;
                                    }
                                    
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_6G_CH5RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi6G_off("5RX", "");
                                    //Delay(15000);
                                    //SettingWifi6G_On("5RX", "");
                                    //Delay(15000);
                                }
                            }
                        }
                        else
                        {
                            result6GTXCH5(Wifi6GTXCH5.ToString());
                            if (i == 3)
                            {
                                if (Wifi6GTXCH5==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                                    TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_5_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH5");
                                    TimeWifi6GCH5 = CountTime("Test_WiFi_6G_CH5", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_5_TX_Value");
                                    return false;
                                }
                               
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_6G_CH5TX");
                                    msg("ON/OFF success");
                                }
                                //SettingWifi6G_off("5TX", "");
                                //Delay(15000);
                                //SettingWifi6G_On("5TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
                return PassWifi6GCH1;
            }
        private bool TestWifi6GCH37()
        {
            bool PassWifi6GCH37 = false;
            Status("Test_WiFi_6G_CH37...");
            double TimeStart = GettimeStart("Test_WiFi_6G_CH37");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_6G_CH37_times " + i);
                if (i == 1)
                {
                    if (!SettingWifi6G("37", "1")) { return false; }
                }
                //else
                {
                    DeleteResult("ResultWF6GTX", "ResultWF6GRX");
                    if (!PingToWifi("WiFi_6G_CH37", IP6G, SSID6G))
                    {
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                            TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_6GHz_Channel_37");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi6G-TX");
                        Wifi6GTXCH37 = ReturnResult("ResultWF6GTX", "CH37");
                        if (Wifi6GTXCH37 >= SpecWifi6G)
                        {
                            result6GTXCH37(Wifi6GTXCH37.ToString());
                            cmn.openExe1(pathfile1, "Wifi6G-RX");
                            Wifi6GRXCH37 = ReturnResult("ResultWF6GRX", "CH37");
                            if (Wifi6GRXCH37 >= SpecWifi6G)
                            {
                                result6GRXCH37(Wifi6GRXCH37.ToString());
                                PassWifi6GCH37 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                                TimeWifi6GCH37 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                                return true;
                            }
                            else
                            {
                                result6GRXCH37(Wifi6GRXCH37.ToString());
                                if (i == 3)
                                {
                                    if (Wifi6GRXCH37==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                                        TimeWifi6GCH37 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_37_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                                        TimeWifi6GCH37 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_37_RX_Value");
                                        return false;
                                    }
                                    
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_6G_CH37RX");
                                        msg("ON/OFF success");
                                    }

                                    //SettingWifi6G_off("37RX", "");
                                    //Delay(15000);
                                    //SettingWifi6G_On("37RX", "");
                                    //Delay(15000);
                                }
                            }
                        }
                        else
                        {
                            result6GTXCH37(Wifi6GTXCH37.ToString());
                            if (i == 3)
                            {
                                if (Wifi6GTXCH37==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                                    TimeWifi6GCH37 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_37_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH37");
                                    TimeWifi6GCH37 = CountTime("Test_WiFi_6G_CH37", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_37_TX_Value");
                                    return false;
                                }
                               
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_6G_CH37TX");
                                    msg("ON/OFF success");
                                }

                                //SettingWifi6G_off("37TX", "");
                                //Delay(15000);
                                //SettingWifi6G_On("37TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
            return PassWifi6GCH37;
        }
        private bool TestWifi6GCH197()
        {
            bool PassWifi6GCH197 = false;
            Status("Test_WiFi_6G_CH197...");
            double TimeStart = GettimeStart("Test_WiFi_6G_CH197");
            for (int i = 1; i <= 5; i++)
            {
                msg("Test_WiFi_6G_CH197_times " + i);
                if (i == 1)
                {
                    if (!SettingWifi6G("197", "1")) { return false; }
                }             
               // else
                {
                    DeleteResult("ResultWF6GTX", "ResultWF6GRX");
                    if (!PingToWifi("WiFi_6G_CH197", IP6G, SSID6G))
                    {                     
                        if (i == 3)
                        {
                            double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                            TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                            ErrorNian("Err_Ping_WiFi_6GHz_Channel_197");
                            return false;
                        }
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "Wifi6G-TX");
                        Wifi6GTXCH197 = ReturnResult("ResultWF6GTX", "CH197");
                        if (Wifi6GTXCH197 >= SpecWifi6G)
                        {
                            result6GTXCH197(Wifi6GTXCH197.ToString());
                            cmn.openExe1(pathfile1, "Wifi6G-RX");
                            Wifi6GRXCH197 = ReturnResult("ResultWF6GRX", "CH197");
                            if (Wifi6GRXCH197 >= SpecWifi6G)
                            {
                                result6GRXCH197(Wifi6GRXCH197.ToString());
                                PassWifi6GCH197 = true;
                                double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                                TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                                return true;
                            }
                            else
                            {
                                result6GRXCH197(Wifi6GRXCH197.ToString());
                                if (i == 3)
                                {
                                    if (Wifi6GRXCH197==0)
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                                        TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_197_RX_Value_not");
                                        return false;
                                    }
                                    else
                                    {
                                        double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                                        TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                                        ErrorNian("Err_WiFi_6GHz_Channel_197_RX_Value");
                                        return false;
                                    }
                                    
                                }
                                if (i == 2)
                                {
                                    cmd.CmdConnect();
                                    cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                    delay(30000);
                                    string Output = cmd.CmdRead();
                                    cmd.CmdWrite("exit");
                                    msg(Output);
                                    if (Output.Contains("SW All Web success ==> PASS"))
                                    {
                                        log_sum_on_off(lbsndut.Text + "_6G_CH197RX");
                                        msg("ON/OFF success");
                                    }
                                    //SettingWifi6G_off("197RX", "");
                                    //Delay(15000);
                                    //SettingWifi6G_On("197RX", "");
                                    //Delay(15000);
                                }
                            }
                        }
                        else
                        {
                            result6GTXCH197(Wifi6GTXCH197.ToString());
                            if (i == 3)
                            {
                                if (Wifi6GTXCH197==0)
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                                    TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_197_TX_Value_not");
                                    return false;
                                }
                                else
                                {
                                    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
                                    TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
                                    ErrorNian("Err_WiFi_6GHz_Channel_197_TX_Value");
                                    return false;
                                }
                               
                            }
                            if (i == 2)
                            {
                                cmd.CmdConnect();
                                cmd.CmdWrite("XB8_ON_OFF.exe 6G");
                                delay(30000);
                                string Output = cmd.CmdRead();
                                cmd.CmdWrite("exit");
                                msg(Output);
                                if (Output.Contains("SW All Web success ==> PASS"))
                                {
                                    log_sum_on_off(lbsndut.Text + "_6G_CH197TX");
                                    msg("ON/OFF success");
                                }

                                //SettingWifi6G_off("197TX", "");
                                //Delay(15000);
                                //SettingWifi6G_On("197TX", "");
                                //Delay(15000);
                            }
                        }
                    }
                }
            }
            return PassWifi6GCH197;
        }
        private void button20_Click_1(object sender, EventArgs e)
        {
            thStattus1 = true;
            //lbsndut.Text = "0123456789";
            //LogFile("PASS","");
            //if (!cmdNian1("WiFiOBACXB8-PC.exe CONNECT 192.168.200.2 " + "OBA2GT01"));
            //Disablecard6G();
            //Disablecard5G();
            //Enablecard2G();
            //delay(2000);
            //if (!TestWifi2GCH1()) { return; }
            //thMutiple1 = new Thread(new ThreadStart(Test2gch1));
            //thMutiple1.IsBackground = true;
            //thMutiple1.Start();

            //   cmn.kill("cmd");
            ////cmn.kill("conhost");
            //cmn.kill("runtst");
            // if (!cmdNian1("WiFiOBACXB8-PC.exe CONNECT 192.168.200.2 " + "OBA2GT01")) ;
            //EnabelEthAllDHCP();
            //if (!cmdNian1("WiFiOBACXB8-PC.exe CONNECT 192.168.200.2 " + "OBA2GT08"))
            //{

            //}
            // if (!PingToWifi("WiFi_6G_CH197", IP6G, SSID6G))
            // {
            // if (i == 2)
            //  {
            //Resetcard();
            //  }
            //if (i == 3)
            //{
            //    double TimeEnd = GettimeEnd("Test_WiFi_6G_CH197");
            //    TimeWifi6GCH197 = CountTime("Test_WiFi_6G_CH197", TimeStart, TimeEnd);
            //    ErrorNian("Err_Ping_WiFi_6GHz_Channel_197");
            //    return false;
            //}
            // }

            // wpspNian();
            // CkeckWPSPairing();
            // //Send_To_SFC_PASS();
            //// if (!Check_SN("368930032105101500"));
            // okok1();        
            //CkeckWPSPairing();
            if (!WebAutoNian()) { return; }
            if (!SettingWifi6G("5", "1")) { return; }
            //Wifi2GTXCH1 = ReturnResult("ResultWF2GTX", "CH1");
            //  if (!PingToWifi("WiFi_2G_CH1", "192.168.2.101", "OBA2G"));
            //LogFilePass();
            // LogFilePass();
            // Save_Time_test("123456789", "PASS", "", "784");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thStattus1 = true;
            if (!WebAutoNian()) { return; }
            if (!SettingWifi5G("36","")) { return; }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxcheckdutalive_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bug = true;
            thStattus1 = true;
            errs = "";          
            if (bug == true) {testing();}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WebAutoNianRST();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmmType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cmmType.SelectedIndex == 1)
            {
                cmmType.ForeColor = Color.Red;
                btnstatus.ForeColor = Color.Red;
                btnstatus.BackColor = Color.Yellow;

            }
            else
            {
                cmmType.ForeColor = Color.Blue;
                btnstatus.ForeColor = Color.Blue;
                btnstatus.BackColor = Color.Lime;
            }
            cmmType.Enabled = false;
        }
        bool count240s = true;
        bool resrtcount240s;
        //Thread thMutiple10 = null;  
        private void button2_Click_1(object sender, EventArgs e)
        {
            resrtcount240s = true;
            delay(1000);
            Thread thMutiple10 = new Thread(new ThreadStart(Dut240));
            thMutiple10.IsBackground = true;
            thMutiple10.Start();
        }
        public void Dut240()
        {
            // if (count240s == true)
            //  {
            resrtcount240s = false;
            count240s = false;
            if (button2.InvokeRequired)
            {
                button2.Invoke(new Action(() => button2.BackColor = Color.Yellow));
            }
            else button2.BackColor = Color.Yellow;

            for (int i = 0; i <= 240; i++)
            {
                if (resrtcount240s == true) return;
                if (button2.InvokeRequired)
                {
                    button2.Invoke(new Action(() => button2.Text = "Dut_Bootup " + i + "s"));
                }
                else button2.Text = "Dut_Bootup " + i + "s";
                delay(1000);
            }
            if (button2.InvokeRequired)
            {
                button2.Invoke(new Action(() => button2.Text = "Dut_Bootup_OK!!"));
            }
            else
                button2.Text = "Dut_Bootup_OK!!";
            if (button2.InvokeRequired)
            {
                button2.Invoke(new Action(() => button2.BackColor = Color.Lime));
            }
            else button2.BackColor = Color.Lime;
            count240s = true;
            //}
        }

        private void rFQAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cmmType.Enabled = true;
            //VoipAgain = true;
            //Type_Program = "ON";s
           // File.Delete(Directory.GetCurrentDirectory() + "\\SNtest.txt");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void botupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }

            //if (!Terminal_SFC())
            //{
            //    return;
            //}
           // delay(3000);
            msg("OP testing --> " + OP);
            if (!Check_SN(lbsndut.Text)) return;        
            // Check_ERRCODE(string err)
            Send_To_SFC_FAIL("FBOTUP");
            delay(300);
            Send_To_SFC_FAIL("FBOTUP");
            LogFileFail(errs, "FBOTUP");
            LogFile("FAIL", "FBOTUP");
        }

        private void ledWPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            if (!Check_SN(lbsndut.Text)) return;
            //if (!Terminal_SFC())
            //{
            //    return;
            //}
            // delay(3000);
            msg("OP testing --> " + OP);
            // Check_ERRCODE(string err)
            Send_To_SFC_FAIL("FLED03");
            delay(300);
            Send_To_SFC_FAIL("FLED03");
            LogFileFail(errs, "FLED03");
            LogFile("FAIL", "FLED03");
        }

        private void wEBToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            if (!Check_SN(lbsndut.Text)) return;
            //if (!Terminal_SFC())
            //{
            //    return;
            //}
            // delay(3000);
            msg("OP testing --> " + OP);
            // Check_ERRCODE(string err)
            Send_To_SFC_FAIL("EWEB00");
            delay(300);
            Send_To_SFC_FAIL("EWEB00");
            LogFileFail(errs, "EWEB00");
            LogFile("FAIL", "EWEB00");
        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            if (!Check_SN(lbsndut.Text)) return;
            //if (!Terminal_SFC())
            //{
            //    return;
            //}
            // delay(3000);
            msg("OP testing --> " + OP);
            // Check_ERRCODE(string err)
            Send_To_SFC_FAIL("EH0001");
            delay(300);
            Send_To_SFC_FAIL("EH0001");
            LogFileFail(errs, "EH0001");
            LogFile("FAIL", "EH0001");
        }

        private void dUTTựKhởiĐộngLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            msg("OP testing --> " + OP);
            if (!Check_SN(lbsndut.Text)) return;
            delay(500);
            errs = "Error_Reboot_Issue";
            Send_To_SFC_FAIL("FREBOT");
            delay(300);
            Send_To_SFC_FAIL("FREBOT");
            LogFileFail(errs, "FREBOT");
            LogFile("FAIL", "FREBOT");
        }

        private void bootupLầnĐầuCắmPSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            msg("OP testing --> " + OP);
            if (!Check_SN(lbsndut.Text.Trim())) { return; }
            delay(500);
            errs = "Error_Bootup_First";
            Send_To_SFC_FAIL("FBOOTF");
            delay(300);
            Send_To_SFC_FAIL("FBOOTF");
            LogFileFail(errs, "FBOOTF");
            LogFile("FAIL", "FBOOTF");
        }

        private void bootupTrongQuáTrìnhTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            msg("OP testing --> " + OP);
            if (!Check_SN(lbsndut.Text.Trim())) { return; }
            delay(500);
            errs = "Error_Bootup_Test";
            Send_To_SFC_FAIL("FBOTUP");
            delay(300);
            Send_To_SFC_FAIL("FBOTUP");
            LogFileFail(errs, "FBOTUP");
            LogFile("FAIL", "FBOTUP");
        }

        private void bootupSauKhiRTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbsndut.Text.Length < 16 | lbsndut.Text.Length > 18)
            {
                lbsndut.Clear();
                MyMessagesBox.Show("\n\n                  Nhap SN !!");
                return;
            }
            if (!btnLogin.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                return;
            }
            msg("OP testing --> " + OP);
            if (!Check_SN(lbsndut.Text.Trim())) { return; }
            delay(500);
            errs = "Error_Bootup_After_RTD";
            Send_To_SFC_FAIL("FBOOTR");
            delay(300);
            Send_To_SFC_FAIL("FBOOTR");
            LogFileFail(errs, "FBOOTR");
            LogFile("FAIL", "FBOOTR");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            cmmType.Enabled = true;
        }

        private void geckoWebBrowser1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
