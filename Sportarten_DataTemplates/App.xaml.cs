using SportLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sportarten_DataTemplates
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if(button.Tag is Sportart art)
                {
                    art.Spieler.Add(new Spieler());
                }
            }
        }
    }
}
