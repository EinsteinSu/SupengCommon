using System.IO;
using DevExpress.Mvvm.DataAnnotations;
using Newtonsoft.Json;
using Supeng.Common;

namespace Supeng.Wpf.Common.ViewModels.Sports
{
    public class FontControlableViewModel
    {
        private string _fileName;

        public FontControlableViewModel()
        {
            Name = "Test";
            _fileName = Path.Combine(DirectoryHelper.LayoutDirectory, $"{Name}.layout");
        }

        public string Name { get; set; }

        public string Text { get; set; }

        public string FontFamily { get; set; }

        public string Foreground { get; set; }

        public double FontSize { get; set; }

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
                Name = vm.Name;
            }
        }

        public void Save()
        {
            _fileName = Path.Combine(DirectoryHelper.LayoutDirectory, $"{Name}.layout");
            _fileName.Save(ToString());
        }
    }
}