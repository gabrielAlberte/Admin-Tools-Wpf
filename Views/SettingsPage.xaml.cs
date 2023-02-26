using Admin_Tools_Wpf.Utilities;
using Admin_Tools_Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace Admin_Tools_Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private Configuration _configFile; 
        private SettingsViewModel _contextSettings; 
        private HospiceGeneralViewModel _contextHospiceGeneral;
        public SettingsPage()
        {
            InitializeComponent();

            _configFile = new Configuration();           
            _contextSettings = new SettingsViewModel();
            _contextHospiceGeneral = new HospiceGeneralViewModel(_configFile);

            //Création du dossier racine et du fichier de configuration.json
            //_configFile.CreateBaseFolder();
            //_configFile.CreateFileConfiguration();

            //Ajoute les infos des chemins de dossier au TextBox
            TextBlockRootFolder.Text = _configFile.RootFolder;
            TextBlockConfigFile.Text = Path.Combine(_configFile.RootFolder, _configFile.ConfigFile);
            TextBlockHospiceGeneralPath.Text = _contextHospiceGeneral.PathFile;

        }

        //Crée le repertoire Racine "Repository" qui contient tous les dossiers des catégories de document  
        private void CreateRootFolder_Click(object sender, RoutedEventArgs e)
        {
            _configFile.CreateRootFolder();    
        }

        private void CreateFileConfig_Click(object sender, RoutedEventArgs e)
        {
            _configFile.CreateConfigFile();
            
        }
    }
}
