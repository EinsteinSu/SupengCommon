using System.Windows;
using DevExpress.Mvvm.DataAnnotations;
using Supeng.Wpf.Common.Commons;
using Supeng.Wpf.Common.ViewModels;
using Supeng.Wpf.Common.Views;

namespace Supeng.Wpf.Common.Test
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    [POCOViewModel]
    public class MainWindowViewModle
    {
        public MainWindowViewModle()
        {
            Progress = new ProgressViewModel();
            Progress.Message = "Hello !!!!";
        }

        public ProgressViewModel Progress { get; set; }

        public void Show()
        {
            new DialogWindow().ShowDialogWindow(new DialogWindowTest());
        }

        public void Hide()
        {
            Progress?.HideProgress();
        }
    }

    public class DialogWindowTest : DialogWindowViewModelBase
    {
        public override string Title => "Wow";
        protected override string LayoutFileName => "balabal.config";
        public override FrameworkElement Content => new TestContent();

        protected override string Check()
        {
            return string.Empty;
        }
    }
}