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
    public partial class AddItem : Form
    {
        Movie createdMovie;
        public AddItem(int maxId)
        {
            InitializeComponent();
            createdMovie = new Movie() { Id = maxId };
        }
        public AddItem(Movie movieToUpdate)
        {
            InitializeComponent();
            createdMovie = movieToUpdate;
            textBox1.Text = createdMovie.Title;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            createdMovie.Title = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WtfClient.deleteId(createdMovie.Id);
            WtfClient.postNewItem(createdMovie);
            this.Close();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }
    }
}
