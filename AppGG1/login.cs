using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace AppGG1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        MySqlConnection cnx = new MySqlConnection("server=localhost;database=users;userid=root;pwd=;");
        MySqlCommand cmd;
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txt_log.Text.Trim()) || !string.IsNullOrEmpty(Txt_Password.Text.Trim()))
                {
                    cmd = new MySqlCommand();
                    cmd.Connection = cnx;
                    MySqlDataAdapter ada = new MySqlDataAdapter("SELECT COUNT(*) FROM user WHERE login='" + txt_log.Text + "'" +
                        "and pwd='" + Txt_Password.Text + "'"
                        , cnx);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Form1 h = new Form1();
                        
                        h.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login or mot de passse invalide", "Vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Login or mot de passe vide", "Vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           

                if (checkBox1.Checked)
                {
                    Txt_Password.isPassword = false;
                }
                else
                {
                    Txt_Password.isPassword = true;
                }
            }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void Txt_Password_OnValueChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                Txt_Password.isPassword = false;
            }
            else
            {
                Txt_Password.isPassword = true;
            }
        }
    }
    }

