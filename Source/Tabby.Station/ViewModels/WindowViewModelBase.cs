using System;
using System.Windows.Input;


namespace Tabby.Station.ViewModels
{
    public abstract class WindowViewModelBase : ViewModelBase
    {
        private Command<WindowViewModelBase> _closeCommand;

        /// <summary>
        /// Raised when this workspace should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        /// <summary>
        /// Returns the command that, when invoked, attempts
        /// to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new Command<WindowViewModelBase>(param => RaiseRequestClose());
                }

                return _closeCommand;
            }
        }


        protected void RaiseRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
