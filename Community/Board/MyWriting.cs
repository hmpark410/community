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
    public partial class MyWriting : Form
    {
        public static string boardname;
        public static string title;
        public static string content;
        public static string date;
        static MySqlConnection conn = null;
        MySqlDataAdapter adpt;
        DataTable dt;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public MyWriting()
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

        private void MyWriting_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string id = Login.id;
            adpt = new MySqlDataAdapter("select boardname,title,content,date from board where id = '" + id + "'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "게시판";
            dataGridView1.Columns[1].HeaderText = "제목";
            dataGridView1.Columns[2].HeaderText = "내용";
            dataGridView1.Columns[3].HeaderText = "날짜";

            conn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            boardname = dr.Cells[0].Value.ToString();
            title = dr.Cells[1].Value.ToString();
            content = dr.Cells[2].Value.ToString();
            date = dr.Cells[3].Value.ToString();
            Hide();
            FreeUpdate freeUpdate = new FreeUpdate();
            freeUpdate.ShowDialog();
            Close();
        }
    }
}
