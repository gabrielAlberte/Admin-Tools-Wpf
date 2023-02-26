using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Printing;
using System.Windows;
using Admin_Tools_Wpf.Utilities;
using Microsoft.Win32;

namespace Admin_Tools_Wpf.ViewModel
{
    class HospiceGeneralViewModel : ViewModelBase
    {
        //private string _path = "C:\\Users\\gabri\\Desktop\\AdminToolsApp\\Admin-Tools-Wpf\\Persistence\\Repository\\";
        //private string _path = "C:\\Users\\gabri\\Documents\\Document-et-autre\\Dev\\C-Sharp\\AdminToolsApp\\Admin-Tools-Wpf\\Persistence\\Repository\\";
        //private string _path = AppDomain.CurrentDomain.BaseDirectory;
        private string _pathFile;
        public string PathFile
        { 
            get { return _pathFile; }
            set 
            { 
                _pathFile = value;
                OnPropertyChanged();
            }
        }
        
        private ObservableCollection<string> _fileNames;
        public ObservableCollection<string> FileNames
        {
            get { return _fileNames;}
            set
            { 
                _fileNames = value;
                OnPropertyChanged(nameof(_fileNames));
            }
        }

        private string _selectedFileName;
        public string SelectFileName        
        {
            get 
            { 
                return _selectedFileName;  
            }
            set 
            { 
                _selectedFileName = value;
            
            }
        }

        public HospiceGeneralViewModel(Configuration config)
        {
            _selectedFileName = null;

            _fileNames = new ObservableCollection<string>();
            config = new Configuration();
            //config.CreateSubFolder("HospiceGeneral");
            
            _pathFile = config.CreateSubFolder("HospiceGeneral");
               
            
            LoadFileNames();          
        }

        private void LoadFileNames()
        {
            try
            {
                if(Directory.Exists(_pathFile))
                {
                    string[] filePaths = Directory.GetFiles(this._pathFile);
                    foreach(string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        FileNames.Add(fileName);
                    }
                }
                else
                {
                    Configuration config = new Configuration();
                    config.CreateSubFolder(_pathFile);
                    MessageBox.Show($"Création d'un repertoir : {_pathFile}");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show($"Erreur d'ouverture du repertoire !!!\n {e}");
            }
        }

        public void RemoveSelectedFile(string path, string fileName)
        {         
            try
            {
                //if (string.IsNullOrEmpty(_selectedFileName))
                //MessageBox.Show("Selectionné un item...");
                
                string pathFile = Path.Combine(path, fileName);
                if (File.Exists(pathFile))
                {
                    //Delete file in the folder
                    File.Delete(pathFile);
                    //Delete the file in the ObservableCollection
                    FileNames.Remove(fileName);
                    MessageBox.Show($"File deleted : {fileName}");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show($"Error, echec de suppression du fichier : \n {e}");
            }
        }

        public void AddFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Add a File";
            openFileDialog.Filter = "All Files (*.*) | *.*";


            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string destinationFile = Path.Combine(_pathFile, Path.GetFileName(sourceFile));
                try
                {
                    File.Copy(sourceFile, destinationFile);
                    this.FileNames.Add(sourceFile);
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Erreur ! le fichier : {sourceFile} existe déjà dans le repertoir...");
                }             
            }
        }
    }
}