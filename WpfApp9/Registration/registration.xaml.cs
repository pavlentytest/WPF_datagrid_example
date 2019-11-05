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
    /// Interaction logic for registration.xaml
    /// </summary>
    public partial class registration : Page
    {
        public MainWindow mw;

        public registration(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        // возвращаемся в главное окно, если нажали на кнопку Закрыть
        private void Button1_Click(object sender, RoutedEventArgs e)
        {  
            mw.OpenPage(MainWindow.pages.login);
        }

        // регистрируем пользователя, если нажали на кнопку 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  проверка на заполнение поля: логин
            if (textBox.Text.Length > 0) 
            {
                // проверка на заполнение поля: пароль
                if (textBox1.Text.Length > 0)      
                {
                    // пароли должны быть одинаковые
                    if (textBox1.Text == textBox2.Text)
                    {
                        using (TestDBEntities1 db = new TestDBEntities1())
                        {
                            // создаем объект из нашей модели БД
                            var users = db.users;     
                            // создаем объект на основе нашей таблицы
                            user reguser = new user();
                            // перечисляем значения всех свойств и присваиваем им значения из соот-их полей textBox
                            reguser.login = textBox.Text;
                            reguser.password = textBox1.Text;
                            reguser.role = 3;
                            // добавляем в модель users новую структуру
                            users.Add(reguser);
                            // фиксируем изменения т.е. добавляем запись в таблицу users
                            db.SaveChanges();
                            // если вернулся id, то запись успешно добавилась
                            if(reguser.id > 0)
                            {
                                MessageBox.Show("Вы успешно зарегистрировались!");
                                mw.OpenPage(MainWindow.pages.login);
                            }
                        }
                    }
                    else MessageBox.Show("Пароли отличаются");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }
    }
}
