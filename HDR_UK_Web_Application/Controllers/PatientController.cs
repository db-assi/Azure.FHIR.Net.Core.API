using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HDR_UK_Web_Application.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace HDR_UK_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public PatientController(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/Patient
        public async Task<IActionResult> Get()
        {
            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.Development.json");

            string accessToken = await _cache.GetOrCreateAsync<string>("AccessToken", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromMinutes(59));
                return AccessToken.CreateAccessToken();
            });

            if (_cache.TryGetValue<string>("AccessToken", out accessToken))
            {
                var client = _httpClientFactory.CreateClient();
                var apiCaller = new ProtectedApiCallHelper(client);

                var response = await apiCaller.CallWebApiAndProcessResultASync($"{config.BaseAddress}/Patient", accessToken);
                var result = HDR_UK_Web_Application.Models.Patient.PatientsDetails(JObject.Parse(response));

                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Access denied." });
            }



        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.Development.json");

            string accessToken = await _cache.GetOrCreateAsync<string>("AccessToken", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(TimeSpan.FromMinutes(59));
                return AccessToken.CreateAccessToken();
            });

            if (_cache.TryGetValue<string>("AccessToken", out accessToken))
            {
                var client = _httpClientFactory.CreateClient();
                var apiCaller = new ProtectedApiCallHelper(client);

                var response = await apiCaller.CallWebApiAndProcessResultASync($"{config.BaseAddress}/Patient/{id}", accessToken);
                //var result = HDR_UK_Web_Application.Models.Patient.PatientDetails(JObject.Parse(response));

                return Ok(response);
            }
            else
            {
                return BadRequest(new { message = "Access denied." });
            }
        }

        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
