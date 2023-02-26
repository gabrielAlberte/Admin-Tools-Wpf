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
using Admin_Tools_Wpf.Utilities;
using Admin_Tools_Wpf.ViewModel;
using Admin_Tools_Wpf.Views;

namespace Admin_Tools_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HospiceGeneralViewModel _context;
        private Configuration _config;

        public MainWindow()
        {
            InitializeComponent();
            NavigationContent.Content = new HospiceGeneralPage();
            //NavigationContent.Content = new HomePage();
            
            //NavigationContent.Content = new SettingsPage();

            //_config = new Configuration();
            //_context = new HospiceGeneralViewModel(_config);

        }
        
        private void SwitchTheme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary currentDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Source.OriginalString.Contains("DarkTheme.xaml"));
            if (currentDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentDictionary);
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Views/Themes/LightTheme.xaml", UriKind.Relative) });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Views/Themes/DarkTheme.xaml", UriKind.Relative) });
            }
        }       

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationContent.Content = new HomePage();
        }

        
        private void HospiceGeneral_Click(object sender, RoutedEventArgs e)
        {
            NavigationContent.Content = new HospiceGeneralPage();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationContent.Content = new SettingsPage();
        }
    }
}
