using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WorkingWithData
{


    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseTest"].ConnectionString);
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand($"SELECT IdPerson FROM FriendList WHERE Id ={textBox1.Text}", sqlConnection);
            int id = (int)command.ExecuteScalar();
            Form5 change = new Form5(id);
            change.Show();

            
            sqlConnection.Close();
            Close();
        }
    }
}
