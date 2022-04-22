using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TestApiController : ControllerBase
    {
        //claim bazlı yetkilendirmede startup kısmında aldığı yetkiye göre kontrol yapar
        [Authorize(Policy ="ReadTestApi")]
        [HttpGet("{musteriId}")]
        public double Bakiye(int musteriId)
        {
            return 6000.75;
        }

        //claim bazlı yetkilendirmede startup kısmında aldığı yetkiye göre kontrol yapar
        [Authorize(Policy = "ReadTestApi")]
        [HttpGet("{musterId}")]
        public List<string> TumHesaplar(int musteriId)
        {
            return new()
            {
                "159753123",
                "17731949720",
                "sananeogliiim"
            };
        }

    }
}