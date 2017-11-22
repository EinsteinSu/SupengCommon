using System;
using System.Windows;
using Supeng.Wpf.Common.Interfaces;
using Supeng.Wpf.Common.Views;

namespace Supeng.Wpf.Common.Commons
{
    public static class DialogWindowHelper
    {
        public static void ShowDialogWindow(this IDialogWindow dialogViewModel, Window window = null)
        {
            dialogViewModel.Window = window ?? new DialogWindow();
            dialogViewModel.Window.DataContext = dialogViewModel;
            dialogViewModel.Window.ShowDialog();
        }

        public static bool? ShowDialogWindowWithReturns(this IDialogWindow dialogViewModel, Window window = null)
        {
            dialogViewModel.Window = window ?? new DialogWindow();
            dialogViewModel.Window.DataContext = dialogViewModel;
            return dialogViewModel.Window.ShowDialog();
        }

        public static void ShowDialogWindow(this IDialogWindow dialogViewModel, Action action, Window window = null)
        {
            dialogViewModel.Window = window ?? new DialogWindow();
            dialogViewModel.Window.DataContext = dialogViewModel;
            var showDialog = dialogViewModel.Window.ShowDialog();
            if (showDialog != null && showDialog.Value)
            {
                action?.Invoke();
            }
        }
    }
}