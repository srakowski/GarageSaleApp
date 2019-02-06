using System;
using System.Collections.Generic;
using System.IO;
using GarageSaleApp.Domain;
using Microsoft.Data.Sqlite;

namespace GarageSaleApp.DataAccess
{
    public class SqliteGarageSaleEventRepository : IGarageSaleEventRepository
    {
        private string _filename;

        public SqliteGarageSaleEventRepository(string directory)
        {
            _filename = Path.Combine(directory, "garagesale.db");
        }

        public IEnumerable<GarageSaleEvent> Events
        {
            get
            {
                try
                {
                    var events = new List<GarageSaleEvent>();

                    using (var db = new SqliteConnection($"Filename={_filename}"))
                    {
                        db.Open();

                        SqliteCommand selectCommand = new SqliteCommand(
                            @"SELECT
                            Id,
                            Name,
                            StartDate,
                            EndDate,
                            Notes from Events", db);

                        SqliteDataReader query = selectCommand.ExecuteReader();



                        while (query.Read())
                        {
                            var gse = new GarageSaleEvent();
                            gse.Name = query.GetString(1);
                            gse.StartDate = query.GetDateTime(2);
                            gse.EndDate = query.GetDateTime(3);
                            gse.Notes = query.IsDBNull(4) ? null : query.GetString(4);
                            events.Add(gse);
                        }

                        db.Close();
                    }

                    return events;
                }
                catch (Exception ex)
                {
                    return new List<GarageSaleEvent>();
                }
            }
        }

        public void Add(GarageSaleEvent entity)
        {
            try
            {
                using (var db = new SqliteConnection($"Filename={_filename}"))
                {
                    db.Open();

                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = @"
                    INSERT INTO Events (
                        Name,
                        StartDate,
                        EndDate,
                        Notes
                    ) VALUES (
                        @Name,
                        @StartDate,
                        @EndDate,
                        @Notes
                    );";

                    insertCommand.Parameters.AddWithValue("@Name", entity.Name);
                    insertCommand.Parameters.AddWithValue("@StartDate", entity.StartDate);
                    insertCommand.Parameters.AddWithValue("@EndDate", entity.EndDate);
                    insertCommand.Parameters.AddWithValue("@Notes", entity.Notes ?? (object)DBNull.Value);

                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
