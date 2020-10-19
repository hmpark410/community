using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Community
{
    public partial class MemberInsert : Form
    {
        static MySqlConnection conn = null;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public MemberInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idtxt.Text.Trim() == "" || passwdtxt.Text.Trim() == "" || nametxt.Text.Trim() == "" || emailtxt.Text.Trim() == "")
            {
                if (MessageBox.Show("모든 항목을 입력해 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Retry)
                {
                    idtxt.Text = "";
                    passwdtxt.Text = "";
                    nametxt.Text = "";
                    emailtxt.Text = "";
                }
            }
            else
            {
                GetConnection();
                string sql = "insert into user(id, passwd, name, email) values ('" + idtxt.Text + "','" + passwdtxt.Text + "','" + nametxt.Text + "','" + emailtxt.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(nametxt.Text + "님 회원가입이 완료되었습니다.");
                Hide();
                Login login = new Login();
                login.ShowDialog();
                Close();
            }      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
            Close();
        }

        private void MemberInsert_Load(object sender, EventArgs e)
        {

        }
    }
}
