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
    public partial class FreeWriting : Form
    {
        static MySqlConnection conn = null;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public FreeWriting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Free free = new Free();
            free.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (titletxt.Text.Trim() == "" || contenttxt.Text.Trim() == "")
            {
                if (MessageBox.Show("모든 항목을 입력해 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Retry)
                {
                    titletxt.Text = "";
                    contenttxt.Text = "";
                }
            }
            else
            {
                GetConnection();
                string id = Login.id;
                string name = "자유게시판";
                string sql = "insert into board(id,boardname,title, content, date) values ('" + id + "','" + name + "','" + titletxt.Text + "','" + contenttxt.Text + "', Now())";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("게시글이 작성되었습니다.");
                this.Hide();
                Free free = new Free();
                free.ShowDialog();
                this.Close();
            }
        }

        private void FreeWriting_Load(object sender, EventArgs e)
        {

        }
    }
}
