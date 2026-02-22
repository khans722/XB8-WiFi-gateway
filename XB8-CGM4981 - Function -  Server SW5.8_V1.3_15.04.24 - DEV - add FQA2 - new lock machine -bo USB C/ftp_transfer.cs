using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTP_Transfer
{
    public class ftp_transfer
    {
        // Upload File to Specified FTP Url with username and password and Upload Directory 
        //if need to upload in sub folders /// 
        //Base FtpUrl of FTP Server
        //Local Filename to Upload
        //Username of FTP Server
        //Password of FTP Server
        //[Optional]Specify sub Folder if any
        //Status String from Server
        public static string UploadFile11(string FtpUrl, string fileName, string userName, string password, string UploadDirectory = "")
        {
            WebRequest request = WebRequest.Create("ftp://200.168.104.98/Logs/OBA/XB8OBAPC03");
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(userName, password);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                Console.Write(response.StatusCode);

            }
            string PureFileName = new FileInfo(fileName).Name;
            String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
            req.UsePassive = false;
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;

            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            using (var response = (FtpWebResponse)req.GetResponse())
            {
                Console.Write(response.StatusCode);

            }

            byte[] data = File.ReadAllBytes(fileName);
            req.ContentLength = data.Length;
           
            Stream stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);

            stream.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();
            return res.StatusDescription;
        }

        public static string UploadFile(string FtpUrl, string fileName,  string Path1, string Path2, string userName, string password, string UploadDirectory = "")
        {
            string a = "";
            string pthh = FtpUrl + UploadDirectory;
            string pthh1 = FtpUrl + Path1;
            string pthh2 = FtpUrl + Path2;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(pthh1);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse requestPass = (FtpWebResponse)request.GetResponse();
            }
            catch { }      
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(pthh2);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse requestPass = (FtpWebResponse)request.GetResponse();
            }
            catch { }
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(pthh);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(userName, password);
                FtpWebResponse requestPass = (FtpWebResponse)request.GetResponse();
            }
            catch { }
            try
            {        
                    string PureFileName = new FileInfo(fileName).Name;
                    String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
                    FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
                    req.UsePassive = false;
                    req.Proxy = null;
                    req.Method = WebRequestMethods.Ftp.UploadFile;
                    req.Credentials = new NetworkCredential(userName, password);
                    req.UseBinary = true;
                    byte[] data = File.ReadAllBytes(fileName);
                    req.ContentLength = data.Length;
                    Stream stream = req.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                    FtpWebResponse res = (FtpWebResponse)req.GetResponse();
                    a = res.StatusDescription;               
            }
            catch
            {

            }
            return a;
        }

        //Download File From FTP Server 
        //Base url of FTP Server
        //if file is in root then write FileName Only if is in use like "subdir1/subdir2/filename.ext"
        //Username of FTP Server
        //Password of FTP Server
        //Folderpath where you want to Download the File
        // Status String from Server
        public static string DownloadFile(string FtpUrl, string FileNameToDownload,
                            string userName, string password, string tempDirPath, string offsetName)
        {
            string ResponseDescription = "";
            string PureFileName = new FileInfo(FileNameToDownload).Name;
            string DownloadedFilePath = tempDirPath + "/" + PureFileName + offsetName;
            string downloadUrl = String.Format("{0}/{1}", FtpUrl, FileNameToDownload);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
            req.UsePassive = false;
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            req.Proxy = null;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[2048];
                FileStream fs = new FileStream(DownloadedFilePath, FileMode.Create);
                int ReadCount = stream.Read(buffer, 0, buffer.Length);
                while (ReadCount > 0)
                {
                    fs.Write(buffer, 0, ReadCount);
                    ReadCount = stream.Read(buffer, 0, buffer.Length);
                }
                ResponseDescription = response.StatusDescription;
                fs.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                return ResponseDescription;
            }
            return ResponseDescription;
        }
    }
}

