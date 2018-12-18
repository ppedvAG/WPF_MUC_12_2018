using System;
using System.Collections.Generic;
using System.Text;

namespace BookModels.Helper
{
    public enum NavigationTargets { Search, Results, Favorites    } 

    public interface INavigationService
    {
        void Navigate(NavigationTargets target ,object viewmodel);
    }
}
