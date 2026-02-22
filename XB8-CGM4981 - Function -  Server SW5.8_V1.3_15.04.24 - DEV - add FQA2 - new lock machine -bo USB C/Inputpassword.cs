using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automatic
{
    public class Inputpassword
    {
        public static string password { get; set; }
        public static string id { get; set; }
        public static DialogResult
        Show(string message)
        {
            Form frm = new Form();
            frm.Size = new Size(280, 160);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowInTaskbar = false;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Location = new Point(570, 324);
            frm.ForeColor = Color.Black;
            //frm.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(5, 380);

            Label lbl = new Label();
            lbl.Text = message;
            lbl.AutoSize = true;
            lbl.MaximumSize = frm.Size;
            lbl.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(8, 10);
            //lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl);

            Label lbl_id = new Label();
            lbl_id.AutoSize = true;
            lbl_id.MaximumSize = frm.Size;
            lbl_id.Text = "ID";
            lbl_id.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lbl_id.ForeColor = Color.Green;
            lbl_id.Location = new Point(10, 32);
            //lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl_id);

            TextBox txt1 = new TextBox();
            txt1.Size = new Size(150, 20);
            txt1.Location = new Point(80, 28);
            txt1.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            
            frm.Controls.Add(txt1);
            txt1.Focus();

            Label lbl_password = new Label();
            lbl_password.AutoSize = true;
            lbl_password.MaximumSize = frm.Size;
            lbl_password.Text = "Password";
            lbl_password.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lbl_password.ForeColor = Color.Red;
            lbl_password.Location = new Point(10, 62);
            //lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl_password);

            TextBox txt2 = new TextBox();
            txt2.Size = new Size(150, 20);
            txt2.PasswordChar = '*';
            txt2.Location = new Point(80, 58);
            txt2.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            txt2.MaxLength = 8;
            frm.Controls.Add(txt2);
            
            Button btn1 = new Button();
            btn1.Size = new Size(75, 29);
            btn1.Text = "OK";
            btn1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            btn1.Location = new Point(33, 99);
            //btn1.Click += (sender, e) => frm.DialogResult = DialogResult.OK;
            btn1.Click += (sender, e) => id = txt1.Text;
            btn1.Click += (sender, e) => password = txt2.Text;
            btn1.Click += (sender, e) => frm.DialogResult = DialogResult.OK;
            frm.Controls.Add(btn1);
            //if (txt2.TextLength > 7)
            //{
            //    btn1.Focus();
            //}


            Button btn2 = new Button();
            btn2.Size = new Size(75, 29);
            btn2.Text = "Cancel";
            btn2.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            btn2.Location = new Point(140, 99);
            btn2.Click += (sender, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(btn2);



            


            frm.AutoSize = true;
            //frm.Text= "Chú ý !!";
            frm.Text = "Unlock_Program";
            

            return frm.ShowDialog();
        }
    }
}
