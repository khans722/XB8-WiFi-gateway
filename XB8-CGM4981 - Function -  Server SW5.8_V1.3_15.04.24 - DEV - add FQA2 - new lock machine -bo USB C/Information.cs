using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatic
{
    class Information
    {
        
        private Common common = new Common();
        private string login;
        public bool step1, step2, step3, step4, step5, step6, step7, step8, step9, step10,
            step11, step12, step13, step14, step15, step16, step17, step18, step19;
        private string ipaddress;
        public string ipAddress
        {
            get { return ipaddress = "10.0.0.1"; }
        }
        private string ipaddress1;
        public string ipAddress1
        {
            get { return ipaddress1 = "10.0.45.1"; }
        }
        private string ipcmts;
        public string Ipcmts
        {
            get { return ipcmts = "172.21.25.241"; }
        }
        private string ipMoca;
        public string IpMoca
        {
            get { return ipMoca = "10.0.0.187"; }
        }
        private string ipMoca2;
        public string IpMoca2
        {
            get { return ipMoca2 = "10.0.0.187"; }
        }
        //eth 
        private string eths;
        public string Eths
        {
            get { return eths = "Link is up";}
        }
        public string Login
        {
            get { return login = "root@vodafone:~#"; }
        }
        private string loginLock;
        public string LoginLock
        {
            get { return loginLock = "root@vodafone:~#"; }
        }
        //information
        private string infor;
        public string Infor
        {
            get { return infor = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.63.20.104; SW_REV: CGM4331COM_3.11s20_PROD_sey; MODEL: CGM4331COM>>" + "\r\n"; }
        }
        private string infor1;
        public string Infor1
        {
            get { return infor1 = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.63.20.104; SW_REV: CGM4331COM_3.11s20_PROD_sey; MODEL: CGM4331COM>>" + "\r\n"; }
        }
        private string infor_EMMC;
        public string Infor_EMMC
        {
            get { return infor_EMMC = "Technicolor DOCSIS 3.1 2-PORT Voice Wireless Gateway <<HW_REV: 2.0; VENDOR: Technicolor; BOOTR: S1TC-3.63.20.104; SW_REV: CGM4331COM_3.11s20_PROD_sey; MODEL: CGM4331COM>>" + "\r\n"; }
        }
        private string swname;
        public string SWSpec
        {
            get { return swname = "'17.4.0236-2441004-20180413102115-e6fa6365e30352b95e80837d940d633ac9f422f4'"; }
        }
        private string hwname;
        public string HWSpec
        {
            get { return hwname = "'VBNT-6'"; } 
        }
        private string modename;
        public string Modename
        {
            get { return modename = "'THG3000g'"; }
        }
        private string tchname;
        public string Tchname
        {
            get { return tchname = "'Vodafone'"; }
        }
        private string bootload;
        public string Bootload
        {
            get { return bootload = "'18.01.1069-0000000-20180104100219-80251de8e138b5b20ab6bb1abc923316ec745284'"; }
        }
        private int chipId;
        public int ChipId
        {
            get { return chipId = 8; }
        }
        private string snStart;
        public string SnStart
        {
            get { return snStart = "serial="; }
        }
        private string macStart;
        public string MacStart
        {
            get { return macStart = "eth_mac="; }
        }
        private string oui;
        public string Oui
        {
            get { return oui = "var.oui='"; }
        }
        private string imei;
        public string Imei
        {
            get { return imei = "software_version"; }
        }
        private string imei1;
        public string Imei1
        {
            get { return imei1 = "imei"; }
        }
        private string imei2;
        public string Imei2
        {
            get { return imei2 = "\""; }
        }
        private string ssid2g;
        public string Ssid2G
        {
            get { return ssid2g = "wireless.wl0.ssid="; }
        }
        private string ssid5g;
        public string Ssid5G
        {
            get { return ssid5g = "wireless.wl1.ssid="; }
        }
        private string wifikey2g;
        public string Wifikey2g
        {
            get { return wifikey2g = "wireless.ap0.wpa_psk_key="; }
        }
        private string wifikey5g;
        public string Wifikey5g
        {
            get { return wifikey5g = "wireless.ap1.wpa_psk_key="; }
        }
        private string passwordLable;
        public string PasswordLable
        {
            get { return passwordLable = "access_key"; }
        }
        ////USB
        private string usbvalue1;
        public string Usbvalue1
        {
            get { return usbvalue1 = "/dev/sda1"; }
        }
        private string usbvalue2;
        public string Usbvalue2
        {
            get { return usbvalue2 = "/dev/sda"; }
        }
        private string usbvalue3;
        public string Usbvalue3
        {
            get { return usbvalue3 = "/dev/sdb1"; }
        }
        private string usbvalue4;
        public string Usbvalue4
        {
            get { return usbvalue4 = "/dev/sdc"; }
        }
        //XDSL
        private string adsl15kChannel;
        public string Adsl15kChannel
        {
            get { return adsl15kChannel = "Channel:"; }
        }
        private string upstream;
        public string Upstream
        {
            get { return upstream = "Upstream rate ="; }
        }
        private string downstream;
        public string Downstream
        {
            get { return downstream = "Downstream rate ="; }
        }
        private float usSpecADSL15k;
        public float UsSpecADSL15k
        {
            get { return usSpecADSL15k = 640; }
        }
        private float dsSpecADSL15k;
        public float DsSpecADSL15k
        {
            get { return dsSpecADSL15k = 1980; }
        }
        //Gfat
        private string gfatkBearer;
        public string GfatkBearer
        {
            get { return gfatkBearer = "Bearer:"; }
        }
        private string gfatupstream;
        public string Gfatupstream
        {
            get { return gfatupstream = "Upstream rate ="; }
        }
        private string gfatdownstreamstream;
        public string Gfatdownstreamstream
        {
            get { return gfatdownstreamstream = "Downstream rate ="; }
        }
        private float usSpecGfat;
        public float UsSpecGfat
        {
            get { return usSpecGfat = 60000; }
        }
        private float dsSpecGfat;
        public float DsSpecGfat
        {
            get { return dsSpecGfat = 250000; }
        }
        //vdsl
        private string vdsl35bBearer;
        public string Vdsl35bBearer
        {
            get { return vdsl35bBearer = "Bearer:"; }
        }
        private string vdsl35bupstream;
        public string Vdsl35bupstream
        {
            get { return vdsl35bupstream = "Upstream rate ="; }
        }
        private string vdsl35bdownstreamstream;
        public string Vdsl35bdownstreamstream
        {
            get { return vdsl35bdownstreamstream = "Downstream rate ="; }
        }
        private float usSpecVDSL35b;
        public float UsSpecVDSL35b
        {
            get { return usSpecVDSL35b = 48000; }
        }
        private float dsSpecVDSL35b;
        public float DsSpecVDSL35b
        {
            get { return dsSpecVDSL35b = 250000; }
        }
        // LTE simcard status
        private string lteSimCardStatus;
        public string LteSimCardStatus
        {
            get { return lteSimCardStatus ="ready"; }
        }
        private string ltePowemode;
        public string LtePowemode
        {
            get { return ltePowemode = "online"; }
        }
        private string wanPing;
        public string WanPing
        {
            get { return wanPing = "64 bytes from 192.168.100.1:"; }
        }
        private string buttonPress0;
        public string ButtonPress0
        {
            get { return buttonPress0 = "BTN_0"; }
        }
        private string buttonPress1;
        public string ButtonPress1
        {
            get { return buttonPress1 = "BTN_1"; }
        }
        private string buttonPress2;
        public string ButtonPress2
        {
            get { return buttonPress2 = "BTN_2"; }
        }
        //Thong tin log_file
        private string modelnameFile;
        public string ModelnameFile
        {
            get { return modelnameFile = "THG3000g"; }
        }
 
    }
}
