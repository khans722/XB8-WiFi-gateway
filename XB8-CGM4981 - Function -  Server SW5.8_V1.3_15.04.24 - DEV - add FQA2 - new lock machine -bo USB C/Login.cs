using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Automatic
{
   public class Login_pass
    {
       public static string  acc { get; set; }
       public static string pwd { get; set; }

       public bool Account(string User, string Password)
       {
           string strCnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=Account.mdb;Jet OleDb:Database Password=doanquyenqe123456";
           OleDbConnection cnn = new OleDbConnection(strCnn);
           try
           {
               cnn.Open();
               string strSql = "SELECT COUNT(*)FROM Login WHERE User=@User AND Password =@Password";
               OleDbCommand cmd = new OleDbCommand(strSql, cnn);
               cmd.Parameters.AddWithValue("@User", User);
               cmd.Parameters.AddWithValue("@Password", Password);
               if (Convert.ToBoolean(cmd.ExecuteScalar()))
               {
                   return true;
               }
               else
               {
                   MessageBox.Show("Bạn không được cấp quyền để sử dụng chức năng này","Waring",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                   cnn.Close();
                   return false;
               }
           }
           catch (Exception a)
           {
               MessageBox.Show(a.Message);
               return false;
           }
       }
    }
}
