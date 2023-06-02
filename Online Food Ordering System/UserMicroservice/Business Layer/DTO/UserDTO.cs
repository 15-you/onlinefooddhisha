using System.ComponentModel.DataAnnotations;

namespace Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO
{
    public class UserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
