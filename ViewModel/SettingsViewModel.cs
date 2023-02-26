using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_Tools_Wpf.Utilities;

namespace Admin_Tools_Wpf.ViewModel
{
    internal class SettingsViewModel : ViewModelBase
    {
        //public  string PATHFILECONFIG = "C:\\Users\\gabri\\Documents\\Document-et-autre\\Dev\\C-Sharp\\AdminToolsApp\\Admin-Tools-Wpf\\Persistence\\config.json";
        private string _pathFolder;

        public string PathFolder
        {
            get 
            {                    
                return _pathFolder; 
            }
            set { _pathFolder = value; }
        }

        public SettingsViewModel() 
        {
            
        }

        //public void CreateBaseFolder()
        //{
        //    if(!Directory.Exists(_pathFolder))
        //    {
        //        Directory.CreateDirectory("Repository");
        //    }

            
        //}

        

        //public string ChangePath(string path)
        //{
        //    return path;
        //}
      
    }
}
