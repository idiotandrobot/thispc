using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ThisPC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel ViewModel = new MainViewModel();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0)
            {
                var main = new MainWindow();
                main.Show();
                return;
            }

            if (HasArgument(e, "/HideAll"))
            {
                HideAll();
            }
            else if (HasArgument(e, "/ShowAll"))
            {
                ShowAll();
            }
            Application.Current.Shutdown();
        }

        private static bool HasArgument(StartupEventArgs e, string argument)
        {
            return e.Args.Contains(argument, StringComparer.OrdinalIgnoreCase);
        }

        private static void ShowAll()
        {
            foreach (var folder in ViewModel.Folders)
            {
                folder.IsVisible = true;
            }
        }

        private static void HideAll()
        {
            foreach (var folder in ViewModel.Folders)
            {
                folder.IsVisible = false;
            }
        }
    }
}
