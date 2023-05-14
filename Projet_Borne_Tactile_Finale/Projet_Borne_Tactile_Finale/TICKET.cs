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
    public partial class TICKET : Form
    {
        public TICKET()
        {
            InitializeComponent();
        }

        private void TICKET_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("\n\t\t\tRESTO\n\n");
            richTextBox1.AppendText("\t\t\t\tLe " + Client_Form.instance.lbl1.Text + "\n\n");
            richTextBox1.AppendText("\tArticle\t\t" + "\tPrix\t\t"+"Qte\t\n");
            richTextBox1.AppendText("\t*********************************************************************\n");
            for (int i = 0; i < Client_Form.instance.dgv1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < Client_Form.instance.dgv1.Columns.Count; j++)
                {
                    richTextBox1.Text += "\t" + Client_Form.instance.dgv1.Rows[i].Cells[j].Value.ToString() + "\t";
                }
                richTextBox1.Text += "\n";
                richTextBox1.AppendText("\t----------------------------------------------------------------------------------------\n");
            }
            richTextBox1.AppendText("\t*********************************************************************\n");
            richTextBox1.Text += "\t\tNet a payer: " + Client_Form.instance.rb1.Text+"\n\n";
            richTextBox1.Text += "\t\t\t\tRendu: " + Client_Form.instance.rb2.Text + "\n\n\n";
            richTextBox1.Text += "\t\t***** AU REVOIR *****";
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
