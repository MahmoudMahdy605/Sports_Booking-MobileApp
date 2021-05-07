using Firebase.Database;
using Firebase.Database.Query;
using SportsBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBookingApp.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExists(string email)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Email == email).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string email, string passwd)
        {
            if (await IsUserExists(email) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                    Email = email,
                    Password = passwd
                });
                return true;
            }
            else return false;
        }

        public async Task<bool> LoginUser(string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            return (user != null);
        }
    }

}
