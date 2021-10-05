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
    public partial class DeleetForm : Form
    {
        public DeleetForm()
        {
            InitializeComponent();
            textBox1.Text = HomeForm.EmpId.ToString();
            textBox2.Text = HomeForm.EmpName;
            textBox3.Text = HomeForm.EmpLocation;
            textBox4.Text = HomeForm.Empsalary.ToString();
            textBox5.Text = HomeForm.EmpDeptId.ToString();

        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("delete from empinfo  where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", textBox1.Text));
            conn.Open();
            int noofrows = cmd.ExecuteNonQuery();
            conn.Close();
            if (noofrows > 0)
            {
                MessageBox.Show("Deleted  successfully");
              
                this.Close();
            }
            else
            {
                MessageBox.Show("Try Later");
            }
        }
    }
}
