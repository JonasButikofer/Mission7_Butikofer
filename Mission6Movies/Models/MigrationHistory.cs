using Microsoft.Data.Sqlite;

namespace Mission6Movies.Models  // This should match the Models folder namespace
{
    public static class MigrationHelper
    {
        public static void CreateMigrationsHistoryTable()
        {
            var connectionString = "Data Source=YourDatabaseFileName.db"; // Make sure this points to your SQLite file
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
                    MigrationId TEXT NOT NULL,
                    ProductVersion TEXT NOT NULL,
                    PRIMARY KEY(MigrationId)
                );
            ";

            command.ExecuteNonQuery();
        }
    }
}
