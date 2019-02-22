using System.Windows.Controls;
using FontAwesome.WPF;

namespace CharpZavertailo1
{
    internal static class Loader
    {
        internal delegate void LoaderAction(Grid grid, ref ImageAwesome loaderIcon, bool visible);

        internal static void OnRequestLoader(Grid grid, ref ImageAwesome loaderIcon, bool visible)
        {
            if (visible)
            {
                loaderIcon = new ImageAwesome();
                grid.Children.Add(loaderIcon);
                loaderIcon.Icon = FontAwesomeIcon.Refresh;
                loaderIcon.Spin = true;
                Grid.SetRow(loaderIcon, 3);
            }
            else
            {
                grid.Children.Remove(loaderIcon);
            }
        }
    }
}
