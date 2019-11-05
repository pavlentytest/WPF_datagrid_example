using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Page
    {
        public TestDBEntities1 db;
        public MainWindow mw;

       
        public manager(MainWindow mainWindow)
        {
            InitializeComponent();
            db = new TestDBEntities1();
            mw = mainWindow;
            // загружаем содержимое таблицы goods в dataGrid
            db.goods.Load();
            // делаем binding (привязку) к источнику данных в dataGrid
            dataGrid.ItemsSource = db.goods.Local.ToBindingList();            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            mw.OpenPage(MainWindow.pages.login);
        }


        // Метод на кнопку - Добавить
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект (новую форму) на основе goodforms
            Manager.goodform addgood = new Manager.goodform();

            // Если на форме, нажали Ок, переходим к проверкам заполненности полей  
            var result = addgood.ShowDialog();         
            if (result == false)
                return;

            // проверка на заполнение поля: наименование
            if (addgood.textBox.Text.Length > 0)
            {
                // проверка на заполение поля: артикул
                if (addgood.textBox1.Text.Length > 0)
                {
                    // проверка на заполение поля: цена

                    if (addgood.textBox2.Text.Length > 0)
                    {
                        // создаем объект на основе модели good
                        good addnewgood = new good();
                        // выставляем свойства объекта - они же поля таблицы
                        addnewgood.name = addgood.textBox.Text;
                        addnewgood.article = addgood.textBox1.Text;
                        addnewgood.price = Decimal.Parse(addgood.textBox2.Text);
                        // добавляем структура
                        db.goods.Add(addnewgood);
                        // сохраняем в таблицу goods
                        db.SaveChanges();
                        MessageBox.Show("Новый товар успешно добавлен!");
                    }
                    else MessageBox.Show("Введите стоимость");
                }
                else MessageBox.Show("Введите артикул");
            }
            else MessageBox.Show("Введите наименование");
        }


        // Метод на кнопку - Изменить
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // создаем объект, по выбранной записи в dataGrid
                good selectedgood = (good)dataGrid.SelectedItem; 
                //  ищем этот объект, по его id
                good dbgood = db.goods.Find(selectedgood.id);
                // создаем новую форму
                Manager.goodform edgood = new Manager.goodform();
                // присваиваем значения найденной записи в поля формы
                edgood.textBox.Text = dbgood.name;
                edgood.textBox1.Text = dbgood.article;
                edgood.textBox2.Text = dbgood.price.ToString();
                // если нажали на ОК, то идем дальше
                var result = edgood.ShowDialog();
                if (result == false)
                    return;
                dbgood.name = edgood.textBox.Text;
                dbgood.article = edgood.textBox1.Text;
                dbgood.price = Decimal.Parse(edgood.textBox2.Text);
                // сохраняем структуру
                db.SaveChanges();
                // обновляем dataGrid, чтобы увидеть изменения
                dataGrid.Items.Refresh();
                MessageBox.Show("Информация по товару успешно изменена");
            }
            catch
            {
                MessageBox.Show("Для редактирования необходимо выбрать существующую запись");
            }
            
           
        }
        // Метод на кнопку - Удалить
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                good selectedgood = (good)dataGrid.SelectedItem;
                good dbgood = db.goods.Find(selectedgood.id);
                db.goods.Remove(dbgood);
                db.SaveChanges();
                dataGrid.Items.Refresh();
                MessageBox.Show("Информация по товару успешно изменена");
            }
            catch
            {
                MessageBox.Show("Для удаления необходимо выбрать существующую запись");
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }
    }
}
