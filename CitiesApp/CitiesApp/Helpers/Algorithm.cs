using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApp.Helpers
{
    //Algorithm methods
    public class Algorithm
    {
        public static List<string> GetNamesMatches(List<string> SetOfCities, string Word)
        {
            List<string> result = SetOfCities.Where(d => d.StartsWith(Word)).ToList();
            return result;
        }

        public static List<string> GetNextCharacters(List<string> SetOfCities, string Word)
        {
            //select only the ones that have a next character after the selected word if not select ""
            List<string> result = SetOfCities.Select(s => (s.IndexOf(Word) + Word.Length + 1) <= s.Length ? s.Substring(s.IndexOf(Word) + Word.Length, 1) : "").ToList();
            //select distinct characters and remove ""
            return result.Distinct().Where(s => s != "").ToList();
        }
    }
}
