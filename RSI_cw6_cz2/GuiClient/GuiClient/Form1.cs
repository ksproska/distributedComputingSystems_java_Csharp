using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiClient
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            try
            {
                textBox1.Text = WtfClient.getAllCurrentItemsPretty();
            }
            catch (System.Net.WebException ex)
            {
                textBox1.Text = "Server not working!";
                //textBox1.Text = ex.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
