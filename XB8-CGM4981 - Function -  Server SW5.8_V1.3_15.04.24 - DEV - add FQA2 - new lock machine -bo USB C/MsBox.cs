using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automatic
{
    public class MsBox
    {
        public static DialogResult
        Show(string message)
        {
            Form frm = new Form();
            frm.Size = new Size(600, 300);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowInTaskbar = false;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(5, 380);


            Label lbl = new Label();
            lbl.Text = message;
            lbl.AutoSize = true;
            lbl.MaximumSize = frm.Size;
            lbl.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.Location = new Point(5, 5);
            lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl);

            Button btn1 = new Button();
            btn1.Size = new Size(80, 40);
            btn1.Text = "OK";
            btn1.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            btn1.Location = new Point(510, 250);
            btn1.Click += (sender, e) => frm.DialogResult = DialogResult.OK;
            frm.Controls.Add(btn1);

            frm.AutoSize = true;
            frm.Text = "Chú ý";

            return frm.ShowDialog();
        }
    }
}
