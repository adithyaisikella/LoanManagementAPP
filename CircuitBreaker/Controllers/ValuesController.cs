using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CircuitBreaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IHttpClientFactory httpClientFactory;
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var client = httpClientFactory.CreateClient("LoanManagementAPPService");
            var response = await client.GetAsync("/v1.1/UserDetails/LoginUserDetails");
            return JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

        }

      
        
    }
}
