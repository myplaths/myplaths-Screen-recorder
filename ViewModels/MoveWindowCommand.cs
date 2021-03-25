using System;
using System.Windows.Input;

namespace MyPlathsRecordingSoftware.ViewModels
{
    public class MoveWindowCommand :ICommand
    {
        private Action<object, MouseButtonEventArgs> moveWindow;

        public MoveWindowCommand(Action<object, MouseButtonEventArgs> moveWindow)
        {
            this.moveWindow = moveWindow;
           
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter, MouseButtonEventArgs e)
        {
            Console.WriteLine("execute double");
            moveWindow.Invoke(parameter, e);
        }



        public void Execute(object parameter)
        {
            Console.WriteLine("exevute single");
        }
    }

   
}