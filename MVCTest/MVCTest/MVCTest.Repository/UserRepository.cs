using MVCTest.DataModel;
using MVCTest.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool VerifyUser(string userName, string password, ref List<string> roles)
        {
            try
            {
                using (var dbContext = new MVCTestEntities())
                {
                    var user = dbContext.Users.SingleOrDefault(u => u.name.Equals(userName) && u.password.Equals(password));
                    if (user != null)
                    {
                        foreach (var role in user.UserRoles)
                        {
                            roles.Add(role.Role.name);
                        }
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;                
            }            
        }
    }
}
