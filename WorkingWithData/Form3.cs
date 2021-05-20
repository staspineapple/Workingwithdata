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
    public partial class Form3 : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlCommand command1 = null;
        private SqlCommand command3 = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseTest"].ConnectionString);

            sqlConnection.Open();
            command = new SqlCommand($"SELECT IdPerson from FriendList where id = {textBox1.Text}", sqlConnection);
            int idPerson = (int)command.ExecuteScalar();
            command = new SqlCommand($"Delete from FriendList where id = {textBox1.Text}", sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand($"Delete from Person where id = {idPerson}", sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            Close();
        }
    }
}
