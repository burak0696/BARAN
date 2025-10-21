using System;
using System.Windows.Forms;

namespace BARAN
{
    public partial class ProductDetails : Form
    {
        public ProductDetails(string design, string sector, string productType, string structureType,
                              string voltage, string foundation, string tower, string height,
                              string rev, string urunKodu)
        {
            InitializeComponent();

            // Dinamik konum ayarları
            int lblX = 20, lblY = 20, lblGap = 30;
            int txtX = 120, txtWidth = 200;

            lblDesign.Top = lblY; lblDesign.Left = lblX; txtDesign.Top = lblY; txtDesign.Left = txtX; txtDesign.Width = txtWidth;
            lblSector.Top = lblY + lblGap; lblSector.Left = lblX; txtSector.Top = lblY + lblGap; txtSector.Left = txtX; txtSector.Width = txtWidth;
            lblProductType.Top = lblY + lblGap * 2; lblProductType.Left = lblX; txtProductType.Top = lblY + lblGap * 2; txtProductType.Left = txtX; txtProductType.Width = txtWidth;
            lblStructureType.Top = lblY + lblGap * 3; lblStructureType.Left = lblX; txtStructureType.Top = lblY + lblGap * 3; txtStructureType.Left = txtX; txtStructureType.Width = txtWidth;
            lblVoltageAyak.Top = lblY + lblGap * 4; lblVoltageAyak.Left = lblX; txtVoltageAyak.Top = lblY + lblGap * 4; txtVoltageAyak.Left = txtX; txtVoltageAyak.Width = txtWidth;
            lblFoundation.Top = lblY + lblGap * 5; lblFoundation.Left = lblX; txtFoundation.Top = lblY + lblGap * 5; txtFoundation.Left = txtX; txtFoundation.Width = txtWidth;
            lblTower.Top = lblY + lblGap * 6; lblTower.Left = lblX; txtTower.Top = lblY + lblGap * 6; txtTower.Left = txtX; txtTower.Width = txtWidth;
            lblHeight.Top = lblY + lblGap * 7; lblHeight.Left = lblX; txtHeight.Top = lblY + lblGap * 7; txtHeight.Left = txtX; txtHeight.Width = txtWidth;
            lblRev.Top = lblY + lblGap * 8; lblRev.Left = lblX; txtRev.Top = lblY + lblGap * 8; txtRev.Left = txtX; txtRev.Width = txtWidth;
            lblUrunKodu.Top = lblY + lblGap * 9; lblUrunKodu.Left = lblX; txtUrunKodu.Top = lblY + lblGap * 9; txtUrunKodu.Left = txtX; txtUrunKodu.Width = txtWidth;

            // Değerleri atama
            txtDesign.Text = design;
            txtSector.Text = sector;
            txtProductType.Text = productType;
            txtStructureType.Text = structureType;
            txtVoltageAyak.Text = voltage;
            txtFoundation.Text = foundation;
            txtTower.Text = tower;
            txtHeight.Text = height;
            txtRev.Text = rev;
            txtUrunKodu.Text = urunKodu;
        }
    }
}
