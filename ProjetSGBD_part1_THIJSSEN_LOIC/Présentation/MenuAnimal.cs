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

            _animalRepository.Ajouter(animal);

            Console.WriteLine("Animal ajouté !");
        }
    }
}
