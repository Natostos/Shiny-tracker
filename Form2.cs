using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Shiny_tracker
{
    public partial class Form2 : Form
    {
        int nbPok;
        Form1 f;
        public Form2()
        {
            InitializeComponent();
            nbPok = 0;
            f = null;
        }

        public Form2(int i, Form1 f1)
        {
            InitializeComponent();
            nbPok = i;
            f = f1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Data.PokemonList[nbPok].setEggs(Data.PokemonList[nbPok].getEggs() - 1);
            f.update();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Data.PokemonList[nbPok].setEggs(0);
            f.update();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Data.PokemonList[nbPok].setFound(false);
            f.update();
        }

        private string AskFileSave(string input)
        {
            OpenFileDialog fb = new OpenFileDialog
            {
                ValidateNames = true,
                CheckFileExists = false,
                CheckPathExists = false,
                FileName = input
            };
            if (fb.ShowDialog() == DialogResult.OK)
                return fb.FileName;
            return null;
        }

        private string AskFileLoad(string input, string filter) // Par Corentin Rondier
        {
            OpenFileDialog fb = new OpenFileDialog
            {
                ValidateNames = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = filter,
                FilterIndex = 1,
                FileName = input
            };
            if (fb.ShowDialog() == DialogResult.OK)
                return fb.FileName;
            return null;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string path = AskFileSave("Select Saving file");
            if (path == null)
                return;
            for (int i = 0; i < Data.PokemonList.Length; i ++)
                File.AppendAllText(@path, JsonConvert.SerializeObject(Data.PokemonList[i]));
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string path = AskFileLoad("Select Saving file", "JSON Config File (*.json)|*.json|All files (*.*)|*.*");
            if (path == null)
                return;
            Data.PokemonList = JsonConvert.DeserializeObject<Pokemons[]>(File.ReadAllText(@path));
        }
    }
}
