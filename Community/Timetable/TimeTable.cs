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
    public partial class TimeTable : Form
    {
        static MySqlConnection conn = null;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=community;uid=root;pwd=cs1234;";
            if (conn == null) conn = new MySqlConnection(connectionString);
            return conn;
        }
        public TimeTable()
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

        private void TimeTable_Load(object sender, EventArgs e)
        {
            string id = Login.id;
            GetConnection();
            #region query
            MySqlCommand day1 = new MySqlCommand("select day from timetable where day='월' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand day2 = new MySqlCommand("select day from timetable where day='화' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand day3 = new MySqlCommand("select day from timetable where day='수' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand day4 = new MySqlCommand("select day from timetable where day='목' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand day5 = new MySqlCommand("select day from timetable where day='금' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub1_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc1_m= new MySqlCommand("select location from timetable where day='월' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub1_t = new MySqlCommand("select subject from timetable where day='화' and time like '%"+1+"%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc1_t = new MySqlCommand("select location from timetable where day='화' and time like '%"+ 1 +"%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub1_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc1_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub1_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc1_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub1_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc1_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub2_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc2_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub2_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc2_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub2_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc2_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub2_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc2_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub2_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc2_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub3_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc3_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub3_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc3_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub3_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc3_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub3_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc3_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub3_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc3_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub4_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc4_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub4_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc4_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub4_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc4_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub4_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc4_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub4_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc4_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub5_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc5_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub5_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc5_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub5_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 5+ "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc5_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub5_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc5_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub5_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc5_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub6_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc6_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub6_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc6_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub6_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc6_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub6_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc6_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub6_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc6_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub7_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc7_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub7_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc7_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub7_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc7_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub7_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc7_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub7_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc7_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand sub8_m = new MySqlCommand("select subject from timetable where day='월' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc8_m = new MySqlCommand("select location from timetable where day='월' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub8_t = new MySqlCommand("select subject from timetable where day='화' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc8_t = new MySqlCommand("select location from timetable where day='화' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub8_w = new MySqlCommand("select subject from timetable where day='수' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc8_w = new MySqlCommand("select location from timetable where day='수' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub8_th = new MySqlCommand("select subject from timetable where day='목' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc8_th = new MySqlCommand("select location from timetable where day='목' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand sub8_f = new MySqlCommand("select subject from timetable where day='금' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand loc8_f = new MySqlCommand("select location from timetable where day='금' and time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);

            MySqlCommand time1 = new MySqlCommand("select time from timetable where time like '%" + 1 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time2 = new MySqlCommand("select time from timetable where time like '%" + 2 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time3 = new MySqlCommand("select time from timetable where time like '%" + 3 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time4 = new MySqlCommand("select time from timetable where time like '%" + 4 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time5 = new MySqlCommand("select time from timetable where time like '%" + 5 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time6 = new MySqlCommand("select time from timetable where time like '%" + 6 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time7 = new MySqlCommand("select time from timetable where time like '%" + 7 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand time8 = new MySqlCommand("select time from timetable where time like '%" + 8 + "%' and sbno in (select sbno from ttresult where id='" + id + "')", conn);
            MySqlCommand count = new MySqlCommand("select count(*) from ttresult where id='" + id + "'", conn);
            #endregion //query
            conn.Open();
            #region string변환 및 선언
            string day_1 = Convert.ToString(day1.ExecuteScalar());
            string day_2 = Convert.ToString(day2.ExecuteScalar());
            string day_3 = Convert.ToString(day3.ExecuteScalar());
            string day_4 = Convert.ToString(day4.ExecuteScalar());
            string day_5 = Convert.ToString(day5.ExecuteScalar());

            string sub_1_m = Convert.ToString(sub1_m.ExecuteScalar());
            string loc_1_m = Convert.ToString(loc1_m.ExecuteScalar());
            string sub_1_t = Convert.ToString(sub1_t.ExecuteScalar());
            string loc_1_t = Convert.ToString(loc1_t.ExecuteScalar());
            string sub_1_w = Convert.ToString(sub1_w.ExecuteScalar());
            string loc_1_w = Convert.ToString(loc1_w.ExecuteScalar());
            string sub_1_th = Convert.ToString(sub1_th.ExecuteScalar());
            string loc_1_th = Convert.ToString(loc1_th.ExecuteScalar());
            string sub_1_f = Convert.ToString(sub1_f.ExecuteScalar());
            string loc_1_f = Convert.ToString(loc1_f.ExecuteScalar());

            string sub_2_m = Convert.ToString(sub2_m.ExecuteScalar());
            string loc_2_m = Convert.ToString(loc2_m.ExecuteScalar());
            string sub_2_t = Convert.ToString(sub2_t.ExecuteScalar());
            string loc_2_t = Convert.ToString(loc2_t.ExecuteScalar());
            string sub_2_w = Convert.ToString(sub2_w.ExecuteScalar());
            string loc_2_w = Convert.ToString(loc2_w.ExecuteScalar());
            string sub_2_th = Convert.ToString(sub2_th.ExecuteScalar());
            string loc_2_th = Convert.ToString(loc2_th.ExecuteScalar());
            string sub_2_f = Convert.ToString(sub2_f.ExecuteScalar());
            string loc_2_f = Convert.ToString(loc2_f.ExecuteScalar());

            string sub_3_m = Convert.ToString(sub3_m.ExecuteScalar());
            string loc_3_m = Convert.ToString(loc3_m.ExecuteScalar());
            string sub_3_t = Convert.ToString(sub3_t.ExecuteScalar());
            string loc_3_t = Convert.ToString(loc3_t.ExecuteScalar());
            string sub_3_w = Convert.ToString(sub3_w.ExecuteScalar());
            string loc_3_w = Convert.ToString(loc3_w.ExecuteScalar());
            string sub_3_th = Convert.ToString(sub3_th.ExecuteScalar());
            string loc_3_th = Convert.ToString(loc3_th.ExecuteScalar());
            string sub_3_f = Convert.ToString(sub3_f.ExecuteScalar());
            string loc_3_f = Convert.ToString(loc3_f.ExecuteScalar());

            string sub_4_m = Convert.ToString(sub4_m.ExecuteScalar());
            string loc_4_m = Convert.ToString(loc4_m.ExecuteScalar());
            string sub_4_t = Convert.ToString(sub4_t.ExecuteScalar());
            string loc_4_t = Convert.ToString(loc4_t.ExecuteScalar());
            string sub_4_w = Convert.ToString(sub4_w.ExecuteScalar());
            string loc_4_w = Convert.ToString(loc4_w.ExecuteScalar());
            string sub_4_th = Convert.ToString(sub4_th.ExecuteScalar());
            string loc_4_th = Convert.ToString(loc4_th.ExecuteScalar());
            string sub_4_f = Convert.ToString(sub4_f.ExecuteScalar());
            string loc_4_f = Convert.ToString(loc4_f.ExecuteScalar());

            string sub_5_m = Convert.ToString(sub5_m.ExecuteScalar());
            string loc_5_m = Convert.ToString(loc5_m.ExecuteScalar());
            string sub_5_t = Convert.ToString(sub5_t.ExecuteScalar());
            string loc_5_t = Convert.ToString(loc5_t.ExecuteScalar());
            string sub_5_w = Convert.ToString(sub5_w.ExecuteScalar());
            string loc_5_w = Convert.ToString(loc5_w.ExecuteScalar());
            string sub_5_th = Convert.ToString(sub5_th.ExecuteScalar());
            string loc_5_th = Convert.ToString(loc5_th.ExecuteScalar());
            string sub_5_f = Convert.ToString(sub5_f.ExecuteScalar());
            string loc_5_f = Convert.ToString(loc5_f.ExecuteScalar());

            string sub_6_m = Convert.ToString(sub6_m.ExecuteScalar());
            string loc_6_m = Convert.ToString(loc6_m.ExecuteScalar());
            string sub_6_t = Convert.ToString(sub6_t.ExecuteScalar());
            string loc_6_t = Convert.ToString(loc6_t.ExecuteScalar());
            string sub_6_w = Convert.ToString(sub6_w.ExecuteScalar());
            string loc_6_w = Convert.ToString(loc6_w.ExecuteScalar());
            string sub_6_th = Convert.ToString(sub6_th.ExecuteScalar());
            string loc_6_th = Convert.ToString(loc6_th.ExecuteScalar());
            string sub_6_f = Convert.ToString(sub6_f.ExecuteScalar());
            string loc_6_f = Convert.ToString(loc6_f.ExecuteScalar());

            string sub_7_m = Convert.ToString(sub7_m.ExecuteScalar());
            string loc_7_m = Convert.ToString(loc7_m.ExecuteScalar());
            string sub_7_t = Convert.ToString(sub7_t.ExecuteScalar());
            string loc_7_t = Convert.ToString(loc7_t.ExecuteScalar());
            string sub_7_w = Convert.ToString(sub7_w.ExecuteScalar());
            string loc_7_w = Convert.ToString(loc7_w.ExecuteScalar());
            string sub_7_th = Convert.ToString(sub7_th.ExecuteScalar());
            string loc_7_th = Convert.ToString(loc7_th.ExecuteScalar());
            string sub_7_f = Convert.ToString(sub7_f.ExecuteScalar());
            string loc_7_f = Convert.ToString(loc7_f.ExecuteScalar());

            string sub_8_m = Convert.ToString(sub8_m.ExecuteScalar());
            string loc_8_m = Convert.ToString(loc8_m.ExecuteScalar());
            string sub_8_t = Convert.ToString(sub8_t.ExecuteScalar());
            string loc_8_t = Convert.ToString(loc8_t.ExecuteScalar());
            string sub_8_w = Convert.ToString(sub8_w.ExecuteScalar());
            string loc_8_w = Convert.ToString(loc8_w.ExecuteScalar());
            string sub_8_th = Convert.ToString(sub8_th.ExecuteScalar());
            string loc_8_th = Convert.ToString(loc8_th.ExecuteScalar());
            string sub_8_f = Convert.ToString(sub8_f.ExecuteScalar());
            string loc_8_f = Convert.ToString(loc8_f.ExecuteScalar());

            string time_1 = Convert.ToString(time1.ExecuteScalar());
            string time_2 = Convert.ToString(time2.ExecuteScalar());
            string time_3 = Convert.ToString(time3.ExecuteScalar());
            string time_4 = Convert.ToString(time4.ExecuteScalar());
            string time_5 = Convert.ToString(time5.ExecuteScalar());
            string time_6 = Convert.ToString(time6.ExecuteScalar());
            string time_7 = Convert.ToString(time7.ExecuteScalar());
            string time_8 = Convert.ToString(time8.ExecuteScalar());
            int count1 = Convert.ToInt32(count.ExecuteScalar());
            #endregion //string변환 및 선언

            while (count1 > 0)
            {
                if (day_1 == "월")
                {
                    if (time_1.Contains("1"))
                    {
                        mon1.Text = "" + sub_1_m + "\n" + loc_1_m + "";
                    }
                    if (time_2.Contains("2"))
                    {
                        mon2.Text = "" + sub_2_m + "\n" + loc_2_m + "";
                    }
                    if (time_3.Contains("3"))
                    {
                        mon3.Text = "" + sub_3_m + "\n" + loc_3_m + "";
                    }
                    if (time_4.Contains("4"))
                    {
                        mon4.Text = "" + sub_4_m + "\n" + loc_4_m + "";
                    }
                    if (time_5.Contains("5"))
                    {
                        mon5.Text = "" + sub_5_m + "\n" + loc_5_m + "";
                    }
                    if (time_6.Contains("6"))
                    {
                        mon6.Text = "" + sub_6_m + "\n" + loc_6_m + "";
                    }
                    if (time_7.Contains("7"))
                    {
                        mon7.Text = "" + sub_7_m + "\n" + loc_7_m + "";
                    }
                    if (time_8.Contains("8"))
                    {
                        mon8.Text = "" + sub_8_m + "\n" + loc_8_m + "";
                    }
                }
                if (day_2 == "화")
                {
                    if (time_1.Contains("1"))
                    {
                        tue1.Text = "" + sub_1_t + "\n" + loc_1_t + "";
                    }
                    if (time_2.Contains("2"))
                    {
                        tue2.Text = "" + sub_2_t + "\n" + loc_2_t + "";
                    }
                    if (time_3.Contains("3"))
                    {
                        tue3.Text = "" + sub_3_t + "\n" + loc_3_t + "";
                    }
                    if (time_4.Contains("4"))
                    {
                        tue4.Text = "" + sub_4_t + "\n(" + loc_4_t + ")";
                    }
                    if (time_5.Contains("5"))
                    {
                        tue5.Text = "" + sub_5_t + "\n" + loc_5_t + "";
                    }
                    if (time_6.Contains("6"))
                    {
                        tue6.Text = "" + sub_6_t + "\n" + loc_6_t + "";
                    }
                    if (time_7.Contains("7"))
                    {
                        tue7.Text = "" + sub_7_t + "\n" + loc_7_t + "";
                    }
                    if (time_8.Contains("8"))
                    {
                        tue8.Text = "" + sub_8_t + "\n" + loc_8_t + "";
                    }
                }
                if (day_3 == "수")
                {
                    if (time_1.Contains("1"))
                    {
                        wed1.Text = "" + sub_1_w + "\n" + loc_1_w + "";
                    }
                    if (time_2.Contains("2"))
                    {
                        wed2.Text = "" + sub_2_w + "\n" + loc_2_w + "";
                    }
                    if (time_3.Contains("3"))
                    {
                        wed3.Text = "" + sub_3_w + "\n" + loc_3_w + "";
                    }
                    if (time_4.Contains("4"))
                    {
                        wed4.Text = "" + sub_4_w + "\n" + loc_4_w + "";
                    }
                    if (time_5.Contains("5"))
                    {
                        wed5.Text = "" + sub_5_w + "\n" + loc_5_w + "";
                    }
                    if (time_6.Contains("6"))
                    {
                        wed6.Text = "" + sub_6_w + "\n" + loc_6_w + "";
                    }
                    if (time_7.Contains("7"))
                    {
                        wed7.Text = "" + sub_7_w + "\n" + loc_7_w + "";
                    }
                    if (time_8.Contains("8"))
                    {
                        wed8.Text = "" + sub_8_w + "\n" + loc_8_w + "";
                    }
                }
                if (day_4 == "목")
                {
                    if (time_1.Contains("1"))
                    {
                        thu1.Text = "" + sub_1_th + "\n" + loc_1_th + "";
                    }
                    if (time_2.Contains("2"))
                    {
                        thu2.Text = "" + sub_2_th + "\n" + loc_2_th + "";
                    }
                    if (time_3.Contains("3"))
                    {
                        thu3.Text = "" + sub_3_th + "\n" + loc_3_th + "";
                    }
                    if (time_4.Contains("4"))
                    {
                        thu4.Text = "" + sub_4_th + "\n" + loc_4_th + "";
                    }
                    if (time_5.Contains("5"))
                    {
                        thu5.Text = "" + sub_5_th + "\n" + loc_5_th + "";
                    }
                    if (time_6.Contains("6"))
                    {
                        thu6.Text = "" + sub_6_th + "\n" + loc_6_th + "";
                    }
                    if (time_7.Contains("7"))
                    {
                        thu7.Text = "" + sub_7_th + "\n" + loc_7_th + "";
                    }
                    if (time_8.Contains("8"))
                    {
                        thu8.Text = "" + sub_8_th + "\n" + loc_8_th + "";
                    }
                }
                if (day_5 == "금")
                {
                    if (time_1.Contains("1"))
                    {
                        fri1.Text = "" + sub_1_f + "\n" + loc_1_f + "";
                    }
                    if (time_2.Contains("2"))
                    {
                        fri2.Text = "" + sub_2_f + "\n" + loc_2_f + "";
                    }
                    if (time_3.Contains("3"))
                    {
                        fri3.Text = "" + sub_3_f + "\n" + loc_3_f + "";
                    }
                    if (time_4.Contains("4"))
                    {
                        fri4.Text = "" + sub_4_f + "\n" + loc_4_f + "";
                    }
                    if (time_5.Contains("5"))
                    {
                        fri5.Text = "" + sub_5_f + "\n" + loc_5_f + "";
                    }
                    if (time_6.Contains("6"))
                    {
                        fri6.Text = "" + sub_6_f + "\n" + loc_6_f + "";
                    }
                    if (time_7.Contains("7"))
                    {
                        fri7.Text = "" + sub_7_f + "\n" + loc_7_f + "";
                    }
                    if (time_8.Contains("8"))
                    {
                        fri8.Text = "" + sub_8_f + "\n" + loc_8_f + "";
                    }
                }
                count1--;
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AddTimeTable add = new AddTimeTable();
            add.ShowDialog();
            Close();
        }
    }
}