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
    public partial class Examens : Form
    {
        public Examens()
        {
            InitializeComponent();
            DisplayExamens();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\ScolariteDB.mdf;Integrated Security=True;Connect Timeout=30");
       
        DataTable data = new DataTable();
        DataTable data1 = new DataTable();
        //  DataSet ds = new DataSet();
        private void DisplayExamens()
        {
            con.Open();
            string query = "select * from ModuleTbl";
            string query1 = "select * from EtudiantTbl";

            
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);

            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            SqlCommandBuilder builder1 = new SqlCommandBuilder(sda1); 

            sda.Fill(data);
            sda1.Fill(data1);

           // sda.Fill(ds);
            // EtudiantsDGV.DataSource = ds.Tables[0];
            var pos = 0;
            DisplayTextModule(pos);

            con.Close();

        }

        private void AjouterBT_Click(object sender, EventArgs e)
        {

        }

        private void EtudiantsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void ModulesBT_Click(object sender, EventArgs e)
        {
            Modules Mod = new Modules();
            this.Hide();
            Mod.Show();
        }

        private void EtudiantsBT_Click(object sender, EventArgs e)
        {
            Etudiants etd = new Etudiants();
            etd.Show();
            this.Hide();
        }

        private void Examens_Load(object sender, EventArgs e)
        {

        }
        public void DisplayTextModule(int rowno)
        {

            CodeMTB.Text = data.Rows[rowno][1].ToString();

            LibelleMTB.Text = data.Rows[rowno][2].ToString();
            SpecialitéTB.Text = "ISIL";


            // partie 2eme
            CodeMTB1.Text = CodeMTB.Text;
            MatriculeTB.Text = data1.Rows[rowno][0].ToString();

        }

        int i = 1 ; 
        int j = 2  ;
        public void ModuleSuivant(int rowno)
        {
            

            CodeMTB.Text = data.Rows[rowno][i].ToString();

            LibelleMTB.Text = data.Rows[rowno][j].ToString();


            // partie 2eme
            CodeMTB1.Text = CodeMTB.Text;
            
         

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        int k = 0;
        private void SuivantMBT_Click(object sender, EventArgs e)
        {
           
            k++;
            ModuleSuivant(k);

        }
        int n = 0 ;
        public void EtudiantSuivant(int rowno)
        {


            MatriculeTB.Text = data1.Rows[rowno][n].ToString();
            NoteTB.Clear();


        }

        int kk = 0;
        private void SuivantEtdBT_Click(object sender, EventArgs e)
        {
            if (NoteTB.Text == "")
            {
                MessageBox.Show("veuillez entrer la note svp ");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" insert into ExamenTbl(CodeM,Matricule,Note) values (@CodeM,@Mat, @Note) ", con);
                    cmd.Parameters.AddWithValue("@CodeM", CodeMTB.Text);
                    cmd.Parameters.AddWithValue("@Mat", MatriculeTB.Text);
                    cmd.Parameters.AddWithValue("@Note", NoteTB.Text); ;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("note etudiant ajoutée");

                   
                    kk++;
                    EtudiantSuivant(kk);
                   

                     con.Close();
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               



            }

        }
    }
}
