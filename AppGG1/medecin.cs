using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppGG1
{
    public partial class medecin : UserControl
    {
        public medecin()
        {
            InitializeComponent();
        }
        MySqlConnection cnx = new MySqlConnection("server=localhost;database=gestiondeshopitaux;uid=root;pwd=;");
        MySqlCommand cmd;
        int id = 0;
        private void Medecin_Load(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;database=gestiondeshopitaux;uid=root;pwd=;");

            try
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand();
                // string ligne = dataGridView1.SelectedRows.ToString();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from medecin ";
                DataSet ds = new DataSet();

                MySqlDataAdapter ada = new MySqlDataAdapter();
                ada.SelectCommand = cmd;
                ada.Fill(ds, "dataTablehopital");
                dataGridView1.DataSource = ds.Tables["dataTablehopital"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GhostWhite;
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                    }
                }

            }
            catch { }
        }

        private void BunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void BunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57) // code asci des numero
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void BunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57) // code asci des numero
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void BunifuMaterialTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57) // code asci des numero
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void BunifuMaterialTextbox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57) // code asci des numero
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection cnx = new MySqlConnection("server=localhost;database=gestiondeshopitaux;userid=root;pwd=;");
            try
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = cnx;

                cmd.CommandText = "insert into medecin values(" + int.Parse(bunifuMaterialTextbox1.Text) + "," + int.Parse(bunifuMaterialTextbox2.Text) + "," + int.Parse(bunifuMaterialTextbox3.Text) + ",'" + bunifuMaterialTextbox4.Text + "','" + bunifuMaterialTextbox5.Text + "','" + bunifuMaterialTextbox6.Text + "','" + bunifuMaterialTextbox7.Text + "','" + bunifuMaterialTextbox8.Text + "','" + bunifuMaterialTextbox9.Text + "','" + comboBox1.Text + "')";

                cmd.ExecuteNonQuery();
                MessageBox.Show("ajout effectué");



            }
            catch
            {
                MessageBox.Show("err");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from medecin ";
                DataSet ds = new DataSet();

                MySqlDataAdapter ada = new MySqlDataAdapter();
                ada.SelectCommand = cmd;
                ada.Fill(ds, "dataTablelab");
                dataGridView1.DataSource = ds.Tables["dataTablelab"];

            }
            catch { }
        }

        public void searchData(string valueToSearch)
        {
            string req = "select * from medecin where concat(codeMedecin,codeService,codeLaboratoire,nom,prenom,telephone,email,adresse,specialite,categorie) like '%" + valueToSearch + "%'";
            cmd = new MySqlCommand(req, cnx);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            ada.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void BunifuMaterialTextbox11_OnValueChanged(object sender, EventArgs e)
        {
            string valueToSearch = bunifuMaterialTextbox11.Text.ToString();
            searchData(valueToSearch);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = cnx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update medecin set codeService=" + int.Parse(bunifuMaterialTextbox2.Text) + ",codeLaboratoire=" + int.Parse(bunifuMaterialTextbox3.Text) + ",nom='" + bunifuMaterialTextbox4.Text + "',prenom='" + bunifuMaterialTextbox5.Text + "',telephone='" + bunifuMaterialTextbox6.Text + "',email='" + bunifuMaterialTextbox7.Text + "',adresse='" + bunifuMaterialTextbox8.Text + "',specialite='" + bunifuMaterialTextbox9.Text + "',categorie='" + comboBox1.Text + "' where codeMedecin=" + id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("modification effectuee avec succès");

                cnx.Close();
                Medecin_Load(sender, e);

            }
            catch { }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            bunifuMaterialTextbox1.Text = id.ToString();
            bunifuMaterialTextbox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bunifuMaterialTextbox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            bunifuMaterialTextbox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            bunifuMaterialTextbox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            bunifuMaterialTextbox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            bunifuMaterialTextbox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            bunifuMaterialTextbox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                DialogResult d = MessageBox.Show("tu es sûr", "suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {

                    try
                    {
                        cnx.Open();

                        MySqlCommand cmd = new MySqlCommand();

                        cmd.Connection = cnx;

                        cmd.CommandText = "delete from medecin where codeMedecin='" + id.ToString() + "'";

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supression effectué");

                        //Hopital_Load(sender, e);


                    }
                    catch { }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            var workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "CustomerDetail";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                }
            }
            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "outputMedecin";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}
