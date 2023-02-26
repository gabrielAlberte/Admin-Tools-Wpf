using Admin_Tools_Wpf.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Admin_Tools_Wpf.Views 
{
    public partial class HomePage : Page
    {
        HomePageViewModel _contextHomePage = new HomePageViewModel();
        public HomePage()
        {
            InitializeComponent();
            
            //System.IO.Path.Combine(Environment.CurrentDirectory);
            //MessageBox.Show(System.IO.Path.Combine(Environment.CurrentDirectory));
        }
    } 
}