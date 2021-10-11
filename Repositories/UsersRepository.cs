

using CoreApi_JWT.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreApi_JWT.Repositories
{
    public class UsersRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "First user", Password = "first" });
            users.Add(new User { Id = 2, Username = "Second user", Password = "second" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}