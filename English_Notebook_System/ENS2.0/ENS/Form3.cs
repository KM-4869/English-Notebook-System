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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            label1.Text = "你最终的得分为    " + Class1.score;
            button1.Text = "查看每题答案与选项";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Class1.form4.Show();
        }
    }
}
