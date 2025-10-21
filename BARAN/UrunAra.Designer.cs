// UrunAra.Designer.cs
namespace BARAN
{
    partial class UrunAra
    {
        /// <summary> 
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Temizleme işlemleri.
        /// </summary>
        /// <param name="disposing">yönetilen kaynaklar atılsın mı</param>
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
            this.cmbDesign = new System.Windows.Forms.ComboBox();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.cmbStructureType = new System.Windows.Forms.ComboBox();
            this.cmbVoltageAyak = new System.Windows.Forms.ComboBox();
            this.cmbFoundation = new System.Windows.Forms.ComboBox();
            this.cmbTower = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            this.btnUrunGetir = new System.Windows.Forms.Button();
            this.txtTasarimSearch = new System.Windows.Forms.TextBox();
            this.btnTasarimSearch = new System.Windows.Forms.Button();
            this.lblTasarimSearch = new System.Windows.Forms.Label();
            this.lblDesign = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblStructureType = new System.Windows.Forms.Label();
            this.lblVoltageAyak = new System.Windows.Forms.Label();
            this.lblFoundation = new System.Windows.Forms.Label();
            this.lblTower = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDesign
            // 
            this.cmbDesign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesign.FormattingEnabled = true;
            this.cmbDesign.Location = new System.Drawing.Point(20, 32);
            this.cmbDesign.Name = "cmbDesign";
            this.cmbDesign.Size = new System.Drawing.Size(160, 21);
            this.cmbDesign.TabIndex = 10;
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(200, 32);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(160, 21);
            this.cmbSector.TabIndex = 11;
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(380, 32);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(160, 21);
            this.cmbProductType.TabIndex = 12;
            // 
            // cmbStructureType
            // 
            this.cmbStructureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStructureType.FormattingEnabled = true;
            this.cmbStructureType.Location = new System.Drawing.Point(560, 32);
            this.cmbStructureType.Name = "cmbStructureType";
            this.cmbStructureType.Size = new System.Drawing.Size(160, 21);
            this.cmbStructureType.TabIndex = 13;
            // 
            // cmbVoltageAyak
            // 
            this.cmbVoltageAyak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoltageAyak.FormattingEnabled = true;
            this.cmbVoltageAyak.Location = new System.Drawing.Point(740, 32);
            this.cmbVoltageAyak.Name = "cmbVoltageAyak";
            this.cmbVoltageAyak.Size = new System.Drawing.Size(160, 21);
            this.cmbVoltageAyak.TabIndex = 14;
            // 
            // cmbFoundation
            // 
            this.cmbFoundation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFoundation.FormattingEnabled = true;
            this.cmbFoundation.Location = new System.Drawing.Point(920, 32);
            this.cmbFoundation.Name = "cmbFoundation";
            this.cmbFoundation.Size = new System.Drawing.Size(160, 21);
            this.cmbFoundation.TabIndex = 15;
            // 
            // cmbTower
            // 
            this.cmbTower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTower.FormattingEnabled = true;
            this.cmbTower.Location = new System.Drawing.Point(1100, 32);
            this.cmbTower.Name = "cmbTower";
            this.cmbTower.Size = new System.Drawing.Size(160, 21);
            this.cmbTower.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(20, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1660, 426);
            this.dataGridView1.TabIndex = 20;
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.Location = new System.Drawing.Point(20, 560);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(120, 30);
            this.btnYeniUrun.TabIndex = 21;
            this.btnYeniUrun.Text = "Yeni Ürün";
            this.btnYeniUrun.UseVisualStyleBackColor = true;
            // 
            // btnUrunGetir
            // 
            this.btnUrunGetir.Location = new System.Drawing.Point(1364, 26);
            this.btnUrunGetir.Name = "btnUrunGetir";
            this.btnUrunGetir.Size = new System.Drawing.Size(120, 30);
            this.btnUrunGetir.TabIndex = 22;
            this.btnUrunGetir.Text = "Ürün Getir";
            this.btnUrunGetir.UseVisualStyleBackColor = true;
            // 
            // txtTasarimSearch
            // 
            this.txtTasarimSearch.Location = new System.Drawing.Point(269, 566);
            this.txtTasarimSearch.Name = "txtTasarimSearch";
            this.txtTasarimSearch.Size = new System.Drawing.Size(260, 20);
            this.txtTasarimSearch.TabIndex = 31;
            // 
            // btnTasarimSearch
            // 
            this.btnTasarimSearch.Location = new System.Drawing.Point(535, 562);
            this.btnTasarimSearch.Name = "btnTasarimSearch";
            this.btnTasarimSearch.Size = new System.Drawing.Size(120, 26);
            this.btnTasarimSearch.TabIndex = 32;
            this.btnTasarimSearch.Text = "Tasarım Ara";
            this.btnTasarimSearch.UseVisualStyleBackColor = true;
            // 
            // lblTasarimSearch
            // 
            this.lblTasarimSearch.AutoSize = true;
            this.lblTasarimSearch.Location = new System.Drawing.Point(197, 569);
            this.lblTasarimSearch.Name = "lblTasarimSearch";
            this.lblTasarimSearch.Size = new System.Drawing.Size(66, 13);
            this.lblTasarimSearch.TabIndex = 30;
            this.lblTasarimSearch.Text = "Tasarım Ara:";
            // 
            // lblDesign
            // 
            this.lblDesign.AutoSize = true;
            this.lblDesign.Location = new System.Drawing.Point(20, 12);
            this.lblDesign.Name = "lblDesign";
            this.lblDesign.Size = new System.Drawing.Size(86, 13);
            this.lblDesign.TabIndex = 0;
            this.lblDesign.Text = "Tasarım (Design)";
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Location = new System.Drawing.Point(200, 12);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(38, 13);
            this.lblSector.TabIndex = 1;
            this.lblSector.Text = "Sector";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(380, 12);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(71, 13);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Product Type";
            // 
            // lblStructureType
            // 
            this.lblStructureType.AutoSize = true;
            this.lblStructureType.Location = new System.Drawing.Point(560, 12);
            this.lblStructureType.Name = "lblStructureType";
            this.lblStructureType.Size = new System.Drawing.Size(77, 13);
            this.lblStructureType.TabIndex = 3;
            this.lblStructureType.Text = "Structure Type";
            // 
            // lblVoltageAyak
            // 
            this.lblVoltageAyak.AutoSize = true;
            this.lblVoltageAyak.Location = new System.Drawing.Point(740, 12);
            this.lblVoltageAyak.Name = "lblVoltageAyak";
            this.lblVoltageAyak.Size = new System.Drawing.Size(72, 13);
            this.lblVoltageAyak.TabIndex = 4;
            this.lblVoltageAyak.Text = "Voltage/Ayak";
            // 
            // lblFoundation
            // 
            this.lblFoundation.AutoSize = true;
            this.lblFoundation.Location = new System.Drawing.Point(920, 12);
            this.lblFoundation.Name = "lblFoundation";
            this.lblFoundation.Size = new System.Drawing.Size(60, 13);
            this.lblFoundation.TabIndex = 5;
            this.lblFoundation.Text = "Foundation";
            // 
            // lblTower
            // 
            this.lblTower.AutoSize = true;
            this.lblTower.Location = new System.Drawing.Point(1100, 12);
            this.lblTower.Name = "lblTower";
            this.lblTower.Size = new System.Drawing.Size(37, 13);
            this.lblTower.TabIndex = 6;
            this.lblTower.Text = "Tower";
            // 
            // UrunAra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1722, 703);
            this.Controls.Add(this.lblDesign);
            this.Controls.Add(this.cmbDesign);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.cmbSector);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.cmbProductType);
            this.Controls.Add(this.lblStructureType);
            this.Controls.Add(this.cmbStructureType);
            this.Controls.Add(this.lblVoltageAyak);
            this.Controls.Add(this.cmbVoltageAyak);
            this.Controls.Add(this.lblFoundation);
            this.Controls.Add(this.cmbFoundation);
            this.Controls.Add(this.lblTower);
            this.Controls.Add(this.cmbTower);
            this.Controls.Add(this.lblTasarimSearch);
            this.Controls.Add(this.txtTasarimSearch);
            this.Controls.Add(this.btnTasarimSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnYeniUrun);
            this.Controls.Add(this.btnUrunGetir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UrunAra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ara";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDesign;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.ComboBox cmbStructureType;
        private System.Windows.Forms.ComboBox cmbVoltageAyak;
        private System.Windows.Forms.ComboBox cmbFoundation;
        private System.Windows.Forms.ComboBox cmbTower;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnYeniUrun;
        private System.Windows.Forms.Button btnUrunGetir;

        // tasarım arama kontrolleri
        private System.Windows.Forms.Label lblTasarimSearch;
        private System.Windows.Forms.TextBox txtTasarimSearch;
        private System.Windows.Forms.Button btnTasarimSearch;

        private System.Windows.Forms.Label lblDesign;
        private System.Windows.Forms.Label lblSector;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblStructureType;
        private System.Windows.Forms.Label lblVoltageAyak;
        private System.Windows.Forms.Label lblFoundation;
        private System.Windows.Forms.Label lblTower;
    }
}
