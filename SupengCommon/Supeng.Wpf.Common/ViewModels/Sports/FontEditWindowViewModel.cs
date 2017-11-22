using System.Drawing;
using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using Supeng.Wpf.Common.Views.Sports;

namespace Supeng.Wpf.Common.ViewModels.Sports
{
    [POCOViewModel]
    public class FontEditWindowViewModel : DialogWindowViewModelBase
    {
        private readonly FontEditView _view;

        public FontEditWindowViewModel()
        {
            _view = new FontEditView();
        }

        protected override string LayoutFileName => "FontEditLayout.layout";

        public FontControlableViewModel Data { get; set; }

        public override FrameworkElement Content => _view;

        protected override string Check()
        {
            return string.Empty;
        }
    }
}