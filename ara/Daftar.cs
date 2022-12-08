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
    public partial class Daftar : Form
    {
        public Daftar()
        {
            InitializeComponent();
        }

        private void btn_Pemilik_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
                conn.Open();

                NpgsqlCommand comm = new NpgsqlCommand($"select * from add_pemilik('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}')", conn);
                int result = (int)comm.ExecuteScalar();

                if (result == 1)
                {
                    MessageBox.Show("Data ditambahkan ke dalam database", "Input berhasil");
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

        private void btn_Karyawan_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("host=localhost;uid=postgres;pwd=puspita0826;database=PBOProjek");
                conn.Open();

                NpgsqlCommand comm = new NpgsqlCommand($"select * from add_karyawan('{textBox12.Text}', '{textBox11.Text}', '{textBox10.Text}', '{textBox9.Text}', '{textBox8.Text}', '{textBox7.Text}')", conn);
                int result = (int)comm.ExecuteScalar();

                if (result == 1)
                {
                    MessageBox.Show("Data ditambahkan ke dalam database", "Input berhasil");
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

        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
