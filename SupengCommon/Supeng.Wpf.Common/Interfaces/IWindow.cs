using System.Windows;
using System.Windows.Media;

namespace Supeng.Wpf.Common.Interfaces
{
    public interface IWindow
    {
        WindowLayout Size { get; set; }

        string Title { get; set; }

        ImageSource Icon { get; set; }

        FrameworkElement Content { get; }

        void Load();
    }

    public class WindowLayout
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Top { get; set; }

        public double Left { get; set; }
    }

    public interface IDialogWindow : IWindow
    {
        Window Window { get; set; }

        bool DialogResult { get; set; }

        void Ok();

        void Cancel();
    }
}