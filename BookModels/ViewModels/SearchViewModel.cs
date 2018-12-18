using BookModels.Helper;
using BookModels.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookModels.ViewModels
{
    public class SearchViewModel : ModelBase
    {
        public event EventHandler<string> MessageShow;

        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetValue(ref _searchTerm, value);
                SearchBooksCommand.OnCanExecuteChanged();
            }
        }

        public DelegateCommand SearchBooksCommand { get; set; }

        public SearchViewModel()
        {
            SearchBooksCommand = new DelegateCommand(SearchBooks, CanSearchBooks);
        }

        private bool CanSearchBooks(object arg)
        {
            return !string.IsNullOrWhiteSpace(SearchTerm);
        }

        private async void SearchBooks(object obj)
        {
            var result = await SearchBookService.SearchBooks(SearchTerm);
            if (result.status == "OK")
            {
                //Zur Ergebnisansicht navigieren
                if (result.books.Count > 0)
                    NavigationHelper.Service.Navigate(NavigationTargets.Results, new ResultViewModel(result.books));
                else
                    MessageShow?.Invoke(this, "Keine Treffer");
            }
            else
            {
                MessageShow?.Invoke(this, result.status);
            }
        }
    }
}