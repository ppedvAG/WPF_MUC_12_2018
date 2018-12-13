using SportLibrary;
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

namespace UnsereUserControls
{
    /// <summary>
    /// Interaction logic for SportartPresenter.xaml
    /// </summary>
    public partial class SportartPresenter : UserControl
    {


        public Sportart CurrentSportart
        {
            get { return (Sportart)GetValue(CurrentSportartProperty); }
            set { SetValue(CurrentSportartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSportart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentSportartProperty =
            DependencyProperty.Register("CurrentSportart", typeof(Sportart), typeof(SportartPresenter), new PropertyMetadata(null,SportartChanged));

        private static void SportartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is SportartPresenter presenter)
            {
                presenter.DataContext = e.NewValue;
            }
        }

        public SportartPresenter()
        {
            InitializeComponent();
        }
    }
}
