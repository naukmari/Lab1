using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.WPF;


namespace CharpZavertailo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            // I had trouble with fa:ImageAwesome, so decided to add refresh this way
            DataContext = new DateViewModel(ShowLoader);
        }

        private void ShowLoader(bool visible)
        {
            Loader.OnRequestLoader(Main, ref _loader, visible);
        }
    }


}
