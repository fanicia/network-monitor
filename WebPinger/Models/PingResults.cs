using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebPinger.Models
{
    public class PingResults
    {
        public HttpStatusCode GoogleHttp { get; set; }
        public HttpStatusCode NetflixHttp { get; set; }
        public HttpStatusCode StofaHttp { get; set; }
    }
}
