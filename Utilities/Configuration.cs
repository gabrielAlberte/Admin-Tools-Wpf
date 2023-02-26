using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace Admin_Tools_Wpf.Utilities
{
    internal class Configuration
    {
        private string _rootFolder;

        public string RootFolder
        {
            get { return _rootFolder; }
            set { _rootFolder = value; }
        }

        private readonly string _configFile;

        public string ConfigFile
        {
            get { return _configFile; }
            //set { _configFile = value; }
        }

        private string _pathConfigFile;

        public string  PathConfigFile
        {
            get { return _pathConfigFile;; }
            set { _pathConfigFile = value; }
        }

        public Configuration() 
        {
            this._rootFolder = AppDomain.CurrentDomain.BaseDirectory + "Repository";
            this._configFile = "config.json";
            
            this._pathConfigFile = Path.Combine(this._rootFolder, this._configFile);
                       
            //Création du fichier config.json
            CreateConfigFile();
            //Ajout de la structure du fichier json dans "config.json"
            AddStructurOfJsonFile();
            //Création du repertoire principale "Repository"
            CreateFoldersFromJson();
        }

        public void CreateConfigFile()
        {
            try
            {
                string pathFile = _configFile;
                if(!File.Exists(pathFile))
                {
                    using (File.Create(pathFile))
                    {
                        MessageBox.Show("Fichier de configuration crée avec succès!");
                    }
                    
                }
                else
                {
                    //MessageBox.Show("Le fichier de configuration existe déjà!");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Impossible de créer le fichier de configuration. Erreur : {e.Message}");
            }

        }

        public void CreateRootFolder()
        {
            try
            {
                if (!Directory.Exists(this._rootFolder))
                {
                    Directory.CreateDirectory(_rootFolder);
                    MessageBox.Show($"Dossier racine créé avec succès \nPath: {this._rootFolder}");
                }
                else
                {
                    MessageBox.Show("Le dossier racine existe déjà!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Impossible de créer le dossier racine. Erreur : {e}");
            }
        }

        public void CreateFoldersFromJson()
        {
            string jsonString = File.ReadAllText(this._configFile);
            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

            var folders = jsonDocument.RootElement.GetProperty("Repository").EnumerateObject();
            foreach ( var folder in folders) 
            {
                string folderName = folder.Name;
                string folderPath = folder.Value.GetString();
                string fullPath = Path.Combine(_rootFolder, folderName);
                
                if(!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    //MessageBox.Show($"Dossier {folderName} crée à {fullPath}");
                }
                else
                {
                    //MessageBox.Show($"Le dossier {folderName} existe déjà à {fullPath}");
                }
            }
        }
 
        public string CreateSubFolder(string name)
        {
            try
            {
                string folderPath = Path.Combine(_rootFolder, name);
                
                if(!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    MessageBox.Show($"Dossier crée avec succès! \nPath : {folderPath}");
                }
                return folderPath;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Impossiblee de créer le dossier. Erreur : {e}");
                return null;
            }
        }
        
        public void AddStructurOfJsonFile()
        {
            string pathFile = this._configFile;
            var json = new JsonObject
            {
                ["Repository"] = new JsonObject
                {
                    //["Repository"] = _rootFolder,
                    ["HospiceGeneral"] = Path.Combine(_rootFolder, "HospiceGeneral")
                }
            };
            File.WriteAllText(pathFile, json.ToString());
            //MessageBox.Show("Ajout de la structure du fichier json");
        }
        

        //public void GetRootFolderName()
        //{
        //    //string jsonString = File.ReadAllText(this._pathConfigFile);
        //    //JsonDocument jsonDoc = JsonDocument.Parse(jsonString);

        //    //string mainFolderName = jsonDoc.RootElement.GetProperty("folder").GetProperty("Repository").ToString();
        //    string jsonString = File.ReadAllText(PathConfigFile);
        //    JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
        //    string mainFolderName = jsonDoc.RootElement.GetProperty("folder").GetProperty("Repository").GetString();


        //    MessageBox.Show($"{mainFolderName}\n Mehtode GetRootFolderName est déclanché");
        //}
    }
}
