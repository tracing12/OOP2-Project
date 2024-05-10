using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System.Host
{
    public partial class Post : Form
    {
        public Post()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPost man = new AddPost();
            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPost gue_u = new EditPost();

            gue_u.TopLevel = false;
            gue_u.AutoScroll = true;
            gue_u.Dock = DockStyle.Fill;
            panel1.Controls.Add(gue_u);
            gue_u.FormBorderStyle = FormBorderStyle.None;
            gue_u.BringToFront();



            gue_u.Show();
        }
    }
}
