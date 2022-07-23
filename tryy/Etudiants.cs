using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace tryy
{
    public partial class Etudiants : Form
    {
        public Etudiants()
        {
            InitializeComponent();
            DisplayEtudiants();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ScolariteDB.mdf;Integrated Security=True;Connect Timeout=30");

        DataTable data = new DataTable();
        DataSet ds = new DataSet();
        private void DisplayEtudiants()
        {
            con.Open();
            string query = "select * from EtudiantTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            
            sda.Fill(data);
            sda.Fill(ds);
            EtudiantsDGV.DataSource = ds.Tables[0];
            var pos = 0;
            DisplayText(pos);

            con.Close();

        }
        private void clear()
        {
            MatriculeTB.Clear();
            NomTB.Clear();
            PrenomTB.Clear();
            SectionTB.Clear();
            GroupeTB.Clear();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
            Etudiants ETD = new Etudiants();
            ETD.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MenuPrincipal FTmenu = new MenuPrincipal();
            FTmenu.Show();
            this.Hide();
        }
        Modules Mod = new Modules();
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mod.Show();

        }

        Examens exam = new Examens();
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            exam.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChercherBT_Click(object sender, EventArgs e)
        {
            string mat = MatriculeTB.Text;
            string nom = NomTB.Text;
            if (mat == "")
            {
                MessageBox.Show("Veuillez introduire le matricule SVP !");
            }
            else
            {
                if ((mat == "181831031232" && nom =="" )||( mat == "202031031232" && nom==""))
                {
                    MessageBox.Show("Etudiant inexistant.Veuillez remplir ses données et l'ajouter");
                }
                else
                {
                    MessageBox.Show("Etudiant existant");
                }

                }
            }

        private void ModifierBT_Click(object sender, EventArgs e)
        {
          
           if (MatriculeTB.Text == "" || NomTB.Text == "" || PrenomTB.Text == "" || SectionTB.Text == "" || GroupeTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" update EtudiantTbl set Nom = @EN,Prénom=@EP,Groupe=@EG,Section=@ES where Matricule=@EM ", con);
                    cmd.Parameters.AddWithValue("@EM", MatriculeTB.Text);
                    cmd.Parameters.AddWithValue("@EN", NomTB.Text);
                    cmd.Parameters.AddWithValue("@EP", PrenomTB.Text);
                    cmd.Parameters.AddWithValue("@ES", SectionTB.Text);
                    cmd.Parameters.AddWithValue("@EG", GroupeTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated ");

                    con.Close();
                    DisplayEtudiants();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           } 

        }

        private void AjouterBT_Click(object sender, EventArgs e)
        {
         
           if (MatriculeTB.Text == "" || NomTB.Text == "" || PrenomTB.Text == "" || SectionTB.Text == "" || GroupeTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd =new SqlCommand(" insert into EtudiantTbl(Matricule,Nom,Prénom,Groupe,Section) values (@EM, @EN, @EP, @EG,@ES) ",con) ;
                    cmd.Parameters.AddWithValue("@EM", MatriculeTB.Text);
                    cmd.Parameters.AddWithValue("@EN", NomTB.Text);
                    cmd.Parameters.AddWithValue("@EP", PrenomTB.Text);
                    cmd.Parameters.AddWithValue("@ES", SectionTB.Text);
                    cmd.Parameters.AddWithValue("@EG", GroupeTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added");

                    con.Close();
                    DisplayEtudiants();
                    clear();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void SupprimerBT_Click_1(object sender, EventArgs e)
        {
            if (MatriculeTB.Text == "" || NomTB.Text == "" || PrenomTB.Text == "" || SectionTB.Text == "" || GroupeTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" delete from EtudiantTbl where Matricule=@EM ", con);
                    cmd.Parameters.AddWithValue("@EM", MatriculeTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully");

                    con.Close();
                    DisplayEtudiants();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MatriculeTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MenuPrincipal FTmenu = new MenuPrincipal();
            FTmenu.Show();
            this.Hide();
        }

        private void ResetBT_Click(object sender, EventArgs e)
        {
            MatriculeTB.Clear();
            NomTB.Clear();
            PrenomTB.Clear();
            SectionTB.Clear();
            GroupeTB.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Etudiants_Load(object sender, EventArgs e)
        {

        }

      
        private void EtudiantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MatriculeTB.Text = EtudiantsDGV.SelectedRows[0].Cells[1].Value.ToString();
            NomTB.Text = EtudiantsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PrenomTB.Text = EtudiantsDGV.SelectedRows[0].Cells[3].Value.ToString();
            SectionTB.Text =  EtudiantsDGV.SelectedRows[0].Cells[4].Value.ToString();
            GroupeTB.Text = EtudiantsDGV.SelectedRows[0].Cells[5].Value.ToString();

        }
        public void DisplayText(int rowno)
        {

            MatriculeTB.Text = data.Rows[rowno][0].ToString();
           // NomTB.Text = ds.Rows[rowno][1].ToString();
           // PrenomTB.Text = ds.Rows[rowno][2].ToString();
           // SectionTB.Text = ds.Rows[rowno][3].ToString();
            GroupeTB.Text = data.Rows[rowno][4].ToString();
        }
    }
    }
