using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Newtonsoft.Json;
using Supeng.Wpf.Common.Commons;
using Supeng.Wpf.Common.ViewModels;
using Supeng.Wpf.Common.ViewModels.Sports;
using Supeng.Wpf.Common.Views;
using SupengCommon;

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
    public class MainWindowViewModle : ViewModelBase
    {
        public MainWindowViewModle()
        {
            Progress = new ProgressViewModel();
            Progress.Message = "Hello !!!!";
            FontVM = new FontControlableViewModel();
        }

        public FontControlableViewModel FontVM { get; set; }

        public ProgressViewModel Progress { get; set; }

        public void Show()
        {
            DialogWindowTest test = new DialogWindowTest();
            test.ShowDialogWindow(() =>
            {
                MessageBox.Show(test.Title);
            });
        }

        public void ShowData()
        {
            DataLayoutWindowTest test = new DataLayoutWindowTest { Data = new TestData() };
            test.ShowDialogWindow(() =>
            {
                MessageBox.Show(test.Data.Name);
            });
        }

        public void LoadFont()
        {
            FontVM.Load();
        }

        public void SetFont()
        {
            //var vm = new FontConfigDialogWindow();
            // if(FontVM == null)
            //      LoadFont();
            //  vm.Data = FontVM;
            //  vm.ShowDialogWindow(() =>
            //  {
            //      FontVM.Save();
            //  });
            var vm = new FontEditWindowViewModel();
            vm.Data = FontVM;
            vm.ShowDialogWindow(() =>
            {

                FontVM.Save();
            });
        }

        public void Hide()
        {
            Progress?.HideProgress();
        }
    }

    public class FontConfigDialogWindow : DataLayoutDialogWindowViewModel<FontControlableViewModel>
    {
        protected override string LayoutFileName => "Font.config";
        protected override string Check()
        {
            return string.Empty;
        }

        public override FontControlableViewModel Data { get; set; }
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

    public class DataLayoutWindowTest : DataLayoutDialogWindowViewModel<TestData>
    {
        protected override string LayoutFileName => "Datalayout.config";
        protected override string Check()
        {
            return string.Empty;
        }

        public override TestData Data { get; set; }
    }



    public class TestData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}