using System;
using System.Windows.Forms;

namespace BARAN
{
    public partial class MainMenu : Form
    {
        // 1. Parametresiz Yapıcı Metot
        public MainMenu()
        {
            InitializeComponent();
        }

        // 2. Kullanıcı Adı Alan Yapıcı Metot (Login'den gelen)
        public MainMenu(string user) : this()
        {
            // İsterseniz kullanıcı adını başlıkta gösterebilirsiniz
            lblBaslik.Text = $"Hoşgeldiniz, Sayın {user} - Kontrol Paneli";
        }

        // --- BUTON OLAYLARI ---

        // 1. Ürün Arama
        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            try
            {
                UrunAra urunForm = new UrunAra();
                urunForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form açılırken hata: " + ex.Message);
            }
        }

        // 2. Müşteri Paneli
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            try
            {
                // Using bloğu form kapandığında kaynakları temizler
                using (var frm = new musteri())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri formu hatası: " + ex.Message);
            }
        }

        // 3. Galvaniz Paneli
        private void btnGalvaniz2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new galvanizteklif())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Galvaniz formu hatası: " + ex.Message);
            }
        }

        // 4. Satın Alma (Sarf) Paneli
        private void btnSatinalma_Click(object sender, EventArgs e)
        {
            try
            {
                // Sarf formunuzu (Sarf.cs) açar
                using (var frm = new Sarf())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satın alma modülü hatası: " + ex.Message);
            }
        }

        // 5. Çıkış Butonu
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Form Kapanırken (X tuşu ile)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}