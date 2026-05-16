using ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess;
using ProjetSGBD_part1_THIJSSEN_LOIC.Présentation;

string connectionString =
    "Host=localhost;Port=5432;Database=projet_sgbd;Username=postgres;Password=Postgres2026";

AnimalRepository animalRepository = new AnimalRepository(connectionString);
MenuAnimal menuAnimal = new MenuAnimal(animalRepository);

CompatibiliteRepository compatibiliteRepository = new CompatibiliteRepository(connectionString);
MenuCompatibilite menuCompatibilite = new MenuCompatibilite(compatibiliteRepository, animalRepository);

ContactRepository contactRepository = new ContactRepository(connectionString);
MenuContact menuContact = new MenuContact(contactRepository);
bool continuer = true;

while (continuer)
{
    Console.WriteLine("=== Refuge Animaux ===");
    Console.WriteLine("1. Ajouter un animal");
    Console.WriteLine("2. Afficher tous les animaux");
    Console.WriteLine("3. Afficher un animal");
    Console.WriteLine("4. Supprimer un animal");
    Console.WriteLine("5. Ajouter une compatibilité à un animal");
    Console.WriteLine("6. Supprimer une compatibilité à un animal");
    Console.WriteLine("7. Ajouter un contact");
    Console.WriteLine("8. Afficher un contact");
    Console.WriteLine("9. Supprimer un contact");
    Console.WriteLine("0. Quitter");
    Console.Write("Choix : ");

    string choix = Console.ReadLine() ?? "";

    switch (choix)
    {
        case "1":
            menuAnimal.AjouterAnimal();
            break;

        case "2":
            menuAnimal.AfficherTout();
            break;

        case "3":
            menuAnimal.AfficherUn();
            break;

        case "4":
            menuAnimal.SupprimerUn();
            break;

        case "5":
            menuCompatibilite.AjouterCompatibilite();
            break;
        case "6":
            menuCompatibilite.SupprimerCompatibilite();
            break;
        case "7":
            menuContact.Ajout();
            break;

        case "8":
            menuContact.AfficherTout();
            menuContact.AfficherUn();
            break;
        case "9":
            menuContact.SupprimerUn();
            break;

        case "0":
            continuer = false;
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}