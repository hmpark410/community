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
    public partial class AddTimeTable : Form
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
        public AddTimeTable()
        {
            InitializeComponent();
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            adpt = new MySqlDataAdapter("select * from timetable where subject like '" + searchtxt.Text + "%'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void AddTimeTable_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string id = Login.id;
            adpt = new MySqlDataAdapter("select * from timetable", conn);
            adpt2 = new MySqlDataAdapter("select * from timetable where sbno in (select sbno from ttresult where id like '"+id+"')", conn);
            dt = new DataTable();
            dt2 = new DataTable();
            adpt.Fill(dt);
            adpt2.Fill(dt2);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;

            dataGridView1.Columns[0].HeaderText = "단과대학";
            dataGridView1.Columns[1].HeaderText = "전공";
            dataGridView1.Columns[2].HeaderText = "과목";
            dataGridView1.Columns[3].HeaderText = "학수번호";
            dataGridView1.Columns[4].HeaderText = "요일";
            dataGridView1.Columns[5].HeaderText = "시간";
            dataGridView1.Columns[6].HeaderText = "위치";
            dataGridView1.Columns[7].HeaderText = "학점";
            dataGridView1.Columns[8].HeaderText = "교수명";
            dataGridView2.Columns[0].HeaderText = "단과대학";
            dataGridView2.Columns[1].HeaderText = "전공";
            dataGridView2.Columns[2].HeaderText = "과목";
            dataGridView2.Columns[3].HeaderText = "학수번호";
            dataGridView2.Columns[4].HeaderText = "요일";
            dataGridView2.Columns[5].HeaderText = "시간";
            dataGridView2.Columns[6].HeaderText = "위치";
            dataGridView2.Columns[7].HeaderText = "학점";
            dataGridView2.Columns[8].HeaderText = "교수명";

            conn.Close();
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            string id = Login.id;
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            string subject = dr.Cells[2].Value.ToString();
            string sbno = dr.Cells[3].Value.ToString();
            string day = dr.Cells[4].Value.ToString();
            string time = dr.Cells[5].Value.ToString();

            GetConnection();
            conn.Open();
            MySqlCommand time1 = new MySqlCommand("select time from ttresult where day='"+day+"' and id='"+id+"'",conn);
            string time_1 = Convert.ToString(time1.ExecuteScalar());
            MySqlCommand day1 = new MySqlCommand("select day from ttresult where day='" + day + "' and id='" + id + "'", conn);
            string day_1 = Convert.ToString(day1.ExecuteScalar());
            int a = time_1.IndexOf(time);
            int b = time.IndexOf(time_1);
            if (day==day_1)
            {
                if (a!=-1 || b!=-1 || time.Contains(time_1) || time_1.Contains(time))
                MessageBox.Show("시간이 겹치는 수업이 있습니다");
                else
                {
                    string sql = "insert into ttresult(id, sbno,day,time) values ('" + id + "','" + sbno + "','" + day + "','" + time + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("'" + subject + "'이/가 추가되었습니다.");
                }
            }
            else
            {
                string sql = "insert into ttresult(id, sbno,day,time) values ('" + id + "','" + sbno + "','" + day + "','" + time + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("'" + subject + "'이/가 추가되었습니다.");
            }        
            conn.Close();
            this.Hide();
            AddTimeTable add = new AddTimeTable();
            add.ShowDialog();
            this.Close();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            GetConnection();
            string id = Login.id;
            DataGridViewRow dr = dataGridView2.SelectedRows[0];
            string sbno = dr.Cells[3].Value.ToString();
            string sql = "delete from ttresult where id='"+id+"' and sbno='"+sbno+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            MySqlCommand Sub = new MySqlCommand(" select subject from timetable where sbno='" + sbno + "'", conn);
            string subject = Convert.ToString(Sub.ExecuteScalar());
            conn.Close();
            MessageBox.Show("'" + subject + "'이/가 삭제되었습니다.");
            this.Hide();
            AddTimeTable add = new AddTimeTable();
            add.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TimeTable().ShowDialog();
        }
    }
}
