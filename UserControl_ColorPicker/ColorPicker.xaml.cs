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

namespace UserControl_ColorPicker
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {

        //Dependency Properties: propdp


        public Brush CurrentColor
        {
            get { return (Brush)GetValue(CurrentColorProperty); }
            set { SetValue(CurrentColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentColorProperty =
            DependencyProperty.Register(nameof(CurrentColor), typeof(Brush), typeof(ColorPicker), new PropertyMetadata(Brushes.White,CurrentColorChanged));

        private static void CurrentColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is ColorPicker colorpicker)
            {
                if(e.NewValue is SolidColorBrush brush )
                {
                    colorpicker.sliderRed.Value =  brush.Color.R;
                    colorpicker.sliderGreen.Value =  brush.Color.G;
                    colorpicker.sliderBlue.Value =  brush.Color.B;
                    colorpicker.sliderOpacity.Value = brush.Opacity;
                }
            }
        }



        public bool ShowOpacity
        {
            get { return (bool)GetValue(ShowOpacityProperty); }
            set { SetValue(ShowOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowOpactiy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowOpacityProperty =
            DependencyProperty.Register(nameof(ShowOpacity), typeof(bool), typeof(ColorPicker), new PropertyMetadata(true));



        public ColorPicker()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void StackPanel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color c = Color.FromRgb( 
                                    (byte)sliderRed.Value, 
                                    (byte)sliderGreen.Value, 
                                    (byte)sliderBlue.Value);
            SolidColorBrush neueFarbe = new SolidColorBrush(c);
            neueFarbe.Opacity = sliderOpacity.Value;

            CurrentColor = neueFarbe;
        }
    }
}
