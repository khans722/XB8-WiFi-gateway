using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Automatic
{
    public class SaveLogs
    {
        public void Save_Logs_Maintain(string model, string ID, string equipment, int times_use)
        {
            string path = "D:\\OBA_STB_Logs\\Maintain" + model;
            string time, time1, time2;
            time = DateTime.Now.ToString("ddd - yyyy/MM/dd HH:mm:ss");
            time1 = DateTime.Now.ToString("yyyy-MM-dd");
            time2 = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
            string file_path = path + "\\" + time1 + "\\" + " " + time2 + " " + equipment + ".txt";

            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!Directory.Exists(path + "\\" + time1))
                {
                    Directory.CreateDirectory(path + "\\" + time1);
                }

                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine("\nID:" + ID + "\n" + equipment + ":" + times_use);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine("\nID:" + ID + "\n" + equipment + ":" + times_use);
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
        public void Save_Logs_File_status_program(string name_status, string errorcode, string ID)
        {
            string path = "D:\\OBA_CM_Look\\" + name_status;
            string time, time1, time2;
            time = DateTime.Now.ToString("ddd - yyyy/MM/dd HH:mm:ss");
            time1 = DateTime.Now.ToString("yyyy-MM-dd");
            time2 = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
            string file_path = path + "\\" + time1 + "\\" + " " + time2 + " " + name_status + " " + ID + ".txt";

            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!Directory.Exists(path + "\\" + time1))
                {
                    Directory.CreateDirectory(path + "\\" + time1);
                }

                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine("\nStatus:" + name_status + "\nError_code" + errorcode + "\nID:" + ID);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    //write.WriteLine(Test_information);
                    write.WriteLine("\nStatus:" + name_status + "\nID:" + ID);
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
        public void Save_Logs_File(string modelname,string SN, string Test_information, string result)
        {

            string path = "D:\\LogFile\\"+modelname;
            string time, time1;
            time = DateTime.Now.ToString("ddd - yyyy/MM/dd HH:mm:ss");
            time1 = DateTime.Now.ToString("yyyy-MM-dd");
            string file_path = path + "\\" + time1 + "\\" + SN + " " + result + ".txt";

            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!Directory.Exists(path + "\\" + time1))
                {
                    Directory.CreateDirectory(path + "\\" + time1);
                }

                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
        string file_path = "";
        string file_path2 = "";
        string file_path3 = "";
        public void Save_Sample_File(string modelname, string SN, string Test_information, string result)
        {

            string path = "D:\\LogFileSample\\" + modelname;
            string time, time1, time3;
            time = DateTime.Now.ToString("ddd - yyyy/MM/dd HH:mm:ss");
            time1 = DateTime.Now.ToString("yyyy-MM-dd");
            time3 = DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss");
            string time_now = DateTime.Now.ToString("ddd - yyyy/MM/dd HH:mm:ss");
            string time_day = DateTime.Now.ToString("ddd");
            string time_hour = DateTime.Now.ToString("HH.mm");
            float cvt_time_hour = float.Parse(time_hour);
            if (cvt_time_hour < 19 && cvt_time_hour > 7)
            {
                file_path = path + "\\" + time1 + "\\" + "CA_NGAY" + "\\" + SN + " " + result + ".txt";
                file_path2 = path + "\\" + time1 + "\\" + "CA_NGAY";
                file_path3 = path + "\\" + time1 + "\\" + "CA_NGAY" + "\\" + SN + " " + result  + "_" + time3 + ".txt";
            }
            else
            {
                if (cvt_time_hour < 7 && cvt_time_hour > 0) // ca ddem
                {
                    string time1_1 = DateTime.Now.ToString("yyyy-MM-");
                    string time1_2 = DateTime.Now.ToString("dd");
                    int dem_1 = int.Parse(time1_2) - 1;
                    string time6 = dem_1.ToString();
                    if (time6.Length < 2)
                    {
                        time6 = "0" + time6;
                    }

                    file_path = path + "\\" + time1_1 + time6 + "\\" + "CA_DEM" + "\\" + SN + " " + result + ".txt";
                    file_path2 = path + "\\" + time1_1 + time6 + "\\" + "CA_DEM";
                    file_path3 = path + "\\" + time1_1 + time6 + "\\" + "CA_DEM" + "\\" + SN + " " + result + "_" + time3 + ".txt";
                }
                else
                {
                    file_path = path + "\\" + time1 + "\\" + "CA_DEM" + "\\" + SN + " " + result + ".txt";
                    file_path2 = path + "\\" + time1 + "\\" + "CA_DEM";
                    file_path3 = path + "\\" + time1 + "\\" + "CA_DEM" + "\\" + SN + " " + result + "_" + time3 + ".txt";
                }
                
            }
           

            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!Directory.Exists(path + "\\" + time1))
                {
                    Directory.CreateDirectory(path + "\\" + time1);
                }
                if (!Directory.Exists(file_path2))
                {
                    Directory.CreateDirectory(file_path2);
                }

                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }
                if (!File.Exists(file_path3))
                {
                    FileStream fs;
                    fs = new FileStream(file_path3, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path3, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(time);
                    write.WriteLine(Test_information);
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
    }

}
