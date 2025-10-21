using System.Windows.Forms;

namespace BARAN
{
    partial class galvaniz
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvMusteriler;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Panel pnlTeklif;
        private System.Windows.Forms.Label lblSecilenMusteri;
        private System.Windows.Forms.TextBox txtLME;
        private System.Windows.Forms.TextBox txtMaliyet;
        private System.Windows.Forms.Button btnTeklifKaydet;
        private System.Windows.Forms.ComboBox cmbKaplama;
        private System.Windows.Forms.Button btnUrunKaydet;
        private System.Windows.Forms.Panel pnlDetay;
        private System.Windows.Forms.Label lblDetay;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.ListView lvUrunler;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunDuzenle;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnGecmisTeklifler;
        private System.Windows.Forms.DataGridView dgvGecmisTeklifler;
        private System.Windows.Forms.DataGridView dgvUrunler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.btnIleri = new System.Windows.Forms.Button();
            this.pnlTeklif = new System.Windows.Forms.Panel();
            this.lblSecilenMusteri = new System.Windows.Forms.Label();
            this.txtLME = new System.Windows.Forms.TextBox();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.btnTeklifKaydet = new System.Windows.Forms.Button();
            this.cmbKaplama = new System.Windows.Forms.ComboBox();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.lvUrunler = new System.Windows.Forms.ListView();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnGecmisTeklifler = new System.Windows.Forms.Button();
            this.dgvGecmisTeklifler = new System.Windows.Forms.DataGridView();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisTeklifler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.pnlTeklif.SuspendLayout();
            this.SuspendLayout();

            // dgvMusteriler
            this.dgvMusteriler.Location = new System.Drawing.Point(20, 20);
            this.dgvMusteriler.Size = new System.Drawing.Size(500, 250);
            this.dgvMusteriler.ReadOnly = true;
            this.dgvMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusteriler.MultiSelect = false;

            this.pnlDetay = new System.Windows.Forms.Panel();
            this.pnlDetay.Location = new System.Drawing.Point(640, 290);
            this.pnlDetay.Size = new System.Drawing.Size(200, 300);
            this.pnlDetay.Visible = false;
            this.pnlDetay.BorderStyle = BorderStyle.FixedSingle;

            this.lblDetay = new System.Windows.Forms.Label();
            this.lblDetay.Location = new System.Drawing.Point(10, 10);
            this.lblDetay.Size = new System.Drawing.Size(180, 280);
            this.lblDetay.Text = "Detaylar burada gösterilecek";
            this.lblDetay.AutoSize = false;

            this.pnlDetay.Controls.Add(this.lblDetay);
            this.Controls.Add(this.pnlDetay);
            // btnIleri
            this.btnIleri.Location = new System.Drawing.Point(530, 20);
            this.btnIleri.Size = new System.Drawing.Size(80, 30);
            this.btnIleri.Text = "İleri";
            this.btnIleri.Click += new System.EventHandler(this.btnIleri_Click);

            this.btnUrunKaydet = new System.Windows.Forms.Button();
            this.btnUrunKaydet.Location = new System.Drawing.Point(440, 240);
            this.btnUrunKaydet.Size = new System.Drawing.Size(100, 28);
            this.btnUrunKaydet.Text = "Kaydet";
            this.btnUrunKaydet.Click += new System.EventHandler(this.btnUrunKaydet_Click);
            this.pnlTeklif.Controls.Add(this.btnUrunKaydet);

            // pnlTeklif
            this.pnlTeklif.Location = new System.Drawing.Point(20, 290);
            this.pnlTeklif.Size = new System.Drawing.Size(800, 500);
            this.pnlTeklif.Visible = false;

            // lblSecilenMusteri
            this.lblSecilenMusteri.Location = new System.Drawing.Point(10, 10);
            this.lblSecilenMusteri.Size = new System.Drawing.Size(300, 25);

            // txtLME
            this.txtLME.Location = new System.Drawing.Point(10, 40);
            this.txtLME.Size = new System.Drawing.Size(100, 22);

            // txtMaliyet
            this.txtMaliyet.Location = new System.Drawing.Point(120, 40);
            this.txtMaliyet.Size = new System.Drawing.Size(100, 22);

            // btnTeklifKaydet
            this.btnTeklifKaydet.Location = new System.Drawing.Point(230, 40);
            this.btnTeklifKaydet.Size = new System.Drawing.Size(100, 25);
            this.btnTeklifKaydet.Text = "Teklifi Kaydet";
            this.btnTeklifKaydet.Click += new System.EventHandler(this.btnTeklifKaydet_Click);

