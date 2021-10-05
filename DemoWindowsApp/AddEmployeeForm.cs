using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsApp
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("insert into empinfo values(@id,@name,@loc,@sal,@deptid)", conn);
            cmd.Parameters.Add(new SqlParameter("@id",textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@name", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@loc", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@sal", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@deptid", textBox5.Text));
            conn.Open();
            int noofrows = cmd.ExecuteNonQuery();
            conn.Close();
            if(noofrows>0)
            {
                MessageBox.Show("Inserted successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Try Later");
            }
        }
    }
}

