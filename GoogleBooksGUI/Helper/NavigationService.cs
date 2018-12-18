using BookModels.Helper;
using BookModels.ViewModels;
using GoogleBooksGUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoogleBooksGUI.Helper
{
    public class NavigationService : INavigationService
    {

        public static Frame _frame;

        public void Navigate(NavigationTargets target, object viewmodel)
        {
            switch (target)
            {
                case NavigationTargets.Search:
                    SearchView view = new SearchView(viewmodel as SearchViewModel);
                    _frame.Navigate(view);
                    break;
                case NavigationTargets.Results:
                case NavigationTargets.Favorites:
                    ResultView resultView = new ResultView();
                    resultView.DataContext = viewmodel;
                    _frame.Navigate(resultView);
                    break;
                default:
                    break;
            }
        }
    }
}
