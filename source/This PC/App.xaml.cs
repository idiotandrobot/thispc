using Mono.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace ThisPC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool AttachConsole(int processId);

        public static MainViewModel ViewModel = new MainViewModel();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0)
            {
                var main = new MainWindow();
                main.Show();
                return;
            }

            AttachConsole(-1);

            bool showHelp = false;
            bool runShowAll = false;
            bool runHideAll = false;
            var p = new OptionSet() {
                { "showall", "Show all User folders in This PC",
                  v => runShowAll = true },
                { "hideall",  "Hide all User folders in This PC",
                  v => runHideAll = true },
                { "?|h|help",  "show this message and exit",
                  v => showHelp = v != null },
            };

            List<string> extra;
            try
            {
                extra = p.Parse(e.Args);
            }
            catch (OptionException ex)
            {
                Console.Write("thispc: ");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try `thispc --help' for more information.");
                Application.Current.Shutdown();
                return;
            }

            if (showHelp)
            {
                ShowHelp(p);
            }
            else if (runHideAll)
            {
                HideAll();
            }
            else if (runShowAll)
            {
                ShowAll();
            }

            Application.Current.Shutdown();
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Usage: thispc [OPTIONS]");
            Console.WriteLine("");
            Console.WriteLine("Alter the list of User folder links displayed in Windows Explorer This PC.");
            Console.WriteLine("Running with no options will launch the UI.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
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
