using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Community.admin
{
    public partial class AdminMyHome : Form
    {
        static MySqlConnection conn = null;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public AdminMyHome()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            Close();
        }

        private void AdminMyHome_Load(object sender, EventArgs e)
        {
            idtxt.Text = Login.id;
            GetConnection();
            MySqlCommand passwd = new MySqlCommand("select passwd  from User where id='" + idtxt.Text + "'", conn);
            MySqlCommand name = new MySqlCommand("select name  from User where id='" + idtxt.Text + "'", conn);
            MySqlCommand email = new MySqlCommand("select email  from User where id='" + idtxt.Text + "'", conn);
            conn.Open();
            string Passwd = Convert.ToString(passwd.ExecuteScalar());
            string Name = Convert.ToString(name.ExecuteScalar());
            string Email = Convert.ToString(email.ExecuteScalar());
            passwdtxt.Text = Passwd;
            nametxt.Text = Name;
            emailtxt.Text = Email;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AdminHome home = new AdminHome();
            home.ShowDialog();
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GetConnection();
            string sql = "update user set passwd='" + passwdtxt.Text + "',name='" + nametxt.Text + "',email='" + emailtxt.Text + "' where id='" + idtxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("정보가 수정되었습니다.");
            Hide();
            AdminMyHome myhome = new AdminMyHome();
            myhome.ShowDialog();
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            Close();
        }
    }
}
