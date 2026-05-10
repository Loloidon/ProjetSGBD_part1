using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;
using Npgsql;
namespace ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess
{
    public class AnimalRepository
    {
        private readonly string _connectionString;

        public AnimalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Ajouter(Animal animal)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                Insert INTO animal
                (nom,type_animal, sexe, date_naissance, sterilise)
                VALUES
                (nom,@type_animal,@sexe,#date_naissance,@sterilise);
            ";

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nom", animal.Nom);
            command.Parameters.AddWithValue("@type_animal", animal.TypeAnimal);
            command.Parameters.AddWithValue("@sexe", animal.Sexe);
            command.Parameters.AddWithValue("@date_naissance", animal.DateNaissance);
            command.Parameters.AddWithValue("@sterilise", animal.Sterilise);

            command.ExecuteNonQuery();

            connection.Close();
        }

    }
}
