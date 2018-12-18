using BookModels.Helper;
using BookModels.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookModels.ViewModels
{
    public class MainViewModel
    {
        //Interaktionen
        public DelegateCommand ShowSearchCommand { get; set; }
        public DelegateCommand ShowResultsCommand { get; set; }
        public DelegateCommand ShowFavoritesCommand { get; set; }


        public MainViewModel()
        {
            ShowSearchCommand = new DelegateCommand(ShowSearch);
            ShowResultsCommand = new DelegateCommand(ShowResults, p => SearchBookService.LastSearchResult != null);
            ShowFavoritesCommand = new DelegateCommand(ShowFavorites,  p => FavoritesManager.Favorites.Count > 0);

            SearchBookService.SuccessfulSearch += (aaaa, bbbb) => ShowResultsCommand.OnCanExecuteChanged(); 
            FavoritesManager.FavoritesChanged += (asd, asda) => ShowFavoritesCommand.OnCanExecuteChanged();
        }

        public void ShowSearch(object p)
        {
            NavigationHelper.Service.Navigate(NavigationTargets.Search, new SearchViewModel());
        }

        public void ShowResults(object p)
        {
            
            NavigationHelper.Service.Navigate(NavigationTargets.Results, new ResultViewModel(SearchBookService.LastSearchResult));
        }

        public void ShowFavorites(object p)
        {
            NavigationHelper.Service.Navigate(NavigationTargets.Favorites, new ResultViewModel(FavoritesManager.Favorites));
        }
    }
}