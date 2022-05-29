using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml;

namespace GuiClient
{
    public partial class MainWindow : Form
    {
        
        public MainWindow()
        {
            InitializeComponent();
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            try
            {
                textBoxTitle.Text = Movie.getTitles();
                updateItems();
            }
            catch (System.Net.WebException ex)
            {
                textBoxTitle.Text = "Server not working!";
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
            AddOrModifyItem form = new AddOrModifyItem(maxId + 1);
            form.ShowDialog(this);
            updateItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WtfClient.deleteId(((Movie)listBox1.SelectedItem).Id);
            updateItems();
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            var selectedMovie = (Movie)listBox1.SelectedItem;
            if (selectedMovie != null)
            {
                AddOrModifyItem form = new AddOrModifyItem(selectedMovie);
                form.ShowDialog(this);
                updateItems();
                buttonDelete.Enabled = false;
                buttonUpdate.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = listBox1.SelectedIndex != -1;
            buttonUpdate.Enabled = listBox1.SelectedIndex != -1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddOrModifyItem form = new AddOrModifyItem((Movie) listBox1.SelectedItem);
            form.ShowDialog(this);
            updateItems();
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }
    }
}
