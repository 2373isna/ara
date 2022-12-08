using Npgsql;

namespace ara
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        NpgsqlConnection conn;
        string connString = "port = 5432; host = localhost; username = postgres; password = puspita0826; database = PBOProjek";
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand($"SELECT * FROM login('{txt_username.Text}', '{txt_password.Text}')", conn);

                int result = (int)comm.ExecuteScalar();

                if (result == 1)
                {
                    this.Hide(); // hide form login
                    new Barang_gudang().Show();
                }
                else if (result == 2)
                {
                    this.Hide();
                    new FormPemilik().Show();
                }
                else
                {
                    MessageBox.Show("Username atau Password tidak valid!", "Login gagal", MessageBoxButtons.OK);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_username.Focus();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button_daftar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Daftar().Show();
        }
    }
}