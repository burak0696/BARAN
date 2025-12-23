namespace BARAN
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCardUrun = new System.Windows.Forms.Button();
            this.btnCardMusteri = new System.Windows.Forms.Button();
            this.btnCardGalvaniz = new System.Windows.Forms.Button();
            this.btnCardSarf = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlSidebar.Controls.Add(this.btnCikis);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 600);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Firebrick;
            this.btnCikis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(0, 550);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(220, 50);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(220, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::BARAN.Properties.Resources.Adsız_tasarım__4_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 100);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(780, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(112, 30);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Ana Menü";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContainer.Controls.Add(this.flowLayoutPanel1);
            this.pnlContainer.Controls.Add(this.pnlFooter);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(220, 60);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContainer.Size = new System.Drawing.Size(780, 540);
            this.pnlContainer.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCardUrun);
            this.flowLayoutPanel1.Controls.Add(this.btnCardMusteri);
            this.flowLayoutPanel1.Controls.Add(this.btnCardGalvaniz);
            this.flowLayoutPanel1.Controls.Add(this.btnCardSarf);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(740, 460);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCardUrun
            // 
            this.btnCardUrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCardUrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardUrun.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCardUrun.ForeColor = System.Drawing.Color.White;
            this.btnCardUrun.Location = new System.Drawing.Point(10, 10);
            this.btnCardUrun.Margin = new System.Windows.Forms.Padding(10);
            this.btnCardUrun.Name = "btnCardUrun";
            this.btnCardUrun.Size = new System.Drawing.Size(300, 89);
            this.btnCardUrun.TabIndex = 0;
            this.btnCardUrun.Text = "🔍\r\nÜRÜN ARAMA";
            this.btnCardUrun.UseVisualStyleBackColor = false;
            this.btnCardUrun.Click += new System.EventHandler(this.btnUrunAra_Click);
            // 
            // btnCardMusteri
            // 
            this.btnCardMusteri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCardMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardMusteri.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCardMusteri.ForeColor = System.Drawing.Color.White;
            this.btnCardMusteri.Location = new System.Drawing.Point(330, 10);
            this.btnCardMusteri.Margin = new System.Windows.Forms.Padding(10);
            this.btnCardMusteri.Name = "btnCardMusteri";
            this.btnCardMusteri.Size = new System.Drawing.Size(300, 89);
            this.btnCardMusteri.TabIndex = 1;
            this.btnCardMusteri.Text = "👥\r\nMÜŞTERİ PANELİ";
            this.btnCardMusteri.UseVisualStyleBackColor = false;
            this.btnCardMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnCardGalvaniz
            // 
            this.btnCardGalvaniz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCardGalvaniz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardGalvaniz.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCardGalvaniz.ForeColor = System.Drawing.Color.White;
            this.btnCardGalvaniz.Location = new System.Drawing.Point(10, 119);
            this.btnCardGalvaniz.Margin = new System.Windows.Forms.Padding(10);
            this.btnCardGalvaniz.Name = "btnCardGalvaniz";
            this.btnCardGalvaniz.Size = new System.Drawing.Size(300, 86);
            this.btnCardGalvaniz.TabIndex = 2;
            this.btnCardGalvaniz.Text = "🏭\r\nGALVANİZ";
            this.btnCardGalvaniz.UseVisualStyleBackColor = false;
            this.btnCardGalvaniz.Click += new System.EventHandler(this.btnGalvaniz2_Click);
            // 
            // btnCardSarf
            // 
            this.btnCardSarf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnCardSarf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardSarf.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCardSarf.ForeColor = System.Drawing.Color.White;
            this.btnCardSarf.Location = new System.Drawing.Point(330, 119);
            this.btnCardSarf.Margin = new System.Windows.Forms.Padding(10);
            this.btnCardSarf.Name = "btnCardSarf";
            this.btnCardSarf.Size = new System.Drawing.Size(300, 86);
            this.btnCardSarf.TabIndex = 3;
            this.btnCardSarf.Text = "📦\r\nSATIN ALMA (SARF)";
            this.btnCardSarf.UseVisualStyleBackColor = false;
            this.btnCardSarf.Click += new System.EventHandler(this.btnSatinalma_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(20, 480);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(740, 40);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(740, 40);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "© 2025 Baran Çelik ve Galvaniz San. Tic. A.Ş.";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(10, 225);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 86);
            this.button1.TabIndex = 4;
            this.button1.Text = "✉\r\nTEKLİF";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(330, 225);
            this.button2.Margin = new System.Windows.Forms.Padding(10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 86);
            this.button2.TabIndex = 5;
            this.button2.Text = "✓\r\nBAKIM / ONARIM";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gainsboro;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(10, 331);
            this.button3.Margin = new System.Windows.Forms.Padding(10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(300, 86);
            this.button3.TabIndex = 6;
            this.button3.Text = "✉\rSİPARİŞ";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkSalmon;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(330, 331);
            this.button4.Margin = new System.Windows.Forms.Padding(10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(300, 86);
            this.button4.TabIndex = 7;
            this.button4.Text = "🏭\r\nÜRETİM\r\n";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BARAN ÇELİK VE GALVANİZ SANAYİ LİMİTED ŞİRKETİ";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCardUrun;
        private System.Windows.Forms.Button btnCardMusteri;
        private System.Windows.Forms.Button btnCardGalvaniz;
        private System.Windows.Forms.Button btnCardSarf;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}