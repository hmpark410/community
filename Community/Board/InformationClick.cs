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
    public partial class InformationClick : Form
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
        public InformationClick()
        {
            InitializeComponent();
            titletxt.Text = Information.title;
            contenttxt.Text = Information.content;
            datetxt.Text = Information.date;
            idtxt.Text = Information.id;
        }

        private void InfomationClick_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string content = Information.content;
            adpt = new MySqlDataAdapter("select id,comment from comment where content = '" + content + "'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Information information = new Information();
            information.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            string id = Login.id;
            string name = "정보게시판";
            string content = Information.content;
            string sql = "insert into comment(id,boardname,title,content,comment) values ('" + id + "','" + name + "','" + titletxt.Text + "','" + content + "','" + commenttxt.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            InformationClick info = new InformationClick();
            info.ShowDialog();
            this.Close();
        }
    }
}
