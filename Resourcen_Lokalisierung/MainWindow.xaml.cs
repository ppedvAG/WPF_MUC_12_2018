using System;
using System.Collections.Generic;
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

namespace Resourcen_Lokalisierung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            if (this.Resources.Contains("windowFontSize") && this.Resources["windowFontSize"] is double fontSize)
            {
                //MessageBox.Show($"Aktuelle Schriftgröße: {fontSize}");
                this.Resources["windowFontSize"] = 50.0;
            }

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            this.Resources["windowFontSize"] = e.NewValue;
        }

        private void MenuItem_Sprache_Click(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is MenuItem item)
            {
                string path = $"Languages/{item.Tag.ToString()}";
                //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"pack://application:,,,/{path}");
                new MainWindow().Show();
                this.Close();
            }
        }

        private void MenuItem_Style_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem item)
            {
                string path = $"Styles/{item.Tag.ToString()}";
                //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri($"pack://siteOfOrigin:,,,/{path}");
                new MainWindow().Show();
                this.Close();
            }
        }
    }
}