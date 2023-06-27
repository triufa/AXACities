using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitiesApp.Controllers;
using CitiesApp.Helpers;
using System.Collections.Generic;

namespace CitiesTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestGetNamesMatches()
        {
            List<string> FirstParameter = new List<string> {"BANDUNG", "BANGUI", "BANGKOK", "BANGALORE"};
            string FirstSeachTerm = "BANG";
            List<string> FirstExpectedResult = new List<string> { "BANGUI", "BANGKOK", "BANGALORE" };
            CollectionAssert.AreEqual(FirstExpectedResult, Algorithm.GetNamesMatches(FirstParameter, FirstSeachTerm));

            List<string> SecondParameter = new List<string> { "LA PAZ", "LA PLATA","LAGOS", "LEEDS"};
            string SecondSeachTerm = "LA";
            List<string> SecondExpectedResult = new List<string> {"LA PAZ", "LA PLATA", "LAGOS"};
            CollectionAssert.AreEqual(SecondExpectedResult, Algorithm.GetNamesMatches(SecondParameter, SecondSeachTerm));

            List<string> ThirdParameter = new List<string> { "ZARIA", "ZHUGHAI", "ZIBO" };
            string ThirdSeachTerm = "ZE";
            List<string> ThirdExpectedResult = new List<string>();
            CollectionAssert.AreEqual(ThirdExpectedResult, Algorithm.GetNamesMatches(ThirdParameter, ThirdSeachTerm));
        }

        [TestMethod]
        public void GetNextCharacters()
        {
            List<string> FirstParameter = new List<string> { "BANGUI", "BANGKOK", "BANGALORE" };
            string FirstSeachTerm = "BANG";
            List<string> FirstExpectedResult = new List<string> { "U", "K", "A" };
            CollectionAssert.AreEqual(FirstExpectedResult, Algorithm.GetNextCharacters(FirstParameter, FirstSeachTerm));

            List<string> SecondParameter = new List<string> { "LA PAZ", "LA PLATA", "LAGOS" };
            string SecondSeachTerm = "LA";
            List<string> SecondExpectedResult = new List<string> { " ", "G"};
            CollectionAssert.AreEqual(SecondExpectedResult, Algorithm.GetNextCharacters(SecondParameter, SecondSeachTerm));

            List<string> ThirdParameter = new List<string>();
            string ThirdSeachTerm = "ZE";
            List<string> ThirdExpectedResult = new List<string>();
            CollectionAssert.AreEqual(ThirdExpectedResult, Algorithm.GetNextCharacters(ThirdParameter, ThirdSeachTerm));
        }
    }
}
