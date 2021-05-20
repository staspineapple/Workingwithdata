using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingWithData
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection =  new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseTest"].ConnectionString);
        
    
        

        public Form2()
        {
            InitializeComponent();
        }

       

        
         


        private void button1_Click(object sender, EventArgs e)
        {

            

            sqlConnection.Open();

            
            //Добавление в Person
            SqlCommand command = new SqlCommand($"INSERT INTO [Person] (Name, Surname, Birthday, Number) VALUES (@Name, @Surname, @Birthday, @Number)", sqlConnection);

            DateTime date = DateTime.Parse(textBox3.Text);
            
            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Surname", textBox2.Text);
            command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Number", textBox4.Text);

            command.ExecuteNonQuery();
            //Нахождение айди последнего Person.
            command = new SqlCommand($"SELECT MAX(id) FROM Person", sqlConnection);
            int id = (int)command.ExecuteScalar();
            //Добавление в FrieendList.
            command = new SqlCommand($"INSERT INTO [FriendList] (IdPerson, IdKindOfFriend, IdGender) VALUES (@IdPerson, @IdKindOfFriend, @IdGender)", sqlConnection);
            command.Parameters.AddWithValue("IdPerson", id);
            //Проверка на то, какие радиокнопки нажаты.
            if (radioButton5.Checked)
            {
                command.Parameters.AddWithValue("IdGender", 1);
            }
            else
            {
                if (radioButton6.Checked)
                {
                    command.Parameters.AddWithValue("IdGender", 2);
                }
                else
                {
                    command.Parameters.AddWithValue("IdGender", null);
                }
            }
            

            if (radioButton1.Checked)
            {
                command.Parameters.AddWithValue("IdKindOfFriend", 1);
            }
            else
            {
                if (radioButton2.Checked)
                {
                    command.Parameters.AddWithValue("IdKindOfFriend", 2);
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        command.Parameters.AddWithValue("IdKindOfFriend", 3);
                    }
                    else
                    {
                        if (radioButton4.Checked)
                        {
                            command.Parameters.AddWithValue("IdKindOfFriend", 4);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("IdKindOfFriend", null);
                        }

                    }
                }
            }



            
            command.ExecuteNonQuery();
            sqlConnection.Close();
            Close();
        }


        

    }
}
