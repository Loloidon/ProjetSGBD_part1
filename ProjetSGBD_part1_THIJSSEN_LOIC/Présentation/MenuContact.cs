using ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.Présentation
{
    public class MenuContact
    {
        private readonly ContactRepository _contactRepository;
        
        public MenuContact(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public void Ajout()
        {
            Contact contact= new Contact();
            Console.WriteLine("Entrez le nom de la personne de contact");
            contact.Nom = Console.ReadLine();

            Console.WriteLine("Entrez le prénom de la personne de contact");
            contact.Prenom = Console.ReadLine();

            Console.WriteLine("Entrez le n* de registre national de la personne de contact");
            contact.Registre=(Console.ReadLine());

            Console.WriteLine("Entrez l'adresse de la personne de contact");
            contact.Adresse = Console.ReadLine();

            Console.WriteLine("Entrez le gsm de la personne de contact");
            contact.Gsm = (Console.ReadLine());

            Console.WriteLine("Entrez le mail de la personne de contact");
            contact.Mail = Console.ReadLine();

            Console.WriteLine("Contact ajouté !");

        }
        private int LireEntier(string message)
        {
            int valeur;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out valeur))
                    return valeur;

                Console.WriteLine("Veuillez entrer un nombre valide.");
            }
        }

        private string LireChoix(string message, string[] choixValides)
        {
            while (true)
            {
                Console.Write(message);
                string valeur = Console.ReadLine()?.Trim() ?? "";

                string? choixTrouve = choixValides
                    .FirstOrDefault(c => c.Equals(valeur, StringComparison.OrdinalIgnoreCase));

                if (choixTrouve != null)
                    return choixTrouve;

                Console.WriteLine("Choix invalide.");
            }
        }
    }
}
