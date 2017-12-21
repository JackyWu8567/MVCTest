using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.WebApi.Client
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }

        public List<string> Roles { get; set; }

        public string BearerToken { get; set; }
    }
}
