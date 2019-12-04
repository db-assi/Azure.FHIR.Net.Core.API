using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HDR_UK_Web_Application.Models
{
    public class User
    {
        public string userId { get; set; }
        public string username { get; set; }
        public string profile { get; set; }
        public string token { get; set; }

        public User() { }

    }


}
