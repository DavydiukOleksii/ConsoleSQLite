using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleSQLite
{
    class Program
    {
        static void Main(string[] args)
        {

            string CreateHeroesQuery = @"CREATE TABLE IF NOT EXISTS
                            [Heroes] (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Name] NVARCHAR(30) NULL,
                            [Descriptions] NVARCHAR(1000) NULL,
                            [Image] NVARCHAR(50) NULL,
                            [StatsId] INTEGER NULL,
                            [Skill1Id] INTEGER NULL,
                            [Skill2Id] INTEGER NULL,
                            [Skill3Id] INTEGER NULL,
                            [Skill4Id] INTEGER NULL)";

            string CreateSkillsQuery = @"CREATE TABLE IF NOT EXISTS
                            [Skills] (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Name] NVARCHAR(30) NULL,
                            [Descriptions] NVARCHAR(1000) NULL,
                            [Image] NVARCHAR(50) NULL,
                            [StatsId] INTEGER NULL)";

            string CreateStatsQuery = @"CREATE TABLE IF NOT EXISTS
                            [Stats] (
                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Attack] INTEGER NULL,
                            [Armor] INTEGER NULL,
                            [Health] INTEGER NULL,
                            [Miss] INTEGER NULL)";


            SQLiteConnection.CreateFile("MemesDB.db");

            using (SQLiteConnection conn = new SQLiteConnection("data source=MemesDB.db"))
            {
                conn.Open();

                using (SQLiteCommand com = new SQLiteCommand(conn))
                {
                    //creating Heroes table
                    com.CommandText = CreateHeroesQuery;
                    com.ExecuteNonQuery();

                    //creating Skills table
                    com.CommandText = CreateSkillsQuery;
                    com.ExecuteNonQuery();

                    //creating Stats table
                    com.CommandText = CreateStatsQuery;
                    com.ExecuteNonQuery();

                    //Add Nichosi to Heroes table
                    com.CommandText = "INSERT INTO Heroes(Name, Descriptions, Image, StatsId, Skill1Id, Skill2Id, Skill3Id, Skill4Id) values ('Nichosi', 'Very bed meme.', 'Nichosi', 1, 1, 2, 3, 4)";
                    com.ExecuteNonQuery();

                    //Add Skills
                    com.CommandText = "INSERT INTO Skills(Image, Name, Descriptions, StatsId) values ('NS1', 'Sk1', 'Descsk1', 2)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Skills(Image, Name, Descriptions, StatsId) values ('NS2', 'Sk2', 'Descsk2', 3)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Skills(Image, Name, Descriptions, StatsId) values ('NS3', 'Sk3', 'Descsk3', 4)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Skills(Image, Name, Descriptions, StatsId) values ('NS4', 'Sk4', 'Descsk4', 5)";
                    com.ExecuteNonQuery();


                    //Add hero stats
                    com.CommandText = "INSERT INTO Stats(Attack, Armor, Health, Miss) values (5, 2, 100, 25)";
                    com.ExecuteNonQuery();

                    //Add skill stats
                    com.CommandText = "INSERT INTO Stats(Attack, Armor, Health, Miss) values (10, 0, 0, 0)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Stats(Attack, Armor, Health, Miss) values (-10, 0, 0, 0)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Stats(Attack, Armor, Health, Miss) values (0, 10, 0, 0)";
                    com.ExecuteNonQuery();

                    com.CommandText = "INSERT INTO Stats(Attack, Armor, Health, Miss) values (0, 0, 0, 25)";
                    com.ExecuteNonQuery();


                    string findRow = "Nichosi";

                    com.CommandText = "SELECT * FROM Heroes WHERE Name = '" + findRow + "'";

                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Name"] + ": " + reader["Descriptions"]);
                        }
                    }
                }

                conn.Close();
            }
            Console.WriteLine("end");
            Console.ReadLine();
        } 
    }
}
