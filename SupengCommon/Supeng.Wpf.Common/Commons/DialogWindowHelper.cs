using System.Windows;
using Supeng.Wpf.Common.Interfaces;

namespace Supeng.Wpf.Common.Commons
{
    public static class DialogWindowHelper
    {
        public static void ShowDialogWindow(this Window window, IDialogWindow dialogViewModel)
        {
            dialogViewModel.Window = window;
            window.DataContext = dialogViewModel;
            window.ShowDialog();
        }
    }
}