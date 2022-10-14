

using AppliedActivity1.Models;
using AppliedActivity1.Services;
using DevExpress.Data.XtraReports.Native;
using MvvmHelpers.Commands;

namespace AppliedActivity1.ViewModels
{

    internal class CocktailListViewModel
    {
        public ICocktailDataStore<Cocktail> DataStore => DependencyService.Get<ICocktailDataStore<Cocktail>>();
        public ObservableRangeCollection<Cocktail> Cocktail { get; set; }
        public AsyncCommand PageAppearingCommand { get; }

        public CocktailListViewModel()
        {
            Cocktail = new ObservableRangeCollection<Cocktail>();
            PageAppearingCommand = new AsyncCommand(PageAppearing);
        }

        public async Task Refresh()
        {
            var cocktail = await DataStore.GetCocktailAsync("margarita");

            Cocktail.AddRange(cocktail);
        }

        async Task PageAppearing()
        {
            await Refresh();
        }
    }
}
