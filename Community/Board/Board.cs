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
    public partial class Board : Form
    {
        public Board()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            MyWriting writing = new MyWriting();
            writing.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MyComment comment= new MyComment();
            comment.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Free free = new Free();
            free.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Promotion promotion = new Promotion();
            promotion.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Information information = new Information();
            information.ShowDialog();
            Close();
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

        private void Board_Load(object sender, EventArgs e)
        {

        }
    }
}
