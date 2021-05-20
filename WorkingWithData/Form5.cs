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
    public partial class Form5 : Form
    {

        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseTest"].ConnectionString);
        int idfriend;

        private DateTime birthday;
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(int id)
        {
            sqlConnection.Open();
            InitializeComponent();
            SqlCommand IdFriendList = new SqlCommand($"SELECT Id FROM FriendList WHERE IdPerson ={id}", sqlConnection);
            idfriend = (int)IdFriendList.ExecuteScalar();

            SqlCommand command = new SqlCommand($"Select Name FROM Person where Id={id}", sqlConnection);
            textBox1.Text = (string)command.ExecuteScalar();
            command = new SqlCommand($"Select Surname FROM Person where Id={id}", sqlConnection);
            textBox2.Text = (string)command.ExecuteScalar();
            command = new SqlCommand($"Select Birthday FROM Person where Id={id}", sqlConnection);
            birthday = (DateTime)command.ExecuteScalar();
            textBox3.Text = $"{birthday.Day}.{birthday.Month}.{birthday.Year}";
            command = new SqlCommand($"Select Number FROM Person where Id={id}", sqlConnection);
            textBox4.Text = (string)command.ExecuteScalar();

            command = new SqlCommand($"Select IdGender FROM FriendList where Id={idfriend}", sqlConnection);
            if ((int)command.ExecuteScalar() == 1)
            {
                radioButton5.Checked = true;
            }
            else
            {
                if ((int)command.ExecuteScalar() == 2)
                {
                    radioButton6.Checked = true;
                }
                

            }

            command = new SqlCommand($"Select IdKindOfFriend FROM FriendList where Id={idfriend}", sqlConnection);
            if ((int)command.ExecuteScalar() == 1)
            {
                radioButton1.Checked = true;
            }
            else
            {
                if ((int)command.ExecuteScalar() == 2)
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    if ((int)command.ExecuteScalar() == 3)
                    {
                        radioButton3.Checked = true;
                    }
                    else
                    {
                        if((int)command.ExecuteScalar() == 4)
                        {
                            radioButton4.Checked = true;
                        }

                    }

                }


            }

            sqlConnection.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand IdPerson = new SqlCommand($"SELECT IdPerson FROM FriendList WHERE Id ={idfriend}", sqlConnection);
            DateTime date = DateTime.Parse(textBox3.Text);
            SqlCommand command = new SqlCommand($"UPDATE Person SET Name ='{textBox1.Text}', Surname = '{textBox2.Text}', Birthday = '{date.Month}/{date.Day}/{date.Year}', Number = '{textBox4.Text}' where id={(int)IdPerson.ExecuteScalar()} ", sqlConnection);
            command.ExecuteNonQuery();
            int idKindOfFriend = 0, idGender = 0;

            

            if (radioButton5.Checked)
            {
                idGender = 1;
            }
            else
            {
                if (radioButton6.Checked)
                {
                    idGender = 2;
                }
                
            }


            if (radioButton1.Checked)
            {
                idKindOfFriend = 1;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    idKindOfFriend = 2;
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        idKindOfFriend = 3;
                    }
                    else
                    {
                        if (radioButton4.Checked)
                        {
                            idKindOfFriend = 4;
                        }
                        

                    }
                }
            }

            command = new SqlCommand($"UPDATE FriendList SET IdKindOfFriend ='{idKindOfFriend}', IdGender = '{idGender}' where Id={idfriend}", sqlConnection);
            command.ExecuteNonQuery();

            sqlConnection.Close();
            Close();
        }
    }
}
