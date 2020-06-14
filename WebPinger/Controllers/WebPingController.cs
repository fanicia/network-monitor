using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebPinger.Models;

namespace WebPinger.Controllers
{
    [Route("web-pinger")]
    public class WebPingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        
        public WebPingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("check-internet-connection")]
        public async Task<IActionResult> CheckInternet()
        {
            var client = _clientFactory.CreateClient();
            var googleRequest = await client.GetAsync("https://www.google.com/");
            var netflixRequest = await client.GetAsync("https://www.netflix.com/");
            var stofaRequest = await client.GetAsync("https://stofa.dk/");

            var results = new PingResults
            {
                GoogleHttp = googleRequest.StatusCode,
                NetflixHttp = netflixRequest.StatusCode,
                StofaHttp = stofaRequest.StatusCode
            };

            if (!googleRequest.IsSuccessStatusCode || !netflixRequest.IsSuccessStatusCode || !stofaRequest.IsSuccessStatusCode)
                return StatusCode(StatusCodes.Status500InternalServerError, results);

            return Ok(results);
        }
    }
}