            // cmbKaplama
            this.cmbKaplama.Location = new System.Drawing.Point(10, 80);
            this.cmbKaplama.Size = new System.Drawing.Size(200, 24);
            this.cmbKaplama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // txtKg
            this.txtKg.Location = new System.Drawing.Point(220, 80);
            this.txtKg.Size = new System.Drawing.Size(100, 22);

            // btnUrunEkle
            this.btnUrunEkle.Location = new System.Drawing.Point(330, 80);
            this.btnUrunEkle.Size = new System.Drawing.Size(100, 28);
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);

            // lvUrunler
            this.lvUrunler.Location = new System.Drawing.Point(10, 120);
            this.lvUrunler.Size = new System.Drawing.Size(420, 150);
            this.lvUrunler.View = System.Windows.Forms.View.Details;
            this.lvUrunler.FullRowSelect = true;
            this.lvUrunler.Columns.Add("Kaplama", 200);
            this.lvUrunler.Columns.Add("Kg", 100);
            this.lvUrunler.Columns.Add("Tutar", 100);

            // btnUrunSil
            this.btnUrunSil.Location = new System.Drawing.Point(440, 120);
            this.btnUrunSil.Size = new System.Drawing.Size(100, 28);
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);

            // btnUrunDuzenle
            this.btnUrunDuzenle.Location = new System.Drawing.Point(440, 160);
            this.btnUrunDuzenle.Size = new System.Drawing.Size(100, 28);
            this.btnUrunDuzenle.Text = "Düzenle";
            this.btnUrunDuzenle.Click += new System.EventHandler(this.btnUrunDuzenle_Click);

            // btnPdf
            this.btnPdf.Location = new System.Drawing.Point(440, 200);
            this.btnPdf.Size = new System.Drawing.Size(100, 28);
            this.btnPdf.Text = "PDF Çıktısı";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);

            this.dgvGecmisTeklifler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGecmisTeklifler_CellDoubleClick);
            this.dgvGecmisTeklifler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGecmisTeklifler_CellDoubleClick);
            // dgvUrunler
            this.dgvUrunler.Location = new System.Drawing.Point(10, 280);
            this.dgvUrunler.Size = new System.Drawing.Size(600, 150);
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrunler.Columns.Add("Kaplama", "Kaplama");
            this.dgvUrunler.Columns.Add("Kg", "Kg");
            this.dgvUrunler.Columns.Add("Tutar", "Tutar");

            // btnGecmisTeklifler
            this.btnGecmisTeklifler.Location = new System.Drawing.Point(620, 20);
            this.btnGecmisTeklifler.Size = new System.Drawing.Size(150, 30);
            this.btnGecmisTeklifler.Text = "Geçmiş Teklifler";
            this.btnGecmisTeklifler.Click += new System.EventHandler(this.btnGecmisTeklifler_Click);

            // dgvGecmisTeklifler
            this.dgvGecmisTeklifler.Location = new System.Drawing.Point(20, 800);
            this.dgvGecmisTeklifler.Size = new System.Drawing.Size(600, 150);
            this.dgvGecmisTeklifler.ReadOnly = true;
            this.dgvGecmisTeklifler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGecmisTeklifler.Visible = false;

            // pnlTeklif.Controls
            this.pnlTeklif.Controls.Add(this.lblSecilenMusteri);
            this.pnlTeklif.Controls.Add(this.txtLME);
            this.pnlTeklif.Controls.Add(this.txtMaliyet);
            this.pnlTeklif.Controls.Add(this.btnTeklifKaydet);
            this.pnlTeklif.Controls.Add(this.cmbKaplama);
            this.pnlTeklif.Controls.Add(this.txtKg);
            this.pnlTeklif.Controls.Add(this.btnUrunEkle);
            this.pnlTeklif.Controls.Add(this.lvUrunler);
            this.pnlTeklif.Controls.Add(this.btnUrunSil);
            this.pnlTeklif.Controls.Add(this.btnUrunDuzenle);
            this.pnlTeklif.Controls.Add(this.btnPdf);
            this.pnlTeklif.Controls.Add(this.dgvUrunler);

            // Form Controls
            this.Controls.Add(this.dgvMusteriler);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGecmisTeklifler);
            this.Controls.Add(this.pnlTeklif);
            this.Controls.Add(this.dgvGecmisTeklifler);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(860, 980);
            this.Name = "galvaniz";
            this.Text = "Teklif Oluştur";
            this.Load += new System.EventHandler(this.galvaniz_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisTeklifler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.pnlTeklif.ResumeLayout(false);
            this.pnlTeklif.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}