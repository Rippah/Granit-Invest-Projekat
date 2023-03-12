namespace GranitInvest.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public UserModel(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public UserModel(int id, string username, string password, string email, string name, string surname) : this(id, username, password)
        {
            Email = email;
            Name = name;
            Surname = surname;
        }
    }
}
