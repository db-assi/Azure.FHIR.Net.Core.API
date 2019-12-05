using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HDR_UK_Web_Application.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HDR_UK_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public ModelController(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        //GET: api/Model/5
        [HttpGet("{id}", Name = "Model")]
        public async Task<IActionResult> Get(string id)
        {
            var content = HDR_UK_Web_Application.Models.Patient.PatientParameters(id);

            var stringContent = new StringContent(content);

            AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.Development.json");

            var client = _httpClientFactory.CreateClient("machinelearning");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response;

            response = await client.PostAsync($"{config.MLBaseAddress}", stringContent);

            var responseString = await response.Content.ReadAsStringAsync();

            return Ok(responseString);

        }

    }
}
