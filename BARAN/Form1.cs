using LoginDemoFramework;
using System;
using System.Windows.Forms;

namespace BARAN
{
    public partial class Form1 : Form
    {
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;

                AddUser.CreateUser(user, pass);
                MessageBox.Show("Yeni kullanıcı eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde çalışan olay
        private void Form1_Load(object sender, EventArgs e)
        {
            // Buraya form açıldığında yapılacak işlemler yazılabilir
            // Örnek: txtUser.Focus();
            txtUser.Focus();
        }

        // "Şifreyi göster" kutusu işaretlendiğinde çalışır
        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShow.Checked;
        }

        // Giriş butonuna basıldığında çalışır
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            try
            {
                if (UserStoreSql.ValidateCredentials(user, pass)) // DB doğrulama
                {
                    MessageBox.Show("Hoşgeldiniz " + user, "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ana menüyü aç
                    MainMenu main = new MainMenu(user);
                    main.Show();

                    // Login formunu gizle
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

