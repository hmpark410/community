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
    public partial class Home : Form
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
        public Home()
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

        private void 시간표ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            TimeTable timetable = new TimeTable();
            timetable.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ybus.kr/spring/user/yiuFood.action");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yongin.ac.kr/index");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yongin.ac.kr/guides/academic/schedule/2018/12/9");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MyHome myhome = new MyHome();
            myhome.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            label2.Text = System.DateTime.Now.ToString("MM" + "월 " + "dd" + "일 " + "dddd");
            GetConnection();
            conn.Open();
            string id = Login.id;
            string day = System.DateTime.Now.ToString("ddd");
            adpt = new MySqlDataAdapter("select * from timetable where day='"+day+"' and sbno in (select sbno from ttresult where id like '" + id + "')", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "단과대학";
            dataGridView1.Columns[1].HeaderText = "전공";
            dataGridView1.Columns[2].HeaderText = "과목";
            dataGridView1.Columns[3].HeaderText = "학수번호";
            dataGridView1.Columns[4].HeaderText = "요일";
            dataGridView1.Columns[5].HeaderText = "시간";
            dataGridView1.Columns[6].HeaderText = "위치";
            dataGridView1.Columns[7].HeaderText = "학점";
            dataGridView1.Columns[8].HeaderText = "교수명";
            conn.Close();
        }
    }
}
