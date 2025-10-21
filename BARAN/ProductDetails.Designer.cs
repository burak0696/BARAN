namespace BARAN
{
    partial class ProductDetails
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
            this.lblDesign = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblStructureType = new System.Windows.Forms.Label();
            this.lblVoltageAyak = new System.Windows.Forms.Label();
            this.lblFoundation = new System.Windows.Forms.Label();
            this.lblTower = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblRev = new System.Windows.Forms.Label();
            this.lblUrunKodu = new System.Windows.Forms.Label();

            this.txtDesign = new System.Windows.Forms.TextBox();
            this.txtSector = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtStructureType = new System.Windows.Forms.TextBox();
            this.txtVoltageAyak = new System.Windows.Forms.TextBox();
            this.txtFoundation = new System.Windows.Forms.TextBox();
            this.txtTower = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtRev = new System.Windows.Forms.TextBox();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // Designer otomatik olarak Top/Left ayarlarını yapacak
            this.lblDesign.Text = "Design:";
            this.lblSector.Text = "Sector:";
            this.lblProductType.Text = "Product Type:";
            this.lblStructureType.Text = "Structure Type:";
            this.lblVoltageAyak.Text = "Voltage Ayak:";
            this.lblFoundation.Text = "Foundation:";
            this.lblTower.Text = "Tower:";
            this.lblHeight.Text = "Height:";
            this.lblRev.Text = "Rev:";
            this.lblUrunKodu.Text = "Ürün Kodu:";

            // TextBox ayarları
            this.txtDesign.ReadOnly = true;
            this.txtSector.ReadOnly = true;
            this.txtProductType.ReadOnly = true;
            this.txtStructureType.ReadOnly = true;
            this.txtVoltageAyak.ReadOnly = true;
            this.txtFoundation.ReadOnly = true;
            this.txtTower.ReadOnly = true;
            this.txtHeight.ReadOnly = true;
            this.txtRev.ReadOnly = true;
            this.txtUrunKodu.ReadOnly = true;

            // Form’a kontrolleri ekle
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDesign, lblSector, lblProductType, lblStructureType, lblVoltageAyak, lblFoundation, lblTower, lblHeight, lblRev, lblUrunKodu,
                txtDesign, txtSector, txtProductType, txtStructureType, txtVoltageAyak, txtFoundation, txtTower, txtHeight, txtRev, txtUrunKodu
            });

            this.ClientSize = new System.Drawing.Size(360, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Detayları";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Label ve TextBox alanları
        private System.Windows.Forms.Label lblDesign, lblSector, lblProductType, lblStructureType, lblVoltageAyak, lblFoundation, lblTower, lblHeight, lblRev, lblUrunKodu;
        private System.Windows.Forms.TextBox txtDesign, txtSector, txtProductType, txtStructureType, txtVoltageAyak, txtFoundation, txtTower, txtHeight, txtRev, txtUrunKodu;
    }
}
