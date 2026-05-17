using Npgsql;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess
{
    public class AccueilFamilleRepository
    {
        private readonly string _connectionString;

        public AccueilFamilleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ajouter(AccueilFamille accueilfamille)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = @"
                Insert INTO accueil_famille
                (date_debut, date_fin, id_animal, id_contact )
                VALUES
                (@date_debut, @date_fin, @id_animal, @id_contact);
            ";

            using var command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@date_debut", accueilfamille.DateDebut);
            command.Parameters.AddWithValue("@date_fin", accueilfamille.DateFin);
            command.Parameters.AddWithValue("@id_animal", accueilfamille.IdAnimal);
            command.Parameters.AddWithValue("@id_contact", accueilfamille.IdContact);
            



            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
