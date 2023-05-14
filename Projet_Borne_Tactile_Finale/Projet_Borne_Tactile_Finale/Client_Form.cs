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
    public partial class Client_Form : Form
    {
        public static Client_Form instance;
        public RichTextBox rb1;
        public RichTextBox rb2;
        public RichTextBox rb3;
        public DataGridView dgv1;
        public Label lbl1;
        public Client_Form()
        {
            InitializeComponent();
            instance = this;
            rb1 = richTextBox1;
            rb2 = richTextBox2;
            rb3 = richTextBox3;
            dgv1 = dataGridView1;
            lbl1 = label1;
        }
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bd_Projet_Borne_Tactile;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand command;
        private void Client_Form_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            GetData();
        }

        public void GetData()
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192,192,0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224,224,224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }
        }

        double tot = 0;
        public void onclick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
            conn.Open();
            command = new SqlCommand("SELECT * FROM Produit WHERE Id_Produit like'" + tag + "'", conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                //tot += double.Parse(reader["Prix_Produit"].ToString());
                dataGridView1.Rows.Add(reader["Nom_Produit"],reader["Prix_Produit"]);
            }
            reader.Close();
            conn.Close();
            label10.Visible = false;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
           // richTextBox1.Text = tot.ToString();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "1";
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "2";
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "3";
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "4";
        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "5";
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "6";
        }

        private void button_WOC7_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "7";
        }

        private void button_WOC8_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "8";
        }

        private void button_WOC9_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "9";
        }

        private void button_WOC10_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox3.Text += "0";
        }

        private void button_WOC11_Click(object sender, EventArgs e)
        {
            String ch = richTextBox3.Text;
            //richTextBox3.Text = ch.Remove(ch.Length - 1);
            richTextBox3.Text = ch.Substring(0, ch.Length - 1);
            //richTextBox1.Text = Convert.ToString(richTextBox3.Text.Length);
        }

        private void button_WOC13_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(richTextBox3.Text);
            double b = Convert.ToDouble(richTextBox1.Text);
            label6.Visible = false;
            double res = a - b;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.Text = Convert.ToString(res);
        }

        private void button_WOC16_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));
            richTextBox1.Text = Convert.ToString(tot);
            dataGridView1.Rows.RemoveAt(rowin);
        }

        private void button_WOC18_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            label10.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            tot = 0;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            GetData();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //PIZZA
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit WHERE Id_Categorie = 2";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192, 192, 0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224, 224, 224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

            //SANDWICH
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit WHERE Id_Categorie = 5";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192, 192, 0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224, 224, 224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            //PASTA
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit WHERE Id_Categorie = 3";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192, 192, 0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224, 224, 224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            //BURGER
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit WHERE Id_Categorie = 4";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192, 192, 0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224, 224, 224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

            //BOISSON
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            string sql = "SELECT Id_Produit , Nom_Produit,Prix_Produit,Image from Produit WHERE Id_Categorie = 6";// WHERE Id_Produit ='"+Convert.ToInt32(textBox1.Text)+"'
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[3]);
                    PictureBox picb = new PictureBox();
                    picb.Width = 150;
                    picb.Height = 100;
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Cursor = Cursors.Hand;
                    picb.BackgroundImageLayout = ImageLayout.Stretch;
                    picb.Tag = reader["Id_Produit"].ToString();

                    Label Price = new Label();
                    Price.Text = reader["Prix_Produit"].ToString();
                    Price.Width = 50;
                    Price.BackColor = Color.FromArgb(192, 192, 0);
                    Price.TextAlign = ContentAlignment.MiddleLeft;
                    Price.Dock = DockStyle.Top;


                    Label art = new Label();
                    art.Text = reader["Nom_Produit"].ToString();
                    art.BackColor = Color.FromArgb(224, 224, 224);
                    art.TextAlign = ContentAlignment.MiddleLeft;
                    art.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream(img);
                    picb.Image = Image.FromStream(ms);
                    picb.Controls.Add(Price);
                    picb.Controls.Add(art);
                    picb.Click += new EventHandler(onclick);
                    flowLayoutPanel1.Controls.Add(picb);
                }
                reader.Close();
                conn.Close();
            }

        }

        private void button_WOC17_Click(object sender, EventArgs e)
        {
            TICKET tk = new TICKET();
            tk.Show();
            dataGridView1.Rows.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            label10.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            tot = 0;
        }

        private void button_WOC14_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 1;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 1;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC26_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 2;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 2;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC12_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 3;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 3;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC20_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 4;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 4;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC19_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 5;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 5;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC15_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 6;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 6;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC23_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 7;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 7;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC22_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 8;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 8;
            richTextBox1.Text = Convert.ToString(tot);
        }

        private void button_WOC21_Click(object sender, EventArgs e)
        {
            int rowin = dataGridView1.CurrentCell.RowIndex;
            tot -= (Convert.ToDouble(dataGridView1.Rows[rowin].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[rowin].Cells[2].Value));

            dataGridView1.Rows[rowin].Cells[2].Value = 9;

            tot += Convert.ToDouble(dataGridView1.Rows[rowin].Cells["Column3"].Value) * 9;
            richTextBox1.Text = Convert.ToString(tot);
        }
    }
}