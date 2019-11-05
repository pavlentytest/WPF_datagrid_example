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

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }
        public enum pages
        {
            login,
            registration,
            admin,
            manager,
            user
        }
        public void OpenPage(pages p)
        {
            switch(p)
            {
                case pages.login:
                    frame.Navigate(new login(this));
                    break;
                case pages.admin:
                    frame.Navigate(new admin(this));
                    break;
                case pages.manager:
                    frame.Navigate(new manager(this));
                    break;
                case pages.registration:
                    frame.Navigate(new registration(this));
                    break;              
            }         
          
        }
    }
}
