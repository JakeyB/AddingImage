using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
namespace AddingImage
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Define db connection
        private string dbConnectionString = @"Data Source=database.db;Version=3;";

        public Window1()
        {
            InitializeComponent();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            //Create new db connection
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {
                // Open connection to database
                sqliteCon.Open();

                string Query = "insert into employeeInfo (id,name,surname,age) values('" + this.ID_text.Text + "','" +
                               this.Name_text.Text + "','" + this.Surname_text.Text + "','" + this.Age_text.Text + "')";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Saved!");
                /*SQLiteDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    
                }
                */

                // Close connection to database
                sqliteCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {
                // Open connection to database
                sqliteCon.Open();

                string Query = "update employeeInfo set id='" + this.ID_text.Text + "', name='" + this.Name_text.Text +
                               "', surname= '" + this.Surname_text.Text + "', age= '" + this.Age_text.Text +
                               "' where id='" + this.ID_text.Text + "'  ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Updated");
                
                //Close connection
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {
                // Open connection to database
                sqliteCon.Open();

                string Query = "delete from employeeInfo where id='" +this.ID_text.Text+"'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Deleted");
                
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
