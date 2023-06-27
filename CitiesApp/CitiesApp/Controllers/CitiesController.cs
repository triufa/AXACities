using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitySearch;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using CitiesApp.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace CitiesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase, ICityFinder
    {
        private IMemoryCache _cacheProvider;
        public CitiesController(IMemoryCache cacheProvider)
        {            
            _cacheProvider = cacheProvider;
        }

        //Api methods
        [HttpGet("{searchString}")]
        public string Get(string searchString)
        {            
            return JsonSerializer.Serialize(this.Search(searchString));
        }

        //implementation of ICityFinder
        public ICityResult Search(string searchString)
        {
            //check if there is a cache element if not call api and create element
            if (!_cacheProvider.TryGetValue("_Cities", out List<string> cities))
            {
                cities = new List<string>();
                //Just to have information calls an api to get all the cities 
                CountriesAPI ob = ApiCall.GetAsync<CountriesAPI>("https://countriesnow.space/api/v0.1/countries").Result;
                foreach (CountriesData datCountries in ob.data)
                {
                    foreach (string datCities in datCountries.cities)
                    {
                        cities.Add(datCities.ToUpper());
                    }
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddDays(20),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cacheProvider.Set("_Cities", cities, cacheEntryOptions);
            }
            //Clean the cities using distinct and remove ""
            cities = cities.Distinct().Where(s => s != "").ToList();

            return new CityResult(searchString.ToUpper(), cities);
        }

        //implementation of ICityResult
        public class CityResult : ICityResult
        {
            public ICollection<string> NextLetters { get; set; }
            public ICollection<string> NextCities { get; set; }

            public CityResult(string searchString, List<string> Cities)
            {
                //Call algorithm and get Next Cities
                NextCities = Algorithm.GetNamesMatches(Cities, searchString);

                //Call algorithm and get Next Characters using NextCities Result
                NextLetters = Algorithm.GetNextCharacters(NextCities.ToList(), searchString);
            }
        }
    }
}
