using HR_DATA.HR_Module.UserMgt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace HR_DATA.Data
{
    public class Seed
    {
        private readonly DataContext _Context;
        public Seed(DataContext context)
        {
            _Context = context;
        }
        public void SeedData()
        {
           var users = System.IO.File.ReadAllText("Data/seed-data.json");
            //var Address = System.IO.File.ReadAllText("Data/Address.json");
            //var addresses = JsonConvert.DeserializeObject<List<Country>>(Address);
            //foreach(var r in addresses)
       
            //{
            //    _Context.Countries.Add()
            //}
           var edata = JsonConvert.DeserializeObject<List<User>>(users);
            foreach(var user in edata)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName = user.UserName.ToLower();

                _Context.Users.Add(user);
            
            }
            _Context.SaveChanges();

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        }
}
