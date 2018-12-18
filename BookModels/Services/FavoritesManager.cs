using BookModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace BookModels.Services
{
    public static class FavoritesManager
    {
        public static event EventHandler FavoritesChanged;

        public static List<Book> Favorites { get; set; }

        static FavoritesManager()
        {
            //TODO: ExceptionHandling
            if(File.Exists(File_Name))
            {
                StreamReader reader = new StreamReader(File_Name);
                string jsonString = reader.ReadToEnd();
                Favorites =  JsonConvert.DeserializeObject<List<Book>>(jsonString);
                reader.Close();
            }
            else 
                Favorites = new List<Book>();
        }

        public const string File_Name = "favorites.fs";

        public static void SaveFavorites()
        {
            using (StreamWriter writer = new StreamWriter(File_Name))
            {
                string jsonString = JsonConvert.SerializeObject(Favorites);
                writer.Write(jsonString);
                writer.Close();
            }
        }

        public static void AddBookToFavorites(Book book)
        {
            book.IsFavorite = true;
            //Füge das Buch nur hinzu, wenn es in der Favoritenliste noch
            //kein anderes Buch mit der selben ID gibt
            if (!Favorites.Any(b => b.ID == book.ID))
            {
                Favorites.Add(book);
                FavoritesChanged?.Invoke(null, EventArgs.Empty);
                SaveFavorites();
            }
        }

        public static void RemoveBookFromFavorites(Book book)
        {
            //Suche nach dem zu löschenden Buch
            book.IsFavorite = false;
            Book bookToDelete = Favorites.FirstOrDefault(b => b.ID == book.ID);
            if (bookToDelete != null)
            {
                Favorites.Remove(bookToDelete);
                FavoritesChanged?.Invoke(null, EventArgs.Empty);
                SaveFavorites();
            }
        }
    }
}
