using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;
using ProjetSGBD_part1_THIJSSEN_LOIC.Présentation;
namespace ProjetSGBD_part1_THIJSSEN_LOIC.Présentation
{
    public class MenuAnimal
    {
        private readonly AnimalRepository _animalRepository;

        public MenuAnimal(AnimalRepository animalRepository)
        {
            _animalRepository=animalRepository;
        }

        public void AjouterAnimal()
        {
            Animal animal = new Animal();

            Console.Write("Nom :");
            animal.Nom = Console.ReadLine() ?? "";

            Console.Write("Type animal (chat/chien :");
            animal.TypeAnimal = Console.ReadLine() ?? "";

            Console.Write("Sexe (M/F) :");
            animal.Sexe = Console.ReadLine() ?? "";

            Console.Write("Date naissance (yyyy-mm-dd) :");
            animal.DateNaissance=DateTime.Parse(Console.ReadLine()?? "");

            Console.Write("Stérilisé ? true/false : ");
            animal.Sterilise = bool.Parse(Console.ReadLine() ?? "false");

            if(animal.Sterilise==true)
            {
                Console.Write("Date sterilisation (yyyy-mm-dd) ?");
                animal.DateSterilisation = DateTime.Parse(Console.ReadLine());
            }
            Console.Write("Couleurs ?");
            animal.Couleurs = Console.ReadLine();

            Console.Write("Description ?");
            animal.Description = Console.ReadLine();

            Console.Write("Particularités ?");
            animal.Particularites = Console.ReadLine();

            Console.Write("Etat courant ? (au refuge - chez son propriétaire - accueilli - adopté - décédé)");
            animal.EtatCourant = Console.ReadLine();

            if(animal.EtatCourant=="décédé")
            {
                Console.Write("Date décès ? (yyyy-mm-dd");
                animal.DateDeces = DateTime.Parse(Console.ReadLine());
            }

            _animalRepository.Ajouter(animal);

            Console.WriteLine("Animal ajouté !");
        }
    }
}
