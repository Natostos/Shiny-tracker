using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_tracker
{
    public class Pokemons
    {
        string name;
        int nbEgg;
        bool found;

        public Pokemons(string n)
        {
            name = n;
            nbEgg = 0;
            found = false;
        }

        public string getName() { return this.name; }

        public void setFound(bool b = true) { found = b; }

        public bool getFound() { return this.found; }

        public int getEggs() { return this.nbEgg; }
        public void setEggs(int i) { this.nbEgg = i; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
