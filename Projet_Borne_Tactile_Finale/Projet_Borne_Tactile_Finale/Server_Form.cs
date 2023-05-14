using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Borne_Tactile_Finale
{
    public partial class Server_Form : Form
    {
        public Server_Form()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bd_Projet_Borne_Tactile;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand command;
        String picLoc1 = "";
        private void button_WOC13_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
            }
        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(picLoc1, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);
            img = binaryReader.ReadBytes((int)fs.Length);
            conn.Open();
            string sql = "INSERT INTO Produit VALUES(" + Convert.ToInt32(textBox1.Text) + ",'" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "',@img,'" + comboBox1.SelectedValue + "')";
            /*if(conn.State != ConnectionState.Open)
            {
                conn.Open();
            }*/
            command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@img", img));
            int x = command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Produit inserrer");
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
            dataGridView1.DataSource = Liste_Client();

        }
        public void Supprimer(Int32 ID)
        {
            string req = "delete from Produit where Id_Produit = @ID";
            SqlCommand cmdsupp = new SqlCommand(req, conn);
            cmdsupp.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            cmdsupp.ExecuteNonQuery();
            conn.Close();
        }
        private void button_WOC3_Click(object sender, EventArgs e)
        {
            Supprimer(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Produit supprimer");
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
            dataGridView1.DataSource = Liste_Client();
        }
        public void Modifier(Produit P)
        {
            string req = "update Produit set Nom_Produit=@Nom,Prix_Produit=@Prix,Image = @img, Id_Categorie = @Cat where Id_Produit =@ID";
            SqlCommand cmdmaj = new SqlCommand(req, conn);
            byte[] img = null;
            FileStream fs = new FileStream(picLoc1, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);
            img = binaryReader.ReadBytes((int)fs.Length);
            conn.Open();
            cmdmaj.Parameters.AddWithValue("@ID", P.ID);
            cmdmaj.Parameters.AddWithValue("@Nom", P.Nom_P);
            cmdmaj.Parameters.AddWithValue("@Prix", P.Prix);
            cmdmaj.Parameters.AddWithValue("@img", SqlDbType.Image).Value=img;
            cmdmaj.Parameters.AddWithValue("@Cat", P.cat);
            cmdmaj.ExecuteNonQuery();
            conn.Close();
        }
        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Produit P = new Produit();
            P.ID = Convert.ToInt32(textBox1.Text);
            P.Nom_P = textBox2.Text;
            P.Prix = Convert.ToInt32(textBox3.Text);
            P.cat = (int)comboBox1.SelectedValue;
            Modifier(P);
            MessageBox.Show("Produit modifier");
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
            dataGridView1.DataSource = Liste_Client();
        }
        public  DataTable Liste_Client()
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Id_Produit,Nom_Produit,Prix_Produit,Id_Categorie from Produit",conn);
            da.Fill(dtcl);
            return dtcl;
        }
        public DataTable existe()
        {
            DataTable dtcl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Id_Produit,Nom_Produit,Prix_Produit,Id_Categorie from Produit where Nom_Produit like'%"+textBox2.Text+"%'", conn);
            da.Fill(dtcl);
            return dtcl;
        }
        private void Server_Form_Load(object sender, EventArgs e)
        {
            DataTable dtcl = new DataTable();
            SqlCommand cmd = new SqlCommand("select Id_Categorie,Nom_Categorie from Categorie", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dtcl);
            comboBox1.DataSource = dtcl;
            comboBox1.DisplayMember = "Nom_Categorie";
            comboBox1.ValueMember = "Id_Categorie";
            dataGridView1.DataSource = Liste_Client();
            label5.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Id_Produit"].Value.ToString();
                textBox2.Text = row.Cells["Nom_Produit"].Value.ToString();
                textBox3.Text = row.Cells["Prix_Produit"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["Id_Categorie"].Value.ToString();
            }
        }
        private void button_WOC4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = existe();
            textBox2.Clear();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Liste_Client();
            textBox1.Clear();
            textBox1.Focus();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox1.Image = null;
        }
    }
}
