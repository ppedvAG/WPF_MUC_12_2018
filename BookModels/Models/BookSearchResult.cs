using System;
using System.Collections.Generic;
using System.Text;

namespace BookModels.Models
{
    
    //Diese Klassen wurden automatisch auf Basis eines Json-Strings mittels Edit->Paste Special-> Paste JSON as Classes generiert
    public class BookSearchResult
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public Volumeinfo volumeInfo { get; set; }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public Imagelinks imageLinks { get; set; }
        public string previewLink { get; set; }
    }


    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
        public string thumbnail { get; set; }
    }
}
