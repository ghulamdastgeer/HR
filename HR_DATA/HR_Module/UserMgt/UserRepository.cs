using System.Collections.Generic;
using System.Threading.Tasks;
using HR_DATA.Data;
using HR_DATA.Repository;
using Microsoft.EntityFrameworkCore;

namespace HR_DATA.HR_Module.UserMgt
{
    public class UserRepository : IUserRepository
    {
        private  readonly DataContext _Context;

        public UserRepository(DataContext context) 
        {
            _Context=context;
        }

        public async Task<User> Login(User user,string password)
        {
            var users = await _Context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);

            if (users == null)
                return null;

            if (!VerifyPasswordHash(password, users.PasswordHash, users.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public async  Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _Context.Entry(user.Role).State = EntityState.Unchanged;
            

            await _Context.Users.AddAsync(user);

            //await _Context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public async Task<bool> UserExists(string username)
        {
            if (await _Context.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }

       
        public async Task<User> Get(int id)
        {
         return await _Context.Users.FindAsync(id);
        }

        public void RemoveEmployee(User user)
        {
            _Context.Remove(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
           return await _Context.Users.ToListAsync();
        }
        public async Task<bool> SaveAll()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

    }
}
