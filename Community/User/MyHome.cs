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

namespace Community
{
    public partial class MyHome : Form
    {
        static MySqlConnection conn = null;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public MyHome()
        {
            InitializeComponent();
        }

        private void 홈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home();
            home.ShowDialog();
            Close();
        }

        private void 게시판ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Board board = new Board();
            board.ShowDialog();
            Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            GetConnection();
            string sql = "update user set passwd='"+passwdtxt.Text+"',name='"+nametxt.Text+"',email='"+emailtxt.Text+"' where id='"+idtxt.Text+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("정보가 수정되었습니다.");
            this.Hide();
            MyHome myhome = new MyHome();
            myhome.ShowDialog();
            this.Close();
        }

        private void 시간표ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            TimeTable timetable = new TimeTable();
            timetable.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            string sql = "delete from user where id='" + idtxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("탈퇴가 완료되었습니다.");
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void MyHome_Load(object sender, EventArgs e)
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
    }
}
