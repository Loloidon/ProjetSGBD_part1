using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ProjetSGBD_part1_THIJSSEN_LOIC.Metier;

namespace ProjetSGBD_part1_THIJSSEN_LOIC.DataAccess
{

    public class CompatibiliteRepository
    {
        private readonly string _connectionString;

        public CompatibiliteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Ajouter(Compatibilite compatibilite)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = @"
            INSERT INTO compatibilite
            (id_animal, type_compatibilite, valeur, description)
            VALUES
            (@id_animal, @type_compatibilite, @valeur, @description);
        ";

            using var command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id_animal", compatibilite.IdAnimal);
            command.Parameters.AddWithValue("@type_compatibilite", compatibilite.TypeCompatibilite);
            command.Parameters.AddWithValue("@valeur", compatibilite.Valeur);
            command.Parameters.AddWithValue("@description",
                string.IsNullOrWhiteSpace(compatibilite.Description)
                    ? DBNull.Value
                    : compatibilite.Description);

            command.ExecuteNonQuery();
        }
    }
}
