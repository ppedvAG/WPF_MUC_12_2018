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

namespace TierLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Krankheiten> krankheitenGlobal = new List<Krankheiten>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Speichern_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            int anzahlBeine = (int)sliderBeine.Value;
            bool ausgestorben = (bool)cbAusgestorben.IsChecked;


            #region Krankeiten ermitteln ohne Events
            List<Krankheiten> krankheiten = new List<Krankheiten>();

            foreach (var item in wpKrankheiten.Children)
            {
                if (item is CheckBox box)
                {
                    if (box.IsChecked == true)
                    {
                        krankheiten.Add((Krankheiten)box.Content);
                    }
                }
            }

            #endregion

            string krankheitenAlsString = $"Krankheiten: {string.Join(", ", krankheitenGlobal)}";

            MessageBox.Show($"{name} ({anzahlBeine} Beine), hat folgende Krankheiten: {krankheitenAlsString}");
        }

        private void Checkbox_Krankheiten_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is CheckBox box)
            {
                if (box.IsChecked == true)
                {
                    if (!krankheitenGlobal.Contains((Krankheiten)box.Content))
                    {
                        krankheitenGlobal.Add((Krankheiten)box.Content);
                    }
                }
                else
                {
                    krankheitenGlobal.Remove((Krankheiten)box.Content);
                }
                //Unterbricht das Event-Bubbling
                e.Handled = true;
            }
            
        }

        int clicks = 0;

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Blockiert die gesamte GUI
            //e.Handled = true;
            clicks++;
            this.Title = $"Clicks: {clicks}";
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;

        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public enum Krankheiten { Husten, Tollwut, Diabetis, Krebs, Karies }
}