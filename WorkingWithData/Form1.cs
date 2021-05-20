using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace WorkingWithData
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseTest"].ConnectionString);
        private DataSet data = null;
        private SqlDataAdapter adapter = null;

        public Form1()
        {
            InitializeComponent();
        }

        




        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addform = new Form2();
            addform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT FriendList.Id, Person.Name, Person.Surname, Person.Birthday, Person.Number, Gender.Gender, Kind.KindOfFriend FROM FriendList inner join Person on Person.Id = FriendList.IdPerson inner join Gender on Gender.Id = FriendList.IdGender inner join Kind on Kind.Id = FriendList.IdKindOfFriend", sqlConnection);

            data = new DataSet();
            adapter.Fill(data);


            dataGridView1.DataSource= data.Tables[0];
            sqlConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            sqlConnection.Open();
            if(textBox1.Text!="")
            adapter = new SqlDataAdapter($"{textBox1.Text}", sqlConnection);
            else
                adapter = new SqlDataAdapter($"SELECT FriendList.Id, Person.Name, Person.Surname, Person.Birthday, Person.Number, Gender.Gender, Kind.KindOfFriend FROM FriendList inner join Person on Person.Id = FriendList.IdPerson inner join Gender on Gender.Id = FriendList.IdGender inner join Kind on Kind.Id = FriendList.IdKindOfFriend", sqlConnection);

            data = new DataSet();
            adapter.Fill(data);


            dataGridView1.DataSource = data.Tables[0];
            




            sqlConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 change = new Form4();
            change.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 deleteform = new Form3();
            deleteform.Show();
        }
    }
}
