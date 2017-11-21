using System.Windows;
using DevExpress.Mvvm;
using Supeng.Wpf.Common.Interfaces;

namespace Supeng.Wpf.Common.ViewModels
{
    public class ProgressViewModel : ViewModelBase, IProgress
    {
        private string _message;
        private Visibility _visibility;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value, "Message");
        }

        public Visibility Visibility
        {
            get => _visibility;
            set => SetProperty(ref _visibility, value, "Visibility");
        }

        public void ShowProgress()
        {
            Visibility = Visibility.Visible;
        }

        public void HideProgress()
        {
            Visibility = Visibility.Hidden;
            Message = string.Empty;
        }

        public virtual void ShowProgress(string message)
        {
            Message = message;
            ShowProgress();
        }
    }
}