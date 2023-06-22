namespace EXCELITAS.Models
{
    public class UserModel
    {
        public List<User> UserList { get; set; }
    }

    public class User
    {
        public int Id_user { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
