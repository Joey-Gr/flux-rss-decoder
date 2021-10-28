using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace service.Controllers
{
    [EnableCors("Policy1")]
    [ApiController]
    [Route("[controller]")]
    public class Rss : ControllerBase
    {

        private readonly ILogger<Rss> _logger;

        public Rss(ILogger<Rss> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<String> Get(string feedUrl)
        {
            // notre cible
            string page = "https://coquillages.com/category/articles/feed/";

            using var client = new HttpClient();

            var result = await client.GetStringAsync(page);

            return result;
        }
    }
}
