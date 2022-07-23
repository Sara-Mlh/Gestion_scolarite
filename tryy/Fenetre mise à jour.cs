using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryy
{
    public partial class Fenetre_mise_à_jour : Form
    {
        public Fenetre_mise_à_jour()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MenuPrincipal Menu = new MenuPrincipal();
            Menu.Show();
            this.Hide();
        }

       

        

        private void EtudiantsBT_Click(object sender, EventArgs e)
        {
            Etudiants Etd = new Etudiants();
            Etd.Show();
            this.Hide();
        }

        private void ModulesBT_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules();
            modules.Show();
            this.Hide();
        }

        private void ExamensBT_Click(object sender, EventArgs e)
        {
            Examens EXAM = new Examens();
            EXAM.Show();
            this.Hide();
        }
    }
    }

