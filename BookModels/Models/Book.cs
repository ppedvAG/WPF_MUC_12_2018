using BookModels.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookModels.Models
{
    public class Book : ModelBase
    {

        private string _id;

        public string ID
        {
            get { return _id; }
            set { SetValue(ref _id, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        private string[] _authors;
        public string[] Authors
        {
            get { return _authors; }
            set { SetValue(ref _authors, value); }
        }

        private string _previewLink;

        public string PreviewLink
        {
            get { return _previewLink; }
            set { SetValue(ref _previewLink, value); }
        }

        private string _coverURL;

        public string CoverURL
        {
            get { return _coverURL; }
            set { SetValue(ref _coverURL, value); }
        }

        private bool _isFavorite = false;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set {SetValue(ref _isFavorite, value); }
        }

        public Book()
        {

        }

        public Book(string iD, string title, string[] authors, string previewLink, string coverURL)
        {
            ID = iD;
            Title = title;
            Authors = authors;
            PreviewLink = previewLink;
            CoverURL = coverURL;
        }

    }
}
