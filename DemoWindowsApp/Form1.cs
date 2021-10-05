using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         //   notifyIcon1.ShowBalloonTip(10, "Info", "selected employee was deleted", ToolTipIcon.Error);
            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("select count(*) from logintable where username=@uname and Password=@pwd", conn);
            cmd.Parameters.Add(new SqlParameter("@uname",tbUname.Text));
            cmd.Parameters.Add(new SqlParameter("@pwd",tbpwd.Text));
            conn.Open();
            int noofrows =(int) cmd.ExecuteScalar();
            conn.Close();
            if (noofrows > 0)
            {
                //lblResult.ForeColor = Color.Green;
                //lblResult.Text = "Loggged In Successfully";
                HomeForm homeForm = new HomeForm();
                homeForm.Show();

            }
            else
            {
                MessageBox.Show("Invalid Username or password");
                //lblResult.ForeColor = Color.Red;
                //lblResult.Text = "Invalid Username or password";

            }



        }
    }
}
