using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GranitInvest.Model;

namespace GranitInvest.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;

            if (!File.Exists("baza.sqlite3"))
                SQLiteConnection.CreateFile("./baza.sqlite3");

            const string databaseFilePath = "./baza.sqlite3";

            using var databaseConnection = new SQLiteConnection("Data Source=" + databaseFilePath);
            databaseConnection.Open();

            const string selectStatement = "select * from User where username = @username and password = @password";
            using var selectCommand = new SQLiteCommand(selectStatement, databaseConnection);

            selectCommand.Parameters.AddWithValue("@Username", credential.UserName);
            selectCommand.Parameters.AddWithValue("@Password", credential.Password);
            using var selectReader = selectCommand.ExecuteReader();

            var selectedUsers = new List<UserModel>();

            while (selectReader.Read())
            {
                selectedUsers.Add(new UserModel(selectReader.GetInt32(0), selectReader.GetString(1), selectReader.GetString(2)));
            }
            return validUser = selectedUsers.Capacity == 0 ? false : true;
        }

        public void Add(UserModel userModel)
        {
            if (!File.Exists("baza.sqlite3"))
                SQLiteConnection.CreateFile("./baza.sqlite3");

            const string databaseFilePath = "./baza.sqlite3";

            using var databaseConnection = new SQLiteConnection("Data Source=" + databaseFilePath);
            databaseConnection.Open();

            const string insertStatement =
                "insert into User(username, password, email, name, surname) values (@username, @password, @email, @name, @surname)";
            using var insertCommand = new SQLiteCommand(insertStatement, databaseConnection);

            insertCommand.Parameters.AddWithValue("@Username", userModel.Username);
            insertCommand.Parameters.AddWithValue("@Password", userModel.Password);
            insertCommand.Parameters.AddWithValue("@Email", userModel.Email);
            insertCommand.Parameters.AddWithValue("@Name", userModel.Name);
            insertCommand.Parameters.AddWithValue("@Surname", userModel.Surname);
            insertCommand.ExecuteNonQuery();

        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
