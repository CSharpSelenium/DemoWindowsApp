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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            textBox1.Text = HomeForm.EmpId.ToString();
            textBox2.Text = HomeForm.EmpName;
            textBox3.Text = HomeForm.EmpLocation;
            textBox4.Text = HomeForm.Empsalary.ToString();
            textBox5.Text = HomeForm.EmpDeptId.ToString();




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("Update empinfo set name=@name,location=@loc,Salary=@sal,DeptId=@deptid where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@name", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@loc", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@sal", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@deptid", textBox5.Text));
            conn.Open();
            int noofrows = cmd.ExecuteNonQuery();
            conn.Close();
            if (noofrows > 0)
            {
                MessageBox.Show("UPdated successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Try Later");
            }
        }
    }
}
