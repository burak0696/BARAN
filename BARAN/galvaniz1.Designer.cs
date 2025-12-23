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
        private System.Windows.Forms.Button btnUrunDuzenle;
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
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.btnIleri = new System.Windows.Forms.Button();
            this.pnlTeklif = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.colKaplama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonbasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUrunKaydet = new System.Windows.Forms.Button();
            this.cmbKaplama = new System.Windows.Forms.ComboBox();
            this.dgvGecmisTeklifler = new System.Windows.Forms.DataGridView();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunDuzenle = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.pnlTeklif.SuspendLayout();
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
            this.btnIleri.Click += new System.EventHandler(this.btnIleri_Click);
            // 
            // pnlTeklif
            // 
            this.pnlTeklif.Controls.Add(this.button2);
            this.pnlTeklif.Controls.Add(this.label10);
            this.pnlTeklif.Controls.Add(this.label7);
            this.pnlTeklif.Controls.Add(this.label19);
            this.pnlTeklif.Controls.Add(this.label14);
            this.pnlTeklif.Controls.Add(this.label13);
            this.pnlTeklif.Controls.Add(this.button1);
            this.pnlTeklif.Controls.Add(this.label12);
            this.pnlTeklif.Controls.Add(this.label8);
            this.pnlTeklif.Controls.Add(this.label6);
            this.pnlTeklif.Controls.Add(this.label5);
            this.pnlTeklif.Controls.Add(this.label4);
            this.pnlTeklif.Controls.Add(this.dgvUrunler);
            this.pnlTeklif.Controls.Add(this.btnUrunKaydet);
            this.pnlTeklif.Controls.Add(this.cmbKaplama);
            this.pnlTeklif.Controls.Add(this.dgvGecmisTeklifler);
            this.pnlTeklif.Controls.Add(this.txtKg);
            this.pnlTeklif.Controls.Add(this.btnUrunEkle);
            this.pnlTeklif.Controls.Add(this.btnUrunSil);
            this.pnlTeklif.Controls.Add(this.btnUrunDuzenle);
            this.pnlTeklif.Controls.Add(this.btnPdf);
            this.pnlTeklif.Controls.Add(this.pnlDetay);
            this.pnlTeklif.Location = new System.Drawing.Point(20, 270);
            this.pnlTeklif.Name = "pnlTeklif";
            this.pnlTeklif.Size = new System.Drawing.Size(1231, 462);
            this.pnlTeklif.TabIndex = 4;
            this.pnlTeklif.Visible = false;
            this.pnlTeklif.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTeklif_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.Location = new System.Drawing.Point(1000, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 30;
            this.button2.Text = "Yeni Teklif";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1076, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "TL";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(943, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "DOLAR";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(731, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 15);
            this.label19.TabIndex = 27;
            this.label19.Text = "ORTALAMA TONBAŞI";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.IndianRed;
            this.label14.Location = new System.Drawing.Point(1218, 441);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(629, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "4";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(1106, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 22;
            this.button1.Text = "Teklifi Kaydet";
            this.button1.UseVisualStyleBackColor = false;
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
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(731, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "ORTALAMA TONBAŞI X TON";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(731, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "TOTAL KDV DAHİL";
            this.label6.Click += new System.EventHandler(this.label6_Click);
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKaplama,
            this.colKg,
            this.colTonbasi,
            this.colTl});
            this.dgvUrunler.Location = new System.Drawing.Point(12, 71);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.Size = new System.Drawing.Size(500, 200);
            this.dgvUrunler.TabIndex = 10;
            this.dgvUrunler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunler_CellContentClick);
            // 
            // colKaplama
            // 
            this.colKaplama.HeaderText = "Kaplama";
            this.colKaplama.Name = "colKaplama";
            // 
            // colKg
            // 
            this.colKg.HeaderText = "Kg";
            this.colKg.Name = "colKg";
            // 
            // colTonbasi
            // 
            this.colTonbasi.HeaderText = "Tonbaşı ($)";
            this.colTonbasi.Name = "colTonbasi";
            // 
            // colTl
            // 
            this.colTl.HeaderText = "TL Karşılık";
            this.colTl.Name = "colTl";
            // 
            // btnUrunKaydet
            // 
            this.btnUrunKaydet.BackColor = System.Drawing.Color.Cyan;
            this.btnUrunKaydet.Location = new System.Drawing.Point(523, 192);
            this.btnUrunKaydet.Name = "btnUrunKaydet";
            this.btnUrunKaydet.Size = new System.Drawing.Size(100, 28);
            this.btnUrunKaydet.TabIndex = 0;
            this.btnUrunKaydet.Text = "Ürünleri Kaydet";
            this.btnUrunKaydet.UseVisualStyleBackColor = false;
            this.btnUrunKaydet.Click += new System.EventHandler(this.btnUrunKaydet_Click);
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
            this.dgvGecmisTeklifler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGecmisTeklifler_CellDoubleClick);
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
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.Location = new System.Drawing.Point(523, 72);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(100, 28);
            this.btnUrunSil.TabIndex = 9;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunDuzenle
            // 
            this.btnUrunDuzenle.Location = new System.Drawing.Point(523, 112);
            this.btnUrunDuzenle.Name = "btnUrunDuzenle";
            this.btnUrunDuzenle.Size = new System.Drawing.Size(100, 28);
            this.btnUrunDuzenle.TabIndex = 10;
            this.btnUrunDuzenle.Text = "Düzenle";
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(523, 152);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(100, 28);
            this.btnPdf.TabIndex = 11;
            this.btnPdf.Text = "PDF Çıktısı";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
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
            this.lbldolar.Text = "Dolar Kuru giriniz (virgülle)";
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
            this.btnTeklifKaydet.Click += new System.EventHandler(this.btnTeklifKaydet_Click);
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
            this.btnGecmisTeklifler.Click += new System.EventHandler(this.btnGecmisTeklifler_Click);
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
            this.btnMusteriAra.Click += new System.EventHandler(this.btnMusteriAra_Click);
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
            // galvaniz
            // 
            this.ClientSize = new System.Drawing.Size(1263, 744);
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
            this.Name = "galvaniz";
            this.Text = "Teklif Oluştur";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.pnlTeklif.ResumeLayout(false);
            this.pnlTeklif.PerformLayout();
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
        private Label label8;
        private Label label6;
        private Label label12;
        private Label label11;
        private Label label13;
        private Button button1;
        private Label label14;
        private Label label15;
        private Label label10;
        private Label label7;
        private Label label19;
        private Label label16;
        private Button button2;
        private DataGridViewTextBoxColumn colKaplama;
        private DataGridViewTextBoxColumn colKg;
        private DataGridViewTextBoxColumn colTonbasi;
        private DataGridViewTextBoxColumn colTl;
    }
}