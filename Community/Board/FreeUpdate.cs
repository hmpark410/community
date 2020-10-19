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
    public partial class FreeUpdate : Form
    {
        public static string name;
        static MySqlConnection conn = null;
        MySqlDataAdapter adpt;
        DataTable dt;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public FreeUpdate()
        {
            InitializeComponent();
            titletxt.Text = MyWriting.title;
            contenttxt.Text = MyWriting.content;
            datetxt.Text = MyWriting.date;
            idtxt.Text = Login.id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MyWriting writing = new MyWriting();
            writing.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetConnection();
            name = MyWriting.boardname;
            string sql = "update board set title='" + titletxt.Text + "',content='" + contenttxt.Text + "' where boardname='" + name + "' and id='" + idtxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("게시글이 수정되었습니다.");
            Hide();
            MyWriting writing = new MyWriting();
            writing.ShowDialog();
            Close(); // 수정 후 돌아가기
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetConnection();
            name = MyWriting.boardname;
            string sql = "delete from board where boardname='"+name+"' and content='" + contenttxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("게시글이 삭제되었습니다.");
            Hide();
            MyWriting writing = new MyWriting();
            writing.ShowDialog();
            Close(); // 삭제 후 돌아가기
        }

        private void FreeUpdate_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            name = MyWriting.boardname;
            string content = MyWriting.content;
            adpt = new MySqlDataAdapter("select id,comment from comment where boardname='" + name + "' and content='" + contenttxt.Text + "'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            string id = Login.id;
            name = MyWriting.boardname;
            string content = MyWriting.content;
            string sql = "insert into comment(id,boardname,title,content,comment) values ('" + id + "','" + name + "','" + titletxt.Text + "','" + content + "','" + commenttxt.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            FreeUpdate free = new FreeUpdate();
            free.ShowDialog();
            this.Close();
        }
    }
}
