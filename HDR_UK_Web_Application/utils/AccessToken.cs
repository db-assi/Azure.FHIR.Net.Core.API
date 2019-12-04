using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace HDR_UK_Web_Application.utils
{
    public class AccessToken
    {
        public static async Task<string> CreateAccessToken()
        {
            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.Development.json");

            IConfidentialClientApplication app;

            app = ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.ClientSecret)
                .WithAuthority(new Uri(config.Authority))
                .Build();

            string[] scopes = new string[] { config.Scope };

            AuthenticationResult result = null;

     
            result = await app.AcquireTokenForClient(scopes)
                .ExecuteAsync();

            return result.AccessToken;

        }
    }
}
