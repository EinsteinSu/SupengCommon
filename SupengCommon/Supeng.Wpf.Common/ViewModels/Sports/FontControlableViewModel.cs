using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Newtonsoft.Json;
using Supeng.Wpf.Common.Commons;
using SupengCommon;

namespace Supeng.Wpf.Common.ViewModels.Sports
{
    [POCOViewModel]
    public class FontControlableViewModel
    {
        private string _fileName;
        public FontControlableViewModel()
        {
            Name = "Test";
            Text = "Hello";
            _fileName = Path.Combine(DirectoryHelper.LayoutDirectory, $"{Name}.layout");
            SettingsVisibility = Visibility.Hidden;
            ShowOrHideCommand = new DelegateCommand(ShowOrHide);
            SetCommand = new DelegateCommand(() =>
            {
                var vm = new FontEditWindowViewModel
                {
                    Data = JsonConvert.DeserializeObject<FontControlableViewModel>(ToString())
                };
                vm.ShowDialogWindow(() =>
                {
                    FontFamily = vm.Data.FontFamily;
                    Foreground = vm.Data.Foreground;
                    FontSize = vm.Data.FontSize;
                    Save();
                });
            });
        }

        public string Name { get; set; }

        public string Text { get; set; }

        public string FontFamily { get; set; }

        public string Foreground { get; set; }

        public double FontSize { get; set; }

        [JsonIgnore]
        public Visibility SettingsVisibility { get; set; }

        [JsonIgnore]
        public DelegateCommand ShowOrHideCommand { get; set; }

        [JsonIgnore]
        public DelegateCommand SetCommand { get; set; }

        public void ShowOrHide()
        {
            SettingsVisibility = SettingsVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);

        }

        public void Load()
        {
            if (File.Exists(_fileName))
            {
                var vm = JsonConvert.DeserializeObject<FontControlableViewModel>(_fileName.Load());
                FontFamily = vm.FontFamily;
                FontSize = vm.FontSize;
                Foreground = vm.Foreground;
                Text = vm.Text;
            }
        }

        public void Save()
        {
            _fileName = Path.Combine(DirectoryHelper.LayoutDirectory, $"{Name}.layout");
            _fileName.Save(ToString());
        }
    }
}
