using BookModels.Helper;
using BookModels.Models;
using BookModels.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookModels.ViewModels
{
    public class ResultViewModel : ModelBase
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetValue(ref _books, value); }
        }

        public DelegateCommand AddFavoriteCommand { get; set; }
        public DelegateCommand RemoveFavoriteCommand { get; set; }


        public ResultViewModel(IEnumerable<Book> books) : this()
        {
            Books = new ObservableCollection<Book>(books);
        }

        public ResultViewModel()
        {
            AddFavoriteCommand = new DelegateCommand(AddBookToFavorites);
            RemoveFavoriteCommand = new DelegateCommand(RemoveBookFromFavorites);
        }

        private void RemoveBookFromFavorites(object obj)
        {
           if(obj is Book book)
           {
              FavoritesManager.RemoveBookFromFavorites(book);
           }
        }

        private void AddBookToFavorites(object obj)
        {
            if(obj is Book book)
            {
                FavoritesManager.AddBookToFavorites(book);
            }
        }
    }
}