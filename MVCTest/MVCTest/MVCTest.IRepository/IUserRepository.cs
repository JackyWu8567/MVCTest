using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.IRepository
{
    public interface IUserRepository
    {
        bool VerifyUser(string userName, string password, ref List<string> roles);
    }
}
