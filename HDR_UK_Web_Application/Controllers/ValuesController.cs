using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using HDR_UK_Web_Application.utils;
using System.Net.Http;

namespace HDR_UK_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ValuesController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuesController(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        //[HttpGet]
        //public string Get()
        //{

        //    return cache.GetOrCreate<string>("IDGKey", cacheEntry =>
        //    {
        //        cacheEntry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
        //        return DateTime.Now.ToString();
        //    });
        //}

        //[HttpGet]
        //public Task<String> Get()
        //{
        //    Task<string> accessToken = null;

        //    cache.GetOrCreateAsync<string>("AccessToken", cacheEntry =>
        //    {
        //        cacheEntry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
        //        return accessToken = AccessToken.CreateAccessToken();
        //    });

        //    return accessToken;
        //}


        [HttpGet]
        public async Task<String> Get()
        {
            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.Development.json");

            string accessToken = await _cache.GetOrCreateAsync<string>("AccessToken", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
                return AccessToken.CreateAccessToken();
            });

            if (_cache.TryGetValue<string>("AccessToken", out accessToken))
            {
                var client = _httpClientFactory.CreateClient();
                var apiCaller = new ProtectedApiCallHelper(client);

                return apiCaller.CallWebApiAndProcessResultASync($"{config.BaseAddress}/Patient", accessToken).GetAwaiter().GetResult();
            } else
            {
                return "0";
            }



        }


        // GET api/values/5
        [HttpGet("{key}")]
        public string Get(string key)
        {
            return _cache.Get<string>(key);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
