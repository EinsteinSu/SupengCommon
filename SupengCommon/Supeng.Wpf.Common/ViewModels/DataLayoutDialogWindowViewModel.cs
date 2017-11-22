using System.Windows;
using Supeng.Wpf.Common.Views;

namespace Supeng.Wpf.Common.ViewModels
{
    public abstract class DataLayoutDialogWindowViewModel<T> : DialogWindowViewModelBase where T : new()
    {
        private DataLayoutView _view;
        public DataLayoutDialogWindowViewModel()
        {
            _view = new DataLayoutView();
            Data = new T();
        }

        public abstract T Data { get; set; }

        public override FrameworkElement Content => _view;
    }
}