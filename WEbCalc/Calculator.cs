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

namespace WEbCalc
{
    public partial class Calculator : Form
    {
        string fileName = @"C:\Users\pasyavulav\Documents\Visual Studio 2013\CustomDataFiles\Runtimelog.txt";
        public Calculator()
        {
            InitializeComponent();
        }

        public void RuntimeLog()
        {
            try
            {
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file 
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Runtimelog");
                    fs.Write(author, 0, author.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = (double.Parse(textBox1.Text) + double.Parse(textBox2.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = (double.Parse(textBox1.Text) - double.Parse(textBox2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (double.Parse(textBox1.Text) * double.Parse(textBox2.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox2.Text) != 0)
            {
                textBox3.Text = (double.Parse(textBox1.Text) / double.Parse(textBox2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Division with 0 is not prossible. Enter a non-zero number");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox2.Text) != 0)
            {
                textBox3.Text = (double.Parse(textBox1.Text) % double.Parse(textBox2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Module operator can't work with 0. Try to enter a non-zero number");
            }
        }
    }
}
