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

        public static AuthResponse SignIn(string name, string password)
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
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var jsonObj = JsonConvert.DeserializeObject<dynamic>(content);

                    var authResponse = new AuthResponse
                    {
                        Roles = new List<string>(),
                        Authenticated = true,
                        BearerToken = jsonObj.access_token
                    };

                    foreach (var role in jsonObj.roles.Value.Split(','))
                    {
                        authResponse.Roles.Add(role);
                    }
                    return authResponse;
                }
                else
                {
                    return new AuthResponse { Authenticated = false };
                }
            }
        }
    }
}
