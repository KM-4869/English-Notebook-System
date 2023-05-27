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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string filename = @"..\..\..\..\ENB.txt";
            StreamReader reader = new StreamReader(filename);

            int lines = 0;

            if (comboBox1.SelectedIndex == -1)
            {
                richTextBox1.Text = "请先选择模式";

            }

           else if (comboBox1.SelectedItem.ToString() == "普通搜索")
            {

                while (reader.ReadLine() != null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");

                    for (int j = 0; j <= word.Length - 1; j++)
                    {
                        string[] part = word[j].Split('/');
                        if (part[0].Contains(input))
                        {
                            richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                        }
                    }



                }
            }
            else if (comboBox1.SelectedItem.ToString() == "顺序搜索")
            {
                while (reader.ReadLine() != null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");

                    for (int j = 0; j <= word.Length - 1; j++)
                    {
                        string[] part = word[j].Split('/');
                        if (part[0].Length >= input.Length)
                        {
                            string head = part[0].Substring(0, input.Length);
                            if (head == input)
                            {
                                richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                            }
                        }
                    }
                }
            }
            else  if (comboBox1.SelectedItem.ToString() == "模糊搜索")
            {

                while (reader.ReadLine() != null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");
                    bool b = true;
                    for (int j = 0; j <= word.Length - 1; j++)
                    {
                        string[] part = word[j].Split('/');
                        
                        for (int k = 0; k < input.Length; k++) 
                        {
                            if(part[0].Contains(input[k]))
                            {
                                b = true;
                            }
                            else
                            {
                                b = false;
                                break;
                            }
                        }
                       if(b==true)
                        {
                            richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                        }
                        
                    }



                }


            }
            else if (comboBox1.SelectedItem.ToString() == "中文检索")
            {

                while (reader.ReadLine() != null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");

                    for (int j = 0; j <= word.Length - 1; j++)
                    {

                        if (word[j].Contains(input))
                        {
                            richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                        }
                    }



                }
            }
            else if(comboBox1.SelectedItem.ToString() == "词组短语")
            {
                while(reader.ReadLine()!=null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");

                    for (int j = 0; j <= word.Length - 1; j++)
                    {
                        string[] part = word[j].Split('/');
                        if (part[0].Contains(" ")||part[0].Contains("-"))
                        {
                            richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                        }
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "词尾搜索")
            {
                while (reader.ReadLine() != null)
                {
                    string row = reader.ReadLine();
                    lines = lines + 2;
                    string[] word = Regex.Split(row, @"\s{3,}");

                    for (int j = 0; j <= word.Length - 1; j++)
                    {
                        if(word[j].Contains('/'))
                        {
                            string[] part = word[j].Split('/');
                            if(part[0].Length>=input.Length)
                            {
                                string tail = part[0].Substring(part[0].Length - input.Length, input.Length);
                                if(tail==input)
                                {
                                    richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                                }
                            }
                            
                        }
                        else
                        {
                            string[] part = new string[2];
                            part[1]= Regex.Replace(word[j], "[a-zA-Z]", "");
                            
                            for (int k = 0; k < word[j].Length; k++)
                            {
                                if (part[1].Contains(word[j][k]))
                                {
                                    part[0] = word[j].Substring(0, k);
                                    break;
                                }
                            }
                            if (part[0] != null)
                            {
                                if (part[0].Length >= input.Length)
                                {
                                    string tail = part[0].Substring(part[0].Length - input.Length, input.Length);
                                    if (tail == input)
                                    {
                                        richTextBox1.Text = richTextBox1.Text + word[j] + "    " + "第" + lines.ToString() + "行" + "\n";
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
            textBox1.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.FormClosed += (_, _) => Show();
            form2.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
