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

namespace DiscothequeWPF
{
    /// <summary>
    /// Logique d'interaction pour TrackControl.xaml
    /// </summary>
    public partial class TrackControl : UserControl
    {
        public TrackControl()
        {
            InitializeComponent();
        }

        public TrackControl(bool hideNewWinButton)
        {
            InitializeComponent();
            if (hideNewWinButton) OpenNewWin.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = new Window
            {
                Title = "DiscothèqueWPF",
                Content = new TrackControl(true),
                DataContext = App.Current.MainWindow.DataContext
            };
            win.Show();
        }
    }
}
