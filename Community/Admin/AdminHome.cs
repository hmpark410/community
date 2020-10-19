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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Hide();
            BoardAdmin board = new BoardAdmin();
            board.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            TimeTableAdmin timetable = new TimeTableAdmin();
            timetable.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            UserAdmin user = new UserAdmin();
            user.ShowDialog();
            Close();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            AdminMyHome myhome = new AdminMyHome();
            myhome.ShowDialog();
            Close();
        }
    }
}
