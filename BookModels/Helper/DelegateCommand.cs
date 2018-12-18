using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BookModels.Helper
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
       
        //http://openbook.rheinwerk-verlag.de/visual_csharp_2012/1997_05_001.html

        //Delegate-Variablen ohne Rückgabewert
        Action<object> _execMethod;
        //Delegate-Variablen mit Rückgabewert
        Func<object, bool> _canExecMethod;

       
        public DelegateCommand(Action<object> execMethod, Func<object, bool> canExecMethod = null)
        {
            _execMethod = execMethod;
            _canExecMethod = canExecMethod;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecMethod != null)
            {
                return _canExecMethod.Invoke(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _execMethod?.Invoke(parameter);
        }
    }
}
