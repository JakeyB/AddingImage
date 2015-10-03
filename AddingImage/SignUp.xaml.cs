using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace AddingImage
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        //Define db connection
        private string dbConnectionString = @"Data Source=database.db;Version=3;";

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_btn_Click(object sender, RoutedEventArgs e)
        {
            //Create new db connection
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {
                // Open connection to database
                sqliteCon.Open();
                
                //Read all usernames from table
                string query = "select * from employeeInfo where username='" + this.Username_text.Text +"' ";
                SQLiteCommand createCommand = new SQLiteCommand(query, sqliteCon);
                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();

                int count = 0;
                //Check if username already exsts
                while (dr.Read())
                {
                    count++;
                }

                if (count == 0)
                {
                    //
                    string insertQuery = "insert into employeeInfo (name,surname,age,username,password) values('" +
                                   this.Name_text.Text + "','" + this.Surname_text.Text + "','" + this.Age_text.Text +
                                   "','" + this.Username_text.Text +
                                   "','" + this.Password_text.Text +
                                   "')";
                    SQLiteCommand createInsertCommand = new SQLiteCommand(insertQuery, sqliteCon);
                    createInsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Saved!");

                    // Close connection to database
                    sqliteCon.Close();
                }
                else
                {
                    MessageBox.Show("Username already exists, Try Again");
                }

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Username_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
