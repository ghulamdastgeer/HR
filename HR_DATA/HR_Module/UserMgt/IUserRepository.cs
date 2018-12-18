using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_DATA.HR_Module.UserMgt
{
    public interface IUserRepository
    {
        Task<User> Register(User user,string password);

        Task<User> Login(User user,string password);

        Task<bool> UserExists(string username);
      
        Task<User> Get(int id);
        void RemoveEmployee(User user);
        Task<List<User>> GetAllUsers();

        Task<bool> SaveAll();

    }
}
