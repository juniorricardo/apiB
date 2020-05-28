using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiB.Service;
using Newtonsoft.Json;
using apiB.Entities;

namespace apiB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/Weather/city
        [HttpGet("{city}", Name = "Get")]
        public ActionResult Get(string city)
        {
            WeatherService weatherService = new WeatherService();
            var data = weatherService.GetWeather(city);

            return Ok(data.Result);
        }
    }
}
