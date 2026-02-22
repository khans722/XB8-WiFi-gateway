using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Automatic
{
    public partial class Login_Lock : Form
    {
        public Login_Lock()
        {
            InitializeComponent();
        }
        private void Login_Lock_Load(object sender, EventArgs e)
        {
            string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
            StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
            string key = loadinfor1.ReadToEnd().Trim();
            loadinfor1.Close();
            lbreeor.Text = key;
            txtuser.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtuser.TextLength >= 8)
            {
                txtpassword.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text.Length < 10 | txtuser.Text.Length < 8 | txtuser.Text.Contains(txtpassword.Text))
            {
                MessageBox.Show("Nhâp lai thông tin!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return ;
            }
            else
            {
                string date = DateTime.Now.ToString("dd.MM.yyyy") + " - " + DateTime.Now.TimeOfDay.Hours.ToString() + "h" + DateTime.Now.TimeOfDay.Minutes.ToString() + "p" + DateTime.Now.TimeOfDay.Seconds.ToString() + "s";
                string pathfile = Directory.GetCurrentDirectory() + "\\QE.txt";
                string pathfile2 = Directory.GetCurrentDirectory() + "\\QEPW.txt";
                string pathfile3 = Directory.GetCurrentDirectory() + "\\Offline.txt";
                StreamReader loadinfor1 = new StreamReader(pathfile, Encoding.UTF8);
                StreamReader loadinfor2 = new StreamReader(pathfile2, Encoding.UTF8);
                StreamReader loadinfor3 = new StreamReader(pathfile3, Encoding.UTF8);
                string key = loadinfor1.ReadToEnd().Trim();
                string key2 = loadinfor2.ReadToEnd().Trim();
                string key3 = loadinfor3.ReadToEnd().Trim();
                loadinfor1.Close();
                loadinfor2.Close();
                loadinfor3.Close();
                if ((key.Contains(txtuser.Text) & (key2.Contains(txtpassword.Text)) & (key3.Contains("PASS"))))
                {
                    Write("", "OK");
                    logfileunlock(txtuser.Text + "\t" + date + "\t" + lbreeor.Text);
                    this.Hide();

                }
                else
                {
                    if (!key.Contains(txtuser.Text))
                    {
                        MessageBox.Show("Không có quyền Unlock!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else if (!key2.Contains(txtpassword.Text))
                    {
                        MessageBox.Show("Sai mat khau!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else if (!key3.Contains("PASS"))
                    {
                        MessageBox.Show("Yeu Cau Test OFFLINE!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    
                }
            }
        }       
        private void Write(string key, string key2)
        {
            string a = DateTime.Now.ToString();
            string pathfile = Directory.GetCurrentDirectory() + "\\ERROR.txt";
            string pathfile1 = Directory.GetCurrentDirectory() + "\\Statuslock.txt";
            string pathfile2 = Directory.GetCurrentDirectory() + "\\Statuslockduperr.txt";
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

                FileStream fs2;
                fs2 = new FileStream(pathfile2, FileMode.Create);
                StreamWriter write2 = new StreamWriter(fs2, Encoding.UTF8);
                write2.WriteLine(a);
                write2.WriteLine(key2);
                write2.Flush();
                fs2.Close();
            }
            catch { }
        }
        private void WriteoffP(string key, string key2)
        {
            string a = DateTime.Now.ToString();
            string pathfile = Directory.GetCurrentDirectory() + "\\Offline.txt";
            try
            {
                FileStream fs;
                fs = new FileStream(pathfile, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine(a);
                write.WriteLine(key);
                write.Flush();
                fs.Close();
            }
            catch { }
        }
        private void WriteoffF(string key, string key2)
        {
            string a = DateTime.Now.ToString();
            string pathfile = Directory.GetCurrentDirectory() + "\\Offline.txt";
            try
            {
                FileStream fs;
                fs = new FileStream(pathfile, FileMode.Create);
                StreamWriter write = new StreamWriter(fs, Encoding.UTF8);
                write.WriteLine(a);
                write.WriteLine(key);
                write.Flush();
                fs.Close();
            }
            catch { }
        }
        private void logfileunlock(string data)
        {
            string filePathSN = Directory.GetCurrentDirectory() + @"\logfileunlock.ini";
            StreamWriter strWrite1 = new StreamWriter(filePathSN, true);
            strWrite1.WriteLine(data);
            strWrite1.Flush();
            strWrite1.Close();
        }


    }
}
