using Npgsql;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess
{
    public class ContactRepository
    {
        private readonly string _connectionString;

        public ContactRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ajouter(Contact contact)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            INSERT INTO contact
            (nom, prenom, registre, adresse, gsm, mail)
            VALUES
            (@nom, @prenom, @registre, @adresse, @gsm, @mail);
        ";

            using var command = new NpgsqlCommand(sql, connection);

            
            command.Parameters.AddWithValue("@nom", contact.Nom);
            command.Parameters.AddWithValue("@prenom",contact.Prenom);
            command.Parameters.AddWithValue("@registre",contact.Registre);
            command.Parameters.AddWithValue("@adresse",contact.Adresse);
            command.Parameters.AddWithValue("@gsm", contact.Gsm);
            command.Parameters.AddWithValue("@mail", contact.Mail);
                

            command.ExecuteNonQuery();
        }
        public void Supprimer(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                        DELETE FROM contact
                        WHERE id_contact = @id;
                    ";

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            int nbLignes = command.ExecuteNonQuery();

            if (nbLignes > 0)
            {
                Console.WriteLine("Contact supprimé.");
            }
            else
            {
                Console.WriteLine("Contact introuvable.");
            }
        }
    }
}
