using System.Data.SQLite;
using System.IO;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        string dbPath = "expenses.db";
        string connString = $"Data Source={dbPath};Version=3;";

        // If DB doesn't exist, create it
        if (!File.Exists(dbPath))
        {
            SQLiteConnection.CreateFile(dbPath);
        }

        using (var conn = new SQLiteConnection(connString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();

            // Create Categories table
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );";
            cmd.ExecuteNonQuery();

            // Seed default categories if none exist
            string[] defaultCategories = { "Food", "Rent", "Salary", "Entertainment", "Utilities", "Clothes", "Other" };

            foreach (string category in defaultCategories)
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Categories WHERE Name = @name";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", category);
                int exists = Convert.ToInt32(cmd.ExecuteScalar());

                if (exists == 0)
                {
                    cmd.CommandText = "INSERT INTO Categories (Name) VALUES (@name)";
                    cmd.ExecuteNonQuery();
                }
            }



            // Create Transactions table
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Transactions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Amount REAL NOT NULL,
                    Type TEXT NOT NULL, -- 'Income' or 'Expense'
                    CategoryId INTEGER NOT NULL,
                    Date TEXT NOT NULL,
                    Notes TEXT,
                    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                );";
            cmd.ExecuteNonQuery();
        }
    }
}
