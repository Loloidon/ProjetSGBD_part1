using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.Metier
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string Nom { get; set; }
        public string TypeAnimal { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public bool Sterilise { get; set; }
    }
}
