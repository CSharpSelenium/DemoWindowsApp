using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a =int.Parse( textBox1.Text);
            int b = int.Parse(textBox2.Text);
            int c = a + b;
            textBox3.Text = c.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <=100 ; i++)
            {
                
                progressBar1.Value = i;
            }
        }
    }
}
