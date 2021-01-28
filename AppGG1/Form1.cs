using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppGG1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            hopital1.Hide();
            lab1.Hide();
            patient1.Hide();
            medecin1.Hide();
            service1.Hide();
            consultation1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            hopital1.Hide();
            lab1.Hide();
            patient1.Hide();
            medecin1.Hide();
            service1.Show();
            consultation1.Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            hopital1.Hide();
            lab1.Hide();
            patient1.Show();
            medecin1.Hide();
            service1.Hide();
            consultation1.Hide();
        }

        private void Hopital1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            hopital1.Show();
            lab1.Hide();
            patient1.Hide();
            medecin1.Hide();
            service1.Hide();
            consultation1.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            hopital1.Hide();
            lab1.Show();
            patient1.Hide();
            medecin1.Hide();
            service1.Hide();
            consultation1.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            hopital1.Hide();
            lab1.Hide();
            patient1.Hide();
            medecin1.Show();
            service1.Hide();
            consultation1.Hide();
            
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login a = new login();
            a.Show();


        }

        private void Hopital1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
