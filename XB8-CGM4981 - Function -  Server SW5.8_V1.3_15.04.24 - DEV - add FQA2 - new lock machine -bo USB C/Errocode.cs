using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatic
{
    class Errocode
    {
        //cong mang
        private string err_Eth1_Speed1G, err_Eth1_Speed100M, err_Eth1_Led_Green, err_Eth1_Led_Red, err_Eth1_Led_Yellow, err_Eth1_Ping, err_Eth_Speed100M, err_Eth_Speed1G;
        private string err_Eth2_Speed1G, err_Eth2_Speed100M, err_Eth2_Led_Green, err_Eth2_Led_Red, err_Eth2_Led_Yellow, err_Eth2_Ping;
        private string err_Eth3_Speed1G, err_Eth3_Speed100M, err_Eth3_Led_Green, err_Eth3_Led_Red, err_Eth3_Led_Yellow, err_Eth3_Ping;
        private string err_Eth4_Speed2_5G, err_Eth4_Speed100M, err_Eth4_Led_Green, err_Eth4_Led_Red, err_Eth4_Led_Yellow, err_Eth4_Ping;
        private string err_WAN_Speed1G, err_WAN_Speed100M, err_WAN_Led_Green, err_WAN_Led_Red, err_WAN_Led_Yellow, err_WAN_Ping;
         //eth1
        public string Err_Eth_Speed100M
        {
            get { return err_Eth_Speed100M = "Err_Eth_Speed100M"; }//Err_Eth1_Speed100M
        }
        public string Err_Eth1_Speed1G
        {
            get { return err_Eth1_Speed1G = "Err_Eth1_Speed1G"; } //Err_Eth1_Speed1G
        }
        public string Err_Eth1_Speed100M
        {
            get { return err_Eth1_Speed100M = "Err_Eth1_Speed100M"; }//Err_Eth1_Speed100M
        }
        public string Err_Eth1_Led_Green
        {
            get { return err_Eth1_Speed100M = "Err_Eth1_Speed100M"; }//Err_Eth1_Led_Green
        }
        public string Err_Eth1_Led_Red
        {
            get { return err_Eth1_Led_Red = "Err_Eth1_Led_Red"; }//Err_Eth1_Led_Red
        }
        public string Err_Eth1_Led_Yellow
        {
            get { return err_Eth1_Led_Yellow = "Err_Eth1_Led_Yellow"; }//Err_Eth1_Led_Yellow
        }
        public string Err_Eth1_Ping
        {
            get { return err_Eth1_Ping = "Err_Eth1_Ping"; }//Err_Eth1_Ping
        }    


        //eth2
        
        public string Err_Eth_Speed1G
        {
            get { return err_Eth_Speed1G = "Err_Eth_Speed1G"; }//Err_Eth_Speed1G
        }
        public string Err_Eth2_Speed1G
        {
            get { return err_Eth2_Speed1G = "Err_Eth2_Speed1G"; }//Err_Eth2_Speed1G
        }
        public string Err_Eth2_Speed100M
        {
            get { return err_Eth2_Speed100M = "Err_Eth2_Speed100M"; }//Err_Eth2_Speed100M
        }
        public string Err_Eth2_Led_Green
        {
            get { return err_Eth2_Led_Green = "Err_Check_Led_Green"; }//Err_Eth2_Led_Green
        }
        public string Err_Eth2_Led_Red
        {
            get { return err_Eth2_Led_Red = "Err_Check_Led_Red"; }//Err_Eth2_Led_Red
        }
        public string Err_Eth2_Led_Yellow
        {
            get { return err_Eth2_Led_Yellow = "Err_Eth2_Led_Yellow"; }//Err_Eth2_Led_Yellow
        }
        public string Err_Eth2_Ping
        {
            get { return err_Eth2_Ping = "Err_Eth2_Ping"; }//Err_Eth2_Ping
        }
        //eth3
        public string Err_Eth3_Speed1G
        {
            get { return err_Eth3_Speed1G = "Err_Eth3_Speed1G"; }//Err_Eth3_Speed1G
        }
        public string Err_Eth3_Speed100M
        {
            get { return err_Eth3_Speed100M = "Err_Eth3_Speed100M"; }//Err_Eth3_Speed100M
        }
        public string Err_Eth3_Led_Green
        {
            get { return err_Eth3_Led_Green = "Err_Eth3_Led_Green"; }//Err_Eth3_Led_Green
        }
        public string Err_Eth3_Led_Red
        {
            get { return err_Eth3_Led_Red = "Err_Eth3_Led_Red"; }//Err_Eth3_Led_Red
        }
        public string Err_Eth3_Led_Yellow
        {
            get { return err_Eth3_Led_Yellow = "Err_Eth3_Led_Yellow"; }//Err_Eth3_Led_Yellow
        }
        public string Err_Eth3_Ping
        {
            get { return err_Eth3_Ping = "Err_Eth3_Ping"; }//Err_Eth3_Ping
        }    

        //eth4
        public string Err_Eth4_Speed2_5G
        {
            get { return err_Eth4_Speed2_5G = "Err_Eth4_Speed2_5G"; }//Err_Eth4_Speed1G
        }
        public string Err_Eth4_Speed100M
        {
            get { return err_Eth4_Speed100M = "Err_Eth4_Speed100M"; }//Err_Eth4_Speed100M
        }
        public string Err_Eth4_Led_Green
        {
            get { return err_Eth4_Led_Green = "Err_Eth4_Led_Green"; }//Err_Eth4_Led_Green
        }
        public string Err_Eth4_Led_Red
        {
            get { return err_Eth4_Led_Red = "Err_Eth4_Led_Red"; }//Err_Eth4_Led_Red
        }
        public string Err_Eth4_Led_Yellow
        {
            get { return err_Eth4_Led_Yellow = "Err_Eth4_Led_Yellow"; }//Err_Eth4_Led_Yellow
        }
        public string Err_Eth4_Ping
        {
            get { return err_Eth4_Ping = "Err_Eth4_Ping"; }//Err_Eth4_Ping
        }
        string err_Led_notfileFound;
        public string Err_Led_notfileFound
        {
            get { return err_Led_notfileFound = "Err_Led_notfileFound"; }//Err_Led_notfileFound
        }
        string err_Led_Online;
        public string Err_Led_Online
        {
            get { return err_Led_Online = "Err_Led_Online"; }//Err_Led_Online
        }
        string err_Led_WPS;
        public string Err_Led_WPS
        {
            get { return err_Led_WPS = "Err_Led_WPS"; }//Err_Led_WPS
        }
        string err_Led_Moca;
        public string Err_Led_Moca
        {
            get { return err_Led_Moca = "Err_Led_Moca"; }//Err_Led_Moca
        }
        //ping after reset
        private string err_PingafterReset;
        public string Err_PingafterReset
        {
            get { return err_PingafterReset = "Err_PingafterReset"; }//Err_PingafterReset
        }
        private string err_voip_function;
        public string Err_voip_function
        {
            get { return err_voip_function = "Err_voip_function"; }//Err_voip_function
        }

        private string err_1000_wait;
        public string Err_1000_wait
        {
            get { return err_1000_wait = "Err_1000_wait"; }//Err_voip_wait
        }
        private string err_voip_wait;
        public string Err_voip_wait
        {
            get { return err_voip_wait = "Err_voip_wait"; }//Err_voip_wait
        }
        private string err_voip_noise;
        public string Err_voip_noise
        {
            get { return err_voip_noise = "Err_voip_noise"; }//Err_voip_noise
        }
        private string err_Ping_Timeout;
        public string Err_Ping_Timeout
        {
            get { return err_Ping_Timeout = "Err_Ping_Timeout"; }//Err_Ping_Timeout
        }
        private string err_Ping_Moca;
        public string Err_Ping_Moca
        {
            get { return err_Ping_Moca = "Err_Ping_Moca"; }//Err_Ping_Moca
        }
        //WAN
        public string Err_WAN_Speed1G
        {
            get { return err_WAN_Speed1G = "Err_WAN_Speed1G"; }//Err_WAN_Speed1G
        }
        public string Err_WAN_Speed100M
        {
            get { return err_WAN_Speed100M = "Err_WAN_Speed100M"; }//Err_WAN_Speed100M
        }
        public string Err_WAN_Led_Green
        {
            get { return err_WAN_Led_Green = "Err_WAN_Led_Green"; }//Err_WAN_Led_Green
        }
        public string Err_WAN_Led_Red
        {
            get { return err_WAN_Led_Red = "Err_WAN_Led_Red"; }//Err_WAN_Led_Red
        }
        public string Err_WAN_Led_Yellow
        {
            get { return err_WAN_Led_Yellow = "Err_WAN_Led_Yellow"; }//Err_WAN_Led_Yellow
        }
        public string Err_WAN_Ping
        {
            get { return err_WAN_Ping = "Err_WAN_Ping"; }//Err_WAN_Ping
        }
        string err_CMTS_Ping;
        public string Err_CMTS_Ping
        {
            get { return err_WAN_Ping = "Err_CMTS_Ping"; }//Err_CMTS_Ping
        }
        string err_Moca_SetIp;
        public string Err_Moca_SetIp
        {
            get { return err_Moca_SetIp = "EMOCA2"; }//Err_Moca_SetIp
        }
        string err_LANMAC;
        public string Err_LANMAC
        {
            get { return err_LANMAC = "Err_LANMAC"; }//Err_LANMAC
        }
        string err_CMMAC_Total;
        public string Err_CMMAC_Total
        {
            get { return err_CMMAC_Total = "Err_CMMAC_Total"; }//Err_CMMAC_Total
        }
        string err_Server_Telnet;
        public string Err_Server_Telnet
        {
            get { return err_Server_Telnet = "Err_Server_Telnet"; }//Err_Server_Telnet
        }
        //snmp
        string err_snmp_connect;
        public string Err_snmp_connect
        {
            get { return err_snmp_connect = "Err_snmp_connect"; }//Err_snmp_connect
        }
        string err_LableGet_WifiLeng;
        public string Err_LableGet_WifiLeng
        {
            get { return err_LableGet_WifiLeng = "Err_LableGet_WifiLeng"; }//Err_LableGet_WifiLeng
        }
         
        string err_CMTS_Connect;
        public string Err_CMTS_Connect
        {
            get { return err_CMTS_Connect = "Err_CMTS_Connect"; }//Err_CMTS_Connect
        }
        string err_LableGet_SSIDName;
        public string Err_LableGet_SSIDName
        {
            get { return err_LableGet_SSIDName = "Err_LableGet_SSIDName"; }//Err_LableGet_SSIDName
        }
        string err_WPS_Pin;
        public string Err_WPS_Pin
        {
            get { return err_WPS_Pin = "Err_WPS_Pin"; }//Err_WPS_Pin
        }
        string err_Barcode_2D;
        public string Err_Barcode_2D
        {
            get { return err_Barcode_2D = "Err_Barcode_2D"; }//Err_Barcode_2D
        }
        //Information
        string err_Information;
        public string Err_Information
        {
            get { return err_Information = "Err_Information"; }//Err_Information
        }

        string err_wifi_password;
        public string Err_wifi_password
        {
            get { return err_wifi_password = "Err_wifi_password"; }//Err_wifi_password
        }
        string err_ssidname;
        public string Err_ssidname
        {
            get { return err_ssidname = "Err_ssidname"; }//Err_ssidname
        }
        string err_sn;
        public string Err_sn
        {
            get { return err_sn = "Err_sn"; }//Err_sn
        }
        string err_CMMAC;
        public string Err_CMMAC
        {
            get { return err_CMMAC = "Err_CMMAC"; }//Err_CMMAC
        }
        string err_MTAMAC;
        public string Err_MTAMAC
        {
            get { return err_MTAMAC = "Err_MTAMAC"; }//Err_MTAMAC
        }
       
        string err_err;
        public string Err_err
        {
            get { return err_err = "Err_err"; }//Err_err
        }
        string err_Dspower;
        public string Err_Dspower
        {
            get { return err_Dspower = "Err_Dspower"; }//Err_Dspower
        }
        string err_Uspower;
        public string Err_Uspower
        {
            get { return err_Uspower = "Err_Uspower"; }//Err_Uspower
        }
        string err_Sample_DS;
        public string Err_Sample_DS
        {
            get { return err_Sample_DS = "Err_Sample_DS"; }//Err_Sample_DS
        }
        string err_Sample_US;
        public string Err_Sample_US
        {
            get { return err_Sample_US = "Err_Sample_US"; }//Err_Sample_US
        }
        //loginWeb
        string err_loginWeb_IdUser;
        public string Err_loginWeb_IdUser
        {
            get { return err_loginWeb_IdUser = "Err_loginWeb_IdUser"; }//Err_loginWeb_IdUser
        }
        string err_loginWeb_PressOKbtn;
        public string Err_loginWeb_PressOKbtn
        {
            get { return err_loginWeb_PressOKbtn = "Err_loginWeb_PressOKbtn"; }//Err_loginWeb_PressOKbtn
        }
        string err_loginWeb_IdPassword;
        public string Err_loginWeb_IdPassword
        {
            get { return err_loginWeb_IdPassword = "Err_loginWeb_IdPassword"; }//Err_loginWeb_IdPassword
        }
        string err_loginWeb_UsernotFound;
        public string Err_loginWeb_UsernotFound
        {
            get { return err_loginWeb_UsernotFound = "Err_loginWeb_UsernotFound"; }//Err_loginWeb_UsernotFound
        }
        string err_Web_LoginFirst;
        public string Err_Web_LoginFirst
        {
            get { return err_Web_LoginFirst = "Err_Web_LoginFirst"; }//Err_Web_LoginFirst
        }
        string err_Web_AccessFirst;
        public string Err_Web_AccessFirst
        {
            get { return err_Web_AccessFirst = "Err_Web_AccessFirst"; }//Err_Web_AccessFirst
        }
        string err_Web_LoginSecond;
        public string Err_Web_LoginSecond
        {
            get { return err_Web_LoginSecond = "Err_Web_LoginSecond"; }//Err_Web_LoginSecond
        }
        string err_Web_clickConnect;
        public string Err_Web_clickConnect
        {
            get { return err_Web_clickConnect = "Err_Web_clickConnect"; }//Err_Web_clickConnect
        }
        string err_Web_clickWifi;
        public string Err_Web_clickWifi
        {
            get { return err_Web_clickWifi = "Err_Web_clickWifi"; }//Err_Web_clickWifi
        }
        string err_Web_clickWPSPin;
        public string Err_Web_clickWPSPin
        {
            get { return err_Web_clickWPSPin = "Err_Web_clickWPSPin"; }//Err_Web_clickWPSPin
        }
        string err_Web_clickMoca;
        public string Err_Web_clickMoca
        {
            get { return err_Web_clickMoca = "Err_Web_clickMoca"; }//Err_Web_clickMoca
        }
        string err_Web_enableMoca;
        public string Err_Web_enableMoca
        {
            get { return err_Web_enableMoca = "Err_Web_enableMoca"; }//Err_Web_enableMoca
        }
        string err_Web_changePassWord;
        public string Err_Web_changePassWord
        {
            get { return err_Web_changePassWord = "Err_Web_changePassWord"; }//Err_Web_changePassWord
        }
        string err_Web_AccessSecond;
        public string Err_Web_AccessSecond
        {
            get { return err_Web_AccessSecond = "Err_Web_AccessSecond"; }//Err_Web_AccessSecond
        }
        string err_loginWeb_ConnectionnotFound;
        public string Err_loginWeb_ConnectionnotFound
        {
            get { return err_loginWeb_ConnectionnotFound = "Err_loginWeb_ConnectionnotFound"; }//Err_loginWeb_ConnectionnotFound
        }

        //voip
        string err_Voip_P1ToP2;
        public string Err_Voip_P1ToP2
        {
            get { return err_Voip_P1ToP2 = "Err_Voip_P1ToP2"; }//Err_Voip_P1ToP2
        }
        string err_Voip_P2ToP1;
        public string Err_Voip_P2ToP1
        {
            get { return err_Voip_P2ToP1 = "Err_Voip_P2ToP1"; }//Err_Voip_P2ToP1
        }
        //thread
        string err_Thread_StartupCmd;
        public string Err_Thread_StartupCmd
        {
            get { return err_Thread_StartupCmd = "Err_Thread_StartupCmd"; }//Err_Thread_StartupCmd
        }
        string err_Thread_Enable;
        public string Err_Thread_Enable
        {
            get { return err_Thread_Enable = "Err_Thread_Enable"; }//Err_Thread_Enable
        }
        string err_Thread_Parring;
        public string Err_Thread_Parring
        {
            get { return err_Thread_Parring = "Err_Thread_Parring"; }//Err_Thread_Parring
        }
        //fan
        string err_Fan_Value;
        public string Err_Fan_Value
        {
            get { return err_Fan_Value = "Err_Fan_Value"; }//Err_Fan_Value
        }
        //BLE
        string err_BLE_Enable;
        public string Err_BLE_Enable
        {
            get { return err_BLE_Enable = "Err_BLE_Enable"; }//Err_BLE_Enable
        }
        string err_Zigbee_Enable;
        public string Err_Zigbee_Enable
        {
            get { return err_Zigbee_Enable = "Err_Zigbee_Enable"; }//Err_Zigbee_Enable
        }
        string err_Zigbee_Disable;
        public string Err_Zigbee_Disable
        {
            get { return err_Zigbee_Disable = "Err_Zigbee_Disable"; }//Err_Zigbee_Disable
        }
        string err_BLE_Scan;
        public string Err_BLE_Scan
        {
            get { return err_BLE_Scan = "Err_BLE_Scan"; }//Err_BLE_Scan
        }
        private string err_Login_SSh;
        private string err_Information_SN, err_Information_MAC, err_Information_OUI_SN, err_Information_ModelName,
             err_Information_SW, err_Information_SW_bootloader_version, err_Information_HW,
             err_Information_TCHName, err_Information_ChipID;
        public string Err_Login_SSh
        {
            get { return err_Login_SSh = "Err_Login_SSh"; }//Err_Login_SSh
        }
        public string Err_Information_SN
        {
            get { return err_Information_SN = "Err_Information_SN"; }//Err_Information_SN
        }
        public string Err_Information_MAC
        {
            get { return err_Information_MAC = "Err_Information_MAC"; }//Err_Information_MAC
        }
        public string Err_Information_OUI_SN
        {
            get { return err_Information_OUI_SN = "Err_Information_OUI_SN"; }//Err_Information_OUI_SN
        }
        public string Err_Information_ModelName
        {
            get { return err_Information_ModelName = "Err_Information_ModelName"; }//Err_Information_ModelName
        }
        public string Err_Information_SW
        {
            get { return err_Information_SW = "Err_Information_SW"; }//Err_Information_SW
        }
        public string Err_Information_SW_bootloader_version
        {
            get { return err_Information_SW_bootloader_version = "Err_Information_SW_bootloader_version"; }//Err_Information_SW_bootloader_version
        }
        public string Err_Information_HW
        {
            get { return err_Information_HW = "Err_Information_HW"; }//Err_Information_HW
        }
        public string Err_Information_TCHName
        {
            get { return err_Information_TCHName = "Err_Information_TCHName"; }//Err_Information_TCHName
        }
        public string Err_Information_ChipID
        {
            get { return err_Information_ChipID = "Err_Information_ChipID"; }//Err_Information_ChipID
        }
        private string err_Information_bootloader;
        public string Err_Information_bootloader
        {
            get { return err_Information_bootloader = "Err_Information_bootloader"; }//Err_Information_bootloader
        }
        //USB
        private string err_USB;
        public string Err_USB
        {
            get { return err_USB = "Err_USB"; }   //Err_USB
        }
        //Gfast
        private string err_Gfat;
        public string Err_Gfat
        {
            get { return err_Gfat = "Err_Gfat"; }//Err_Gfat
        }
        //XDSL
        private string err_ADSL15k;
        public string Err_ADSL15k
        {
            get { return err_ADSL15k = "Err_ADSL15k"; }//Err_ADSL15k
        }
        private string err_VDSL1k;
        public string Err_VDSL1k
        {
            get { return err_VDSL1k = "Err_VDSL1k"; }//Err_VDSL1k
        }
        //led
        private string err_ledDUToff;
        public string Err_ledDUToff
        {
            get { return err_ledDUToff = "Err_ledDUToff"; }//Err_ledDUToff
        }
        private string err_ledDUTon;
        public string Err_ledDUTon
        {
            get { return err_ledDUTon = "Err_ledDUTon"; }//Err_ledDUTon
        }
        private string err_RedledDUTon;
        public string Err_RedledDUTon
        {
            get { return err_RedledDUTon = "Err_RedledDUTon"; }//Err_RedledDUTon
        }
        private string err_RedledDUToff;
        public string Err_RedledDUToff
        {
            get { return err_RedledDUToff = "Err_RedledDUToff"; }//Err_RedledDUToff
        }
        private string err_GreenledDUTon;
        public string Err_GreenledDUTon
        {
            get { return err_GreenledDUTon = "Err_GreenledDUTon"; }//Err_GreenledDUTon
        }
        private string err_GreenledDUToff;
        public string Err_GreenledDUToff
        {
            get { return err_GreenledDUToff = "Err_GreenledDUToff"; }//Err_GreenledDUToff
        }
        private string err_BlueledDUTon;
        public string Err_BlueledDUTon
        {
            get { return err_BlueledDUTon = "Err_BlueledDUTon"; }//Err_BlueledDUTon
        }
        private string err_BlueledDUToff;
        public string Err_BlueledDUToff
        {
            get { return err_BlueledDUToff = "Err_BlueledDUToff"; }
        }
        private string err_VOIPStatus;
        public string Err_VOIPStatus
        {
            get { return err_VOIPStatus = "Err_VOIPStatus"; }
        }
        private string err_VOIPFXStoFXS;
        public string Err_VOIPFXStoFXS
        {
            get { return err_VOIPFXStoFXS = "Err_VOIPFXStoFXS"; }
        }
        private string err_VOIPPSTNtoFXS;
        public string Err_VOIPPSTNtoFXS
        {
            get { return err_VOIPPSTNtoFXS = "Err_VOIPPSTNtoFXS"; }
        }
        private string err_FindDect;
        public string Err_FindDect
        {
            get { return err_FindDect = "Err_FindDect"; }
        }
        private string err_LtesimcardStatus;
        public string Err_LtesimcardStatus
        {
            get { return err_LtesimcardStatus = "Err_LtesimcardStatus"; }
        }
        private string err_LtePowerMode;
        public string Err_LtePowerMode
        {
            get { return err_LtePowerMode = "Err_LtePowerMode"; }
        }
        //button
        private string err_Button;
        public string Err_Button
        {
            get { return err_Button = "Err_Button"; }
        }
        //
        private string err_inforLable;
        public string Err_inforLable
        {
            get { return err_inforLable = "Err_inforLable"; }
        }
        private string err_ssidWifikey;
        public string Err_ssidWifikey
        {
            get { return err_ssidWifikey = "Err_ssidWifikey"; }
        }
        //LoginWeb
        private string err_LogInweb;
        public string Err_LogInweb
        {
            get { return err_LogInweb = "Err_LogInweb"; }
        }
    }
}
