using System.IO;
using System.Windows;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Newtonsoft.Json;
using Supeng.Wpf.Common.Interfaces;
using SupengCommon;

namespace Supeng.Wpf.Common.ViewModels
{
    //todo: unit test
    [POCOViewModel]
    public abstract class DialogWindowViewModelBase : IProgress, IDialogWindow
    {
        private Window _window;

        public DialogWindowViewModelBase()
        {
            OkCommand = new DelegateCommand(Ok);
            CancelCommand = new DelegateCommand(Cancel);
            Size = new WindowSize { Height = 400, Width = 400 };
            Progress = new ProgressViewModel();
            Progress.Visibility = Visibility.Hidden;
        }

        [JsonIgnore]
        public DelegateCommand OkCommand { get; set; }

        [JsonIgnore]
        public DelegateCommand CancelCommand { get; set; }


        [JsonIgnore]
        public ProgressViewModel Progress { get; set; }

        [JsonIgnore]
        protected abstract string LayoutFileName { get; }

        public virtual string Title => string.Empty;

        public WindowSize Size { get; set; }

        [JsonIgnore]
        public abstract FrameworkElement Content { get; }


        string IWindow.Title { get; set; }

        [JsonIgnore]
        public ImageSource Icon { get; set; }

        public virtual void Load()
        {
            if (File.Exists(GetLayoutFileName()))
            {
                var vm = JsonConvert.DeserializeObject<WindowSize>(GetLayoutFileName().Load());
                Window.Width = vm.Width;
                Window.Height = vm.Height;
            }
            if (Content != null && Content.DataContext == null)
                Content.DataContext = this;
        }


        [JsonIgnore]
        public bool DialogResult { get; set; }

        public virtual void Ok()
        {
            if (!string.IsNullOrEmpty(Check()))
            {
                MessageBox.Show(Check());
                DialogResult = false;
                return;
            }
            DialogResult = true;
            Window.DialogResult = true;
        }

        public virtual void Cancel()
        {
            DialogResult = false;
            Window.DialogResult = false;
        }

        [JsonIgnore]
        public Window Window
        {
            get => _window;
            set
            {
                _window = value;
                _window.Closed += (sender, args) => { Close(); };
                _window.Loaded += (sender, args) => { Load(); };
            }
        }


        public virtual void ShowProgress()
        {
            Progress.ShowProgress();
        }

        public void HideProgress()
        {
            Progress.HideProgress();
        }

        public virtual void Close()
        {
            GetLayoutFileName().Save(JsonConvert.SerializeObject(new WindowSize { Height = Window.Height, Width = Window.Width }));
        }

        protected virtual string GetLayoutFileName()
        {
            return Path.Combine(DirectoryHelper.LayoutDirectory, LayoutFileName);
        }

        protected abstract string Check();
    }
}