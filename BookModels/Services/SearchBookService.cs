using BookModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookModels.Services
{
    public static class SearchBookService
    {
        public static List<Book> LastSearchResult { get; private set; }


        public static event EventHandler SuccessfulSearch;

        //Tuple: https://docs.microsoft.com/de-de/dotnet/csharp/tuples
        public async static Task<(List<Book> books, string status)> SearchBooks(string searchterm)
        {
            try
            {
                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={searchterm.Replace(' ', '+')}");
                //NuGet-Package: Newtonsoft.Json
                //Deserialisierung: Umwandlung eines strings in ein .NET-Objekt
                BookSearchResult result = JsonConvert.DeserializeObject<BookSearchResult>(json);


                List<Book> books = new List<Book>();

                foreach (var item in result.items)
                {
                    Book newBook = new Book(item.id,
                                            item.volumeInfo?.title,
                                            item.volumeInfo?.authors,
                                            item.volumeInfo?.previewLink,
                                            item.volumeInfo?.imageLinks?.smallThumbnail);

                    books.Add(newBook);
                }
                if (books.Count > 0)
                {
                    LastSearchResult = books;
                    SuccessfulSearch?.Invoke(null, EventArgs.Empty);
                }
                return (books, "OK");
            }
            catch (Exception exp)
            {
                return (null, exp.Message);
            }
        }
    }
}
