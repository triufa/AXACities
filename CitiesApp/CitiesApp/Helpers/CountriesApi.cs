using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApp.Helpers
{
    //classes json api cities
    public class CountriesAPI
    {
        public bool error { get; set; }
        public string msg { get; set; }
        public CountriesData[] data { get; set; }
    }

    public class CountriesData
    {
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public string country { get; set; }
        public string[] cities { get; set; }
    }
}
