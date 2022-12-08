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
public partial class Barang_gudang : Form
    {
        public Barang_gudang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
                conn.Open();

                NpgsqlCommand comm = new NpgsqlCommand($"select * from add_barang('{textBox1.Text}', {textBox2.Text}, {textBox3.Text}, '{textBox4.Text}', '{textBox5.Text}')", conn);
                int result = (int)comm.ExecuteScalar();

                if (result == 1)
                {
                    MessageBox.Show("Data ditambahkan ke dalam database", "Input berhasil");
                    comm.CommandText = "SELECT * FROM barang";
                    NpgsqlDataReader read = comm.ExecuteReader();

                    if (read.HasRows)
                    {
                        DataTable dtab = new DataTable();
                        dtab.Load(read);
                        dataGridView1.DataSource = dtab;
                    }
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data ke dalam database", "Input gagal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message, "Invalid database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Barang_gudang_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
                conn.Open();

                MessageBox.Show("Data telah di-hapus dari database", "Berhasil Menghapus", MessageBoxButtons.OK);
                
                NpgsqlCommand comm = new NpgsqlCommand($"DELETE FROM barang WHERE id_produk = {textBox6.Text}", conn);
                comm.ExecuteNonQuery();

                comm.CommandText = "SELECT * FROM barang";
                NpgsqlDataReader read = comm.ExecuteReader();

                if (read.HasRows)
                {
                    DataTable dtabBaru = new DataTable();
                    dtabBaru.Load(read);
                    dataGridView1.DataSource = dtabBaru;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
                conn.Open();

                NpgsqlCommand comm = new NpgsqlCommand($"SELECT * FROM upd_barang('{textBox1.Text}', {textBox2.Text}, {textBox3.Text}, '{textBox4.Text}', '{textBox5.Text}')", conn);

                int result = (int)comm.ExecuteScalar();

                if (result == 1)
                {
                    MessageBox.Show("Data telah di-update dari database", "Berhasil Update", MessageBoxButtons.OK);

                    //Meng-update data yang terdapat dalam Data Grid View
                    comm.CommandText = "SELECT * FROM barang";
                    NpgsqlDataReader read = comm.ExecuteReader();

                    if (read.HasRows)
                    {
                        DataTable dtab = new DataTable();
                        dtab.Load(read);
                        dataGridView1.DataSource = dtab;
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak dapat di-update", "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}