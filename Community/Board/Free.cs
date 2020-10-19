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
    public partial class Free : Form
    {
        public static string content;
        public static string id;
        public static string date;
        public static string title;
        static MySqlConnection conn = null;
        MySqlDataAdapter adpt;
        DataTable dt;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Free()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            FreeWriting writing = new FreeWriting();
            writing.ShowDialog();
            Close();
        }

        private void Free_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string name = "자유게시판";
            adpt = new MySqlDataAdapter("select title,content,date,id from board where boardname = '"+name+"'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "제목";
            dataGridView1.Columns[1].HeaderText = "내용";
            dataGridView1.Columns[2].HeaderText = "날짜";
            dataGridView1.Columns[3].HeaderText = "작성자(ID)";

            conn.Close();
        }

        private void 게시판ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Hide();
            Board board = new Board();
            board.ShowDialog();
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            title = dr.Cells[0].Value.ToString();
            content = dr.Cells[1].Value.ToString();
            date = dr.Cells[2].Value.ToString();
            id = dr.Cells[3].Value.ToString();
            Hide();
            FreeClick click = new FreeClick();
            click.ShowDialog();
            Close();
        }
    }
}
