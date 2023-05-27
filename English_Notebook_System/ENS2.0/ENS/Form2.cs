using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ENS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string filename = @"..\..\..\..\ENB.txt";
            StreamReader reader = new StreamReader(filename);

            int lines = 0;
            Class1.score = 100;
            Class1.times = 1;

            Class1.form4.FormClosed += (_, _) => System.Environment.Exit(0);

            Class1.form4.dataGridView1.ColumnCount = 11;
                for (int k = 0; k < 11; k++)
                {
                    Class1.form4.dataGridView1.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                Class1.form4.dataGridView1.Columns[0].Name = "题序";
                Class1.form4.dataGridView1.Columns[1].Name = "作答情况";
                Class1.form4.dataGridView1.Columns[2].Name = "题目";
                Class1.form4.dataGridView1.Columns[3].Name = "正确答案";
                Class1.form4.dataGridView1.Columns[4].Name = "所在行";
                Class1.form4.dataGridView1.Columns[5].Name = "错误选项之一";
                Class1.form4.dataGridView1.Columns[6].Name = "所在行";
                Class1.form4.dataGridView1.Columns[7].Name = "错误选项之二";
                Class1.form4.dataGridView1.Columns[8].Name = "所在行";
                Class1.form4.dataGridView1.Columns[9].Name = "错误选项之三";
                Class1.form4.dataGridView1.Columns[10].Name = "所在行";
            
            

            string[,] words = new string[1000, 6];
            string[,] Chinese = new string[1000, 6];
            string s = "/";
            string empty = " ";

            while (reader.ReadLine() != null)
            {
                string row = reader.ReadLine();
                lines = lines + 2;
                string[] word = Regex.Split(row, @"\s{3,}");

                for (int j = 0; j <= word.Length - 1; j++)
                {

                    Class1.whole[lines / 2 - 1, j] = word[j];

                    bool f=false;
                    if ( word[j].Contains(empty)||word[j].Contains('-'))
                    {
                        f = true;
                    }
                    if (word[j].Contains(s))
                    {
                        string[] part = word[j].Split('/');
                        words[lines / 2 - 1, j] = part[0];
                        Chinese[lines / 2 - 1, j] = part[2];
                    }
                    else if(f==false)
                    {
                        Chinese[lines / 2 - 1, j] = Regex.Replace(word[j], "[a-zA-Z]", "");

                        for (int k = 0; k < word[j].Length; k++)
                        {
                            if (Chinese[lines / 2 - 1, j].Contains(word[j][k]))
                            {
                                words[lines / 2 - 1, j] = word[j].Substring(0, k);
                                break;
                            }
                        }
                    }


                }

            }


            for(int i=0;i<1000;i++)
            {
                for(int j = 0;j < 6;j++)
                {
                    Class1.T_words[i, j] = words[i, j];
                    Class1.T_Chinese[i, j] = Chinese[i, j];
                }
            }
            Class1.T_lines = lines;
            Random random = new Random();
           
            for (int i = 1; ; i++)
            {
                int r01 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r02 = Convert.ToInt32(random.Next(0, 6));
                int r21 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r22 = Convert.ToInt32(random.Next(0, 6));
                int r31 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r32 = Convert.ToInt32(random.Next(0, 6));
                int r41 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r42 = Convert.ToInt32(random.Next(0, 6));
                
                if (Class1.T_words[r01, r02] != null  && Class1.T_Chinese[r21, r22] != null && Class1.T_Chinese[r31, r32] != null && Class1.T_Chinese[r41, r42] != null)
                {
                    label1.Text = Class1.T_words[r01, r02];
                    button1.Text = Class1.T_Chinese[r01, r02];
                    button2.Text = Class1.T_Chinese[r21, r22];
                    button3.Text = Class1.T_Chinese[r31, r32];
                    button4.Text = Class1.T_Chinese[r41, r42];
                    Class1.answer = Class1.T_Chinese[r01, r02];

                    int index = Class1.form4.dataGridView1.Rows.Add();
                    Class1.form4.dataGridView1.Rows[index].Cells[0].Value = "第" + Class1.times + "题";
                    Class1.form4.dataGridView1.Rows[index].Cells[2].Value = Class1.T_words[r01, r02];
                    Class1.form4.dataGridView1.Rows[index].Cells[3].Value = Class1.whole[r01, r02];
                    Class1.form4.dataGridView1.Rows[index].Cells[4].Value = "第" + 2 * (r01 + 1) + "行";
                    Class1.form4.dataGridView1.Rows[index].Cells[5].Value = Class1.whole[r21, r22];
                    Class1.form4.dataGridView1.Rows[index].Cells[6].Value = "第" + 2 * (r21 + 1) + "行";
                    Class1.form4.dataGridView1.Rows[index].Cells[7].Value = Class1.whole[r31, r32];
                    Class1.form4.dataGridView1.Rows[index].Cells[8].Value = "第" + 2 * (r31 + 1) + "行";
                    Class1.form4.dataGridView1.Rows[index].Cells[9].Value = Class1.whole[r41, r42];
                    Class1.form4.dataGridView1.Rows[index].Cells[10].Value = "第" + 2 * (r41 + 1) + "行";
                    break;
                }
            }
            int r = Convert.ToInt32(random.Next(0, 10));
            for(int i=1;i<=r;i++)
            {
                string t = button1.Text;
                button1.Text = button2.Text;
                button2.Text = button3.Text;
                button3.Text = button4.Text;
                button4.Text = t;
            }
           
            label2.Text="你的得分：" + Class1.score.ToString();
            label3.Text = "闯关进度" + Class1.times.ToString() + "/25";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != Class1.answer)
            {
                Class1.score = Class1.score - 4;
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "×";
            }
            else
            {
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "√";
            }
            label2.Text = "你的得分：" + Class1.score.ToString();
            Class1.times = Class1.times + 1;
            label3.Text ="闯关进度"+Class1.times.ToString()+"/25";

            if (Class1.times > 25)
            {
                this.Dispose();
                Form3 form3 = new Form3();
                form3.FormClosed += (_, _) => System.Environment.Exit(0);
                form3.ShowDialog();
            }

            else
            {

                Random random = new Random();

                for (int i = 1; ; i++)
                {
                    int r01 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r02 = Convert.ToInt32(random.Next(0, 6));
                    int r21 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r22 = Convert.ToInt32(random.Next(0, 6));
                    int r31 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r32 = Convert.ToInt32(random.Next(0, 6));
                    int r41 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r42 = Convert.ToInt32(random.Next(0, 6));

                    if (Class1.T_words[r01, r02] != null && Class1.T_Chinese[r21, r22] != null && Class1.T_Chinese[r31, r32] != null && Class1.T_Chinese[r41, r42] != null)
                    {
                        label1.Text = Class1.T_words[r01, r02];
                        button1.Text = Class1.T_Chinese[r01, r02];
                        button2.Text = Class1.T_Chinese[r21, r22];
                        button3.Text = Class1.T_Chinese[r31, r32];
                        button4.Text = Class1.T_Chinese[r41, r42];
                        Class1.answer = Class1.T_Chinese[r01, r02];


                        int index = Class1.form4.dataGridView1.Rows.Add();
                        Class1.form4.dataGridView1.Rows[index].Cells[0].Value = "第" + Class1.times + "题";
                        Class1.form4.dataGridView1.Rows[index].Cells[2].Value = Class1.T_words[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[3].Value = Class1.whole[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[4].Value = "第" + 2 * (r01 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[5].Value = Class1.whole[r21, r22];
                        Class1.form4.dataGridView1.Rows[index].Cells[6].Value = "第" + 2 * (r21 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[7].Value = Class1.whole[r31, r32];
                        Class1.form4.dataGridView1.Rows[index].Cells[8].Value = "第" + 2 * (r31 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[9].Value = Class1.whole[r41, r42];
                        Class1.form4.dataGridView1.Rows[index].Cells[10].Value = "第" + 2 * (r41 + 1) + "行";
                        break;
                    }
                }
                int r = Convert.ToInt32(random.Next(0, 10));
                for (int i = 1; i <= r; i++)
                {
                    string t = button1.Text;
                    button1.Text = button2.Text;
                    button2.Text = button3.Text;
                    button3.Text = button4.Text;
                    button4.Text = t;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != Class1.answer)
            {
                Class1.score = Class1.score - 4;
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "×";
            }
            else
            {
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "√";
            }
            label2.Text = "你的得分：" + Class1.score.ToString();
            Class1.times = Class1.times + 1;
            label3.Text = "闯关进度" + Class1.times.ToString() + "/25";

            if (Class1.times > 25)
            {
                this.Dispose();
                Form3 form3 = new Form3();
                form3.FormClosed += (_, _) => System.Environment.Exit(0);
                form3.ShowDialog();
            }
            else
            {
                Random random = new Random();

                for (int i = 1; ; i++)
                {
                    int r01 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r02 = Convert.ToInt32(random.Next(0, 6));
                    int r21 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r22 = Convert.ToInt32(random.Next(0, 6));
                    int r31 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r32 = Convert.ToInt32(random.Next(0, 6));
                    int r41 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r42 = Convert.ToInt32(random.Next(0, 6));

                    if (Class1.T_words[r01, r02] != null && Class1.T_Chinese[r21, r22] != null && Class1.T_Chinese[r31, r32] != null && Class1.T_Chinese[r41, r42] != null)
                    {
                        label1.Text = Class1.T_words[r01, r02];
                        button1.Text = Class1.T_Chinese[r01, r02];
                        button2.Text = Class1.T_Chinese[r21, r22];
                        button3.Text = Class1.T_Chinese[r31, r32];
                        button4.Text = Class1.T_Chinese[r41, r42];
                        Class1.answer = Class1.T_Chinese[r01, r02];

                        int index = Class1.form4.dataGridView1.Rows.Add();
                        Class1.form4.dataGridView1.Rows[index].Cells[0].Value = "第" + Class1.times + "题";
                        Class1.form4.dataGridView1.Rows[index].Cells[2].Value = Class1.T_words[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[3].Value = Class1.whole[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[4].Value = "第" + 2 * (r01 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[5].Value = Class1.whole[r21, r22];
                        Class1.form4.dataGridView1.Rows[index].Cells[6].Value = "第" + 2 * (r21 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[7].Value = Class1.whole[r31, r32];
                        Class1.form4.dataGridView1.Rows[index].Cells[8].Value = "第" + 2 * (r31 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[9].Value = Class1.whole[r41, r42];
                        Class1.form4.dataGridView1.Rows[index].Cells[10].Value = "第" + 2 * (r41 + 1) + "行";
                        break;




                    }
                }
                int r = Convert.ToInt32(random.Next(0, 10));
                for (int i = 1; i <= r; i++)
                {
                    string t = button1.Text;
                    button1.Text = button2.Text;
                    button2.Text = button3.Text;
                    button3.Text = button4.Text;
                    button4.Text = t;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text != Class1.answer)
            {
                Class1.score = Class1.score - 4;
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "×";
            }
            else
            {
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "√";
            }
            label2.Text = "你的得分：" + Class1.score.ToString();
            Class1.times = Class1.times + 1;
            label3.Text = "闯关进度" + Class1.times.ToString() + "/25";

            if (Class1.times > 25)
            {
                this.Dispose();
                Form3 form3 = new Form3();
                form3.FormClosed += (_, _) => System.Environment.Exit(0);
                form3.ShowDialog();
            }
            else
            {
                Random random = new Random();

                for (int i = 1; ; i++)
                {
                    int r01 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r02 = Convert.ToInt32(random.Next(0, 6));
                    int r21 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r22 = Convert.ToInt32(random.Next(0, 6));
                    int r31 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r32 = Convert.ToInt32(random.Next(0, 6));
                    int r41 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r42 = Convert.ToInt32(random.Next(0, 6));

                    if (Class1.T_words[r01, r02] != null && Class1.T_Chinese[r21, r22] != null && Class1.T_Chinese[r31, r32] != null && Class1.T_Chinese[r41, r42] != null)
                    {
                        label1.Text = Class1.T_words[r01, r02];
                        button1.Text = Class1.T_Chinese[r01, r02];
                        button2.Text = Class1.T_Chinese[r21, r22];
                        button3.Text = Class1.T_Chinese[r31, r32];
                        button4.Text = Class1.T_Chinese[r41, r42];
                        Class1.answer = Class1.T_Chinese[r01, r02];

                        int index = Class1.form4.dataGridView1.Rows.Add();
                        Class1.form4.dataGridView1.Rows[index].Cells[0].Value = "第" + Class1.times + "题";
                        Class1.form4.dataGridView1.Rows[index].Cells[2].Value = Class1.T_words[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[3].Value = Class1.whole[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[4].Value = "第" + 2 * (r01 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[5].Value = Class1.whole[r21, r22];
                        Class1.form4.dataGridView1.Rows[index].Cells[6].Value = "第" + 2 * (r21 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[7].Value = Class1.whole[r31, r32];
                        Class1.form4.dataGridView1.Rows[index].Cells[8].Value = "第" + 2 * (r31 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[9].Value = Class1.whole[r41, r42];
                        Class1.form4.dataGridView1.Rows[index].Cells[10].Value = "第" + 2 * (r41 + 1) + "行";
                        break;


                    }
                }
                int r = Convert.ToInt32(random.Next(0, 10));
                for (int i = 1; i <= r; i++)
                {
                    string t = button1.Text;
                    button1.Text = button2.Text;
                    button2.Text = button3.Text;
                    button3.Text = button4.Text;
                    button4.Text = t;
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text != Class1.answer)
            {
                Class1.score = Class1.score - 4;
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "×";
            }
            else
            {
                Class1.form4.dataGridView1.Rows[Class1.times - 1].Cells[1].Value = "√";
            }
            label2.Text = "你的得分：" + Class1.score.ToString();
            Class1.times = Class1.times + 1;
            label3.Text = "闯关进度" + Class1.times.ToString() + "/25";

            if (Class1.times > 25)
            {
                this.Dispose();
                Form3 form3 = new Form3();
                form3.FormClosed += (_, _) => System.Environment.Exit(0);
                form3.ShowDialog();
            }
            else
            {
                Random random = new Random();

                for (int i = 1; ; i++)
                {
                    int r01 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r02 = Convert.ToInt32(random.Next(0, 6));
                    int r21 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r22 = Convert.ToInt32(random.Next(0, 6));
                    int r31 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r32 = Convert.ToInt32(random.Next(0, 6));
                    int r41 = Convert.ToInt32(random.Next(0, Class1.T_lines / 2 - 1)); int r42 = Convert.ToInt32(random.Next(0, 6));

                    if (Class1.T_words[r01, r02] != null && Class1.T_Chinese[r21, r22] != null && Class1.T_Chinese[r31, r32] != null && Class1.T_Chinese[r41, r42] != null)
                    {
                        label1.Text = Class1.T_words[r01, r02];
                        button1.Text = Class1.T_Chinese[r01, r02];
                        button2.Text = Class1.T_Chinese[r21, r22];
                        button3.Text = Class1.T_Chinese[r31, r32];
                        button4.Text = Class1.T_Chinese[r41, r42];
                        Class1.answer = Class1.T_Chinese[r01, r02];

                        int index = Class1.form4.dataGridView1.Rows.Add();
                        Class1.form4.dataGridView1.Rows[index].Cells[0].Value = "第" + Class1.times + "题";
                        Class1.form4.dataGridView1.Rows[index].Cells[2].Value = Class1.T_words[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[3].Value = Class1.whole[r01, r02];
                        Class1.form4.dataGridView1.Rows[index].Cells[4].Value = "第" + 2 * (r01 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[5].Value = Class1.whole[r21, r22];
                        Class1.form4.dataGridView1.Rows[index].Cells[6].Value = "第" + 2 * (r21 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[7].Value = Class1.whole[r31, r32];
                        Class1.form4.dataGridView1.Rows[index].Cells[8].Value = "第" + 2 * (r31 + 1) + "行";
                        Class1.form4.dataGridView1.Rows[index].Cells[9].Value = Class1.whole[r41, r42];
                        Class1.form4.dataGridView1.Rows[index].Cells[10].Value = "第" + 2 * (r41 + 1) + "行";
                        break;


                    }
                }
                int r = Convert.ToInt32(random.Next(0, 10));
                for (int i = 1; i <= r; i++)
                {
                    string t = button1.Text;
                    button1.Text = button2.Text;
                    button2.Text = button3.Text;
                    button3.Text = button4.Text;
                    button4.Text = t;
                }

            } 
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
