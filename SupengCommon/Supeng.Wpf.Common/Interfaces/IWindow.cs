using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Supeng.Wpf.Common.Interfaces
{
    public interface IWindow
    {
        WindowSize Size { get; set; }

        string Title { get; set; }

        ImageSource Icon { get; set; }

        FrameworkElement Content { get; }

        void Load();
    }

    public class WindowSize
    {
        public double Height { get; set; }

        public double Width { get; set; }
    }

    public interface IDialogWindow : IWindow
    {
        Window Window { get; set; }

        bool DialogResult { get; set; }

        void Ok();

        void Cancel();
    }
}
