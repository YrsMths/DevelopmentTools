using DevelopmentTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevelopentTools
{
    class MainWindowExitCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (var tool in (parameter as MainWindowViewModel).tools)
            {
                tool.instance.ToolWindow.Close();
            }
        }
    }
}
