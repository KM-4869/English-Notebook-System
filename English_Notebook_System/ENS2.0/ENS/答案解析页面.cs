using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENS
{
    public partial class 答案解析页面 : Form
    {
        public 答案解析页面()
        {
            InitializeComponent();
            button1.Text = "返回首页";
            button2.Text = "结束一切";

          





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Class1.form4.Hide();
            for (int i = 0; i < 25; i++)
            {
                Class1.form4.dataGridView1.Rows.RemoveAt(0);
            }
            
            Form1 form1 = new Form1();
            form1.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
