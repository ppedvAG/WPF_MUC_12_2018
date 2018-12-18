using SportLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sportarten_DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Sportart> _sportarten = new ObservableCollection<Sportart>()
        {
            new Sportart("Tischtennis", true, Sportart.HilfsmittelEnum.Schläger, "https://stillmed.olympic.org/media/Images/OlympicOrg/News/2016/08/20/2016-08-20-Handball-Women-thumbnail.jpg"),
            new Sportart("Schwimmen", true, Sportart.HilfsmittelEnum.Badehose, "https://i.eurosport.com/2018/11/06/2456059-51019895-2560-1440.jpg")
        };

        public MainWindow()
        {
            InitializeComponent();
            _sportarten[0].Spieler.Add(new Spieler() { Name="Alex" });
            _sportarten[0].Spieler.Add(new Spieler() { Name="Maria" });
            _sportarten[1].Spieler.Add(new Spieler() { Name="Torsten" });
            this.DataContext = _sportarten;
            
        }
       

        private void Button_Neu_Click(object sender, RoutedEventArgs e)
        {
            _sportarten.Add(new Sportart());
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _sportarten)
            {
                item.Anstrengend = true;
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            _sportarten.Clear();
        }
    }
}
