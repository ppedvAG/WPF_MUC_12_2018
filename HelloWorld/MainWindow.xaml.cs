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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();

        //EventHandler-Methode für das Click-Event eines Buttons
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Button neuerButton = new Button();
            neuerButton.Content = "Start";
            neuerButton.HorizontalAlignment = (HorizontalAlignment)random.Next(0, 4);
            neuerButton.VerticalAlignment = (VerticalAlignment)random.Next(0, 4);
            neuerButton.Padding = new Thickness(10);
            neuerButton.Click += NeuerButton_Click;
            mainGrid.Children.Add(neuerButton);

            ThicknessConverter converter = new ThicknessConverter();
            Thickness t = (Thickness)converter.ConvertFrom("10 10 5 0");
        }

        private void NeuerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
        }
    }
}
