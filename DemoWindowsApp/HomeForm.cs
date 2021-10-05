using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsApp
{
    public partial class HomeForm : Form
    {
        public static int EmpId { get; set; }
        public static string EmpName { get; set; }
        public static string EmpLocation { get; set; }
        public static int Empsalary { get; set; }
        public static int EmpDeptId { get; set; }
        public HomeForm()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("Select * from empinfo", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DgvEmpInfo.DataSource = ds.Tables[0];
            
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void DgvEmpInfo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            EmpId = int.Parse(DgvEmpInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
            EmpName = DgvEmpInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
            EmpLocation = DgvEmpInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
            Empsalary = int.Parse(DgvEmpInfo.Rows[e.RowIndex].Cells[3].Value.ToString());
            EmpDeptId = int.Parse(DgvEmpInfo.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(EmpId>0)
            {
                UpdateForm updateForm = new UpdateForm();
                updateForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select EMployee to update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(EmpId>0)
            {
                DeleetForm deleetForm = new DeleetForm();
                deleetForm.Show();
            }
            else
            {
                MessageBox.Show("Please select Employee to Delete");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            DgvEmpInfo.Visible = false;
            for (int i = 1; i <=100 ; i++)
            {
                Thread.Sleep(10);
                progressBar1.Value = i;
            }
            progressBar1.Visible = false;
            DgvEmpInfo.Visible = true;
            SqlConnection conn = new SqlConnection("server=TYSS-ELF;Database=EmployeeDB;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("Select * from empinfo", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DgvEmpInfo.DataSource = ds.Tables[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
