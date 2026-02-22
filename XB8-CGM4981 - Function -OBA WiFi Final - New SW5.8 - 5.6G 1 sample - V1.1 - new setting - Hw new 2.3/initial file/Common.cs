using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CmdApp;
using ICMPPing;
using System.Threading;
using System.IO;
namespace Automatic
{
    class Common
    {
        long startTick = 0;
        long endTick = 0;
        private cmdApp cmd = new cmdApp();
        private iCMPPing icmp = new iCMPPing();
        public List<string> list = new List<string>();
        public bool ethCardName(string EthName)
        {
            bool a = false;
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in nic.Where(b => b.OperationalStatus == OperationalStatus.Up))
            {
                //IPInterfaceProperties inf = n.GetIPProperties();
                string name = n.Name;
                if (name.Equals(EthName))
                {
                    delay(200);
                    a = true;
                    break;
                }
            }
            return a;
        }
        public void delay(int utime)
        {
            double star = Environment.TickCount;
            double delay = Environment.TickCount - star;
            while (delay < utime)
            {
                delay = Environment.TickCount - star;
                Application.DoEvents();
                //System.Threading.Thread.Sleep(150);
            }
        }
        public void date_TimeStart()
        {
            startTick = DateTime.Now.Ticks;
        }
        public string date_TimeEnd(string time)
        {
            string timeTest = "";
            endTick = DateTime.Now.Ticks;
            long tick = endTick - startTick;
            long seconds = tick / TimeSpan.TicksPerSecond;
            long milliseconds = tick / TimeSpan.TicksPerMillisecond;
            timeTest = time + "of:" + "Second:" + seconds.ToString() + "," + milliseconds.ToString();
            return timeTest;
        }
        public void controlEthCard(string EthCardNameEnable, string EthCardNameDisable)
        {
            cmd.CmdConnect();
            if (EthCardNameEnable.Equals(EthCardNameEnable))
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + EthCardNameEnable + "\"" + " ENABLED");//"\"Eth1\""
                cmd.CmdWrite("\r\n");
            }
            if (EthCardNameDisable.Equals(EthCardNameDisable))
           // else
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + EthCardNameDisable + "\"" + " DISABLED");//"\"Eth1\""
                cmd.CmdWrite("\r\n");   
            }
        }
        private string pingData;
        public string pingdata
        {
            get { return pingData; }
            set { pingData = value; }
        }
        public string pingToAddress(string ipaddress)
        {
            icmp.Ping(ipaddress);
            pingData = icmp.PingResult;
            return pingData;
        }
        private string eth1address;
        public string Eth1address
        {
            get { return eth1address; }
            set { eth1address = value; }
        }
        private string eth2address;
        public string Eth2address
        {
            get { return eth2address; }
            set { eth2address = value; }
        }
        private void switchSpeedofEthcard(string Eth,string value)
        {
            cmd.CmdConnect();
            delay(2000);
            if (Eth.Equals("Eth1")&&value.Equals("1000"))
            {
                string str1 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                cmd.CmdWrite(str1); //d 4 la=100 full, d 0 la auto,3 full 100
            }
            else if (Eth.Equals("Eth2") && value.Equals("1000"))
            {
                string str2 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                cmd.CmdWrite(str2); //d 4 la=100 full, d 0 la auto,full 100
            }
            if (Eth.Equals("Eth1") && value.Equals("100"))
            {
                string str3 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 3 /t REG_SZ /f";
                cmd.CmdWrite(str3); //d 4 la=100 full, d 0 la auto,full 100
            }
            else if (Eth.Equals("Eth2") && value.Equals("100"))
            {
                string str4 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 3 /t REG_SZ /f";
                cmd.CmdWrite(str4); //d 4 la=100 full, d 0 la auto,full 100
            }

            string k = "netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED";
            cmd.CmdWrite("netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED");
            delay(2000);
            cmd.CmdWrite("netsh interface set interface " + "\"" + Eth + "\"" + " ENABLED");
            delay(2000);
            cmd.CmdWrite("\r\n");
            delay(1000);
        }
        public long speedEth(string Eth, string value)
        {
            switchSpeedofEthcard(Eth, value);
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            long speed = 0;
            foreach (NetworkInterface n in nic.Where(a => a.OperationalStatus == OperationalStatus.Up))
            {
                //IPInterfaceProperties inf = n.GetIPProperties();
                string name = n.Name;
                if (name.Equals(Eth))
                {
                    speed = n.Speed / 1000000;
                }
            }
            return speed;
        }
        public List<string> loadFile(string filename)
        {
            
            string readFile = "";
            using (StreamReader reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\"+filename))
            {
                while ((readFile = reader.ReadLine()) != null)
                    list.Add(readFile);
            }
            return list;
        }
        public List<string> loadFileLanMac(string filename)
        {

            string readFile = "";
            list.Clear();
            if (File.Exists(@"C:\" + "\\" + filename))
            {
                using (StreamReader reader = new StreamReader(@"C:\" + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        list.Add(readFile);
                }
            }
            else
            {
                list.Add("no_file");
            }
            return list;
        }
        public List<string> loadFileLed(string pathfile, string filename)
        {

            
            string readFile = "";
            try
            {
                using (StreamReader reader = new StreamReader(pathfile + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        list.Add(readFile);
                }
            }
            catch
            { }
            return list;
        }
        public string get2ValueLoadfile(string keyStart1, string keyStart2)
        {
            string value = "";
            foreach (string va in list)
            {
                if (va.Contains(keyStart1)&&va.Contains(keyStart2))
                {
                    value = va;
                }
            }
            return value;
        }
        public string getValueLoadfile(string keyStart)
        {
            string value = "";
            foreach (string va in list)
            {
                if (va.Contains(keyStart))
                {
                    value = va.Substring(keyStart.Length, va.Length - keyStart.Length);
                }
            }
            return value;
        }
        public void openExe(string pathfile, string fileName)
        {
            try
            {
                cmd.CmdConnect();
                delay(2000);
                cmd.RunExe(pathfile, fileName);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public bool deleteFile(string path,string filename)
        {
            bool a = false;
            path = path + filename;
            for (int i = 0; i < 5; i++)
            {

                if (File.Exists(path))
                {
                    File.Delete(path);
                    a = true;        
                    delay(1000);
                    break;
                }
            }
            return a;
        }
        public bool ExitFile(string filename)
        {
            bool a = false;
            string path = Directory.GetCurrentDirectory() + "\\" + filename;
            if (File.Exists(path))
            {
                
                a = true;
            }
            return a;
        }
        public bool ExitFile1(string pathfile, string filename)
        {
            bool a = false;
            string path = pathfile + "\\" + filename;
            for (int i = 0; i < 5; i++)
            {
                if (File.Exists(path))
                {

                    a = true;
                    break;
                }
                delay(1000);
            }
            return a;
        }
        public bool getLanMac()
        {
            bool a = false;
            string path=@"C:\";
            deleteFile(path, "arpa.txt");
            cmd.RunExe(System.IO.Directory.GetCurrentDirectory(), "arpa.bat");
            delay(1000);
            if(ExitFile(path))
            {
                loadFile(path);
                a = true;
            }
            return a;
        }
        
    }
}
