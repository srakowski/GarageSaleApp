using System;
using System.Windows.Input;

namespace GarageSaleApp.UwpApp.Commands
{
    public interface IAcceptsDigits
    {
        void PushDigit(string digit);
    }

    public class EnterDigitCommand : ICommand
    {
        private IAcceptsDigits _acceptsDigits;

        public EnterDigitCommand(IAcceptsDigits acceptsDigits)
        {
            _acceptsDigits = acceptsDigits;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _acceptsDigits.PushDigit(parameter?.ToString());
        }
    }
}
