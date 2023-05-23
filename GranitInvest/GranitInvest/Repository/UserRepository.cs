using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using GranitInvest.Model;

namespace GranitInvest.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {

            using var databaseConnection = GetConnection();
            databaseConnection.Open();

            const string selectStatement = "select * from User where username = @username and password = @password";
            using var selectCommand = new SQLiteCommand(selectStatement, databaseConnection);

            selectCommand.Parameters.AddWithValue("@Username", credential.UserName);
            selectCommand.Parameters.AddWithValue("@Password", credential.Password);
            using var selectReader = selectCommand.ExecuteReader();

            return selectReader.Read() && selectReader["Username"] != DBNull.Value;
        }

        public void Add(User userModel)
        {
            using var databaseConnection = GetConnection();
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

        public void Edit(User userModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            User user = null!;
            using var databaseConnection = GetConnection();
            databaseConnection.Open();
            var selectCommand = databaseConnection.CreateCommand();
            selectCommand.CommandText = @"SELECT * FROM User WHERE Username = $Username";

            selectCommand.Parameters.AddWithValue("$Username", username);
            using var selectReader = selectCommand.ExecuteReader();

            if (selectReader.Read())
            {
                user = new User(
                    selectReader.GetInt32(0),
                    selectReader.GetString(1),
                    string.Empty,
                    selectReader.GetString(3),
                    selectReader.GetString(4),
                    selectReader.GetString(5),
                    selectReader.GetInt32(6) == 1
                );
            }

            return user;
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
