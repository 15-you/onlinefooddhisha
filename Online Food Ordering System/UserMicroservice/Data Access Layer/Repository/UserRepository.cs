using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool UsernameExists(string username)
        {
            return _dbContext.Users.Any(u => u.Username == username);
        }

        public bool EmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
