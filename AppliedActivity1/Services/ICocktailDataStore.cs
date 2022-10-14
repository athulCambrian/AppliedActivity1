

using AppliedActivity1.Models;

namespace AppliedActivity1.Services
{
    interface ICocktailDataStore<T>
    {
        Task<IEnumerable<Cocktail>> GetCocktailAsync(string name);
    }
}