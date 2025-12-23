// FormMain.Designer.cs
namespace BARAN
{
    partial class satinalma
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(satinalma));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageStoklar = new System.Windows.Forms.TabPage();
            this.panelStokTop = new System.Windows.Forms.Panel();
            this.btnStokYenile = new System.Windows.Forms.Button();
            this.btnStokSil = new System.Windows.Forms.Button();
            this.btnStokDuzenle = new System.Windows.Forms.Button();
            this.btnStokEkle = new System.Windows.Forms.Button();
            this.txtStokArama = new System.Windows.Forms.TextBox();
            this.lblStokAra = new System.Windows.Forms.Label();
            this.dgvStoklar = new System.Windows.Forms.DataGridView();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSatinAlma = new System.Windows.Forms.TabPage();
            this.panelSatinTop = new System.Windows.Forms.Panel();
            this.btnSatinKaydet = new System.Windows.Forms.Button();
            this.btnSatinYeni = new System.Windows.Forms.Button();
            this.txtSatinTedarikci = new System.Windows.Forms.TextBox();
            this.lblSatinTedarikci = new System.Windows.Forms.Label();
            this.dtpSatinTarih = new System.Windows.Forms.DateTimePicker();
            this.lblSatinTarih = new System.Windows.Forms.Label();
            this.dgvSatinKalemler = new System.Windows.Forms.DataGridView();
            this.tabPageTalep = new System.Windows.Forms.TabPage();
            this.panelTalepTop = new System.Windows.Forms.Panel();
            this.btnTalepKaydet = new System.Windows.Forms.Button();
            this.btnTalepYeni = new System.Windows.Forms.Button();
            this.txtTalepEden = new System.Windows.Forms.TextBox();
            this.lblTalepEden = new System.Windows.Forms.Label();
            this.dtpTalepTarih = new System.Windows.Forms.DateTimePicker();
            this.lblTalepTarih = new System.Windows.Forms.Label();
            this.dgvTalepler = new System.Windows.Forms.DataGridView();
            this.tabPageFatura = new System.Windows.Forms.TabPage();
            this.panelFaturaTop = new System.Windows.Forms.Panel();
            this.btnFaturaKaydet = new System.Windows.Forms.Button();
            this.btnFaturaYeni = new System.Windows.Forms.Button();
            this.txtFaturaCari = new System.Windows.Forms.TextBox();
            this.lblFaturaCari = new System.Windows.Forms.Label();
            this.dtpFaturaTarih = new System.Windows.Forms.DateTimePicker();
            this.lblFaturaTarih = new System.Windows.Forms.Label();
            this.dgvFaturaKalemler = new System.Windows.Forms.DataGridView();
            this.tabPageSayim = new System.Windows.Forms.TabPage();
            this.panelSayimTop = new System.Windows.Forms.Panel();
            this.btnSayimKaydet = new System.Windows.Forms.Button();
            this.btnSayimYeni = new System.Windows.Forms.Button();
            this.txtSayimArama = new System.Windows.Forms.TextBox();
            this.lblSayimAra = new System.Windows.Forms.Label();
            this.dgvSayim = new System.Windows.Forms.DataGridView();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageStoklar.SuspendLayout();
            this.panelStokTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).BeginInit();
            this.contextMenuGrid.SuspendLayout();
            this.tabPageSatinAlma.SuspendLayout();
            this.panelSatinTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatinKalemler)).BeginInit();
            this.tabPageTalep.SuspendLayout();
            this.panelTalepTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepler)).BeginInit();
            this.tabPageFatura.SuspendLayout();
            this.panelFaturaTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturaKalemler)).BeginInit();
            this.tabPageSayim.SuspendLayout();
            this.panelSayimTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSayim)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageStoklar);
            this.tabControlMain.Controls.Add(this.tabPageSatinAlma);
            this.tabControlMain.Controls.Add(this.tabPageTalep);
            this.tabControlMain.Controls.Add(this.tabPageFatura);
            this.tabControlMain.Controls.Add(this.tabPageSayim);
            this.tabControlMain.Location = new System.Drawing.Point(8, 8);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1200, 700);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageStoklar
            // 
            this.tabPageStoklar.Controls.Add(this.panelStokTop);
            this.tabPageStoklar.Controls.Add(this.dgvStoklar);
            this.tabPageStoklar.Location = new System.Drawing.Point(4, 22);
            this.tabPageStoklar.Name = "tabPageStoklar";
            this.tabPageStoklar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStoklar.Size = new System.Drawing.Size(1192, 674);
            this.tabPageStoklar.TabIndex = 0;
            this.tabPageStoklar.Text = "Stoklar";
            this.tabPageStoklar.UseVisualStyleBackColor = true;
            // 
            // panelStokTop
            // 
            this.panelStokTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStokTop.Controls.Add(this.btnStokYenile);
            this.panelStokTop.Controls.Add(this.btnStokSil);
            this.panelStokTop.Controls.Add(this.btnStokDuzenle);
            this.panelStokTop.Controls.Add(this.btnStokEkle);
            this.panelStokTop.Controls.Add(this.txtStokArama);
            this.panelStokTop.Controls.Add(this.lblStokAra);
            this.panelStokTop.Location = new System.Drawing.Point(9, 9);
            this.panelStokTop.Name = "panelStokTop";
            this.panelStokTop.Size = new System.Drawing.Size(2166, 60);
            this.panelStokTop.TabIndex = 0;
            // 
            // btnStokYenile
            // 
            this.btnStokYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokYenile.Location = new System.Drawing.Point(3016, 15);
            this.btnStokYenile.Name = "btnStokYenile";
            this.btnStokYenile.Size = new System.Drawing.Size(120, 30);
            this.btnStokYenile.TabIndex = 5;
            this.btnStokYenile.Text = "Yenile";
            this.btnStokYenile.UseVisualStyleBackColor = true;
            // 
            // btnStokSil
            // 
            this.btnStokSil.Location = new System.Drawing.Point(270, 15);
            this.btnStokSil.Name = "btnStokSil";
            this.btnStokSil.Size = new System.Drawing.Size(90, 30);
            this.btnStokSil.TabIndex = 4;
            this.btnStokSil.Text = "Sil";
            this.btnStokSil.UseVisualStyleBackColor = true;
            // 
            // btnStokDuzenle
            // 
            this.btnStokDuzenle.Location = new System.Drawing.Point(174, 15);
            this.btnStokDuzenle.Name = "btnStokDuzenle";
            this.btnStokDuzenle.Size = new System.Drawing.Size(90, 30);
            this.btnStokDuzenle.TabIndex = 3;
            this.btnStokDuzenle.Text = "Düzenle";
            this.btnStokDuzenle.UseVisualStyleBackColor = true;
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(78, 15);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(90, 30);
            this.btnStokEkle.TabIndex = 2;
            this.btnStokEkle.Text = "Yeni Ürün";
            this.btnStokEkle.UseVisualStyleBackColor = true;
            // 
            // txtStokArama
            // 
            this.txtStokArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStokArama.Location = new System.Drawing.Point(390, 18);
            this.txtStokArama.Name = "txtStokArama";
            this.txtStokArama.Size = new System.Drawing.Size(2606, 20);
            this.txtStokArama.TabIndex = 1;
            // 
            // lblStokAra
            // 
            this.lblStokAra.AutoSize = true;
            this.lblStokAra.Location = new System.Drawing.Point(6, 22);
            this.lblStokAra.Name = "lblStokAra";
            this.lblStokAra.Size = new System.Drawing.Size(68, 13);
            this.lblStokAra.TabIndex = 0;
            this.lblStokAra.Text = "Barkod / Ara";
            // 
            // dgvStoklar
            // 
            this.dgvStoklar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStoklar.ContextMenuStrip = this.contextMenuGrid;
            this.dgvStoklar.Location = new System.Drawing.Point(9, 75);
            this.dgvStoklar.MultiSelect = false;
            this.dgvStoklar.Name = "dgvStoklar";
            this.dgvStoklar.ReadOnly = true;
            this.dgvStoklar.RowHeadersVisible = false;
            this.dgvStoklar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoklar.Size = new System.Drawing.Size(2166, 1158);
            this.dgvStoklar.TabIndex = 1;
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExport});
            this.contextMenuGrid.Name = "contextMenuGrid";
            this.contextMenuGrid.Size = new System.Drawing.Size(142, 26);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(141, 22);
            this.contextMenuExport.Text = "Excel\'e Aktar";
            // 
            // tabPageSatinAlma
            // 
            this.tabPageSatinAlma.Controls.Add(this.panelSatinTop);
            this.tabPageSatinAlma.Controls.Add(this.dgvSatinKalemler);
            this.tabPageSatinAlma.Location = new System.Drawing.Point(4, 22);
            this.tabPageSatinAlma.Name = "tabPageSatinAlma";
            this.tabPageSatinAlma.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSatinAlma.Size = new System.Drawing.Size(1192, 674);
            this.tabPageSatinAlma.TabIndex = 1;
            this.tabPageSatinAlma.Text = "Satın Alma";
            this.tabPageSatinAlma.UseVisualStyleBackColor = true;
            // 
            // panelSatinTop
            // 
            this.panelSatinTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSatinTop.Controls.Add(this.btnSatinKaydet);
            this.panelSatinTop.Controls.Add(this.btnSatinYeni);
            this.panelSatinTop.Controls.Add(this.txtSatinTedarikci);
            this.panelSatinTop.Controls.Add(this.lblSatinTedarikci);
            this.panelSatinTop.Controls.Add(this.dtpSatinTarih);
            this.panelSatinTop.Controls.Add(this.lblSatinTarih);
            this.panelSatinTop.Location = new System.Drawing.Point(9, 9);
            this.panelSatinTop.Name = "panelSatinTop";
            this.panelSatinTop.Size = new System.Drawing.Size(2166, 60);
            this.panelSatinTop.TabIndex = 0;
            // 
            // btnSatinKaydet
            // 
            this.btnSatinKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSatinKaydet.Location = new System.Drawing.Point(3016, 15);
            this.btnSatinKaydet.Name = "btnSatinKaydet";
            this.btnSatinKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnSatinKaydet.TabIndex = 5;
            this.btnSatinKaydet.Text = "Kaydet";
            this.btnSatinKaydet.UseVisualStyleBackColor = true;
            // 
            // btnSatinYeni
            // 
            this.btnSatinYeni.Location = new System.Drawing.Point(6, 15);
            this.btnSatinYeni.Name = "btnSatinYeni";
            this.btnSatinYeni.Size = new System.Drawing.Size(120, 30);
            this.btnSatinYeni.TabIndex = 4;
            this.btnSatinYeni.Text = "Yeni Satınalma";
            this.btnSatinYeni.UseVisualStyleBackColor = true;
            // 
            // txtSatinTedarikci
            // 
            this.txtSatinTedarikci.Location = new System.Drawing.Point(380, 18);
            this.txtSatinTedarikci.Name = "txtSatinTedarikci";
            this.txtSatinTedarikci.Size = new System.Drawing.Size(400, 20);
            this.txtSatinTedarikci.TabIndex = 3;
            // 
            // lblSatinTedarikci
            // 
            this.lblSatinTedarikci.AutoSize = true;
            this.lblSatinTedarikci.Location = new System.Drawing.Point(270, 21);
            this.lblSatinTedarikci.Name = "lblSatinTedarikci";
            this.lblSatinTedarikci.Size = new System.Drawing.Size(79, 13);
            this.lblSatinTedarikci.TabIndex = 2;
            this.lblSatinTedarikci.Text = "Tedarikçi Firma";
            // 
            // dtpSatinTarih
            // 
            this.dtpSatinTarih.Location = new System.Drawing.Point(127, 18);
            this.dtpSatinTarih.Name = "dtpSatinTarih";
            this.dtpSatinTarih.Size = new System.Drawing.Size(130, 20);
            this.dtpSatinTarih.TabIndex = 1;
            // 
            // lblSatinTarih
            // 
            this.lblSatinTarih.AutoSize = true;
            this.lblSatinTarih.Location = new System.Drawing.Point(6, 21);
            this.lblSatinTarih.Name = "lblSatinTarih";
            this.lblSatinTarih.Size = new System.Drawing.Size(31, 13);
            this.lblSatinTarih.TabIndex = 0;
            this.lblSatinTarih.Text = "Tarih";
            // 
            // dgvSatinKalemler
            // 
            this.dgvSatinKalemler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSatinKalemler.ContextMenuStrip = this.contextMenuGrid;
            this.dgvSatinKalemler.Location = new System.Drawing.Point(9, 75);
            this.dgvSatinKalemler.MultiSelect = false;
            this.dgvSatinKalemler.Name = "dgvSatinKalemler";
            this.dgvSatinKalemler.RowHeadersVisible = false;
            this.dgvSatinKalemler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatinKalemler.Size = new System.Drawing.Size(2166, 1158);
            this.dgvSatinKalemler.TabIndex = 1;
            // 
            // tabPageTalep
            // 
            this.tabPageTalep.Controls.Add(this.panelTalepTop);
            this.tabPageTalep.Controls.Add(this.dgvTalepler);
            this.tabPageTalep.Location = new System.Drawing.Point(4, 22);
            this.tabPageTalep.Name = "tabPageTalep";
            this.tabPageTalep.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTalep.Size = new System.Drawing.Size(1192, 674);
            this.tabPageTalep.TabIndex = 2;
            this.tabPageTalep.Text = "Talep";
            this.tabPageTalep.UseVisualStyleBackColor = true;
            // 
            // panelTalepTop
            // 
            this.panelTalepTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTalepTop.Controls.Add(this.btnTalepKaydet);
            this.panelTalepTop.Controls.Add(this.btnTalepYeni);
            this.panelTalepTop.Controls.Add(this.txtTalepEden);
            this.panelTalepTop.Controls.Add(this.lblTalepEden);
            this.panelTalepTop.Controls.Add(this.dtpTalepTarih);
            this.panelTalepTop.Controls.Add(this.lblTalepTarih);
            this.panelTalepTop.Location = new System.Drawing.Point(9, 9);
            this.panelTalepTop.Name = "panelTalepTop";
            this.panelTalepTop.Size = new System.Drawing.Size(2166, 60);
            this.panelTalepTop.TabIndex = 0;
            // 
            // btnTalepKaydet
            // 
            this.btnTalepKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTalepKaydet.Location = new System.Drawing.Point(3016, 15);
            this.btnTalepKaydet.Name = "btnTalepKaydet";
            this.btnTalepKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnTalepKaydet.TabIndex = 5;
            this.btnTalepKaydet.Text = "Kaydet";
            this.btnTalepKaydet.UseVisualStyleBackColor = true;
            // 
            // btnTalepYeni
            // 
            this.btnTalepYeni.Location = new System.Drawing.Point(6, 15);
            this.btnTalepYeni.Name = "btnTalepYeni";
            this.btnTalepYeni.Size = new System.Drawing.Size(120, 30);
            this.btnTalepYeni.TabIndex = 4;
            this.btnTalepYeni.Text = "Yeni Talep";
            this.btnTalepYeni.UseVisualStyleBackColor = true;
            // 
            // txtTalepEden
            // 
            this.txtTalepEden.Location = new System.Drawing.Point(380, 18);
            this.txtTalepEden.Name = "txtTalepEden";
            this.txtTalepEden.Size = new System.Drawing.Size(400, 20);
            this.txtTalepEden.TabIndex = 3;
            // 
            // lblTalepEden
            // 
            this.lblTalepEden.AutoSize = true;
            this.lblTalepEden.Location = new System.Drawing.Point(270, 21);
            this.lblTalepEden.Name = "lblTalepEden";
            this.lblTalepEden.Size = new System.Drawing.Size(62, 13);
            this.lblTalepEden.TabIndex = 2;
            this.lblTalepEden.Text = "Talep Eden";
            // 
            // dtpTalepTarih
            // 
            this.dtpTalepTarih.Location = new System.Drawing.Point(127, 18);
            this.dtpTalepTarih.Name = "dtpTalepTarih";
            this.dtpTalepTarih.Size = new System.Drawing.Size(130, 20);
            this.dtpTalepTarih.TabIndex = 1;
            // 
            // lblTalepTarih
            // 
            this.lblTalepTarih.AutoSize = true;
            this.lblTalepTarih.Location = new System.Drawing.Point(6, 21);
            this.lblTalepTarih.Name = "lblTalepTarih";
            this.lblTalepTarih.Size = new System.Drawing.Size(31, 13);
            this.lblTalepTarih.TabIndex = 0;
            this.lblTalepTarih.Text = "Tarih";
            // 
            // dgvTalepler
            // 
            this.dgvTalepler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTalepler.ContextMenuStrip = this.contextMenuGrid;
            this.dgvTalepler.Location = new System.Drawing.Point(9, 75);
            this.dgvTalepler.MultiSelect = false;
            this.dgvTalepler.Name = "dgvTalepler";
            this.dgvTalepler.RowHeadersVisible = false;
            this.dgvTalepler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTalepler.Size = new System.Drawing.Size(2166, 1158);
            this.dgvTalepler.TabIndex = 1;
            // 
            // tabPageFatura
            // 
            this.tabPageFatura.Controls.Add(this.panelFaturaTop);
            this.tabPageFatura.Controls.Add(this.dgvFaturaKalemler);
            this.tabPageFatura.Location = new System.Drawing.Point(4, 22);
            this.tabPageFatura.Name = "tabPageFatura";
            this.tabPageFatura.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFatura.Size = new System.Drawing.Size(1192, 674);
            this.tabPageFatura.TabIndex = 3;
            this.tabPageFatura.Text = "Fatura";
            this.tabPageFatura.UseVisualStyleBackColor = true;
            // 
            // panelFaturaTop
            // 
            this.panelFaturaTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFaturaTop.Controls.Add(this.btnFaturaKaydet);
            this.panelFaturaTop.Controls.Add(this.btnFaturaYeni);
            this.panelFaturaTop.Controls.Add(this.txtFaturaCari);
            this.panelFaturaTop.Controls.Add(this.lblFaturaCari);
            this.panelFaturaTop.Controls.Add(this.dtpFaturaTarih);
            this.panelFaturaTop.Controls.Add(this.lblFaturaTarih);
            this.panelFaturaTop.Location = new System.Drawing.Point(9, 9);
            this.panelFaturaTop.Name = "panelFaturaTop";
            this.panelFaturaTop.Size = new System.Drawing.Size(2166, 60);
            this.panelFaturaTop.TabIndex = 0;
            // 
            // btnFaturaKaydet
            // 
            this.btnFaturaKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaturaKaydet.Location = new System.Drawing.Point(3016, 15);
            this.btnFaturaKaydet.Name = "btnFaturaKaydet";
            this.btnFaturaKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnFaturaKaydet.TabIndex = 5;
            this.btnFaturaKaydet.Text = "Kaydet";
            this.btnFaturaKaydet.UseVisualStyleBackColor = true;
            // 
            // btnFaturaYeni
            // 
            this.btnFaturaYeni.Location = new System.Drawing.Point(6, 15);
            this.btnFaturaYeni.Name = "btnFaturaYeni";
            this.btnFaturaYeni.Size = new System.Drawing.Size(120, 30);
            this.btnFaturaYeni.TabIndex = 4;
            this.btnFaturaYeni.Text = "Yeni Fatura";
            this.btnFaturaYeni.UseVisualStyleBackColor = true;
            // 
            // txtFaturaCari
            // 
            this.txtFaturaCari.Location = new System.Drawing.Point(380, 18);
            this.txtFaturaCari.Name = "txtFaturaCari";
            this.txtFaturaCari.Size = new System.Drawing.Size(400, 20);
            this.txtFaturaCari.TabIndex = 3;
            // 
            // lblFaturaCari
            // 
            this.lblFaturaCari.AutoSize = true;
            this.lblFaturaCari.Location = new System.Drawing.Point(270, 21);
            this.lblFaturaCari.Name = "lblFaturaCari";
            this.lblFaturaCari.Size = new System.Drawing.Size(25, 13);
            this.lblFaturaCari.TabIndex = 2;
            this.lblFaturaCari.Text = "Cari";
            // 
            // dtpFaturaTarih
            // 
            this.dtpFaturaTarih.Location = new System.Drawing.Point(127, 18);
            this.dtpFaturaTarih.Name = "dtpFaturaTarih";
            this.dtpFaturaTarih.Size = new System.Drawing.Size(130, 20);
            this.dtpFaturaTarih.TabIndex = 1;
            // 
            // lblFaturaTarih
            // 
            this.lblFaturaTarih.AutoSize = true;
            this.lblFaturaTarih.Location = new System.Drawing.Point(6, 21);
            this.lblFaturaTarih.Name = "lblFaturaTarih";
            this.lblFaturaTarih.Size = new System.Drawing.Size(31, 13);
            this.lblFaturaTarih.TabIndex = 0;
            this.lblFaturaTarih.Text = "Tarih";
            // 
            // dgvFaturaKalemler
            // 
            this.dgvFaturaKalemler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaturaKalemler.ContextMenuStrip = this.contextMenuGrid;
            this.dgvFaturaKalemler.Location = new System.Drawing.Point(9, 75);
            this.dgvFaturaKalemler.MultiSelect = false;
            this.dgvFaturaKalemler.Name = "dgvFaturaKalemler";
            this.dgvFaturaKalemler.RowHeadersVisible = false;
            this.dgvFaturaKalemler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaturaKalemler.Size = new System.Drawing.Size(2166, 1158);
            this.dgvFaturaKalemler.TabIndex = 1;
            // 
            // tabPageSayim
            // 
            this.tabPageSayim.Controls.Add(this.panelSayimTop);
            this.tabPageSayim.Controls.Add(this.dgvSayim);
            this.tabPageSayim.Location = new System.Drawing.Point(4, 22);
            this.tabPageSayim.Name = "tabPageSayim";
            this.tabPageSayim.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSayim.Size = new System.Drawing.Size(1192, 674);
            this.tabPageSayim.TabIndex = 4;
            this.tabPageSayim.Text = "Sayım";
            this.tabPageSayim.UseVisualStyleBackColor = true;
            // 
            // panelSayimTop
            // 
            this.panelSayimTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSayimTop.Controls.Add(this.btnSayimKaydet);
            this.panelSayimTop.Controls.Add(this.btnSayimYeni);
            this.panelSayimTop.Controls.Add(this.txtSayimArama);
            this.panelSayimTop.Controls.Add(this.lblSayimAra);
            this.panelSayimTop.Location = new System.Drawing.Point(9, 9);
            this.panelSayimTop.Name = "panelSayimTop";
            this.panelSayimTop.Size = new System.Drawing.Size(2166, 60);
            this.panelSayimTop.TabIndex = 0;
            // 
            // btnSayimKaydet
            // 
            this.btnSayimKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSayimKaydet.Location = new System.Drawing.Point(3016, 15);
            this.btnSayimKaydet.Name = "btnSayimKaydet";
            this.btnSayimKaydet.Size = new System.Drawing.Size(120, 30);
            this.btnSayimKaydet.TabIndex = 3;
            this.btnSayimKaydet.Text = "Kaydet";
            this.btnSayimKaydet.UseVisualStyleBackColor = true;
            // 
            // btnSayimYeni
            // 
            this.btnSayimYeni.Location = new System.Drawing.Point(6, 15);
            this.btnSayimYeni.Name = "btnSayimYeni";
            this.btnSayimYeni.Size = new System.Drawing.Size(120, 30);
            this.btnSayimYeni.TabIndex = 2;
            this.btnSayimYeni.Text = "Yeni Sayım";
            this.btnSayimYeni.UseVisualStyleBackColor = true;
            // 
            // txtSayimArama
            // 
            this.txtSayimArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSayimArama.Location = new System.Drawing.Point(150, 18);
            this.txtSayimArama.Name = "txtSayimArama";
            this.txtSayimArama.Size = new System.Drawing.Size(2854, 20);
            this.txtSayimArama.TabIndex = 1;
            // 
            // lblSayimAra
            // 
            this.lblSayimAra.AutoSize = true;
            this.lblSayimAra.Location = new System.Drawing.Point(132, 21);
            this.lblSayimAra.Name = "lblSayimAra";
            this.lblSayimAra.Size = new System.Drawing.Size(9, 13);
            this.lblSayimAra.TabIndex = 0;
            this.lblSayimAra.Text = "|";
            // 
            // dgvSayim
            // 
            this.dgvSayim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSayim.ContextMenuStrip = this.contextMenuGrid;
            this.dgvSayim.Location = new System.Drawing.Point(9, 75);
            this.dgvSayim.MultiSelect = false;
            this.dgvSayim.Name = "dgvSayim";
            this.dgvSayim.RowHeadersVisible = false;
            this.dgvSayim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSayim.Size = new System.Drawing.Size(2166, 1158);
            this.dgvSayim.TabIndex = 1;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo});
            this.statusStripMain.Location = new System.Drawing.Point(0, 711);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1216, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // satinalma
            // 
            this.ClientSize = new System.Drawing.Size(1216, 733);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "satinalma";
            this.Text = "Stok Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControlMain.ResumeLayout(false);
            this.tabPageStoklar.ResumeLayout(false);
            this.panelStokTop.ResumeLayout(false);
            this.panelStokTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).EndInit();
            this.contextMenuGrid.ResumeLayout(false);
            this.tabPageSatinAlma.ResumeLayout(false);
            this.panelSatinTop.ResumeLayout(false);
            this.panelSatinTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatinKalemler)).EndInit();
            this.tabPageTalep.ResumeLayout(false);
            this.panelTalepTop.ResumeLayout(false);
            this.panelTalepTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepler)).EndInit();
            this.tabPageFatura.ResumeLayout(false);
            this.panelFaturaTop.ResumeLayout(false);
            this.panelFaturaTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturaKalemler)).EndInit();
            this.tabPageSayim.ResumeLayout(false);
            this.panelSayimTop.ResumeLayout(false);
            this.panelSayimTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSayim)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageStoklar;
        private System.Windows.Forms.TabPage tabPageSatinAlma;
        private System.Windows.Forms.TabPage tabPageTalep;
        private System.Windows.Forms.TabPage tabPageFatura;
        private System.Windows.Forms.TabPage tabPageSayim;
        private System.Windows.Forms.Panel panelStokTop;
        private System.Windows.Forms.Button btnStokEkle;
        private System.Windows.Forms.TextBox txtStokArama;
        private System.Windows.Forms.Label lblStokAra;
        private System.Windows.Forms.DataGridView dgvStoklar;
        private System.Windows.Forms.Button btnStokDuzenle;
        private System.Windows.Forms.Button btnStokSil;
        private System.Windows.Forms.Button btnStokYenile;
        private System.Windows.Forms.Panel panelSatinTop;
        private System.Windows.Forms.Button btnSatinYeni;
        private System.Windows.Forms.TextBox txtSatinTedarikci;
        private System.Windows.Forms.Label lblSatinTedarikci;
        private System.Windows.Forms.DateTimePicker dtpSatinTarih;
        private System.Windows.Forms.Label lblSatinTarih;
        private System.Windows.Forms.DataGridView dgvSatinKalemler;
        private System.Windows.Forms.Button btnSatinKaydet;
        private System.Windows.Forms.Panel panelTalepTop;
        private System.Windows.Forms.Button btnTalepYeni;
        private System.Windows.Forms.TextBox txtTalepEden;
        private System.Windows.Forms.Label lblTalepEden;
        private System.Windows.Forms.DateTimePicker dtpTalepTarih;
        private System.Windows.Forms.Label lblTalepTarih;
        private System.Windows.Forms.DataGridView dgvTalepler;
        private System.Windows.Forms.Button btnTalepKaydet;
        private System.Windows.Forms.Panel panelFaturaTop;
        private System.Windows.Forms.Button btnFaturaYeni;
        private System.Windows.Forms.TextBox txtFaturaCari;
        private System.Windows.Forms.Label lblFaturaCari;
        private System.Windows.Forms.DateTimePicker dtpFaturaTarih;
        private System.Windows.Forms.Label lblFaturaTarih;
        private System.Windows.Forms.DataGridView dgvFaturaKalemler;
        private System.Windows.Forms.Button btnFaturaKaydet;
        private System.Windows.Forms.Panel panelSayimTop;
        private System.Windows.Forms.Button btnSayimYeni;
        private System.Windows.Forms.TextBox txtSayimArama;
        private System.Windows.Forms.Label lblSayimAra;
        private System.Windows.Forms.DataGridView dgvSayim;
        private System.Windows.Forms.Button btnSayimKaydet;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
    }
}