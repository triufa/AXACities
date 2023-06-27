using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitySearch
{
    using System.Collections.Generic;

    public interface ICityResult
    {
        ICollection<string> NextLetters { get; set; }

        ICollection<string> NextCities { get; set; }
    }
}

namespace CitySearch
{
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }
}