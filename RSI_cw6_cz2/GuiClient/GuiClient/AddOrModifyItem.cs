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
    public partial class AddOrModifyItem : Form
    {
        Movie currentMovie;
        public AddOrModifyItem(int maxId)
        {
            InitializeComponent();
            currentMovie = new Movie() { Id = maxId };
        }
        public AddOrModifyItem(Movie movieToUpdate)
        {
            InitializeComponent();
            currentMovie = movieToUpdate;
            textBoxTitle.Text = currentMovie.Title;
            textBox2.Text = currentMovie.Length.ToString();
            textBox3.Text = currentMovie.Director;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentMovie.Title = textBoxTitle.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                return;
            }
            if(textBox2.Text.Length > 0)
            {
                currentMovie.Length = int.Parse(textBox2.Text);
            }
            else
            {
                currentMovie.Length = 0;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            currentMovie.Director = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WtfClient.deleteId(currentMovie.Id);
            WtfClient.postNewItem(currentMovie);
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
