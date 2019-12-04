using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HDR_UK_Web_Application.Models
{
    public static class Authentication
    {
        public static User AuthenticateUser(string username, string password)
        {
            StreamReader stream = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Data/users.json"));
            string json = stream.ReadToEnd();

            JObject o = JObject.Parse(json);

            var users =
                from p in o["users"].Children()
                select new
                {
                    id = (string)p["id"],
                    username = (string)p["username"],
                    password = (string)p["password"],
                    profile = (string)p["profile"]

                }
                into a
                where a.username.Contains(username) && a.password.Contains(password)
                select a;

            User user = new User();

            foreach (var item in users)
            {
                user.profile = item.profile.ToLower();
                user.userId = item.id;
                user.username = item.username;
                user.token = "fake-jwt-token";
            }

            return user;
        }
    }
}
