using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cableConnectionsnmp;
using Com;
using Telnet;
using System.Threading;
using System.Collections;
using CmdApp;
using System.Net;
using System.IO.Ports;
using System.Diagnostics;
using sAudio;
using System.IO;
using AutoClickPosition;
using webbrow;
using Gecko.DOM;
using System.Net;
using System.Net.NetworkInformation;
using System.Globalization;
using NAudio;
using NAudio.Dsp;
using NAudio.CoreAudioApi;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Gecko;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

//using System.Text.Json;




namespace Automatic
{
    public partial class ProForm : Form
    {
        public ProForm()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(Application.StartupPath + "\\xulrunner");
            //PromptFactory.PromptServiceCreator = () => new FilteredPromptService();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//client
            //ThreadStart thStart = new ThreadStart(GetData);
            //thReceiveData = new Thread(thStart);
            //thReceiveData.IsBackground = true;
            //thReceiveData.Start();
            //Control.CheckForIllegalCrossThreadCalls = false;

            string[] ports = SerialPort.GetPortNames();
            //cbbComSFC.Items.AddRange(ports);
            cmbComVoip.Items.AddRange(ports);
            cmbcomzble.Items.AddRange(ports);

        }
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
        List<jsonNian> testDatas = new List<jsonNian>();
        //FunctionTime = new List<functionTime>
        //    {
        //        new functionTime{
            //this.testDatas.Add(new testData
            //{
            //    itemName = "WPS",
            //    itemValue = 1.00
            //});
        List<string> value1 = new List<string>();

        //public string k ()
        //{
        //    string k = "";
        //    jsonNian sp = new jsonNian();
        //    sp.modemName = "";
        //    sp.t
        //    return k;
        //}

        AutoClickPosition.Autoclick autoClickPosition = new AutoClickPosition.Autoclick();
        msnmp cable = new msnmp();
        cmdApp cmd = new cmdApp();
        Thread thReceiveData = null;
        Thread thbegin = null;
        Thread thVoip = null;
        Thread thMutiple1 = null;
        Thread thMutiple2 = null;
        Thread thMutiple3 = null;
        Thread thVoipAnanys = null;
        Thread thMutiple4 = null;
        Thread thMutiple5 = null;
        Thread thMutiple6 = null;
        Thread thMutiple7 = null;
        Thread thMutiple8 = null;
        Thread thMutiple9 = null;
        Thread thMutiple10 = null;
        Thread thMutiple11 = null;
        string sModem = "COM";
        string SSIDName = " ";
        int v_process = 0;
        int nam ;
        static ASCIIEncoding encoding = new ASCIIEncoding();
      
        Information inf = new Information();
        SerialPort serial = new SerialPort();
        SerialPort serialsfc = new SerialPort();
        //SerialPort serialThread = new SerialPort();
        Thread ServerDo = null;
        Socket sck;
        Errocode err = new Errocode();
        Common cmn = new Common();
        sAudio.Voip voip = new Voip();
        private List<double> value = new List<double>();
        private GeckoWebBrowser brower;
        private Telnet.TelnetClient telnet = new Telnet.TelnetClient();
        string IPSERVER = "172.21.25.241";
        string notes = "FUNCTIONPASS";
        string InfoIP = "10.0.0.1";
        string iptestEth2 = "10.0.0.20";
        string iptestEth3 = "10.0.0.30";
        string iptestEth4 = "10.0.0.40";
        string InfoIPfailCOX = "10.0.0.1";
        string line = "new";
        private const int volum_up = 0xA0000;
        private const int volum_down = 0x90000;
        private const int appcomand = 0x319;

        [DllImport("User32.dll")]

        public static extern IntPtr SendMessageW(IntPtr Wnd, int Msg, IntPtr Wpram, IntPtr Ipram);

        bool Feasa = false;
        bool count240s = true;
        bool resrtcount240s;
        private int fails;
        private int pass;
        private int countTimeTest;       
        private string mac;
        private string ModelnameFile;
        private string monitorSN = "";
        private bool timeweb = false;
        private bool p11 = false;
        private bool p22 = false;
        private bool NoiseP1 = false;
        private bool NoiseP2 = false;
        private int wavep1Top2;
        private int wavep2Top1;
        private int noiseVoipCount;
        private int noiseVoipCountP1;
        private int noiseVoipCountP2;
        private int noiseVoipSpect;
        private int minvoice;
        private int maxvoice;
        private int dupvoice;
        private int minvoice1;
        private int maxvoice1;
        private int dupvoice1;
        private int resultss;
        private int resPass;
        private int resFalse;
        int n_waitTimeOut = 45000;
        bool ButtonReset = false;
        private bool P1P2 = false;
        private bool startB = true;
        private bool voice1Stop = false;
        private bool voice2Stop = false;
        private bool voipfunction = false;
        private bool voipStart = false;
        private int countTimeWeb;
        private int pingCmts;
        private double values = 0;

        bool Label_Test = true;
        bool LockloginWeb = true;
        bool DKVOIP1 = false;
        bool DKlED1G = false;
        bool DKLED100M = false;
        bool DKLEDONLINE = false;
        bool VoiP1Pass = false;
        bool VoiP2Pass = false;
        bool thStattus1 = false;
        bool AnalysisVoipNian = false;
        bool thStattus2 = false;
        bool vstop = false;
        bool nk = false;
        bool timS;
        bool dkvoip = false;
        bool dkresetodefoult = true;     
        bool  dkvoipnian = true;
        bool wpsButton = false;
        bool getWANMAC1 = false;
        bool BLEstatus = false;
        bool CheckLed_USB = false;
        bool BLEresult = false;
        bool noise = false;
        bool VoiPNoise = false;
        bool DKPressLedOnline  = true;
        bool voipNoise = false;
        bool voipNoiseResult = false;
        bool VoipAgain = false;
        bool NoiseResultPASS = false;
        bool Checksignal_VOIPPass = false;
        bool NoiseResultFAIL = false;
        bool NoiseResult = false;
        bool VoipMoca = false;
        int VoiP1P2Again;
        int VoiP2P1Again;
        bool VoiP2P1Againtest;
        bool VoiP1P2Againtest;
        bool p1p2Picup;
        bool p1p2PicupResult;
        bool dklogin = true;       
        int demDup = 0;
        double averP1 = 0;
        double Dup1 = 0;
        double waveP1 = 0;
        double averP2 = 0;
        double Dup2 = 0;
        double waveP2 = 0;

        bool dkcheckVOIP = true;
        bool Dklognewpassword = true;
        //string errCode = "EFQA01";
        bool dkvoipretest = true;
        string SNDUT = "";
        string SSIDCDUT = "";
        string PASSWORDDUT = "";
        string SNDDUT = "";
        string CMMACDUT = "";
        string WANMACDUT = "";
        string MTAMACDUT = "";
        string pathsaveftp = "";
        string pathsaveftp1 = "";
        string pathsaveftp2 = "";
        string CMMACLabel = "";
        string MTAMACLabel = "";
        string WANMACLabel = "";
        string SNlabel = "";
        string pathfile1 = Directory.GetCurrentDirectory();
        string data;
        string errs;
        string Nian = "";
        string Type_Program  = "ON";
        string khuyen = "";
        string HW = "2.0";
        string model = "1";
        string boot = "S1TC-3.81.21.97";
        int SNlength = 18;
        string keyusbc = "USB";
        string lockpc = "no";
        string LedPhone = "no";
        string linkWeb = "http://10.0.0.1/";
        string linkWeb1 = "http://10.0.0.1/at_a_glance.jst";   //http://10.0.0.1/at_a_glance.jst   
        string linkWeb2 = "http://10.0.0.1/index.jst";
        string linkWebChangePassword = "http://10.0.0.1/admin_password_change.jst";
        string linkWebNetwork = "http://10.0.0.1/wireless_network_configuration.jst";
        string linkWebMOCA = "http://10.0.0.1/moca.jst";
        string linkReset = "http://10.0.0.1/restore_reboot.jst";
        string linkInfor = "http://10.0.0.1/network_setup.jst";
        string linkwifi  = "http://10.0.0.1/wireless_network_configuration.jst";
        string DocumentTitleWEBSSID1 = "XFINITY Smart Internet";
        string DocumentTitleWEBSSID2 = "Login";
        string DocumentTitleChangPassword = "Change Password";
        string DocumentTitleInfor = "Gateway > Connection > XFINITY Network - XFINITY";
        string DocumentTitleWifi = "Gateway > Connection > WiFi";
        string DocumentTitleMOCA = "MoCA";


        int DelayWatingWEB = 3000;
        string snvalue;
        int idpass;
        bool enableMocaWebPss;
        GeckoWebBrowser browser;
        bool checkPingEth1Pass;
        bool checkPingEth2Pass;
        bool checkPingEth3Pass;
        bool checkPingEth4Pass;
        bool Result_CheckLed_EthGreen;
        bool accessWebsiteNewPassCon;
        bool getWANMACPass;
        bool enableZigBeePass;
        bool disaZigBeePass;
        bool enableThreadPass;
        bool enableBLEPass;
        bool CheckLed_1000EthPass;
        bool CheckVoipP1toP2PASS;
        bool gw;
        bool gw1;
        bool PlayVoip;
        bool CheckLed_100EthPass;
        bool CheckLed_OnlinePass = false;
        bool CheckLed_WPSPass = false;
        bool DKGet_SN = false;
        bool checkPingMocaPass;
        string Ytext, Xtext;
        string LbMACText;
        string LbMTAText;
        string LbSN;
        bool getWifiPasswordPass;
        bool checkWifiPasswordPass;
        bool CheckVoipP2toP1PASS;
        string mt1, mt2, mt3, mt4, mt5, mt6, mt7, mt8;
        bool SNduplicate;
        bool accessWebsitePass = false;
        bool clickWPSWebPass;
        string DataComControl;
        string DataZbBle = "";
        string DataComVoip;
        int DIALTONE1 = 0;
        int DIALTONE2 = 0;
        string DataUsb;
        bool clickMocaWebPass;
        bool stoptestUSB = false;
        bool waitCheckLed1G;
        bool fanValuePass;
        bool Check_SNPass;
        bool noiseTestPass;
        bool GetInfLableSSIDNamePass;
        bool getSSIDNamePass;
        bool checkPingResetTodefaultPass;
        bool seyup1G;
        bool checkSpeed1GPass;
        bool checkSpeed100Pass;
        bool checkfailStatus;
        bool PingWPS  = true;
        bool SFC_flag = false;
        GeckoInputElement geckinputelement;
        bool dkfailssid = false;
        string InfoSW = "Can not Load";
        string Bootloadrrr = "Can not Load";
        string OP = "";     
        int waitWPS = 45000;
        int waitOnline = 45000;
        int wpsdelay = 350;
        int waitdisable = 3000;
        int waitanable = 2000;
        int nianping = 0;
        string Labview_part = @"D:\Test_Program\CGM4981"; //D:\Test_Program\CGM4981 D:\Test_Program\XLAXB8
        string sFeasa = "NotInfo";
        string sLine = "";
        string sComVoip = "";
        string sComUsb = "";
        string sCom = "";
        string SNledonline = "";
        string CMmacbuf = "";
        bool SNHieuPC = true;
        bool MACHieuPC = true;
        string SNlable = "null";
        string SSISNamelale = "null";
        string Passwordlale = "null";
        string CMmaclable = "null";
        string Wanmaclable = "null";
        string Mtamaclable = "null";


        double TimepingEth1 = 0.0;
        double TimepingEth2 = 0.0;
        double TimepingEth3 = 0.0;
        double TimepingEth4 = 0.0;
        double TimeSpeed1G = 0.0;
        double ledgrren = 0.0;
        double ledred = 0.0;
        double ledonline = 0.0;
        double checksignal = 0.0;

        double statusEth = 0.0;
        double DHPCIP = 0.0;
        double ledWPS = 0.0;
        double ledusb = 0.0;
        double ledusb1 = 0.0;
        double TimeSpeed100M = 0.0;
        double TimeEnableZgbee = 0.0;
        double TimeDisableZgbee = 0.0;
        double TimeEnableBLE = 0.0;
        double Timeweb = 0.0;
        double TimeMoca = 0.0;
        double TimeVoip1 = 0.0;
        double TimeVoip2 = 0.0;
        double Lable = 0.0;
        double FactoryRST = 0.0;
        double Infor1 = 0.0;
        double Infor2 = 0.0;

        double valueRed_Online = 0.00;
        double valueGreen_Online = 0.00;
        double valueBlue_Online = 0.00;
        double valueX_Online = 0.00;
        double valueY_Online = 0.00;


        double valueRed_WPS = 0.00;
        double valueGreen_WPS = 0.00;
        double valueBlue_WPS = 0.00;
        double valueX_WPS = 0.00;
        double valueY_WPS = 0.00;
        bool c_pingProduct = false; string Result = "";
        string Err_code = "";
        double TotalTest_Time = 0.00;


        private string  LoadResust(string partfile,string Notes)
        {
            string Info1 = "Get Information: Not Infomation";
            try
            {
                string file_path = Labview_part + partfile;
                StreamReader loadinfor = new StreamReader(file_path, Encoding.UTF8);
                Info1 = "-----> LoadResustFile :  " + Notes + " : " + loadinfor.ReadToEnd() + " <--LoadResustFile----End.";
                loadinfor.Close();
                return Info1;
            }
            catch
            {
                return Info1;
            }         
        }
        private double LoadResust1(string partfile)
        {
            double Info1 = 0.0;
            try
            {             
                string Info2 = " ";
                string file_path = Labview_part + partfile;
                StreamReader loadinfor = new StreamReader(file_path, Encoding.UTF8);
                string Info = loadinfor.ReadToEnd();
                loadinfor.Close();
                int cout = Info.Length;
                if (partfile.Contains("Red"))
                {
                    Info2 = Info.Substring(9, cout - 9).Trim();
                }
                else if (partfile.Contains("Green"))
                {
                    Info2 = Info.Substring(12, cout-12).Trim();
                }
                else if (partfile.Contains("Blue"))
                {
                    Info2 = Info.Substring(11, cout-11).Trim();
                }
                else if (partfile.Contains("X"))
                {
                    Info2 = Info.Substring(8, cout-8).Trim();
                }
                else if(partfile.Contains("Y"))
                {
                    Info2 = Info.Substring(8, cout-8).Trim();
                }
                Info1 = Convert.ToDouble(Info2);
                return Info1;
            }
            catch
            {               
                return Info1;
            }
        }
        private void LoadResustWPS()
        {       
            string RGBWPS = Labview_part + "\\LEDWPSXB8\\RGBWPS.txt";
            //string XYWPS = Labview_part + "\\LEDWPSXB8\\XYWPS.txt";

            StreamReader loadledonline = new StreamReader(RGBWPS, Encoding.UTF8);
            string RGBWPSz = loadledonline.ReadToEnd();
            loadledonline.Close();
            //StreamReader loadledonline1 = new StreamReader(XYWPS, Encoding.UTF8);
            //string XYWPSz = loadledonline1.ReadToEnd();
            //loadledonline.Close();
            msg("Load_value_RGB_led_WPS ==> \n" + RGBWPSz + "\n");            
            try
            {
                string valueRed_WPS1 = File.ReadLines(RGBWPS).Skip(0).Take(1).First().Trim();
                int length1 = valueRed_WPS1.Length;
                string valueRed_WPS2 = valueRed_WPS1.Substring(5, length1 - 5);
                valueRed_WPS = Convert.ToDouble(valueRed_WPS2);
            }
            catch { valueRed_WPS = 0; }
            try
            {
                string valueGreen_WPS1 = File.ReadLines(RGBWPS).Skip(1).Take(1).First().Trim();
                int length1 = valueGreen_WPS1.Length;
                string valueGreen_WPS2 = valueGreen_WPS1.Substring(7, length1 - 7);
                valueGreen_WPS = Convert.ToDouble(valueGreen_WPS2);
            }
            catch { valueGreen_WPS = 0; }
            try
            {
                string valueBlue_WPS1 = File.ReadLines(RGBWPS).Skip(2).Take(1).First().Trim();
                int length1 = valueBlue_WPS1.Length;
                string valueBlue_WPS2 = valueBlue_WPS1.Substring(6, length1 - 6);
                valueBlue_WPS = Convert.ToDouble(valueBlue_WPS2);
            }
            catch { valueBlue_WPS = 0; }
            
            //try
            //{
            //    string valueX_WPS1 = File.ReadLines(XYWPS).Skip(0).Take(1).First().Trim();
            //    int length1 = valueX_WPS1.Length;
            //    string valueX_WPS2 = valueX_WPS1.Substring(3, length1 - 3);
            //    valueX_WPS = Convert.ToDouble(valueX_WPS2);
            //}
            //catch { valueX_WPS = 0; }
            //try
            //{
            //    string valueY_WPS1 = File.ReadLines(XYWPS).Skip(1).Take(1).First().Trim();
            //    int length1 = valueY_WPS1.Length;
            //    string valueY_WPS2 = valueY_WPS1.Substring(3, length1 - 3);
            //    valueY_WPS = Convert.ToDouble(valueY_WPS2);
            //}
            //catch { valueY_WPS = 0; }
        }
        private bool LoadInfoModem()
        {
            bool a = true;
            try
            {         
                txtInfoModem.Text = inforSW;
                if (txtInfoModem.Text == "")
                {
                    MessageBox.Show("Load_Fail_Information => FAIL!!");
                    return false;
                }
                string swtool = getKeyEnd(inforSW, "HW_REV:").Trim();// 
                string[] bufNian = inforSW.Split(';');
                string BootLd = bufNian[2];
                string SWare1 = bufNian[3];
                InfoSW = getKeyEnd(SWare1, "SW_REV:").Trim();
                Bootloadrrr = getKeyEnd(BootLd, "BOOTR:").Trim();
                boot = Bootloadrrr;
                lbSoftware.Text = InfoSW;
                lbBootver.Text = Bootloadrrr;
                return true;
            }
            catch
            {
                cmmModem.Enabled = true;
                a = false;
                return false;
            }
            return a;
        }
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
                string ii = getKeyEndNian(NoteOP,uu);                    
                if(ii == "")
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
            msg(Function+ "  "+ timeend + " END");
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
            double TimeStart = GettimeStart("WEB_UI");
            if (sModem != "CGM4981COX" & sModem != "CGM4981SHW")
            {
                if(!ConfigSSIDPassword()) { StatusERR("FAIL WEB FIRST"); return false; }
            }
            if (!LoginWEBFirst()) { StatusERR("accessWebsite"); return false; }
            timeTest.Enabled = false;
            MyMessagesBox.Show("\n\n           Rut_RF_CABLE!!");
            timeTest.Enabled = true;
            delay(70000);
            if (Dklognewpassword == true)
            {
                //if (!ChangePassword()) { StatusERR("changePasswordWebsite"); return false; }
            }
            else { msg("Wating!! Login new password");}
            if (!LoginWithNewPassword()) { StatusERR("LoginWithNewPassword"); return false;}
            if (!GetMACInforWEBUI()) { StatusERR("GetInforMAC_Address"); return false;}
            if (!GeWifiInforWEBUI()) { StatusERR("Bootup_Wifi"); return false;}
            if (Label_Test == true)
            {
                thMutiple6 = new Thread(new ThreadStart(thrLable));
                thMutiple6.IsBackground = true;
                thMutiple6.Start();
            }
            if (!enableMocaWebCOM()) { StatusERR("noiseTest"); return false;}
            double TimeEnd = GettimeEnd("WEB_UI");
            Timeweb = CountTime("LogInWeb_UI",TimeStart, TimeEnd);
            return true;
        }
        private bool WebAutoNian1()
        {
            geckoWebBrowser1.Visible = true;
            if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
            {
                if (!LoginWithNewPassword()) { StatusERR("LoginWithNewPassword"); return false; }
            }
            ResetFactorySeting();
            return true;
        }
        private string Loadtxt(string FileName)
        {
            string Info1 = "Get Information: Not Good";
            for (int i =0;i<10;i++)
            {
            try
            {
               
                string file_path = Labview_part + "\\" + FileName + ".txt";
                StreamReader loadinfor = new StreamReader(file_path, Encoding.UTF8);
                Info1 = loadinfor.ReadToEnd();           
                break;
            }
            catch
            {
                    Delay(2000);
            }
            }
            return Info1;

        }
        public void thrMultledOnline()
        {
            try
            {
                delay(125000);
                if (!CheckLed_OnlineNian()) return;
            }
            catch
            {
                StatusERR("Fail Thread Led_Online");
            }
           return;         
        }
        public void EthGreen()
        {
            try
            {
                if (!CheckLed_EthGreen()) { ErrorNian("Err_Eth1_Led_Green"); return; }
            }
            catch { }
        }
        public void thereadSN()
        {
            try
            {
                if (!GetSN()) return;
            }
            catch { }
        }
        public void thchecksignal()
        {
            try
            {
                if (!Checksignal_VOIP()) return;
            }
            catch { }
        }
        private bool Checksignal_VOIP()
        {
            double TimeStart = GettimeStart("Check_signal_VOIP");
            string Result_signal = "";
            Checksignal_VOIPPass = false;
            Status("Check_signal_VOIP");
            msg("Start Check_signal_VOIP");
            bool led1 = true;
            bool led2 = true;
            bool led3 = true;
            bool led4 = true;
            bool led5 = true;
            bool led6 = true;
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 2; i++)
                {
                    Result_signal = socket_string("PHONE");

                    if (Result_signal.Contains("Client send WRONG format"))
                    {
                        Checksignal_VOIPPass = false;
                        ErrorNian("Err_Check_signal");
                        break;
                    }
                    var data = Result_signal.Split('\n');
                    if (data[0].Contains("OFF")) { led1 = false; }
                    if (data[1].Contains("OFF")) { led2 = false; }
                    if (data[2].Contains("OFF")) { led3 = false; }
                    if (data[3].Contains("OFF")) { led4 = false; }
                    if (data[4].Contains("OFF")) { led5 = false; }
                    if (data[5].Contains("OFF")) { led6 = false; }
                    if (led1 & led2 & led3 & led4 & led5 & led6)
                    {
                        Checksignal_VOIPPass = true;
                        msgPass("Check_signal_VOIP ");
                        break;
                    }
                    else
                    {
                        if (!led1 & !led2 & !led3 & !led4 & !led5 & !led6)
                        {
                            Checksignal_VOIPPass = false;
                            ErrorNian("Err_NO_Voltage");
                            break;
                        }
                        if (!led2 & !led3 & !led4)
                        {
                            Checksignal_VOIPPass = false;
                            ErrorNian("Err_Port2_no_Voltage");
                            break;
                        }
                        if (!led1 & !led5 & !led6)
                        {
                            Checksignal_VOIPPass = false;
                            ErrorNian("Err_Port1_no_Voltage");
                            break;
                        }
                        if (!led2)
                        {
                            Checksignal_VOIPPass = false;
                            ErrorNian("Err_RJ11_Phone");
                            break;
                        }
                        if (!led1)
                        {
                            Checksignal_VOIPPass = false;
                            ErrorNian("Err_RJ11_Modem");
                            break;
                        }
                    }
                }
            }
            double TimeEnd = GettimeEnd("Check_signal_VOIP");
            checksignal = CountTime("Check_signal_VOIP", TimeStart, TimeEnd);
            return Checksignal_VOIPPass;
        }
        public void thrMultledWPS()
        {
            LockloginWeb = true;
            try
            {
                if (!CheckLed_WPSNian(1))
                {
                    if (!CheckLed_OnlineNian()) { StatusERR("Fail Led_oline"); return; }                   
                    delay(5000);
                    if (!CheckLed_USB_C()) { ErrorNian("Err_USB_TypeC"); StatusERR("Fail_LED_USB"); return; }
                    if (sLine == "T1") { comCmd("out6_on"); }
                    delay(90000);
                    if (sLine == "T1")
                    {
                        comCmd("out9_on");
                        delay(6000);
                        comCmd("out9_off");
                        delay(5000);
                    }
                    else
                    {
                        comCmd("bton");
                        delay(6000);
                        comCmd("btof");
                        delay(5000);
                    }
                    if (!CheckLed_WPSNian(2))
                    {
                        return;
                    }
                    
                    //MyMessagesBox.Show("\n\n      Pls.Gọi kỹ sư QE kiểm tra WPS\n          0353002840!!!");
                    LockloginWeb = false;
                }
                else
                {
                    delay(10000);
                    if (!CheckLed_USB_C()) { ErrorNian("Err_USB_TypeC"); StatusERR("Fail_LED_USB"); return; }
                    delay(110000);
                    if (!CheckLed_OnlineNian()) {StatusERR("Fail Led_oline"); return; }
                    LockloginWeb = false;
                }
            }
            catch
            {
                StatusERR("Fail Thread Led_Online");
            }
            return;
        }
        public void thrMultPingbootup() //nianokok
        {
            checkFail_BootUp_WPS();
        }
        public void thrMultVOIP()
        {
            try
            {
                dkresetodefoult = true;
                if (CheckVoipP1toP2PASS == false)
                {
                    double TimeStart = GettimeStart("VOIP1");
                    Status4("CHECK P1 >> P2 VOIP");
                    if (!CheckVoipP1toP2Nian()) { dkvoipretest = true; StatusERR("CheckVoipP1toP2"); return; }
                    if (!noiseTest("P1toP2"))
                    {
                        dkvoipretest = true;
                        StatusERR("noiseTestP1toP2");
                        CallP1toP2nian();
                        if (!noiseTest("P1toP2"))
                        {
                            ErrorNian("Err_voip_noise_P1");
                            return;
                        }
                    }
                    CheckVoipP1toP2PASS = true;
                    double TimeEnd = GettimeEnd("VOIP1");
                    TimeVoip1 = CountTime("VOIP1", TimeStart, TimeEnd);
                }
                if (CheckVoipP2toP1PASS == false)
                {
                    double TimeStart = GettimeStart("VOIP2");
                    Status4("CHECK P2 >> P1 VOIP");
                    if (!CheckVoipP2toP1Nian()) { dkvoipretest = true; StatusERR("CheckVoipP2toP1"); return; }
                    if (!noiseTest("P2toP1"))
                    {
                        dkvoipretest = true;
                        StatusERR("noiseTestP2toP1");
                        CallP2toP1Nian();
                        if (!noiseTest("P2toP1"))
                        {
                            ErrorNian("Err_voip_noise_P2");
                            return;
                        }
                    }
                    CheckVoipP2toP1PASS = true;
                    dkresetodefoult = false;
                    double TimeEnd = GettimeEnd("VOIP2");
                    TimeVoip2 = CountTime("VOIP2", TimeStart, TimeEnd);
                }
                Status4("CHECK VOIP COMPLETE");
                dkvoipretest = false;
                dkvoip = false;
            }
            catch { }
        }
        public void thrMultVOIP1()
        {
            double TimeStart = GettimeStart("VOIP");
            Status4("CHECK P1 >> P2 VOIP");
            if (!CheckVoipP1toP2Nian()) { dkvoipretest = true; StatusERR("CheckVoipP1toP2"); return; } //CheckVoipP2toP1Nian
            Status4("NOISE_TESTP1toP2");
            if (!noiseTest("P1toP2")) { dkvoipretest = true; StatusERR("noiseTestP1toP2"); return; }
            Status4("CHECK P2 >> P1 VOIP");
            if (!CheckVoipP2toP1Nian()) { dkvoipretest = true; StatusERR("CheckVoipP2toP1"); return; } //CheckVoipP1toP2Nian
            Status4("NOISE_TESTP2toP1");
            if (!noiseTest("P2toP1")) {StatusERR("noiseTestP2toP1"); return; }
            Status4("CHECK VOIP COMPLETE");
            double TimeEnd = GettimeEnd("VOIP");
            TimeVoip1 = CountTime("VOIP", TimeStart, TimeEnd);
            dkvoip = true;
        }
        public void threadZBBLE()
        {   try
            {
                if (thStattus1 == true)
                {
                    if (!enableZigbee()) { StatusERR("enableZigbee"); return; }
                    delay(2000);
                    if (!enableBLE()) { StatusERR("enableBLE"); return; }
                    delay(40000);
                    if (!disableZigbee()) { StatusERR("disableZigbee"); return; }
                }
                else return;
            }
            catch
            {           
                StatusERR("Fail Thrad BLE");
                return;
            }                                         
        }       
        public void thrled100()
        {
            try
            {
                if (!CheckLed_Eth_Red())
                {
                    ErrorNian("Err_Eth1_Led_Red"); return;
                }
                if (sLine == "T1") { comCmd("out6_on"); }
                if (!CheckLed_USB_C()) { ErrorNian("Err_USB_TypeC"); StatusERR("Fail_LED_USB"); return; }
                if (sLine == "T1") { comCmd("out6_off"); }
               // else { comCmd("teon"); }
                delay(300);
                Status("CheckLed_100M-Pass");
            }
            catch { StatusERR("Fail Led WPS or Led 100M "); }
            return;
        }
        public string getKeyEnd(string databuffer, string start)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                if(databuffer.Contains(start))
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
            try
            {
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
            }
            catch { }
            return result;
        }
        public string getKeyEth(string databuffer, string start,string keyend)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
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
                    txttelnet.AppendText(strCongtent);
                    txtOutput.AppendText(strCongtent + "\n");

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
        private void Status(string status)
        {
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke(new Action(() => lbStatus.Text = "Checking " + status));
            }
            else lbStatus.Text = "Checking " + status;
        }

      
      
        private void Status4(string status)
        {
            if (lbStatus4.InvokeRequired)
            {
                lbStatus4.Invoke(new Action(() => lbStatus4.Text = "" + status));
            }
            else lbStatus4.Text = "" + status;
        }
        private void StatusERR(string status)
        {
            //if (lblerr.InvokeRequired)
            //{
            //    lblerr.Invoke(new Action(() => lblerr.Text = "Exception > " + status));
            //}
            //else lblerr.Text = "Exception => " + status;
        }

      
        private void msg(string Message)
        {
            try
            {
                if (txtOutput.InvokeRequired)
                {
                    txtOutput.Invoke(new Action(() =>
                    {
                        txtOutput.AppendText(Message + "\r\n");
                    }));
                }
                else
                {
                    txtOutput.AppendText(Message + "\r\n");
                }
            }
            catch { }                                    
        }
        private void msgnoie(string Message)
        {
            try
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new Action(() =>
                    {
                        textBox1.AppendText(Message + "\r\n");
                    }));
                }
                else
                {
                    textBox1.AppendText(Message + "\r\n");
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
            if (lbStatusPass.InvokeRequired)
            {
                lbStatusPass.Invoke(new Action(() => lbStatusPass.Text = Message + "___Pass"));
            }
            else lbStatusPass.Text = Message + "___Pass";
        }     
        private void fail(string ErroCode)//loi
        {
            string errs = "";
            if (thStattus1 == true)
            {
                thStattus1 = false;
                timeTest.Enabled = false;
                StopPGram();              
                PingWPS = false;
                nk = true;
                checkfailStatus = true;
                try
                {
                    msg(errs);
                    errs = ErroCode;
                    Check_ERRCODE(ErroCode);
                    FailOKOK();
                    msg("(" + "\"" + "^" + "\"" + ")" + errs);
                    fails++;
                    if (lbFail.InvokeRequired)
                    {
                        lbFail.Invoke(new Action(() => lbFail.Text = fails.ToString()));
                    }
                    else lbFail.Text = fails.ToString();
                    checkfailStatus = true;
                    msg("->Check_ERRCODE");
                    if (lbStatus.InvokeRequired)
                    {
                        lbStatus.Invoke(new Action(() =>
                        {
                            lbStatus.Text = errs;
                            lbStatus.ForeColor = Color.Red;
                        }));
                    }
                    else
                    {
                        lbStatus.Text = errs;
                        lbStatus.ForeColor = Color.Red;
                    }
                    set_speed_Eth_port("All", "1000");
                    ErroCode = "";
                    if (txtComFB.InvokeRequired)
                    {
                        txtComFB.Invoke(new Action(() => txtComFB.Clear()));
                    }
                    else { txtComFB.Clear(); }
                    checkfailStatus = true;
                    errs = "";
                    cmn.openExe1(pathfile1, "enableEth1");                  
                    timS = true;
                }
                catch (Exception ex)
                {
                    msg("Save & Send Err ->Fail__" + ex.Message.ToString());
                    Status("Save & Send Err ->Fail");
                }
            }
            else
            {

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
        private void MoveFile(int kk,string file, string time,string newname)
        {
            string filename1 = "AudioTest.mp3";
            string filename2 = "nsTest.mp3";
            string fileNewname = "AudioTest"+ newname +".mp3";
            string sourcepathFile = file;// + "AudioTest.mp3";
            ModelnameFile = sModem;
            string date = DateTime.Now.ToString("MM / dd / yyyy");
            date = DateTime.Now.ToString("dd-MM-yyyy");
            date = date.Replace("-", ".");
            string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile +"-VOiP-"+ time;
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
            else if(kk == 1)
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
        private void LogFile(string passFail, string error)
        {
            try
            {
                ModelnameFile = sModem;
                string time11 = "";
                string sns = "";
                string Data = ""; 
                string directoryPath1 = Directory.GetCurrentDirectory();
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                msg(DateTime.Now.ToString());
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                msg(Nian);
                if (txtOutput.InvokeRequired) { txtOutput.Invoke(new Action(() => Data = txtOutput.Text)); }
                else { Data = txtOutput.Text; }
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
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
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() =>
                    {
                         sns = lbsndut.Text.Trim();
                    }));
                }
                else
                {
                     sns = lbsndut.Text.Trim();
                }
                string filePath = directoryPath + @"\" + sns + "_" + passFail + "_" + time11+ "_" + Type_Program + ".txt";
                pathsaveftp = filePath;              
                string filePathSN = directoryPath1 + @"\SNtest.txt";
                StreamWriter strWrite = new StreamWriter(filePath, true);
                strWrite.WriteLine(Data);
                strWrite.Flush();
                strWrite.Close();
                delay(100);         
                if (passFail.Contains("PASS"))
                {
                    if (txtOutput.InvokeRequired) { txtOutput.Invoke(new Action(() => txtOutput.Clear())); }
                    else { txtOutput.Clear(); }
                }
                else
                {
                    try
                    {
                        cmn.kill("notepad");
                        delay(500);
                        StreamWriter strWrite1 = new StreamWriter(filePathSN, true);
                        strWrite1.WriteLine(lbsndut.Text);
                        strWrite1.Flush();
                        strWrite1.Close();
                    }
                    catch { }
                }
                if (Type_Program == "ON")
                {
                    cmn.openExe1(pathfile1, "disableEthAll-SV");
                    delay(1500);
                    Save_Time_test(sns, passFail, error, time11);
                    try
                    {
                        SeveFile(pathsaveftp);
                        //SeveFile(pathsaveftp1);
                        //SeveFile(pathsaveftp2);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
               // cmn.openExe1(pathfile1, "ResetEthSever");
            }
        }

        private void logfileunlock(string data)
        {
            string filePathSN = Directory.GetCurrentDirectory() + @"\logfileunlockmaintain.ini";
            StreamWriter strWrite1 = new StreamWriter(filePathSN, true);
            strWrite1.WriteLine(data);
            strWrite1.Flush();
            strWrite1.Close();
        }
        private void LogFiledata(string data)
        {
            try
            {
                ModelnameFile = sModem;  
                string sns = "";
                string directoryPath1 = Directory.GetCurrentDirectory();
                string date = DateTime.Now.TimeOfDay.Hours.ToString() + "h" + DateTime.Now.TimeOfDay.Minutes.ToString() + "p" + DateTime.Now.TimeOfDay.Seconds.ToString() + "s";

                string directoryPath = "D:\\LogFileDATA";
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }      
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() =>
                    {
                        sns = lbsndut.Text.Trim();
                    }));
                }
                else
                {
                    sns = lbsndut.Text.Trim();
                }
                string filePath = directoryPath + @"\" + sns + "_" + date + "_"  + ".txt";

                StreamWriter strWrite = new StreamWriter(filePath, true);
                strWrite.WriteLine(data);
                strWrite.Flush();
                strWrite.Close();
                
            }
            catch (Exception ex)
            {             
                // cmn.openExe1(pathfile1, "ResetEthSever");
            }
        }
        private void Save_Time_test(string SnDUT, string reult, string error, string time)
        {
            try
            {
                TotalTest_Time = Convert.ToDouble(time);
                Result = reult;
                string pathfile = Directory.GetCurrentDirectory();
                string path2 = pathfile + "\\Sendjson.exe";            
                var weatherForecast = new jsonNian
                {
                    modelName = sModem,
                    route = "OBAFUNCTION",
                    station = Computer_name,
                    sn = SnDUT,
                    result = Result,
                    errorCode = error,
                    totalTime = TotalTest_Time,
                    FunctionTime = new List<functionTime>
            {
                new functionTime{name ="ETH_1",testTime=TimepingEth1},
                new functionTime{name ="ETH_2",testTime=TimepingEth2},
                new functionTime{name ="ETH_3",testTime=TimepingEth3},
                new functionTime{name ="ETH_4",testTime=TimepingEth4},
                new functionTime{name ="INFORMATION",testTime=(Infor1 + Infor2)},
                new functionTime{name ="INITIAL_SETUP",testTime=Timeweb},
                new functionTime{name ="USB_C",testTime=(ledusb + ledusb1)},
                new functionTime{name ="LED_ONLINE",testTime=ledonline},
                new functionTime{name ="LED_WPS",testTime=ledWPS},
                new functionTime{name ="LED_GREEN",testTime=(ledgrren + TimeSpeed1G)},
                new functionTime{name ="LED_RED",testTime=(ledred + TimeSpeed100M)},
                new functionTime{name ="ZIGBEE",testTime=(TimeEnableZgbee + TimeDisableZgbee+2)},
                new functionTime{name ="BLE",testTime=(TimeEnableBLE+2)},
                new functionTime{name ="VOIP_12",testTime=TimeVoip1},
                new functionTime{name ="VOIP_21",testTime=TimeVoip2},
                new functionTime{name ="MOCA",testTime=TimeMoca},
                new functionTime{name ="LABEL",testTime=Lable},
                new functionTime{name ="RTD",testTime=FactoryRST},
            },
                    TestData = new List<testData>
            {
                new testData{itemName ="Online_R",itemValue=valueRed_Online}, //
                new testData{itemName ="Online_G",itemValue=valueGreen_Online},//valueGreen_Online
                new testData{itemName ="Online_B",itemValue=valueBlue_Online},//valueBlue_Online
                new testData{itemName ="Online_X",itemValue=valueX_Online},//valueX_Online
                new testData{itemName ="Online_Y",itemValue=valueY_Online},//valueY_Online
                new testData{itemName ="WPS_R",itemValue=valueRed_WPS},//valueRed_WPS
                new testData{itemName ="WPS_G",itemValue=valueGreen_WPS},//valueGreen_WPS
                new testData{itemName ="WPS_B",itemValue=valueBlue_WPS},//valueBlue_WPS
                new testData{itemName ="VOIP_averP1",itemValue=averP1},//valueBlue_WPS
                new testData{itemName ="VOIP_Dup1",itemValue=Dup1},//valueBlue_WPS
                new testData{itemName ="VOIP_waveP1",itemValue=waveP1},//valueBlue_WPS
                new testData{itemName ="VOIP_averP2",itemValue=averP2},//valueBlue_WPS
                new testData{itemName ="VOIP_Dup2",itemValue=Dup2},//valueBlue_WPS
                new testData{itemName ="VOIP_waveP2",itemValue=waveP2},//valueBlue_WPS
            },
                };
                string Data = JsonConvert.SerializeObject(weatherForecast, Formatting.Indented);
                string pathfile1 = Directory.GetCurrentDirectory();
                string file_path = pathfile1  + "\\data.json";
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }


        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            public string SummaryField;
            public IList<DateTimeOffset> DatesAvailable { get; set; }
            public Dictionary<string, HighLowTemps> TemperatureRanges
            {
                get;
                set;
            }
            public string[] SummaryWords { get; set; }
        }
        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }
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
        private void LogFilePassNian(string result,string Err)
        {
            pathsaveftp2 = "";
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
                string filePathSN3 = directoryPath + @"\Summary.ini";
                pathsaveftp2 = filePathSN3;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                if (!File.Exists(filePathSN3))
                {
                    StreamWriter strWrite1 = new StreamWriter(filePathSN3, true);
                    strWrite1.WriteLine("Model \tSN \tResult \tErrorcode \tTime \tvalueRed_Online  \tvalueGreen_Online \tvalueBlue_Online \tvalueX_Online \tvalueY_Online \tvalueRed_WPS \tvalueGreen_WPS \tvalueBlue_WPS");
                    strWrite1.Flush();
                    strWrite1.Close();
                    delay(1000);
                }
                StreamWriter strWrite = new StreamWriter(filePathSN3, true);
                strWrite.WriteLine(sModem + "\t" + sns + "\t"+ result + "\t" + Err + "\t" + time + "\t"
                + valueRed_Online+"\t"+
                +valueGreen_Online + "\t" +
                +valueBlue_Online + "\t" +
                +valueX_Online + "\t" +
                +valueY_Online + "\t" +

                +valueRed_WPS + "\t" +
                +valueGreen_WPS + "\t" +
                +valueBlue_WPS);              
                strWrite.Flush();
                strWrite.Close();
            }          
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }           
        }
        private void LogFilePass(string passFail)
        {
            try
            {
                string infor = "";
                ModelnameFile = sModem;
                msg(DateTime.Now.ToString());
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath1 = Directory.GetCurrentDirectory();
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }

                string sns = "wxwx";
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                }
                else
                {
                    sns = lbsndut.Text;
                }

                string filePathSN2 = directoryPath1 + @"\SN2.txt";
                string filePathSN3 = directoryPath + @"\pass.ini";
                if (File.Exists(filePathSN2) == true)
                {
                    File.Delete(filePathSN2);
                }
                StreamWriter strWrite2 = new StreamWriter(filePathSN2, true);
                StreamWriter strWrite3 = new StreamWriter(filePathSN3, true);
                if (lbTimecc.InvokeRequired)
                {
                    lbTimecc.Invoke(new Action(() => msg("Tottal_TestTime:" + lbTimecc.Text)));
                }
                else
                {
                    msg("Tottal_TestTime:" + lbTimecc.Text);
                }
                if (!System.IO.Directory.Exists(directoryPath1))
                {
                    System.IO.Directory.CreateDirectory(directoryPath1);

                    /// string filePath = directoryPath + @"\" + sns + passFail + lbTime.Text + ".txt";
                    /// StreamWriter strWrite = new StreamWriter(@"" + filePath, true);
                    strWrite2.WriteLine(snvalue);
                    strWrite3.WriteLine(snvalue + "__pass");
                    delay(1000);
                    strWrite2.Flush();
                    strWrite2.Close();
                    strWrite3.Flush();
                    strWrite3.Close();
                    delay(1000);
                    /* if (txtResult.InvokeRequired)
                     {
                         txtResult.Invoke(new Action(() => txtResult.Clear()));
                     }
                     else
                     {
                         txtResult.Clear();
                     }
                     if (txtOutput.InvokeRequired)
                     {
                         txtOutput.Invoke(new Action(() => txtOutput.Clear()));
                     }
                     else
                     {
                         txtOutput.Clear();
                     }
                     */

                }
                else
                {
                    System.IO.Directory.CreateDirectory(directoryPath1);
                    if (lbsndut.InvokeRequired)
                    {
                        lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                    }
                    else
                    {
                        sns = lbsndut.Text;
                    }
                    // string filePath = directoryPath + sns + passFail + ".txt";
                    ///string filePath = directoryPath + @"\" + sns + passFail + lbTime.Text + ".txt";
                    //StreamWriter strWrite = new StreamWriter(@"" + filePath, true);
                    /// StreamWriter strWrite = new StreamWriter(filePath, true);
                    strWrite2.WriteLine(barcode2D_SN);
                    strWrite3.WriteLine(sns + "__pass");
                    delay(1000);
                    strWrite2.Flush();
                    strWrite2.Close();
                    strWrite3.Flush();
                    strWrite3.Close();
                    delay(1000);
                    /*if (txtResult.InvokeRequired)
                    {
                        txtResult.Invoke(new Action(() => txtResult.Clear()));
                    }
                    else
                    {
                        txtResult.Clear();
                    }
                    if (txtOutput.InvokeRequired)
                    {
                        txtOutput.Invoke(new Action(() => txtOutput.Clear()));
                    }
                    else
                    {
                        txtOutput.Clear();
                    }*/
                }
                //timeTest.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
            //ResetRelay();
        }
        private void LogFileFail(string err11 , string Error)
        {
            pathsaveftp1 = "";
            try
            {
                ModelnameFile = sModem;
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                string sns = "xxxxx";
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                }
                else
                {
                    sns = lbsndut.Text;
                }
                string filePathSN3 = directoryPath + @"\SummaryFail.ini";
                pathsaveftp1 = filePathSN3;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                if (!File.Exists(filePathSN3))
                {
                    StreamWriter strWrite3 = new StreamWriter(filePathSN3, true);
                    strWrite3.WriteLine("SN \tType \tSN \t Time \t ");
                    strWrite3.Flush();
                    strWrite3.Close();
                    delay(1000);
                }
                StreamWriter strWrite1 = new StreamWriter(filePathSN3, true);
                strWrite1.WriteLine(sns + "\t" + Type_Program + "\t" + err11 + "\t" + Error + "\t" + DateTime.Now.ToString());
                strWrite1.Flush();
                strWrite1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
        }
        private void LogFilePassVOIP(string passFail, string filename, string data)
        {
            try
            {

                string infor = "";
                ModelnameFile = sModem +"_VO";
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath1 = Directory.GetCurrentDirectory();
                string directoryPath = "D:\\LogFile" + @"\" + date + "\\" + ModelnameFile;
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                string sns = "wxwx";
                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                }
                else
                {
                    sns = lbsndut.Text;
                }

                string filePathSN2 = directoryPath + @"\" + filename;
                StreamWriter strWrite2 = new StreamWriter(filePathSN2, true);
                if (lbTimecc.InvokeRequired)
                {
                    lbTimecc.Invoke(new Action(() => msg("Tottal_TestTime:" + lbTimecc.Text)));
                }
                else
                {
                    msg("Tottal_TestTime:" + lbTimecc.Text);
                }

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);

                    /// string filePath = directoryPath + @"\" + sns + passFail + lbTime.Text + ".txt";
                    /// StreamWriter strWrite = new StreamWriter(@"" + filePath, true);
                    strWrite2.WriteLine(data);
                    delay(1000);
                    strWrite2.Flush();
                    strWrite2.Close();
                    delay(1000);
                    /* if (txtResult.InvokeRequired)
                     {
                         txtResult.Invoke(new Action(() => txtResult.Clear()));
                     }
                     else
                     {
                         txtResult.Clear();
                     }
                     if (txtOutput.InvokeRequired)
                     {
                         txtOutput.Invoke(new Action(() => txtOutput.Clear()));
                     }
                     else
                     {
                         txtOutput.Clear();
                     }
                     */

                }
                else
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                    if (lbsndut.InvokeRequired)
                    {
                        lbsndut.Invoke(new Action(() => sns = lbsndut.Text));
                    }
                    else
                    {
                        sns = lbsndut.Text;
                    }
                    // string filePath = directoryPath + sns + passFail + ".txt";
                    ///string filePath = directoryPath + @"\" + sns + passFail + lbTime.Text + ".txt";
                    //StreamWriter strWrite = new StreamWriter(@"" + filePath, true);
                    /// StreamWriter strWrite = new StreamWriter(filePath, true);
                    strWrite2.WriteLine(data);
                    delay(1000);
                    strWrite2.Flush();
                    strWrite2.Close();
                    delay(1000);
                    /* if (txtResult.InvokeRequired)
                     {
                         txtResult.Invoke(new Action(() => txtResult.Clear()));
                     }
                     else
                     {
                         txtResult.Clear();
                     }
                     if (txtOutput.InvokeRequired)
                     {
                         txtOutput.Invoke(new Action(() => txtOutput.Clear()));
                     }
                     else
                     {
                         txtOutput.Clear();
                     }*/
                }
                // timeTest.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
            //ResetRelay();
        }
        private bool loadComport()
        {
            bool a = false;
            try
            {
                List<string> Devices = new List<string>();
                string[] comDevice = null;
                comDevice = SerialPort.GetPortNames();
                string pathfile2 = Directory.GetCurrentDirectory();
                string file_path2 = pathfile2 + "\\ProSetting.txt";
                StreamReader loadinfor2 = new StreamReader(file_path2, Encoding.UTF8);
                string sCom1 = loadinfor2.ReadLine();
                string sComSFC1 = loadinfor2.ReadLine();
                string ComVoip1 = loadinfor2.ReadLine();
                line = loadinfor2.ReadLine();
                keyusbc = loadinfor2.ReadLine();
                string lockpc1 = loadinfor2.ReadLine();
                string LedPhone1 = loadinfor2.ReadLine();
                loadinfor2.Close();
                sCom = getKeyEnd(sCom1, "COMVDK:").Trim();//
                sLine = getKeyEnd(sComSFC1, "Type:").Trim();
                sComVoip = getKeyEnd(ComVoip1, "COMVoip:").Trim();
                lockpc = getKeyEnd(lockpc1, "Lock:").Trim();
                LedPhone = getKeyEnd(LedPhone1, "LedPhone:").Trim();
                cmbComport.Text = sCom;
                cmbComVoip.Text = sComVoip;
                if (line.Contains("old")) { line = "old"; }
                else { line = "new"; }
                foreach (string device in comDevice)
                {
                    Devices.Add(device);
                    if (this.cmbComport.InvokeRequired)
                    {
                        cmbComport.Invoke(new Action(() => cmbComport.Items.Add(device)));
                    }
                    else cmbComport.Items.Add(device);
                    if (this.cmbComport.InvokeRequired)
                    {
                        cmbComVoip.Invoke(new Action(() => cmbComVoip.Items.Add(device)));
                    }
                    else cmbComVoip.Items.Add(device);
                    return true;
                }
            }
            catch { MyMessagesBox.Show("\n\nKiem tra Proseting.txt");
                return false;
            }
            return a;
        }
        private void comSfcConnect(string Name, int bauRate)
        {
            try
            {
                if (!serialsfc.IsOpen)
                {
                    //serial.Close();
                    serialsfc.Dispose();
                    delay(2000);
                }
                serialsfc.BaudRate = bauRate;
                serialsfc.PortName = Name;
                serialsfc.Parity = Parity.None;
                serialsfc.StopBits = StopBits.One;
                serialsfc.DataBits = 8;
                serialsfc.Handshake = Handshake.None;
                serialsfc.RtsEnable = true;
                serialsfc.Open();
                serialsfc.DataReceived += new SerialDataReceivedEventHandler(_comSfc_DataReceived);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void _comSfc_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bufSFC = "";
          //  bufSFC = ComSFC.ReadLine();
            //str_SFC = bufSFC.Trim();
            if (InvokeRequired)
            {
                txtOutput.Invoke(new Action(() =>
                {
                    txtOutput.AppendText(bufSFC + "\r\n");
                }));
            }
            else
            {
                txtOutput.AppendText(bufSFC + "\r\n");
            }

        }
        private void comConnect(string Name, int bauRate)
        {
            try
            {
                if (!serial.IsOpen)
                {
                    //serial.Close();
                    serial.Dispose();
                    delay(2000);
                }
                serial.BaudRate = bauRate;
                serial.PortName = Name;
                serial.Parity = Parity.None;
                serial.StopBits = StopBits.One;
                serial.DataBits = 8;
                serial.Handshake = Handshake.None;
                serial.RtsEnable = true;
                serial.Open();
                serial.DataReceived += new SerialDataReceivedEventHandler(_com1_DataReceived);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void comConnectThread(string Name, int bauRate)
        {
            //try
            //{
            //    if (!serialThread.IsOpen)
            //    {
            //        serialThread.Close();
            //        delay(2000);
            //        serialThread = new SerialPort();
            //    }
            //    serialThread.BaudRate = bauRate;
            //    serialThread.PortName = Name;
            //    serialThread.Parity = Parity.None;
            //    serialThread.StopBits = StopBits.One;
            //    serialThread.DataBits = 8;
            //    serialThread.Handshake = Handshake.None;
            //    serialThread.RtsEnable = true;
            //    serialThread.Open();
            //    serialThread.DataReceived += new SerialDataReceivedEventHandler(_com1_DataReceivedThread);

            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //    //  MessageBox.Show(ex.Message.ToString());
            //}
        }
        private void loadData()
        {
            lbId1.Text = cmn.getValueLoadfile("Voice P1_1:");
            lbId2.Text = cmn.getValueLoadfile("Voice P1_2:");
            lbId3.Text = cmn.getValueLoadfile("Voice P1_3:");
            lbId4.Text = cmn.getValueLoadfile("Voice P1_4:");
            lbId5.Text = cmn.getValueLoadfile("Voice P1_5:");
            lbId6.Text = cmn.getValueLoadfile("Voice P1_6:");
            lbId7.Text = cmn.getValueLoadfile("Voice P1_7:");
            lbId8.Text = cmn.getValueLoadfile("Voice P1_8:");
            lbId9.Text = cmn.getValueLoadfile("Voice P1_9:");
            lbId10.Text = cmn.getValueLoadfile("Voice P1_10:");
            lbIdmin.Text = cmn.getValueLoadfile("Voice P1_min:");
            lbIdmax.Text = cmn.getValueLoadfile("Voice P1_max:");
            lbIddup.Text = cmn.getValueLoadfile("Voice P1_dup:");
            lbWaveP1toP2.Text = cmn.getValueLoadfile("Voice P1_wave1:");
            lbid11.Text = cmn.getValueLoadfile("Voice P2_1:");
            lbid12.Text = cmn.getValueLoadfile("Voice P2_2:");
            lbid13.Text = cmn.getValueLoadfile("Voice P2_3:");
            lbid14.Text = cmn.getValueLoadfile("Voice P2_4:");
            lbid15.Text = cmn.getValueLoadfile("Voice P2_5:");
            lbid16.Text = cmn.getValueLoadfile("Voice P2_6:");
            lbid17.Text = cmn.getValueLoadfile("Voice P2_7:");
            lbid18.Text = cmn.getValueLoadfile("Voice P2_8:");
            lbid19.Text = cmn.getValueLoadfile("Voice P2_9:");
            lbid20.Text = cmn.getValueLoadfile("Voice P2_10:");
            lbidmin1.Text = cmn.getValueLoadfile("Voice P2_min:");
            lbidmax1.Text = cmn.getValueLoadfile("Voice P2_max:");
            lbiddup1.Text = cmn.getValueLoadfile("Voice P2_dup:");
            lbWaveP2toP1.Text = cmn.getValueLoadfile("Voice P2_wave2:");
            lbNoiseCount.Text = cmn.getValueLoadfile("Voice NS_Ct_P1:");
            string noiseP2 = cmn.getValueLoadfile("Voice NS_Ct_P2:");
            lbNoiseSp.Text = cmn.getValueLoadfile("Voice NS_spec:");
            minvoice = int.Parse(lbIdmin.Text);
            maxvoice = int.Parse(lbIdmax.Text);
            dupvoice = int.Parse(lbIddup.Text);
            minvoice1 = int.Parse(lbidmin1.Text);
            maxvoice1 = int.Parse(lbidmax1.Text);
            dupvoice1 = int.Parse(lbiddup1.Text);
            wavep1Top2 = int.Parse(lbWaveP1toP2.Text);
            wavep2Top1 = int.Parse(lbWaveP2toP1.Text);
            noiseVoipCountP1 = int.Parse(lbNoiseCount.Text);
            noiseVoipCountP2 = int.Parse(noiseP2);
            noiseVoipSpect = int.Parse(lbNoiseSp.Text);
        }
        private void SerialVOIP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Delay(1000);
            string data = ComVoip.ReadExisting();
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() =>
                {
                    txtOutput.AppendText(data + "\n");
                    DataComVoip = data;
                }));
            }
            else
            {
                txtOutput.AppendText(data + "\n");
                DataComVoip = data;
            }
        }

        //private void TestUSB()
        //{
        //    double TimeStart = GettimeStart("USB_TypeC");
        //    comUsbCmd("test_usb");
        //    delay(1000);
        //    int n = 0;
        //    int k = 0;
        //    int fa = 0;
        //    List<string> VA = new List<string>();
        //    double valueUsb = 5;
        //    bool a = false;
        //    bool flac = false;
        //    bool TestUSB = false;
        //    TestUSB = true;
        //    while (true)
        //    {
        //        if (nk == true) break;
        //        try
        //        {
        //            valueUsb = Convert.ToDouble(DataUsb);
        //        }
        //        catch (Exception ex)
        //        {
        //            //MessageBox.Show(ex.ToString());
        //            //fa++;
        //            //if (fa >= 10)
        //            //{
        //            //    a = false;
        //            //    ErrorNian("Err_USB_TypeC");
        //            //    comUsbCmd("stop_usb");
        //            //    TestUSB = false;
        //            //}
        //            //MessageBox.Show("Hãy kiểm tra USB Type C !!");
        //        }
        //        if (valueUsb == 0)
        //        {
        //            if (flac == false)
        //            {
        //                fa++;
        //                if (fa >= 10)
        //                {
        //                    a = false;
        //                    ErrorNian("Err_USB_TypeC");
        //                    comUsbCmd("stop_usb");
        //                    TestUSB = false;
        //                    break;
        //                }
        //                DialogResult va = MessageBox.Show("Hãy kiểm tra USB Type C !!", "USB_Type_C", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //                if (va == DialogResult.Yes | va == DialogResult.No)
        //                {
        //                    valueUsb = 5;
        //                    flac = true;
        //                }
        //            }
        //        }
        //        if(valueUsb < 4)
        //        {
        //            n++;
        //            msg("Volgate_USB_TypeC _Issue-> " + valueUsb.ToString()+"Volt");
        //            if (n == 1 & flac == true)
        //            {
        //                a = false;
        //                ErrorNian("Err_USB_TypeC");
        //                comUsbCmd("stop_usb");
        //                TestUSB = false;
        //                break;
        //            }
        //            delay(10);
        //        }
        //        else if (valueUsb > 6)
        //        {
        //            n++;
        //            msg("Volgate_USB_TypeC _Issue-> " + valueUsb.ToString() + "Volt");
        //            if (n == 1)
        //            {
        //                a = false;
        //                ErrorNian("Err_USB_TypeC");
        //                comUsbCmd("stop_usb");
        //                TestUSB = false;
        //                break;
        //            }
        //            delay(10);
        //        }
        //        else
        //        {   
        //            k++;
        //            if (k < 40)
        //            {
        //                VA.Add(valueUsb.ToString()+ "Volt");
        //            }                 
        //            delay(100);
        //        }
        //        if (stoptestUSB == true)
        //        {
        //            a = true;
        //            msgPass("Test_USB_TypeC");
        //            comUsbCmd("stop_usb");
        //            TestUSB = false;                 
        //            for (int o = 0; o < 30; o++)
        //            {

        //                if (txtOutput.InvokeRequired)
        //                {
        //                    txtOutput.Invoke(new Action(() =>
        //                    {
        //                        txtOutput.AppendText(VA[o].ToString() + "\n");
        //                    }));
        //                }
        //                else
        //                {
        //                    try
        //                    {
        //                        txtOutput.AppendText(VA[o].ToString() + "\n");
        //                    }
        //                    catch { }                         
        //                }
        //            }
        //            break;
        //        }
        //        delay(100);
        //    }
        //    double TimeEnd = GettimeEnd("USB_TypeC");
        //    Timeweb = CountTime("USB_TypeC", TimeStart, TimeEnd);
        //}
        private bool comCmd1to2(string cmd)
        {
            bool a = false;
            DataComVoip = "";
            for (int i = 1; i <= 20; i++)
            {
                try
                {
                    ComVoip.Write(cmd + "\n\r");
                    delay(2500);
                    if (cmd.Contains("ATD"))
                    {
                        delay(13000);
                        if (DataComVoip.Contains("DIALTONE"))
                        {
                            if (i >= 3)
                            {
                                DIALTONE1++;
                                if (DIALTONE1 >= 2)
                                {
                                    ErrorNian("Err_Voip_P1ToP2_Call");
                                    a = false;
                                    return false;
                                }
                                a = false;
                                return false;
                            }
                        }
                        else if (DataComVoip.Contains("BUSY"))
                        {
                            if (i >= 3)
                            {
                                DIALTONE1++;
                                if (DIALTONE1 >= 2)
                                {
                                    ErrorNian("Err_Voip_P1ToP2_Busy");
                                    a = false;
                                    return false;
                                }
                                if (sLine == "T1") { comCmd("out5_off"); }
                                else { comCmd("teof"); }
                                a = false;
                                return false;
                            }
                        }
                        else
                        {
                            DataComVoip = "";
                            a = true;
                            i = 1;
                            return true;
                        }
                    }
                    else
                    {
                        for (int u = 0; u <= 20; u++)
                        {
                            return true;
                            if (DataComVoip.Contains("OK"))
                            {
                                DataComVoip = "";
                                a = true;
                                i = 1;
                                return true;
                            }
                            else
                            {
                                delay(500);
                            }
                        }
                    }
                }
                catch
                {
                    if (i == 5)
                    {
                        MessageBox.Show("Lỗi gửi Command Module VOIP !!!");
                    }
                    if (i == 10)
                    {
                        msg("~~Fail Module V90/V92~~");
                        ErrorNian("Err_Voip_P1ToP2_Other");
                        dkvoipnian = false;
                        return false;
                    }
                    delay(1000);
                }
            }
            return a;
        }
        private bool comCmd2to1(string cmd)
        {
            bool a = false;
            DataComVoip = "";
            for (int i = 1; i <= 20; i++)
            {
                try
                {
                    ComVoip.Write(cmd + "\n\r");
                    delay(2500);
                    if (cmd.Contains("ATD"))
                    {
                        delay(13000);
                        if (DataComVoip.Contains("DIALTONE"))
                        {
                            if (i >= 3)
                            {
                                DIALTONE2++;
                                if (DIALTONE2 >= 2)
                                {
                                    ErrorNian("Err_Voip_P2ToP1_Call");
                                    a = false;
                                    return false;
                                }
                                a = false;
                                return false;
                            }
                        }
                        else if (DataComVoip.Contains("BUSY"))
                        {
                            if (i >= 3)
                            {
                                DIALTONE1++;
                                if (DIALTONE1 >= 2)
                                {
                                    ErrorNian("Err_Voip_P2ToP1_Busy");
                                    a = false;
                                    return false;
                                }
                                if (sLine == "T1") { comCmd("out5_off"); }
                                else { comCmd("teof"); }
                                a = false;
                                return false;
                            }
                        }
                        else
                        {
                            DataComVoip = "";
                            a = true;
                            i = 1;
                            return true;
                        }
                    }
                    else
                    {
                        for (int u = 0; u <= 20; u++)
                        {
                            return true;
                            if (DataComVoip.Contains("OK"))
                            {
                                DataComVoip = "";
                                a = true;
                                i = 1;
                                return true;
                            }
                            else
                            {
                                delay(500);
                            }
                        }
                    }
                }
                catch
                {
                    if (i == 5)
                    {
                        MessageBox.Show("Lỗi gửi Command Module VOIP !!!");
                    }
                    if (i == 10)
                    {
                        msg("~~Fail Module V90/V92~~");
                        ErrorNian("Err_Voip_P1ToP2_Other");
                        dkvoipnian = false;
                        return false;
                    }
                    delay(1000);
                }
            }
            return a;
        }
        private void ErrorNian(string maloi)
        {
            if (cmmType.InvokeRequired)
            {
                cmmType.Invoke(new Action(() => {
                    if (cmmType.SelectedIndex == 1) { Type_Program = "OFF";}}));
            }
            else { if (cmmType.SelectedIndex == 1) { Type_Program = "OFF"; } }
            if (txtComFB.InvokeRequired)
            {
                txtComFB.Invoke(new Action(() => txtComFB.Clear()));
            }
            else { txtComFB.Clear(); }
            Nian = "";
            Nian = maloi;
            thMutiple8 = new Thread(new ThreadStart(thrMultFail));
            thMutiple8.IsBackground = true;
            thMutiple8.Start();
            //delay(5000);
        }
        private void DataReceived_ZBBLE(object sender, SerialDataReceivedEventArgs e)
        {         
            DataZbBle = ComZBLE.ReadLine();                
        }
        int countPSU = 0;
        private void _com1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //data = "";
            if (sLine == "T1") { DataComControl = ComVDK.ReadLine();}
            else { DataComControl = ComVDK.ReadExisting();}
            if (txtComFB.InvokeRequired)
            {
                txtComFB.Invoke(new Action(() =>
                {
                    txtComFB.AppendText(DataComControl + "\r\n");                    
                }));
            }
            else
            {
                txtComFB.AppendText(DataComControl + "\r\n");               
            }
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() =>
                {
                    txtOutput.AppendText(DataComControl + "\r\n");                
                }));
            }
            else
            {
                txtOutput.AppendText(DataComControl + "\r\n");             
            }
            if (DataComControl.Contains("Warning"))
            {
                countPSU++;
                if (thStattus1 == true)
                {
                    LogFilePSU(data);
                    if (DataComControl.Contains("PW_1"))
                    {
                        if (countPSU >= 3)
                        {
                            ErrorNian("Err_PSU_1");
                            MyMessagesBox.Show("\n\nPls. Call Kỹ Sư QE kiểm tra PSU 1!");
                        }
                    }
                    else
                    {
                        if (countPSU >= 3)
                        {
                            ErrorNian("Err_PSU_2");
                            MyMessagesBox.Show("\n\nPls. Call Kỹ Sư QE kiểm tra PSU 2!");
                        }
                    }
                }
                delay(1500);
            }

        }
        private void comCmd(string cmd)
        {
            DataComControl = "";
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() =>
                {
                    txtOutput.AppendText(cmd + "\r\n");
                }));
            }
            else
            {
                txtOutput.AppendText(cmd + "\r\n");
            }
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    ComVDK.Write(cmd + "\n");
                    delay(1000);
                    if (DataComControl.Contains("OK") | DataComControl.Contains("ok"))
                    {
                        break;
                    }
                    else
                    {
                        if (i >= 10)
                        {
                            MessageBox.Show("Gui va nhan lenh xuong controlboard khong thanh cong");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                /// MessageBox.Show("serialWrite" + ex.Message);
            }
        }
        private void comCmdRN(string cmd)
        {
            serial.Write(cmd + "\n");

            delay(200);
        }
        private void comClose()
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                    delay(200);
                }

            }
            catch (Exception ex)
            { }

        }
        private void comCmdThread(string cmd)
        {

        }
        private void comCmdZBBLE(string cmd)
        {
            try
            {
                ComZBLE.Write("\n" + "\n" + cmd + "\n");
                delay(100);
            }
            catch
            {
                ComZBLE.Write("\n" + "\n" + cmd + "\n");
                delay(100);
            }
        }
        private bool comCmdZ(string cmd)
        {
            bool a = false;
            bool b = true;
            int u = 0;
            int o = 0;
            while (b)
            {
                try
                {                   
                    ComZBLE.Write(cmd + "\n" + "\n");
                    delay(1000);
                    if(DataZbBle.Contains("root@Docsis-Gateway:~# "))
                    {
                        u++;
                        o = o - 2;
                        if(u >= 3)
                        {
                            a = true;
                            b = false;
                            break;
                        }                       
                    }
                    else
                    {
                        o++;
                        {
                            if (o >= 15)
                            {
                                a = false;
                                b = false;
                                break;
                            }
                        }
                        delay(1000);
                    }
                    DataZbBle = "";
                }
                catch
                {
                    ComZBLE.Write(cmd);
                    delay(100);

                }
            }                    
            return a;
        }
        private void comCmdRNThread(string cmd)
        {

            //try
            //{
            //    String temp = cmd + "\r";
            //    //serialThread.Write(temp);
            //    delay(200);
            //}
            //catch
            //{
            //    String temp = cmd + "\r";
            //    serialThread.Write(temp);
            //    delay(200);
            //}
        }
        private void comCloseThread()
        {
            //try
            //{
            //    if (serialThread.IsOpen)
            //    {
            //        serialThread.Close();
            //    }

            //    delay(200);
            //}
            //catch (Exception ex)
            //{ }
        }
        private void Initialprogram()
        {
            btnStart.Enabled = false;
            int minvoice;
            int maxvoice;
            int dupvoice;
            int minvoice1;
            int maxvoice1;
            int dupvoice1;
            minvoice = int.Parse(lbIdmin.Text.Substring(4, 2));
            maxvoice = int.Parse(lbIdmax.Text.Substring(4, 2));
            dupvoice = int.Parse(lbIddup.Text.Substring(4, 2));
            minvoice1 = int.Parse(lbidmin1.Text.Substring(4, 2));
            maxvoice1 = int.Parse(lbidmax1.Text.Substring(4, 2));
            dupvoice1 = int.Parse(lbiddup1.Text.Substring(4, 2));
            txtOutput.Clear();
            txtOutput.Clear();
            txttelnet.Clear();
            txtSever.Clear();
            txtclient.Clear();
            bool st = true;
        }

        private bool ResetFactorySeting()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            comCmd("out5_off");
            delay(300);
            //comCmd1to2("ATH");
            int cout = 0;
            if (thStattus1 == true)
            {
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                geckoWebBrowser1.Visible = true;
                Status("ResetFactory_WEB_UI");
                geckoWebBrowser1.Navigate(linkReset);
                delay(3000);
                for (int n = 0; n <= 30; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkReset))
                    {
                        try
                        {
                            GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                            break;
                        }
                        catch { delay(1000); }
                    }
                    if (n == 15)
                    {
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            LoginWithNewPassword1();
                            geckoWebBrowser1.Navigate(linkReset);
                            delay(5000);
                        }
                    }
                    if (n >= 30)
                    {
                        return false;
                    }
                    delay(1000);
                }          
                while (b)
                {
                    try
                    {
                        GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                        Submit_reset.Click();
                        for (int n1 = 0; n1 <= 45; n1++)
                        {
                            try
                            {
                                GeckoInputElement ss = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_title").DomObject);
                                string dd = ss.TextContent;
                                if (dd.Contains("Are You Sure?"))
                                {
                                    GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                    click.Click();
                                    delay(5000);
                                    try
                                    {
                                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                        geckinputelement.Click();
                                    }
                                    catch { }
                                    delay(30000);
                                    msgPass("Reset_DUT_WEBUI");
                                    a = true;
                                    b = false;
                                    StopWEB();
                                    return true;
                                }
                            }
                            catch
                            {
                                if (n1 >= 20)
                                {
                                    msg("Err_ResetFactory_WEB ");
                                    b = false;
                                    return false;
                                }
                            }
                            delay(1000);
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 10)
                        {
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkReset);
                        delay(5000);
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            LoginWithNewPassword1();
                            geckoWebBrowser1.Navigate(linkReset);
                            delay(5000);
                        }
                    }
                }
            }
            else
            {
                Status("Err_ResetFactory_WEB");
                return false;
            }

            return a;
        }
        private bool checkPingTimeout()
        {
            bool a = false;
            bool b = true;
            bool resetdutpass = true;
            watingrst = true;
            int j = 0;
            int total3 = 0;
            int pingtimeout1 = 0;
            int countPing = 0;
            Status("Reset to default DUT");
            msg("Reset to default DUT");
            for (int o = 1; o <= 2; o++)
            {
                b = true;
                msg("Test reset to defount time:  " + o);
                if (!ResetFactorySeting())
                {
                    if (sLine == "T1")
                    {
                        comCmd("out9_on");
                        delay(50000);
                        comCmd("out9_off");
                        delay(15000);
                    }
                    else
                    {
                        comCmd("bton");
                        delay(50000);
                        comCmd("btof");
                        delay(15000);
                    }
                }
                for (int i = 0; i <= 100; i++)
                {
                    total3++;
                    Delay(1000);
                    if (total3 >= 26) { break; }
                    Status4("Wait_Ping_Timeout: " + i.ToString());
                }
                while (b)
                {
                    if(thStattus1 == false) return false;
                    cmn.pingToAddress(InfoIP);
                    msg(cmn.pingdata);
                    if (!string.IsNullOrEmpty(cmn.pingdata))
                    {
                        if (cmn.pingdata.Contains("Can not ping to"))
                        {
                            pingtimeout1++;
                            if (pingtimeout1 >= 10)
                            {
                                countPing = 0;
                                pingtimeout1 = 0;
                                msgPass("PingTimeout");
                                j = 0;
                                a = true;
                                b = false;
                                return true;
                            }
                        }
                        else
                        {
                            Status("Wait Ping TimeOut: " + countPing.ToString());
                            countPing++;
                            if (countPing >= 40) //30
                            {
                                msg("PingTimeout Fail !!!");
                                if (o >= 2)
                                {
                                    msg("Error Ping TimeOut ");
                                    b = false;
                                    a = false;
                                    pingtimeout1 = 0;
                                    countPing = 0;
                                    ErrorNian("Err_Ping_Timeout");
                                    return false;
                                }
                                // resetdutpass = false;
                                pingtimeout1 = 0;
                                countPing = 0;
                                b = false;
                                break;
                            }                         
                        }
                    }
                }
            }
            return a;
        }
        private bool checkPingTimeoutWeb()
        {
            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            int pingtimeout1 = 0;
            int countPing = 0;
            Status("checkPingTimeout");
            msg("checkPingTimeout");
            while (b)
            {
                if (mt8.Equals("Checking")) { b = false; }
                cmn.pingToAddress(InfoIP);

                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;

                        if (pingtimeout1 > 0)
                        {
                            countPing = 0;
                            pingtimeout1 = 0;
                            msgPass("checkPingTimeout");
                            a = true;
                            b = false;
                        }
                    }
                    else
                    {
                        delay(800);
                        countPing++;
                        if (countPing > 50)
                        {
                            pingtimeout1 = 0;
                            countPing = 0;
                            b = false;
                        }
                    }
                }
                delay(150);
            }
            return a;
        }
        private bool checkPingtoDUTMoca(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, string ipAddress1, int pingtimeout, int countPing)
        {
            bool a = false;
            bool b = true;
            cmn.date_TimeStart();
            int ping = 0;
            int misspingmoca = 0;
            string pathfile1 = Directory.GetCurrentDirectory();
            Status(PingInformation);
            msg(PingInformation);
            if (thStattus1 == true)
            {
                while (b)
                {
                    if (thStattus1 == false) return false;
                    cmn.pingToAddress(ipAddress);
                    msg(cmn.pingdata);
                    if (!string.IsNullOrEmpty(cmn.pingdata))
                    {
                        if (cmn.pingdata.Contains("Can not ping to"))
                        {
                            if (nk == true) { break; }
                            ping = 0;
                            misspingmoca++;
                            delay(200);
                            if (misspingmoca >= pingtimeout)
                            {
                                misspingmoca = 0;
                                countPing = 0;
                                pingtimeout = 0;
                                msg(PingInformation + " can not ping");
                                return false;
                            }
                            if (misspingmoca == 5 | misspingmoca == 10)
                            {
                                cmn.openExe1(pathfile1, "disableEth1");
                                delay(1000);
                                cmn.openExe1(pathfile1, "enableEth1");
                                delay(7000);
                            }
                        }
                        else
                        {
                            misspingmoca = 0;
                            ping++;
                            if (ping >= 10)
                            {
                                countPing = 0;
                                pingtimeout = 0;
                                msgPass(PingInformation);
                                a = true;
                                b = false;
                                return true;
                            }
                        }
                    }
                }
            }
            return a;
        }
        private bool checkPingtoDUT(string PingInformation, string EthCardName, string EthCardNameDisable, string iptest, int pingtimeout, int countPing, string mt)
        {
            bool a = false;
            bool b = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            Status(PingInformation);
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(iptest);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {                  
                        pingtimeout1++;
                        ping = 0;
                        if (pingtimeout1 == 6 )
                        {
                            cmn.openExe1(pathfile1, "disable" + EthCardName);
                            delay(100);
                            cmn.openExe1(pathfile1, "enable" + EthCardName);
                            delay(10000);
                        }                                            
                        if (pingtimeout1 >= pingtimeout)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + " can not ping");
                            c_pingProduct = true;
                            b = false;
                            a = false;
                        }
                    }
                    else if(cmn.pingdata.Contains("TTL=64") || cmn.pingdata.Contains("TTL=128"))
                    {
                        ping++;
                        pingtimeout1 = 0;
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
        private bool checkPingResetToSefoul(string PingInformation, string EthCardName, string EthCardNameDisable, string iptest, int pingtimeout, int countPing, string mt)
        {
            bool a = false;
            bool b = true;

            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            Status(PingInformation);
            msg(PingInformation);
            while (b)
            {
                if (thStattus1 == false) return false;
                cmn.pingToAddress(iptest);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;
                        ping = 0;
                        if (pingtimeout1 == 40)
                        {
                            MyMessagesBox.Show("\n----------------!!WARING!!----------------\n            HÃY KIỂM TRA DUT \n      HOẠT ĐỘNG HAY KHÔNG ?");
                        }                   
                        if (pingtimeout1 >= 65)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + " can not ping!!");
                            b = false;
                            a = false;
                            Status("Err_PingafterReset");
                            ErrorNian("Error_Bootup_After_RTD");
                            return false;
                        }
                    }
                    else if (cmn.pingdata.Contains("TTL=64") || cmn.pingdata.Contains("TTL=128"))
                    {
                        ping++;
                        pingtimeout1 = 0;
                        if (ping >= 10)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msgPass(PingInformation);
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    delay(1000);
                }
            }
            return a;
        }
        private bool checkPingProductDHCP(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, int pingtimeout, int countPing, string mt)
        {
           
            bool a = false;
            bool b = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            //cmn.openExe1(pathfile1, "enable" + EthCardName);
            //Delay(2000);
            int pingtimeout1 = 0;
            int pingtimeout2 = 0;
            int ping = 0;
            Status(PingInformation);
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
                            c_pingProduct = true;
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
        private bool checkFail_BootUp()
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            if (sModem == "CGM4981COX")
            {
                cmn.openExe1(pathfile1, "disableEthSever");
                delay(500);
            }
            if (!checkPingBotupissue("checkPingProduct", "All", "", InfoIP, 3, 2, mt8))
            {
                c_pingProduct = true;
                return true;
            }
            else
            {
                if (sModem == "CGM4981COX")
                {
                    cmn.openExe1(pathfile1, "ResetEthSever");
                    delay(500);
                }
                c_pingProduct = true;
                return false;
            }
        }
        private void checkFail_BootUp_WPS()
        {
            delay(5000);
            c_pingProduct = true;
            string pathfile1 = Directory.GetCurrentDirectory();          
            if (!checkPingBotupissueWPSnian("Check BootUp WPS ", "All", "", InfoIP, 3, 2, mt8))
            {             
                ErrorNian("Error_Botup_Issue");               
            }          
        }
        private bool checkFail_BootUpVOIP(string Eth)//checkPingBotupVOIP
        {
            if (!checkPingBotupVOIP("checkPingProduct", Eth, "", InfoIP, 3, 2, mt8))
            {
                c_pingProduct = true;
                return true;
            }
            else
            {
                c_pingProduct = true;
                return false;
            }
        }//checkPingBotupVOIP
        private bool checkPingBotupissue(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, int pingtimeout, int countPing, string mt)
        {

            bool a = false;
            bool b = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, "enableEthAll");
            int pingtimeout1 = 0;
            int pingtimeout2 = 0;
            int ping = 0;
            Status(PingInformation);
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(ipAddress);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;
                        pingtimeout2++;
                        delay(100);
                        if (pingtimeout1 >= 3)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + " can not ping");
                            b = false;
                        }
                    }
                    else
                    {
                        ping++;
                        delay(300);
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
        private bool checkPingBotupissueWPSnian(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, int pingtimeout, int countPing, string mt)
        {

            bool a = false;
            bool b = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            int pingtimeout1 = 0;
            int ping = 0;
            Status(PingInformation);
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(ipAddress);        
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        msg(cmn.pingdata);
                        pingtimeout1++;
                        delay(100);
                        if (pingtimeout1 >= 6)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msg(PingInformation + ipAddress  + " ==> Fail BootUp ");
                            b = false;
                            return false;
                        }
                    }
                    else
                    {
                        ping++;
                        delay(300);
                        if (PingWPS == false)
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
        private bool checkPingBotupVOIP(string PingInformation, string EthCardName, string EthCardNameDisable, string ipAddress, int pingtimeout, int countPing, string mt)
        {

            bool a = false;
            bool b = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            Delay(2000);
            int pingtimeout1 = 0;
            int pingtimeout2 = 0;
            int ping = 0;
            Status(PingInformation);
            msg(PingInformation);
            while (b)
            {
                cmn.pingToAddress(ipAddress);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;
                        pingtimeout2++;
                        delay(200);
                        if (pingtimeout1 >= 3)
                        {
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
                Delay(150);
            }
            return a;
        }
        private bool checkPingtoCMTS()
        {
            bool a = false;
            bool b = true;
            int pingtimeout = 0;
            int ping = 0;
            Status("ping to CMTS");
            msg("ping to CMTS");
            while (b)
            {
                if (!checkStatustesting(mt8)) b = false;
                cmn.pingToAddress(inf.Ipcmts);
                delay(800);
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout++;

                        if (pingtimeout > 100)
                        {
                            ping = 0;
                            pingtimeout = 0;
                            msg("ping to CMTS" + " can not ping");                        
                            ErrorNian("Err_CMTS_Ping");                          
                            b = false;
                        }
                    }
                    else
                    {
                        ping++;
                        if (ping > 20)
                        {
                            ping = 0;
                            pingtimeout = 0;
                            msgPass("ping to CMTS");
                            a = true;
                            b = false;
                        }
                    }
                }
                delay(150);
            }
            return a;
        }
      
        private bool checkPingEth2()
        {
            bool a = false;
            double TimeStart = GettimeStart("Ping_Eth2");
            Status4("checkPingEth2");
            checkPingEth2Pass = false;
            string pathfile1 = Directory.GetCurrentDirectory();          
            if (thStattus1 == true)
            {
                if (checkPingtoDUT("Ping to Eth2", "Eth2", "Eth1-3-4", iptestEth2, 12, 6, mt8))
                {
                    nianping = 40;
                    checkPingEth2Pass = true;
                    msgPass("Ping_Eth2");
                    double TimeEnd = GettimeEnd("Ping_Eth2");
                    TimepingEth2 = CountTime("Ping_Eth2", TimeStart, TimeEnd);
                    a = true;
                    return true;
                }
                else
                {
                    Status4("Err_Eth2_Ping");                  
                    ErrorNian("Err_Eth2_Ping");
                    double TimeEnd = GettimeEnd("Ping_Eth2");
                    TimepingEth2 = CountTime("Ping_Eth2", TimeStart, TimeEnd);
                    return false;
                }
            }
            else
            {                              
                return false;
            }
            return a;
        }   
        private bool checkPingEth3()
        {
            double TimeStart = GettimeStart("Ping_Eth3");
            bool a = false;
            bool b = true;
            int count = 0;
            checkPingEth3Pass = false;
            Status4("checkPingEth3");
            if (thStattus1 == true)
            {              
                if (!checkStatustesting(mt8)) { mt8 = "Checking"; return a; }
                if (checkPingtoDUT("Ping to Eth3", "Eth3", " ", iptestEth3, 12, 6, mt8))
                {
                    nianping = 60;
                    checkPingEth3Pass = true;                 
                    msgPass("checkPingEth3");
                    a = true;
                    double TimeEnd = GettimeEnd("Ping_Eth3");
                    TimepingEth3 = CountTime("Ping_Eth3", TimeStart, TimeEnd);
                    return true;
                }
                else
                {
                    Status4("Err_Eth3_Ping");              
                    ErrorNian("Err_Eth3_Ping");
                    double TimeEnd = GettimeEnd("Ping_Eth3");
                    TimepingEth3 = CountTime("Ping_Eth3", TimeStart, TimeEnd);
                    return true;
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool checkPingEth4()
        {
            double TimeStart = GettimeStart("Ping_Eth3");
            bool a = false;
            bool b = true;
            int count = 0;
            checkPingEth4Pass = false;
            Status4("checkPingEth4");
            if (thStattus1 == true)
            {              
                if (!checkStatustesting(mt8)) { mt8 = "Checking"; return a; }
                if (checkPingtoDUT("Ping to Eth4", "Eth4", " ", iptestEth4, 12, 6, mt8))
                {
                    nianping = 100;
                    checkPingEth4Pass = true;                
                    msgPass("checkPingEth4");
                    a = true;
                    double TimeEnd = GettimeEnd("Ping_Eth4");
                    TimepingEth4 = CountTime("Ping_Eth4", TimeStart, TimeEnd);
                } 
                else
                {
                    Status4("Err_Eth4_Ping");               
                    ErrorNian("Err_Eth4_Ping");
                    double TimeEnd = GettimeEnd("Ping_Eth4");
                    TimepingEth4 = CountTime("Ping_Eth4", TimeStart, TimeEnd);
                    return false;
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool checkPingEth1()
        {
            bool a = false;
            bool b = true;
            int count = 0;
            checkPingEth1Pass = false;
            double TimeStart = GettimeStart("Ping_Eth1");
            Status4("checkPingEth1");
            if (thStattus1 == true)
            {
                List<string> list = new List<string>();
                while (b)
                {
                    list.Clear();
                    NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface n in nic.Where(card => card.OperationalStatus == OperationalStatus.Up))
                    {
                        string name = n.Name;
                        list.Add(name);
                    }
                    if (list.Contains("Eth1"))
                    {
                        break;
                    }
                    else
                    {
                        count++;
                        if (count >= 3)
                        {
                            ErrorNian("Err_Connect_Card_1");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra kêt nôi Eth1");
                            return false;
                        }
                        cmn.openExe1(pathfile1, "ResetEth1");
                        delay(10000);
                    }
                }
                if (checkPingtoDUT("Ping to Eth1", "Eth1", " ", InfoIP, 12, 6, mt8))
                {
                    nianping = 20;
                    checkPingEth1Pass = true;
                    msgPass("checkPingEth1");
                    double TimeEnd = GettimeEnd("Ping_Eth1");
                    TimepingEth1 = CountTime("Ping_Eth1", TimeStart, TimeEnd);
                    a = true;
                    return true;
                }
                else
                {
                    Status4("Err_Eth1_Ping");
                    cmd.CmdConnect();
                    cmd.CmdWrite("ipconfig /allcompartments");
                    Delay(100);
                    string Output = cmd.CmdRead();
                    cmd.CmdWrite("exit");
                    string y = cmdNianreturnIP(Output, "IP", "Eth1","IP");
                    if (y.Contains("169."))
                    {
                        ErrorNian("Err_Eth1_Ping_issue_IP169");
                        if (sModem == "CGM4981COX")
                        {
                            MyMessagesBox.Show("\n\n Pls.Reset test lai!!  Ping Cox issue");
                        }
                    }
                    else
                    {
                        ErrorNian("Err_Eth1_Ping");
                    }
                    double TimeEnd = GettimeEnd("Ping_Eth1");
                    TimepingEth1 = CountTime("Ping_Eth1", TimeStart, TimeEnd);
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
        private bool checkPingMocaMian()
        {
            double TimeStart = GettimeStart("Ping_To_Moca");
            string pathfile1 = Directory.GetCurrentDirectory();
            bool a = false;
            int count = 0;
            checkPingMocaPass = false;
            cmn.openExe1(pathfile1, "enableEth1");
            delay(3000);
            if (thStattus1 == true)
            {
                bool b = false;
                bool c = true;
                string ipmoca = "";
                for (int i = 0; i <= 10; i++)
                {
                    count = 0;
                    if (a == true | checkPingMocaPass == true) { return true; }
                    msg("Start Setup IP Moca ");
                    while (c)
                    {
                        if (thStattus1 == false) return false;
                        if (sModem != "CGM4331COX")
                        {
                            c = false;
                            b = true;
                            break;
                        }
                        cmn.openExe1(pathfile1, "mocaStIp");
                        delay(3000);
                        cmd.CmdConnect();
                        cmd.CmdWrite("ipconfig /allcompartments");
                        Delay(100);
                        string Output = cmd.CmdRead();
                        cmd.CmdWrite("exit");
                        string statusEth4 = cmdNianreturnIP(Output,"IP", "Eth1", "IP");
                        if (statusEth4.Contains("10.0."))
                        {
                            msgPass("ipmocaSetupStatus:==> " + ipmoca);
                            b = true;
                            c = false;
                            count = 0;
                            break;
                        }
                        else
                        {
                            count++;
                            if (count > 5)
                            {
                                msg("Err_Setup_Mo_IP");
                                b = true;
                                count = 0;
                                c = false;
                                break;
                            }
                        }
                    }
                    while (b)
                    {
                        count = 0;
                        if (thStattus1 == false) return false;
                        if (checkPingtoDUTMoca("Ping to Moca", "Eth1", "", inf.IpMoca, inf.IpMoca2, 15, 10))
                        {
                            checkPingMocaPass = true;
                            Status4("checkPingMoca_Pass");
                            msgPass("checkPingMoca");
                            cmn.openExe1(pathfile1, "mocaDyIp");
                            delay(1000);
                            double TimeEnd = GettimeEnd("Ping_To_Moca");
                            TimeMoca = CountTime("Ping_To_Moca", TimeStart, TimeEnd);
                            return true;
                        }
                        else
                        {
                            count++;
                            if (count >= 2)
                            {
                                PlugRFMOCA();
                            }
                            if (count >= 5)
                            {
                                Status("Err checkPingResetToMoca");
                                cmn.openExe1(pathfile1, "mocaDyIp");
                                delay(2000);
                                ErrorNian("Err_Ping_Moca");
                                double TimeEnd = GettimeEnd("Ping_To_Moca");
                                TimeMoca = CountTime("Ping_To_Moca", TimeStart, TimeEnd);
                                return false;
                            }
                            cmn.openExe1(pathfile1, "disableEth1");
                            delay(1000);
                            cmn.openExe1(pathfile1, "enableEth1");
                            delay(6000);
                        }
                    }
                }
            }
            else
            {

                return false;
            }
            return checkPingMocaPass;
        }

        private void Reset_to_default()
        {
            PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
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
        bool watingrst = true;
        private void RESETDUT1()
        {
            if (thStattus1 == true)
            {
                if (sModem == "CGM4981COX") { }
                else
                {
                    if (watingrst == true)
                    {
                        watingrst = false;
                        timeTest.Enabled = false;
                        DialogResult va = MyMessagesBox.Show("\n\r           !!!!--WARNING--!!!!\n\r            RUT DAY CABLE\n\r        RA KHOI SAN PHAM!");
                        if (va == DialogResult.Yes || va == DialogResult.No)
                        {
                            timeTest.Enabled = true;
                        }
                    }
                }
                try
                {
                    if (sLine == "T1")
                    {
                        comCmd("out9_on");
                        delay(45000);
                        comCmd("out9_off");
                        delay(15000);
                    }
                    else
                    {
                        comCmd("bton");
                        delay(45000);
                        comCmd("btof");
                        delay(15000);
                    }
                }
                catch
                {
                    if (sLine == "T1")
                    {
                        comCmd("out9_on");
                        delay(45000);
                        comCmd("out9_off");
                        delay(15000);
                    }
                    else
                    {
                        comCmd("bton");
                        delay(45000);
                        comCmd("btof");
                        delay(15000);
                    }
                }
            }
        }
        private void RESETDUT2()
        {
            if (sModem == "CGM4981COX") { }
            else
            {
                if (watingrst == true)
                {
                    watingrst = false;
                    timeTest.Enabled = false;
                    DialogResult va = MyMessagesBox.Show("\n\r           !!!!--WARNING--!!!!\n\r            RUT DAY CABLE\n\r        RA KHOI SAN PHAM!");
                    if (va == DialogResult.Yes || va == DialogResult.No)
                    { }
                }
            }
            try
            {
                if (sLine == "T1")
                {
                    comCmd("out9_on");
                    delay(50000);
                    comCmd("out9_off");
                    delay(15000);
                }
                else
                {
                    comCmd("bton");
                    delay(50000);
                    comCmd("btof");
                    delay(15000);
                }
            }
            catch
            {
                if (sLine == "T1")
                {
                    comCmd("out9_on");
                    delay(50000);
                    comCmd("out9_off");
                    delay(15000);
                }
                else
                {
                    comCmd("bton");
                    delay(50000);
                    comCmd("btof");
                    delay(15000);
                }
            }
        }
        private void RESETDUT()
        {
            ButtonReset = true;
            ThreadStart xx = new ThreadStart(RESETDUT1);//
            thMutiple1 = new Thread(xx);
            thMutiple1.IsBackground = true;
            thMutiple1.Start();
            delaySuperTime();          
            waiyputButtonReset();
        }
        private void Volumte_specaker()
        {
            try
            {
                for (int i = 0; i <= 50; i++)
                {
                    SendMessageW(this.Handle, appcomand, this.Handle, (IntPtr)volum_up);
                }
                //for (int i = 0; i <= 44; i++)
                //{
                //    SendMessageW(this.Handle, appcomand, this.Handle, (IntPtr)volum_down);
                //}/

                msg("Adjust Volume Speaker Pass ;))");
            }
            catch
            {
                msg("Adjust Volume Speaker Fail ;((");
            }
        }
        private bool checkDHCP()
        {
            int count = 0;
            msg("Check DHCP-IP " + sModem);
            string IPEth2 = "";
            string IPEth3 = "";
            string IPEth4 = "";
            string pathfile = "C:";
            bool a = false;
            int i;
            string pathfile1 = Directory.GetCurrentDirectory();
            for ( i = 0; i <= 5; i++)
            {             
                cmn.deleteFile(pathfile, "\\DHCPShowIP.txt");
                delay(500);
                cmn.openExe1(pathfile1, "showIpDHCP");
                delay(3000);
                string file_dhcp = pathfile + "\\DHCPShowIP.txt";
                try
                {
                     IPEth2 = File.ReadLines(file_dhcp).Skip(3).Take(1).First().Replace("IP Address:", "").Trim();
                     IPEth3 = File.ReadLines(file_dhcp).Skip(13).Take(1).First().Replace("IP Address:", "").Trim();
                     IPEth4 = File.ReadLines(file_dhcp).Skip(23).Take(1).First().Replace("IP Address:", "").Trim();
                }
                catch { }          
                
                
                                                               
                if (sModem == "CGM4981COX")
                {
                    //dhcpStIp
                    if (IPEth2.Equals("192.168.0.20") && IPEth3.Equals("192.168.0.30")&& IPEth4.Equals("192.168.0.40"))
                    {
                        a = true;
                        break;
                    }
                    else
                    {
                        MyMessagesBox.Show("Kiem tra Ip Eth2,3,4\n      192.168.0.20\n      192.168.0.30\n      192.168.0.40 ");
                        count++;
                        if(count == 4 )
                        {
                            a = false;
                            break;
                        }
                        cmn.openExe1(pathfile1, "NodhcpStIpCox");
                        delay(1000);                     
                    }
                }
                else
                {
                    if (IPEth2.Equals("10.0.0.20") && IPEth3.Equals("10.0.0.30") && IPEth4.Equals("10.0.0.40"))
                    {
                        a = true;
                        break;
                    }
                    else
                    {
                        count++;
                        if (count == 4)
                        {
                            a = false;
                            break;
                        }
                        MyMessagesBox.Show("Kiem tra Ip Eth2,3,4\n      10.0.0.20\n      10.0.0.30\n      10.0.0.40 ");
                        cmn.openExe1(pathfile1, "NodhcpStIp");
                        delay(1000);
                    }
                }
            }
            if(a == true) { msgPass("Check DHCP-IP " + i + " " + sModem );}
            else
            {
                msg("Check DHCP-IP Fail!! ");
                ///ErrorNian("Err_Set_DHCP_IP");
            }
            return a;
        }
        private bool checkPingResetTodefault()
        {
            set_speed_Eth_port("All", "1000");
            bool a = false;
            bool b = true;
            BLEstatus = true;
            string pathfile1 = Directory.GetCurrentDirectory();
            checkPingResetTodefaultPass = false;
            if (thStattus1 == true)
            {
                double TimeStart = GettimeStart("Factory_RST");
                if (!checkPingTimeout())
                {
                    StatusERR("Err_Ping_TimeOut");
                    return a;
                }
                delay(25000);
                Status("Ping Reset To Defaul");
                if (checkPingResetToSefoul("Ping Reset Todefault", "EthAll", "", InfoIP, 60, 10, mt8))
                {
                    double TimeEnd = GettimeEnd("Factory_RST");
                    FactoryRST = CountTime("Factory_RST", TimeStart, TimeEnd);
                    if (Label_Test == false)
                    {
                        checkWifiPasswordPass = true;
                    }
                    bool Waitchecklabel = false;
                    int count_Waitchecklabel = 0;
                    while (count_Waitchecklabel < 200)
                    {
                        if (nk == true) return false ;
                        if (checkWifiPasswordPass == true)
                        {
                            Waitchecklabel = true;
                            count_Waitchecklabel = 1000;
                        }
                        else
                        {
                            Status4("Waitchecklabel: " + count_Waitchecklabel.ToString());
                            count_Waitchecklabel++;
                            Delay(1000);
                        }
                    }
                    if (Waitchecklabel) //allfunctionpass
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (Send_To_SFC_PASS())
                            {
                                StopWEB();
                                timStart.Enabled = true;
                                timeTest.Enabled = false;
                                checkPingResetTodefaultPass = true; ;
                                resPass++;
                                pass++;
                                WriteCPU("STATUS=STOP");
                                Status("");
                                comCmd("open_on");
                                comCmd("open_on");
                                comCmd("open");
                                comCmd("open"); ;
                                msgPass("checkPingResetTodefault");
                                msgPass("All_Function-> Pass");
                                Status("All_Function->Pass");
                                Status("->~Next Product~");
                                Status4("->~Next Product~");
                                lbPass.Text = resPass.ToString();
                                LogFilePassNian("PASS", "");
                                LogFile("PASS", "");
                                PASSOK();
                                thStattus2 = false;
                                thStattus1 = false;
                                a = true;
                                ResetRelay();
                                txtComFB.Clear();
                                timS = true;
                                Status("-> Put Product in Fixture!");
                                Status4("->Put Product in Fixture!");
                                txtOutput.Clear();
                                msg("Next_Product !!!");
                                if (lockpc.Contains("yes"))
                                {
                                    if (!Checklockpc1())
                                    {
                                        cmmType.Enabled = true;
                                    }
                                }
                                Writeduperr("");
                                Write("", "OK");
                                return true;
                            }
                            else
                            {
                                MyMessagesBox.Show("\n\t\tSend_To_SFC_Error");
                                if (i >= 2)
                                {
                                    msg("Send_To_SFC_Error");
                                    ErrorNian("Err_Send_SFC_Pass");
                                    return false;
                                }
                                delay(2000);
                            }
                        }
                    }
                    else
                    {
                        thStattus2 = false;
                        thStattus1 = false;
                        Status("Wait Check Label");
                        ErrorNian("EWAIT_ERR_LABEL");
                        return false;
                    }
                }
                else
                {
                    thStattus2 = false;
                    thStattus1 = false;
                    Status("Err_PingafterReset");
                   // ("FBOOTR", "Error_Bootup_After_RTD");
                  // ErrorNian("Error_Bootup_After_RTD");
                    return false;
                }
            }
            else
            {
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
        private bool GetinforDUT()
        {
            bool loadLable = false;
            bool a = true;
            int count = 0;
            CMMACDUT = "";
            WANMACDUT = "";
            MTAMACDUT = "";
            SSIDCDUT = "";
            PASSWORDDUT = "";
            SNDDUT = "";
            while (a)
            {
                if (lbSsid.InvokeRequired)
                {
                    lbSsid.Invoke(new Action(() =>
                    {
                        SSIDCDUT = lbSsid.Text.Trim();

                    }));
                }
                else { SSIDCDUT = lbCMMAC.Text.Trim(); }

                if (lbwifiPassword.InvokeRequired)
                {
                    lbwifiPassword.Invoke(new Action(() =>
                    {
                        PASSWORDDUT = lbwifiPassword.Text.Trim();

                    }));
                }
                else { PASSWORDDUT = lbwifiPassword.Text.Trim(); }

                if (lbCMMAC.InvokeRequired)
                {
                    lbCMMAC.Invoke(new Action(() =>
                    {
                        CMMACDUT = lbCMMAC.Text.Trim();

                    }));
                }
                else { CMMACDUT = lbCMMAC.Text.Trim(); }

                if (lbWanMac.InvokeRequired)
                {
                    lbWanMac.Invoke(new Action(() =>
                    {
                        WANMACDUT = lbWanMac.Text.Trim();

                    }));
                }
                else { WANMACDUT = lbWanMac.Text.Trim(); }

                if (lbWanMac.InvokeRequired)
                {
                    lbWanMac.Invoke(new Action(() =>
                    {
                        MTAMACDUT = lbMTAMAC.Text.Trim();

                    }));
                }
                else { MTAMACDUT = lbMTAMAC.Text.Trim(); }

                if (lbsndut.InvokeRequired)
                {
                    lbsndut.Invoke(new Action(() =>
                    {
                        SNDDUT = lbsndut.Text.Trim();

                    }));
                }
                else { SNDDUT = lbsndut.Text.Trim(); }

                if (SSIDCDUT != "" & PASSWORDDUT != "")
                {
                    a = false;
                    loadLable = true;
                    return true;
                }
                else
                {
                    count++;
                    if (count >= 10)
                    {
                        a = false;
                        loadLable = false;
                        return false;
                    }
                    delay(500);
                }
            }
            return loadLable;
        }
        private bool GetInfLable()
        {
            Status4("Check_Lable");
            bool a = false;
            gw = false;
            gw1 = false;
            string Result = "";
            string pathfile1 = Directory.GetCurrentDirectory();
            cmn.openExe1(pathfile1, "enableCamera");
            string filename1 = "Barcode.txt";
            bool SSIDPass = false;
            bool PASSWORDPass = false;
            bool CM = false;
            bool WAN = true;
            bool MAT = false;
            if (!GetinforDUT()) { ErrorNian("Err_Lable_to_Get"); return false; };
            if (sModem != "CGM4981COX")
            {
                CM = true;
                WAN = true;
                MAT = true;
            }
            for (int i = 1; i <= 3; i++)
            {
                if (thStattus1 == false) return false;             
                string SSIDlable = "";
                string Passwordlable = "";
                string CMMAC = "";
                string MATMAC = "";
                string WANMAC = "";
                string SSIDlable1 = "";
                Result = socket_string("LABEL");
                if (!Result.Equals(""))
                {
                    var Data = Result.Split('\n');
                    if (Result != "")
                    {
                        try
                        {
                            if (SSIDPass == false)
                            {
                                try
                                {
                                    // SSIDCDUT = "SHAW-24E8";
                                    if (sModem == "CGM4981ROG")
                                    {
                                        SSIDlable = SSIDName + SNDDUT.Substring(SNDDUT.Length - 5, 5);
                                        SSIDlable1 = "WIFI-" + lbCMMAC.Text.Substring(lbCMMAC.Text.Length - 4, 4);
                                        if (SSIDlable.Equals(SSIDCDUT) & Data[0].Trim().Equals(SSIDlable1))
                                        {
                                            msg("SSID_lable1: " + Data[0].Trim() + "  ==>  " + "SSID_MIB: " + SSIDlable1);
                                            msg("SSID_lable1: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            SSIDPass = true;
                                            msgPass("Check_SSID");
                                        }
                                        else
                                        {
                                            if (i >= 3)
                                            {
                                                if (!Errorlabel(Result))
                                                {
                                                    ErrorNian("Err_Check_Label_SSID");
                                                }
                                                return false;
                                            }
                                            msg("SSID_lable1: " + Data[0].Trim() + "  ==>  " + "SSID_MIB: " + SSIDlable1);
                                            msg("Error: SSID_lable: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            delay(1000);
                                        }
                                    }
                                    else if (sModem == "CGM4981SHW")
                                    {
                                        SSIDlable = Data[0].Trim();
                                        SSIDCDUT = "WIFI-" + lbCMMAC.Text.Substring(lbCMMAC.Text.Length - 4, 4);
                                        if (SSIDlable.Equals(SSIDCDUT))
                                        {
                                            msg("SSID_lable1: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            SSIDPass = true;
                                            msgPass("Check_SSID");
                                        }
                                        else
                                        {
                                            if (i >= 3)
                                            {
                                                if (!Errorlabel(Result))
                                                {
                                                    ErrorNian("Err_Check_Label_SSID");
                                                }
                                                return false;
                                            }
                                            msg("Error: SSID_lable: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            delay(1000);
                                        }
                                    }
                                    else
                                    {
                                        SSIDlable = Data[0].Trim();
                                        if (SSIDlable.Equals(SSIDCDUT))
                                        {
                                            msg("SSID_lable: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            SSIDPass = true;
                                            msgPass("Check_SSID");
                                        }
                                        else
                                        {
                                            if (i >= 3)
                                            {
                                                if (!Errorlabel(Result))
                                                {
                                                    ErrorNian("Err_Check_Label_SSID");
                                                }
                                                return false;
                                            }
                                            msg("Error: SSID_lable: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                            delay(1000);
                                        }
                                    }
                                }
                                catch
                                {

                                    if (i >= 3)
                                    {
                                        if (!Errorlabel(Result))
                                        {
                                            ErrorNian("Err_Check_Label_SSID");
                                        }
                                        return false;
                                    }
                                    msg("Error: SSID_lable: " + SSIDlable + "  ==>  " + "SSID_MIB: " + SSIDCDUT);
                                    delay(1000);
                                }
                            }
                            //---------------------------------------   
                            if (PASSWORDPass == false)
                            {
                                try
                                {
                                    Passwordlable = Data[1].Trim();
                                    if (Passwordlable.Equals(PASSWORDDUT))
                                    {
                                        msg("Password_lable: " + Passwordlable + "  ==>  " + "Password_MIB: " + PASSWORDDUT);
                                        PASSWORDPass = true;
                                        msgPass("Check_Password");
                                    }
                                    else
                                    {
                                        if (i >= 3)
                                        {
                                            if (!Errorlabel(Result))
                                            {
                                                ErrorNian("Err_Check_Label_PASSWORD");
                                            }
                                            return false;
                                        }
                                        msg("Error: Password_lable: " + Passwordlable + "  ==>  " + "Password_MIB: " + PASSWORDDUT);
                                        delay(1000);
                                    }
                                }
                                catch
                                {
                                    if (i >= 3)
                                    {
                                        if (!Errorlabel(Result))
                                        {
                                            ErrorNian("Err_Check_Label_PASSWORD");
                                        }
                                        return false;
                                    }
                                    delay(1000);
                                }
                            }
                            if (CM == false)
                            {
                                try
                                {
                                    CMMAC = Data[2].Trim();
                                    if (CMMAC.Equals(CMMACDUT))
                                    {
                                        msg("CMMAC_lable: " + CMMAC + "  ==>  " + "CMMAC_WEB: " + CMMACDUT);
                                        CM = true;
                                        msgPass("Check_CMMAC");
                                    }
                                    else
                                    {
                                        if (i >= 3)
                                        {
                                            if (!Errorlabel(Result))
                                            {
                                                ErrorNian("Err_Check_Label_MAC");
                                            }
                                            return false;
                                        }                               
                                        msg("Error: CMMAC_lable: " + CMMAC + "  ==>  " + "CMMAC_WEB: " + CMMACDUT);
                                        delay(1000);
                                    }
                                }
                                catch
                                {
                                    if (i >= 3)
                                    {
                                        if (!Errorlabel(Result))
                                        {
                                            ErrorNian("Err_Check_Label_MAC");
                                        }
                                        return false;
                                    }
                                    delay(1000);
                                }
                            }
                            if (MAT == false)
                            {
                                try
                                {
                                    MATMAC = Data[3].Trim();
                                    if (MATMAC.Equals(MTAMACDUT))
                                    {
                                        msg("MTAMAC_lable: " + MATMAC + "  ==>  " + "MTAMAC_WEB: " + MTAMACDUT);
                                        MAT = true;
                                        msgPass("Check_CMMAC");
                                    }
                                    else
                                    {
                                        if (i >= 3)
                                        {
                                            if (!Errorlabel(Result))
                                            {
                                                ErrorNian("Err_Check_Label_MAC");
                                            }
                                            return false;
                                        }
                                        msg("Error: MTAMAC_lable: " + MATMAC + "  ==>  " + "MTAMAC_WEB: " + MTAMACDUT);
                                        delay(1000);
                                    }
                                }
                                catch
                                {
                                    if (i >= 3)
                                    {
                                        if (!Errorlabel(Result))
                                        {
                                            ErrorNian("Err_Check_Label_MAC");
                                        }
                                        return false;
                                    }
                                    delay(1000);
                                }
                            }
                            if (WAN == false)
                            {
                                try
                                {
                                    WANMAC = Data[4].Trim();
                                    if (WANMAC.Equals(WANMACDUT))
                                    {
                                        msg("WANMAC_lable: " + WANMAC + "  ==>  " + "WANMAC_WEB: " + WANMACDUT);
                                        WAN = true;
                                        msgPass("Check_CMMAC");
                                    }
                                    else
                                    {
                                        if (i >= 3)
                                        {
                                            if (!Errorlabel(Result))
                                            {
                                                ErrorNian("Err_Check_Label_MAC");
                                            }
                                            return false;
                                        }
                                        msg("Error: WANMAC_lable: " + WANMAC + "  ==>  " + "WANMAC_WEB: " + WANMACDUT);
                                        delay(1000);
                                    }
                                }
                                catch
                                {
                                    if (i >= 3)
                                    {
                                        if (!Errorlabel(Result))
                                        {
                                            ErrorNian("Err_Check_Label_MAC");
                                        }
                                        return false;
                                    }
                                    delay(1000);
                                }
                            }

                        }
                        catch
                        {
                            if (i >= 3)
                            {
                                if (!Errorlabel(Result))
                                {
                                    ErrorNian("Err_Check_Label_get_file");
                                }
                                return false;
                            }
                            delay(2000);
                        }
                    }
                    else
                    {
                        msg("Can't_found_lable.txt=> " + i);
                        if (i >= 3)
                        {
                            if (!Errorlabel(Result))
                            {
                                ErrorNian("Err_Check_Label_get_file");
                            }
                            return false;
                        }
                        delay(2000);
                    }
                    if (SSIDPass & PASSWORDPass & MAT & CM == true)
                    {
                        checkWifiPasswordPass = true;
                        msgPass("Check_Lable");
                        return true;
                    }
                }
                else
                {
                    msg("===> Error: Result null!!");
                    if (i >= 3)
                    {
                        if (!Errorlabel(Result))
                        {
                            ErrorNian("Err_Check_Label_get_file");
                        }
                        return false;
                    }
                    delay(2000);
                }
            }
            return a;
        }
        private bool CheckLed_USB_C()
        {      
            double TimeStart = GettimeStart("LED_Mouse_Function-USB");
            double TimeEnd;
            string file_ledGreen = Labview_part + "\\LedGREEN.txt";
            CheckLed_USB = false;
            Status("Led_1G & 2.5G");
            msg("Start CheckLed_1G & 2.5G");
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (nk == true) return false;
                    msg("Test Led LED_Mouse_Function-USB : " + i.ToString());
                    if (socket_bool(keyusbc))
                    {
                        CheckLed_USB = true;
                        msgPass("LED_Mouse_Function-USB");
                        return true;
                    }
                    else
                    {
                        if (i >= 3)
                        {
                            CheckLed_USB = false;
                           // ErrorNian("Err_USB_TypeC");
                            TimeEnd = GettimeEnd("LED_Mouse_Function-USB");
                            ledusb = CountTime("LED_Mouse_Function-USB", TimeStart, TimeEnd);                            
                            return false;
                        }
                        MyMessagesBox.Show("Kiem Tra USB Type C!!");
                    }
                }
            }
            TimeEnd = GettimeEnd("LED_Mouse_Function-USB");
            ledusb = CountTime("LED_Mouse_Function-USB", TimeStart, TimeEnd);
            return CheckLed_USB;
        }
        private bool CheckLed_USB_C1()
        {
            ledusb1 = 0;
            double TimeStart = GettimeStart("LED_Mouse_Function-USB");
            string file_ledGreen = Labview_part + "\\LedGREEN.txt";
            CheckLed_USB = false;
            Status("Led_1G & 2.5G");
            msg("Start CheckLed_1G & 2.5G");
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (nk == true) return false;
                    msg("Test Led Green : " + i.ToString());
                    if (socket_bool("USB"))
                    {
                        CheckLed_USB = true;
                        msgPass("LED_Mouse_Function-USB");
                        break;
                    }
                    else
                    {
                        if (i >= 3)
                        {
                            CheckLed_USB = false;
                            ErrorNian("Err_USB_TypeC");
                            break;
                        }
                        MyMessagesBox.Show("Kiem Tra USB Type C!!");
                    }
                }
            }
            double TimeEnd = GettimeEnd("LED_Mouse_Function-USB");
            ledusb1 = CountTime("LED_Mouse_Function-USB", TimeStart, TimeEnd);
            return CheckLed_USB;
        }
        private bool CheckLed_EthGreen()
        {
            double TimeStart = GettimeStart("Led_Eth_Green");
            string file_ledGreen = Labview_part + "\\LedGREEN.txt";
            CheckLed_1000EthPass = false;
            Status("Led_1G & 2.5G");
            msg("Start CheckLed_1G & 2.5G");
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (nk == true) return false;
                    msg("Test Led Green : " + i.ToString());
                    if (socket_bool("GREEN"))
                    {
                        CheckLed_1000EthPass = true;
                        msgPass("Test Led Green ");
                        break;
                    }
                    else
                    {
                        if (i >= 2)
                        {
                            CheckLed_1000EthPass = false;
                            //ErrorNian("Err_Eth1_Led_Green");
                            break;
                        }
                    }
                }
            }
            double TimeEnd = GettimeEnd("Led_Eth_Green");
            ledgrren = CountTime("Led_Eth_Green", TimeStart, TimeEnd);
            return CheckLed_1000EthPass;
        }
        private bool CheckLed_Eth_Red()
        {
           double TimeStart = GettimeStart("Led_RED_Eth");
           bool ResultLedRED = false;
            Status("Led_Eth 100M");
            msg("Led_Eth 100M");
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (nk == true) return false;
                    msg("Test Led Eth RED : " + i.ToString());
                    if (socket_bool("RED"))
                    {
                        ResultLedRED = true;
                        msgPass("Test Led Ethernet RED ");
                        break;

                    }
                    else
                    {
                        if (i >= 2)
                        {
                            ResultLedRED = false;
                            //ErrorNian("Err_Eth1_Led_Red");
                            break;
                        }
                    }
                }
            }
            double TimeEnd = GettimeEnd("Led_RED_Eth");
            ledred = CountTime("Led_RED_Eth", TimeStart, TimeEnd);
            return ResultLedRED;
        }
        private bool CheckLed_WPSNian(int times)
        {
            string ResultLedWPS = "";
            CheckLed_WPSPass = false;
            valueRed_WPS = 0.00;
            valueGreen_WPS = 0.00;
            valueBlue_WPS = 0.00;
            double TimeEnd = 0.0;
            double TimeStart = GettimeStart("Led_WPS");
            if (thStattus1 == true)
            {             
                Status("CheckLed_WPS");
                msg("Start Checking:Led_WPS");
                for (int i = 1; i <= 5; i++)
                {
                    if (thStattus1 == false) return false;
                    ResultLedWPS = socket_string("WPS");
                    if (!ResultLedWPS.Equals(""))
                    {
                        try
                        {
                            var Data = ResultLedWPS.Split(':');
                            try
                            {
                                msg(LoadResust("\\Process_LED_FEASA_RGBI.csv", "Value RGB Feasa Led WPS"));
                                valueGreen_WPS = Math.Round(Convert.ToDouble(Data[3].Substring(0, Data[3].Length - 1)), 3);
                                valueBlue_WPS = Math.Round(Convert.ToDouble(Data[4].Substring(0, Data[4].Length - 1)), 3);
                                valueRed_WPS = Math.Round(Convert.ToDouble(Data[2].Substring(0, Data[2].Length - 1)), 3);
                            }
                            catch { msg("Load_Data_LED_WPS_ERROR!!!"); }
                            if (Data[0].Contains("Fail"))
                            {
                                if(times == 1)
                                {
                                    CheckLed_WPSPass = false;
                                    return false;
                                }
                                if (i >= times & times == 2)
                                {
                                    CheckLed_WPSPass = false;
                                    if (!Errorlabel(ResultLedWPS))
                                    {
                                        ErrorNian("Err_Led_WPS");
                                    }
                                    break;
                                }
                                if (sLine == "T1")
                                {
                                    comCmd("out9_on");
                                    delay(6000);
                                    comCmd("out9_off");
                                    delay(5000);
                                }
                                else
                                {
                                    comCmd("bton");
                                    delay(6000);
                                    comCmd("btof");
                                    delay(5000);
                                }
                            }
                            else
                            {
                                msgPass("Led_WPS");
                                CheckLed_WPSPass = true;
                                break;
                            }
                        }
                        catch
                        {
                            msg("Error_File_Led_WPS.txt!!");
                            if (i >= times & times == 2)
                            {
                                CheckLed_WPSPass = false;
                                if (!Errorlabel(ResultLedWPS))
                                {
                                    ErrorNian("Err_Led_WPS");
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        msg("===> Error: LED WPS");
                        if (i >= times & times == 2)
                        {
                            CheckLed_WPSPass = false;
                            if (!Errorlabel(ResultLedWPS))
                            {
                                ErrorNian("Err_Led_WPS");
                            }
                            break;
                        }
                        delay(3000);
                    }
                }
            }
            TimeEnd = GettimeEnd("Led_WPS");
            ledWPS = CountTime("Led_WPS", TimeStart, TimeEnd);
            return CheckLed_WPSPass;
        }
        private void openledprogram(string fileRun, string fileResult)
        {
            string pathfile1 = Directory.GetCurrentDirectory();            
            cmn.openExe(pathfile1, fileRun);
            Delay(2000);
        }
        private bool GetSN()
        {
            SNHieuPC = false;
            MACHieuPC = false;
            SNlabel = "";
            CMMACLabel = "";
            MTAMACLabel = "";
            WANMACLabel = "";
            bool GetSNHieuPC = false;
            for (int i = 1; i <= 2; i++)
            {
                msg("Get_SN_time: " + i);
                try
                {
                    Barcode2D = socket_string("SN");
                    if (Barcode2D.Length > 10 & !Barcode2D.Contains("Error"))
                    {
                        var DataBarcode = Barcode2D.Split('\n');
                        if (!DataBarcode[3].Contains(model))
                        {
                            MyMessagesBox.Show("\n\n           OP Chọn sai Model!!!");
                            ErrorNian("Error_MODEL");
                            return false;
                        }
                        else
                        {
                            SNlabel = DataBarcode[0].Substring(3, DataBarcode[0].Length - 3).Trim();
                            SNledonline = SNlabel;
                            if (lbsndut.InvokeRequired) { lbsndut.Invoke(new Action(() => { lbsndut.Text = SNlabel; })); }
                            else { lbsndut.Text = SNlabel; }
                            if (model.Equals("0"))
                            {
                                var Data1 = DataBarcode[2].Split('.');
                                CMMACLabel = Data1[3].Trim();
                                MTAMACLabel = Data1[4].Substring(2, Data1[4].Length - 2).Trim();
                                WANMACLabel = Data1[5].Substring(2, Data1[5].Length - 2).Trim();
                            }
                            if (model.Equals("1"))
                            {
                                var Data1 = DataBarcode[2].Split('.');
                                CMMACLabel = Data1[3].Trim();
                                MTAMACLabel = Data1[4].Substring(2, Data1[4].Length - 2).Trim();
                                WANMACLabel = Data1[5].Substring(2, Data1[5].Length - 2).Trim();
                            }
                            if (model.Equals("2"))
                            {
                               // var Data1 = DataBarcode[1].Split('.');
                                //CMMACLabel = Data1[1].Trim();
                                //MTAMACLabel = Data1[0].Substring(10, Data1[0].Length - 10).Trim();
                            }
                            if (model.Equals("3"))
                            {
                                var Data1 = DataBarcode[2].Split('.');
                                CMMACLabel = Data1[3].Trim();
                                MTAMACLabel = Data1[4].Substring(2, Data1[4].Length - 2).Trim();
                                WANMACLabel = Data1[5].Substring(2, Data1[5].Length - 2).Trim();
                            }
                            if (model.Equals("4"))
                            {
                                var Data1 = DataBarcode[2].Split('.');
                                CMMACLabel = Data1[3].Trim();
                                MTAMACLabel = Data1[4].Substring(2, Data1[4].Length - 2).Trim();
                                WANMACLabel = Data1[5].Substring(2, Data1[5].Length - 2).Trim();
                            }
                            if (model.Equals("5"))
                            {
                                var Data1 = DataBarcode[2].Split('.');
                                CMMACLabel = Data1[3].Trim();
                                MTAMACLabel = Data1[4].Substring(2, Data1[4].Length - 2).Trim();
                                WANMACLabel = Data1[5].Substring(2, Data1[5].Length - 2).Trim();
                            }
                            SNHieuPC = true;
                            return true;
                        }

                        //if (sModem == "CGM4981COX")
                        //{

                        //    SNledonline = DataBarcode[0].Substring(10, DataBarcode[0].Length - 10).Trim();
                        //    if (lbsndut.InvokeRequired) { lbsndut.Invoke(new Action(() => { lbsndut.Text = SNledonline; })); }
                        //    else { lbsndut.Text = SNledonline; }
                        //    GetSNHieuPC = true;
                        //    SNHieuPC = true;
                        //    return true;
                        //}
                        //else
                        //{
                        //    SNledonline = DataBarcode[2].Trim();
                        //    if (lbsndut.InvokeRequired) { lbsndut.Invoke(new Action(() => { lbsndut.Text = SNledonline; })); }
                        //    else { lbsndut.Text = SNledonline; }
                        //    CMMACLabel = DataBarcode[3].Trim();
                        //    MTAMACLabel = DataBarcode[4].Substring(2, DataBarcode[4].Length - 2).Trim();
                        //    WANMACLabel = DataBarcode[5].Substring(2, DataBarcode[5].Length - 2).Trim();
                        //    CMmacbuf = CMMACLabel;
                        //    GetSNHieuPC = true;
                        //    SNHieuPC = true;
                        //    return true;
                        //}
                    }
                    else
                    {
                        if (i >= 2)
                        {
                            if (!Errorlabel(Barcode2D))
                            {
                                ErrorNian("Err_Check_Label_SN");
                            }
                            return false;
                        }
                        delay(5000);
                    }
                }
                catch
                {
                    GetSNHieuPC = false;
                    SNHieuPC = false;
                    msg("Get_SN_LedOnline_Fail" + Barcode2D);
                    if (i >= 2)
                    {
                        if (!Errorlabel(Barcode2D))
                        {
                            ErrorNian("Err_Check_Label_SN");
                        }
                        return false;
                    }
                }
            }       
            return GetSNHieuPC;
        }
        private bool Errorlabel(string data)
        {
            bool result = false;
            if (data.Contains("ECAMLE")) { ErrorNian("Err_Connect_Camera_LED"); return true; }
            else if (data.Contains("ECAMLB")) { ErrorNian("Err_Connect_Camera_Label"); return true; }
            else if (data.Contains("FFEASA")) { ErrorNian("Err_Feasa_Nan"); return true; }
            else if (data.Contains("ELIGHT")) { ErrorNian("Err_Light_Camera_Label"); return true; }
            else if (data.Contains("FEASAB")) { ErrorNian("Err_Led_Online_Blue"); return true; }
            else if (data.Contains("FEASAG")) { ErrorNian("Err_Led_Online_Green"); return true; }
            else if (data.Contains("FEASAN")) { ErrorNian("Err_Led_Online_OFF"); return true; }
            else if (data.Contains("FEASAO")) { ErrorNian("Err_Led_Online_Orange"); return true; }
            else if (data.Contains("FLWPSG")) { ErrorNian("Err_Led_WPS_Green"); return true; }
            else if (data.Contains("FLWPSN")) { ErrorNian("Err_Led_WPS_OFF"); return true; }
            else if (data.Contains("FLWPSO")) { ErrorNian("Err_Led_WPS_Orange"); return true; }
            else if (data.Contains("FLWPSW")) { ErrorNian("Err_Led_WPS_White"); return true; }
            else if (data.Contains("FEASA0")) { ErrorNian("Err_Connect_Feasa"); return true; }
            else if (data.Contains("FEASA2")) { ErrorNian("Err_Setcommand_Feasa"); return true; }
            return result;
        }
        private bool CheckLed_OnlineNian()
        {
            CheckLed_OnlinePass = false;
            string ResultOnline = "";
            valueRed_Online = 0.00;
            valueGreen_Online = 0.00;
            valueBlue_Online = 0.00;
            valueX_Online = 0.00;
            valueY_Online = 0.00;
            double TimeEnd = 0.0;
            double TimeStart = GettimeStart("led_Online");
            if (thStattus1 == true)
            {
                Status4("Led_Online");
                msg("Start Checking:Led_Online");
                for (int i = 1; i <= 2; i++)
                {
                    msg("Test Led Online : " + i.ToString());
                    ResultOnline = socket_string("ONLINE");
                    if (!ResultOnline.Equals("")) //&!ResultOnline.Contains("Error")
                    {
                        try
                        {
                            var Data = ResultOnline.Split(':');
                            try
                            {
                                msg(LoadResust("\\Process_LED_FEASA_RGBI.csv", "Value RGB Feasa Led Online"));
                                msg(LoadResust("\\Process_LED_FEASA_XYI.csv", "Value XY Feasa Led Online"));
                                valueRed_Online = Math.Round(Convert.ToDouble(Data[2].Substring(0, Data[2].Length - 1)), 3);
                                valueGreen_Online = Math.Round(Convert.ToDouble(Data[3].Substring(0, Data[3].Length - 1)), 3);
                                valueBlue_Online = Math.Round(Convert.ToDouble(Data[4].Substring(0, Data[4].Length - 1)), 3);
                                valueX_Online = Math.Round(Convert.ToDouble(Data[5].Substring(0, Data[5].Length - 1)), 3);
                                valueY_Online = Math.Round(Convert.ToDouble(Data[6].Substring(0, Data[6].Length - 1)), 3);
                            }
                            catch { msg("Load_Value_LED_ONLINE_ERROR!!!"); }
                            if (Data[0].Contains("Fail") | ResultOnline.Contains("Error"))
                            {
                                if (i >= 2)
                                {
                                    CheckLed_OnlinePass = false;
                                    if (!Errorlabel(ResultOnline))
                                    {
                                        ErrorNian("Err_Led_Online");
                                    }
                                    break;     
                                }
                            }
                            else
                            {
                                msgPass("Led_Online");
                                CheckLed_OnlinePass = true;
                                break;
                            }
                        }
                        catch
                        {
                            msg("Error_File_Led_Online.txt!!");
                            if (i >= 2)
                            {
                                CheckLed_OnlinePass = false;
                                if (!Errorlabel(ResultOnline))
                                {
                                    ErrorNian("Err_Led_Online");
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (i >= 2)
                        {
                            CheckLed_OnlinePass = false;
                            if (!Errorlabel(ResultOnline))
                            {
                                ErrorNian("Err_Led_Online");
                            }
                            break;
                        }
                        delay(3000);
                    }
                }
            }
            TimeEnd = GettimeEnd("Led_Online");
            ledonline = CountTime("Led_Online", TimeStart, TimeEnd);
            return CheckLed_OnlinePass;
        }
        private bool CheckSpeedCamera_Xb7()
        {
            ///camera123
            bool CheckSpeedCamera = false;
            long speed_number = cmn.xb7speedEthAll("Camera", "1000");
            if (speed_number == 1000)
            {
                CheckSpeedCamera = true;
            }
            else
            {
                MessageBox.Show("Chinh toc do camera len 1G");
            }
            return CheckSpeedCamera;
        }    
        private string getLanMac()
        {
            Status("getLanMac");
            List<string> lsLan = new List<string>();
            string LanMAC = "";         
            string TG = "";
            string filename = "arpa.txt";
            string filename1 = "arpa.bat";
            string pathfile = @"C:\";
            string pathfile1 = Directory.GetCurrentDirectory();
            bool b = true;
            int count = 0;
            cmn.deleteFile(pathfile, filename);
            delay(500);
            cmn.openExe(pathfile1, filename1);
            delay(1000);
            string LanMACs = "";
            while (b)
            {
                lsLan = cmn.loadFileLanMac(filename, InfoIP);
                msg("Physical_Address_is: " + lsLan);
                delay(1000);
                if (lsLan.Contains("no_file"))
                {
                    lsLan.Clear();
                    cmn.deleteFile(pathfile, filename);
                    delay(2000);
                    cmn.openExe(pathfile1, filename1);
                    delay(3500);
                    count++;
                    if (count > 5)
                    {
                        LanMAC = "no_LanMAc";
                        b = false;
                    }
                }
                else
                {
                    delay(3000);
                    LanMAC = cmn.get2ValueLoadfile(InfoIP, "dynamic");
                    msg("Physical_Address:" + LanMAC);
                    if (LanMAC.Length > 0)
                    {
                        
                        if (sModem == "CGM4981COX")
                        {
                            TG = getKey(LanMAC, InfoIP, 31);
                           
                        }
                        else
                        {
                            TG = LanMAC.Substring(InfoIP.Length + 4, 33);
                        }                                               
                        TG = TG.Trim();
                        TG = TG.Replace("-", "");                    
                        LanMACs = TG;                      
                    }
                    if (TG.Length == 12)
                    {
                        // Neu chuoi text Lanmacs co ky tu number = 0 o vi tri dau tien thi cat nay ky tu so 0 do.
                        // nguyen nhan de phong khi chuyen sang ma hex thi se k tinh ky tu so 0 o vi tri dau tien
                        //vd:so 0123--> thap phan : = 123 or hex =123.
                        //===> string 0123=> hex 123 => string 123(mat so 0);
                        string LanMACsHex = LanMACs.Substring(0, 1);
                        //MessageBox.Show(LanMACsHex);
                        //int cmmac = Int32.Parse(LanMAC, System.Globalization.NumberStyles.HexNumber);
                        Int64 cmmacs = Int64.Parse(LanMACs, System.Globalization.NumberStyles.HexNumber);
                        /* delay(500);
                         cmmac = cmmac - 3;
                         LanMAC = cmmac.ToString("X");*/

                        cmmacs = cmmacs - 3;
                        LanMACs = cmmacs.ToString("X");
                        string LanMACs1 = "";
                        string LanMACs2 = "";
                        string LanMACs3 = "";
                        delay(500);
                        if (LanMACsHex == "0")
                        {
                            String LanMACsLoveHex = LanMACsHex + LanMACs;
                            LanMACs = LanMACsLoveHex;
                            //MessageBox.Show(LanMACs);


                        }

                        if (LanMACs.Length == 12)
                        {
                            LanMACs1 = LanMACs.Substring(0, 4);
                            LanMACs2 = LanMACs.Substring(4, 4);
                            LanMACs3 = LanMACs.Substring(8, 4);
                            LanMACs = LanMACs1 + "-" + LanMACs2 + "-" + LanMACs3;
                            b = false;
                        }
                        else
                        {
                            MessageBox.Show("Loi k du ky tu LanMac/12");

                            b = false;
                        }
                        delay(200);                     
                    }
                    else
                    {
                        cmn.deleteFile(pathfile, filename);
                        delay(2000);
                        cmn.openExe(pathfile1, filename1);
                        delay(3000);
                        //   cmn.loadFile(filename);
                        //   delay(3000);
                        count++;
                        if (count > 5)
                        {
                            LanMAC = "no_LanMAc";
                            b = false;
                        }
                    }
                }
                Delay(200);
            }
            
            return LanMACs;
        }
        private string GetLanMacNian()
        {
            Status("getLanMac");
            SNHieuPC = false;
            double TimeStart = GettimeStart("Infor1");
            List<string> lsLan = new List<string>();
            string LanMACs = "";
            string LanMAC = "";
            string TG = "";
            string filename = "arpa.txt";
            string filename1 = "arpa.bat";
            string pathfile = @"C:\";
            string pathfile1 = Directory.GetCurrentDirectory();
             bool b = true;
            //cmn.deleteFile(pathfile, filename);
            //delay(200);
            //cmn.openExe(pathfile1, filename1);
            //delay(2000);
            while (b)
            {
                for (int i = 1; i <= 5; i++)
                {
                    msg("GetLanMac -> " + i);
                    //lsLan = cmn.loadFileLanMacNian(filename, InfoIP, iptestEth2, iptestEth3, iptestEth4);
                    //msg("IP Get list.count ==>  " + lsLan.Count);
                    //delay(100);
                    //if (lsLan.Contains("no_file") || lsLan.Count == 0)
                    //{
                    //    lsLan.Clear();
                    //    cmn.deleteFile(pathfile, filename);
                    //    delay(200);
                    //    cmn.openExe(pathfile1, filename1);
                    //    delay(2000);
                    //    if (i >= 3)
                    //    {
                    //        LanMAC = "no_LanMAc";
                    //        msg(LanMAC);
                    //        b = false;
                    //        ErrorNian("Err_Get_WanMac");
                    //        return LanMAC;
                    //    }
                    //}
                    //else
                    //{
                    //    LanMAC = cmn.get2ValueLoadfile(InfoIP, "dynamic").Trim();
                    //    msg("LANMAC Cut:" + LanMAC);
                    // if (sModem == "CGM4331COX")
                    //    {
                    //        TG = getKey(LanMAC, InfoIP, 31);
                    //    }
                    //    else
                    //    {
                    //        TG = LanMAC.Substring(InfoIP.Length + 4, 30);
                    //    }
                    //    TG = TG.Trim();
                    //    TG = TG.Replace("-", "");
                    //    LanMACs = TG;
                    //    break;
                    //}


                    LanMAC = CmdNianreturnMAC().Trim();
                    msg("MACPhysical Address: " + LanMAC);
                    TG = LanMAC;
                    TG = TG.Replace("-", "");
                    LanMACs = TG;
                    if (TG.Length == 12)
                    {
                        break;
                    }
                }
                //if (LanMAC.Length > 0)
                //{
                //    if (sModem == "CGM4981COX")
                //    {
                //        TG = getKey(LanMAC, InfoIP, 31);
                //    }
                //    else
                //    {
                //        TG = LanMAC.Substring(InfoIP.Length + 4, 30);
                //    }
                //    TG = TG.Trim();
                //    TG = TG.Replace("-", "");
                //    LanMACs = TG;
                //}
                if (TG.Length == 12)
                {
                    Int64 cmmacs = Int64.Parse(LanMACs, System.Globalization.NumberStyles.HexNumber);
                    cmmacs = cmmacs - 3;
                    LanMACs = cmmacs.ToString("X");
                    int o = LanMACs.Length;
                    for (int c = 1; c <= 12 - o; c++) 
                    {
                        LanMACs = "0" + LanMACs;
                    }
                    if (LanMACs.Length == 12)
                    {
                        msg("Buf_is:  " + LanMACs);
                        SNHieuPC = true;
                        b = false;
                    }
                    else
                    {
                        MessageBox.Show("Loi k du ky tu LanMac/12");
                        b = false;
                    }
                }
                else
                {
                    ErrorNian("Err_WanMac_Leng");                  
                    LanMAC = "no_LanMAc";
                    msg(LanMAC);
                    b = false;
                }
            }
            double TimeEnd = GettimeEnd("Infor1");
            TimeMoca = CountTime("Infor1", TimeStart, TimeEnd);
            return LanMACs.Trim();
        }
        private string CmdNianreturnMAC()
        {
            string dataEth = "";
            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    string Output = "";
                    cmd.CmdConnect();
                    cmd.CmdWrite("arp -a");
                    Delay(100);
                    Output = cmd.CmdRead();
                    cmd.CmdWrite("exit");
                    dataEth = getKey(Output, InfoIP + "   ", 28).Trim();
                    return dataEth;
                }
                catch (Exception ex)
                {
                    dataEth = "";
                    msg("Exception-> " + ex.ToString());
                    if (i >= 2)
                    {
                        return dataEth;
                    }
                    delay(500);
                }
            }
            return dataEth;
        }
        private string cmIP;
        private string CMip
        {
            get { return cmIP; }
            set { cmIP = value; }
        }
        private bool WANSetup(string EnDis)
        {
            bool a = false;
            cmd.CmdConnect();
            delay(2000);
            if (EnDis == "dis")
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " DISABLED");
                delay(1000);
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " DISABLED");
                delay(1000);
                a = true;
            }
            else if (EnDis == "en")
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");
                delay(2000);
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " ENABLED");
                delay(15000);
                a = true;
            }
            return a;
        }
        private void checkgetWANMAC()
        {
            //getWANMAC();
            // if (!CheckVoipP1toP2()) { Status(""); return; }
            // cmn.switchEthcard("Eth1Eth2", "100");  
        }
        private void thrMult3()
        {
            if (!PingSreverNian()) { StatusERR("PingSERVER"); return; }
            if (!GetIpCMTSNian()) { StatusERR("getWANMAC"); return; }
           /// if (!getWANMAC()) { StatusERR("getWANMAC"); return; }          
        }
        private void thrMultSENSFC()
        {
            Check_ERRCODE(errs);
        }
        private void thrMultFail()
        {
            delay(3000);
            fail(Nian);
        }
        private void thrLable()//lable
        {
            try
            {
                double TimeEnd = 0.0;
                double TimeStart = GettimeStart("Check_Lable");
                checkWifiPasswordPass = false;
                string pathfile1 = Directory.GetCurrentDirectory();
                Status4("Check_Lable");
                if (!GetInfLable())
                {
                    TimeEnd = GettimeEnd("Check_Lable");
                    Lable = CountTime("Check_Lable", TimeStart, TimeEnd);
                    StatusERR("Fail Lable");
                    return;
                }             
                TimeEnd = GettimeEnd("Check_Lable");
                Lable = CountTime("Check_Lable", TimeStart, TimeEnd);
                Status("CheckLabel->Pass");
            }
            catch { StatusERR("Fail Lable"); }
        }

        private void waiyputButtonReset()
        {
            int TIM = countTimeTest;
            bool a = true;
            while (ButtonReset)
            {
                countTimeTest = TIM;
                    if (!ButtonReset)
                    { ButtonReset = false; break; }
                Delay(3000);            
            }
        }       
        private void ReSet_and_Setting_Sample()///123
        {

            if (!comCmdZ("\n")) { MessageBox.Show("Rúi điện và cắm lại sample chờ khởi động 5 phút!!"); return; }
            delay(2000);
            comCmdZBBLE("systemctl stop ble");
            delay(2000);
            comCmdZBBLE("BLEtest -u /dev/ttyS1");
            delay(2000);
            comCmdZBBLE("BLEtest -u /dev/ttyS1 -a 11:22:33:44:55:66");
            delay(2000);
            comCmdZBBLE("uart-dfu /dev/ttyS1 115200 /lib/firmware/xb7-ble-bg13-ncp-0513v1.gbl");
            delay(60000);
            comCmdZBBLE("BLEtest -u /dev/ttyS1 -p 105 -e & ");
            delay(2000);
            comCmdZBBLE("systemctl stop zilker");
            delay(2000);       
            comCmdZBBLE("systemctl stop touchstone");
            delay(2000);
            comCmdZBBLE("zigbee_startup");
            delay(2000);
            comCmdZBBLE("Xb7HostApp651v9");
            delay(2000);
            comCmdZBBLE("net leave");
            delay(2000);
            comCmdZBBLE("net form 25 3 0x0ba1");
            delay(2000);
            comCmdZBBLE("net pjoin 255");
            delay(2000);

            MyMessagesBox.Show("\n\nCài đặt sample ZB-BLE thành công");
            groupBox2.Visible = false;
        }
        private void ReSet_and_Setting_Samplezigbee()///123
        {

            if (!comCmdZ("\n")) { MessageBox.Show("Rúi điện và cắm lại sample !!"); return; }         
            delay(2000);
            comCmdZBBLE("systemctl stop zilker");
            delay(2000);
            comCmdZBBLE("systemctl stop touchstone");
            delay(2000);
            comCmdZBBLE("zigbee_startup");
            delay(2000);
            comCmdZBBLE("Xb7HostApp651v9");
            delay(2000);
            comCmdZBBLE("net leave");
            delay(2000);
            comCmdZBBLE("net form 25 3 0x0ba1");
            delay(2000);
            comCmdZBBLE("net pjoin 255");
            delay(2000);

            MyMessagesBox.Show("\n\nCài đặt sample ZB-BLE thành công");
            groupBox2.Visible = false;
        }
        private void CloseThreading_thMutiple1()
        {
            thMutiple1.Abort();
        }
        private bool PingSreverNian()
        {
            bool a = false;
            bool b = true;
            int pingtimeout1 = 0;
            int ping = 0;
            Status4("checkPing_Server");          
            string pathfile1 = Directory.GetCurrentDirectory();
            if (thStattus1 == true)
            {
                while (b)
                {
                    if (thStattus1 == false) return false;
                    cmn.pingToAddress(IPSERVER);
                    msg(cmn.pingdata);
                    if (!string.IsNullOrEmpty(cmn.pingdata))
                    {
                        if (cmn.pingdata.Contains("Can not ping to"))
                        {
                            pingtimeout1++;
                            ping = 0;
                            if (pingtimeout1 == 6 | pingtimeout1 == 9)
                            {
                                cmn.openExe1(pathfile1, "disableEthSever");
                                delay(100);
                                cmn.openExe1(pathfile1, "ResetEthSever");
                                delay(10000);
                            }
                            if (pingtimeout1 >= 20)
                            {
                                pingtimeout1 = 0;
                                msg("Ping Server Fail!!");
                                Status4("Ping Server Fail!!");
                                ErrorNian("Err_Eth_SERVER");                             
                                b = false;
                                a = false;
                                return false;                                                              
                            }
                        }
                        else
                        {
                            ping++;
                            pingtimeout1--;
                            delay(300);
                            if (ping >= 5)
                            {
                                pingtimeout1 = 0;
                                ping = 0;
                                msgPass("Ping SERVER");                              
                                b = false;
                                a = true;
                                return true;
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
        private bool socket_bool(string item_check)
        {//SN   LABEL   GREEN   ETHERNET  USB
            int dem_socket = 0;
            string Result = "";
            int dem_sai_folmat = 0;
            while (true)
            {
                try
                {
                    int BUFFER_SIZE = 1032;
                    int PORT_NUMBER = 1998;
                    string IP_server = "127.0.0.1";
                    TcpClient client = new TcpClient();
                    // 1. connect
                    client.Connect(IP_server, PORT_NUMBER);
                    Stream stream = client.GetStream();
                    msg("Connected_to_Server: " + IP_server + ", PORT: " + PORT_NUMBER + ", BUFFER_SIZE: " + BUFFER_SIZE);                 
                    // 2. send
                    byte[] data = encoding.GetBytes(item_check);
                    stream.Write(data, 0, data.Length);
                    msg("Client_Sen: " + item_check);
                    // 3. receive
                    try
                    {
                        stream.ReadTimeout = 40000; // timeout 
                        byte[] data2 = new byte[BUFFER_SIZE];
                        stream.Read(data2, 0, BUFFER_SIZE);
                        Result = encoding.GetString(data2).Trim().Replace("\0", "").ToString(); //tra ve
                        msg("XLA_Return_Result " + item_check + ": " + Result);
                        if (Result.Contains("PASS"))
                        {
                            stream.Close();
                            client.Close();
                            return true;
                        }
                        else if (Result.Contains("WRONG"))
                        {
                            dem_sai_folmat++;
                            msg("Server_return: ==> Sai Folmat <==");
                            if (dem_sai_folmat == 3)
                            {
                                stream.Close();
                                client.Close();
                                return false;
                            }
                        }
                        else if (Result.Contains("Error"))
                        {
                            dem_sai_folmat = dem_sai_folmat + 1;
                            msg("Server_return: ==> Error <==" + Result);
                            if (dem_sai_folmat == 3)
                            {
                                Errorlabel(Result);
                                stream.Close();
                                client.Close();
                                return false;
                            }
                        }
                        else
                        {
                            stream.Close();
                            client.Close();
                            return false;
                        }
                    }
                    catch
                    {
                        msg("Time_out ==> Server 40s khong tra ve ket qua cho Client");
                        stream.Close();
                        client.Close();
                        return false;
                    }
                }
                catch
                {
                    msg("==============> Error: Mat ket noi tu Sever");
                    dem_socket = dem_socket + 1;
                    if (dem_socket >= 1)
                    {
                        Process[] proc = Process.GetProcessesByName("XLAXB8");
                        if (proc.Length == 0) // 0: Không có file nào ch?y
                        {
                            openledprogram("StartXLA", "");
                            delay(5000);
                        }
                        else
                        {
                            msg("===> Error: Chuong trinh dang chay ==> khong ket noi duoc Server <===");
                            //cmn.kill("XLAXB8");
                            //openledprogram("StartXLA", "");
                            if (dem_socket == 3)
                            {
                                dem_socket = 0;
                                return false;
                            }
                            delay(5000);
                        }
                    }
                }
            }
            return false;
        }
        private string socket_string(string item_check)
        {//SN   LABEL   GREEN   ETHERNET 
            string result = "";
            int dem_socket = 0;

            while (true)
            {
                try
                {
                    int BUFFER_SIZE = 1032;
                    int PORT_NUMBER = 1998;
                    string IP_server = "127.0.0.1";
                    TcpClient client = new TcpClient();
                    // 1. connect
                    client.Connect(IP_server, PORT_NUMBER);
                    Stream stream = client.GetStream();
                    msg("Connected_to_Server: " + IP_server + ", PORT: " + PORT_NUMBER + ", BUFFER_SIZE: " + BUFFER_SIZE);
                    while (true)
                    {
                        try
                        {
                            // 2. send
                            byte[] data = encoding.GetBytes(item_check);
                            stream.Write(data, 0, data.Length);
                            msg("Client_Sen: " + item_check);
                            // 3. receive
                            try
                            {
                                stream.ReadTimeout = 40000; // timeout 
                                byte[] data2 = new byte[BUFFER_SIZE];
                                stream.Read(data2, 0, BUFFER_SIZE);
                                result = encoding.GetString(data2).Trim().Replace("\0", "").ToString(); //tra ve
                                msg("XLA_return: " + result);
                                stream.Close();
                                client.Close();
                                return result;                          
                            }
                            catch
                            {
                                msg("Time_out ==> Server 40s khong tra ve ket qua cho Client");
                                return result;
                            }
                        }
                        catch
                        {
                            Process[] proc = Process.GetProcessesByName("XLAXB8");
                            if (proc.Length == 0) // 0: Không có file nào ch?y
                            {
                                openledprogram("StartXLA", "");
                                delay(5000);
                            }
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg("==============> Error: Mat ket noi tu Sever");
                    dem_socket = dem_socket + 1;
                    if (dem_socket >= 1)
                    {
                        Process[] proc = Process.GetProcessesByName("XLAXB7");
                        if (proc.Length == 0) // 0: Không có file nào ch?y
                        {
                            openledprogram("StartXLA", "");
                            delay(5000);
                        }
                        else
                        {
                            msg("===> Error: Chuong trinh dang chay ==> khong ket noi duoc Server <===");
                            //cmn.kill("XLAXB8");
                            //openledprogram("StartXLA", "");
                            delay(5000);
                            if (dem_socket == 3)
                            {
                                dem_socket = 0;
                                return result;
                            }
                            delay(5000);
                        }
                    }
                }
            }
            return result;
        }
        private void pingsever()
        {           
            string pathfile1 = Directory.GetCurrentDirectory();
            delay(3000);
            bool checkping = true; int pingtimeout1 = 0; int ping = 0; int pingtimeout2 = 0;
            int countPing = 0;
            int pingtimeout = 0;
            while (checkping)
            {
                cmn.pingToAddress("172.21.25.241");
                msg(cmn.pingdata);
                if (!string.IsNullOrEmpty(cmn.pingdata))
                {
                    if (cmn.pingdata.Contains("Can not ping to"))
                    {
                        pingtimeout1++;
                        pingtimeout2++;
                        delay(200);
                        if (pingtimeout2 >= 5)
                        {
                            cmn.openExe1(pathfile1, "ResetEthSever");
                            delay(5000);
                            pingtimeout2 = 0;
                        }

                        if (pingtimeout1 >= 30)
                        {

                            //////cmn.openExe1(pathfile1, "enableEth2");
                            countPing = 0;
                            pingtimeout = 0;
                            msg("Sever" + " can not ping");
                            checkping = false;
                        }
                    }
                    else
                    {
                        ping++;

                        if (ping >= 3)
                        {
                            countPing = 0;
                            pingtimeout = 0;
                            msgPass("Ping Sever");
                            checkping = false;
                            break;
                        }
                    }
                }
            }
        }
        private bool GetIpCMTSNian()
        {
            bool a = false;
            bool c = false;
            int count1 = 0;
            int count2 = 0;
            getWANMAC1 = false;
            string tel = "";
            string lanMac = "";
            getWANMACPass = false;
            string Mac1 = "";
            string Mac2 = "";
            string Mac3 = "";
            string pathfile1 = Directory.GetCurrentDirectory();
            if (thStattus1 == true)
            {
                lanMac = khuyen;
                Status("Get_Ip_CMTS");
                //if (Type_Program == "OFF")
                //{
                //    if (lanMac.Contains("NO_LANMAC"))
                //    {
                //        Status("");
                //        ErrorNian("Err_LANMAC");
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (model.Equals("2")) { }
                //    else { lanMac = CMMACLabel; }
                //}           
                lanMac = lanMac.ToUpper().Trim();
                try
                {
                    Mac1 = lanMac.Substring(0, 4);
                    Mac2 = lanMac.Substring(4, 4);
                    Mac3 = lanMac.Substring(8, 4);
                    lanMac = Mac1 + "." + Mac2 + "." + Mac3;
                    lanMac = lanMac.ToUpper().Trim();
                }
                catch { lanMac = "NO_LANMAC"; }
                if (lanMac.Length < 5)
                {
                    Status("Error_CMMAC_Length");
                    ErrorNian("Err_LANMAC");
                    return false;
                }
                tel = "";
                try
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (telnet.Connect("172.21.25.242"))
                        {
                            c = true;
                            delay(1500);
                            telnetSend("admin");
                            delay(1000);
                            telnetSend("admin");
                            delay(1000);
                            telnetSend("en");
                            delay(500);
                            telnetSend("show cable modem " + lanMac);
                            delay(500);
                            tel = telnet.GetStream();
                            msg(tel);
                            delay(200);
                        }
                        else
                        {
                            cmn.openExe1(pathfile1, "ResetEthSever");
                            delay(10000);
                            count1++;
                            if (count1 >= 3)
                            {
                                a = false;
                                c = false;
                                telnetSend("q");
                                delay(500);
                                telnet.close();
                                if (PingSreverNian())
                                {
                                    ErrorNian("Err_Server_Telnet"); //Err_Server_Get_IP
                                }
                                return false;
                            }
                        }
                    }
                    while (c)
                    {
                        if (tel.Contains("online(pt)"))
                        {
                            try
                            {
                                CMip = tel.Substring(tel.IndexOf("10.52"), 14);
                                CMip = CMip.Trim();
                                if (CMip.Contains("10.52."))
                                {
                                    getWANMACPass = true;
                                    msg("Get_IP_MIB:  " + CMip);
                                    telnetSend("q");
                                    delay(500);
                                    telnet.close();
                                    a = true;
                                    c = false;
                                    getWANMAC1 = true;
                                    return true;
                                }
                                else
                                {
                                    msg("ERR_CM_IP: " + CMip);
                                    count1++;
                                    if (count1 >= 3)
                                    {
                                        if (PingSreverNian())
                                        {
                                            telnetSend("q");
                                            a = false;
                                            c = false;
                                            telnet.close();
                                            Status(err.Err_Server_Telnet);
                                            ErrorNian("Err_Server_Telnet");
                                            return false;
                                        }
                                    }
                                    txttelnet.Clear();
                                    tel = "";
                                    telnetSend("show cable modem " + lanMac);
                                    delay(2200);
                                    telnetSend("\n");
                                    delay(1000);
                                    tel = telnet.GetStream();
                                    msg(tel);
                                }
                            }
                            catch
                            {
                                msg("ERR_CM_IP: " + CMip);
                                count1++;
                                if (count1 >= 3)
                                {
                                    if (PingSreverNian())
                                    {
                                        telnetSend("q");
                                        a = false;
                                        c = false;
                                        telnet.close();
                                        Status(err.Err_Server_Telnet);
                                        ErrorNian("Err_Server_Telnet");
                                        return false;
                                    }
                                }
                                txttelnet.Clear();
                                tel = "";
                                telnetSend("show cable modem " + lanMac);
                                delay(2200);
                                telnetSend("\n");
                                delay(1000);
                                tel = telnet.GetStream();
                                msg(tel);
                            }
                        }
                        else
                        {
                            count1++;
                            if (count1 >= 3)
                            {
                                a = false;
                                c = false;
                                telnetSend("q");
                                delay(500);
                                telnet.close();
                                Status(err.Err_Server_Telnet);
                                ErrorNian("Err_Server_Telnet"); //Err_Server_Get_IP
                                return false;
                            }
                            tel = "";
                            delay(2200);
                            telnetSend("show cable modem " + lanMac);
                            delay(1500);
                            tel = telnet.GetStream();
                            msg(tel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg("Exception_CMTS_Connect:" + ex.Message);
                    count2++;
                    cmn.openExe1(pathfile1, "ResetEthSever");
                    delay(10000);
                    if (PingSreverNian())
                    {
                        if (count2 >= 2)
                        {
                            telnetSend("q");
                            delay(500);
                            Status("");
                            ErrorNian("Err_CMTS_Connect");
                            telnet.close();
                            a = false;
                            c = false;
                            return false;
                        }
                        delay(5000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        public void ClearMAC()
        {
            ClerMACNian(khuyen);
        }
        private void ClerMACNian( string key)
        {
            string tel = "";
            int count2 = 0;
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 3; i++)
                {
                    tel = "";
                    try
                    {
                        if (telnet.Connect("172.21.25.242"))
                        {
                            delay(1500);
                            telnetSend("admin");
                            delay(1000);
                            telnetSend("admin");
                            delay(1000);
                            telnetSend("en");
                            delay(500);
                            while (!checkPingMocaPass)
                            {
                                telnetSend("clear cable modem " + key + " delete");
                                delay(200);
                                //tel = telnet.GetStream();
                                //msg(tel);
                            }
                            delay(500);
                            telnetSend("q");
                            delay(500);
                        }
                    }
                    catch (Exception ex)
                    {
                        msg("Exception_CMTS_Connect:" + ex.Message);
                        count2++;
                        if (count2 >= 3)
                        {
                            telnetSend("q");
                            delay(500);
                            Status("");
                            ErrorNian("Err_CMTS_Connect");
                            telnet.close();
                        }
                        delay(5000);
                    }
                }
            }
        }
        private bool GetWANMAC()
        {
            bool a = false;
            bool c = true;
            int count1 = 0;
            int count2 = 0;
            getWANMAC1 = false;
            string tel = "";    
            getWANMACPass = false;
            string pathfile1 = Directory.GetCurrentDirectory();
            if (thStattus1 == true)
            {
                string lanMac = khuyen;
                Status("Get_MAC_Server!!!");
                lanMac = lanMac.ToUpper().Trim();
                msg("Get_MAC_Server: " + lanMac);
                if (lanMac.Length < 5)
                {
                    Status("Error_CMMAC_Length");
                    ErrorNian("Err_LANMAC");
                    return false;
                }

                //if (Type_Program == "OFF")
                //{
                //    lanMac = lanMac.ToUpper().Trim();
                //    if (lanMac.Contains("NO_LANMAC"))
                //    {
                //        Status("");
                //        ErrorNian("Err_LANMAC");
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (model.Equals("2")) { }
                //    else{lanMac = CMMACLabel;}
                //}
                // lanMac = "F8D2ACA914E7";
                for (int i = 1; i <= 3; i++)
                {
                    if (thStattus1 == false) return false;
                    tel = "";
                    try
                    {
                        if (telnet.Connect(inf.Ipcmts))//10.52.78.69
                        {
                            delay(2000);
                            telnetSend("obaroot1");
                            delay(1000);
                            telnetSend("admin123");
                            delay(1000);
                            telnetSend("en");
                            delay(500);
                            telnetSend("con");
                            delay(500);
                            telnetSend("display cable modem cpe " + lanMac);
                            delay(500);
                            telnetSend("\n");
                            delay(1000);
                            string tel1 = telnet.GetStream();
                            telnetSend("\n");
                            string tel2 = telnet.GetStream();
                            tel = tel1 + tel2;
                            //  }
                            msg(tel);
                            while (c)
                            {
                                if (tel.Contains("CM has an IPv6 address"))
                                {
                                    try
                                    {
                                        CMip = tel.Substring(tel.IndexOf("10.52."), 14);
                                        CMip = CMip.Trim();
                                        if (CMip.Contains("10.52."))
                                        {
                                            getWANMACPass = true;
                                            msg("Get_IP_MIB:  " + CMip);
                                            telnet.close();
                                            a = true;
                                            c = false;
                                            getWANMAC1 = true;
                                            return true;
                                        }
                                        else
                                        {
                                            msg("ERR_CM_IP: " + CMip);
                                            count1++;
                                            if (count1 >= 3)
                                            {
                                                if (PingSreverNian())
                                                {
                                                    a = false;
                                                    c = false;
                                                    telnet.close();
                                                    Status(err.Err_Server_Telnet);
                                                    ErrorNian("Err_Server_Telnet");
                                                    return false;
                                                }
                                            }
                                            txttelnet.Clear();
                                            tel = "";
                                            telnetSend("display cable modem cpe " + lanMac + "\n");
                                            delay(2200);
                                            telnetSend("\n");
                                            delay(1000);
                                            tel = telnet.GetStream();
                                            msg(tel);
                                        }
                                    }
                                    catch
                                    {
                                        count1++;
                                        if (count1 >= 3)
                                        {
                                            if (PingSreverNian())
                                            {
                                                a = false;
                                                c = false;
                                                telnet.close();
                                                Status(err.Err_Server_Telnet);
                                                ErrorNian("Err_Server_Telnet");
                                                return false;
                                            }
                                        }
                                        txttelnet.Clear();
                                        tel = "";
                                        telnetSend("display cable modem cpe " + lanMac + "\n");
                                        delay(2200);
                                        telnetSend("\n");
                                        delay(1000);
                                        tel = telnet.GetStream();
                                        msg(tel);
                                    }
                                }
                                else if(tel.Contains("shutdown call"))
                                {
                                    telnet.close();
                                    cmn.openExe1(pathfile1, "ResetEthSever");
                                    delay(10000);
                                    if (i >= 3)
                                    {
                                        Status("Connect_SerVer_Fail!!");
                                        if (PingSreverNian())
                                        {
                                            ErrorNian("Err_CMTS_Connect");
                                            telnet.close();
                                            a = false;
                                            c = false;
                                            return false;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    count1++;
                                    if (count1 >= 3)
                                    {
                                        if (PingSreverNian())
                                        {
                                            a = false;
                                            c = false;
                                            telnet.close();
                                            Status(err.Err_Server_Telnet);
                                            ErrorNian("Err_Server_Telnet");
                                            return false;
                                        }
                                    }
                                    txttelnet.Clear();
                                    tel = "";
                                    telnetSend("display cable modem cpe " + lanMac + "\n");
                                    delay(2200);
                                    telnetSend("\n");
                                    delay(1000);
                                    tel = telnet.GetStream();
                                    msg(tel);
                                }
                            }
                        }
                        else
                        {
                            telnet.close();
                            cmn.openExe1(pathfile1, "ResetEthSever");
                            delay(10000);
                            if (i >= 3)
                            {
                                Status("Connect_SerVer_Fail!!");
                                if (PingSreverNian())
                                {
                                    ErrorNian("Err_CMTS_Connect");
                                    telnet.close();
                                    a = false;
                                    c = false;
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        telnet.close();
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                        msg("Exception_CMTS_Connect:" + ex.Message);
                        count2++;
                        if (PingSreverNian())
                        {
                            if (count2 > 3)
                            {
                                Status("");
                                ErrorNian("Err_CMTS_Connect");
                                telnet.close();
                                a = false;
                                c = false;
                                return false;
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
        /*private bool getWANMAC()
        {
            bool a = false;
            bool b = true;
            bool c = true;
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            getWANMAC1 = false;
            string tel = "";
            string tel1 = "";
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();

                string lanMac = getLanMac();
                lanMac = lanMac.ToUpper();
                msg("LANMAC:" + lanMac);
                
                delay(200);
                if (lanMac.Contains("NO_LANMAC"))
                {
                    fail(err.Err_LANMAC);
                    a = false;
                    return a;
                }
                Status("getWANMAC");
                msg("getWANMAC");
                while (b)
                {
                    try
                    {
                        if (telnet.Connect(inf.Ipcmts))//10.52.78.69
                        {
                            count3 = count1 % 2;
                            if (count3 == 0)
                            {
                                delay(2000);
                                telnetSend("obaroot1");
                                delay(500);
                                telnetSend("admin123");
                                delay(500);
                                telnetSend("en");
                                delay(500);
                                telnetSend("con");
                                delay(500);
                                telnetSend("display cable modem online");
                                delay(1000);
                                telnetSend("\r\n");
                                delay(500);
                                telnetSend("{SPACE}");
                                delay(1000);
                                tel1 = "telnet_obaroot1";
                            }
                            else
                            {
                                delay(2000);
                                telnetSend("ma5800");
                                delay(500);
                                telnetSend("admin123");
                                delay(500);
                                telnetSend("en");
                                delay(500);
                                telnetSend("con");
                                delay(500);
                                telnetSend("display cable modem online");
                                delay(1000);
                                telnetSend("\r\n");
                                delay(500);
                                telnetSend("{SPACE}");
                                delay(1000);
                                tel1 = "telnet_ma5800";
                            }
                            tel = tel1 ;
                            while (c)
                            {
                                tel = txttelnet.Text;//txtOutput
                                if (txttelnet.Text.Contains("Total") | tel.Contains("Idx is the index of a CM"))//Idx is the index of a CM.
                                {
                                    //Wanip = cmd.GetKeyByNumber(txtOutput.Text, lanMac, 14);
                                    CMip = tel.Substring(tel.IndexOf(lanMac) + lanMac.Length, 16);
                                    //CMip = txtOutput.Text.Substring(txtOutput.Text.IndexOf(lanMac) + lanMac.Length, 15);
                                    delay(1000);
                                    //CMip = CMip.Substring(lanMac.Length, 14);
                                    CMip = CMip.Trim();
                                    if (cmIP.Contains("10.52."))
                                    {
                                        sendDataToSer(1);
                                        msg("CM_IP:" + CMip);
                                        telnet.close();
                                        a = true;
                                        b = false;
                                        c = false;
                                    }
                                    else
                                    {
                                        sendDataToSer(1);
                                        msg("ERR_CM_IP:" + CMip);
                                        telnet.close();
                                        getWANMAC1 = true;
                                        b = false;
                                        c = false;
                                    }

                                }//*
                                else
                                {
                                    telnetSend("\r\n");
                                    delay(500);
                                    //  SendKeys.SendWait("{SPACE}");
                                    telnetSend("{SPACE}");
                                    delay(1000);
                                    count1++;

                                    if (count1 > 150)
                                    {
                                        fail(err.Err_Server_Telnet);
                                        a = false;
                                        b = false;
                                        c = false;
                                    }
                                }

                            }
                            Thread.Sleep(200);
                        }
                        else
                        {
                            count++;
                            if (count > 10)
                            {
                                fail(err.Err_CMMAC_Total);
                                telnet.close();
                                a = false;
                                b = false;
                                c = false;
                            }
                        }

                    }
                    catch(Exception ex)
                    {
                        delay(10000);
                        msg("Err_CMTS_Connect:" + ex.Message);
                        count2++;
                        if (count2 > 4)
                        {
                            fail(err.Err_CMTS_Connect);
                            telnet.close();
                            a = false;
                            b = false;
                            c = false;
                        }
                    }
                    Thread.Sleep(200);
                }
                
            }
            else
            {
                sendDataToSer(6);
                delay(500);
                sendDataToSer(3);
                delay(500);
                sendDataToSer(5);
                delay(500);
                thStattus2 = false;
                fail(errCode);
                //Status();
            }
            return a;
        }*/
        private bool checkInformation()
        {

            bool a = false;
            bool b = true;
            if (thStattus1 == true)
            {
                Status("checkInformation");
                msg("checkInformation");
                int count = 0;
                int count1 = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.2.1.1.1.0"))
                    {
                        string va = cable.value.Trim();
                        txtinfoDUT.Text = va;
                        msg("Product Information : " + va + "-End");
                        string infodut = getKeyEnd(txtinfoDUT.Text, "Technicolor DOCSIS");
                        msg("Sample Information : " + txtInfoModem.Text + "-End");
                        if (txtInfoModem.Text.Equals(txtinfoDUT.Text))
                        {
                            a = true;
                            msgPass("checkInformation");
                            b = false;
                        }
                        else if (txtInfoModem.Text.Contains(txtinfoDUT.Text))
                        {
                            a = true;
                            msgPass("checkInformation");
                            b = false;
                        }
                        else if (txtInfoModem.Text == va)
                        {
                            a = true;
                            msgPass("checkInformation");
                            b = false;
                        }
                        else
                        {
                            Status(err.Err_Information);
                            mt2 = "Checking";
                            ErrorNian("Err_Information");
                            a = false;
                            b = false;
                        }
                    }
                    else
                    {
                        count++;
                        delay(2000);
                        if (count >= 3)
                        {
                            Status("Err_Mib_Information");
                            if (PingSreverNian())
                            {
                                ErrorNian("Err_Mib_Information");
                                a = false;
                                b = false;
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private int compareString(string valueSnmp, string valueCam)
        {
            msg("compareString: InfoByMib-->" + valueSnmp +"  <==>   "+ " InfoByLabel-->" + valueCam);
            List<string> list = new List<string>();
            List<string> list1 = new List<string>();
            int count = 0;
            if (valueSnmp.Length == valueCam.Length)
            {
                for (int i = 0; i < valueSnmp.Length; i++)
                {
                    list.Add(valueSnmp.Substring(i, 1));
                }
                for (int i = 0; i < valueCam.Length; i++)
                {
                    list1.Add(valueCam.Substring(i, 1));
                }
                for (int i = 0; i < valueSnmp.Length; i++)
                {
                    if (list[i] == list1[i])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private int compareStringWifi(string valueSnmp, string valueCam, string valueCam2)
        {
            List<string> list = new List<string>();
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            //List<string> list3 = new List<string>();
            int count = 0;
            if (valueSnmp.Length == 15)
            {
                for (int i = 0; i < valueSnmp.Length; i++)
                {
                    list.Add(valueSnmp.Substring(i, 1));
                }
            }
            else
                return count = valueSnmp.Length;
            if (valueCam.Length == 15)
            {
                for (int i = 0; i < valueCam.Length; i++)
                {
                    list1.Add(valueCam.Substring(i, 1));
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    try
                    {
                        if (valueCam.Substring(i, 1) != null)
                        {
                            list1.Add(valueCam.Substring(i, 1));
                        }
                    }
                    catch
                    {
                        list1.Add("@");
                    }
                }
            }
            //if (valueCam2.Length == 15)
            //{
            //    for (int i = 0; i < valueCam2.Length; i++)
            //    {
            //        list2.Add(valueCam2.Substring(i, 1));
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 15; i++)
            //    {
            //        try
            //        {
            //            if (valueCam2.Substring(i, 1) != null)
            //            {
            //                list2.Add(valueCam2.Substring(i, 1));
            //            }
            //        }
            //        catch
            //        {
            //            list2.Add("@");
            //        }
            //    }
            //}
            for (int i = 0; i < valueSnmp.Length; i++)
            {
                if ((list[i] == list1[i]))
                {
                    count++;
                }
            }
            msg("WifiCount:" + count.ToString());
            return count;
        }
 
        private bool getWifiPassword()
        {
            bool a = false;
            bool b = true;
            getWifiPasswordPass = false;
            if (!checkStatustesting(mt8)) return a;
            if (thStattus1 == true)
            {
                Status("Check_WifiPassword");
                msg("Check_WifiPassword");
                int count = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.4.1.17270.50.2.2.3.1.1.2.10001"))
                    {
                        delay(1000);
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Trim();
                        Passwordlale = va;
                        msg("MIB_WifiPassword: " + va);                      
                        if (lbwifiPassword.InvokeRequired)
                        {
                            lbwifiPassword.Invoke(new Action(() =>
                            {
                                lbwifiPassword.Text = va;                              
                            }));
                        }
                        else
                        {
                            lbwifiPassword.Text = va;
                        }
                        if (va.Length < 15)
                        {
                            if (va.Contains("password30") | va.Contains("password3"))
                            {
                                mt2 = "Checking";                        
                                ErrorNian("OP_Chua_Reset");
                                a = false;
                                b = false;
                                return false;
                            }
                            else
                            {

                                mt2 = "Checking";
                                ErrorNian("Error_SSID_Length");
                                a = false;
                                b = false;
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        count++;
                        if (count >= 2)
                        {
                            if (PingSreverNian())
                            {
                                a = false;
                                b = false;
                                ErrorNian("Err_wifi_password");
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            
            return a;
        }   
        private bool getSSIDName()
        {
            bool a = false;
            bool b = true;
            getSSIDNamePass = false;
            if (thStattus1 == true)
            {
                Status("Check_SSID_Name");
                msg("Check_SSID_Name");
                int count = 0, count1 = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.4.1.17270.50.2.2.2.1.1.3.10001"))
                    {
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Trim();
                        SSISNamelale = va;
                        msg("Mib_SSID:" + va);
                        if (lbSsid.InvokeRequired)
                        {
                            lbSsid.Invoke(new Action(() => lbSsid.Text = va));
                        }
                        else{ lbSsid.Text = va;}
                        if (lbSsid.Text.Contains(SSIDName))
                        {
                            getSSIDNamePass = true;
                            a = true;
                            b = false;
                            return true;
                        }
                        else
                        {
                            if (lbSsid.Text.Length < 10)
                            {
                                if (lbSsid.Text.Contains( "admin"))
                                {
                                    mt2 = "Checking";
                                    ErrorNian("Chua_Reset_DUT");
                                    b = false;
                                    a = false;
                                    return false;
                                }
                                else
                                {
                                    mt2 = "Checking";
                                    ErrorNian("Error_SSID_Length");
                                    b = false;
                                    a = false;
                                    return false;
                                }
                            }
                            else
                            {
                                ErrorNian("Error_SSID_Length");
                                b = false;
                                a = false;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        count++;
                        if (count >= 2)
                        {
                            if (PingSreverNian())
                            {
                                a = false;
                                b = false;
                                ErrorNian("Err_ssidname");
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
   
        private bool checkSN()
        {
            bool a = false;
            bool b = true;
            snvalue = "";

            if (!checkStatustesting(mt8)) { mt2 = "Checking"; return a; }
            if (thStattus1 == true)
            {
                Status("checkSN");
                msg("checkSN");
                int count = 0, count1 = 0;
                {
                    if (lbsndut.Text.Equals(Barcode2D_SN))
                    {
                        a = true;
                        msgPass("checkSN");
                        b = false;
                    }
                    else
                    {
                        count1++;
                        {
                            mt2 = "Checking";
                            c_pingProduct = true;
                            ErrorNian("Err_sn");
                            a = false;
                            b = false;
                        }
                    }
                }
                
            }
            else
            {
                Status("Setup.Check.Sn");
                c_pingProduct = true;
               
            }
            return a;
        }
        private bool getSN()
        {
            bool a = false;
            bool b = true;
            snvalue = "";
            if (thStattus1 == true)
            {
                Status("checkSN");
                msg("checkSN");
                int count = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.4.1.46366.4292.80.1.3.0"))
                    {
                        string va = cable.value;
                        va = va.Replace("\r\n", "").Trim();
                        msg("MibSN:" + va + "\n" + "SN_Label: " + SNledonline);
                        if (!va.Equals(SNledonline) & Label_Test == true)
                        {
                            ErrorNian("Err_Information_SN");
                            return false;
                        }
                        if (va.Contains("368930021515103416"))
                        {
                            HW = "1.2";
                            lbSoftware.Text = "CGM4981COM_4.14p6s4_PROD_sey";
                            lbBootver.Text = "S1TC-3.81.21.94";
                            txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 1.2; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.94; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>-End";
                        }
                        else
                        {
                            if (va.Length == 16)
                            {
                                if (va.Substring(4, 2).Contains("05"))
                                {
                                    HW = "2.1";
                                    txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.1; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>";
                                }
                                else
                                {
                                    HW = "2.0";
                                    txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>";
                                }
                            }
                            else
                            {
                                if (va.Substring(6, 2).Contains("05"))
                                {
                                    HW = "2.1";
                                    if (sModem == "CGM4981COM-DEV")
                                    {
                                        txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.1; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_DEV_sey; MODEL: CGM4981COM>>";
                                    }
                                    else
                                    {
                                        txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.1; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>";
                                    }
                                }
                                else
                                {
                                    HW = "2.0";
                                    txtInfoModem.Text = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>";
                                }
                            }
                        }
                        if (lbsndut.InvokeRequired)
                        {
                            lbsndut.Invoke(new Action(() => lbsndut.Text = va));
                            snvalue = va;
                            b = false;
                            a = true;
                            return true;
                        }
                        else
                        {
                            lbsndut.Text = va;
                            snvalue = va;
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    else
                    {
                        count++;
                        if (count >= 3)
                        {
                            if (PingSreverNian())
                            {
                                ErrorNian("Err_GetSN_MIB");
                                a = false;
                                b = false;
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }         
            return a;
        }
        private bool checkCMMAC()
        {
            bool a = false;
            bool b = true;
            if (thStattus1 == true)
            {
                if (!checkStatustesting(mt8)) { mt2 = "Checking"; return a; }
                cmn.date_TimeStart();
                Status("checkCMMAC");
                msg("checkCMMAC");

                int count = 0, count1 = 0;

                if (lbCMMAC.Text.Equals(LbMACText) | lbCMMAC.Text.Equals(Barcode2D_CMMAC))
                {
                    a = true;
                    msgPass("checkCMMAC");
                    b = false;
                }
                else
                {
                    {
                        c_pingProduct = true;
                        Status(err.Err_CMMAC);
                        ErrorNian("Err_CMMAC");
                        a = false;
                        b = false;
                    }

                }
                
            }
            else
            {
                c_pingProduct = true;
                Status("Setup.Err_CMMAC");
                
            }
            return a;
        }
        private bool getCMMAC()
        {
            bool a = false;
            bool b = true;
            int c = 1000;
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();
                Status("checkCMMAC");
                msg("MIB_GET_CMMAC!");
                int count = 0, count1 = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.4.1.46366.4292.80.1.4.0"))
                    {
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Replace(":", "");
                        va = va.Trim();
                        CMmaclable = va;
                        msg("MIB_CMMAC=> " + va);
                        if (lbCMMAC.InvokeRequired)
                        {
                            lbCMMAC.Invoke(new Action(() => lbCMMAC.Text = va));
                            b = false;
                            a = true;
                            return true;
                        }
                        else
                        {
                            lbCMMAC.Text = va;
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    else
                    {
                        count++;
                        if (count >= 3)
                        {
                            if (PingSreverNian())
                            {
                                Status("Err_Mib_CMMAC");
                                mt2 = "Checking";
                                ErrorNian("Err_Mib_CMMAC");
                                a = false;
                                b = false;
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool checkMTAMAC()
        {
            bool a = false;
            bool b = true;
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();
                Status("checkMTAMAC");
                msg("checkMTAMAC");
                int count = 0, count1 = 0;

                if (lbMTAMAC.Text.Equals(lbMTAMAC) | lbMTAMAC.Text.Equals(Barcode2D_MTAMAC))
                {
                    a = true;
                    msgPass("checkMTAMAC");
                    b = false;
                }
                else
                {
                    count1++;
                    // if (count1 > 3)
                    {
                        c_pingProduct = true;
                        Status(err.Err_MTAMAC);
                        mt2 = "Checking";
                        ErrorNian("Err_MTAMAC");
                        a = false;
                        b = false;
                    }
                }
                
            }
            else
            {
                c_pingProduct = true;
                Status("Setup.Err_MTAMAC");
                
            }
            return a;
        }
        private bool getMTAMAC()
        {
            bool a = false;
            bool b = true;
            int c = 1000;
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();
                Status("checkMTAMAC");
                msg("MIB_GET_MTAMAC");
                int count = 0, count1 = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.2.1.2.2.1.6.16"))
                    {
                        // delay(c);
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Replace(" ", "");
                        va = va.Replace(":", "").Trim();
                        Mtamaclable = va;
                        msg("MIB_GET_MTAMAC=> " + va);
                        if (lbMTAMAC.InvokeRequired)
                        {
                            lbMTAMAC.Invoke(new Action(() => lbMTAMAC.Text = va));
                            a = true;
                            b = false;
                            return true;
                        }
                        else
                        {
                            lbMTAMAC.Text = va;
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    else
                    {
                        c = c + 3000;
                        count++;
                        if (count >= 2)
                        {
                            if (PingSreverNian())
                            {
                                Status("Err_Mib_MTAMAC");
                                mt2 = "Checking";
                                ErrorNian("Err_Mib_MTAMAC");
                                a = false;
                                b = false;
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool getMACBLE()
        {
            bool a = false;
            bool b = true;
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();
                Status("Geting_MACBLE");
                msg("MIB_GET_MACBLE");
                int count = 0, count1 = 0;
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", "1.3.6.1.4.1.46366.4292.80.2.9.0"))
                    {
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Replace(" ", "");
                        va = va.Trim();
                        // Mtamaclable = va;
                        msg("MIB_GET_MACBLE=> " + va);
                        //if (lbMTAMAC.InvokeRequired)
                        //{
                        // lbMTAMAC.Invoke(new Action(() => lbMTAMAC.Text = va));
                        a = true;
                        b = false;
                        //    return true;
                        //}
                        //else
                        //{
                        //    lbMTAMAC.Text = va;
                        //    a = true;
                        //    b = false;
                        return true;
                        //}
                    }
                    else
                    {
                        return false;
                        //count++;
                        //if (count >= 2)
                        //{
                        //    ///Status(err.Err_snmp_connect);
                        //    mt2 = "Checking";
                        //    ///ErrorNian("Err_snmp_connect");
                        //    a = false;
                        //    b = false;
                        //    return false;
                        //}
                        //cmn.openExe1(pathfile1, "ResetEthSever");
                        //delay(5000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
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
 
        private void AudioDevice()
        {
            try
            {
                cmbAudioDevice.Items.AddRange(voip.findDeviceDetial("Speaker"));
                cmbAudioRecoder.Items.AddRange(voip.findDeviceDetial("Mic"));
                cmbAudioDevice.SelectedIndex = 0; cmbAudioRecoder.SelectedIndex = 0;
                cmbAudioDevice.Enabled = false; cmbAudioRecoder.Enabled = false;
            }
            catch
            {
                MyMessagesBox.Show("Kiểm tra tín hiệu Spekers or Microphone");
            }
        }
        private void ResetRelayVOIPNian()
        {
            if (sLine == "T1")
            {
                comCmd("out1_off");
                delay(300);
                comCmd("out2_off");
                delay(300);
                comCmd("out5_off");
                delay(300);
            }
            else{
                comCmd("p1p2");
                delay(300);
                comCmd("teof");
                delay(300);
            }           
            if (!comCmd1to2("ATH")) { dkvoipnian = false; return; }
            delay(300);
            //if (!comCmd1to2("AT+FCLASS=8")) { dkvoipnian = false; return; }
            //delay(500);
            //comCmd1to2("AT+VGT=128");
            //delay(500);
            //comCmd1to2("ATDT1001");
            //delay(1300);
            //comCmd("out5_on");
            //delay(300);
        }
        private void ResetRelayVOIP()
        {
            int count = 0;
            comCmd("out1_off");
            delay(300);
            comCmd("out2_off");
            delay(300);
            comCmd("out3_off");
            delay(300);
            comCmd("out4_off");
            delay(300);
            comCmd("out5_off");
            delay(300);
            comCmd("out6_off");
            delay(300);
            comCmd("out7_off");
            delay(300);
            comCmd("out8_off");
            delay(300);
            
        }
        private void ResetRelay()
        {
            if (sLine == "T1")
            {
                comCmd("out1_off");
                delay(100);
                comCmd("out2_off");
                delay(100);
                comCmd("out3_off");
                delay(100);
                comCmd("out5_off");
                delay(100);
            }
            else
            {
                comCmd("p1p2");
                delay(300);
                comCmd("teof");
                delay(300);
            }           
        }
        private void PreCall()
        {
            Preparevoip();
            try
            {
                if (cmn.deleteFile(Directory.GetCurrentDirectory(), "\\AudioTest.mp3")) //mp3
                {                 
                    msgPass("delete file AudioTest ");                                    
                }
                delay(500);
                if (cmn.deleteFile(Directory.GetCurrentDirectory(), "\\nsTest.mp3")) //mp3
                {                 
                    msgPass("delete file nsTest ");                                   
                }
                delay(500);
            }
            catch { msg("Delete File Fail"); }

        }
        private void PreCall1()
        {
            Preparevoip();
            try
            {
                if (cmn.deleteFile(Directory.GetCurrentDirectory(), "\\AudioTest.mp3")) //mp3
                {
                    msgPass("delete file AudioTest ");
                }
                delay(500);             
            }
            catch { msg("Delete File Fail"); }

        }
        private bool playfile(string audioFileName)
        {
            bool a = false;
            AnalysisVoipNian = true;
            string path = Directory.GetCurrentDirectory() + "\\" + audioFileName;
            try
            {
                if (File.Exists(path))
                {
                    voip.PlayAudio(audioFileName, 1);//JingleBells.mp3//1
                    //sAudio.Voip nian = new Voip();
                    //nian.PlayAudio(audioFileName, 1);//JingleBells.mp3//1
                    a = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return a;
        }
        private void AudioRecoder()
        {
            //  voip.Recodeing(cmbAudioRecoder.SelectedIndex, "AudioTest.mp3");
            //  int AudioSlected = 1000;
            try
            {
                if (cmbAudioRecoder.InvokeRequired)
                {
                    cmbAudioRecoder.Invoke(new Action(() =>
                    {
                        var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                        string de = device.DeviceFriendlyName;
                        voip.Recodeing(cmbAudioRecoder.SelectedIndex, "AudioTest.mp3");
                    }));
                }
                else
                {
                    var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                    string de = device.DeviceFriendlyName;
                    voip.Recodeing(cmbAudioRecoder.SelectedIndex, "AudioTest.mp3");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("AudioRecoder:" + ex.Message);

            }
        }
        private void AudioRecodernoise()
        {
            try
            {
                if (cmbAudioRecoder.InvokeRequired)
                {
                    cmbAudioRecoder.Invoke(new Action(() =>
                    {
                        var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                        string de = device.DeviceFriendlyName;
                        voip.Recodeing(cmbAudioRecoder.SelectedIndex, "nsTest.mp3");
                    }));
                }
                else
                {
                    var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                    string de = device.DeviceFriendlyName;
                    voip.Recodeing(cmbAudioRecoder.SelectedIndex, "nsTest.mp3");
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("AudioRecoderNoise: " + ex.Message);
            }
        }
        private void AudioRecoder1()
        {
            //  voip.Recodeing(cmbAudioRecoder.SelectedIndex, "AudioTest.mp3");
            //  int AudioSlected = 1000;
            if (cmbAudioRecoder.InvokeRequired)
            {
                cmbAudioRecoder.Invoke(new Action(() =>
                {
                    var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                    string de = device.DeviceFriendlyName;
                    voip.Recodeing(cmbAudioRecoder.SelectedIndex, "nsTest.mp3");
                }));
            }
            else
            {
                var device = (MMDevice)cmbAudioRecoder.SelectedItem;
                string de = device.DeviceFriendlyName;
                voip.Recodeing(cmbAudioRecoder.SelectedIndex, "nsTest.mp3");
            }

        }

        private void CallP1toP2nian()
        {
            vstop = false;
            ResetRelayVOIPNian();
            msg("ResetRelay");
            value.Clear();
            P1P2 = false;
            try
            {
                PreCall();
                msg("CheckVoipP1toP2");
                if (!comCmd1to2("ATL2")) {return; }
                delay(400);
                if (!comCmd1to2("ATD1002")) { return; }
               // delay(3000);
                if (sLine == "T1") { comCmd("out5_on"); }
                else { comCmd("teon"); }
                delay(3000);
                PlayVoip = true;
                AudioRecodernoise();//ghi am
                delay(6000);
                voip.RecodeingStop();
                delay(100);
                playfile("JingleBells.mp3");//chay file
                delay(1000);
                AudioRecoder();//ghi am
                delay(6000);
                voip.RecodeingStop();
                voip.PlayStop();
                voip.PlayAudioStop();
                delay(2000);
                if (!comCmd1to2("ATH")) { return;}
                delay(300);
                if (sLine == "T1") { comCmd("out5_off"); }
                else { comCmd("teof"); }            
            }
            catch (Exception ex)
            {
               /// MessageBox.Show("CallP1toP2 Exception:" + ex.Message);
            }
        }
        private void Preparevoip()
        {
            try
            {
                voip.RecodeingStop();
                voip.PlayStop();
                voip.PlayAudioStop();

                try
                {
                    voip.wavein.StopRecording();
                    voip.wavein = null;
                }
                catch { }
                try
                {
                    voip.waveWrite.Dispose();
                    voip.waveWrite = null;
                }
                catch { }

                try
                {
                    voip.stream.Close();
                    voip.stream = null;
                }
                catch { }
                try
                {
                    voip.output.Stop();
                }
                catch { }
            }
            catch { }
        }
             
        private bool noiseTest(string bug)
        {
            Status4("Noise_Test: " + bug);
            msg("Noise_Test: " + bug);
            bool a = false;
            VoiPNoise = false;
            if (bug == "P1toP2")
            {
                noiseVoipCount = noiseVoipCountP1;
            }
            else
            {
                noiseVoipCount = noiseVoipCountP2;
            }
            if (thStattus1 == true)
            {
                try
                {
                    Preparevoip();
                    value.Clear();
                    msg("noiseTest");
                    if (playfile("nsTest.mp3"))
                    {
                        delay(100);
                        AnalysisVoip("noise");
                    }
                    if (VoiPNoise == false) return false;
                    else return true;
                }
                catch { }
            }
            return a;
        }
        private bool CheckVoipP1toP2Nian()
        {
            bool a = false;
            VoiP1Pass = false;
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 2; i++)
                {                 
                    msg("Check_VoipP1toP2_time: " + i.ToString());
                    CallP1toP2nian();
                    if (playfile("AudioTest.mp3"))
                    {
                        delay(1500);
                        AnalysisVoip("VOIP1");                       
                    }
                    if (VoiP1Pass == true) return true;
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private void CallP2toP1Nian()
        {
            P1P2 = false;
            ResetRelayVOIPNian();
            msg("ResetRelay");
            if (dkvoipnian == false) return;
            if (!checkStatustesting(mt8)) { mt1 = "Checking"; return; }
            value.Clear();
            if (dkvoipnian == false) return;
            try
            {
                if (sLine == "T1")
                {
                    comCmd("out1_on");
                    delay(100);
                    comCmd("out2_on");
                    delay(100);
                }
                else { comCmd("p2p1");}
                voip.RecodeingStop();
                voip.PlayStop();
                voip.PlayAudioStop();
                PreCall();
                msg("CheckVoipP2toP1");
                if (!comCmd2to1("ATL2")) {return; }
                delay(400);
                if(!comCmd2to1("ATD1001")) {  return; }
               // delay(2800);
                if (vstop == true) return;
                if (sLine == "T1") { comCmd("out5_on"); }
                else { comCmd("teon"); }
                delay(3000);
                PlayVoip = true;
                AudioRecodernoise();//ghi am
                delay(6000);
                voip.RecodeingStop();
                delay(100);
                playfile("JingleBells.mp3");//chay file
                delay(1000);
                AudioRecoder();//ghi am
                delay(6000);
                voip.RecodeingStop();
                voip.PlayStop();
                voip.PlayAudioStop();
                delay(2000);
                if (!comCmd2to1("ATH"))
                delay(300);
                if (sLine == "T1") { comCmd("out5_off"); }
                else { comCmd("teof"); }               
            }
            catch (Exception ex)
            {
               // MessageBox.Show("CallP2toP1 Exception:" + ex.Message);
            }
        }    
        private bool CheckVoipP2toP1Nian()
        {
            bool a = false;
            VoiP2Pass = false;
            if (thStattus1 == true)
            {
                for (int i = 1; i <= 2; i++)
                {                   
                    msg("Check_VoipP2toP1_time: " + i.ToString());
                    CallP2toP1Nian();
                    if (playfile("AudioTest.mp3"))
                    {
                        delay(1500);
                        AnalysisVoip("VOIP2");
                    }
                    if (VoiP2Pass == true) return true;
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private void btnConnect_Click(object sender, EventArgs e)//server
        {
            /*sck.Connect(txtIpAddress.Text, 5325);
            MessageBox.Show("Connected");
            tabControl1.SelectedIndex = 1;
            btnConnect.Enabled = false;*/

        }    
        private bool enableThread()
        {
            bool a = true;
            bool b = true;
            int count = 0;
            //CMip = "10.52.81.237";
            Status("enableThread");
            msg("enableThread");
            enableThreadPass = false;
            cable.connectionSetVer01(CMip, 2, "private", "1.3.6.1.4.1.46366.4292.10001.1.2.0", 1);
            while (b)
            {
                if (mt8.Equals("Checking")) { b = false; }
                //if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.10001.1.2.0"))
                //{
                enableThreadPass = true;
                a = true;
                b = false;
                //}
                //else
                //{
                //    count++;
                //    cable.connectionSetVer0110(CMip, 2, "private", "1.3.6.1.4.1.46366.4292.10001.1.2.0", 1);
                //    if (count > 20)
                //    {
                //        Status2("");
                //        fail(err.Err_Thread_Enable);
                //        b = false;
                //    }
                //}
                Delay(100);
            }
            return a;
        }    
        private bool fanValue()
        {

            cmn.date_TimeStart();
            bool a = false;
            bool b = true;
            fanValuePass = false;
            if (thStattus1 == true)
            {
                msg("fanValue");
                int count = 0;
                // CMip = "10.52.81.237";
                cable.connection(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.77.1.75.1.2.1");
                msg(cable.value);
                while (b)
                {
                    if (!checkStatustesting(mt8)) { mt2 = "Checking"; b = false; }
                    if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.77.1.75.1.2.1"))
                    {
                        fanValuePass = true;
                        msgPass("fanValue");
                        a = true;
                        b = false;
                    }
                    else
                    {
                        count++;
                        cable.connection(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.77.1.75.1.2.1");
                        msg(cable.value);
                        if (count > 20)
                        {
                            mt8 = "Checking";
                            mt2 = "Checking";                   
                            ErrorNian("Err_Fan_Value");
                            b = false;
                        }
                    }
                    Delay(100);
                }
                
            }
            else
            {
                mt8 = "Checking";
                mt2 = "Checking";               
            }
            return a;
        }
        private bool enableBLE()
        {
            double TimeStart = GettimeStart("Enable_BLE");
            bool b = true;
            Status("EnableBLE");
            msg("enableBLE");   
            int count = 0;         
            enableBLEPass = false;      
            try
            {               
                while (b)
                {
                    if (thStattus1 == false) return false;
                    cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.1.0", 1);
                    Delay(2500);
                    msg(cable.value);
                    if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.10001.1.1.0"))
                    {
                        enableBLEPass = true;                     
                        msg("enableBLE_ok");
                        msgPass("enableBLE");            
                        b = false;
                        break;
                    }
                    else
                    {
                        count++;                        
                        if (count >= 4)
                        {
                            enableBLEPass = false;
                            Status("");
                            ErrorNian("Err_BLE_Enable");
                            b = false;
                            break;
                        }
                        delay(2000);
                    }
                }
            }
            catch
            {
                count++;
                if (count > 3)
                {
                    enableBLEPass = false;
                    Status("");
                    ErrorNian("Err_BLE_Enable");
                    b = false;
                }
                delay(2000);
            }

            double TimeEnd = GettimeEnd("Enable_BLE");
            TimeEnableBLE = CountTime("Enable_BLE", TimeStart, TimeEnd);
            return enableBLEPass;           
        }
        private bool enableZigbee()
        {
            double TimeStart = GettimeStart("EnableZigbee");
            bool b = true;
            Status("EnableZigbee");
            msg("enableZigbee");
            delay(200);
            int count = 0;
            enableZigBeePass = false;          
            while (b)
            {
                if (thStattus1 == false) return false;
                cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.4.0", 2);
                Delay(2500);
                msg(cable.value);
                if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.10001.1.4.0"))
                {
                    enableZigBeePass = true;
                    msg("enableZigbee_ok");
                    msgPass("enableZigbee");                  
                    b = false;
                    break;
                }
                else
                {
                    count++;                            
                    if (count >= 4)
                    {
                        enableZigBeePass = false;
                        Status("");
                        ErrorNian("Err_Zigbee_Enable");
                        b = false;
                        break;
                    }
                    delay(2000);
                }
            }
            double TimeEnd = GettimeEnd("EnableZigbee");
            TimeEnableZgbee  = CountTime("EnableZigbee", TimeStart, TimeEnd);
            return enableZigBeePass;
        }
        private bool disableBLE()
        {
            cmn.date_TimeStart();
            bool a = false;
            bool b = true;
            Status("disableBLE");
            msg("disableBLE");
            int count = 0;
            // CMip = "10.52.81.237";
            cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.1.0", 0);
            msg(cable.value);
            while (b)
            {
                if (mt8.Equals("Checking")) { b = false; }
                if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.10001.1.1.0"))
                {

                    //msgPass("enableBLE");
                    msg("disableBLE_ok");
                    a = true;
                    b = false;
                }
                else
                {
                    count++;
                    cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.1.0", 0);
                    msg(cable.value);
                    if (count > 4)
                    {
                        Status(err.Err_BLE_Enable);
                        ErrorNian("Err_BLE_Enable");
                        b = false;
                    }
                }
                Delay(100);
            }
            
            return a;
        }
        private bool disableZigbee()
        {
            double TimeStart = GettimeStart("DisableZigbee");
            bool a = false;
            bool b = true;
            Status("disableZigbee");
            msg("disableZigbee");
            int count = 0;
            disaZigBeePass = false;
            while (b)
            {
                if (thStattus1 == false) return false;
                cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.4.0", 1);
                msg(cable.value);
                Delay(5000);
                disaZigBeePass = true;
                return true;
                if (cable.connected.Contains("1.3.6.1.4.1.46366.4292.10001.1.4.0"))
                {
                    disaZigBeePass = true;
                    msg("disableZigbee_ok");
                    msgPass("disableZigbee");
                    a = true;
                    b = false;
                    break;
                }
                else
                {
                    count++; 
                    //if(count == 3)
                    //{   
                    //    cable.connectionSetVer01(CMip, 1, "private", "1.3.6.1.4.1.46366.4292.10001.1.4.0", 2);
                    //    delay(40000);                       
                    //}
                    if (count > 3)
                    {
                        MessageBox.Show("Kiểm tra Sample ZIGBEE");
                        Status(err.Err_Zigbee_Enable);
                        ErrorNian("Err_Zigbee_Enable");
                        disaZigBeePass = false;
                        b = false;
                        a = false;
                        break;
                    }
                    delay(2000);
                }
            }
            double TimeEnd = GettimeEnd("DisableZigbee");
            TimeDisableZgbee = CountTime("DisableZigbee", TimeStart, TimeEnd);
            return disaZigBeePass;
        }    
        private void Form1_Load(object sender, EventArgs e)
        {
            cmn.openExe1(pathfile1, "disableFirewall");
            OP = "";
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


            try
            {
                cmn.loadFile("initial.ini");
                if (!loadComport()) return;
                cmbComport.Enabled = false; cmbComVoip.Enabled = false; btnOpenCom.Enabled = false;
                btnStart.Enabled = false;
                loadData();
                AudioDevice();
                Process[] proc = Process.GetProcessesByName("XLAXB8");
                if (proc.Length == 0)
                {
                    openledprogram("StartXLA", "");
                }
            }
            catch
            {
                MyMessagesBox.Show("\n\nGoi ky su kiem tra File: initial.ini\n        Prosetting.txt");
                //cmn.kill("Automatic");
            }
        }
        private string comname()
        {
            string name = "";
            if (this.cmbComport.InvokeRequired)
            {
                cmbComport.Invoke(new Action(() => name = cmbComport.Items[cmbComport.SelectedIndex].ToString()));
            }
            else name = cmbComport.Items[cmbComport.SelectedIndex].ToString();
            return name;
        }
        private void LogFilePSU(string data)
        {
            try
            {
                string time = DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "p" + DateTime.Now.Second.ToString() + "s";
                string date = DateTime.Now.ToString("MM / dd / yyyy");
                date = DateTime.Now.ToString("dd-MM-yyyy");
                date = date.Replace("-", ".");
                string directoryPath = "D:\\LogFilePSU" + @"\" + date;
                string filePathSN3 = directoryPath + @"\SummaryPSU.ini";
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                //if (!File.Exists(filePathSN3))
                //{
                //    StreamWriter strWrite1 = new StreamWriter(filePathSN3, true);                   
                //}
                StreamWriter strWrite = new StreamWriter(filePathSN3, true);
                strWrite.WriteLine(time + "\t" + data);
                strWrite.Flush();
                strWrite.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LogFile Exception:" + ex.Message);
            }
        }
        private bool preStarrt()
        {
            bool a = false;
            if (lbStatus.InvokeRequired)
            {
                lbStatus.Invoke(new Action(() =>
                {
                    lbStatus.Text = errs; lbStatus.ForeColor = Color.Green;
                }));
            }
            else
            {

                lbStatus.ForeColor = Color.Green;
            }
            if (lbStatusPass.InvokeRequired)
            {
                lbStatusPass.Invoke(new Action(() => lbStatusPass.Text = ""));
            }
            else
            {
                lbStatusPass.Text = "";
            }         
            if (lbwifiPassword.InvokeRequired)
            {
                lbwifiPassword.Invoke(new Action(() => lbwifiPassword.Text = ""));
            }
            else
            {
                lbwifiPassword.Text = "";
            }
            if (lbsndut.InvokeRequired)
            {
                lbsndut.Invoke(new Action(() => lbsndut.Text = ""));
            }
            else
            {
                lbsndut.Text = "";
            }
            if (lbMTAMAC.InvokeRequired)
            {
                lbMTAMAC.Invoke(new Action(() => lbMTAMAC.Text = ""));
            }
            else
            {
                lbMTAMAC.Text = "";
            }
            if (lbCMMAC.InvokeRequired)
            {
                lbCMMAC.Invoke(new Action(() => lbCMMAC.Text = ""));
            }
            else
            {
                lbCMMAC.Text = "";
            }
            if (lbWanMac.InvokeRequired)
            {
                lbWanMac.Invoke(new Action(() => lbWanMac.Text = ""));
            }
            else
            {
                lbWanMac.Text = "";
            }       
            if (lbSsid.InvokeRequired)
            {
                lbSsid.Invoke(new Action(() => lbSsid.Text = ""));
            }
            else
            {

                lbSsid.Text = "";
            }
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action(() => btnStart.Enabled = false));
            }
            else
            {
                btnStart.Enabled = false;
            }
            if (lblerr.InvokeRequired)
            {
                lblerr.Invoke(new Action(() => lblerr.Text = ""));
            }
            else
            {
                lblerr.Text = "";
            }                
            mt1 = "start";
            mt2 = "start";
            mt3 = "start";
            mt4 = "start";
            mt5 = "start";
            mt6 = "start";
            mt7 = "start";
            mt8 = "start";
            wpsButton = false;
            getWANMAC1 = false;
            BLEstatus = false;
            BLEresult = false;
            noise = false;
            voipNoise = false;
            voipNoiseResult = false;
            NoiseResult = false;
            VoipMoca = false;
            VoiP1P2Again = 0;
            VoiP2P1Again = 0;
            VoiP2P1Againtest = false;
            VoiP1P2Againtest = false;
            p1p2Picup = false;
            p1p2PicupResult = false;
            checkPingEth2Pass = false;           
            accessWebsiteNewPassCon = false;
            getWANMACPass = false;
            enableThreadPass = false;
            enableBLEPass = false;
            CheckLed_1000EthPass = false;
            CheckVoipP1toP2PASS = false;
            checkPingEth1Pass = false;
            gw = false;
            gw1 = false;
            PlayVoip = false;
            CheckLed_100EthPass = false;
            checkPingMocaPass = false;
            getWifiPasswordPass = false;
            checkWifiPasswordPass = false;
            CheckVoipP2toP1PASS = false;
            SNduplicate = false;
            accessWebsitePass = false;
            clickWPSWebPass = false;
            clickMocaWebPass = false;
            waitCheckLed1G = true;
            fanValuePass = false;
            lbStatus.Text = "";
            lbStatus4.Text = "";
           
            sendDataToSer(3);
            Barcode2D_SN = "";
            PlayVoip = false;
            Check_SNPass = false;
            noiseTestPass = false;
            GetInfLableSSIDNamePass = false;
            getSSIDNamePass = false;
            checkPingResetTodefaultPass = false;
            seyup1G = false;
            checkSpeed1GPass = false;
            checkfailStatus = false;
            Preparevoip();
            a = true;
            return a;
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
        private bool preTesting()
        {
            bool a = false;
            thStattus1 = true;
            thStattus2 = true;
            CMip = "";
            snvalue = "";
            Status("Starting");
            txttelnet.Clear();
            txtOutput.Clear();
            txtOutput.Clear();        
            if (!preStarrt()) return a;
            a = true;
            return a;

        }
        private bool checkDuplicateTest()
        {
            string data = "";
            string Path1 = Directory.GetCurrentDirectory() + "\\SNtest.txt";
            bool a = true;    
            string SN1 = lbsndut.Text.Trim();
            List<string> dataSN = new List<string>();
            dataSN = cmn.loadFileNian("SNtest.txt");
            SNduplicate = true;
            try
            {
                StreamReader loadledGreen = new StreamReader(Path1, Encoding.UTF8);
                data = loadledGreen.ReadToEnd();
                loadledGreen.Close();
                if (data.Contains(SN1))
                {
                    a = false; 
                }
            }
            catch { a = true; }       
            //if (dataSN.Contains("No_Data"))
            //{
            ////    a = true;
            ////    return true;
            ////}
            //else
            //{

            //    //foreach (string SNDupble in dataSN)
            //    //{
            //    //    if (SNDupble.Equals(SN1))
            //    //    {
            //    //        SNduplicate = false;
            //    //        a = false;                      
            //    //    }                 
            //    //}
            //}
            if (dataSN.Count >= 5) { File.Delete(Directory.GetCurrentDirectory() + "\\SNtest.txt"); }
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            StopPGram();
            Label_Test = true;
            try
            {
                if (thMutiple8.IsAlive)
                {
                    try { thMutiple8.Abort();}
                    catch { }
                }
            }
            catch { }
            Status("Open >> Pls.Waiting! ");          
            thStattus1 = true;
            errs = "";
            data = "";
            timS = true;
            timStart.Enabled = true;            
            v_process = 0;
            Err_code = "";
            ERR_CODE1 = "";
            Status("Start >> Good Lucky! ");
            txtComFB.Clear();
            Status("-> Put Product in Fixture!");
            Status4("->Put Product in Fixture!");
            //testing();
        }
        private void khoitao()
        {
            Err_code = "";
            ERR_CODE1 = "";
            countPSU = 0;
            AnalysisVoipNian = false;
            cmn.kill("msedge");
            cmn.kill("GrabBarcode");
            DIALTONE1 = 0;
            DIALTONE2 = 0;
            averP1 = 0;
            Dup1 = 0;
            waveP1 = 0;
            averP2 = 0;
            Dup2 = 0;
            waveP2 = 0;         
            nk = false;
            DKGet_SN = false;
            SFC_flag = false;
            timS = false;
            dkvoipnian = true;           
            LockloginWeb = true;
            StatusERR("");
            bufSFC = "";
            ButtonReset = false;
            DKVOIP1 = DKLED100M = DKlED1G = DKLEDONLINE = false;       
            dkfailssid = false;
            v_process = 0;
            demDup = 0;
            Feasa = false;
            PingWPS = true;
            StopWEB();
            Checksignal_VOIPPass = false;
            enableBLEPass = false;     
            c_pingProduct = false;
            DKPressLedOnline = true;
            dkcheckVOIP = true;
            stoptestUSB = false;
            dkresetodefoult = true;
            dkvoipretest = true;
            CheckLed_USB = false;
            dkvoip = true; LockloginWeb = true; disaZigBeePass = false; CheckLed_OnlinePass = false; CheckLed_WPSPass = false;
            lbsndut.Text = "";
            khuyen = "";
            Nian = "";
            dkvoip = true; // enable moca
            SNHieuPC = false;
            SNlable = "";         
            SSISNamelale = "";
            Passwordlale = "";
            CMmaclable = "";
            Wanmaclable = "";
            Mtamaclable = "";
            lbMTAMAC.Text = "";
            lbWanMac.Text = "";
            lbCMMAC.Text = "";
            lbsndut.Text = "";
            lbwifiPassword.Text = "";
            lbSsid.Text = "";
            valueRed_Online = 0.00;
            valueGreen_Online = 0.00;
            valueBlue_Online = 0.00;
            valueX_Online = 0.00;
            valueY_Online = 0.00;
            valueRed_WPS = 0.00;
            valueGreen_WPS = 0.00;
            valueBlue_WPS = 0.00;
            valueX_WPS = 0.00;
            valueY_WPS = 0.00;
            TimepingEth1 = 0.0;
            TimepingEth2 = 0.0;
            TimepingEth3 = 0.0;
            TimepingEth4 = 0.0;
            TimeSpeed1G = 0.0;
            ledgrren = 0.0;
            ledred = 0.0;
            ledonline = 0.0;
            ledWPS = 0.0;
            ledusb = 0.0;
            TimeSpeed100M = 0.0;
            TimeEnableZgbee = 0.0;
            TimeDisableZgbee = 0.0;
            TimeEnableBLE = 0.0;
            Timeweb = 0.0;
            TimeMoca = 0.0;
            TimeVoip1 = 0.0;
            TimeVoip2 = 0.0;
            Lable = 0.0;
        }
        private void testing()
        {
            //for (int p = 0; p <= 9; p++)
            //{
            khoitao();
            Clear_SFC();
            textBox1.Clear();
            VoipAgain = true;
            countTimeTest = 0;
            lbTimeShow.Focus();
            timeTest.Enabled = true; 
            timStart.Enabled = false;
            testingqq();
            set_speed_Eth_port("All", "1000");           
            try
            {
                Type_Program = "ON";
                if (cmmType.SelectedIndex == 1)
                {
                    Type_Program = "OFF"; btnStart.BackColor = Color.Yellow;
                    btnStart.ForeColor = Color.Red;
                }
                else { btnStart.BackColor = Color.Lime; }
                WriteCPU("STATUS=RUNNING");
                txtComFB.Clear();                
                string pathfile1 = Directory.GetCurrentDirectory();
                cmn.deleteFile(pathfile1, "\\data.json");
                if (!preTesting()) return;
                msg(DateTime.Now.ToString());
                msg("OP testing --> " + OP);
                if (Type_Program == "ON")
                {
                    Label_Test = true;
                    if (lockpc.Contains("yes"))
                    {
                        if (!Checklockpc())
                        {
                            ErrorNian("Lock_Program!!");
                            return;
                        }
                    }
                    if (!ChecklockpcPUS())
                    {
                        ErrorNian("Lock_Program!!");
                        return;
                    }
                }
                if (!countmaintain())
                {
                    msg("Pls. Call QE team Maintain Fixture!!!");
                    ErrorNian("Maintain Fixture!!");
                    return;
                }                   
                Status("Testing...");
                cmn.openExe1(pathfile1, "enableEth1");            
                btnStart.Enabled = true;
                if (Label_Test == true)
                {
                    thMutiple1 = new Thread(new ThreadStart(thereadSN));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    for (int d = 0; d <= 300; d++)
                    {
                        if (thStattus1 == false) return;
                        if (SNHieuPC == true) break;
                        else
                        {
                            Status4("Wait_SN_XLA: " + d.ToString());
                            Delay(1000);
                        }
                        if (d > 200) { ErrorNian("Error_Get_SN"); }
                    }
                }
                if (cmmType.SelectedIndex == 1) {}// khuyen = getLanMacNian(); }
                else
                {
                    if (!checkDuplicateTest())
                    {
                        ErrorNian("Err_Dupble_SN--> ID002"); return;
                    }
                    else
                    {
                        if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); ErrorNian("Err_Check_SN_SFC"); return; }
                    }
                }
                if (LedPhone.Contains("yes"))
                {
                    thStattus1 = true;
                    thMutiple1 = new Thread(new ThreadStart(thchecksignal));
                    thMutiple1.IsBackground = true;
                    thMutiple1.Start();
                    for (int d = 0; d <= 300; d++)
                    {
                        if (thStattus1 == false) return;
                        if (Checksignal_VOIPPass == true) break;
                        else
                        {
                            Status4("LED_Signal_VOIP: " + d.ToString());
                            Delay(1000);
                        }
                        if (d > 200) { ErrorNian("LED_Signal_VOIP"); }
                    }
                }
                thMutiple2 = new Thread(new ThreadStart(thrMultledWPS));
                thMutiple2.IsBackground = true;
                thMutiple2.Start();
                adjusmicro();
                adjusvolume();
                thMutiple3 = new Thread(new ThreadStart(thrMultVOIP));
                thMutiple3.IsBackground = true;
                thMutiple3.Start();
                cmn.openExe1(pathfile1, "disableEth234-SV");
                cmn.openExe1(pathfile1, "mocaDyIp");
                delay(1500);
                if (!checkPingEth1()) return;
                khuyen = GetLanMacNian();
                //if (Type_Program == "OFF" | model.Equals("2")) { khuyen = GetLanMacNian();}
                cmn.openExe1(pathfile1, "enableEthSever");
                delay(5000);
                cmn.openExe1(pathfile1, "disableEth1");
                delay(1000);
                double TimeStart1 = GettimeStart("Infor2");
                if (sModem == "CGM4981SHW")
                {
                    if (!PingSreverNian()) { StatusERR("PingSERVER"); return; }
                    if (!GetWANMAC()) { StatusERR("getWANMAC"); return; }
                }
                else
                {
                    if (line == "old")
                    {
                        if (!PingSreverNian()) { StatusERR("PingSERVER"); return; }
                        if (!GetWANMAC()) { StatusERR("getWANMAC"); return; }
                    }
                    else
                    {
                        IPSERVER = "172.21.25.242";
                        if (!PingSreverNian()) { StatusERR("PingSERVER"); return; }
                        if (!GetIpCMTSNian()) { StatusERR("getWANMAC"); return; }
                    }
                }
                if (!getSN()) { StatusERR("getSN"); return; }
                delay(1000);                                    
                if (!checkInformation()) { StatusERR("checkInformation"); return; }
                delay(1000);
                if (!getSSIDName()) { StatusERR("GetSSIDName"); return; }
                if (!getWifiPassword()) { StatusERR("GetPassword"); return; }
                delay(1000);
                if (!getCMMAC()) { StatusERR("getCMMAC"); return; }
                delay(1000);
                if (!GetWanMac()) { StatusERR("getCMMAC"); return; }
                delay(1000);
                if (!getMTAMAC()) { StatusERR("getMTAMAC"); return; }
                delay(1000);
                getMACBLE();
                WriteFileLab();
                for (int d = 0; d <= 300; d++)
                {
                    if (thStattus1 == false) return;
                    if (CheckLed_USB == true) break;
                    else
                    {
                        Status4("Wait_USB_C : " + d.ToString());
                        Delay(1000);
                    }
                    if (d >= 200) {
                        ErrorNian("Err_USB_TypeC");
                        return;
                    }
                }
                for (int j = 1; j <= 200; j++)
                {
                    if (nk == true | thStattus1 == false) return;
                    if (AnalysisVoipNian == false) break;
                    Status4("Wating-VOIP: " + j.ToString());
                    delay(1000);
                }
                if (!EnabelEthAll()) { return; }
                if (!EnabelEthAllDHCP()) {return; }
                double TimeEnd1 = GettimeEnd("Infor2");
                Infor2 = CountTime("Infor2", TimeStart1, TimeEnd1);            
                if (!checkPingEth2()) return;
                if (!checkPingEth3()) return;
                if (!checkPingEth4()) return;
                if (!Check_speed("All", "1000")) return;                            
                thMutiple1 = new Thread(new ThreadStart(EthGreen));
                thMutiple1.IsBackground = true;
                thMutiple1.Start();
                for (int d = 0; d <= 300; d++)
                {
                    if (thStattus1 == false) return;
                    if (CheckLed_1000EthPass == true) break;
                    else
                    {
                        Status4("Wait_LED_Green : " + d.ToString());
                        Delay(1000);
                    }
                    if (d > 300) { ErrorNian("Error_LED_Green");
                        return;
                    }
                }
                set_speed_Eth_port("All", "100");
                cmn.openExe1(pathfile1, "disableEthAll");
                delay(1000);
                cmn.openExe1(pathfile1, "enableEthAll");              
                delay(8000);
                //if (!EnabelEthAll()) return;
                if (!Check_speed("All", "100")) return;
                thMutiple1 = new Thread(new ThreadStart(thrled100));
                thMutiple1.IsBackground = true;
                thMutiple1.Start();
                thMutiple4 = new Thread(new ThreadStart(threadZBBLE));
                thMutiple4.IsBackground = true;
                thMutiple4.Start();
                for (int d = 0; d <= 500; d++)
                {
                    if (LockloginWeb == false && dkresetodefoult == false && CheckLed_OnlinePass == true && dkvoipretest == false && disaZigBeePass == true) break;
                    else
                    {
                        if (thStattus1 == false) return;
                        Status4("Wait Check LED - VOIP : " + d.ToString());
                        if (d >= 300)
                        {
                            ErrorNian("Fail LED Online - VOIP");
                            return;
                        }
                        Delay(1000);
                    }
                }
                cmn.openExe1(pathfile1, "disableEthSever");
                if (!WebAutoNian()) { StatusERR("Web_Module"); return; }              
                if (!checkPingMocaMian()) { StatusERR("checkPingMoca"); return;}
                textBox1.Clear();
                c_pingProduct = true;               
                if (!checkPingResetTodefault()) { StatusERR("Reset_To_Default"); return; }
            }
            catch
            {
                //MessageBox.Show("Khoi Dong Lai Program");
            }
            //    delay(200000);
            //}
        }
        private void CkeckLiveSN()
        {

            //if (v_process == 10)
            //{
            //    if (!clickResetByWeb()) { StatusERR("accessWebsiteNewPass"); Status("clickResetByWeb NG"); return; }
            //    Status("clickResetByWeb Done");
            //    StatusSP("Good! -> clickResetByWeb Done-> Pls!NextTest");
            //    geckoWebBrowser1.Visible = false;
            //}
            //   else if (v_process == 1)
            //{
            //    geckoWebBrowser1.Visible = true;
            //    if (!accessWebsite()) { StatusERR("accessWebsite"); Status("clickResetByWeb NG"); return; }
            //    if (!changePasswordWebsite()) { StatusERR("changePasswordWebsite"); Status("clickResetByWeb NG"); return; }
            //    if (!accessWebsiteNewPass()) { StatusERR("accessWebsiteNewPass"); Status("clickResetByWeb NG"); return; }
            //    if (!clickResetByWeb()) { StatusERR("accessWebsiteNewPass"); Status("clickResetByWeb NG"); return; }
            //    Status("clickResetByWeb Done");
            //    StatusSP("Good! -> clickResetByWeb Done-> Pls!NextTest");
            //    geckoWebBrowser1.Visible = false;
            //}
            //else if(v_process > 1)
            //{
            //    geckoWebBrowser1.Visible = true;
            //    if (!accessWebsiteNewPass()) { StatusERR("accessWebsiteNewPass"); Status("clickResetByWeb NG"); return; }
            //    if (!clickResetByWeb()) { StatusERR("accessWebsiteNewPass"); Status("clickResetByWeb NG");return; }
            //    Status("clickResetByWeb Done");
            //    StatusSP("Good! -> clickResetByWeb Done-> Pls!NextTest");
            //    geckoWebBrowser1.Visible = false;
            //}

            if (lbsndut.Text.Length > 10)
            {
                msg("Scan_SN_SFC: YES");
            }
            else
            {
                msg("Scan_SN_SFC: No");
                msg("Scan_SN_SFC: Scan");
                Delay(10000);
                GetSN();
                if (!GetSN())
                {
                    msg("Get SN Fail ");
                    return;
                }
            }                   
        }
        private bool GetWanMac()
        {
            bool a = false;
            bool b = true;
            int c = 1000;
            if (thStattus1 == true)
            {
                cmn.date_TimeStart();
                Status("Get_WAN");
                msg("MIB_Get_WANMAC");
                int count = 0;
                string command = "1.3.6.1.2.1.2.2.1.6.1"; ///1.3.6.1.2.1.2.2.1.6.1
                while (b)
                {
                    if (thStattus1 == false) return false;
                    if (cable.connection(CMip.Trim(), 1, "private", command))
                    {
                        //delay(c);
                        string va = cable.value;
                        va = va.Replace("\r\n", "");
                        va = va.Replace(" ", "");
                        va = va.Trim();
                        Wanmaclable = va;
                        msg("MIB_WANMAC=> " + va);
                        if (lbWanMac.InvokeRequired)
                        {
                            lbWanMac.Invoke(new Action(() => lbWanMac.Text = va));
                            a = true;
                            b = false;
                            return true;
                        }
                        else
                        {
                            lbWanMac.Text = va;
                            a = true;
                            b = false;
                            return true;
                        }
                    }
                    else
                    {
                        c = c + 3000;
                        count++;
                        if (count == 2)
                        {
                            command = "1.3.6.1.4.1.4491.2.1.14.1.5.3.0";
                        }
                        if (count >= 3)
                        {
                            if (PingSreverNian())
                            {
                                ErrorNian("Err_Mib_Wanmac");
                                return false;
                            }
                        }
                        cmn.openExe1(pathfile1, "ResetEthSever");
                        delay(10000);
                    }
                }
            }
            else
            {
                return false;
            }
            return a;
        }
        private bool clickResetByWeb()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            //if (thStattus1 == true)

            Status("clickResetByWeb");         

            msg("clickResetByWeb");
            try
            {
                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            }
            catch { }
            while (b)
            {
                geckoWebBrowser1.Navigate("http://10.0.0.1/restore_reboot.php");
                delay(4000);
                try
                {
                    //if (!checkStatustesting(mt8)) b = false;
                    delay(1000);
                    string va = "";
                    if (geckoWebBrowser1.InvokeRequired)
                    {
                        geckoWebBrowser1.Invoke(new Action(() =>
                        {
                            //btn4
                            GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                            Submit_reset.Click();
                            Submit_reset.Click();
                            Delay(2000);
                            string okclick = "";
                            okclick = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                            GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                            delay(2000);
                            click.Click();
                            delay(60000);
                            msgPass("clickResetByWeb");
                            a = true;
                            b = false;

                        }));
                    }
                    else
                    {
                        GeckoInputElement Submit_reset = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("btn5").DomObject);
                        Submit_reset.Click();
                        Submit_reset.Click();
                        Delay(2000);
                        string okclick = "";
                        okclick = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                        GeckoInputElement click = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                        delay(2000);
                        click.Click();
                        delay(60000);
                        msgPass("clickResetByWeb");
                        a = true;
                        b = false;
                    }

                    //Connection
                    cout++;
                    delay(3000);
                    if (cout > 2)
                    {
                        Status("Er.clickResetByWeb");
                        ErrorNian("ERR_clickResetByWeb");
                        b = false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("clickConnectionWeb:" + ex.Message);
                    cout1++;
                    if (cout1 > 2)
                    {

                        Status("Er.Err_Reset_Wifi");
                        ErrorNian("ERR_clickResetByWeb");
                        b = false;
                    }
                }
            }
            
            return a;
        }
        private void WriteFileLabView(string File, string note)
        {
            string path121 = File;
            string file_path = Labview_part + "\\" + File + ".txt";

            FileStream fs;
            fs = new FileStream(file_path, FileMode.Create);
            StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
            write.WriteLine(note);
            write.Flush();
            fs.Close();
        }
        private void Writemaintain(string RF1, string RF2, string PSU1, string PSU2, string VOIP1, string VOIP2, string Eth1, string Eth2, string Eth3, string Eth4, string USB)
        {
            string value =
                "RF1: " + RF1 + "\n" +
                "RF2: " + RF2 + "\n" +
                "PSU1: " + PSU1 + "\n" +
                "PSU2: " + PSU2 + "\n" +
                "VOIP1: " + VOIP1 + "\n" +
                "VOIP2: " + VOIP2 + "\n" +
                "Eth1: " + Eth1 + "\n" +
                "Eth2: " + Eth2 + "\n" +
                "Eth3: " + Eth3 + "\n" +
                "Eth4: " + Eth4 + "\n" +
            "UBS_Type_C: " + USB;
            string file_path = Directory.GetCurrentDirectory() + "\\" + "maintain.txt";
            FileStream fs;
            fs = new FileStream(file_path, FileMode.Create);
            StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
            write.WriteLine(value);
            write.Flush();
            fs.Close();
        }
        private void WriteCPU(string note)
        {
            string file_path = @"D:\TestStatus.data";
            try
            {
                FileStream fs;
                fs = new FileStream(file_path, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine(note);
                write.Flush();
                fs.Close();
            }
            catch { }
        }
        private void WriteFileLab()
        { 
            string file_path = Labview_part + "\\Information.txt";
            string file_path1 = Labview_part + "\\LengthPassword.txt";
            FileStream fs;
            fs = new FileStream(file_path, FileMode.Create);
            StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
            if (sModem == "CGM4981ROG")
            {
                write.WriteLine("WIFI-" + lbCMMAC.Text.Substring(lbCMMAC.Text.Length - 4, 4));
            }else { write.WriteLine(lbSsid.Text); }
            write.WriteLine(lbwifiPassword.Text);
            write.WriteLine(lbCMMAC.Text);
            write.WriteLine(lbMTAMAC.Text);
            write.WriteLine(lbWanMac.Text);
            write.Flush();
            fs.Close();
            FileStream fs1;
            fs1 = new FileStream(file_path1, FileMode.Create);
            StreamWriter write1 = new StreamWriter(fs1, Encoding.UTF8);
            write1.WriteLine(lbwifiPassword.Text.Length);
            write1.Flush();
            fs1.Close();

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            // sck.Send(Encoding.Default.GetBytes("WAN_IP " + txtMsg.Text));
            telnetSend(txtSever.Text + "\r\n");
        }

        private void timeTest_Tick(object sender, EventArgs e)
        {
            countTimeTest++;
            if (thStattus1 == false) return;
            if (lbTimecc.InvokeRequired)
            {
                lbTimecc.Invoke(new Action(() => lbTimecc.Text = countTimeTest.ToString()));
            }
            else
            {
                lbTimecc.Text = countTimeTest.ToString();  
            }
              
            if (countTimeTest >= 800)
            {
                Status4("Error Time Test 800 seconds");
                msg("Error Time Test 800 seconds ");
                fail("Error Time Test 800 seconds!");
                timStart.Enabled = false;
                timeTest.Enabled = false;             
                Status("Stop Program");
                return;
            }                 
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
        private bool checkCMIPStatus()
        {
            bool a = false;
            bool b = true;
            int count = 0;
            while (b)
            {
                if (getWANMAC1 == true)
                {
                    a = true;
                    b = false;
                }
                delay(1000);
                count++;
                if (count > 100)
                {
                    a = false;
                    b = false;
                }
            }
            return a;
        }
        private void timVoip_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbAudioDevice.InvokeRequired)
        //        {
        //            cmbAudioDevice.Invoke(new Action(() =>
        //            {
        //                value.Add(voip.printListpeakValues(cmbAudioDevice.SelectedItem));
        //            }));

        //        }
        //        else
        //        {
        //            values = voip.printListpeakValues(cmbAudioDevice.SelectedItem);
        //            value.Add(values);
        //        }

        //        if (value.Count >= 150)  //190
        //        {
        //            timVoip.Enabled = false;
        //            msgPass("Analys VOIP");
        //            PlayVoip = false;
        //            voip.PlayStop();
        //            if (noise == true)
        //            {
        //                noise = false;
        //                voipNoiseResult = false;
        //                int noisevalue = 0;
        //                int noisevalue1 = 0;
        //                if (NoiseP1 == true)
        //                {
        //                    //msgnoie("ValueP1");
        //                    foreach (double v in value)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        msg(v.ToString());
        //                        //msgnoie(v.ToString());
        //                        if (v == 0)
        //                        {
        //                            noisevalue++;
        //                        }
        //                        else if (v > noiseVoipCountP1) //noiseVoipCount = int.Parse(lbNoiseCount.Text);
        //                        {
        //                            noisevalue1++;
        //                        }
        //                    }
        //                    if (noisevalue1 > noiseVoipSpect) //noiseVoipSpect = int.Parse(lbNoiseSp.Text); Fail NOISE
        //                    {
        //                        noise = false;
        //                        voipNoiseResult = true;
        //                        msg("Noise_Value_P1: " + noisevalue);
        //                        msg("Noise_Value_Error_P1: " + noisevalue1);
        //                        NoiseResultFAIL = true;
        //                        MoveFileVoip1("nsTest.mp3", "P1toP2", "FAIL", VoiP2P1Again);
        //                        if (VoipAgain == true)
        //                        {
        //                            //ErrorNian("Err_voip_noise_P1");
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        P1P2 = true;
        //                        string noidata = "noisevalue:" + noisevalue + "\r\n" + "noisevalue1:" + noisevalue1;
        //                        noise = false;
        //                        NoiseResultPASS = true;
        //                        voipNoiseResult = true;
        //                        msg("Noise_Value_P1: " + noisevalue);
        //                        msg("Noise_Value_Error_P1: " + noisevalue1);
        //                        msgPass("VoipNoisePass_P1");
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    //msgnoie("\n\nValueP2");
        //                    foreach (double v in value)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        msg(v.ToString());
        //                       // msgnoie(v.ToString());
        //                        if (v == 0)
        //                        {
        //                            noisevalue++;
        //                        }
        //                        else if (v > noiseVoipCountP2) //noiseVoipCount = int.Parse(lbNoiseCount.Text);
        //                        {
        //                            noisevalue1++;
        //                        }
        //                    }
        //                    if (noisevalue1 > noiseVoipSpect) //noiseVoipSpect = int.Parse(lbNoiseSp.Text); Fail NOISE
        //                    {
        //                        noise = false;
        //                        voipNoiseResult = true;
        //                        msg("Noise_Value_P2: " + noisevalue);
        //                        msg("Noise_Value_Error_P2: " + noisevalue1);
        //                        NoiseResultFAIL = true;
        //                        MoveFileVoip1("nsTest.mp3", "P2toP1", "FAIL", VoiP2P1Again);
        //                        if (VoipAgain == true)
        //                        {
        //                            //ErrorNian("Err_voip_noise_P2");
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        P1P2 = true;
        //                        string noidata = "noisevalue:" + noisevalue + "\r\n" + "noisevalue1:" + noisevalue1;
        //                        noise = false;
        //                        NoiseResultPASS = true;
        //                        voipNoiseResult = true;
        //                        msg("Noise_Value_P2: " + noisevalue);
        //                        msg("Noise_Value_Error_P2: " + noisevalue1);
        //                        msgPass("VoipNoisePass_P2");
        //                        return;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                demDup = 0;
        //                msg("Audio Analysing");
        //                int vs = 0, countBiger = 0;
        //                int cou = 0, cou1 = 0, cou2 = 0, cou3 = 0, cou4 = 0, cou5 = 0, cou6 = 0, cou7 = 0, cou8 = 0, cou9 = 0, coutotal = 0;
        //                int d = 0;
        //                for (int i = 0; i < value.Count; i++)
        //                {
        //                    if (thStattus1 == false) return;
        //                    if (i < value.Count - 1)
        //                    {
        //                        if (value[i] <= value[i + 1])
        //                        {
        //                            vs++;
        //                            if (vs == 3)//5
        //                            {
        //                                countBiger++;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            vs = 0;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (txtOutput.InvokeRequired)
        //                        {
        //                            txtOutput.Invoke(new Action(() => txtOutput.AppendText("countBiger=" + countBiger.ToString() + "\r\n")));
        //                        }
        //                        else
        //                        {
        //                            txtOutput.AppendText("countBiger=" + countBiger.ToString() + "\r\n");
        //                        }
        //                    }
        //                }
        //                List<double> analysDup = new List<double>();
        //                List<string> DupCount = new List<string>();
        //                List<int> DupMax = new List<int>();
        //                analysDup = voip.AnalysDup(value);
        //                analysDup.Sort();
        //                foreach (double an in analysDup)
        //                {
        //                    //if (p11 == true)
        //                    //{
        //                    //    msgP1P2(an.ToString());
        //                    //}
        //                    //if (p22 == true)
        //                    //{
        //                    //    msgP2P1(an.ToString());
        //                    //}
        //                    if (thStattus1 == false) return;
        //                    msg(an.ToString());
        //                }
        //                DupCount = voip.AnalysDupCount(analysDup);
        //                if (p11 == true)
        //                {
        //                    foreach (string an in DupCount)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        d = 0;
        //                        demDup++;
        //                        msg(an.ToString()); ///msg("ns:" + v.ToString());                         
        //                        if (an.Contains("total DupValue of" + lbId1.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId2.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou1++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId3.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou2++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId4.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou3++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId5.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou4++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId6.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou5++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId7.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou6++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId8.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou7++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId9.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou8++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbId10.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou9++;
        //                            DupMax.Add(d);
        //                        }
        //                    }
        //                    DupMax.Sort();
        //                    int tt = 0;
        //                    int valuett = 0;
        //                    string valueResult = "";
        //                    for (int i = 0; i < DupMax.Count; i++)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        valuett = DupMax[i];
        //                        if (valuett > 70)
        //                        {
        //                            tt = 1000;
        //                            valueResult = valuett.ToString();
        //                            msg("DupMaxOverSpec:" + valueResult);
        //                            break;
        //                        }
        //                        tt = tt + DupMax[i];
        //                    }
        //                    coutotal = cou + cou1 + cou2 + cou3 + cou4 + cou5 + cou6 + cou7 + cou8 + cou9;
        //                    int max = 0;
        //                    if (DupMax.Count > 0)
        //                    {
        //                        max = DupMax[DupMax.Count - 1];
        //                    }
        //                    double aver = voip.AnalysDupAver(analysDup);
        //                    aver = Math.Round(aver, 1);
        //                    msg("Aver: " + aver.ToString());
        //                    msg("MaxDup: " + tt.ToString());
        //                    msg("wavep1Top2: " + countBiger.ToString());
        //                    msg("Total Dup: " + demDup.ToString());
        //                    averP1 = aver;
        //                    Dup1 = tt;
        //                    waveP1 = countBiger;
        //                    if (minvoice <= aver && aver <= maxvoice && tt >= dupvoice && tt <= 150 && countBiger >= wavep1Top2 & demDup >= 10)
        //                    {
        //                        P1P2 = true;
        //                        string P1P2data = "aver:" + aver + "\r\n" + "dupvoice:" + tt + "\r\n" + "countBiger:" + countBiger;
        //                        // LogFilePassVOIP("Pass", "P1P2.ini", P1P2data);
        //                        msg("P1CallP2");
        //                        msgPass("P1CallP2");
        //                        //MoveFileVoip("AudioTest.mp3", "P1toP2", "PASS", VoiP1P2Again);
        //                        demDup = 0;
        //                        p11 = false;
        //                        analysDup.Clear();
        //                        return;
        //                        // LogFile("pass");
        //                    }
        //                    else
        //                    {
        //                        analysDup.Clear();
        //                        VoiP1P2Again++;
        //                        //if (tt < 10 && aver > 10 && VoiP1P2Again == 1)
        //                        //{
        //                        //    MessageBox.Show("Kiem Tra Lai So Dien Thoai.Pls!");
        //                        //    VoiP1P2Againtest = false;
        //                        //    return;
        //                        //}
        //                        MoveFileVoip1("AudioTest.mp3", "P1toP2", "Fail", VoiP1P2Again);
        //                        msg("VoiP1P2Again:" + VoiP1P2Again.ToString());
        //                        VoiP1P2Againtest = false;
        //                        if (VoiP1P2Again == 2 & VoipAgain == true & thStattus1 == true)
        //                        {
        //                            mt1 = "Checking";
        //                            VoiP1P2Againtest = false;
        //                            msg("->  Total Dup:  " + demDup.ToString() + "/Target >= 10");
        //                            //minvoice <= aver && aver <= maxvoice && tt >= dupvoice && tt <= 150 && countBiger >= wavep1Top2 & demDup >= 10
        //                            if (minvoice > aver & demDup < 10 & tt < 10)// Loi khong nhan dk am thanh
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P1ToP2_00");
        //                                return;
        //                            }
        //                            else if (minvoice > aver)// nho hon gia tri tb
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P1ToP2_Min");
        //                                return;
        //                            }
        //                            else if (maxvoice < aver)// lon hon gia tri tb
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P1ToP2_Max");
        //                                return;
        //                            }
        //                            else if (minvoice1 <= aver && aver <= maxvoice1)
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P1ToP2_OutDup");
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P1ToP2_Other");
        //                                return;
        //                            }
        //                            voice1Stop = true;
        //                            p11 = false;
        //                        }
        //                    }
        //                }
        //                else if (p22 == true)
        //                {
        //                    foreach (string an in DupCount)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        demDup++;
        //                        d = 0;
        //                        msg(an.ToString()); ///msg("ns:" + v.ToString());
        //                        if (an.Contains("total DupValue of" + lbid11.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid12.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou1++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid13.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou2++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid14.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou3++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid15.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou4++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid16.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou5++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid17.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou6++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid18.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou7++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid19.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou8++;
        //                            DupMax.Add(d);
        //                        }
        //                        if (an.Contains("total DupValue of" + lbid20.Text + ":"))
        //                        {
        //                            string o = an.Substring(20, an.Length - 20);
        //                            d = Convert.ToInt16(o);
        //                            cou9++;
        //                            DupMax.Add(d);
        //                        }
        //                    }
        //                    DupMax.Sort();
        //                    int tt = 0;
        //                    for (int i = 0; i < DupMax.Count; i++)
        //                    {
        //                        if (thStattus1 == false) return;
        //                        tt = tt + DupMax[i];
        //                    }
        //                    coutotal = cou + cou1 + cou2 + cou3 + cou4 + cou5 + cou6 + cou7 + cou8 + cou9;
        //                    int max = 0;
        //                    if (DupMax.Count > 0)
        //                    {
        //                        max = DupMax[DupMax.Count - 1];
        //                    }
        //                    double aver = voip.AnalysDupAver(analysDup);
        //                    aver = Math.Round(aver, 1);
        //                    msg("Aver: " + aver.ToString());
        //                    msg("MaxDup: " + tt.ToString());
        //                    msg("wavep1Top2: " + countBiger.ToString());
        //                    msg("Total Dup: " + demDup.ToString());                          
        //                    averP2 = aver;
        //                    Dup2 = tt;
        //                    waveP2 = countBiger;
        //                    if (minvoice1 <= aver && aver <= maxvoice1 && tt >= dupvoice1 && tt <= 150 && countBiger >= wavep2Top1 && demDup >= 10)
        //                    {
        //                        analysDup.Clear();
        //                        string P1P2data = "aver:" + aver + "\r\n" + "dupvoice:" + tt + "\r\n" + "countBiger:" + countBiger;
        //                        // LogFilePassVOIP("Pass", "P2P1.ini", P1P2data);
        //                        msg("P2CallP1");
        //                        msgPass("P2CallP1");
        //                        ///MoveFileVoip("AudioTest.mp3", "P2toP1", "PASS", VoiP2P1Again);
        //                        p22 = false;
        //                        noise = true;
        //                        voipfunction = true;
        //                        P1P2 = true;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        analysDup.Clear();
        //                        VoiP2P1Again++;
        //                        MoveFileVoip1("AudioTest.mp3", "P2toP1", "Fail", VoiP2P1Again);
        //                        msg("VoiP2P1Again:" + VoiP2P1Again.ToString());
        //                        VoiP2P1Againtest = false;
        //                        if (VoiP2P1Again == 2 & VoipAgain == true & thStattus1 == true)
        //                        {
        //                            mt1 = "Checking";
        //                            VoiP2P1Againtest = false;
        //                            msg("->  Total Dup2:  " + demDup.ToString() + "/Target >= 10");                                  
        //                            if (minvoice > aver & demDup < 10 & tt < 10)
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P2ToP1_00");
        //                                return;
        //                            }
        //                            else if (minvoice > aver)// nho hon gia tri tb
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P2ToP1_Min");
        //                                return;
        //                            }
        //                            else if (maxvoice < aver)// lon hon gia tri tb
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P2ToP1_Max");
        //                                return;
        //                            }
        //                            else if (minvoice1 <= aver && aver <= maxvoice1)
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P2ToP1_OutDup");
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                DKVOIP1 = true;
        //                                ErrorNian("Err_Voip_P2ToP1_Other");
        //                                return;
        //                            }
        //                            p22 = false;
        //                            voice2Stop = true;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //        //  MessageBox.Show("timVoip Analys:" + ex.Message);
        //    }       
        //}
        { }
        private void AnalysisVoip(string key)////timVoip_Tick(object sender, EventArgs e)
        {
            try
            {
                while (true)
                {
                    if (cmbAudioDevice.InvokeRequired)
                    {
                        cmbAudioDevice.Invoke(new Action(() =>
                        {
                            value.Add(voip.printListpeakValues(cmbAudioDevice.SelectedItem));
                            delay(15);
                        }));

                    }
                    else
                    {
                        value.Add(voip.printListpeakValues(cmbAudioDevice.SelectedItem));
                        delay(15);
                    }
                    if (value.Count >= 150) break;
                }
                if (value.Count >= 150)  //190
                {
                    AnalysisVoipNian = false;
                    if (thStattus1 == false) return;
                    //timVoip.Enabled = false;
                    msgPass("Analysis VOIP");
                    voip.PlayAudioStop();
                    voip.PlayStop();
                    if (key.Contains("noise"))
                    {                    
                        noise = false;
                        voipNoiseResult = false;
                        int noisevalue1 = 0;
                        foreach (double v in value)
                        {
                            if (thStattus1 == false) return;
                            msg(v.ToString());
                            if (v > noiseVoipCount)
                            {
                                noisevalue1++;
                            }
                        }
                        if (noisevalue1 > noiseVoipSpect)
                        {
                            MoveFileVoip1("nsTest.mp3", "", "FAIL", VoiP2P1Again);
                            VoipAgain = true;
                            mt1 = "Checking";
                            voipNoiseResult = true;
                            msg("Noise_Value_Error: " + noisevalue1);
                            NoiseResultFAIL = true;
                            if (VoipAgain == true)
                            {
                                //ErrorNian("Err_voip_noise");
                                return;
                            }
                        }
                        else
                        {
                            NoiseResultPASS = true;
                            voipNoiseResult = true;
                            msg("Noise_Value_Error: " + noisevalue1);
                            msgPass("VoipNoisePass");
                            VoiPNoise = true;
                            return;
                        }
                    }
                    else
                    {
                        demDup = 0;
                        msg("Audio Analysing");
                        int vs = 0, countBiger = 0;
                        int cou = 0, cou1 = 0, cou2 = 0, cou3 = 0, cou4 = 0, cou5 = 0, cou6 = 0, cou7 = 0, cou8 = 0, cou9 = 0, coutotal = 0;
                        int d = 0;
                        for (int i = 0; i < value.Count; i++)
                        {
                            if (thStattus1 == false) return;
                            if (i < value.Count - 1)
                            {
                                if (value[i] <= value[i + 1])
                                {
                                    vs++;
                                    if (vs == 3)//5
                                    {
                                        countBiger++;
                                    }
                                }
                                else
                                {
                                    vs = 0;
                                }
                            }
                            else
                            {
                                msg("countBiger=" + countBiger.ToString());
                            }
                        }
                        List<double> analysDup = new List<double>();
                        List<string> DupCount = new List<string>();
                        List<int> DupMax = new List<int>();
                        analysDup = voip.AnalysDup(value);
                        analysDup.Sort();
                        foreach (double an in analysDup)
                        {
                            //if (p11 == true)
                            //{
                            //    msgP1P2(an.ToString());
                            //}
                            //if (p22 == true)
                            //{
                            //    msgP2P1(an.ToString());
                            //}
                            msg(an.ToString());
                        }
                        DupCount = voip.AnalysDupCount(analysDup);
                        if (key.Contains("VOIP1"))
                        {
                            foreach (string an in DupCount)
                            {
                                d = 0;
                                demDup++;
                                msg(an.ToString()); ///msg("ns:" + v.ToString());                         
                                if (an.Contains("total DupValue of" + lbId1.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId2.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou1++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId3.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou2++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId4.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou3++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId5.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou4++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId6.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou5++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId7.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou6++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId8.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou7++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId9.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou8++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbId10.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou9++;
                                    DupMax.Add(d);
                                }
                            }
                            DupMax.Sort();
                            int tt = 0;
                            int valuett = 0;
                            string valueResult = "";
                            for (int i = 0; i < DupMax.Count; i++)
                            {
                                valuett = DupMax[i];
                                if (valuett > 70)
                                {
                                    tt = 1000;
                                    valueResult = valuett.ToString();
                                    msg("DupMaxOverSpec:" + valueResult);
                                    break;
                                }
                                tt = tt + DupMax[i];
                            }
                            coutotal = cou + cou1 + cou2 + cou3 + cou4 + cou5 + cou6 + cou7 + cou8 + cou9;
                            int max = 0;
                            if (DupMax.Count > 0)
                            {
                                max = DupMax[DupMax.Count - 1];
                            }
                            double aver = voip.AnalysDupAver(analysDup);
                            aver = Math.Round(aver, 1);
                            msg("Aver: " + aver.ToString());
                            msg("MaxDup: " + tt.ToString());
                            msg("Wavep1Top2: " + countBiger.ToString());
                            msg("Total Dup: " + demDup.ToString());
                            averP1 = aver;
                            Dup1 = tt;
                            waveP1 = countBiger;
                            if (minvoice <= aver && aver <= maxvoice && tt >= dupvoice && tt <= 150 && countBiger >= wavep1Top2 & demDup >= 10)
                            {
                                VoiP1Pass = true;
                                msg("P1CallP2");
                                msgPass("P1CallP2");
                                demDup = 0;
                                analysDup.Clear();
                                return;
                            }
                            else
                            {
                                analysDup.Clear();
                                VoiP1P2Again++;
                                MoveFileVoip1("AudioTest.mp3", "P1toP2", "Fail", VoiP1P2Again);
                                msg("VoiP1P2Again:" + VoiP1P2Again.ToString());
                                if (VoiP1P2Again >= 2 & VoipAgain == true)
                                {
                                    msg("->  Total Dup:  " + demDup.ToString() + "/Target >= 10");
                                    if (minvoice > aver & demDup < 10 & tt < 10)// Loi khong nhan dk am thanh
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P1ToP2_00");
                                        return;
                                    }
                                    else if (minvoice > aver)// nho hon gia tri tb
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P1ToP2_Min");
                                        return;
                                    }
                                    else if (maxvoice < aver)// lon hon gia tri tb
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P1ToP2_Max");
                                        return;
                                    }
                                    else if (minvoice1 <= aver && aver <= maxvoice1)
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P1ToP2_OutDup");
                                        return;
                                    }
                                    else
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P1ToP2_00");
                                        return;
                                    }
                                }
                            }
                        }
                        else if (key.Contains("VOIP2"))
                        {
                            foreach (string an in DupCount)
                            {
                                if (thStattus1 == false) return;
                                demDup++;
                                d = 0;
                                msg(an.ToString()); ///msg("ns:" + v.ToString());
                                if (an.Contains("total DupValue of" + lbid11.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid12.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou1++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid13.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou2++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid14.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou3++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid15.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou4++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid16.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou5++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid17.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou6++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid18.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou7++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid19.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou8++;
                                    DupMax.Add(d);
                                }
                                if (an.Contains("total DupValue of" + lbid20.Text + ":"))
                                {
                                    string o = an.Substring(20, an.Length - 20);
                                    d = Convert.ToInt16(o);
                                    cou9++;
                                    DupMax.Add(d);
                                }
                            }
                            DupMax.Sort();
                            int tt = 0;
                            for (int i = 0; i < DupMax.Count; i++)
                            {
                                if (thStattus1 == false) return;
                                tt = tt + DupMax[i];
                            }
                            coutotal = cou + cou1 + cou2 + cou3 + cou4 + cou5 + cou6 + cou7 + cou8 + cou9;
                            int max = 0;
                            if (DupMax.Count > 0)
                            {
                                max = DupMax[DupMax.Count - 1];
                            }
                            double aver = voip.AnalysDupAver(analysDup);
                            aver = Math.Round(aver, 1);
                            msg("Aver: " + aver.ToString());
                            msg("MaxDup: " + tt.ToString());
                            msg("Wavep2Top1: " + countBiger.ToString());
                            msg("Total Dup: " + demDup.ToString());       
                            averP2 = aver;
                            Dup2 = tt;
                            waveP2 = countBiger;
                            if (minvoice1 <= aver && aver <= maxvoice1 && tt >= dupvoice1 && tt <= 150 && countBiger >= wavep2Top1 && demDup >= 10)
                            {
                                analysDup.Clear();
                                string P1P2data = "aver:" + aver + "\r\n" + "dupvoice:" + tt + "\r\n" + "countBiger:" + countBiger;
                                msg("P2CallP1");
                                msgPass("P2CallP1");
                                VoiP2Pass = true;
                                return;
                            }
                            else
                            {
                                analysDup.Clear();
                                VoiP2P1Again++;
                                MoveFileVoip1("AudioTest.mp3", "P2toP1", "Fail", VoiP2P1Again);
                                msg("VoiP2P1Again:" + VoiP2P1Again.ToString());
                                if (VoiP2P1Again >= 2 & VoipAgain == true)
                                {
                                    mt1 = "Checking";
                                    msg("->  Total Dup2:  " + demDup.ToString() + "/Target >= 10");
                                    //minvoice <= aver && aver <= maxvoice && tt >= dupvoice && tt <= 150 && countBiger >= wavep1Top2 & demDup >= 10
                                    if (minvoice > aver & demDup < 10 & tt < 10)// Loi khong nhan dk am thanh
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P2ToP1_00");
                                        return;
                                    }
                                    else if (minvoice > aver)// nho hon gia tri tb
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P2ToP1_Min");
                                        return;
                                    }
                                    else if (maxvoice < aver)// lon hon gia tri tb
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P2ToP1_Max");
                                        return;
                                    }
                                    else if (minvoice1 <= aver && aver <= maxvoice1)
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P2ToP1_OutDup");
                                        return;
                                    }
                                    else
                                    {
                                        DKVOIP1 = true;
                                        ErrorNian("Err_Voip_P2ToP1_00");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void MoveFileVoip1(string Namepart, string port, string PassFail, int time)
        {
            string timedata = DateTime.Now.Hour.ToString() + "h" + DateTime.Now.Minute.ToString() + "p"+DateTime.Now.Second.ToString() + "s";
            string path = Directory.GetCurrentDirectory();
            string directoryPath = "D:\\LogFileVOIP";
            string SNDUT = "";
            if (lbsndut.InvokeRequired)
            {
                lbsndut.Invoke(new Action(() => SNDUT = lbsndut.Text));
            }
            else
            {
                SNDUT = lbsndut.Text;
            }
            string fileNewname = SNDUT + port + PassFail + timedata + Namepart;
            string sourcepathFile = path;
            try
            {
                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                }
                string sourceFile = System.IO.Path.Combine(sourcepathFile, Namepart);
                string destFile = System.IO.Path.Combine(directoryPath, fileNewname);
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch
            {
                MessageBox.Show("MoveFile-->FAIL");
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
                cmn.kill("XLAXB8");
                cmn.kill("cmd");
                cmn.kill("msedge");
               // cmn.kill("conhost");
                try
                {
                    stream_SFC.Close();
                    socket_SFC.Close();
                    listener_SFC.Stop();
                }
                catch { }
                //cmn.kill("Automatic");
                System.Environment.Exit(0);
            }
            // serial.Dispose();
        }

        private void timStart_Tick(object sender, EventArgs e)
        {
           delay(100);
           while(txtComFB.Text.Contains("Dong") | txtComFB.Text.Contains("CLOSE_OK") & timS == true)
            {
                timS = false;
                txtComFB.Clear();
                testing();
            }           
        }

        private void stopProgramingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg("Error_Stop_Program!");
            Status4("Error_Stop_Program");
            fail("Error_Stop_Program!");
            timStart.Enabled = false;
            timeTest.Enabled = false;
            return;
        }

        private void StopPGram()
        {
            timStart.Enabled = false;
            timeTest.Enabled = false;
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
            delay(200);
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

                if (!checkStatustesting(mt8)) b = false;
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
        private bool accessWebsiteCOX()
        {
            PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            int count2 = 0;
            int ct = 0;
            idpass = 0;
            bool h = false;
            bool k1 = true;
            accessWebsitePass = false;            
            if (thStattus1 == true)
            {
                Status("accessWebsite");
                msg("accessWebsite");               
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                for (int i = 0;i <= 25;i++)
                {
                    geckoWebBrowser1.Navigate("about:blank");
                    geckoWebBrowser1.Document.Cookie = "";
                    geckoWebBrowser1.Document.DocumentElement.TextContent = "";
                    geckoWebBrowser1.Navigate("http://192.168.0.1");
                    delay(5000);
                    if (!WaitLog("Login - Cox", "Login - Cox"))
                    {                       
                        if (i >= 24)
                        {
                            MessageBox.Show("san pham chua khoi dong thanh cong");
                            msg("san pham chua khoi dong thanh cong");                                                   
                            return a;
                        }                     
                    }
                    else { break;}
                }            
                b = true;
                while (b)
                {
                    try
                    {
                        {
                            if (!checkStatustesting(mt8)) b = false;
                            string va = "";
                            if (geckoWebBrowser1.InvokeRequired)
                            {
                                geckoWebBrowser1.Invoke(new Action(() =>
                                {
                                    va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                    msg(va);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                                    geckinputelement.Value = "admin";
                                    delay(100);
                                    msg("user:" + geckinputelement.Value);
                                }));

                            }
                            else
                            {

                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                                geckinputelement.Value = "admin";
                                delay(100);
                                msg("user:" + geckinputelement.Value);

                            }
                            if (geckoWebBrowser1.InvokeRequired)
                            {
                                geckoWebBrowser1.Invoke(new Action(() =>
                                {

                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                                    geckinputelement.Value = "password";
                                    delay(100);
                                    msg("password:" + geckinputelement.Value);
                                    Gecko.GeckoElementCollection geckoElementCollection = geckoWebBrowser1.Document.GetElementsByTagName("input");
                                    delay(200);
                                    foreach (Gecko.GeckoElement geckoElement in geckoElementCollection)
                                    {
                                        bool k = false;
                                        if (geckoElement.GetAttribute("type").Equals("submit"))
                                        {
                                            ((Gecko.GeckoHtmlElement)geckoElement).Click();

                                            delay(1500);
                                            msgPass("accessWebsite");
                                            accessWebsitePass = true;
                                            a = true;
                                            b = false;
                                            break;
                                            try
                                            {
                                                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                                            }
                                            catch { }

                                            if (a == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }));
                            }
                            else
                            {

                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                                geckinputelement.Value = "password";
                                delay(100);
                                Gecko.GeckoElementCollection geckoElementCollection = geckoWebBrowser1.Document.GetElementsByTagName("input");

                                foreach (Gecko.GeckoElement geckoElement in geckoElementCollection)
                                {
                                    bool k = false;
                                    if (geckoElement.GetAttribute("type").Equals("submit"))
                                    {
                                        ((Gecko.GeckoHtmlElement)geckoElement).Click();
                                        delay(1500);
                                        msgPass("accessWebsite");
                                        accessWebsitePass = true;
                                        a = true;
                                        b = false;
                                        break;
                                        try
                                        {
                                            PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                                        }
                                        catch { }


                                        if (a == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            /* cout++;

                             if (cout > 50)
                             {
                                 mt8 = "Checking";
                                 Status("");
                                 //fail("");
                                 fail(err.Err_Web_AccessFirst);
                                 b = false;
                             }*/
                        }
                    }
                    catch (Exception ex)
                    {
                        cout1++;
                        delay(1000);
                        geckoWebBrowser1.Navigate("http://192.168.0.1");
                        delay(5000);
                        if (cout1 > 3)
                        {
                            Status("Web_AccessFirst");
                            ErrorNian(err.Err_Web_AccessFirst + "EX:" + ex.Message);
                            b = false;
                        }
                    }
                }
                
            }
            else
            {
                Status("Setup.Web_AccessFirst");              
                thStattus2 = false;
                
            }
            return a;
        }      

      
        bool DK_VOIP_HOAyi;
    
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
      
      
        private bool ConfigSSIDPassword()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            geckoWebBrowser1.Navigate("about:blank");
            geckoWebBrowser1.Document.Cookie = "";
            geckoWebBrowser1.Document.Cookie.Clone();
            delay(1000);
            try
            {
                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
            }
            catch { }
            if (thStattus1 == true)
            {
                Status("Config_SSID_Password...");
                msg("login_Website_Config_SSID_Password");
                geckoWebBrowser1.Navigate(linkWeb);
                for (int n = 0; n <= 45; n++)
                {
                    if (WaitLog(DocumentTitleWEBSSID1, DocumentTitleWEBSSID2))
                    {
                        delay(1000);
                        break;
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
                for (int c = 1; c <= 8; c++)
                {
                    try
                    {
                        msg("Config_SSID_Password: "+ c);
                        string va = "";
                        va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                        if (WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                        {
                            a = true;
                            b = false;
                            msg("Warning! => Don't config SSID_Password!!!");
                            return true;
                        }
                        else if (va.Contains("get_set_up"))
                        {                          
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                            geckinputelement.Click();
                            for (int u = 0; u <= 20; u++)
                            {
                                try
                                {
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Name").DomObject);
                                    geckinputelement.Value = "admin";
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Password").DomObject);
                                    geckinputelement.Value = "password";
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next").DomObject);
                                    geckinputelement.Click();
                                    for (int u1 = 0; u1 <= 20; u1++)
                                    {
                                        try
                                        {
                                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next_01").DomObject);
                                            geckinputelement.Click();
                                            for (int i = 0; i < 25; i++)
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
                                                }
                                                else if (y == 20)
                                                {
                                                    geckoWebBrowser1.Navigate(linkWeb);
                                                    delay(3000);
                                                }
                                                else if (y >= 30)
                                                {
                                                    if (c == 2)
                                                    {
                                                        ErrorNian("Err_config_SSID_Password");
                                                        return false;
                                                    }
                                                    geckoWebBrowser1.Navigate(linkWeb);
                                                    delay(3000);
                                                    break;
                                                }
                                                delay(1000);
                                            }
                                            break;
                                        }
                                        catch { delay(500); }
                                    }
                                    break;
                                }
                                catch { delay(500); }
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
            }
            else
            {
                a = false;
                return false;
            }
            return a;
        }
        private bool loginWebsiteSHW()
        {
            //mt8 = "qeqqew";
            bool a = false;
            int b = 0;
            int cout = 0;
            int cout1 = 0;
            int count = 0;
            bool j = true;
            if (thStattus1 == true)
            {
                Status("loginWebsite");
                msg("loginWebsite");
                bool p = true;
                int p1 = 0;
                if (!checkStatustesting(mt8)) { mt8 = "Checking"; return a; }
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                int u = 0;
                for (int i = 0; i <= 5; i++)
                {
                    geckoWebBrowser1.Navigate("about:blank");
                    geckoWebBrowser1.Document.Cookie = "";
                    geckoWebBrowser1.Navigate("linkWeb");
                    delay(18000);
                    if (WaitLog("SHAW Smart Internet", "Login - Shaw"))
                    {
                        break;                       
                    }
                    else
                    {
                        if (i >= 4)
                        {
                            MessageBox.Show("san pham chua khoi dong thanh cong");
                            msg("san pham chua khoi dong thanh cong");
                            ErrorNian("Err_config_SSID_Password");
                            return a;
                        }
                    }
                }          
                while (b < 4)
                {
                    string va = "";
                    b++;
                    try
                    {
                        if (!checkStatustesting(mt8)) { mt8 = "Checking"; b = 5; }                       
                        if (geckoWebBrowser1.InvokeRequired)
                        {
                            geckoWebBrowser1.Invoke(new Action(() =>
                            {                            
                                va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                if ((va.Contains("username")))
                                {                                  
                                    // Login fail
                                    a = true;
                                    msg("Use Page Next __loginWebsite_CAP");
                                    msgPass("Warning! loginWebsite_CAP");
                                    //////    //msgPass("loginWebsite");
                                    //////    //a = true;
                                    notes = "LOGINUSEPAGE";
                                    b = 5;
                                }
                                else if (va.Contains("get_set_up"))
                                {
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                                    //GeckoInputElement savePass = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                                    delay(500);
                                    geckinputelement.Click();
                                    delay(1000);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Name").DomObject);
                                    geckinputelement.Value = "admin1" + idpass.ToString();
                                    delay(200);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Password").DomObject);
                                    geckinputelement.Value = "password3" + idpass.ToString();
                                    delay(200);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next").DomObject);
                                    delay(200);
                                    geckinputelement.Click();
                                    delay(1000);
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next_01").DomObject);
                                    delay(200);
                                    geckinputelement.Click();
                                    delay(1000);
                                    for (int i = 0; i < 30; i++)
                                    {
                                        Status("Wait Setup Wifi Web: " + i.ToString());
                                        Delay(1000);
                                    }
                                    delay(1000);
                                    geckoWebBrowser1.Navigate("http://10.0.0.1");
                                    delay(3000);
                                    a = true;
                                    b = 5;
                                    msgPass("loginWebsite_CAP");
                                }

                            }));
                        }
                        else
                        {
                            va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                            if ((va.Contains("username")))
                            {

                                a = true;
                                msg("Use Page Next __loginWebsite_CAP");
                                msgPass("Warning! loginWebsite_CAP");
                                notes = "LOGINUSEPAGE";
                                b = 5;
                            }
                            if (va.Contains("get_set_up"))
                            {
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                                delay(200);
                                geckinputelement.Click();
                                delay(1000);
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Name").DomObject);
                                geckinputelement.Value = "admin1" + idpass.ToString();
                                delay(200);
                                msg(va);
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Password").DomObject);
                                geckinputelement.Value = "password3" + idpass.ToString();
                                delay(200);
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next").DomObject);
                                delay(200);
                                geckinputelement.Click();
                                delay(1000);
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next_01").DomObject);
                                delay(200);
                                geckinputelement.Click();
                                delay(1000);
                                for (int i = 0; i < 28; i++)
                                {
                                    Status("Wait Setup Wifi Web: " + i.ToString());
                                    Delay(1000);
                                }
                                delay(1000);
                                geckoWebBrowser1.Navigate("http://10.0.0.1");
                                delay(3000);
                                a = true;
                                b = 5;
                                msgPass("loginWebsite_CAP");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        b = b - 1;
                        cout1++;
                        delay(1000);
                        geckoWebBrowser1.Visible = true;
                        geckoWebBrowser1.Navigate("about:blank");
                        geckoWebBrowser1.Document.Cookie = "";
                        geckoWebBrowser1.Navigate("http://10.0.0.1");
                        delay(15000);
                        va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                        if ((va.Contains("username")))
                        {

                            a = true;
                            msg("Use Page Next __loginWebsite_CAP");
                            msgPass("Warning! loginWebsite_CAP");
                            //////    //msgPass("loginWebsite");
                            //////    //a = true;
                            notes = "LOGINUSEPAGE";
                            b = 5;
                        }                      
                        if (va.Contains("get_set_up"))
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("get_set_up").DomObject);
                            delay(1000);
                            geckinputelement.Click();
                            delay(1000);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Name").DomObject);
                            geckinputelement.Value = "admin1" + idpass.ToString();
                            delay(1000);
                            msg(va);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("WiFi_Password").DomObject);
                            geckinputelement.Value = "password3" + idpass.ToString();
                            delay(1000);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next").DomObject);
                            delay(1000);
                            geckinputelement.Click();
                            delay(1000);
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("button_next_01").DomObject);
                            delay(1000);
                            geckinputelement.Click();
                            delay(1000);
                            for (int i = 0; i < 28; i++)
                            {
                                Status("Wait Setup Wifi Web: " + i.ToString());
                                Delay(1000);
                            }
                            delay(1000);
                            geckoWebBrowser1.Navigate("http://10.0.0.1");
                            delay(3000);
                            a = true;
                            b = 5;
                            msgPass("loginWebsite_CAP");
                        }
                        if (cout1 > 250)
                        {

                            Status("Web_get_set_up");
                            ErrorNian(err.Err_Web_LoginFirst);
                            //MessageBox.Show("LoginWeb:" + ex.Message);
                            msg("Exception: LoginWeb:" + ex.Message);
                            b = 10;
                        }
                    }

                }
                
            }
            else
            {
                Status("Setup.Web_get_set_up");
                
            }
            return a;
        }
        private bool loginWebsiteCheckCap()
        {
            bool a = false;
            int b = 0;
            int cout = 0;
            int cout1 = 0;
            int count = 0;
            bool j = true;
           // thStattus1 = true;
            if (thStattus1 == true)
            {
                Status("loginWebsite");
                msg("loginWebsite");
                bool p = true;
                int p1 = 0;
                if (!checkStatustesting(mt8)) { mt8 = "Checking"; return a; }
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                int u = 0;
                geckoWebBrowser1.Visible = true;
                geckoWebBrowser1.Navigate("about:blank");
                geckoWebBrowser1.Document.Cookie = "";
                geckoWebBrowser1.Navigate("http://10.0.0.1");
                delay(2000);
                geckoWebBrowser1.Navigate("http://10.0.0.1");
                Delay(4000);
                string vcap = Check_Cap("XFINITY Smart Internet", "Login - XFINITY");
                if (vcap.Contains("Not"))
                {
                    msg("FWEB01");
                    //MessageBox.Show("San pham chua khoi dong xong");
                    return a;
                }
                else if (vcap.Contains("Cap"))
                {
                    msg("Login_Web_Cap_Pass");
                    a = true;
                    Status("Login_Web_Cap_Pass");
                    return a;
                }
                else
                {
                    msg("FWEB00");
                    Status("FWEB00");
                   
                    a = false;
                }
                
            }
            else
            {
                Status("Setup.Web_get_set_up");
                
            }
            return a;
        }
        private bool LoginWEBFirst()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            int cout2 = 0;
            string dd = "";
            accessWebsiteNewPassCon = false;
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
                            try
                            {
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                                msg("Old_user: admin");
                                msg("Old_Password: password");
                                string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                msg(va);
                                break;
                            }
                            catch { delay(1000); }
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
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                        geckinputelement.Value = "admin";
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                        geckinputelement.Value = "password";
                        //delay(500);
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        for (int o = 0; o <= 15; o++)
                        {
                            try
                            {                               
                                geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                geckinputelement.Click();
                                for (int c = 0; c <= 20; c++)
                                {
                                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebChangePassword))
                                    {
                                        Dklognewpassword = true;
                                        r = 100;
                                        break;
                                    }
                                    else
                                    {
                                        delay(500);
                                    }
                                }
                                break;
                            }
                            catch
                            {
                                dd = "";
                                if (r >= 1)
                                {
                                    if (WaitWeb1(DocumentTitleWEBSSID2))
                                    {
                                        Dklognewpassword = false;
                                        msg("Login_Change_password");
                                        ////ErrorNian("Login_With_Old_Password");
                                        b = false;
                                        r = 100;
                                       // break;
                                        return true;
                                        //msg("Warning! Error Change new password => Try login with new password");
                                        //return true;
                                    }
                                }
                                delay(1000);
                            }
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
                        for (int o = 0; o <= 30; o++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb))
                            {
                                try
                                {
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                                    break;
                                }
                                catch { delay(1000);}
                            }
                        }
                    }
                }
                for (int n = 0; n <= 40; n++)
                {
                    try
                    {
                        //geckoWebBrowser1.Navigate(linkWebChangePassword);
                        //delay(1000);
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebChangePassword) & WaitWeb1("Change Password"))
                        {
                            msgPass("Login_Old_Password");
                            msg("New_Password: password2");
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("oldPassword").DomObject);
                            geckinputelement.Value = "password";
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("userPassword").DomObject);
                            geckinputelement.Value = "password2";
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("verifyPassword").DomObject);
                            geckinputelement.Value = "password2";
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_pwd").DomObject);
                            geckinputelement.Click();
                            for (int o1 = 0; o1 <= 30; o1++)
                            {
                                try
                                {
                                    //GeckoInputElement ss = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_message").DomObject);
                                    //string bug = ss.TextContent; //"Changes saved successfully"
                                    geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("popup_ok").DomObject);
                                    geckinputelement.Click();
                                    //if (bug.Contains("Changes saved successfully") | bug.Contains("Password"))
                                    //{
                                    delay(3000);
                                    msgPass("Change_New_Pasword");
                                    return true;
                                    //}
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
                            geckoWebBrowser1.Navigate(linkWebChangePassword);
                            for (int o = 0; o <= 30; o++)
                            {
                                if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebChangePassword))
                                {
                                    try
                                    {
                                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("oldPassword").DomObject);
                                        break;
                                    }
                                    catch { delay(1000); }
                                }
                            }
                            delay(1000);
                        }
                        else
                        {
                            if (n == 20)
                            {
                                geckoWebBrowser1.Navigate(linkWebChangePassword);
                                delay(1000);
                            }
                            if (n == 40)
                            {
                                Status("Login_Save_New_Password");
                                ErrorNian("Login_With_Old_Password");
                                b = false;
                                return false;
                            }
                            delay(1000);
                        }
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
                        delay(1000);
                    }
                }
            }
            else
            {
                Status("Err_Login_With_Old_Password");
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
                for (int n = 0; n <= 45; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                    {
                        try
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                            msg("Old_user: admin");
                            msg("Old_Password: password2");
                            string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                            msg(va);
                            break;
                        }
                        catch { delay(1000); }
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
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        for (int p = 0; p <= 35; p++)
                        {
                            if (cout2 == 3)
                            {
                                ErrorNian("Err_login_Web_New_Password");
                                b = false;
                                return false;
                            }
                            else
                            {
                                if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb1) & WaitWeb1("Gateway"))
                                {
                                    msgPass("LoginWithNewPassword");
                                    a = true;
                                    b = false;
                                    return true;
                                }
                                else if (p == 30)
                                {
                                    geckoWebBrowser1.Navigate(linkWeb);
                                    delay(5000);
                                    break;
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
        private bool LoginWithNewPassword1()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            int cout2 = 1;
            if (thStattus1 == true)
            {
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                geckoWebBrowser1.Navigate(linkWeb);
                for (int n = 0; n <= 45; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                    {
                        try
                        {
                            geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
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
                    if (cout2 >=3)
                    {
                        return false;
                    }
                    try
                    {
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("username").DomObject);
                        geckinputelement.Value = "admin";
                        geckinputelement = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("password").DomObject);
                        geckinputelement.Value = "password2";
                        geckoWebBrowser1.Document.GetElementsByTagName("input")[2].Click();
                        for (int p = 0; p <= 35; p++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb1))
                            {
                               // msgPass("LoginWithNewPassword");
                                a = true;
                                b = false;
                                return true;
                            }
                            else if (p == 30)
                            {
                                geckoWebBrowser1.Navigate(linkWeb);
                                delay(5000);
                                break;
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
                            //b = false;
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
        private bool GetMACInforWEBUI()
        {
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
                Status("Check_Information_Web_UI");
                msg("Get_Information_Web_UI");
                geckoWebBrowser1.Navigate(linkInfor);
                delay(500);
                for (int n = 0; n <= 40; n++)
                {
                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkInfor) & WaitWeb1(DocumentTitleInfor))
                    {
                        break;
                    }
                    else
                    {
                        if (n >= 30)
                        {
                            msg("Err_Get_infor_WEB");
                            ErrorNian("Err_Get_infor_WEB");
                            return false;
                        }
                        else if (n == 15)
                        {
                            geckoWebBrowser1.Navigate(linkInfor);
                            delay(3000);
                        }
                        else if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitWeb1(DocumentTitleWEBSSID2))
                        {
                            LoginWithNewPassword();
                        }
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
                        msg("Get_Infor_XFINITY Network => --------------\n\r" + rr + " \n " + rr1 + "\nGet_Infor_XFINITY Network =>--------------End\n");
                        var ll = Bootup_wifi1.GetElementsByTagName("div");
                        var ll1 = Bootup_wifi2.GetElementsByTagName("div");
                        try
                        {
                            var Mac1 = ll[17].GetElementsByTagName("span");
                            wanmac = Mac1[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { wanmac = ""; }
                        try
                        {
                            var Mac2 = ll[18].GetElementsByTagName("span");
                            mtamac = Mac2[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { mtamac = ""; }
                        try
                        {
                            var Mac3 = ll[19].GetElementsByTagName("span");
                            cmmac = Mac3[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { cmmac = ""; }
                        try
                        {
                            var hardware = ll1[0].GetElementsByTagName("span");
                            HW1 = hardware[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            var bootloatder = ll1[2].GetElementsByTagName("span");
                            boot1 = bootloatder[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                            var sn = ll1[8].GetElementsByTagName("span");
                            sns = sn[1].TextContent.Replace(":", "").Replace("\n", "").Replace("\t", "");
                        }
                        catch { HW = ""; boot = ""; sns = ""; }
                        if (Label_Test == false)
                        {
                            if (!cmmac.Equals("") & !mtamac.Equals("") & !wanmac.Equals("") & HW1.Equals(HW) & boot1.Equals(boot) & lbsndut.Text.Equals(sns))
                            {
                                msg("Information_WEB");
                                return true;
                            }
                            else
                            {
                                msg(
                               "Error: HW_WEB: " + HW1 + "  ==>  " + "HW_DUT: " + HW + "\n" +
                                    "Error: SN_lable: " + SNledonline + "  ==>  " + "SN_WEB: " + sns + "\n");
                                cout1++;
                                if (cout1 > 3)
                                {
                                    ErrorNian("Err_Information_WEB");
                                    b = false;
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkInfor);
                                delay(3500);
                            }
                        }
                        else
                        {
                            if (sModem == "CGM4981COX")
                            {
                                if (!cmmac.Equals("") & !mtamac.Equals("") & !wanmac.Equals("") & HW1.Equals(HW) & boot1.Equals(boot) & SNledonline.Equals(sns))
                                {
                                    msg("Information_WEB");
                                    return true;
                                }
                                else
                                {
                                    msg(
                                   "Error: HW_WEB: " + HW1 + "  ==>  " + "HW_DUT: " + HW + "\n" +
                                        "Error: SN_lable: " + SNledonline + "  ==>  " + "SN_WEB: " + sns + "\n");
                                    cout1++;
                                    if (cout1 > 3)
                                    {
                                        ErrorNian("Err_Information_WEB");
                                        b = false;
                                        return false;
                                    }
                                    geckoWebBrowser1.Navigate(linkInfor);
                                    delay(3500);
                                }
                            }
                            else
                            {
                                msg("SN_lable: " + SNledonline + "  ==>  " + "SN_WEB: " + sns + "\n" +
                                    "CMMAC_lable: " + CMMACLabel + " ==> " + "CMMAC_WEB: " + cmmac + "\n" +
                                    "MTAMAC_lable: " + MTAMACLabel + "  ==>  " + "MTAMAC_WEB: " + mtamac + "\n" +
                                    "WANMAC_lable: " + WANMACLabel + "  ==>  " + "WANMAC_WEB: " + wanmac);
                                if (CMMACLabel.Equals(cmmac) & MTAMACLabel.Equals(mtamac) & WANMACLabel.Equals(wanmac) & HW1.Equals(HW) & boot1.Equals(boot) & SNledonline.Equals(sns))
                                {
                                    msg("Information_WEB");
                                    return true;
                                }
                                else
                                {
                                    msg("Error: CMMAC_lable: " + CMMACLabel + "  ==>  " + "CMMACC_WEB: " + cmmac + "\n" +
                                        "Error: WANMAC_lable: " + MTAMACLabel + "  ==>  " + "WANMAC_WEB: " + mtamac + "\n" +
                                        "Error: WANMAC_lable: " + WANMACLabel + "  ==>  " + "WANMAC_WEB: " + wanmac + "\n" +
                                        "Error: HW_DUT: " + HW + "  ==>  " + "HW_WEB: " + HW1 + "\n" +
                                        "Error: SN_lable: " + SNledonline + "  ==>  " + "SN_WEB: " + sns + "\n");
                                    cout1++;
                                    if (cout1 > 3)
                                    {
                                        ErrorNian("Err_Information_WEB");
                                        b = false;
                                        return false;
                                    }
                                    geckoWebBrowser1.Navigate(linkInfor);
                                    delay(3500);
                                }
                            }
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
        private bool GeWifiInforWEBUI()
        {
            bool a = false;
            bool b = true;
            int cout1 = 0;
            clickWPSWebPass = false;
            if (thStattus1 == true)
            {
                Status("Check_wifi_bootup_Web_UI");
                msg("Check_wifi_bootup_Web_UI");
                for (int i = 0; i < 3; i++)
                {
                    geckoWebBrowser1.Navigate(linkwifi);
                    delay(200);
                    for (int n = 0; n <= 30; n++)
                    {
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkwifi))
                        {
                            break;
                        }
                        else
                        {
                            delay(1000);
                        }
                    }
                    if (WaitWeb1(DocumentTitleWifi))
                    {
                        break;
                    }
                    else
                    {
                        if (i >= 2)
                        {
                            msg("Err_Wifi_bootup_WEB");
                            ErrorNian("Err_Wifi_bootup_WEB");
                            return false;
                        }
                    }
                }
                while (b)
                {
                    try
                    {
                        if (geckoWebBrowser1.InvokeRequired)
                        {
                            geckoWebBrowser1.Invoke(new Action(() =>
                            {
                                GeckoInputElement Bootup_wifi = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                                string rr = Bootup_wifi.TextContent.Replace(" ", "").Replace("\t", "");
                                msg("Get_Wifi_Private Wi-Fi Network => --------------\n\r" + rr + "\nGet_Private Wi-Fi Network =>End\n");
                                if (rr.Contains("2.4GHz") & rr.Contains("5GHz") & rr.Contains("6GHz"))
                                {
                                    b = false;
                                    a = false;
                                }
                                else
                                {

                                    cout1++;
                                    if (cout1 > 3)
                                    {
                                        Status("Err_Web_clickWPSPin");
                                        ErrorNian("Err_Wifi_bootup_WEB");
                                        b = false;
                                        a = false ;
                                    }
                                    geckoWebBrowser1.Navigate(linkwifi);
                                    delay(3500);
                                }
                            }));
                        }
                        else
                        {                         
                            GeckoInputElement Bootup_wifi = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("private_wifi").DomObject);
                            string rr = Bootup_wifi.TextContent.Replace(" ", "").Replace("\t","").Replace("\n\n", "\n").Replace("\n\n\n", "\n");
                            msg("Get_Wifi_Private Wi-Fi Network => --------------\n\r" + rr + "\nGet_Private Wi-Fi Network =>--------------End\n");
                            if (rr.Contains("2.4GHz") & rr.Contains("5GHz") & rr.Contains("6GHz"))
                            {
                                b = false;
                                a = true;
                                return true;
                            }
                            else
                            { 
                                cout1++;
                                if (cout1 > 3)
                                {
                                    Status("Err_Web_clickWPSPin");
                                    ErrorNian("Err_Wifi_bootup_WEB");
                                    b = false;
                                    return false;
                                }
                                geckoWebBrowser1.Navigate(linkwifi);
                                for (int n = 0; n <= 30; n++)
                                {
                                    if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkwifi))
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
                    catch
                    {
                        cout1++;
                        if (cout1 > 3)
                        {
                            Status("Err_Wifi_bootup_WEB");
                            ErrorNian("Err_Wifi_bootup_WEB");
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkwifi);
                        for (int n = 0; n <= 30; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Contains(linkwifi))
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
        private bool clickMocaWeb()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            clickMocaWebPass = false;
            if (thStattus1 == true)
            {
                Status("clickMocaWeb");
                msg("clickMocaWeb");
                try
                {
                    PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                }
                catch { }
                if (!WaitWeb("Gateway > Connection > Wireless > Add Wireless Client - XFINITY"))
                {
                    msg("khong the truy cap vao Gateway > Connection > Wireless > Add Wireless Client - XFINITY");
                    MessageBox.Show("khong the truy cap vao Gateway > Connection > Wireless > Add Wireless Client - XFINITY");
                    return a;
                }
                while (b)
                {
                    try
                    {
                        if (!checkStatustesting(mt8)) b = false;
                        //PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                        //geckoWebBrowser1.Document.DocumentElement.TextContent = "";
                        //this.SetDesktopLocation(0, 0);
                        string va = "";
                        delay(1000);

                        if (geckoWebBrowser1.InvokeRequired)
                        {
                            geckoWebBrowser1.Invoke(new Action(() =>
                            {
                                geckoWebBrowser1.Navigate("http://10.0.0.1/moca.php");
                                delay(2000);
                                geckoWebBrowser1.Document.GetElementsByTagName("a")[15].Click();//conection
                                va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                            }));
                        }
                        else
                        {
                            geckoWebBrowser1.Document.GetElementsByTagName("a")[15].Click();//conection
                            va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                        }
                        if (va.Contains("moca.php"))
                        {
                            msgPass("clickMocaWeb");
                            clickMocaWebPass = true;
                            a = true;
                            b = false;
                        }
                        //Connection
                        cout++;
                        if (cout > 20)
                        {
                            Status("Err_Web_clickMoca");
                            ErrorNian(err.Err_Web_clickMoca);
                            b = false;
                        }
                    }
                    catch
                    {
                        cout1++;
                        if (cout1 > 50)
                        {
                            Status("");
                            Status("Err_Web_clickMoca");
                            ErrorNian(err.Err_Web_clickMoca);
                            b = false;
                        }
                    }

                }
                
            }
            else
            {
                Status("");
                //sendDataToSer(6);
                //delay(500);
                //sendDataToSer(3);
                //delay(500);
                //sendDataToSer(5);
                //delay(500);
                
                thStattus2 = false;
                //Status();
            }
            return a;
        }

        private bool enableMocaWebSHW()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            int cout2 = 0;
            enableMocaWebPss = false;
            if (thStattus1 == true)
            {
                Status("enableMocaWeb");
                msg("enableMocaWeb");
                geckoWebBrowser1.Navigate("http://10.0.0.1/moca.php");
                delay(2000);
                while (b)
                {
                    while (dkvoip)
                    {
                        try
                        {
                            if (!checkStatustesting(mt8)) { mt1 = "Checking"; b = false; }
                            try
                            {
                                PromptFactory.PromptServiceCreator = () => new NoPrmptServer();
                            }
                            catch { }
                            //this.SetDesktopLocation(0, 0);
                            delay(1000);

                            if (geckoWebBrowser1.InvokeRequired)
                            {
                                geckoWebBrowser1.Invoke(new Action(() =>
                                {
                                    geckoWebBrowser1.Navigate("http://10.0.0.1/moca.php");
                                    delay(2000);
                                    GeckoInputElement EnableMoca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("moca_enable").DomObject);
                                    delay(600);
                                    EnableMoca.Click();
                                    delay(600);
                                    //delay(20000);
                                    //geckoWebBrowser1.Document.GetElementsByTagName("a")[15].Click();//conection
                                    string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                    if (va.Contains("moca_enable"))
                                    {

                                        //enableMocaWebPss = true;
                                        GeckoInputElement Submit_moca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_moca").DomObject);
                                        Submit_moca.Click();


                                        enableMocaWebPss = true;
                                        Delay(20000);
                                        //if (!checkPingEth2()) return;
                                        if (geckoWebBrowser1.InvokeRequired)
                                        {
                                            geckoWebBrowser1.Invoke(new Action(() =>
                                            {
                                                geckoWebBrowser1.Stop();
                                                geckoWebBrowser1.Visible = false;
                                            }));
                                        }
                                        else
                                        {
                                            geckoWebBrowser1.Stop();
                                            geckoWebBrowser1.Visible = false;
                                        }
                                        /*  cmd.CmdConnect();
                                          delay(2000);
                                          cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");
                                          delay(2000);
                                          delay(5000);*/
                                        //20000
                                        msgPass("enableMocaWeb");

                                        a = true;
                                        b = false;
                                        VoipMoca = false;
                                        //voipfunction = false;
                                    }
                                }));
                            }
                            else
                            {
                                GeckoInputElement EnableMoca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("moca_enable").DomObject);
                                delay(600);
                                EnableMoca.Click();
                                delay(600);
                                //delay(20000);
                                //geckoWebBrowser1.Document.GetElementsByTagName("a")[15].Click();//conection
                                string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                                if (va.Contains("moca_enable"))
                                {

                                    GeckoInputElement Submit_moca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_moca").DomObject);
                                    //string pathfile1 = Directory.GetCurrentDirectory();
                                    //cmn.openExe1(pathfile1, "enableEth1");
                                    Submit_moca.Click();
                                    delay(10000);
                                    enableMocaWebPss = true;
                                    geckoWebBrowser1.Navigate("http://10.0.0.1");
                                    delay(2000);
                                    geckoWebBrowser1.Stop();
                                    geckoWebBrowser1.Visible = false;

                                    if (geckoWebBrowser1.InvokeRequired)
                                    {
                                        geckoWebBrowser1.Invoke(new Action(() =>
                                        {
                                            geckoWebBrowser1.Stop();
                                            geckoWebBrowser1.Visible = false;
                                        }));
                                    }
                                    else
                                    {
                                        geckoWebBrowser1.Stop();
                                        geckoWebBrowser1.Visible = false;
                                    }
                                    /* cmd.CmdConnect();
                                     delay(2000);
                                     cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");
                                     delay(2000);
                                     delay(5000);*/
                                    //20000
                                    msgPass("enableMocaWeb");
                                    a = true;
                                    b = false;
                                    VoipMoca = false;
                                    dkvoip = false;
                                    //voipfunction = false;
                                }
                            }
                            //Connection
                            //if (!checkStatustesting(mt8)) { mt1 = "Checking"; b = false; }
                            cout1++;
                            if (cout1 > 30)
                            {
                                Status("Err_Web_enableMoca");
                                ErrorNian(err.Err_Web_enableMoca);
                                thStattus2 = false;
                                b = false;
                                VoipMoca = false;
                                //voipfunction = false;
                            }
                        }
                        catch
                        {
                            cout2++;
                            if (cout2 > 50)
                            {
                                Status("");
                                //ErrorNian("");
                                ErrorNian(err.Err_Web_enableMoca);
                                b = false;
                            }
                        }
                    }
                    cout++;
                    delay(1000);
                    Status("VOIP wating:" + cout.ToString());
                    if (cout > 250)
                    {
                        Status("");
                        //ErrorNian("");
                        ErrorNian(err.Err_voip_wait);
                        thStattus2 = false;
                        b = false;
                        VoipMoca = false;
                        //voipfunction = false;
                    }
                }
                if (geckoWebBrowser1.InvokeRequired)
                {
                    geckoWebBrowser1.Invoke(new Action(() =>
                    {
                        geckoWebBrowser1.Stop();
                        geckoWebBrowser1.Visible = false;
                    }));
                }
                else
                {
                    geckoWebBrowser1.Stop();
                    geckoWebBrowser1.Visible = false;
                }
                
            }
            else
            {
                Status("");
                //sendDataToSer(6);
                //delay(500);
                //sendDataToSer(3);
                //delay(500);
                //sendDataToSer(5);
                //delay(500);
                
                thStattus2 = false;
                ///ErrorNian(errCode);
                //Status();
            }
            return a;
        }

        private bool enableMocaWebCOM()
        {
            bool a = false;
            bool b = true;
            int cout = 0;
            int cout1 = 0;
            int cout2 = 0;
            enableMocaWebPss = false;
            if (thStattus1 == true)
            {
                Status("Enable_Moca_WebUI");
                msg("Enable_Moca_WebUI");
                for (int i = 0; i <= 15; i++)
                {
                    geckoWebBrowser1.Navigate(linkWebMOCA);
                    for (int n = 0; n <= 30; n++)
                    {
                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebMOCA))
                        {
                            break;
                        }
                        else
                        {
                            delay(1000);
                        }
                    }
                    if (WaitLog(DocumentTitleMOCA, DocumentTitleMOCA))
                    {
                        break;
                    }
                    else
                    {
                        if (i >= 5)
                        {
                            msg("Err_Web_enableMoca");
                            ErrorNian("Err_Web_enableMoca");
                            return false;
                        }
                        delay(1000);
                    }
                }
                while (b)
                {
                    try
                    {
                        int c = 0;
                        while (true)
                        {
                            try//content
                            {
                                GeckoInputElement EnableMoca2 = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("moca_enable").DomObject);
                                if(EnableMoca2.OuterHtml.Length > 90 )
                                {
                                    geckoWebBrowser1.Navigate(linkWebMOCA);
                                    delay(10000);
                                }
                                else
                                {
                                    c++;
                                    if (c >= 2)
                                    {
                                        //if (sModem != "CGM4981SHW")
                                        //{
                                        timeTest.Enabled = false;
                                        MyMessagesBox.Show("\n\n           Cam_RF_MOCA!!");
                                        timeTest.Enabled = true;
                                        if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWeb) & WaitLog(DocumentTitleWEBSSID2, DocumentTitleWEBSSID2))
                                        {
                                            LoginWithNewPassword();
                                        }                        //}
                                        break;
                                    }
                                }

                            }
                            catch { }
                        }
                        GeckoInputElement EnableMoca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("moca_enable").DomObject);
                        delay(100);
                        EnableMoca.Click();
                        delay(500);
                        string va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
                        if (va.Contains("moca_enable"))
                        {
                            GeckoInputElement Submit_moca = new GeckoInputElement(geckoWebBrowser1.Document.GetElementById("submit_moca").DomObject);
                            Submit_moca.Click();
                            delay(13000);
                            enableMocaWebPss = true;                    
                            msgPass("enableMocaWeb");
                            a = true;
                            b = false;
                            VoipMoca = false;
                            dkvoip = false;
                            return true;
                        }
                    }
                    catch
                    {
                        cout2++;
                        if (cout2 > 10)
                        {
                            Status("Err_Web_enableMoca");
                            ErrorNian(err.Err_Web_enableMoca);
                            b = false;
                            return false;
                        }
                        geckoWebBrowser1.Navigate(linkWebMOCA);
                        for (int n = 0; n <= 30; n++)
                        {
                            if (geckoWebBrowser1.Document.Url.AbsoluteUri.Equals(linkWebMOCA))
                            {
                                delay(1000);
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


        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enableTelnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thStattus1 = true;
            VoipAgain = false;
            AnalysisVoipNian = false;
            double TimeStart = GettimeStart("VOIP1");
            Status4("CHECK P1 >> P2 VOIP");
            if (!CheckVoipP1toP2Nian()) { dkvoipretest = true; StatusERR("CheckVoipP1toP2"); return; }
            if (!noiseTest("P1toP2")) { dkvoipretest = true; StatusERR("noiseTestP1toP2"); return; }
            double TimeEnd = GettimeEnd("VOIP1");
            TimeVoip1 = CountTime("VOIP1", TimeStart, TimeEnd);
            double TimeStart1 = GettimeStart("VOIP2");
            Status4("CHECK P2 >> P1 VOIP");
            if (!CheckVoipP2toP1Nian()) { dkvoipretest = true; StatusERR("CheckVoipP2toP1"); return; }
            if (!noiseTest("P2toP1")) { dkvoipretest = true; StatusERR("noiseTestP2toP1"); return; }
            double TimeEnd1 = GettimeEnd("VOIP2");
            TimeVoip2 = CountTime("VOIP2", TimeStart1, TimeEnd);
            Status4("CHECK VOIP COMPLETE");
        }
        //******************************************************************************************
        //******************************************************************************************
        //******************************************************************************************
        string SN_SFC = "";
        string STB_SN = "";
        string buf = "";
        string bufSFC = "";
        string ERR_CODE = " ";
        string ERR_CODE1 = "";
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
            if (cmmModem.SelectedIndex == -1)
            {
                MessageBox.Show("Hay Chon Modem Name !!Pls");
            }
            if (txtUser.Text.Length == 8)
            {
                if(LoadInforOP())
                {
                    txtUser.ReadOnly = true;
                    btnLogin.Text = "Wait...";
                    btnLogin.Enabled = false;            
                    txtUser.Enabled = false;
                    btnLogin.Text = "LoginOK";
                    btnOpenCom.Enabled = true;
                    grKey.Visible = false;                  
                }
                else
                {
                    MessageBox.Show("Tên tài khoản không đúng.\r\nMời bạn nhập lại.");
                    txtUser.Text = "";
                    txtUser.Focus();
                    return;
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
        //******************************************************************************************
        private void btnConnect_SFC_Click(object sender, EventArgs e)
        {
            kq_Terminal_SFC = false;    
            if (cmmType.SelectedIndex != 1)
            {
                if (lockpc.Contains("yes"))
                {
                    if (!Checklockpc())
                    {
                        btnOpenCom.Text = "Connect";
                        btnOpenCom.Enabled = true;
                        return;
                    }
                }
                else
                {
                    if (!ChecklockpcPUS())
                    {
                        btnOpenCom.Text = "Connect";
                        btnOpenCom.Enabled = true;
                        return;
                    }                                    
                    string status2 = "";
                    string pathfile2 = Directory.GetCurrentDirectory() + "\\Statuslockduperr.txt";
                    try
                    {
                        StreamReader loadinfor2 = new StreamReader(pathfile2, Encoding.UTF8);
                        status2 = loadinfor2.ReadToEnd();
                        loadinfor2.Close();
                    }
                    catch { }
                    if (status2.Contains("lock"))
                    {
                        string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
                        StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                        string key = loadinfor1.ReadToEnd().Trim();
                        loadinfor1.Close();

                        cmmType.SelectedIndex = 1;
                        MyMessagesBox.Show("\n                  WARNING!!! \nPls.Gọi kỹ sư Online QE sử ly lỗi!\n\n            ERROR=> " + key);
                        Login_Lock lock1 = new Login_Lock();
                        lock1.Show();
                        serialsfc.Close();
                        serial.Close();
                        ComVoip.Close();
                        btnOpenCom.Text = "Connect";
                        btnOpenCom.Enabled = true;
                        return;
                    }                  
                }
            }
            st1 = false;
            cmmType.Enabled = false;
            lbComPort.Focus();
            btnOpenCom.Text = "Waiting...";
            kq_Terminal_SFC = false;
            if (cmmType.SelectedIndex == 1) {
                if (!ChecklockpcPUS())
                {
                    btnOpenCom.Text = "Connect";
                    btnOpenCom.Enabled = true;
                    return;
                }
                kq_Terminal_SFC = true; }
            else
            {
                ThreadStart socket_SFC = new ThreadStart(SFC);
                Thread_SFC = new Thread(socket_SFC);
                Thread_SFC.IsBackground = true;
                Thread_SFC.Start();
            }
            for (int i = 0; i <= 10; i++)
            {
                if (kq_Terminal_SFC == true)
                {
                    cmmType.Enabled = false;
                    btnOpenCom.Text = "Disconnect";
                    btnStart.Enabled = true;
                    adjusmicro();
                    adjusvolume();
                    btnOpenCom.Enabled = false;
                    break;
                }
                else
                {
                    if (i >= 5)
                    {
                        listener_SFC.Stop();
                        serialsfc.Close();
                        serial.Close();
                        ComVoip.Close();
                        btnOpenCom.Text = "Connect";
                        btnOpenCom.Enabled = true;
                        MyMessagesBox.Show("\n\n      Pls.Kiểm tra SFC trạm FQA1_1!!!");
                        return;
                    }
                    delay(1000);
                }
            }
            try
            {
                if (!ComVDK.IsOpen)
                {
                    ComVDK.PortName = sCom;
                    ComVDK.Close();
                    if (sLine == "T1")
                    {
                        ComVDK.BaudRate = Convert.ToInt32("9600");
                    }
                    else { ComVDK.BaudRate = Convert.ToInt32("19200"); }
                    ComVDK.DataBits = 8;
                    ComVDK.Parity = Parity.None;
                    ComVDK.StopBits = StopBits.One;
                    ComVDK.DataReceived += new SerialDataReceivedEventHandler(_com1_DataReceived);
                    ComVDK.Open();
                }
                //serialVoip
                if (!ComVoip.IsOpen)
                {
                    ComVoip.PortName = sComVoip;
                    ComVoip.BaudRate = Convert.ToInt32("115200");
                    ComVoip.DataBits = 8;
                    ComVoip.Parity = Parity.None;
                    ComVoip.StopBits = StopBits.One;
                    ComVoip.DataReceived += new SerialDataReceivedEventHandler(SerialVOIP_DataReceived);
                    ComVoip.Open();
                }
                button3.Visible = true;
                return;
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                serialsfc.Close();
                serial.Close();
                btnOpenCom.Enabled = true;
                btnOpenCom.Text = "Connect";
                return;
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
                    if (str.Contains("@_@") && str.Contains("FQA1_1"))
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
            string strrrrr = ""; string strrrrr_2 = "";
            try
            {
                strrrrr = reader_SFC.ReadLine().ToString();
                delay(500);
                strrrrr_2 = reader_SFC.ReadLine();
                Write_logfile_SFC("Receive: " + strrrrr);
                msg_SFC("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
                msg(strrrrr.Replace("\0", "") + "\r\n");
                Write_logfile_SFC("Receive: " + strrrrr_2);
                msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
                msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
            }
            catch { }
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
            lblSFC_Status.Text = "SFC_Status: Testing...";
            lblSFC_Status.ForeColor = Color.Teal;
            txtOutput.AppendText("ID worker: " + txtUser.Text);
            txtOutput.AppendText("\r\n");
            SFC_flag = false;
        }
        //******************************************************************************************
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
                //  byte[] data = encoding.GetBytes("config");
                // stream_SFC.Write(data, 0, data.Length);
                // Write_logfile_SFC("Send: config");
                Delay(500);
                // 2. receive
                buf = "                        ";
                msg("Data_Send_SFC: " + cmd);
                writer_SFC.Write("\x1b\x07" + cmd + "\r\n");
                Write_logfile_SFC("Send: " + "\x1b\x07" + cmd + "\r\n");
                try
                {
                    delay(100);
                    strrrrr = reader_SFC.ReadLine().ToString().Trim();
                    delay(100);
                    strrrrr_2 = reader_SFC.ReadLine().Trim();
                    delay(100);
                    Write_logfile_SFC("Receive: " + strrrrr);
                    msg_SFC(strrrrr.Replace("\0", "") + "\r\n");
                    msg("SFC_1: " + strrrrr.Replace("\0", "") + "\r\n");
                    Write_logfile_SFC("Receive: " + strrrrr_2);
                    msg_SFC(strrrrr_2.Replace("\0", "") + "\r\n");
                    msg("SFC_2: " + strrrrr_2.Replace("\0", "") + "\r\n");
                    //strrrrr_3 = reader_SFC.ReadLine();
                    //delay(100);
                    //strrrrr_4 = reader_SFC.ReadLine();
                    //delay(100);
                    //strrrrr_5 = reader_SFC.ReadLine();
                }
                catch
                {
                    name_connection_SFC("Connection Fail!");
                    stream_SFC.Close();
                    socket_SFC.Close();
                    listener_SFC.Stop();
                    return strrrrr;
                }
                stream_SFC.Close();
                socket_SFC.Close();
                listener_SFC.Stop();
                return strrrrr;
            }
            catch (Exception ex)
            {
                name_connection_SFC("Connection Fail!");
                MessageBox.Show("Gửi dữ liệu lên SFC Fail\r\n" + ex.Message);
                listener_SFC.Stop();
                return strrrrr;
            }
            return strrrrr;
        }
        //******************************************************************************************
        private bool Check_SN(string SN_Box)
        {
            // SN1234
            bool a = false;
            Check_SNPass = true;
            SN_SFC = SN_Box;
            SN_SFC = SN_SFC.PadRight(35, ' ');
            SN_SFC = SN_SFC + "END";
            Check_SNPass = false;
            for (int i = 0; i <= 1; i++)
            {
                string str_SFC = "";
                str_SFC =  Send_To_SFC(SN_SFC);
              //  delay(500);
               // str_SFC = Get_data_SFC1();
                if (str_SFC.Length <= 120)
                {
                    txtSN_SFC.Text = SN_Box;
                    if (str_SFC.Contains("PASS") && str_SFC.Contains(SN_Box))
                    {
                        lblSFC_Status.Text = "Send data to SFC: Success";
                        lblSFC_Status.ForeColor = Color.Blue;
                        Check_SNPass = true;
                        a = true;
                        return true;
                    }
                    else
                    {
                        if (i >= 1)
                        {
                            a = false;
                            lblSFC_Status.Text = "Send data SFC: Unsuccess";
                            lblSFC_Status.ForeColor = Color.Red;
                            Status4("Please Check Terminal !!");
                            MessageBox.Show("      Sai lưu trinh!! \n" + SFC_result.Text);
                            msg(SFC_result.Text);
                            return false;
                        }
                        delay(2000);
                    }
                }
                else
                {
                    if (i >= 1)
                    {
                        MyMessagesBox.Show("\t\tPls. Check Termial!!");
                        return false;
                    }
                    delay(2000);
                }
            }
            return a;
        }
        //******************************************************************************************
        private bool Check_Feedback(string chuoi)
        {
            try
            {
                string temp = chuoi.Trim();
                    //string str_Result = temp.Substring(temp.Length - 4, 4);
                    if ((temp.Contains("PASS")) | (temp.Contains("FAIL")))
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
        //******************************************************************************************
        private bool Send_To_SFC_PASS()
        {
            string str_SFC = "";
            if (cmmType.SelectedIndex == 1)
            {               
                return true;
            }
            else
            {
                msg("Send_To_SFC_PASS:" + lbsndut.Text);
                STB_SN = SNledonline.PadRight(35, ' ');
                //STB_SN = lbsndut.Text.PadRight(35, ' ');
                if (dkfailssid)
                {
                    str_SFC = Send_To_SFC(STB_SN + "GETWIFIBYWEB" + Computer_name + "\r");
                }
                else
                {
                    str_SFC = Send_To_SFC(STB_SN + "GETWIFIBYMIB" + Computer_name + "\r");
                }                           
                msg("SFC_PASS_STB_SN:" + STB_SN);
                msg("SFC_PASS_lbSN.Text:" + lbsndut.Text);
                msg("SFC_PASS_LbSN:" + lbsndut);
               // bufSFC = Get_data_SFC1();
                if (Check_Feedback(str_SFC))
                {
                   // Initial();
                    lblSFC_Status.Text = "Send data to SFC: Success";
                    lblSFC_Status.ForeColor = Color.Blue;                  
                    return true;
                }
                else
                {
                    msg("SFC_PASS_buf:" + bufSFC);
                  //  Initial();
                    lblSFC_Status.Text = "Send data to SFC: Unsuccess";
                    lblSFC_Status.ForeColor = Color.Red;                  
                    return false;
                }
            }
        }

        //******************************************************************************************
        private bool Send_To_SFC_FAIL(string err)
        {
            msg("Send_To_SFC_FAIL:" + lbsndut.Text+ " " + err);
            STB_SN = lbsndut.Text.PadRight(35, ' ');
            if (err.Length < 5 | err.Length > 7)
            {
                err = "ERRNOTDEFINE";
            }
            bufSFC = Send_To_SFC(STB_SN + "FUNCTIONFAIL" + Computer_name + err + "\r");
           // bufSFC = Get_data_SFC1();
            if (Check_Feedback(bufSFC))
            {
               // Initial();
                if (lblSFC_Status.InvokeRequired)
                {
                    lblSFC_Status.Invoke(new Action(() => lblSFC_Status.Text = "Send data to SFC: Success"));
                }
                else
                {
                    lblSFC_Status.Text = "Send data to SFC: Success";
                }      
                lblSFC_Status.ForeColor = Color.Blue;
                return true;
            }
            else
            {
               // Initial();
                if (lblSFC_Status.InvokeRequired)
                {
                    lblSFC_Status.Invoke(new Action(() => lblSFC_Status.Text = "Send data to SFC: Unsuccess"));
                }
                else
                {
                    lblSFC_Status.Text = "Send data to SFC: Unsuccess";
                }           
                lblSFC_Status.ForeColor = Color.Red;
                return false;
            }
        }
        
        //******************************************************************************************
        private void Initial()
        {
            if (txtSN_SFC.InvokeRequired)
            {
                txtSN_SFC.Invoke(new Action(() => txtSN_SFC.Text = ""));
            }
            else
            {
                txtSN_SFC.Text = "";
            }          
            STB_SN = "";
            SN_SFC = "";         
        }
        //*****************************************************************************************       
        private void Send_ErrCode(string ERR_CODE, string err)
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

            if (lblerr.InvokeRequired)
            {
                lblerr.Invoke(new Action(() =>
                {
                    lblerr.Text = ERR_CODE + " => " + err;
                }));
            }
            else { lblerr.Text = ERR_CODE + " => " + err; }
        }
        //*********************************************************************************************
        private void Check_ERRCODE(string err)
        {
            ///maloi    
            ///
            ERR_CODE = "";
            nk = true;
            if (err == "Error_Bootup_After_RTD") ERR_CODE = "FBOOTR";

            if (err == "Err_PSU_1") ERR_CODE = "FPSU01";
            if (err == "Err_PSU_2") ERR_CODE = "FPSU02";

            if (err == "Err_Feasa_Nan") ERR_CODE = "FFEASA";
            if (err == "Err_Connect_Camera_LED") ERR_CODE = "ECAMLE";
            if (err == "Err_Connect_Camera_Label") ERR_CODE = "ECAMLB";
            if (err == "Err_Light_Camera_Label") ERR_CODE = "ELIGHT";
            if (err == "Err_Led_Online") ERR_CODE = "FEASA1";
            if (err == "Err_Led_Online_Blue") ERR_CODE = "FEASAB";
            if (err == "Err_Led_Online_Green") ERR_CODE = "FEASAG";
            if (err == "Err_Led_Online_OFF") ERR_CODE = "FEASAN";
            if (err == "Err_Led_Online_Orange") ERR_CODE = "FEASAO";
            if (err == "Err_Led_WPS") ERR_CODE = "FLED03";
            if (err == "Err_Led_WPS_Green") ERR_CODE = "FLWPSG";
            if (err == "Err_Led_WPS_OFF") ERR_CODE = "FLWPSN";
            if (err == "Err_Led_WPS_Orange") ERR_CODE = "FLWPSO";
            if (err == "Err_Led_WPS_White") ERR_CODE = "FLWPSW";
            if (err == "Err_Connect_Feasa") ERR_CODE = "FEASA0";
            if (err == "Err_Setcommand_Feasa") ERR_CODE = "FEASA2";

            if (err == "Err_NO_Card_1") ERR_CODE = "ECARD1";
            if (err == "Err_NO_Card_2") ERR_CODE = "ECARD2";
            if (err == "Err_NO_Card_3") ERR_CODE = "ECARD3";
            if (err == "Err_NO_Card_4") ERR_CODE = "ECARD4";

            if (err == "Err_Connect_Card_1") ERR_CODE = "ECNTH1";
            if (err == "Err_Connect_Card_2") ERR_CODE = "ECNTH2";
            if (err == "Err_Connect_Card_3") ERR_CODE = "ECNTH3";
            if (err == "Err_Connect_Card_4") ERR_CODE = "ECNTH4";

            if (err == "Err_IP_Card_1") ERR_CODE = "EIPDF1";
            if (err == "Err_IP_Card_2") ERR_CODE = "EIPDF2";
            if (err == "Err_IP_Card_3") ERR_CODE = "EIPDF3";
            if (err == "Err_IP_Card_4") ERR_CODE = "EIPDF4";

            if (err == "Err_NO_Voltage") ERR_CODE = "FVOIPV";
            if (err == "Err_Port1_no_Voltage") ERR_CODE = "FRJD01";
            if (err == "Err_Port2_no_Voltage") ERR_CODE = "FRJD02";
            if (err == "Err_RJ11_Modem") ERR_CODE = "FRJ11M";
            if (err == "Err_RJ11_Phone") ERR_CODE = "FRJ11P";

            if (err == "Err_Check_Label_get_file") ERR_CODE = "ECAM40";
            if (err == "Err_Check_Label_SN") ERR_CODE = "ECAM41";
            if (err == "Err_Check_Label_SSID") ERR_CODE = "ECAM42";
            if (err == "Err_Check_Label_PASSWORD") ERR_CODE = "ECAM43";
            if (err == "Err_Check_Label_MAC") ERR_CODE = "ECAM44";
            if (err == "Err_Check_Label_Passw_Wifi") ERR_CODE = "ECAM45";

            if (err == "Err_WanMac_Leng") ERR_CODE = "FWALEG";
            if (err == "Err_Get_WanMac") ERR_CODE = "FWAGET";
            if (err == "Err_Set_DHCP_IP") ERR_CODE = "FDHCIP";
            if (err == "Fail_Down_Stream") ERR_CODE = "FDWTRM";
            if (err == "Fail_UP_Stream") ERR_CODE = "FUPTRM";

            if (err == "Err_GetSN_MIB") ERR_CODE = "FSNMIB";
            if (err == "Err_GetSN_MIB_Length") ERR_CODE = "FSNLEG";
            if (err == "Err_wifi_password") ERR_CODE = "FPASSM";
            if (err == "Err_ssidname") ERR_CODE = "FGSSID";
            if (err == "Login_With_Old_Password") ERR_CODE = "FLOG02";
            if (err == "Err_USB_TypeC") ERR_CODE = "FUSB00";
            if (err == "Err_config_SSID_Password") ERR_CODE = "EWEB00";//EWEB00
            if (err == "Err_login_Web_First") ERR_CODE = "EWEB01";
            if (err == "Err_Web_Change_Password") ERR_CODE = "EWEB02";
            if (err == "Err_login_Web_New_Password") ERR_CODE = "EWEB03";
            if (err == "Err_Wifi_bootup_WEB") ERR_CODE = "EWEWFB";
            if (err == "Err_Information_WEB") ERR_CODE = "EWEINF";

            if (err == "Err_Eth1_Speed1G") ERR_CODE = "FSPE11";
            if (err == "Err_Eth1_Speed100M") ERR_CODE = "FSPE01";
            if (err == "Err_Eth1_Led_Green") ERR_CODE = "FLEG01";
            if (err == "Err_Eth1_Led_Red") ERR_CODE = "FLER01";
            if (err == "Err_Eth1_Ping") ERR_CODE = "FPING1";
            if (err == "Err_Eth1_Ping_COX_issue") ERR_CODE = "FP1COX";
            if (err == "Err_Eth1_Ping_issue_IP169") ERR_CODE = "FPI169";
            if (err == "Err_Eth2_Speed1G") ERR_CODE = "FSPE12";
            if (err == "Err_Eth2_Speed100M") ERR_CODE = "FSPE02";
            if (err == "Err_Eth2_Led_Green") ERR_CODE = "FLEG02";
            if (err == "Err_Eth2_Led_Red") ERR_CODE = "FLER02";
            if (err == "Err_Eth2_Ping") ERR_CODE = "FPING2";
            if (err == "Err_Eth_SERVER") ERR_CODE = "FPIGSV";
            if (err == "Err_Eth3_Speed1G") ERR_CODE = "FSPE13";
            if (err == "Err_Eth3_Speed100M") ERR_CODE = "FSPE03";
            if (err == "Err_Eth3_Led_Green") ERR_CODE = "FLEG03";
            if (err == "Err_Eth3_Led_Red") ERR_CODE = "FLER03";
            if (err == "Err_Eth3_Ping") ERR_CODE = "FPING3";
            if (err == "Err_Eth4_Speed2.5G") ERR_CODE = "FSPE24";
            if (err == "Err_Eth4_Speed100M") ERR_CODE = "FSPE04";
            if (err == "Err_Eth4_Led_Green") ERR_CODE = "FLEG04";
            if (err == "Err_Eth4_Led_Red") ERR_CODE = "FLER04";
            if (err == "Err_Eth4_Ping") ERR_CODE = "FPING4";

            if (err == "Err_Led_WPS") ERR_CODE = "FLED03";
            if (err == "Err_PingafterReset") ERR_CODE = "FRST41";
            if (err == "Err_voip_noise_P1") ERR_CODE = "FVOPN1";
            if (err == "Err_voip_noise_P2") ERR_CODE = "FVOPN2";
            if (err == "Err_Ping_Timeout") ERR_CODE = "FRST40";
            if (err == "Err_Ping_Moca") ERR_CODE = "FPMOCA";
            if (err == "Err_CMTS_Ping") ERR_CODE = "EPSV01";
            if (err == "Err_Moca_SetIp") ERR_CODE = "FSMOCA";
            if (err == "Err_LANMAC") ERR_CODE = "FINF07";
            if (err == "Err_CMMAC_Total") ERR_CODE = "FINF01";
            if (err == "Err_Server_Telnet") ERR_CODE = "ETSV01";
            if (err == "Err_snmp_connect") ERR_CODE = "ECSV01";
            if (err == "Err_CMTS_Connect") ERR_CODE = "ECSV01";
            if (err == "Err_WPS_Pin") ERR_CODE = "FWPS01";
            if (err == "Err_Information") ERR_CODE = "FINF00";

            if (err == "Err_Information_SN") ERR_CODE = "FINF03";
            if (err == "Err_CMMAC") ERR_CODE = "FINF01";
            if (err == "Err_MTAMAC") ERR_CODE = "FINF06";
            if (err == "Err_Web_LoginFirst") ERR_CODE = "FLOG01";
            if (err == "Err_Web_AccessFirst") ERR_CODE = "FLOG02";
            if (err == "Err_Web_LoginSecond") ERR_CODE = "FLOG03";
            if (err == "Err_Web_clickConnect") ERR_CODE = "FCLK01";
            if (err == "Err_Web_clickWifi") ERR_CODE = "FCLK02";
            if (err == "Err_Web_clickWPSPin") ERR_CODE = "FCLK03";
            if (err == "Err_Web_clickMoca") ERR_CODE = "FCLK04";
            if (err == "Err_Web_enableMoca") ERR_CODE = "FEMOCA";
            if (err == "Err_Fan_Value") ERR_CODE = "FFAN01";
            if (err == "Err_BLE_Enable") ERR_CODE = "FBLE01";
            if (err == "Err_Zigbee_Enable") ERR_CODE = "FZIG01";
            if (err == "Err_Zigbee_Disable") ERR_CODE = "FZIG02";

            if (err == "Err_Voip_P1ToP2_00") ERR_CODE = "FVOI10";
            if (err == "Err_Voip_P1ToP2_Min") ERR_CODE = "FVOI11";
            if (err == "Err_Voip_P1ToP2_Min0") ERR_CODE = "FVOI12";
            if (err == "Err_Voip_P1ToP2_Min1") ERR_CODE = "FVOI13";
            if (err == "Err_Voip_P1ToP2_Max") ERR_CODE = "FVOI14";
            if (err == "Err_Voip_P1ToP2_Max0") ERR_CODE = "FVOI15";
            if (err == "Err_Voip_P1ToP2_Max1") ERR_CODE = "FVOI16";
            if (err == "Err_Voip_P1ToP2_OutDup") ERR_CODE = "FVOI17";
            if (err == "Err_Voip_P1ToP2_Busy") ERR_CODE = "FVOI18";
            if (err == "Err_Voip_P1ToP2_Call") ERR_CODE = "FVOI19";
            if (err == "Err_Voip_P1ToP2_Other") ERR_CODE = "FVOIP1";//Err_Voip_P1ToP2_Other

            if (err == "Err_Voip_P2ToP1_00") ERR_CODE = "FVOI20";
            if (err == "Err_Voip_P2ToP1_Min") ERR_CODE = "FVOI21";
            if (err == "Err_Voip_P2ToP1_Min0") ERR_CODE = "FVOI22";
            if (err == "Err_Voip_P2ToP1_Min1") ERR_CODE = "FVOI23";
            if (err == "Err_Voip_P2ToP1_Max") ERR_CODE = "FVOI24";
            if (err == "Err_Voip_P2ToP1_Max0") ERR_CODE = "FVOI25";
            if (err == "Err_Voip_P2ToP1_Max1") ERR_CODE = "FVOI26";
            if (err == "Err_Voip_P2ToP1_OutDup") ERR_CODE = "FVOI27";
            if (err == "Err_Voip_P2ToP1_Busy") ERR_CODE = "FVOI28";
            if (err == "Err_Voip_P2ToP1_Call") ERR_CODE = "FVOI29";
            if (err == "Err_Voip_P2ToP1_Other") ERR_CODE = "FVOIP2";
            if (err == "Error_Bootup_Issue") ERR_CODE = "FBOTUP";
            if (err == "Error_Save_AudioFile") ERR_CODE = "EAUDIO";//Error_Save_AudioFile
            if (err == "ETIME0 Thoi gian test vuot qua Out Time") ERR_CODE = "EAUDIO";//"ETIME0 Thoi gian test vuot qua 840S"
            if (err == "Err_Led_Online") ERR_CODE = "FEASA1";//Err_Led_Online              
            msg(err + " ==> " + ERR_CODE);        
            if (Type_Program == "ON")
            {
                if (ERR_CODE.Length == 6)
                {

                    Send_ErrCode(ERR_CODE, err);
                    if (lockpc.Contains("yes"))
                    {                    
                        Checklockpc();
                        Write(ERR_CODE, "lock");
                    }
                    else
                    {
                        Checklockpcduperr(ERR_CODE);
                        Write(ERR_CODE, "lock");
                    }              
                }
            }
            LogFile("FAIL", ERR_CODE);
            LogFileFail(err, ERR_CODE);
            LogFilePassNian("FAIL", ERR_CODE);
        }
        //*********************************************************************************************
        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
        private bool Checklockpcduperr(string data)
        {
            bool a = false;
            try
            {
                string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
                StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                string key = loadinfor1.ReadToEnd().Trim();
                loadinfor1.Close();
                ERR_CODE1 = key;
                if (key.Equals(data))
                {               
                    ThreadStart Thread_Fail = new ThreadStart(messfail);
                    Thread_Failms = new Thread(Thread_Fail);
                    Thread_Failms.IsBackground = true;
                    Thread_Failms.Start();
                    checkstatus();
                    Writeduperr("lock");
                    return false;
                }
                else { return true; }
            }
            catch { }
            return a;
        }
        private void Writeduperr(string key)
        {
            string a = DateTime.Now.ToString();
            string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslockduperr.txt";
            try
            {
                FileStream fs1;
                fs1 = new FileStream(pathfile1, FileMode.Create);
                StreamWriter write1 = new StreamWriter(fs1, Encoding.UTF8);
                write1.WriteLine(key);
                write1.Flush();
                fs1.Close();
            }
            catch { }

        }
        Thread Thread_Failms = null;
        public void messfail()
        {
            MyMessagesBox.Show("\n                  WARNING!!! \nPls.Gọi kỹ sư Online QE sử ly lỗi!\n\n            ERROR=> " + ERR_CODE1);
            Login_Lock lock1 = new Login_Lock();
            lock1.Show();
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

        private void enableInforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            lbSsid.Visible = true;
            label7.Visible = true;
            lbwifiPassword.Visible = true;
            label4.Visible = true;
            //lbWpspin.Visible = true;
            label5.Visible = true;
            lbsndut.Visible = true;
            label11.Visible = true;
            lbCMMAC.Visible = true;
            label13.Visible = true;
            lbMTAMAC.Visible = true;

        }

        private void disableInforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            lbSsid.Visible = false;
            label7.Visible = false;
            lbwifiPassword.Visible = false;
            label4.Visible = false;
            //lbWpspin.Visible = false;
            label5.Visible = false;
            lbsndut.Visible = false;
            label11.Visible = false;
            lbCMMAC.Visible = false;
            label13.Visible = false;
            lbMTAMAC.Visible = false;
        }

        private void txtSN_SFC_TextChanged(object sender, EventArgs e)
        {

        }

        private void switchSppedToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        private void set_speed_Eth_port(string name_port, string speed)
        {
            string pathfile1 = Directory.GetCurrentDirectory();
            if (name_port == "All")
            {
                if (speed == "1000")
                {
                    cmn.openExe1(pathfile1, "speed1000All");
                }
                else
                {
                    cmn.openExe1(pathfile1, "speed100All");
                }
            }
                                            
        }
     
        private void button3_Click(object sender, EventArgs e)
        {
            string path = "C:";
            string path11 = "ProgramXB7";
            string path121 = "MODEL";
            string file_path = path + "\\" + path11 + "\\" + path121 + ".txt";
            errs = "";
            data = "";
            timStart.Enabled = true;
            FileStream fs;
            fs = new FileStream(file_path, FileMode.Create);
            StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
            write.WriteLine("1");
            write.Flush();
            fs.Close();
            txtOutput.Text = "CLOSE_OK";
        }
        private bool CheckSpeedWan_Xb7()
        {
            bool CheckSpeedWan = true;
            long speed_number = cmn.xb7speedEthAll("WAN-XB7", "100");
            if (speed_number == 100)
            {
                CheckSpeedWan = true;
            }
            else
            { CheckSpeedWan = false; }
            return CheckSpeedWan;
        }

        /// <summary>
        /// namecheck = "All"
        /// speed = "100" or "1000"
        /// </summary>
        /// <param name="namecheck"></param>
        /// <param name="speed"></param>
        private bool Check_speed(string namecheck, string speed)
        {
            Status("Speed "+ speed);
            string pathfile1 = Directory.GetCurrentDirectory();
            Status4("check Speed:" + speed + "/" + namecheck);
            checkSpeed100Pass = false;
            checkSpeed1GPass = false;
            bool b = true;
            int count100 = 1;
            int count = 1;         
            bool results_Check_speed = false;
            double TimeStart = GettimeStart("Speed1G_2.5G");
            double TimeStart1 = GettimeStart("Speed100M");
            ////////////////////////////////////
            if (thStattus1 == true)
            {
                while (b)
                {
                    long speed_number = cmn.xb7speedEthAll(namecheck, speed);
                    if (speed == "1000")
                    {                     
                        msg("Checking Speed1G & 2.5G:   " + count.ToString());
                        if (speed_number == 1000)
                        {
                            msgPass("checkSpeed 1G & 2.5G/Eth4 Pass");
                            msg("speed Eth4: 2.5G & Eth1,2,3: 1G Pass");
                            speed_number = 0;
                            checkSpeed1GPass = true;
                            b = false;
                            results_Check_speed = true;
                            double TimeEnd = GettimeEnd("Speed1G_2.5G");
                            TimeSpeed1G = CountTime("Speed1G_2.5G", TimeStart, TimeEnd);
                        }
                        else
                        {
                            msg("Checking Speed1G & 2.5G: " + count.ToString() + " Fail");
                            count++;
                            if (count >= 3)
                            {
                                double TimeEnd = GettimeEnd("Speed1G_2.5G");
                                TimeSpeed1G = CountTime("Speed1G_2.5G", TimeStart, TimeEnd);
                                DKlED1G = true;
                                if (speed_number == 11)
                                {
                                    ErrorNian("Err_Eth1_Speed1G");
                                }
                                else if (speed_number == 22)
                                {
                                    ErrorNian("Err_Eth2_Speed1G");
                                }
                                else if (speed_number == 33)
                                {
                                    ErrorNian("Err_Eth3_Speed1G");
                                }
                                else if (speed_number == 44)
                                {
                                    ErrorNian("Err_Eth4_Speed2.5G");
                                }
                                else { ErrorNian("Err_Eth1_Speed1G"); }
                                b = false;
                                return false;
                            }
                        }
                    }
                    else
                    {                     
                        msg("Checking Speed100M:   " + count100.ToString());
                        if (speed_number == 100)
                        {
                            msgPass("checkSpeed100M Pass");
                            msg("Speed100M:  Pass");
                            speed_number = 0;
                            checkSpeed100Pass = true;
                            b = false;
                            results_Check_speed = true;
                            double TimeEnd = GettimeEnd("Speed100M");
                            TimeSpeed100M = CountTime("Speed100M", TimeStart1, TimeEnd);
                        }
                        else
                        {
                            msg("Checking Setup100M: " + count100.ToString() + " Fail");
                            //_set_net_disable();
                            //Delay(1000);
                            //set_speed_Eth_port("All", "100");
                            //_set_net_enable();
                            //delay(10000);
                            count100++;
                            msg("Setup Speed100M:   " + count100.ToString());
                            if (count100 >= 3)
                            {
                                double TimeEnd = GettimeEnd("Speed100M");
                                TimeSpeed100M = CountTime("Speed100M", TimeStart1, TimeEnd);
                                DKLED100M = true;
                                if (speed_number == 11)
                                {
                                    ErrorNian("Err_Eth1_Speed100M");
                                }
                                else if (speed_number == 22)
                                {
                                    ErrorNian("Err_Eth2_Speed100M");
                                }
                                else if (speed_number == 33)
                                {
                                    ErrorNian("Err_Eth3_Speed100M");
                                }
                                else if (speed_number == 44)
                                {
                                    ErrorNian("Err_Eth4_Speed100M");
                                }
                                else { ErrorNian("Err_Eth1_Speed100M"); }
                                b = false;
                                return false;
                            }
                        }
                    }
                }
            }
            return results_Check_speed;
        }  
        private void button4_Click(object sender, EventArgs e)
        {
            txt_Debug.Text = "Start";
            CheckLed_1000EthPass = true;
            checkPingMocaPass = true;
            GetInfLable();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mt8 = "";
            thStattus1 = true;
            thrLable();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            comCmd("out10_on");
            //delay(45000);
            comCmd("out10_off");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string va = "";
            geckoWebBrowser1.Visible = true;
            geckoWebBrowser1.Visible = true;
            geckoWebBrowser1.Navigate("about:blank");
            geckoWebBrowser1.Document.Cookie = "";
            geckoWebBrowser1.Navigate("http://10.0.0.1");
            delay(2000);
            geckoWebBrowser1.Document.DocumentElement.TextContent = "";

            geckoWebBrowser1.Navigate("http://10.0.0.1");
            //geckoWebBrowser1.Size = new Size(358, 140);//675, 247//358, 140)
            delay(1000);
            va = ((Gecko.GeckoHtmlElement)(geckoWebBrowser1.Document.DocumentElement)).InnerHtml.ToString();
            if ((va.Contains("username")))
            {
                msg("loginWebsite_CAP");
                ErrorNian("FWBCAP");
                //msgPass("loginWebsite");
                //a = true;
                //b = false;
                //geckoWebBrowser1.Navigate("http://10.0.0.1");
                //delay(2000);
            }
            else if (va.Contains("get_set_up"))
            {
                delay(100);
            }
            else
            { }
        }

        private void button3_Click_3(object sender, EventArgs e)
        {           
            button3.Enabled = false;
            RESETDUT2();            
            button3.Enabled = true;
            MessageBox.Show("Reset Complete!!!...");
        }
    
        private void cmmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmmType.SelectedIndex == 1)
            {
                cmmType.ForeColor = Color.Red;
                //lbl_Type.Text = "Type: Warning!!!";
               // lbl_Type.ForeColor = Color.Red;
                btnStart.ForeColor = Color.Red;
                btnStart.BackColor = Color.Yellow;
                cmmType.Enabled = false;
            }
        }

        private void testingqq()
        {
            if (btnStart.InvokeRequired) {
                btnStart.Invoke(new Action(() =>
            {
                btnStart.ForeColor = Color.Blue;
                btnStart.BackColor = Color.Lime;
                btnStart.Text = "Testing...\n " + sModem;
                float xx = btnStart.Font.Size;
                xx = 14;
                btnStart.Font = new Font(btnStart.Font.Name, xx, btnStart.Font.Style, btnStart.Font.Unit);
            }          
            )); }
            else
            {
                btnStart.ForeColor = Color.Blue;
                btnStart.BackColor = Color.Lime;
                btnStart.Text = "Testing...\n " + sModem;
                float xx = btnStart.Font.Size;
                xx = 14;
                btnStart.Font = new Font(btnStart.Font.Name, xx, btnStart.Font.Style, btnStart.Font.Unit);
            }          
        }
        private void PASSOK()
        {
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action(() =>
                {
                    btnStart.ForeColor = Color.Blue;
                    btnStart.BackColor = Color.Lime;
                    btnStart.Text = "PASS";
                    float xx = btnStart.Font.Size;
                    xx = 30;
                    btnStart.Font = new Font(btnStart.Font.Name, xx,btnStart.Font.Style,btnStart.Font.Unit);
                }
            ));
            }
            else
            {
                btnStart.ForeColor = Color.Blue;
                btnStart.BackColor = Color.Lime;
                btnStart.Text = "PASS";
                float xx = btnStart.Font.Size;
                xx = 30;
                btnStart.Font = new Font(btnStart.Font.Name, xx, btnStart.Font.Style, btnStart.Font.Unit);
            }
        }
        private void FailOKOK()
        {
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action(() =>
                {
                    btnStart.ForeColor = Color.Yellow;
                    btnStart.BackColor = Color.Red;
                    btnStart.Text = "FAIL";
                    float xx = btnStart.Font.Size;
                    xx = 30;
                    btnStart.Font = new Font(btnStart.Font.Name, xx, btnStart.Font.Style, btnStart.Font.Unit);
                }
            ));
            }
            else
            {
                btnStart.ForeColor = Color.Yellow;
                btnStart.BackColor = Color.Red;
                btnStart.Text = "FAIL";
                float xx = btnStart.Font.Size;
                xx = 30;
                btnStart.Font = new Font(btnStart.Font.Name, xx, btnStart.Font.Style, btnStart.Font.Unit);
            }
        }
      

        private void button5_Click_3(object sender, EventArgs e)
        {
           
            comCmd("out10_on");
            delay(waitWPS);
            comCmd("out10_off");
            Delay(1000);
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
        private void button6_Click_3(object sender, EventArgs e)
        {
            //cmdNian();
            //stoptestUSB = true;
            //StopPGram();
            thStattus1 = true;
            cmn.openExe1(pathfile1, "enableEth1");
            delay(8000);
            WebAutoNian1();


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
        string inforSW = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_PROD_sey; MODEL: CGM4981COM>>";
        private void cmmModem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmmModem.SelectedIndex == 0| cmmModem.SelectedIndex == -1)
            {
                sModem = "CGM4981COM";
                pronam = "CGM4981COM";
                SSIDName = "XFSETUP";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "1");
                HW = "2.0";
                model = "1";
                inforSW = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_5.8p3s1_PROD_sey; MODEL: CGM4981COM>>";
            }
            if (cmmModem.SelectedIndex == 1)
            {
                model = "0";
                sModem = "CGM4981COM-DEV";
                SSIDName = "XFSETUP";
                pronam = "CGM4981COM-DEV";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "1");
                inforSW = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.81.21.97; SW_REV: CGM4981COM_4.14p6s4_DEV_sey; MODEL: CGM4981COM>>";
            }
            if (cmmModem.SelectedIndex == 2)
            {
                model = "2";
                sModem = "CGM4981COX";
                SSIDName = "SETUP";
                pronam = "CGM4981COX";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "2");
                InfoIP = "192.168.0.1";
                iptestEth2 = "192.168.0.20";
                iptestEth3 = "192.168.0.30";
                iptestEth4 = "192.168.0.40";
                HW = "2.0";
                linkWeb = "http://192.168.0.1/";
                linkWeb1 = "http://192.168.0.1/at_a_glance.jst";
                linkWebChangePassword = "http://192.168.0.1/admin_password_change.jst";
                linkWebNetwork = "http://192.168.0.1/wireless_network_configuration.jst";
                linkWebMOCA = "http://192.168.0.1/moca.jst";
                linkReset = "http://192.168.0.1/restore_reboot.jst";
                linkInfor = "http://192.168.0.1/network_setup.jst";
                linkwifi = "http://192.168.0.1/wireless_network_configuration.jst";
                DocumentTitleWEBSSID1 = "Smart Internet";
                DocumentTitleWEBSSID2 = "Login - Cox";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";             
            }
            if (cmmModem.SelectedIndex == 3)
            {
                model = "3";
                sModem = "CGM4981ROG";
                pronam = "CGM4981ROG";
                SSIDName = "EasyConnect";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "3");
                HW = "2.0";
                SNlength = 16;
                DocumentTitleWEBSSID1 = "Rogers Ignite";
                DocumentTitleWEBSSID2 = "Login - Rogers";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";              
            }        
            if (cmmModem.SelectedIndex == 4)//SHW
            {
                model = "4";
                sModem = "CGM4981SHW";
                pronam = "CGM4981SHW";
                SSIDName = "SHAW";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "3");
                HW = "2.0";
                SNlength = 16;
                DocumentTitleWEBSSID1 = "SHAW Smart Internet";
                DocumentTitleWEBSSID2 = "Login - Shaw";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";              
            }
            if (cmmModem.SelectedIndex == 5)
            {
                model = "5";
                sModem = "CGM4981VDT";
                pronam = "CGM4981VDT";
                SSIDName = "HELIX";
                btnStart.Text = "Start " + sModem;
                cmmModem.Enabled = false;
                WriteFileLabView("MODEL", "4");
                HW = "2.0";
                DocumentTitleWEBSSID1 = "Helix";
                DocumentTitleWEBSSID2 = "Login - Helix";
                DocumentTitleChangPassword = "Change Password";
                DocumentTitleInfor = "Gateway > Connection";
            }
            LoadInfoModem();
            cmdNian();
            txtUser.Focus();
            set_speed_Eth_port("All", "100");        
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
           // return "V";
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
        private bool CheckledOnline()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("                  LED status blinking white ? \n\n Led trang thái có nhâp nhay mau trắng không?", "Check LED Online/kiểm tra LED Online", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                timeTest.Enabled = true;
                msgPass("Check LED ONLINE__Manual");
                return true;
            }
            else
            {
                msg("Fail LED ONLINE");
                return false;
            }
        }
        private bool CheckledWPS()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("Press and hold button WPS 5s, LED status blinking blue ? \n\n                         Nhấn và giữ nút WPS 5s, \n         Led trang thái có nhâp nhay mau xanh không?", "Check button WPS/kiểm tra nút WPS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                timeTest.Enabled = true;
                msgPass("Check LED WPS__Manual");
                return true;
            }
            else
            {
                msg("Fail LED WPS");
                return false;
            }
        }
        private bool CheckledEthGreen()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("                    4 Port Ethernet blinking green? \n\n     4Port Ethernet có đang nhâp nhay màu xanh không?", "Check LED GREEN 4port Ethernet /kiểm tra LED xanh 4port Ethernet  ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                timeTest.Enabled = true;
                msgPass("Check LED Green Ethernet");
                return true;
            }
            else
            {
                msg("Fail LED Green Ethernet");
                return false;
            }
        }
        private bool CheckledEthOrange()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("                    4 Port Ethernet blinking orange? \n\n     4Port Ethernet có đang nhâp nhay màu cam không?", "Check LED Orange 4port Ethernet /kiểm tra LED cam 4port Ethernet  ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                timeTest.Enabled = true;
                msgPass("Check LED Orange Ethernet");
                return true;
            }
            else
            {
                msg("Fail LED Orange Ethernet");
                return false;
            }
        }
        private bool CheckUSBTypeC()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("       LED Check USB type C is light ?\n\n      Led kiêm tra USB type C có sáng ?", "Check USB type C/ Kiêm tra chức năng USB type C", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                msgPass("Check USB type C");
                timeTest.Enabled = true;
                return true;
            }
            else
            {
                msg("Fail USB Type C");
                return false;
            }
        }
        private bool ChecVoipP1toP2()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("         Call from Phone1 to Phone2 PASS?\n              (The phone number is 1001)  \n\nCuộc gọi từ điện thoại 1 tới điện thoại 2 PASS?\n                      (Số điện thọai 1001)", "Check VOiP P1->P2 /kiểm tra VOiP P1-> P2 (1001)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                timeTest.Enabled = true;
                msgPass("Check VOIP1 to VOIP2");
                return true;
            }
            else
            {
                msg("Fail VOIP1 to VOIP2");
                return false;
            }
        }
        private void Checkreset()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("Unplug RF cable, Press and hold button WPS about 40s->60s \n\n         Rut RF cable, nhấn và giữ nut WPS từ 40s->60s", "Reset to default/ Khôi phục cài đặt mặc đinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (va == DialogResult.OK)
            {
                timeTest.Enabled = true;
                
            }
            else
            {
                
            }
        }
        private bool ChecVoipP2toP1()
        {
            timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("         Call from Phone2 to Phone1 PASS?\n              (The phone number is 1002)  \n\nCuộc gọi từ điện thoại 2 tới điện thoại 1 PASS?\n                      (Số điện thọai 1002)", "Check VOiP P2->P1 /kiểm tra VOiP P2->P1 (1002)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                msgPass("Check VOIP2 to VOIP1");
                timeTest.Enabled = true;
                return true;
            }
            else
            {
                msg("Fail VOIP2 to VOIP1");
                return false;
            }
        }
        private bool CheckLable11()
        {
            //timeTest.Enabled = false;
            DialogResult va = MessageBox.Show("CM MAC: " + CMmaclable + "\nWAN MAC: " + Wanmaclable + "\nMTA MAC: " + Mtamaclable + "\nSN: " + SNlable + "\n\nSSID: " + SSISNamelale + "\nPassword: " + Passwordlale, "Check Lable/Kiểm tra Lable", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (va == DialogResult.Yes)
            {
                //timeTest.Enabled = true;
                msgPass("Check Lable");
                checkWifiPasswordPass = true;
                return true;
            }
            else
            {
                msg("Fail LABLE");
                return false;
            }
            msg("Lable_READ_TO_CHECK ===> ----------------------"+"\nCM MAC: " + CMmaclable + "\nWAN MAC: " + Wanmaclable + "\nMTA MAC: " + Mtamaclable + "\nSN: " + SNlable + "\n\nSSID: " + SSISNamelale + "\nPassword: " + Passwordlale + "\n==============================END");
        }
        private bool countmaintain()
        {
            bool a = false;
            string RF11 = "0";
            string RF22 = "0";
            string PSU11 = "0";
            string PSU22 = "0";
            string VOIP11 = "0";
            string VOIP22 = "0";
            string Eth11 = "0";
            string Eth22 = "0";
            string Eth33 = "0";
            string Eth44 = "0";
            string USB1 = "0";
            int RF1 = 0;
            int RF2 = 0;
            int PSU1 = 0;
            int PSU2 = 0;
            int VOIP1 = 0;
            int VOIP2 = 0;
            int Eth1 = 0;
            int Eth2 = 0;
            int Eth3 = 0;
            int Eth4 = 0;
            int USB = 0;
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 5:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);
            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;
            try
            {
                string pathfile2 = Directory.GetCurrentDirectory() + "\\maintain.txt";
                RF11 = File.ReadLines(pathfile2).Skip(0).Take(1).First().Substring(4, File.ReadLines(pathfile2).Skip(0).Take(1).First().Length - 4).Trim();
                RF22 = File.ReadLines(pathfile2).Skip(1).Take(1).First().Substring(4, File.ReadLines(pathfile2).Skip(1).Take(1).First().Length - 4).Trim();
                PSU11 = File.ReadLines(pathfile2).Skip(2).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(2).Take(1).First().Length - 5).Trim();
                PSU22 = File.ReadLines(pathfile2).Skip(3).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(3).Take(1).First().Length - 5).Trim();
                VOIP11 = File.ReadLines(pathfile2).Skip(4).Take(1).First().Substring(7, File.ReadLines(pathfile2).Skip(4).Take(1).First().Length - 7).Trim();
                VOIP22 = File.ReadLines(pathfile2).Skip(5).Take(1).First().Substring(7, File.ReadLines(pathfile2).Skip(5).Take(1).First().Length - 7).Trim();
                Eth11 = File.ReadLines(pathfile2).Skip(6).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(6).Take(1).First().Length - 5).Trim();
                Eth22 = File.ReadLines(pathfile2).Skip(7).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(7).Take(1).First().Length - 5).Trim();
                Eth33 = File.ReadLines(pathfile2).Skip(8).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(8).Take(1).First().Length - 5).Trim();
                Eth44 = File.ReadLines(pathfile2).Skip(9).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(9).Take(1).First().Length - 5).Trim();
                USB1 = File.ReadLines(pathfile2).Skip(10).Take(1).First().Substring(11, File.ReadLines(pathfile2).Skip(10).Take(1).First().Length - 11).Trim();

                RF1 = Convert.ToInt32(RF11); RF1 = RF1 + 1;
                RF2 = Convert.ToInt32(RF22); RF2 = RF2 + 1;
                PSU1 = Convert.ToInt32(PSU11); PSU1 = PSU1 + 1;
                PSU2 = Convert.ToInt32(PSU22); PSU2 = PSU2 + 1;
                VOIP1 = Convert.ToInt32(VOIP11); VOIP1 = VOIP1 + 1;
                VOIP2 = Convert.ToInt32(VOIP22); VOIP2 = VOIP2 + 1;
                Eth1 = Convert.ToInt32(Eth11); Eth1 = Eth1 + 1;
                Eth2 = Convert.ToInt32(Eth22); Eth2 = Eth2 + 1;
                Eth3 = Convert.ToInt32(Eth33); Eth3 = Eth3 + 1;
                Eth4 = Convert.ToInt32(Eth44); Eth4 = Eth4 + 1;
                USB = Convert.ToInt32(USB1); USB = USB + 1;
                Writemaintain(RF1.ToString(), RF2.ToString(), PSU1.ToString(), PSU2.ToString(), VOIP1.ToString(), VOIP2.ToString(), Eth1.ToString(), Eth2.ToString(), Eth3.ToString(), Eth4.ToString(), USB.ToString());
                StreamReader loadinfor2 = new StreamReader(pathfile2, Encoding.UTF8);
                string Datacount = loadinfor2.ReadToEnd();
                loadinfor2.Close();
                msg("Cuont Maintance Equipment: \n" + Datacount);
                if (Timee3 < Timee2 & Timee3 > Timee1)
                {
                    if (RF1 > 3000 | RF2 > 3000)
                    {
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RF cable");
                        if (RF1 > 3000 | RF2 > 3100)
                        {
                            return false;
                        }
                    }
                    if (Eth1 > 4400 | Eth2 > 4400 | Eth3 > 4400 | Eth4 > 4400)
                    {
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RJ45 cable");
                        if (Eth1 > 4700 | Eth2 > 4700 | Eth3 > 4700 | Eth4 > 4700)
                        {
                            return false;
                        }
                    }
                    if (PSU1 > 5000 | PSU2 > 5000)
                    {
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                        PSU");
                        if (PSU1 > 5000 | PSU2 > 5000)
                        {
                            //return false;
                        }
                    }
                    if (VOIP1 > 5000 | VOIP2 > 5000)
                    {
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RJ11 Cable");
                        if (PSU1 > 5000 | PSU2 > 5000)
                        {
                            //return false;
                        }
                    }
                    if (USB > 5000)
                    {
                      
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    USB_Type_C");
                        if (USB > 5000)
                        {
                            //return false;
                        }
                    }
                    return true;
                }
                else { return true; }
            }
            catch
            {
                Writemaintain(RF1.ToString(), RF2.ToString(), PSU1.ToString(), PSU2.ToString(), VOIP1.ToString(), VOIP2.ToString(), Eth1.ToString(), Eth2.ToString(), Eth3.ToString(), Eth4.ToString(), USB.ToString());
                return true;
            }
            return a;
        }
        private bool ChecklockpcPUS()
        {
            bool a = false;
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 5:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);
            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
                StreamReader loadinfor = new StreamReader(pathfile1, Encoding.UTF8);
                string status = loadinfor.ReadToEnd();
                loadinfor.Close();
                string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
                StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                string key = loadinfor1.ReadToEnd().Trim();
                loadinfor1.Close();
                if (key.Contains("PSU"))
                {
                    checkstatus();
                    MyMessagesBox.Show("\n                  WARNING!!! \nPls.Gọi kỹ sư Online QE sử ly lỗi!\n\n            ERROR=> " + key);
                    Login_Lock lock1 = new Login_Lock();
                    lock1.Show();
                    return false;
                }
                else { return true; }
            }
            catch { }
            return a;
        }
        private bool Checklockpc()
        {
            bool a = false;
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 5:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);
            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
                StreamReader loadinfor = new StreamReader(pathfile1, Encoding.UTF8);
                string status = loadinfor.ReadToEnd();
                loadinfor.Close();
                string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
                StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                string key = loadinfor1.ReadToEnd().Trim();
                loadinfor1.Close();
                if (Timee3 < Timee2 & Timee3 > Timee1 & status.Contains("lock"))
                {
                    checkstatus();
                    MyMessagesBox.Show("\n                  WARNING!!! \nPls.Gọi kỹ sư Online QE sử ly lỗi!\n\n            ERROR=> " + key);
                    Login_Lock lock1 = new Login_Lock();
                    lock1.Show();
                    return false;
                }
                else { return true; }
            }
            catch { }
            return a;
        }
        private bool Checklockpcmantance()
        {
            bool a = false;
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 5:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);
            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;
            string pathfile = Directory.GetCurrentDirectory() + "\\maintain.txt";
            string pathfile1 = Directory.GetCurrentDirectory() + "\\maintainRF.txt";
            string pathfile2 = Directory.GetCurrentDirectory() + "\\maintainRJ45.txt";
            try
            {
                string maintainRF = File.ReadLines(pathfile1).Skip(0).Take(1).First().Trim();
                string maintainRJ45 = File.ReadLines(pathfile2).Skip(0).Take(1).First().Trim();              
                if (Timee3 < Timee2 & Timee3 > Timee1)
                {
                    if (Convert.ToInt32(maintainRF) > 3000)
                    {
                        txtUser.Enabled = true;
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RF cable");
                        if (Convert.ToInt32(maintainRF) > 3050)
                        {
                            MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RF cable");
                            return false;
                        }
                    }
                    if (Convert.ToInt32(maintainRJ45) > 4400)
                    {
                        txtUser.Enabled = true;
                        MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RJ45 cable");
                        if (Convert.ToInt32(maintainRJ45) > 4700)
                        {
                            MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RJ45 cable");
                            return false;
                        }
                    }
                    return true;
                }
                else { return true; }
            }
            catch { return true;}
            return a;
        }
        private bool Checklockpc1()
        {
            bool a = false;
            string cc = "3/2/2022 7:30:00 AM";
            string cc1 = "3/2/2022 5:30:00 PM";
            DateTime cc2 = DateTime.Now;
            DateTime ccc1 = Convert.ToDateTime(cc);
            DateTime ccc2 = Convert.ToDateTime(cc1);
            TimeSpan Timee1 = ccc1.TimeOfDay;
            TimeSpan Timee2 = ccc2.TimeOfDay;
            TimeSpan Timee3 = cc2.TimeOfDay;
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
                StreamReader loadinfor = new StreamReader(pathfile1, Encoding.UTF8);
                string status = loadinfor.ReadToEnd();
                loadinfor.Close();
                string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
                StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                string key = loadinfor1.ReadToEnd().Trim();
                loadinfor1.Close();
                if (Timee3 < Timee2 & Timee3 > Timee1 & status.Contains("lock"))
                {
                    checkstatus();
                    //MyMessagesBox.Show("\n                  WARNING!!! \nPls.Gọi kỹ sư Online QE sử ly lỗi!\n\n            ERROR=> " + key);
                    return false;
                }
                else { return true; }
            }
            catch { }
            return a;
        }
        private void checkstatus()
        {
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
                StreamReader loadinfor = new StreamReader(pathfile1, Encoding.UTF8);
                string status = loadinfor.ReadToEnd();
                loadinfor.Close();
                if(status.Contains("lock"))
                {

                    if (cmmType.InvokeRequired)
                    {
                        cmmType.Invoke(new Action(() =>
                        {
                            cmmType.SelectedIndex = 1;
                        }
                    ));
                    }
                    else
                    {
                        cmmType.SelectedIndex = 1;
                    }
                }
            }
            catch { }
        }
        private void Write(string key, string key2)
        {
            string a = DateTime.Now.ToString();
            string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
            string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
            try
            {
                FileStream fs;
                fs = new FileStream(pathfile, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine(key);
                write.Flush();
                fs.Close();

                FileStream fs1;
                fs1 = new FileStream(pathfile1, FileMode.Create);
                StreamWriter write1 = new StreamWriter(fs1, Encoding.UTF8);
                write1.WriteLine(a);
                write1.WriteLine(key2);
                write1.Flush();
                fs1.Close();
            }
            catch { }

        }
        private void adjusmicro()
        {
            var devcol = voip.findDeviceDetial("Mic");
            int level = 100;
            foreach (NAudio.CoreAudioApi.MMDevice dev in devcol)
            {
                try
                {
                    if(dev.State == NAudio.CoreAudioApi.DeviceState.Active && (dev.FriendlyName.ToLower().Contains("micro")))
                    {
                        var newvolume = (float)Math.Max(Math.Min(level, 100), 0) / (float)100;
                        dev.AudioEndpointVolume.MasterVolumeLevelScalar = newvolume;
                        msgPass("Adjust_volume_Microphone_100%");
                    }
                }
                catch {
                    msg("Error_Adjust_volume_Microphone");
                }
            }
        }
        private void adjusvolume()
        {
            var devcol = voip.findDeviceDetial("Speaker");
            int level = 100;
            foreach (NAudio.CoreAudioApi.MMDevice dev in devcol)
            {
                try
                {
                    if (dev.State == NAudio.CoreAudioApi.DeviceState.Active && (dev.FriendlyName.ToLower().Contains("speaker")))
                    {
                        var newvolume = (float)Math.Max(Math.Min(level, 100), 0) / (float)100;
                        dev.AudioEndpointVolume.MasterVolumeLevelScalar = newvolume;
                        msgPass("Adjust_volume_Speaker_100%");
                    }
                }
                catch {
                    msg("Error_Adjust_volume_Speaker");
                }
            }

        }
        private bool EnabelEthAll()
        {
            bool Resutl = false;
            cmn.openExe1(pathfile1, "enableEthAll-SV");
            double TimeStart = GettimeStart("Check_Enabel_Eth");
            delay(8000);
            bool Eth1 = false;
            bool Eth2 = false;
            bool Eth3 = false;
            bool Eth4 = false;
            bool Eth5 = false;
            for (int i = 0; i <= 5; i++)
            {
                string Output = "";
                cmd.CmdConnect();
                cmd.CmdWrite("ipconfig /allcompartments");
                Delay(500);
                Output = cmd.CmdRead();
                cmd.CmdWrite("exit");
                if (Eth1 == false)
                {
                    string statusEth1 = cmdNianreturnIP(Output, "status", "Eth1", "");
                    if (statusEth1.Contains("NoPort"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth1");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_NO_Card_1");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra Card mang Eth1");
                            return false;
                        }
                    }
                    else if (statusEth1.Contains("disconnected"))
                    {

                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth1");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_Connect_Card_1");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra kêt nôi Eth1");
                            return false;
                        }
                    }
                    else { Eth1 = true; }
                }
                if (Eth2 == false)
                {
                    string statusEth2 = cmdNianreturnIP(Output, "status", "Eth2", "");
                    if (statusEth2.Contains("NoPort"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth2");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_NO_Card_2");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra Card mang Eth2");
                            return false;
                        }
                    }
                    else if (statusEth2.Contains("disconnected"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth2");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_Connect_Card_2");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra kêt nôi Eth2");
                            return false;
                        }
                    }
                    else { Eth2 = true; }
                }
                if (Eth3 == false)
                {
                    string statusEth3 = cmdNianreturnIP(Output, "status", "Eth3", "");
                    if (statusEth3.Contains("NoPort"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth3");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_NO_Card_3");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra Card mang Eth3");
                            return false;
                        }
                    }
                    else if (statusEth3.Contains("disconnected"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth3");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_Connect_Card_3");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra kêt nôi Eth3");
                            return false;
                        }
                    }
                    else { Eth3 = true; }
                }
                if (Eth4 == false)
                {
                    string statusEth4 = cmdNianreturnIP(Output, "status", "Eth4", "");
                    if (statusEth4.Contains("NoPort"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth4");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_NO_Card_4");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra Card mang Eth4");
                            return false;
                        }
                    }
                    else if (statusEth4.Contains("disconnected"))
                    {
                        if (i == 2)
                        {
                            cmn.openExe1(Directory.GetCurrentDirectory(), "ResetEth4");
                            delay(5000);
                        }
                        if (i >= 4)
                        {
                            ErrorNian("Err_Connect_Card_4");
                            MyMessagesBox.Show("\n\nPls! Kiểm tra kêt nôi Eth4");
                            return false;
                        }
                    }
                    else { Eth4 = true; }
                }
                if (Eth1 == true & Eth2 == true & Eth3 == true & Eth4 == true)
                {
                    Resutl = true;
                    break;
                }
                else { delay(2000); }
            }
            for (int i = 0; i <= 30; i++)
            {
                long speed_number = cmn.EnabelEthAll();
                //if (speed_number == 11)
                //{
                //    // MyMessagesBox.Show("\n\n  Pls! Kiểm tra trạng thái Eth1");
                //    return false;
                //}
                //else if (speed_number == 22)
                //{
                //    // MyMessagesBox.Show("\n\n  Pls! Kiểm tra trạng thái Eth2");
                //    return false;
                //}
                //else if (speed_number == 33)
                //{
                //    // MyMessagesBox.Show("\n\n  Pls! Kiểm tra trạng thái Eth3");
                //    return false;
                //}

                //else if (speed_number == 44)
                //{
                //    // MyMessagesBox.Show("\n\n  Pls! Kiểm tra trạng thái Eth4");
                //    return false;
                //}
                if (speed_number == 55)
                {
                    MyMessagesBox.Show("\n\n Pls! Kiểm tra trạng thái Eth SERVER!");
                    if (i >= 2)
                    {
                        return false;
                    }
                }
                else
                {
                    Resutl = true;
                    break;
                }
            }
            double TimeEnd = GettimeEnd("Check_Enabel_Eth");
            statusEth = CountTime("Check_Enabel_Eth", TimeStart, TimeEnd);
            return Resutl;
        }
        private bool EnabelEthAllDHCP()
        {
            bool Resutl = false;
            double TimeStart = GettimeStart("Check_Eth_DHCP");
            bool Eth1 = false;
            bool Eth2 = false;
            bool Eth3 = false;
            bool Eth4 = false;
            for (int i = 0; i <= 20; i++)
            {
                string Output = "";
                cmd.CmdConnect();
                cmd.CmdWrite("ipconfig /allcompartments");
                Delay(500);
                Output = cmd.CmdRead();
                cmd.CmdWrite("exit");
                //if (Eth1 == false)
                //{
                //    string statusEth1 = cmdNianreturnIP("IP", "Eth1");
                //    if (statusEth1.Contains(iptestEth1))
                //    {
                //        Eth1 = true;
                //    }
                //    else
                //    {
                //        cmn.openExe1(pathfile1, "SetDHCP" + model + "Eth1");
                //        if (i >= 5)
                //        {
                //            MyMessagesBox.Show("\n\nPls! Kiểm tra IP Eth1");
                //        }
                //        if (i >= 10)
                //        {
                //            return false;
                //        }
                //    }
                //}
                if (Eth2 == false)
                {
                    string statusEth2 = cmdNianreturnIP(Output, "IP", "Eth2", "");
                    if (statusEth2.Contains(iptestEth2))
                    {
                        Eth2 = true;
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "SetDHCPEth2");
                        if (i == 2)
                        {
                            MyMessagesBox.Show("\n\nPls! Kiểm tra IP Eth2");
                        }
                        if (i >= 5)
                        {
                            ErrorNian("Err_IP_Card_2");
                            return false;
                        }
                    }
                }
                if (Eth3 == false)
                {
                    string statusEth3 = cmdNianreturnIP(Output, "IP", "Eth3", "");
                    if (statusEth3.Contains(iptestEth3))
                    {
                        Eth3 = true;
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "SetDHCPEth3");
                        if (i == 2)
                        {
                            MyMessagesBox.Show("\n\nPls! Kiểm tra IP Eth3");
                        }
                        if (i >= 5)
                        {
                            ErrorNian("Err_IP_Card_3");
                            return false;
                        }
                    }
                }
                if (Eth4 == false)
                {
                    string statusEth4 = cmdNianreturnIP(Output, "IP", "Eth4", "");
                    if (statusEth4.Contains(iptestEth4))
                    {
                        Eth4 = true;
                    }
                    else
                    {
                        cmn.openExe1(pathfile1, "SetDHCPEth4");
                        if (i == 2)
                        {
                            MyMessagesBox.Show("\n\nPls! Kiểm tra IP Eth4");
                        }
                        if (i >= 5)
                        {
                            ErrorNian("Err_IP_Card_4");
                            return false;
                        }
                    }
                }
                if (Eth2 == true & Eth3 == true & Eth4 == true)
                {
                    Resutl = true;
                    break;
                }
                else { delay(2000); }
            }
            double TimeEnd = GettimeEnd("Check_Eth_DHCP");
            DHPCIP = CountTime("Check_Eth_DHCP", TimeStart, TimeEnd);
            return Resutl;
        }
        public void dunDAta(TextBox txtLogin_Lock)
        {
            string a = txtUser.Text;  
        }

        private void button20_Click(object sender, EventArgs e)
        {
            thStattus1 = true;

            ERR_CODE = "FEASA1";
            Checklockpcduperr(ERR_CODE);
            Write(ERR_CODE, "lock");
            // CheckLed_OnlineNian();
            // countmaintain();
            // GetLanMacNian();
            //CheckLed_WPSNian(1);
            //if (!GetSN()) return;
            //string Result = socket_string("SN");
            //msg(Result);
            // string y = cmdNianreturnIP("IP", "SFC","IP");
            // y = "";

            //    if (playfile("AudioTest.mp3")) ;
            //  countmaintain();



            //UnlockMaintanice.Show("           Reset Count Maintenance!!!");
            //if(UnlockMaintanice.RF1 == true)
            //{

            //}
            //UnlockMaintanice.id = "";

            //if (!CheckVoipP1toP2Nian()) { dkvoipretest = true; StatusERR("CheckVoipP1toP2"); return; }
            //if (!noiseTest("P1toP2")) { dkvoipretest = true; StatusERR("noiseTestP1toP2"); return; }
            //double TimeEnd = GettimeEnd("VOIP1");
            //double TimeStart1 = GettimeStart("VOIP2");
            //Status4("CHECK P2 >> P1 VOIP");
            //if (!CheckVoipP2toP1Nian()) { dkvoipretest = true; StatusERR("CheckVoipP2toP1"); return; }
            // if (!noiseTest("P2toP1")) { dkvoipretest = true; StatusERR("noiseTestP2toP1"); return; }




            //analisVoip();
            // EnabelEthAll();
            // CheckLed_OnlineNian();
            //if (!Check_speed("All", "100")) return;
            // if (!Check_speed("All", "1000")) return;
            //if (!EnabelEthAll()) return;
            //  EnabelEthAllDHCP();

            //Preparevoip();
            //cmn.kill("GrabBarcode");
            //cmn.kill("GrabLabelXB8");
            // thrMultVOIP();
            // EnabelEthAll();
            // EnabelEthAllDHCP();


            //checkDHCP();
            //countmaintain();
            //string y= cmdNianreturnIP("status","Eth5");
            //if (y.Contains(""))
            //{ }

            //MyMessagesBox.Show("\n                  WARNING!!! \n Pls.Gọi kỹ sư Online QE sửa chưa \n                    RF cable");
            // Checklockpcmantance();
            //MoveFileVoip1("nsTest.mp3", "1", "FAIL", VoiP2P1Again);
            //  MyMessagesBox.Show("\n\n      Bản chưa bootup thành công\n          Đợi thêm thời gian!!!");
            // thStattus1 = true;
            //string date = DateTime.Now.TimeOfDay.Hours.ToString() + "h" + DateTime.Now.TimeOfDay.Minutes.ToString() + "p" + DateTime.Now.TimeOfDay.Seconds.ToString() + "s";
            // CheckLed_OnlineNian();
            //adjusmicro();
            //adjusvolume();
            //WriteCPU("STATUS=STOP");
            //MoveFileVoip1("nsTest.mp3", "", "FAIL", VoiP2P1Again);
            //checkstatus();
            //Write("PVOIP0", "lock");
            //Checklockpc();
            // GetInfLable();
            //cmn.kill("msedge");
            //timVoip.Enabled = true;
            //comCmd("open_on");
            //comCmd("open_on");
            //comCmd("open");
            //comCmd("open");
            //getLanMacNian();
            // GetSN();
            //CheckLed_WPSNian();
            // CheckLed_OnlineNian(); if (!GetSN()) return;
            //if (!GetSN()) return;
           // WebAutoNian();
            //  GetInfLable();
            //CheckLed_WPSNian();
            //    CheckLed_OnlineNian();
            //  if (!GetSN()) return; 
            // if (!CheckLed_USB_C()) { StatusERR("Fail_LED_USB"); return; }
            //   socket_string("SN");
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
        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void txtComFB_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void enableOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void disableStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enableStautsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void configSampleZBBLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMessagesBox.Show("\n\nKhởi động lại Sample ZB-BLE\n          chờ khởi động 5 phút!!");
            groupBox2.Visible = true;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if(cmbcomzble.Text.Length < 3)
            {
                MessageBox.Show("Hãy chọn COM !!!!  "); return;
            }
            try
            {
                if (!ComZBLE.IsOpen)
                {
                    ComZBLE.PortName = cmbcomzble.Text.ToString();
                    serial.Close();
                    ComZBLE.BaudRate = Convert.ToInt32("115200");
                    ComZBLE.DataBits = 8;
                    ComZBLE.Parity = Parity.None;
                    ComZBLE.StopBits = StopBits.One;
                    ComZBLE.DataReceived += new SerialDataReceivedEventHandler(DataReceived_ZBBLE);
                    ComZBLE.Open();
                }
                else
                {
                    //Next
                    ComZBLE.PortName = cmbcomzble.Text.ToString();
                    ComZBLE.BaudRate = Convert.ToInt32("115200");
                    ComZBLE.DataBits = 8;
                    ComZBLE.Parity = Parity.None;
                    ComZBLE.StopBits = StopBits.One;
                    ComZBLE.DataReceived += new SerialDataReceivedEventHandler(DataReceived_ZBBLE);
                    ComZBLE.Open();
                }
                delay(20000);
                ReSet_and_Setting_Sample();
                ComZBLE.Close();
            }
            catch
            {
                MyMessagesBox.Show("\n\n  Config Sample thất bại! ");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

        }

        private void txtinfoDUT_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbcomzble.Text.Length < 3)
            {
                MessageBox.Show("Hãy chọn COM !!!!  "); return;
            }
            try
            {
                if (!ComZBLE.IsOpen)
                {
                    ComZBLE.PortName = cmbcomzble.Text.ToString();
                    serial.Close();
                    ComZBLE.BaudRate = Convert.ToInt32("115200");
                    ComZBLE.DataBits = 8;
                    ComZBLE.Parity = Parity.None;
                    ComZBLE.StopBits = StopBits.One;
                    ComZBLE.DataReceived += new SerialDataReceivedEventHandler(DataReceived_ZBBLE);
                    ComZBLE.Open();
                }
                else
                {
                    //Next
                    ComZBLE.PortName = cmbcomzble.Text.ToString();
                    ComZBLE.BaudRate = Convert.ToInt32("115200");
                    ComZBLE.DataBits = 8;
                    ComZBLE.Parity = Parity.None;
                    ComZBLE.StopBits = StopBits.One;
                    ComZBLE.DataReceived += new SerialDataReceivedEventHandler(DataReceived_ZBBLE);
                    ComZBLE.Open();
                }
                delay(1000);
                ReSet_and_Setting_Samplezigbee();
                ComZBLE.Close();
            }
            catch
            {
                MyMessagesBox.Show("\n\n  Config Sample thất bại! ");
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testNOISEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Result = socket_string("LABEL");
            msg(Result);
        }

        private void ledonlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Result = socket_string("ONLINE");
            msg(Result);
        }

        private void ledWPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Result = socket_string("WPS");
            msg(Result);
        }

        private void ledEthGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket_bool("GREEN");
        }

        private void ledEthRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket_bool("RED");
        }

        private void sNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Result = socket_string("SN");
            msg(Result);
        }

        private void uSPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket_bool(keyusbc);
        }

        private void cmmType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmmType.ForeColor = Color.Red;
            //lbl_Type.Text = "Type: Warning!!!";
            // lbl_Type.ForeColor = Color.Red;
            btnStart.ForeColor = Color.Red;
            btnStart.BackColor = Color.Yellow;
            cmmType.Enabled = false;
        }

        private void sampleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bootupToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            //if (!btnOpenCom.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            //{
            //    MyMessagesBox.Show("\n\n              Setting Program!!!");
            //    btnOpenCom.Text = ("Connect");
            //    btnOpenCom.Enabled = true;
            //    cmmType.Enabled = true;
            //    return;
            //}
            //msg("OP testing --> " + OP);
            //// MyMessagesBox.Show("\n\n      Chọn Model !!");
            //if (!GetSN()) return;
            //if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); return;}
            ////ThreadStart socket_SFC = new ThreadStart(Terminal_SFC);
            ////Thread_SFC = new Thread(socket_SFC);
            ////Thread_SFC.IsBackground = true;
            ////Thread_SFC.Start();
            ////delay(6000);

            //Send_ErrCode("FBOTUP", "Error_Bootup_Issue");
            //delay(1000);
            //Send_ErrCode("FBOTUP", "Error_Bootup_Issue");
            //LogFile("FAIL", "FBOTUP");
            //LogFileFail("Error_Bootup_Issue", "FBOTUP");
            //LogFilePassNian("FAIL", "FBOTUP");
        }

        private void rFQA11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmmType.Enabled = true;
            VoipAgain = true;
            Type_Program = "ON";
            File.Delete(Directory.GetCurrentDirectory() + "\\SNtest.txt");

        }

        private void takeDataNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thStattus1 = true;
            VoipAgain = false;
            noiseVoipCountP2 = noiseVoipCountP1 = 100;
            if (!GetSN()) return;
            Status4("CHECK P1 >> P2 VOIP");
            if (!CheckVoipP1toP2Nian()) { dkvoipretest = true; StatusERR("CheckVoipP1toP2"); return; }
           // CallP1toP2nian();
            if (!noiseTest("P1toP2")) { dkvoipretest = true; StatusERR("noiseTestP1toP2"); return; }
            Status4("CHECK P2 >> P1 VOIP");
            if (!CheckVoipP2toP1Nian()) { dkvoipretest = true; StatusERR("CheckVoipP2toP1"); return; }
            //CallP2toP1Nian();
            if (!noiseTest("P2toP1")) { dkvoipretest = true; StatusERR("noiseTestP2toP1"); return; }
            LogFiledata(textBox1.Text);
            textBox1.Clear();
            Status4("CHECK VOIP COMPLETE");
        }

        private void rFCableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rJ45CableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unlockProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
                StreamReader loadinfor = new StreamReader(pathfile1, Encoding.UTF8);
                string status = loadinfor.ReadToEnd();
                loadinfor.Close();
                string pathfile2 = Directory.GetCurrentDirectory() + "\\Statuslockduperr.txt";
                StreamReader loadinfor2 = new StreamReader(pathfile2, Encoding.UTF8);
                string status2 = loadinfor2.ReadToEnd();
                loadinfor2.Close();
                if (status.Contains("lock") | status2.Contains("lock"))
                {
                    Login_Lock lock1 = new Login_Lock();
                    lock1.Show();
                }
                cmmType.Enabled = true;
            }
            catch { }
        }

        private void ledPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Result = socket_string("PHONE");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resrtcount240s = true;
            delay(1500);
            thMutiple10 = new Thread(new ThreadStart(Dut240));
            thMutiple10.IsBackground = true;
            thMutiple10.Start();
        }
        public void Dut240 ()
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
                    if(resrtcount240s == true) return;
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

        private void unlockMantanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string RF1 = "0";
            string RF2 = "0";
            string PSU1 = "0";
            string PSU2 = "0";
            string VOIP1 = "0";
            string VOIP2 = "0";
            string Eth1 = "0";
            string Eth2 = "0";
            string Eth3 = "0";
            string Eth4 = "0";
            string USB = "0";
            try
            {
                if (UnlockMaintanice.Show("           Reset Count Maintenance!!!") == DialogResult.OK)
                {
                    string data = UnlockMaintanice.id.ToUpper();
                    string date = DateTime.Now.TimeOfDay.Hours.ToString() + "h" + DateTime.Now.TimeOfDay.Minutes.ToString() + "p" + DateTime.Now.TimeOfDay.Seconds.ToString() + "s";
                    txtUser.Enabled = true;
                    string pathfile2 = Directory.GetCurrentDirectory() + "\\maintain.txt";
                    if (data.Length == 8)
                    {
                        RF1 = File.ReadLines(pathfile2).Skip(0).Take(1).First().Substring(4, File.ReadLines(pathfile2).Skip(0).Take(1).First().Length - 4).Trim();
                        RF2 = File.ReadLines(pathfile2).Skip(1).Take(1).First().Substring(4, File.ReadLines(pathfile2).Skip(1).Take(1).First().Length - 4).Trim();
                        PSU1 = File.ReadLines(pathfile2).Skip(2).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(2).Take(1).First().Length - 5).Trim();
                        PSU2 = File.ReadLines(pathfile2).Skip(3).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(3).Take(1).First().Length - 5).Trim();
                        VOIP1 = File.ReadLines(pathfile2).Skip(4).Take(1).First().Substring(7, File.ReadLines(pathfile2).Skip(4).Take(1).First().Length - 7).Trim();
                        VOIP2 = File.ReadLines(pathfile2).Skip(5).Take(1).First().Substring(7, File.ReadLines(pathfile2).Skip(5).Take(1).First().Length - 7).Trim();
                        Eth1 = File.ReadLines(pathfile2).Skip(6).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(6).Take(1).First().Length - 5).Trim();
                        Eth2 = File.ReadLines(pathfile2).Skip(7).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(7).Take(1).First().Length - 5).Trim();
                        Eth3 = File.ReadLines(pathfile2).Skip(8).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(8).Take(1).First().Length - 5).Trim();
                        Eth4 = File.ReadLines(pathfile2).Skip(9).Take(1).First().Substring(5, File.ReadLines(pathfile2).Skip(9).Take(1).First().Length - 5).Trim();
                        USB = File.ReadLines(pathfile2).Skip(10).Take(1).First().Substring(11, File.ReadLines(pathfile2).Skip(10).Take(1).First().Length - 11).Trim();
                        if (UnlockMaintanice.RF1 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "RF1\t" + RF1);
                            RF1 = "0";
                        }
                        if (UnlockMaintanice.RF2 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "RF2\t" + RF2);
                            RF2 = "0";
                        }
                        if (UnlockMaintanice.PSU1 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "PSU1\t" + PSU1);
                            PSU1 = "0";
                        }
                        if (UnlockMaintanice.PSU2 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "PSU2\t" + PSU2);
                            PSU2 = "0";
                        }
                        if (UnlockMaintanice.VOIP1 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "VOIP1\t" + VOIP1);
                            VOIP1 = "0";
                        }
                        if (UnlockMaintanice.VOIP2 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "VOIP2\t" + VOIP2);
                            VOIP2 = "0";
                        }
                        if (UnlockMaintanice.Eth1 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "Eth1\t" + Eth1);
                            Eth1 = "0";
                        }
                        if (UnlockMaintanice.Eth2 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "Eth2\t" + Eth2);
                            Eth2 = "0";
                        }
                        if (UnlockMaintanice.Eth3 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "Eth3\t" + Eth3);
                            Eth3 = "0";
                        }
                        if (UnlockMaintanice.Eth4 == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "Eth4\t" + Eth4);
                            Eth4 = "0";
                        }
                        if (UnlockMaintanice.USB_C == true)
                        {
                            logfileunlock(data + "\t" + date + "\t" + "USB_Type_C\t" + Eth4);
                            USB = "0";
                        }
                        Writemaintain(RF1.ToString(), RF2.ToString(), PSU1.ToString(), PSU2.ToString(), VOIP1.ToString(), VOIP2.ToString(), Eth1.ToString(), Eth2.ToString(), Eth3.ToString(), Eth4.ToString(), USB.ToString());
                    }
                    else
                    {
                        MyMessagesBox.Show("\n\n     Pls. Nhap ma nhan vien !!!");
                        return;
                    }
                }
            }
            catch
            {
                //RF1 = "0";
                //RF2 = "0";
                //PSU1 = "0";
                //PSU2 = "0";
                //VOIP1 = "0";
                //VOIP2 = "0";
                //Eth1 = "0";
                //Eth2 = "0";
                //Eth3 = "0";
                //Eth4 = "0";
                Writemaintain(RF1.ToString(), RF2.ToString(), PSU1.ToString(), PSU2.ToString(), VOIP1.ToString(), VOIP2.ToString(), Eth1.ToString(), Eth2.ToString(), Eth3.ToString(), Eth4.ToString(), USB.ToString());
            }
        }

        private void testOffLimneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Label_Test = false;
            checkWifiPasswordPass = true;
            cmmType.SelectedIndex = 1;
            cmmType.Enabled = false;
            msg("NO Check Label!!!!!");
        }

        private void unlockProgramToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void rFCableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void rJ45CableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void bugXLAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hidenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(button2.Visible == true)
            {
                button2.Visible = false;
            }
            else
            {
                button2.Visible = true;
            }
        }

        private void dUTTựKhởiĐộngLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btnOpenCom.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                btnOpenCom.Text = ("Connect");
                btnOpenCom.Enabled = true;
                cmmType.Enabled = true;
                return;
            }
            msg("OP testing --> " + OP);
            if (!GetSN()) return;
            if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); return; }
            delay(500);
            Send_ErrCode("FREBOT", "Error_Reboot_Issue");
            delay(500);
            Send_ErrCode("FREBOT", "Error_Reboot_Issue");
            LogFile("FAIL", "FREBOT");
            LogFileFail("Error_Reboot_Issue", "FREBOT");
            LogFilePassNian("FAIL", "FREBOT");
        }

        private void bootupTrongQuáTrìnhTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btnOpenCom.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                btnOpenCom.Text = ("Connect");
                btnOpenCom.Enabled = true;
                cmmType.Enabled = true;
                return;
            }
            msg("OP testing --> " + OP);
            if (!GetSN()) return;
            if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); return; }        
            Send_ErrCode("FBOTUP", "Error_Bootup_Issue");
            delay(1000);
            Send_ErrCode("FBOTUP", "Error_Bootup_Issue");
            LogFile("FAIL", "FBOTUP");
            LogFileFail("Error_Bootup_Issue", "FBOTUP");
            LogFilePassNian("FAIL", "FBOTUP");
        }

        private void bootupLầnĐầuCắmPSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btnOpenCom.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                btnOpenCom.Text = ("Connect");
                btnOpenCom.Enabled = true;
                cmmType.Enabled = true;
                return;
            }
            msg("OP testing --> " + OP);
            if (!GetSN()) return;
            if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); return; }
            delay(500);
            Send_ErrCode("FBOOTF", "Error_Bootup_First");
            delay(500);
            Send_ErrCode("FBOTUPF", "Error_Bootup_First");
            LogFile("FAIL", "FBOOTF");
            LogFileFail("Error_Bootup_First", "FBOOTF");
            LogFilePassNian("FAIL", "FBOOTF");

        }

        private void bootupSauKhiRTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!btnOpenCom.Text.Contains("Disconnect") | cmmType.SelectedIndex == 1)
            {
                MyMessagesBox.Show("\n\n              Setting Program!!!");
                btnOpenCom.Text = ("Connect");
                btnOpenCom.Enabled = true;
                cmmType.Enabled = true;
                return;
            }
            msg("OP testing --> " + OP);
            if (!GetSN()) return;
            if (!Check_SN(lbsndut.Text.Trim())) { StatusERR("Check_SN"); return; }
            delay(500);
            Send_ErrCode("FBOOTR", "Error_Bootup_After_RTD");
            delay(500);
            Send_ErrCode("FBOOTR", "Error_Bootup_After_RTD");
            LogFile("FAIL", "FBOOTR");
            LogFileFail("Error_Bootup_After_RTD", "FBOOTR");
            LogFilePassNian("FAIL", "FBOOTR");
        }

        private void geckoWebBrowser1_Click_2(object sender, EventArgs e)
        {

        }

        private void grLogin_Enter(object sender, EventArgs e)
        {

        }

        private void wEBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thStattus1 = true;
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

        private void button22_Click(object sender, EventArgs e)
        {
            ReSet_and_Setting_Sample();
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
    }
}
