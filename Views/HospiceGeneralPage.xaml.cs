using Admin_Tools_Wpf.ViewModel;
using Microsoft.Win32;
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
//using System.Windows.Shapes;
using System.IO;
using Admin_Tools_Wpf.Utilities;

namespace Admin_Tools_Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour HospiceGeneralPage.xaml
    /// </summary>
    public partial class HospiceGeneralPage : Page
    {
        private HospiceGeneralViewModel _context;
        private Configuration _config;

        public HospiceGeneralPage()
        {
            InitializeComponent();
            
            _config = new Configuration();
            _context = new HospiceGeneralViewModel(_config);

            //DataContext = new HospiceGeneralViewModel();       

            ListNameFiles.Items.Clear();
            ListNameFiles.ItemsSource = _context.FileNames;

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string selectFileName = (string)ListNameFiles.SelectedItem;
            _context.RemoveSelectedFile(_context.PathFile, selectFileName);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _context.AddFile();        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Clear();
        }

        private void DoubleClick_Click(object sender, RoutedEventArgs e)
        {
            
            string selectItem = (string)ListNameFiles.SelectedItem;
            if(!string.IsNullOrEmpty(selectItem))
            {
                /*
                //crée un nouvel onglet
                TabItem newTab = new TabItem();

                //Création d'un bouton de fermeture
                Button closeButton = new Button();
                closeButton.Content = "Super button";


                //définir le text de l'en-tete de l'onglet
                newTab.Header = selectItem;

                //crée un nouveau conteneur pour le contenu de l'onglet
                Grid newTabContent = new Grid();
                newTab.Content = newTabContent;               

                

                //Ajouter du text au contenu de l'onglet
                TextBlock textBlock = new TextBlock();                              
                textBlock.Text = $"Voici le contenu de : {selectItem}";

                newTabContent.Children.Add(textBlock);
                              
                //Ajoute le nouvel onglet au TabControl
                MainTabControl.Items.Add(newTab);

                //Sélectionner le nouvel onglet
                MainTabControl.SelectedItem = newTab;
                */

                TabItem newTab = new TabItem();
                newTab.Header = selectItem;
                //Grid newTabContent = new Grid();
                newTab.HeaderTemplate = CreateTabHeaderTemplate();
                
                MainTabControl.Items.Add(newTab);
            }
        }
        
        private DataTemplate CreateTabHeaderTemplate()
        {
            DataTemplate template = new DataTemplate();

            return template;
        }

        private void CloseTabButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Je vais partir");
        }
    }
}
