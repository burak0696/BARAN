using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BARAN
{
    public partial class UrunSecimFormu : Form
    {
        // Ana forma veri taşıyacak özellikler
        public int SecilenId { get; private set; }
        public string SecilenBarkod { get; private set; }
        public bool YeniEkleIstegi { get; private set; } = false;

        private DataGridView dgvSonuclar; // Grid
        private Button btnSec;            // Seç Butonu
        private Button btnYeni;           // Yeni Ekle Butonu

        public UrunSecimFormu(DataTable dt)
        {
            InitializeComponent(); // Designer.cs'deki boş metodu çağırır
            ArayuzuOlustur(dt);    // Arayüzü kodla çizer
        }

        private void ArayuzuOlustur(DataTable dt)
        {
            // Form Ayarları
            this.Text = "Arama Sonuçları - Lütfen Seçim Yapın";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            // Bilgi Etiketi
            Label lbl = new Label();
            lbl.Text = "Birden fazla ürün bulundu. Listeden seçip 'SEÇ' butonuna basın veya çift tıklayın.";
            lbl.Dock = DockStyle.Top;
            lbl.Height = 40;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.LightYellow;

            // Grid Ayarları
            dgvSonuclar = new DataGridView();
            dgvSonuclar.Dock = DockStyle.Fill;
            dgvSonuclar.DataSource = dt;
            dgvSonuclar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSonuclar.ReadOnly = true;
            dgvSonuclar.AllowUserToAddRows = false;
            dgvSonuclar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvSonuclar.Columns.Contains("Id")) dgvSonuclar.Columns["Id"].Visible = false;

            // Çift Tıklama Olayını Elle Bağlıyoruz
            dgvSonuclar.DoubleClick += (s, e) => SecimIslemi();

            // Alt Panel ve Butonlar
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Bottom;
            pnl.Height = 50;

            btnYeni = new Button();
            btnYeni.Text = "ARADIĞIM YOK (YENİ EKLE)";
            btnYeni.Size = new Size(200, 30);
            btnYeni.Location = new Point(10, 10);
            btnYeni.BackColor = Color.OrangeRed;
            btnYeni.ForeColor = Color.White;
            // Yeni Ekleme Olayını Bağlıyoruz
            btnYeni.Click += (s, e) => { YeniEkleIstegi = true; this.Close(); };

            btnSec = new Button();
            btnSec.Text = "SEÇ";
            btnSec.Size = new Size(100, 30);
            btnSec.Location = new Point(470, 10);
            btnSec.BackColor = Color.SeaGreen;
            btnSec.ForeColor = Color.White;
            // Seçme Olayını Bağlıyoruz
            btnSec.Click += (s, e) => SecimIslemi();

            pnl.Controls.Add(btnYeni);
            pnl.Controls.Add(btnSec);

            this.Controls.Add(dgvSonuclar);
            this.Controls.Add(pnl);
            this.Controls.Add(lbl);
        }

        private void SecimIslemi()
        {
            if (dgvSonuclar.SelectedRows.Count > 0)
            {
                SecilenId = Convert.ToInt32(dgvSonuclar.SelectedRows[0].Cells["Id"].Value);
                SecilenBarkod = dgvSonuclar.SelectedRows[0].Cells["Barkod"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir satır seçin.");
            }
        }
    }
}