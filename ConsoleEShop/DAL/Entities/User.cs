using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.DAL.Entities
{
    public class User
    {
        public User(string userName, UserType type, int id)
        {
            UserName = userName;
            Id = id;
            Type = type;
        }
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"{UserName} {Type} {Id}";
        }
    }
}
