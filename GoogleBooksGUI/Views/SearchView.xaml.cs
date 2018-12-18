using BookModels.ViewModels;
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

namespace GoogleBooksGUI.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : Page
    {
        public SearchView(object model)
        {
            InitializeComponent();
            this.DataContext = model;
            if (DataContext is SearchViewModel viewmodel)
            {
                viewmodel.MessageShow += Model_MessageShow;
            }
        }

        private void Model_MessageShow(object sender, string e)
        {
            MessageBox.Show(e);
        }
    }
}
