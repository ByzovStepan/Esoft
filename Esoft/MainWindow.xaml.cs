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
using MySql.Data.MySqlClient;
using Tutorial.SqlConn;
using System.Data.Common;


namespace Esoft
{
        /// <summary>
        /// Логика взаимодействия для MainWindow.xaml
        /// </summary>
    public partial class Authorization : Window
    {
        public int id = -1;

        public Authorization()
        {
            
            InitializeComponent();
            
        }

        private void ButtonAuthorization(object sender, RoutedEventArgs a)
        {
            //Подключение к таблице
            MySqlConnection db = DBUtils.GetDBConnection();
            try
            {
                db.Open();
                //Поиск по логину
                MySqlCommand cmd = new MySqlCommand("SELECT id, TypeUser FROM `users` WHERE Login = '" + Login.Text + "' AND Password = '" + Password.Password + "'");
                cmd.Connection = db;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("Введен не правильный логин или пароль!");
                    }
                    else
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
           
                        bool IsManager = reader.GetValue(1).ToString() == "Менеджер" ? true : false;

                        Coefficients gg = new Coefficients
                        {
                            id = id
                        };
                        gg.ForTest("Тест: " + reader.GetValue(0).ToString());
                        gg.Show();
                        this.Close();
                        

                    };
                };
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось подключиться к базе данных или серверу! Информация об ошибке: " + e);
            }

            //Закгрузка const реквезитов пользователя
            /*
                Тут заполняется публичная переменная класса user, куда вводятся данные, такие как гейдер(прим. junior, middle) и роль пользователя
            */

            //Закрыть форму авторизации
            //Открыть форму исходя из роли пользователя

         
        }
    }

}
