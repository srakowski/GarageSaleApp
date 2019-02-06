using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace GarageSaleApp.DataAccess
{
    public class SqliteDatabase
    {
        public static void Initialize(string directory)
        {
            try
            {
                using (var db = new SqliteConnection($"Filename={Path.Combine(directory, "garagesale.db")}"))
                {
                    db.Open();

                    var tableCommand = @"CREATE TABLE IF NOT EXISTS
                        Events (
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                        Name NVARCHAR(512) NOT NULL,
                            StartDate DATETIME NOT NULL,
	                        EndDate DATETIME NOT NULL,
	                        Notes NVARCHAR(2048),
	                        PRIMARY KEY(Id)
                        ); ";

                    SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                    createTable.ExecuteReader();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
