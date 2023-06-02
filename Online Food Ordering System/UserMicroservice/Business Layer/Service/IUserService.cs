using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.UserMicroservice.Business_Layer.Service
{
    public interface IUserService
    {
        void RegisterUser(UserDto userDto);
       (string token, int userId) Login(UserLoginDTO userLoginDto);
    }

}
  
