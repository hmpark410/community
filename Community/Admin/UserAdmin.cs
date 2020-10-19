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
    public partial class UserAdmin : Form
    {
        static MySqlConnection conn = null;
        MySqlDataAdapter adpt;
        DataTable dt;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public UserAdmin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            AdminHome home = new AdminHome();
            home.ShowDialog();
            Close();
        }

        private void UserAdmin_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            adpt = new MySqlDataAdapter("select * from user", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "아이디";
            dataGridView1.Columns[1].HeaderText = "비밀번호";
            dataGridView1.Columns[2].HeaderText = "이름";
            dataGridView1.Columns[3].HeaderText = "E-Mail";

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            string id = dr.Cells[0].Value.ToString();
            string passwd = dr.Cells[1].Value.ToString();
            string sql = "delete from user where id='" + id + "' and passwd='" + passwd + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("회원이 삭제되었습니다.");
            Hide();
            UserAdmin user = new UserAdmin();
            user.ShowDialog();
            Close();
        }
    }
}
