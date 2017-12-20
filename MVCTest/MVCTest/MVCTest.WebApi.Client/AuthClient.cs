using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCTest.WebApi.Client
{
    public static class AuthClient
    {
        private static Uri BaseAddress
        {
            get
            {
                return new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
            }
        }

        public static void SignIn(string name, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;

                var response = client.PostAsync("Token", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("grant_type", "password"),
                                new KeyValuePair<string, string>("username", name),
                                new KeyValuePair<string, string>("password", password)
                            })).Result;

                var content = response.Content.ReadAsStringAsync().Result;
                var jsonObj = JsonConvert.DeserializeObject<dynamic>(content);

            }
        }
    }
}
