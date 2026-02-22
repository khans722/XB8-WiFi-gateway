using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automatic
{
    public class UnlockMaintanice
    {
        public static string id { get; set; }
        public static bool RF1 { get; set; }
        public static bool RF2 { get; set; }
        public static bool PSU1 { get; set; }
        public static bool PSU2 { get; set; }
        public static bool VOIP1 { get; set; }
        public static bool VOIP2 { get; set; }
        public static bool Eth1 { get; set; }
        public static bool Eth2 { get; set; }
        public static bool Eth3 { get; set; }
        public static bool Eth4 { get; set; }
        public static bool USB_C { get; set; }



        public static DialogResult
        Show(string message)
        {
            Eth4 = Eth3 = Eth2 = Eth1 = VOIP2 = VOIP1 = PSU2 = PSU1 = RF1 = RF2 = USB_C= false;
            Form frm = new Form();
            frm.Size = new Size(450, 220);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowInTaskbar = false;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.Location = new Point(570, 315);
            frm.ForeColor = Color.Black;
            frm.StartPosition = FormStartPosition.Manual;

            Label lbl = new Label();
            lbl.Text = message;
            lbl.AutoSize = true;
            lbl.MaximumSize = frm.Size;
            lbl.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Red;
            lbl.Location = new Point(8, 10);
            frm.Controls.Add(lbl);

            Label lbl_id = new Label();
            lbl_id.AutoSize = true;
            lbl_id.MaximumSize = frm.Size;
            lbl_id.Text = "YourID";
            lbl_id.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            lbl_id.ForeColor = Color.Green;
            lbl_id.Location = new Point(10, 62);
            //lbl.Click += (s, e) => frm.DialogResult = DialogResult.Cancel;
            frm.Controls.Add(lbl_id);

            TextBox txt_id = new TextBox();
            txt_id.Size = new Size(150, 20);
            txt_id.CharacterCasing =  CharacterCasing.Upper;
            txt_id.Location = new Point(70, 58);
            txt_id.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            frm.Controls.Add(txt_id);
            txt_id.Focus();

            CheckBox RF11 = new CheckBox();
            RF11.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            RF11.Location = new Point(250, 5);
            RF11.Text = "RF1";
            frm.Controls.Add(RF11);

            CheckBox RF22 = new CheckBox();
            RF22.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            RF22.Location = new Point(360, 5);
            RF22.Text = "RF2";
            frm.Controls.Add(RF22);

            CheckBox PSU11 = new CheckBox();
            PSU11.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            PSU11.Location = new Point(250, 33);
            PSU11.Text = "PSU1";
            frm.Controls.Add(PSU11);

            CheckBox PSU22 = new CheckBox();
            PSU22.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            PSU22.Location = new Point(360,33);
            PSU22.Text = "PSU2";
            frm.Controls.Add(PSU22);

            CheckBox VOIP11 = new CheckBox();
            VOIP11.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            VOIP11.Location = new Point(250, 60);
            VOIP11.Text = "VOIP1";
            frm.Controls.Add(VOIP11);

            CheckBox VOIP22 = new CheckBox();
            VOIP22.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            VOIP22.Location = new Point(360, 60);
            VOIP22.Text = "VOIP2";
            frm.Controls.Add(VOIP22);

            CheckBox Eth11 = new CheckBox();
            Eth11.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            Eth11.Location = new Point(250, 88);
            Eth11.Text = "Eth1";
            frm.Controls.Add(Eth11);
            CheckBox Eth22 = new CheckBox();
            Eth22.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            Eth22.Location = new Point(360, 88);
            Eth22.Text = "Eth2";
            frm.Controls.Add(Eth22);

            CheckBox Eth33 = new CheckBox();
            Eth33.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            Eth33.Location = new Point(250, 115);
            Eth33.Text = "Eth3";
            frm.Controls.Add(Eth33);
            CheckBox Eth44 = new CheckBox();
            Eth44.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            Eth44.Location = new Point(360, 115);
            Eth44.Text = "Eth4";
            frm.Controls.Add(Eth44);

            CheckBox USb = new CheckBox();
            USb.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            USb.Location = new Point(250, 139);
            USb.Text = "USB_Type.C";
            frm.Controls.Add(USb);

            Button btn1 = new Button();
            btn1.Size = new Size(75, 29);
            btn1.Text = "OK";
            btn1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            btn1.Location = new Point(110, 120);
            frm.Controls.Add(btn1);
            btn1.Click += (sender, e) => id = txt_id.Text;
            btn1.Click += (sender, e) => frm.DialogResult = DialogResult.OK;
            RF11.CheckStateChanged += (sender, e) => { if (RF11.Checked == true) { RF1 = true; } };
            RF22.CheckStateChanged += (sender, e) => { if (RF22.Checked == true) { RF2 = true; } };
            PSU11.CheckStateChanged += (sender, e) => { if (PSU11.Checked == true) { PSU1 = true; } };
            PSU22.CheckStateChanged += (sender, e) => { if (PSU22.Checked == true) { PSU2 = true; } };
            VOIP11.CheckStateChanged += (sender, e) => { if (VOIP11.Checked == true) { VOIP1 = true; } };
            VOIP22.CheckStateChanged += (sender, e) => { if (VOIP22.Checked == true) { VOIP2 = true; } };
            Eth11.CheckStateChanged += (sender, e) => { if (Eth11.Checked == true) { Eth1 = true; } };
            Eth22.CheckStateChanged += (sender, e) => { if (Eth22.Checked == true) { Eth2 = true; } };
            Eth33.CheckStateChanged += (sender, e) => { if (Eth33.Checked == true) { Eth3 = true; } };
            Eth44.CheckStateChanged += (sender, e) => { if (Eth44.Checked == true) { Eth4 = true; } };
            USb.CheckStateChanged += (sender, e) => { if (USb.Checked == true) { USB_C = true; } };
            return frm.ShowDialog();
        }
    }
}