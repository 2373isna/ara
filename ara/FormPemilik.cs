using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ara
{
    public partial class FormPemilik : Form
    {
        public FormPemilik()
        {
            InitializeComponent();
        }

        private void FormPemilik_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
            conn.Open();

            NpgsqlCommand comm = new NpgsqlCommand("SELECT * FROM barang", conn);
            NpgsqlDataReader read = comm.ExecuteReader();

            if (read.HasRows)
            {
                DataTable dtab = new DataTable();
                dtab.Load(read);
                //.DataSource = dtab;
                dataGridView1.DataSource = dtab;// dgv mengambil data dari data table
            }
            comm.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
