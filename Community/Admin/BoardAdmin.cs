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
    public partial class BoardAdmin : Form
    {
        static MySqlConnection conn = null;
        MySqlDataAdapter adpt;
        MySqlDataAdapter adpt2;
        DataTable dt;
        DataTable dt2;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public BoardAdmin()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            AdminHome home = new AdminHome();
            home.ShowDialog();
            Close();
        }

        private void BoardAdmin_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            adpt = new MySqlDataAdapter("select * from board", conn);
            adpt2 = new MySqlDataAdapter("select * from comment", conn);
            dt = new DataTable();
            dt2 = new DataTable();
            adpt.Fill(dt);
            adpt2.Fill(dt2);
            dataGridView2.DataSource = dt;
            dataGridView1.DataSource = dt2;

            dataGridView1.Columns[0].HeaderText = "작성자(ID)";
            dataGridView1.Columns[1].HeaderText = "게시판";
            dataGridView1.Columns[2].HeaderText = "제목";
            dataGridView1.Columns[3].HeaderText = "내용";
            dataGridView1.Columns[4].HeaderText = "댓글";
            dataGridView2.Columns[0].HeaderText = "작성자(ID)";
            dataGridView2.Columns[1].HeaderText = "게시판";
            dataGridView2.Columns[2].HeaderText = "제목";
            dataGridView2.Columns[3].HeaderText = "내용";
            dataGridView2.Columns[4].HeaderText = "날짜";

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            string id = dr.Cells[0].Value.ToString();
            string boardname = dr.Cells[1].Value.ToString();
            string content = dr.Cells[3].Value.ToString();
            string sql = "delete from board where id='" + id + "' and boardname='" + boardname + "' and content='"+content+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("게시글이 삭제되었습니다.");
            Hide();
            BoardAdmin board = new BoardAdmin();
            board.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConnection();
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            string id = dr.Cells[0].Value.ToString();
            string boardname = dr.Cells[1].Value.ToString();
            string content = dr.Cells[3].Value.ToString();
            string comment = dr.Cells[4].Value.ToString();
            string sql = "delete from comment where id='" + id + "' and boardname='" + boardname + "' and content='" + content + "' and comment='"+comment+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("댓글이 삭제되었습니다.");
            Hide();
            BoardAdmin board = new BoardAdmin();
            board.ShowDialog();
            Close();
        }
    }
}
