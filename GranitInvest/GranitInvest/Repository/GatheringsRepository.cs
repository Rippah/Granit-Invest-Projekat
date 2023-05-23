using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using GranitInvest.Model;

namespace GranitInvest.Repository
{
    public class GatheringsRepository : RepositoryBase, IGatheringsRepository
    {
        public void Add(Gatherings gatherings)
        {
            using var databaseConnection = GetConnection();
            databaseConnection.Open();

            const string insertStatement =
                @"insert into Gatherings(Name, Description, Date, Location, Profile, Link) values (@Name, @Description, @Date, @Location, @Profile, @Link)";
            using var insertCommand = new SQLiteCommand(insertStatement, databaseConnection);
            insertCommand.Parameters.AddWithValue("@Name", gatherings.Name);
            insertCommand.Parameters.AddWithValue("@Description", gatherings.Description);
            insertCommand.Parameters.AddWithValue("@Date", gatherings.Date);
            insertCommand.Parameters.AddWithValue("@Location", gatherings.Location);
            insertCommand.Parameters.AddWithValue("@Profile", gatherings.Profile);
            insertCommand.Parameters.AddWithValue("@Link", gatherings.Link);
            insertCommand.ExecuteNonQuery();
        }

        public Gatherings GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Gatherings GetByName(string name)
        {
            using var databaseConnection = GetConnection();
            databaseConnection.Open();

            const string selectStatement = "select * from Gatherings where Name = @Name";
            using var selectCommand = new SQLiteCommand(selectStatement, databaseConnection);
            selectCommand.Parameters.AddWithValue("@Name", name);
            using var selectReader = selectCommand.ExecuteReader();

            return selectReader.Read()
                ? new Gatherings(selectReader.GetInt32(0), selectReader.GetString(1), selectReader.GetString(2), selectReader.GetString(3),
                    selectReader.GetString(4), selectReader.GetString(5), selectReader.GetString(6))
                : null;
        }

        public DataTable GetAll(DataTable dt)
        {
            using var databaseConnection = GetConnection();
            databaseConnection.Open();

            const string selectStatement = "select * from Gatherings order by Id";
            using var selectCommand = new SQLiteCommand(selectStatement, databaseConnection);
            selectCommand.Parameters.AddWithValue("$Date",
                DateTime.Today.ToString("dd/MM/yyyy", new CultureInfo("en-US")));
            dt.Load(selectCommand.ExecuteReader());
            return dt;
        }
    }
}
