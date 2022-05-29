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
            button2.Enabled = false;
            button3.Enabled = false;
            try
            {
                textBox1.Text = WtfClient.getPrettyNames();
                updateItems();
            }
            catch (System.Net.WebException ex)
            {
                textBox1.Text = "Server not working!";
                //textBox1.Text = ex.ToString();
            }
        }

        private void updateItems()
        {
            listBox1.Items.Clear();
            foreach (var item in WtfClient.getItems())
            {
                listBox1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var maxId = 0;
            foreach(var item in listBox1.Items) {
                var casted = (Movie)item;
                if(maxId < casted.Id)
                {
                    maxId = casted.Id;
                }
            }
            AddItem form = new AddItem(maxId + 1);
            form.ShowDialog(this);
            updateItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WtfClient.deleteId(((Movie)listBox1.SelectedItem).Id);
            updateItems();
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listBox1.SelectedIndex != -1;
            button3.Enabled = listBox1.SelectedIndex != -1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddItem form = new AddItem((Movie) listBox1.SelectedItem);
            form.ShowDialog(this);
            updateItems();
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
