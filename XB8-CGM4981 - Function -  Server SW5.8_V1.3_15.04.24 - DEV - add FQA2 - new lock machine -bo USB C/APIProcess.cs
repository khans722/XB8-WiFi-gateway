using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
namespace Automatic
{
    public class APIProcess
    {
        private string _URL = string.Empty;
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        private string _IMAGEURL = string.Empty;
        public string IMAGEURL
        {
            get { return _IMAGEURL; }
            set { _IMAGEURL = value; }
        }

        private int _NOR = 0;
        public int NOR
        {
            get { return _NOR; }
            set { _NOR = value; }
        }

        public string GetMethod()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Khi sư dung https
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(_URL);
            Req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;//disable ssl
            Req.Method = "GET";
            Req.Timeout = Timeout.Infinite;
            Req.KeepAlive = true;
            Req.ContentType = "application/json";
            //Req.Proxy = null;
            HttpWebResponse Res = (HttpWebResponse)Req.GetResponse();
            return new StreamReader(Res.GetResponseStream()).ReadToEnd();
        }

        public string PostMethod(object modal)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//Khi sư dung https
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(_URL);
            Req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;//disable ssl
            Req.Method = "POST";
            Req.Timeout = Timeout.Infinite;
            Req.KeepAlive = true;
            Req.ContentType = "application/json"; 

            var jsonData = JsonConvert.SerializeObject(modal);

            Write_File("API_log.txt", jsonData);

            using (var streamWriter = new StreamWriter(Req.GetRequestStream(), Encoding.Unicode))
            {
                streamWriter.Write(jsonData);
            }

            HttpWebResponse Res = (HttpWebResponse)Req.GetResponse(); ///
            return new StreamReader(Res.GetResponseStream()).ReadToEnd();
        }

        public void Write_File(string file_path, string WriteFile)
        {
            //string path = file_path;
            string path = Application.StartupPath + "\\" + file_path;
            try
            {
                if (!File.Exists(file_path))
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(WriteFile);
                    write.Flush();
                    fs.Close();
                }
                else
                {
                    FileStream fs;
                    fs = new FileStream(file_path, FileMode.Create);
                    StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                    write.WriteLine(WriteFile);
                    write.Flush();
                    fs.Close();
                }

            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
            }
        }
        public string PostMethod(string jsonData)
        {
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(_URL);
            Req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            Req.Method = "POST";
            Req.Timeout = Timeout.Infinite;
            Req.KeepAlive = true;
            Req.ContentType = "application/json";

            //var jsonData = JsonConvert.SerializeObject(modal);

            using (var streamWriter = new StreamWriter(Req.GetRequestStream(), Encoding.Unicode))
            {
                streamWriter.Write(jsonData);
            }

            HttpWebResponse Res = (HttpWebResponse)Req.GetResponse();
            return new StreamReader(Res.GetResponseStream()).ReadToEnd();
        }
    }
}
