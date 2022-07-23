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
    public partial class Modules : Form
    {
        public Modules()
        {
            InitializeComponent();
            DisplayModules();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ScolariteDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayModules()
        {
            con.Open();
            string query = "select * from ModuleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ModulesDGV.DataSource = ds.Tables[0];

            con.Close();

        }
        private void clear()
        {
            CodeMTB.Clear();
            LibelleTB.Clear();
            CoeffTB.Clear();
        }

        private void ModulesBT_Click(object sender, EventArgs e)
        {
            Etudiants etd = new Etudiants();
            etd.Show();
            this.Hide();
           
        }

        private void SupprimerBT_Click(object sender, EventArgs e)
        {
            /*  if (CodeMTB.Text == "" || LibelleTB.Text == "" || CoeffTB.Text == "" )
              {
                  MessageBox.Show("Informations manquante !Veuillez introduire toute les informations");
              }
              else
              {
                  MessageBox.Show("Suppression faite avec succès");
                  CodeMTB.Text = "";
                  LibelleTB.Text = "";
                  CoeffTB.Text = "";
              } */
            if (CodeMTB.Text == "" || LibelleTB.Text == "" || CoeffTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" delete from ModuleTbl values CodeM=@MCod ", con);
                    cmd.Parameters.AddWithValue("@MCod", CodeMTB.Text);
                    cmd.Parameters.AddWithValue("@MLib", LibelleTB.Text);
                    cmd.Parameters.AddWithValue("@MC", CoeffTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Module deleted successfully");

                    con.Close();
                    DisplayModules();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ModifierBT_Click(object sender, EventArgs e)
        {
            /*  if (CodeMTB.Text == "" || LibelleTB.Text == "" || CoeffTB.Text == "")
              {
                  MessageBox.Show("Informations manquante !Veuillez introduire toute les informations");
              }
              else
              {
                  MessageBox.Show("Modification faite avec succès");
              } */
            if (CodeMTB.Text == "" || LibelleTB.Text == "" || CoeffTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" update ModuleTbl set Libelle = @MLib ,Coeff = @MC where CodeM = @MCod ", con);
                    cmd.Parameters.AddWithValue("@MCod", CodeMTB.Text);
                    cmd.Parameters.AddWithValue("@MLib", LibelleTB.Text);
                    cmd.Parameters.AddWithValue("@MC", CoeffTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Module updated");

                    con.Close();
                    DisplayModules();
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
            /*  if (CodeMTB.Text == ""  || LibelleTB.Text == "" || CoeffTB.Text == "")
              {
                  MessageBox.Show("Informations manquante !Veuillez introduire toute les informations");
              }
              else
              {
                  MessageBox.Show("Ajout fait avec succès");
              } */
            if (CodeMTB.Text == "" || LibelleTB.Text == "" || CoeffTB.Text == "")
            {
                MessageBox.Show("Missing informations");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" insert into ModuleTbl(CodeM,LibelleM,Coeff) values (@MCod, @MLib, @MC) ", con);
                    cmd.Parameters.AddWithValue("@MCod", CodeMTB.Text);
                    cmd.Parameters.AddWithValue("@MLib", LibelleTB.Text);
                    cmd.Parameters.AddWithValue("@MC", CoeffTB.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Module Added");

                    con.Close();
                    DisplayModules();
                    clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ChercherBT_Click(object sender, EventArgs e)
        {
            string CodeM = CodeMTB.Text;
            string libelle = LibelleTB.Text;
            if (CodeM== "")
            {
                MessageBox.Show("Veuillez introduire le matricule SVP !");
            }
            else
            {
                if((CodeM == "1"&& libelle=="ALGO")||(CodeM == "3"&& libelle=="ARCHI"))
                {
                    MessageBox.Show("Module existant");
                }
                else
                {
                 
                    MessageBox.Show("Module inexistant.Veuillez remplir ses données et l'ajouter");
                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MenuPrincipal FTmenu = new MenuPrincipal();
            FTmenu.Show();
            this.Hide();
        }

        private void PrecedentBT_Click(object sender, EventArgs e)
        {
            MenuPrincipal FTmenu = new MenuPrincipal();
            FTmenu.Show();
            this.Hide();
        }

        private void ResetBT_Click(object sender, EventArgs e)
        {
            CodeMTB.Text = "";
            LibelleTB.Text = "";
            CoeffTB.Text = "";
        }

        private void CodeMTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        Examens exam = new Examens();
        private void ExamensBT_Click(object sender, EventArgs e)
        {
            this.Hide();
            exam.Show();
        }

        private void EtudiantsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CodeMTB.Text = ModulesDGV.SelectedRows[0].Cells[1].Value.ToString();
            LibelleTB.Text = ModulesDGV.SelectedRows[0].Cells[2].Value.ToString();
            CoeffTB.Text = ModulesDGV.SelectedRows[0].Cells[3].Value.ToString();

        }
    }
}
