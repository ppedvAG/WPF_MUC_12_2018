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
using System.Windows.Media.Animation;
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

        public enum AnimationsTrigger { None, MouseEnter, Click }


        public AnimationsTrigger Trigger { get; set; } = AnimationsTrigger.Click;


        public Sportart CurrentSportart
        {
            get { return (Sportart)GetValue(CurrentSportartProperty); }
            set { SetValue(CurrentSportartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSportart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentSportartProperty =
            DependencyProperty.Register("CurrentSportart", typeof(Sportart), typeof(SportartPresenter), new PropertyMetadata(null, SportartChanged));

        private static void SportartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SportartPresenter presenter)
            {
                presenter.DataContext = e.NewValue;
            }
        }

        public SportartPresenter()
        {
            InitializeComponent();
        }

        private void Neuer_Spieler_Click(object sender, RoutedEventArgs e)
        {
            CurrentSportart.Spieler.Add(new Spieler());
        }

        private bool _isOpen = false;


        private void Start_Animation()
        {
            double from = _isOpen ? this.ActualWidth / 3 : 0.0;
            double to = _isOpen ? 0 : this.ActualWidth / 3;

            Storyboard expandBoard = new Storyboard();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            Storyboard.SetTargetName(animation, "column2");
            Storyboard.SetTargetProperty(animation, new PropertyPath("MaxWidth"));

            expandBoard.Children.Add(animation);

            DoubleAnimation animation2 = animation.Clone() as DoubleAnimation;
            Storyboard.SetTargetName(animation2, "column3");

            expandBoard.Children.Add(animation2);

            this.BeginStoryboard(expandBoard);

            _isOpen = !_isOpen;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if(Trigger == AnimationsTrigger.Click)
            {
                Start_Animation();
            }
        }

        private void Image1_MouseEnter(object sender, MouseEventArgs e)
        {
            if(Trigger == AnimationsTrigger.MouseEnter)
            {
                Start_Animation();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(Trigger == AnimationsTrigger.None)
            {
                column2.MaxWidth = this.ActualWidth / 3;
                column3.MaxWidth = this.ActualWidth / 3;
            }
        }
    }
}
