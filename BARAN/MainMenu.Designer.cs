using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BARAN
{

    partial class MainMenu
    {
        private System.Windows.Forms.Button btnGalvaniz;
        public MainMenu(string user) : base() // <-- "this()" yerine "base()" kullanın
        {
            // use user (e.g. set label)
            InitializeComponent();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// Bu sürüm: iki sekme (TabPage) içeren TabControl ekler. Butonlara tıklayınca sekmeler arasında geçiş yapar.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnUrunAra = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnGalvaniz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUrunAra
            // 
            this.btnUrunAra.Location = new System.Drawing.Point(12, 13);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(149, 59);
            this.btnUrunAra.TabIndex = 0;
            this.btnUrunAra.Text = "Ürünler";
            this.btnUrunAra.UseVisualStyleBackColor = true;
            this.btnUrunAra.Click += new System.EventHandler(this.btnUrunAra_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Location = new System.Drawing.Point(167, 13);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(149, 59);
            this.btnMusteri.TabIndex = 1;
            this.btnMusteri.Text = "Müşteri Paneli";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnGalvaniz
            // 
            this.btnGalvaniz.Location = new System.Drawing.Point(322, 13);
            this.btnGalvaniz.Name = "btnGalvaniz";
            this.btnGalvaniz.Size = new System.Drawing.Size(149, 59);
            this.btnGalvaniz.TabIndex = 3;
            this.btnGalvaniz.Text = "Galvaniz Paneli";
            this.btnGalvaniz.UseVisualStyleBackColor = true;
            this.btnGalvaniz.Click += new System.EventHandler(this.btnGalvaniz_Click);

            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGalvaniz);
            this.Controls.Add(this.btnUrunAra);
            this.Controls.Add(this.btnMusteri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "BARAN ÇELİK VE GALVANİZ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUrunAra;
        private System.Windows.Forms.Button btnMusteri;

        // Buton click olayları: sekmeler arası geçiş yapar.
   
    }
}