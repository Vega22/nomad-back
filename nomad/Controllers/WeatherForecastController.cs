using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Newtonsoft.Json;
using nomad.Models;
using MongoDB.Driver;
using nomad.Repositories;

namespace nomad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private ICityCollection db = new CityCollection();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            Random random = new Random();

            Double num = random.NextDouble();
            if(num < 0.1)
            {
                return BadRequest("How unfortunate! The API Request Failed");
            }
            else
            {
                List<weatherModel> result = new List<weatherModel>();
                List<cityModel> cities = GetAllCities().Result;
                for (int i = 0; i < cities.Count; i++)
                {
                    var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={(cities[i].city).Replace("'", string.Empty)}&appid=3e460f4d5fb539b95adac377c36396c9");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);
                    result.Add(JsonConvert.DeserializeObject<weatherModel>(response.Content));
                }

                //return JsonConvert.DeserializeObject<weatherModel>(response.Content);
                return Ok(result);
            }
            
        }

        public async Task<List<cityModel>> GetAllCities()
        {
            var response = await db.GetAllCities();
            return (response);
        }
    }
}
