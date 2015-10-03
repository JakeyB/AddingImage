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
using System.Data.Sql;

using  System.Data.SQLite;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace AddingImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Define connection to database
        string dbConnectionString = @"Data Source=database.db;Version=3;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            // Open connection to database
            try
            {
                sqliteCon.Open();

                string Query = "select * from employeeInfo where username='" + this.txt_username.Text + "' and password='" + this.txt_password.Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;

                while (dr.Read())
                {
                    count++;
                }

                // If Passwords match open new window *** Will need to close the old window ***
                if(count == 1){
                    // Close connection to database
                    sqliteCon.Close();

                    // Create new window bject, open the window and close old window
                    Main sec = new Main();
                    sec.Show();
                    Close();
                } 
                if (count < 1)
                {
                    MessageBox.Show("Username or password incorrect!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Image1_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = (Image) sender;
            DoubleAnimation animation = new DoubleAnimation(0,TimeSpan.FromSeconds(2));
            img.BeginAnimation(Image.OpacityProperty, animation);
        }

        private void Image1_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(2));
            img.BeginAnimation(Image.OpacityProperty, animation);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

            // Create an object of the new WPF window
            SignUp signUp = new SignUp();
            signUp.Show();
            Close();
        }
    }
}
