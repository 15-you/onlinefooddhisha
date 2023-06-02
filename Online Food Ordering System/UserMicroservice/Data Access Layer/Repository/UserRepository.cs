using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;



namespace Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(User user)
        {
            _appDbContext.Users.Add(user);
        }

        public void Update(User user)
        {
            _appDbContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            _appDbContext.Users.Remove(user);
        }

        public User GetById(int id)
        {
            return _appDbContext.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public bool UsernameExists(string username)
        {
            return _appDbContext.Users.Any(u => u.Username == username);
        }

        public bool EmailExists(string email)
        {
            return _appDbContext.Users.Any(u => u.Email == email);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}