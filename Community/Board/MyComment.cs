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
    public partial class MyComment : Form
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
        public MyComment()
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
        
        private void 시간표ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            TimeTable timetable = new TimeTable();
            timetable.ShowDialog();
            Close();
        }

        private void 게시판ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            Board board = new Board();
            board.ShowDialog();
            Close();
        }

        private void MyComment_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string id = Login.id;
            adpt = new MySqlDataAdapter("select boardname,title,content, comment from comment where id='" + id + "'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "게시판";
            dataGridView1.Columns[1].HeaderText = "제목";
            dataGridView1.Columns[2].HeaderText = "내용";
            dataGridView1.Columns[3].HeaderText = "댓글";

            conn.Close();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            GetConnection();
            string id = Login.id;
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            string comment = dr.Cells[3].Value.ToString();
            string sql = "delete from comment where comment='" + comment + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("댓글이 삭제되었습니다.");
            Hide();
            MyComment comment1 = new MyComment();
            comment1.ShowDialog();
            Close();
        }
    }
}
