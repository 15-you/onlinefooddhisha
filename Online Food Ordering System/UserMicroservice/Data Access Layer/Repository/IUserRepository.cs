using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Repository
{
    public interface IUserRepository
    {
        User GetById(int userId);
        User GetByUsername(string username);
        bool UsernameExists(string username);
        bool EmailExists(string email);
        User Add(User user);
        User Update(User user);
        void Delete(User user);
        void SaveChanges();
    }
}
