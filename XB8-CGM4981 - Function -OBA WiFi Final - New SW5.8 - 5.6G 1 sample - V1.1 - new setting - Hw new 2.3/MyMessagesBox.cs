using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Automatic
{
    class MyMessagesBox
    {
       public static DialogResult
       Show(string message)
        {
            Form frm = new Form();
            frm.Size = new Size(400, 200);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowInTaskbar = false;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(10, 200);

            Label lbl = new Label();
            lbl.Text = message;
            lbl.AutoSize = true;
            lbl.MaximumSize = frm.Size;
            lbl.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            lbl.ForeColor = Color.Blue;
            lbl.Location = new Point(5, 5);
            //lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl);

            Button btn1 = new Button();
            btn1.Size = new Size(80, 35);
            btn1.Text = "Yes";
            btn1.ForeColor = Color.Blue;
            btn1.Font = new Font("Times New Roman", 17, FontStyle.Bold);
            btn1.Location = new Point(50, 150);
            btn1.Click += (sender, e) => frm.DialogResult = DialogResult.Yes;
            frm.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Size = new Size(80, 35);
            btn2.Text = "No";
            btn2.ForeColor = Color.Red;
            btn2.Font = new Font("Times New Roman", 17, FontStyle.Bold);
            btn2.Location = new Point(260, 150);
            btn2.Click += (sender, e) => frm.DialogResult = DialogResult.No;
            frm.Controls.Add(btn2);
            frm.AutoSize = true;
            frm.Text = "Xác nhận/Confirm";
            frm.Font = new Font("Times New Roman", 17, FontStyle.Bold);
            frm.ForeColor = Color.Blue;
            return frm.ShowDialog();
        }
    }
}
