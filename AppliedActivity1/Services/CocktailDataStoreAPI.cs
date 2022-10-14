

using System.Dynamic;
using AppliedActivity1.Models;
using Newtonsoft.Json;
using EmployeeApplication.Services;

namespace AppliedActivity1.Services
{
    class EmployeeDataStoreAPI : ICocktailDataStore<Cocktail>
    {
        private static string API => "https://www.thecocktaildb.com/api/json/v1/1/search.php";

        public async Task<IEnumerable<Cocktail>> GetCocktailAsync(String name)
        {
            var service = DependencyService.Get<IWebClientService>();
            var json = await service.GetAsync($"{API}?s={name}");

            var employees = CocktailBuilder(json);

            return employees;
        }

     

        private List<Cocktail> CocktailBuilder(string json)
        {

            var response = JsonConvert.DeserializeObject<dynamic>(json);
            var datas = response.results;

            var cocktail = new List<Cocktail>();

            foreach (var data in datas)
            {
                var name = data.drinks.strDrink.ToString();
             
                var discription = data.drinks.strInstructions.ToString();


                cocktail.Add(new Cocktail(name, discription));

            }

            return cocktail;
        }

        public static class UserBuilder
        {
           
        }
    }
}
