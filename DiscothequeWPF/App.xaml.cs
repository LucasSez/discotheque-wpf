using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DiscothequeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // En XAML on avait l'attribut : StartupUri="MainWindow.xaml"
            // Equivalent C# :
            //
            // MainWindow win = new MainWindow();
            // win.Show();

            MainWindow win = new MainWindow();
            win.DataContext = new MainViewModel(); // Définit l'objet partagé avec XAML
            win.Show();
        }
    }
}
