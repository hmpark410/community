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
    public partial class TimeTableAdmin : Form
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
        public TimeTableAdmin()
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

        private void TimeTableAdmin_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            adpt = new MySqlDataAdapter("select * from timetable", conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            part1txt.Text = dr.Cells[0].Value.ToString();
            majortxt.Text = dr.Cells[1].Value.ToString();
            subjecttxt.Text = dr.Cells[2].Value.ToString();
            sbnotxt.Text = dr.Cells[3].Value.ToString();
            daytxt.Text = dr.Cells[4].Value.ToString();
            timetxt.Text = dr.Cells[5].Value.ToString();
            locationtxt.Text = dr.Cells[6].Value.ToString();
            credittxt.Text = dr.Cells[7].Value.ToString();
            proftxt.Text = dr.Cells[8].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            string sql = "insert into timetable(part1, major, subject, sbno, day, time, location, credit, professor) values ('" + part1txt.Text + "','" + majortxt.Text + "','" + subjecttxt.Text + "','" + sbnotxt.Text + "','" + daytxt.Text + "','" + timetxt.Text + "','" + locationtxt.Text + "'," + credittxt.Text + ",'"+proftxt.Text+"')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(subjecttxt.Text +"이/가 추가되었습니다.");
            Hide();
            TimeTableAdmin timetable = new TimeTableAdmin();
            timetable.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetConnection();
            string sql = "update timetable set part1='"+part1txt.Text+"', major='"+majortxt.Text+"', subject='"+subjecttxt.Text+"', sbno='"+sbnotxt.Text+"', day='"+daytxt.Text+"',time='"+timetxt.Text+"',location='"+locationtxt.Text+"',credit="+credittxt.Text+",professor='"+proftxt.Text+"' where sbno='" + sbnotxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(subjecttxt.Text + "이/가 수정되었습니다.");
            Hide();
            TimeTableAdmin timetable = new TimeTableAdmin();
            timetable.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetConnection();
            string sql = "delete from timetable where sbno='" + sbnotxt.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(subjecttxt.Text + "이/가 삭제되었습니다.");
            Hide();
            TimeTableAdmin timetable = new TimeTableAdmin();
            timetable.ShowDialog();
            Close();
        }
    }
}
