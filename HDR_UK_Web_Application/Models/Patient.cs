using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDR_UK_Web_Application.Models
{
    public static class Patient
    {
        public static JObject PatientsDetails(JObject json)
        {

            var result =
                from p in json["entry"].Children()
                select new
                {
                    id = (string)p["resource"]["id"],
                    birthDate = (string)p["resource"]["birthDate"],
                    profile = (string)p["resource"]["resourceType"],
                    name = (string)p["resource"]["name"][0]["family"],
                    gender = (string)p["resource"]["gender"]
                };

            JObject o = JObject.FromObject(new { result });

            return o;

        }

        //public static JObject PatientDetails(JObject json)
        //{

        //    var result =
        //        from p in json
        //        select new
        //        {
        //            id = (string)p["id"],
        //            birthDate = (string)p["birthDate"],
        //            profile = (string)p["resourceType"],
        //            name = (string)p["name"][0]["family"],
        //            gender = (string)p["gender"]
        //        };

        //    JObject o = JObject.FromObject(new { result });

        //    return o;

        //}

        public static string PatientParameters(string id)
        {
            return "{\"first_breathcount\": 89, \"fev1_z_min\": -0.5, \"sex\": \"Female\", \"age\": 10.0, \"staph_aureus\": 1}";
        }
    }
}
