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
    public partial class Log_In_Form : Form
    {
        public Log_In_Form()
        {
            InitializeComponent();
        }

        private void button_WOC13_Click(object sender, EventArgs e)
        {
            if (LogIn.isvalid(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                this.Hide();
                MessageBox.Show("Hello " + textBox1.Text);
                Server_Form fserveur = new Server_Form();
                fserveur.Show();
            }
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log_In_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
