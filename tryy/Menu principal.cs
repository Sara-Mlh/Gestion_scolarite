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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

      

        private void Màj_Click(object sender, EventArgs e)
        {
            this.MàjBTN.BackColor = Color.Red;
            this.Hide();
        
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Etudiants ETD = new Etudiants();
        private void Màj_Click_1(object sender, EventArgs e)
        {
          
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenuText_Click(object sender, EventArgs e)
        {

        }

        private void EtatsButton_Click(object sender, EventArgs e)
        {

        }

        private void MàjBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fenetre_mise_à_jour Maj = new Fenetre_mise_à_jour();
            Maj.Show();
        }
    }
}
