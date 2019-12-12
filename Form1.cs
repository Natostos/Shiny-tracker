using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_tracker
{
    public partial class Form1 : Form
    {
        double chance = 511d / 512d;
        int nbEggs = 0;
        public Form1()
        {
            InitializeComponent();
            label4.Text = chance.ToString("F3") + "%";
            label3.Text = nbEggs.ToString();

            BindingSource bs = new BindingSource();
            bs.DataSource = Data.PokemonList;
            comboBox1.DataSource = bs;
            comboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            nbEggs++;
            Data.PokemonList[comboBox1.SelectedIndex].setEggs(nbEggs);
            label3.Text = nbEggs.ToString();
            chance = 100d - (Math.Pow((511d / 512d), nbEggs + 1) * 100);
            label4.Text = chance.ToString("F3") + "%";
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            nbEggs += 5;
            Data.PokemonList[comboBox1.SelectedIndex].setEggs(nbEggs);
            label3.Text = nbEggs.ToString();
            chance = 100d - (Math.Pow((511d / 512d), nbEggs + 1) * 100);
            label4.Text = chance.ToString("F3") + "%";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            Data.PokemonList[comboBox1.SelectedIndex].setFound();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nbEggs = Data.PokemonList[comboBox1.SelectedIndex].getEggs();
            label3.Text = nbEggs.ToString();
            chance = 100d - (Math.Pow((511d / 512d), nbEggs + 1) * 100);
            label4.Text = chance.ToString("F3") + "%";
            checkBox1.Checked = Data.PokemonList[comboBox1.SelectedIndex].getFound();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(comboBox1.SelectedIndex, this);
            f.Show();
        }

        public void update()
        {
            nbEggs = Data.PokemonList[comboBox1.SelectedIndex].getEggs();
            label3.Text = nbEggs.ToString();
            chance = 100d - (Math.Pow((511d / 512d), nbEggs + 1) * 100);
            label4.Text = chance.ToString("F3") + "%";
            checkBox1.Checked = Data.PokemonList[comboBox1.SelectedIndex].getFound();
        }
    }
}
