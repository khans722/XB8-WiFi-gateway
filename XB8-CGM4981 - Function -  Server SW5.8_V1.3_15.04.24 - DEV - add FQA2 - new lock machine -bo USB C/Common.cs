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
using System.Diagnostics;
namespace Automatic
{
    class Common
    {
        long startTick = 0;
        long endTick = 0;
        private cmdApp cmd = new cmdApp();
        private iCMPPing icmp = new iCMPPing();
        public List<string> list = new List<string>();
        public List<string> listSN = new List<string>();
         public int maintainCount = 0;
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
        public string cut(string databuffer, string start, string stop)  //chi su dung ham nay khi chuoi do la duy nhat tren databuffer
        {
            string result = "";
            if (!string.IsNullOrEmpty(databuffer))
            {
                try
                {
                    int data = databuffer.Length;
                    int istart = start.Length;
                    int value_start = istart + databuffer.IndexOf(start);
                    int value_stop = databuffer.IndexOf(stop) - value_start;
                    result = databuffer.Substring(value_start, value_stop);
                }
                catch { }
            }
            return result;
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
            /*cmd.CmdConnect();
            delay(2000);
            if (EthCardNameEnable.Equals(EthCardNameEnable))
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + EthCardNameEnable + "\"" + " ENABLED");//"\"Eth1\""
                delay(2000);
                //cmd.CmdWrite("\r\n");
            }
            if (EthCardNameDisable.Equals(EthCardNameDisable))
           // else
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + EthCardNameDisable + "\"" + " DISABLED");//"\"Eth1\""
                delay(2000);
               // cmd.CmdWrite("\r\n");   
            }
            if (EthCardNameEnable.Equals("enable") && EthCardNameDisable.Equals("enable"))
            // else
            {
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");//"\"Eth1\""
                delay(2000);
                cmd.CmdWrite("\r\n");
                cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " ENABLED");//"\"Eth1\""
                delay(2000);
               // cmd.CmdWrite("\r\n");
            }*/
        }
        public void EnableEthCard(string EthCardNameEnable)
        {
            try
            {
                
                if (EthCardNameEnable.Equals("Eth1Eth2Eth3Eth4"))
                {
                    cmd.CmdConnect();
                    delay(2000);
                    cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");//"\"Eth1\""
                    delay(2000);
                    cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " ENABLED");//"\"Eth1\""
                    delay(2000);
                    cmd.CmdWrite("\r\n");
                    delay(2000);
                    cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth3" + "\"" + " ENABLED");//"\"Eth3\""
                    delay(2000);
                    cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth4" + "\"" + " ENABLED");//"\"Eth4\""
                    delay(2000);
                    cmd.CmdWrite("\r\n");
                    delay(2000);
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("EnableEthCard:" + ex.Message);
            }

        }
        private string pingData;
        public string pingdata
        {
            get { return pingData; }
            set { pingData = value; }
        }
        Thread thMutiple5 = null;
        string ipaddress = "";
        public string pingToAddress(string ip)
        {
            icmp.PingResult = "";
            ipaddress = "";
            ipaddress = ip;
            thMutiple5 = new Thread(new ThreadStart(Pingcc));
            thMutiple5.IsBackground = true;
            thMutiple5.Start();
            delay(800);
            pingData = icmp.PingResult;
            return pingData;
        }
        private void Pingcc()
        {
            pingData = "";
            icmp.Ping(ipaddress);
           /// pingData = icmp.PingResult;
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
        private string eth3address;
        public string Eth3address
        {
            get { return eth3address; }
            set { eth3address = value; }
        }
        private string eth4address;
        public string Eth4address
        {
            get { return eth4address; }
            set { eth4address = value; }
        }
        private void switchSpeedofEthcard(string Eth,string value)
        {
            cmd.CmdConnect();
            delay(2000);
            if (Eth.Equals("Eth1") && value.Equals("1000"))
            {
                string str1 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                cmd.CmdWrite(str1); //d 4 la=100 full, d 0 la auto,3 half 100
            }
            else if (Eth.Equals("Eth2") && value.Equals("1000"))
            {
                string str2 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                cmd.CmdWrite(str2); //d 4 la=100 full, d 0 la auto,full 100
            }
            if (Eth.Equals("Eth1") && value.Equals("100"))
            {
                string str3 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 4 /t REG_SZ /f";
                cmd.CmdWrite(str3); //d 4 la=100 full, d 0 la auto,full 100
            }
            else if (Eth.Equals("Eth2") && value.Equals("100"))
            {
                string str4 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 4 /t REG_SZ /f";
                cmd.CmdWrite(str4); //d 4 la=100 full, d 0 la auto,full 100
            }
            if (Eth.Equals("Eth3") && value.Equals("100"))
            {
                string str5 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth3address + " /v *SpeedDuplex /d 4 /t REG_SZ /f";
                cmd.CmdWrite(str5); //d 4 la=100 full, d 0 la auto,full 100
            }
            else if (Eth.Equals("Eth3") && value.Equals("1000"))
            {
                string str6 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth3address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                cmd.CmdWrite(str6); //d 4 la=100 full, d 0 la auto,full 100
            }
            if (Eth.Equals("Eth4") && value.Equals("100"))
            {
                string str7 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth4address + " /v LinkSpeed /d 32 /t REG_SZ /f";
                cmd.CmdWrite(str7); //d 1 =10G, d 2 =5G, d 8 =2.5G, d 16 =1G, d 32= 100M, d 59 auto
            }
            else if (Eth.Equals("Eth4") && value.Equals("2500"))
            {
                string str8 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth4address + " /v LinkSpeed /d 59 /t REG_SZ /f";
                cmd.CmdWrite(str8); //d 1 =10G, d 2 =5G, d 8 =2.5G, d 16 =1G, d 32= 100M, d 59 auto
            }

            string k = "netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED";

            cmd.CmdWrite("netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED");
            delay(2000);
            cmd.CmdWrite("netsh interface set interface " + "\"" + Eth + "\"" + " ENABLED");
            delay(15000);
            cmd.CmdWrite("\r\n");
            delay(1000);
        }
        public void switchEthcard(string Eth, string value)
        {

            bool a = false;
            bool b = false;
            if (Eth.Equals("Eth1Eth2Eth3Eth4")&value.Equals("1000"))
            {
                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        cmd.CmdConnect();
                        delay(2000);
                        string k = "netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED";
                        string str1 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                        string str2 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                        string str3 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 0 /t REG_SZ /f";
                        string str4 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v LinkSpeed /d 59 /t REG_SZ /f";

                        cmd.CmdWrite(str1); //d 4 la=100 full, d 0 la auto,3 full 100
                        delay(1500);
                        cmd.CmdWrite(str2);
                        delay(1500);
                        cmd.CmdWrite(str3);
                        delay(1500);
                        cmd.CmdWrite(str4);//d 1 =10G, d 2 =5G, d 8 =2.5G, d 16 =1G, d 32= 100M, d 59 auto            
                        delay(1500);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " DISABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " DISABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth3" + "\"" + " DISABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth4" + "\"" + " DISABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " ENABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth3" + "\"" + " ENABLED");
                        delay(2000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth4" + "\"" + " ENABLED");
                        delay(2000);
                        //cmd.CmdWrite("\r\n");
                        delay(5000);
                        a = true;
                        if (a == true)
                        {
                            break;
                        }
                        else
                        {
                            if (i > 2)
                            {
                                MessageBox.Show("disable and enable Eth issue");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

               // delay(8000);
            }
            if (Eth.Equals("Eth1Eth2Eth3Eth4") & value.Equals("100"))
            {
               
                try
                {

                    for (int i = 0; i < 4; i++)
                    {
                        cmd.CmdConnect();
                        delay(2000);
                        string k = "netsh interface set interface " + "\"" + Eth + "\"" + " DISABLED";
                        string str1 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth1address + " /v *SpeedDuplex /d 3 /t REG_SZ /f";
                        string str2 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth2address + " /v *SpeedDuplex /d 3 /t REG_SZ /f";
                        string str3 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth3address + " /v *SpeedDuplex /d 3 /t REG_SZ /f";
                        string str4 = "reg add HKEY_LOCAL_MACHINE" + "\\" + "SYSTEM" + "\\" + "CurrentControlSet" + "\\" + "Control" + "\\" + "Class" + "\\" + "{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + Eth4address + " /v LinkSpeed /d 3 /t REG_SZ /f";
                        cmd.CmdWrite(str1); //d 4 la=100 full, d 0 la auto,3 full 100
                        delay(1500);
                        cmd.CmdWrite(str2);
                        delay(1500);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " DISABLED");
                        delay(1000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " DISABLED");
                        delay(1000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth1" + "\"" + " ENABLED");
                        delay(1000);
                        cmd.CmdWrite("netsh interface set interface " + "\"" + "Eth2" + "\"" + " ENABLED");
                        delay(1000);
                        //cmd.CmdWrite("\r\n");
                        delay(5000);
                        b = true;
                        if (b == true)
                        {
                            break;
                        }
                        else
                        {
                            if (i > 2)
                            {
                                MessageBox.Show("disable and enable Eth issue");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    //MessageBox.Show("disable and enable Eth issue" + ex.Message);
                }

                 delay(8000);
            }
        }
        public long speedEth(string Eth, string value)
        {
            long speed = 0;
            bool b = true;
            bool c=false;
            bool d=false;
            int count = 0;
            bool step11 = false;
            bool step22=false;
            while (b)
            {
                switchSpeedofEthcard(Eth, value);
               // delay(2000);
                NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface n in nic.Where(a => a.OperationalStatus == OperationalStatus.Up))
                {
                    //IPInterfaceProperties inf = n.GetIPProperties();
                    string name = n.Name;
                    if(Eth.Equals("Eth1Eth2"))
                    {
                        
                        if (name.Equals("Eth1"))
                        { 
                            speed = n.Speed / 1000000;
                            step11 = true;
                            
                            if (speed.ToString().Equals(value))
                            {
                                c = true;
                               
                            }
                        }
                        if (name.Equals("Eth2"))
                        {
                            speed = n.Speed / 1000000;
                            step22 = true;
                            if (speed.ToString().Equals(value))
                            {
                                d = true;
                                
                            }
                        }
                        if (step11&& step22 )
                        {
                            b = false;
                            break;
                        }
                    }
                    else if (name.Equals(Eth))
                    {
                        speed = n.Speed / 1000000;
                        b = false;
                        break;
                    }
                }
                if (step11 && step22)
                {
                    b = false;
                    break;
                }
                else
                {
                    delay(5000);
                    count++;
                    if (count > 4)
                    {
                       
                        b = false;
                    }
                }
            }
            if (!(c && d))
            {
                speed = 0;
            }
            return speed;
        }
        public long xb7speedEthAll(string Eth, string value)
        {
            string keyspeed = "speed1000All";
            long speed1 = 0;
            long speed2 = 0;
            long speed3 = 0;
            long speed4 = 0;
            bool b = true;
            int count = 0;
            bool step11 = false;
            bool step22 = false;
            bool step33 = false;
            bool step44 = false;
            if (value == "100")
            {
                keyspeed = "speed100All";
            }
            while (b)
            {
                NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nic.Where(a => a.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    string name = n.Name;
                    if (step11 == false)
                    {
                        if (name.Equals("Eth1"))
                        {
                            speed1 = n.Speed / 1000000;
                            if (speed1.ToString().Equals(value))
                            {
                                step11 = true;
                            }
                        }
                    }
                    if (step22 == false)
                    {
                        if (name.Equals("Eth2"))
                        {
                            speed2 = n.Speed / 1000000;
                            if (speed2.ToString().Equals(value))
                            {
                                step22 = true;
                            }
                        }
                    }
                    if (step33 == false)
                    {
                        if (name.Equals("Eth3"))
                        {
                            speed3 = n.Speed / 1000000;
                            if (speed3.ToString().Equals(value))
                            {
                                step33 = true;
                            }
                        }
                    }
                    if (step44 == false)
                    {
                        if (name.Equals("Eth4"))
                        {
                            speed4 = n.Speed / 1000000;
                            string sped4 = "100";
                            if (value.Equals("1000"))
                            {
                                sped4 = "2500";
                            }
                            if (speed4.ToString().Equals(sped4))
                            {
                                step44 = true;
                            }
                        }
                    }
                }
                if (step11 && step22 && step33 && step44)
                {
                    
                    b = false;
                    return speed1 + speed2 + speed3 + speed4;
                    //break;
                }
                else
                {
                    count++;
                    openExe1(Directory.GetCurrentDirectory(), keyspeed);
                    delay(500);
                    if (step11 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth1");
                        delay(7000);
                    }
                    if (step22 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth2");
                        delay(7000);
                    }
                    if (step33 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth3");
                        delay(7000);
                    }
                    if (step44 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth4");
                        delay(10000);
                    }
                    if (count > 2)
                    {
                        if (step11 == false) return 11;
                        else if (step22 == false) return 22;
                        else if (step33 == false) return 33;
                        else if (step44 == false) return 44;
                        b = false;
                    }
                }
            }
            return speed1 + speed2 + speed3 + speed4;
        }
        public string xb7speedEthAll_string(string Eth, string value)
        {
            string keyspeed = "speed1000All";
            long speed1 = 0;
            long speed2 = 0;
            long speed3 = 0;
            long speed4 = 0;
            bool b = true;
            int count = 0;
            bool step11 = false;
            bool step22 = false;
            bool step33 = false;
            bool step44 = false;
            if (value == "100")
            {
                keyspeed = "speed100All";
            }
            while (b)
            {
                NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nic.Where(a => a.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    string name = n.Name;
                    if (step11 == false)
                    {
                        if (name.Equals("Eth1"))
                        {
                            speed1 = n.Speed / 1000000;
                            if (speed1.ToString().Equals(value))
                            {
                                step11 = true;
                            }
                        }
                    }
                    if (step22 == false)
                    {
                        if (name.Equals("Eth2"))
                        {
                            speed2 = n.Speed / 1000000;
                            if (speed2.ToString().Equals(value))
                            {
                                step22 = true;
                            }
                        }
                    }
                    if (step33 == false)
                    {
                        if (name.Equals("Eth3"))
                        {
                            speed3 = n.Speed / 1000000;
                            if (speed3.ToString().Equals(value))
                            {
                                step33 = true;
                            }
                        }
                    }
                    if (step44 == false)
                    {
                        if (name.Equals("Eth4"))
                        {
                            speed4 = n.Speed / 1000000;
                            string sped4 = "100";
                            if (value.Equals("1000"))
                            {
                                sped4 = "2500";
                            }
                            if (speed4.ToString().Equals(sped4)) //sped4
                            {
                                step44 = true;
                            }
                        }
                    }
                }
                if (step11 && step22 && step33 && step44)
                {

                    b = false;
                    return "Eth1: " + speed1.ToString() + "\nEth2: " + speed2.ToString() + "\nEth3: " + speed3.ToString() + "\nEth4: " + speed4.ToString() + " PASS";
                    //break;
                }
                else
                {
                    count++;
                    openExe1(Directory.GetCurrentDirectory(), keyspeed);
                    delay(500);
                    if (step11 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth1");
                        delay(7000);
                    }
                    if (step22 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth2");
                        delay(7000);
                    }
                    if (step33 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth3");
                        delay(7000);
                    }
                    if (step44 == false)
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth4");
                        delay(7000);
                    }
                    if (count > 2)
                    {
                        return "Eth1: " + speed1.ToString() + "\nEth2: " + speed2.ToString() + "\nEth3: " + speed3.ToString() + "\nEth4: " + speed4.ToString();
                        b = false;
                    }
                }
            }
            return "Eth1: " + speed1.ToString() + "\nEth2: " + speed2.ToString() + "\nEth3: " + speed3.ToString() + "\nEth4: " + speed4.ToString();
        }
        public long EnabelEthAll()
        {
            long Ethenet = 1000;
            bool b = true;
            int count = 0;
            bool step11 = false;
            bool step22 = false;
            bool step33 = false;
            bool step44 = false;
            bool step55 = false;
            List<string> list = new List<string>();
            while (b)
            {
                list.Clear();
                NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface n in nic.Where(a => a.OperationalStatus == OperationalStatus.Up))
                {
                    string name = n.Name;
                    list.Add(name);
                }
                if (step11 == false)
                {
                    if (list.Contains("Eth1"))
                    {
                        step11 = true;
                    }
                    else
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth1");
                        delay(10000);
                    }
                }
                if (step22 == false)
                {
                    if (list.Contains("Eth2"))
                    {
                        step22 = true;
                    }
                    else
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth2");
                        delay(10000);
                    }
                }
                if (step33 == false)
                {
                    if (list.Contains("Eth3"))
                    {
                        step33 = true;
                    }
                    else
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth3");
                        delay(10000);
                    }
                }
                if (step44 == false)
                {
                    if (list.Contains("Eth4"))
                    {
                        step44 = true;
                    }
                    else
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEth4");
                        delay(15000);
                    }
                }
                if (step55 == false)
                {
                    if (list.Contains("SERVER"))
                    {
                        step55 = true;
                    }
                    else
                    {
                        openExe1(Directory.GetCurrentDirectory(), "ResetEthSever");
                        delay(10000);
                    }
                }
                if (step11 && step22 && step33 && step44 & step55)
                {
                    b = false;
                    break;
                }
                else
                {
                    count++;
                    if (count >= 2)
                    {
                        if (step11 == false) return 11;
                        else if (step22 == false) return 22;
                        else if (step33 == false) return 33;
                        else if (step44 == false) return 44;
                        else if (step55 == false) return 55;
                        b = false;
                    }
                }
            }
            return Ethenet;
        }
        public long speedEthCurrent(string Eth, string value)
        {
            long speed = 0;
            bool b = true;
            bool c = false;
            bool d = false;
            int count = 0;
            bool step11 = false;
            bool step22 = false;
               NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();

               foreach (NetworkInterface n in nic.Where(a => a.OperationalStatus == OperationalStatus.Up))
               {
                   //IPInterfaceProperties inf = n.GetIPProperties();
                   string name = n.Name;
                   if (Eth.Equals("Eth1Eth2"))
                   {

                       if (name.Equals("Eth1"))
                       {
                           speed = n.Speed / 1000000;
                           step11 = true;

                           if (speed.ToString().Equals(value))
                           {
                               c = true;

                           }
                       }
                       if (name.Equals("Eth2"))
                       {
                           speed = n.Speed / 1000000;
                           step22 = true;
                           if (speed.ToString().Equals(value))
                           {
                               d = true;

                           }
                       }
                       if (step11==true & step22==true)
                       {
                           b = false;
                           break;
                       }
                   }
               }
               if (!(c && d))
               {
                   speed = 0;
               }

            return speed;
        }
        public long xb7speedmoduleEth(string Eth, string value)
        {
            long speed = 0;
            bool b = true;
            bool c = false;
            bool d = false;
            bool e = false;
            bool f = false;
            int count = 0;
            bool step11 = false;
            bool step22 = false;
            bool step33 = false;
            bool step44 = false;
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in nic.Where(a => a.OperationalStatus == OperationalStatus.Up))
            {
                //IPInterfaceProperties inf = n.GetIPProperties();
                string name = n.Name;
                if (Eth.Equals("All"))
                {

                    if (name.Equals("All"))
                    {
                        speed = n.Speed / 1000000;
                        step11 = true;

                        if (speed.ToString().Equals(value))
                        {
                            c = true;

                        }
                    }
                    if (name.Equals("All"))
                    {
                        speed = n.Speed / 1000000;
                        step22 = true;
                        if (speed.ToString().Equals(value))
                        {
                            d = true;

                        }
                    }
                    if (name.Equals("All"))
                    {
                        speed = n.Speed / 1000000;
                        step33 = true;
                        if (speed.ToString().Equals(value))
                        {
                            d = true;

                        }
                    }
                    if (name.Equals("All"))
                    {
                        speed = n.Speed / 1000000;
                        step44 = true;
                        if (speed.ToString().Equals(value))
                        {
                            d = true;

                        }
                    }
                    if (step11 == true & step22 == true & step33 == true & step44 == true )
                    {
                        b = false;
                        break;
                    }
                }
            }
            if (!(c && d && e && f))
            {
                speed = 0;
            }

            return speed;
        }
        public List<string> loadFile(string filename)
        {
            string readFile = "";
            listSN.Clear();
            list.Clear();
            if (filename.Equals("SN.txt"))
            {
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                {
                    using (StreamReader reader1 = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                    {
                        while ((readFile = reader1.ReadLine()) != null)
                            listSN.Add(readFile);
                        reader1.Close();
                       
                    }
                }
                else
                {
                    listSN.Add("No Data");
                }
                return listSN;
            }
            else
            {               
                using (StreamReader reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        list.Add(readFile);
                }
                return list;
            }
        }
        public List<string> loadFileMaintan(string filename)
        {
            string readFile = "";
            listSN.Clear();
            list.Clear();
            if (filename.Equals("maintain.txt"))
            {
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                {
                    using (StreamReader reader1 = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                    {
                        while ((readFile = reader1.ReadLine()) != null)
                            maintainCount =Convert.ToInt16(readFile);
                        reader1.Close();

                    }
                }
                else
                {
                    listSN.Add("No Data");
                }
                return listSN;
            }
            else
            {

                using (StreamReader reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        list.Add(readFile);
                }
                return list;
            }
        }
        public List<string> loadFileNian(string filename)
        {
            string readFile = "";
            listSN.Clear();
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
            {
                using (StreamReader reader1 = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\" + filename))
                {
                    while ((readFile = reader1.ReadLine()) != null)
                        listSN.Add(readFile);
                    reader1.Close();
                }
            }
            else
            {
                listSN.Add("No_Data");
            }
            return listSN;
        }
        public List<string> loadFileLanMac(string filename,string IP)
        {
            string sIP = IP.Substring(0, IP.Length - 1);
            string readFile = "";
            list.Clear();
            if (File.Exists(@"C:\" + "\\" + filename))
            {
                bool dem = false;
                int i = 0;
                using (StreamReader reader = new StreamReader(@"C:\" + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        if (dem || (readFile.Contains(sIP) && readFile.Contains("---")))
                        {
                            dem = true;
                            i++;
                            if (i < 10)
                            {
                                list.Add(readFile);
                            }
                        }                      
                } 
            }
            else
            {
                list.Add("no_file");
            }
            return list;
        }
        string IpDUT = "";
        public List<string> loadFileLanMacNian(string filename, string IP, string iptestEth2, string iptestEth3, string iptestEth4)
        {
            IpDUT = "";
            string IPliss = IP.Substring(0, IP.Length - 1);
            string readFile = "";
            list.Clear();
            if (File.Exists(@"C:\" + "\\" + filename))
            {
                bool dem = false;
                int i = 0;
                int nofile = 0;
                using (StreamReader reader = new StreamReader(@"C:\" + "\\" + filename))
                {
                    while ((readFile = reader.ReadLine()) != null)
                        if (dem || (readFile.Contains(IPliss) && readFile.Contains("---") && (!readFile.Contains(iptestEth2) && (!readFile.Contains(iptestEth3) && (!readFile.Contains(iptestEth4))))))
                        {
                            dem = true;
                            i++;
                            if (i < 9)
                            {
                                list.Add(readFile);
                            }
                            else { return list;}
                        }
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
            list.Clear();
            int a = 0;
            while(a<3)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(pathfile + "\\" + filename))
                    {
                        while ((readFile = reader.ReadLine()) != null)
                        list.Add(readFile);
                        delay(100);
                        a = 4;
                    }                  
                }
                catch
                {
                    a++;
                }
            
            }
            return list;
        }
        public string get2ValueLoadfile(string keyStart1, string keyStart2)
        {
            string value = "";
            foreach (string va in list)
            {
               
                if (va.Contains(keyStart1) && va.Contains(keyStart2))
                {
                    value = va;
                    break;                   
                }
            }
            return value;
        }
        public string getValueLoadfile(string keyStart)
        {
            string value = "";
            try
            {
                foreach (string va in list)
                {
                    if (va.Contains(keyStart))
                    {
                        value = va.Substring(keyStart.Length, va.Length - keyStart.Length);
                    }
                }
            }
            catch { }
            return value;
        }
        public void openExe(string pathfile, string fileName)
        {
            try
            {
               // cmd.CmdConnect();
               // delay(000);
                cmd.RunExe(pathfile, fileName, 1000);
                delay(2000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + fileName);
            }
        }
        public void RunExe(string pathfile, string fileName)
        {
            string part = pathfile + "\\" + fileName + ".bat";
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = part;
                process.Start();
                //System.Diagnostics.Process.Start(part);
                delay(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + fileName);
            }

        }

        public void openExe1(string pathfile, string fileName)
        {
            try
            {
                //cmd.CmdConnect();
                delay(1000);
                RunExe(pathfile, fileName);
                //delay(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + fileName);
            }
        }
        public bool deleteFile(string path,string filename)
        {
            bool a = false;
            bool b = true;
            string pathred = path + filename;
            while (b)
            {
                try
                {                                 
                    if (File.Exists(pathred))
                    {
                        File.Delete(pathred);
                        delay(1000);
                        if(!File.Exists(pathred))
                        {
                            b = false;
                            a = true;
                        }                                                 
                    } 
                    else
                    {
                        if (!File.Exists(pathred))
                        {
                            b = false;
                            a = true;
                        }
                    }                           
                }
                catch
                {
                    try
                    {
                        File.Delete(pathred);
                    }
                    catch { return false; }
                  
                    if (!File.Exists(pathred))
                    {
                        b = false;
                        a = true;
                    }
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
            for (int i = 0; i <= 20; i++)
            {
                if (File.Exists(path))
                {
                    a = true;
                    return true;
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
            cmd.RunExe(System.IO.Directory.GetCurrentDirectory(), "arpa.bat",1000);
            delay(1000);
            if(ExitFile(path))
            {
                loadFile(path);
                a = true;
            }
            return a;
        }
        public void kill(string killName)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains( killName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(100);
                    }
                    catch
                    { }
                }
            }
        }
        public void killEdge(string killName)
        {
            foreach (Process p in Process.GetProcessesByName(killName))
            {
                if (p.ProcessName.Contains(killName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(100);
                    }
                    catch
                    { }
                }
            }
        }
        public bool killCheck(string killName)
        {
           bool a=false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains(killName))
                {
                    a = true;
                    break;
                }
            }
            return a;
        }
    }
}
