using System;
using System.Windows.Forms;
using WindowsFormsApp1.Authentication;
using WindowsFormsApp1.database;
using WindowsFormsApp1.IoC;
using WindowsFormsApp1.Util;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        new readonly DependencyContainer Container = DependencyContainer.getInstance();
        string capchar = Randomize.get();
        public Form1()
        {
            // register database firstly
            Container.Register(new Connection());
            // register shield for authen
            Container.Register(new Shield());
            InitializeComponent();
        }

        void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        void label1_Click(object sender, EventArgs e)
        {
        }

        void label2_Click(object sender, EventArgs e)
        {
        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        void button1_Click(object sender, EventArgs e)
        {
            Shield shield = Container.Resolve<Shield>("WindowsFormsApp1.Authentication.Shield");
            bool isLogin = shield.auth(new Credential(textBox1.Text, textBox2.Text, textBox3.Text));
            if (isLogin)
            {
                MessageBox.Show("da login");
            }
        }

        void label3_Click(object sender, EventArgs e)
        {
        }

        void button2_Click(object sender, EventArgs e)
        {
            
        }

        void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}