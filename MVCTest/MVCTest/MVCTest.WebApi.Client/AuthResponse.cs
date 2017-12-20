using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.WebApi.Client
{
    public class AuthResponse
    {
        public bool Authenticated { get; private set; }

        public List<string> Roles { get; private set; }

        public BearerToken Token { get; private set; }
    }

    public class BearerToken
    {
        public string AccessToken { get; private set; }

        public DateTime Issued { get; private set; }

        public DateTime Expired { get; private set; }
    }
}
