using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SportLibrary
{
    [ContentProperty(nameof(Sportart.Spieler))]
    public class Sportart : INotifyPropertyChanged
    {
        public enum HilfsmittelEnum { Schier, Ball, Schläger, Badehose }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private bool _anstrengend;

        public bool Anstrengend
        {
            get { return _anstrengend; }
            set
            {
                _anstrengend = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Anstrengend)));
            }
        }

        private HilfsmittelEnum _hilfsmittel;
        public HilfsmittelEnum Hilfsmittel
        {
            get { return _hilfsmittel; }
            set
            {
                _hilfsmittel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hilfsmittel)));
            }
        }

        private string _imageUrl = "https://stillmed.olympic.org/media/Images/OlympicOrg/News/2016/08/20/2016-08-20-Handball-Women-thumbnail.jpg";
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageUrl)));
            }
        }

        private ObservableCollection<Spieler> _spieler = new ObservableCollection<Spieler>();

        public ObservableCollection<Spieler> Spieler
        {
            get { return _spieler; }
            set { _spieler = value; }
        }


        private static List<HilfsmittelEnum> _hilfsmittelEnum;

        public event PropertyChangedEventHandler PropertyChanged;

        static Sportart()
        {
            _hilfsmittelEnum = Enum.GetValues(typeof(HilfsmittelEnum)).Cast<HilfsmittelEnum>().ToList();
            #region Ohne Linq
            //List<HilfsmittelEnum> enums = new List<HilfsmittelEnum>();
            //foreach (var item in Enum.GetValues(typeof(HilfsmittelEnum)))
            //{
            //    enums.Add((HilfsmittelEnum)item);
            //}
            //return enums;
            #endregion
        }

        //Kurzschreibweise für eine Getter-Property (Expression Body Members)
        public List<HilfsmittelEnum> HilfsmittelEnumValues => _hilfsmittelEnum;


        public Sportart(string name, bool anstrengend, HilfsmittelEnum hilfsmittel, string imageUrl)
        {
            Name = name;
            Anstrengend = anstrengend;
            Hilfsmittel = hilfsmittel;
            ImageUrl = imageUrl;
        }

        public override string ToString()
        {
            return $"{Name}";
        }


        public Sportart()
        {

        }
    }

    public class Spieler
    {
        public string Name { get; set; }
    }
}
