using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Borne_Tactile_Finale
{
    public partial class Home_Form : Form
    {
        public Home_Form()
        {
            InitializeComponent();
        }

        private void Home_Form_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_Form client_Form = new Client_Form();
            client_Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log_In_Form l = new Log_In_Form();
            l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
