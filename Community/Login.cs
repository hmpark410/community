using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Community
{
    public partial class Login : Form
    {
        public static string id;
        public Login()
        {
            InitializeComponent();
            Text = "YIU COMMUNITY";          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            new MemberInsert().ShowDialog();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            MySqlConnection conn = new MySqlConnection("server=localhost;database=community;uid=root;pwd=cs1234;");
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT id, passwd FROM User WHERE id =@pram1 and passwd=@pram2";
            cmd.Parameters.Add("@pram1", MySqlDbType.VarChar, 50).Value = idtxt.Text;
            cmd.Parameters.Add("@pram2", MySqlDbType.VarChar, 50).Value = passwdtxt.Text;
            cmd.Connection = conn;

            conn.Open();
            
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (idtxt.Text == "admin")
                {
                    id = idtxt.Text;
                    this.Hide();
                    admin.AdminHome home = new admin.AdminHome();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    id = idtxt.Text;
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Close();
                }       
            }
            else if (idtxt.Text.Trim() == "" || passwdtxt.Text.Trim() == "")
            {
                if (MessageBox.Show("ID와 PASSWORD를 입력해 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Retry)
                {
                    idtxt.Text = "";
                    passwdtxt.Text = "";
                }
            }
            else
            {
                if (MessageBox.Show("ID 또는 PASSWORD를 확인해 주세요.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                {
                    idtxt.Text = "";
                    passwdtxt.Text = "";
                }
            }
            reader.Close();

            conn.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
