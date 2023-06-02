namespace Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }

}
