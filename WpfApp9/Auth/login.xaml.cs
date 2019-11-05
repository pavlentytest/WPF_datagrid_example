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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public MainWindow mw;     

        public login(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0) // проверяем введён ли логин  
            {
                if (textBox1.Text.Length > 0) // проверяем введён ли пароль         
                {
                    // using аналог конструкции try catch
                    // db - переменная (объект) класса UserEntities 
                    using (TestDBEntities1 db = new TestDBEntities1())
                    {
                        // переменная users - набор объектов
                        var users = db.users;
                        // проверяем совпадение логина и пароля 
                        // никакого SQL

                        var result = users.Where(i => i.login == textBox.Text && i.password == textBox1.Text);
                        // если есть записи
                        if (result.Count() > 0)
                        {
                            // в зависимости от роли - показываем необходимую страницу с datagrid
                            switch (result.FirstOrDefault().role)
                            {
                                case 1:
                                    mw.OpenPage(MainWindow.pages.admin);
                                    break;
                                case 2:
                                    mw.OpenPage(MainWindow.pages.manager);
                                    break;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя не существует", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                } else MessageBox.Show("Введите пароль");
            } else MessageBox.Show("Введите логин");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            mw.OpenPage(MainWindow.pages.registration);
        }
    }
}
