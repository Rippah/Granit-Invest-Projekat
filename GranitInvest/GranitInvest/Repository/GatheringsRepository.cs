using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GranitInvest.Model;

namespace GranitInvest.Repository
{
    public class GatheringsRepository : RepositoryBase, IGatheringsRepository
    {
        public void Add(Gatherings gatherings)
        {
            throw new NotImplementedException();
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
                ? new Gatherings(selectReader.GetInt32(0), selectReader.GetString(1), selectReader.GetString(2),
                    selectReader.GetString(3), selectReader.GetString(4))
                : null;
        }

        public DataTable GetAll(DataTable dt)
        {
            using var databaseConnection = GetConnection();
            databaseConnection.Open();

            const string selectStatement = "select * from Gatherings";
            using var selectCommand = new SQLiteCommand(selectStatement, databaseConnection);

            dt.Load(selectCommand.ExecuteReader());
            return dt;
        }
    }
}
