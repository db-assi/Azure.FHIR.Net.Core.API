using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public static class Patient
    {
        
        public static void getHospitalNumberDateOfBirth(string json)
        {
            JObject bundle = JObject.Parse(json);

            JArray entries = (JArray)bundle["entry"];

            var result =
                from p in bundle["entry"].Children()
                select new
                {
                    identifier = (string)p["resource"]["id"],
                    birthDate = (string)p["resource"]["birthDate"]
                }
                into a
                where a.identifier.Contains("af47b8b6-d2a9-424f-ac8a-32c3c1175469")
                select a;


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

    }
}
