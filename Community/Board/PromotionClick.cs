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
    public partial class PromotionClick : Form
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
        public PromotionClick()
        {
            InitializeComponent();
            titletxt.Text = Promotion.title;
            contenttxt.Text = Promotion.content;
            datetxt.Text = Promotion.date;
            idtxt.Text = Promotion.id;
        }
        private void PromotionClick_Load(object sender, EventArgs e)
        {
            GetConnection();
            conn.Open();
            string content = Promotion.content;
            adpt = new MySqlDataAdapter("select id,comment from comment where content = '" + content + "'", conn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Promotion promotion = new Promotion();
            promotion.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            string id = Login.id;
            string name = "홍보게시판";
            string content = Promotion.content;
            string sql = "insert into comment(id,boardname,title,content,comment) values ('" + id + "','" + name + "','" + titletxt.Text + "','" + content + "','" + commenttxt.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            PromotionClick pro = new PromotionClick();
            pro.ShowDialog();
            this.Close();
        }
    }
}
