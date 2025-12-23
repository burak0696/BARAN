using System.Windows.Forms;

namespace BARAN
{
    partial class galvanizteklif
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
        private System.Windows.Forms.DataGridView dgvUrunler;

        private System.Windows.Forms.Button btnUrunKaydet;
        private System.Windows.Forms.Panel pnlDetay;
        private System.Windows.Forms.Label lblDetay;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.TextBox txtTlKarsilik;

        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Label lbldolar;
        private System.Windows.Forms.TextBox txtdolar;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnGecmisTeklifler;
        private System.Windows.Forms.DataGridView dgvGecmisTeklifler;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(galvanizteklif));
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.btnIleri = new System.Windows.Forms.Button();
            this.pnlTeklif = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKumulatifkarli = new System.Windows.Forms.Label();
            this.btnKarli = new System.Windows.Forms.Button();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.lblKumulatif = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnUrunKaydet = new System.Windows.Forms.Button();
            this.cmbKaplama = new System.Windows.Forms.ComboBox();
            this.dgvGecmisTeklifler = new System.Windows.Forms.DataGridView();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.lblDetay = new System.Windows.Forms.Label();
            this.lbldolar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdolar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLME = new System.Windows.Forms.TextBox();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.btnTeklifKaydet = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSecilenMusteri = new System.Windows.Forms.Label();
            this.btnGecmisTeklifler = new System.Windows.Forms.Button();
            this.txtMusteriAra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMusteriAra = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.pnlTeklif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisTeklifler)).BeginInit();
            this.pnlDetay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMusteriler
            // 
            this.dgvMusteriler.Location = new System.Drawing.Point(20, 37);
            this.dgvMusteriler.MultiSelect = false;
            this.dgvMusteriler.Name = "dgvMusteriler";
            this.dgvMusteriler.ReadOnly = true;
            this.dgvMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusteriler.Size = new System.Drawing.Size(500, 195);
            this.dgvMusteriler.TabIndex = 1;
            // 
            // btnIleri
            // 
            this.btnIleri.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIleri.Location = new System.Drawing.Point(530, 20);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(80, 30);
            this.btnIleri.TabIndex = 2;
            this.btnIleri.Text = "Seç";
            this.btnIleri.UseVisualStyleBackColor = false;
            // 
            // pnlTeklif
            // 
            this.pnlTeklif.Controls.Add(this.pictureBox1);
            this.pnlTeklif.Controls.Add(this.lblKumulatifkarli);
            this.pnlTeklif.Controls.Add(this.btnKarli);
            this.pnlTeklif.Controls.Add(this.btnHesapla);
            this.pnlTeklif.Controls.Add(this.lblKumulatif);
            this.pnlTeklif.Controls.Add(this.label13);
            this.pnlTeklif.Controls.Add(this.label12);
            this.pnlTeklif.Controls.Add(this.label5);
            this.pnlTeklif.Controls.Add(this.label4);
            this.pnlTeklif.Controls.Add(this.dgvUrunler);
            this.pnlTeklif.Controls.Add(this.btnUrunKaydet);
            this.pnlTeklif.Controls.Add(this.cmbKaplama);
            this.pnlTeklif.Controls.Add(this.dgvGecmisTeklifler);
            this.pnlTeklif.Controls.Add(this.txtKg);
            this.pnlTeklif.Controls.Add(this.btnUrunEkle);
            this.pnlTeklif.Controls.Add(this.btnUrunSil);
            this.pnlTeklif.Controls.Add(this.btnPdf);
            this.pnlTeklif.Controls.Add(this.pnlDetay);
            this.pnlTeklif.Location = new System.Drawing.Point(20, 270);
            this.pnlTeklif.Name = "pnlTeklif";
            this.pnlTeklif.Size = new System.Drawing.Size(1231, 462);
            this.pnlTeklif.TabIndex = 4;
            this.pnlTeklif.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BARAN.Properties.Resources.Adsız_tasarım__4_;
            this.pictureBox1.Location = new System.Drawing.Point(1016, 375);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 77);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // lblKumulatifkarli
            // 
            this.lblKumulatifkarli.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblKumulatifkarli.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKumulatifkarli.Location = new System.Drawing.Point(702, 327);
            this.lblKumulatifkarli.Name = "lblKumulatifkarli";
            this.lblKumulatifkarli.Size = new System.Drawing.Size(265, 38);
            this.lblKumulatifkarli.TabIndex = 32;
            // 
            // btnKarli
            // 
            this.btnKarli.Location = new System.Drawing.Point(534, 322);
            this.btnKarli.Name = "btnKarli";
            this.btnKarli.Size = new System.Drawing.Size(151, 38);
            this.btnKarli.TabIndex = 31;
            this.btnKarli.Text = "Teklif Fiyatı";
            // 
            // btnHesapla
            // 
            this.btnHesapla.Location = new System.Drawing.Point(535, 286);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(150, 30);
            this.btnHesapla.TabIndex = 28;
            this.btnHesapla.Text = "Kümülatif Maliyet";
            // 
            // lblKumulatif
            // 
            this.lblKumulatif.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblKumulatif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKumulatif.Location = new System.Drawing.Point(702, 285);
            this.lblKumulatif.Name = "lblKumulatif";
            this.lblKumulatif.Size = new System.Drawing.Size(265, 38);
            this.lblKumulatif.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(1212, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.IndianRed;
            this.label12.Location = new System.Drawing.Point(629, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "3";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(314, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "KG Giriniz :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ürün Türü Seçiniz :";
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(17, 72);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.Size = new System.Drawing.Size(1083, 200);
            this.dgvUrunler.TabIndex = 10;
            // 
            // btnUrunKaydet
            // 
            this.btnUrunKaydet.BackColor = System.Drawing.Color.Cyan;
            this.btnUrunKaydet.Location = new System.Drawing.Point(1106, 230);
            this.btnUrunKaydet.Name = "btnUrunKaydet";
            this.btnUrunKaydet.Size = new System.Drawing.Size(100, 28);
            this.btnUrunKaydet.TabIndex = 0;
            this.btnUrunKaydet.Text = "Teklifi Kaydet";
            this.btnUrunKaydet.UseVisualStyleBackColor = false;
            // 
            // cmbKaplama
            // 
            this.cmbKaplama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKaplama.Location = new System.Drawing.Point(111, 23);
            this.cmbKaplama.Name = "cmbKaplama";
            this.cmbKaplama.Size = new System.Drawing.Size(200, 21);
            this.cmbKaplama.TabIndex = 5;
            // 
            // dgvGecmisTeklifler
            // 
            this.dgvGecmisTeklifler.Location = new System.Drawing.Point(12, 280);
            this.dgvGecmisTeklifler.Name = "dgvGecmisTeklifler";
            this.dgvGecmisTeklifler.ReadOnly = true;
            this.dgvGecmisTeklifler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGecmisTeklifler.Size = new System.Drawing.Size(305, 150);
            this.dgvGecmisTeklifler.TabIndex = 5;
            this.dgvGecmisTeklifler.Visible = false;
            // 
            // txtKg
            // 
            this.txtKg.Location = new System.Drawing.Point(374, 25);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(100, 20);
            this.txtKg.TabIndex = 6;
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnUrunEkle.Location = new System.Drawing.Point(523, 21);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(100, 28);
            this.btnUrunEkle.TabIndex = 7;
            this.btnUrunEkle.Text = "Ürün Girişi";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.Location = new System.Drawing.Point(1106, 144);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(100, 28);
            this.btnUrunSil.TabIndex = 9;
            this.btnUrunSil.Text = "Ürün Sil";
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(1106, 190);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(100, 28);
            this.btnPdf.TabIndex = 11;
            this.btnPdf.Text = "PDF Çıktısı";
            // 
            // pnlDetay
            // 
            this.pnlDetay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetay.Controls.Add(this.lblDetay);
            this.pnlDetay.Location = new System.Drawing.Point(323, 280);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(189, 150);
            this.pnlDetay.TabIndex = 0;
            this.pnlDetay.Visible = false;
            // 
            // lblDetay
            // 
            this.lblDetay.Location = new System.Drawing.Point(8, 14);
            this.lblDetay.Name = "lblDetay";
            this.lblDetay.Size = new System.Drawing.Size(168, 122);
            this.lblDetay.TabIndex = 0;
            this.lblDetay.Text = "Geçmiş Teklif Detayı";
            // 
            // lbldolar
            // 
            this.lbldolar.Location = new System.Drawing.Point(817, 81);
            this.lbldolar.Name = "lbldolar";
            this.lbldolar.Size = new System.Drawing.Size(100, 38);
            this.lbldolar.TabIndex = 0;
            this.lbldolar.Text = "Dolar Kuru giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(819, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Maliyet Giriniz";
            // 
            // txtdolar
            // 
            this.txtdolar.Location = new System.Drawing.Point(920, 81);
            this.txtdolar.Name = "txtdolar";
            this.txtdolar.Size = new System.Drawing.Size(100, 20);
            this.txtdolar.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "LME Fiyatı Giriniz";
            // 
            // txtLME
            // 
            this.txtLME.Location = new System.Drawing.Point(920, 23);
            this.txtLME.Name = "txtLME";
            this.txtLME.Size = new System.Drawing.Size(100, 20);
            this.txtLME.TabIndex = 2;
            // 
            // txtMaliyet
            // 
            this.txtMaliyet.Location = new System.Drawing.Point(920, 55);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.Size = new System.Drawing.Size(100, 20);
            this.txtMaliyet.TabIndex = 3;
            // 
            // btnTeklifKaydet
            // 
            this.btnTeklifKaydet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTeklifKaydet.Location = new System.Drawing.Point(1056, 36);
            this.btnTeklifKaydet.Name = "btnTeklifKaydet";
            this.btnTeklifKaydet.Size = new System.Drawing.Size(100, 25);
            this.btnTeklifKaydet.TabIndex = 4;
            this.btnTeklifKaydet.Text = "Teklife Başla";
            this.btnTeklifKaydet.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // lblSecilenMusteri
            // 
            this.lblSecilenMusteri.Location = new System.Drawing.Point(24, 242);
            this.lblSecilenMusteri.Name = "lblSecilenMusteri";
            this.lblSecilenMusteri.Size = new System.Drawing.Size(300, 25);
            this.lblSecilenMusteri.TabIndex = 1;
            // 
            // btnGecmisTeklifler
            // 
            this.btnGecmisTeklifler.Location = new System.Drawing.Point(632, 20);
            this.btnGecmisTeklifler.Name = "btnGecmisTeklifler";
            this.btnGecmisTeklifler.Size = new System.Drawing.Size(150, 30);
            this.btnGecmisTeklifler.TabIndex = 3;
            this.btnGecmisTeklifler.Text = "Geçmiş Teklifleri Gör";
            // 
            // txtMusteriAra
            // 
            this.txtMusteriAra.Location = new System.Drawing.Point(543, 97);
            this.txtMusteriAra.Name = "txtMusteriAra";
            this.txtMusteriAra.Size = new System.Drawing.Size(100, 20);
            this.txtMusteriAra.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Müşteri Arama";
            // 
            // btnMusteriAra
            // 
            this.btnMusteriAra.Location = new System.Drawing.Point(654, 94);
            this.btnMusteriAra.Name = "btnMusteriAra";
            this.btnMusteriAra.Size = new System.Drawing.Size(100, 25);
            this.btnMusteriAra.TabIndex = 15;
            this.btnMusteriAra.Text = "Müşteri Ara";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(1167, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.IndianRed;
            this.label15.Location = new System.Drawing.Point(613, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Müşteriye Tıklayıp Seç Tuşuna Basınız";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(817, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 38);
            this.label6.TabIndex = 26;
            this.label6.Text = "Kar Marjı Giriniz";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(920, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 27;
            // 
            // galvanizteklif
            // 
            this.ClientSize = new System.Drawing.Size(1263, 744);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnMusteriAra);
            this.Controls.Add(this.lbldolar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMusteriAra);
            this.Controls.Add(this.txtdolar);
            this.Controls.Add(this.lblSecilenMusteri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMusteriler);
            this.Controls.Add(this.txtLME);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.txtMaliyet);
            this.Controls.Add(this.btnTeklifKaydet);
            this.Controls.Add(this.btnGecmisTeklifler);
            this.Controls.Add(this.pnlTeklif);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "galvanizteklif";
            this.Text = "Teklif Oluştur";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.pnlTeklif.ResumeLayout(false);
            this.pnlTeklif.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGecmisTeklifler)).EndInit();
            this.pnlDetay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private TextBox txtMusteriAra;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button btnMusteriAra;





        private Label label4;
        private Label label5;
        private Label label12;
        private Label label11;
        private Label label13;
        private Label label15;
        private Label label16;
        private Label label6;
        private TextBox textBox1;
        private Button btnHesapla;
        private Label lblKumulatif;
        private Label lblKumulatifkarli;
        private Button btnKarli;
        private PictureBox pictureBox1;
    }
}
