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
    public partial class Login : Form
    {
        MenuPrincipal for2 = new MenuPrincipal();
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        
      
    }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.
                Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


        int item = 0;
        private void buttonValider_Click(object sender, EventArgs e)
        {
            

            if (item <3)
            {

                if (textBox1.Text == "" || textBox2.Text == "")
                {

                    MessageBox.Show("Connexion échoué");
                }
                else
                { if (textBox1.Text == "ADMIN" && textBox2.Text == "ADMIN")
                    {
                        MessageBox.Show("connexion reussite");
                        for2.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                if(item ==3)
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {

                        MessageBox.Show("Connexion échouée,plus de 3 essais.Veuillez réessayer une autre fois SVP");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("connexion reussite");
                        for2.Show();
                        this.Hide();
                    }

                }
                

            }
            item++;  

        }
    }
}
