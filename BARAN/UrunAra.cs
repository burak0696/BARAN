// UrunAra.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BARAN
{
    public partial class UrunAra : Form
    {
        // SENİN KULLANDIĞIN BAĞLANTI DİZGESİ (sahip olduğun sürümle aynı tutuldı)
        private readonly string ConnStr = @"Server=localhost\SQL;Database=LoginDB;Trusted_Connection=True;";

        public UrunAra()
        {
            InitializeComponent();
            AttachEvents();
            LoadInitialDesigns();
        }

        private void AttachEvents()
        {
            // ComboBox selection events
            cmbDesign.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(1);
                FillComboBox(cmbSector, "Sector", "Design=@d", new SqlParameter("@d", cmbDesign.Text));
            };

            cmbSector.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(2);
                FillComboBox(cmbProductType, "ProductType", "Design=@d AND Sector=@s",
                    new SqlParameter("@d", cmbDesign.Text), new SqlParameter("@s", cmbSector.Text));
            };

            cmbProductType.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(3);
                FillComboBox(cmbStructureType, "StructureType", "Design=@d AND Sector=@s AND ProductType=@p",
                    new SqlParameter("@d", cmbDesign.Text), new SqlParameter("@s", cmbSector.Text), new SqlParameter("@p", cmbProductType.Text));
            };

            cmbStructureType.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(4);
                FillComboBox(cmbVoltageAyak, "VoltageAyak", "Design=@d AND Sector=@s AND ProductType=@p AND StructureType=@st",
                    new SqlParameter("@d", cmbDesign.Text), new SqlParameter("@s", cmbSector.Text), new SqlParameter("@p", cmbProductType.Text), new SqlParameter("@st", cmbStructureType.Text));
            };

            cmbVoltageAyak.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(5);
                FillComboBox(cmbFoundation, "Foundation", "Design=@d AND Sector=@s AND ProductType=@p AND StructureType=@st AND VoltageAyak=@v",
                    new SqlParameter("@d", cmbDesign.Text), new SqlParameter("@s", cmbSector.Text), new SqlParameter("@p", cmbProductType.Text), new SqlParameter("@st", cmbStructureType.Text), new SqlParameter("@v", cmbVoltageAyak.Text));
            };

            cmbFoundation.SelectedIndexChanged += (s, e) =>
            {
                ClearLowerCombos(6);
                FillComboBox(cmbTower, "Tower", "Design=@d AND Sector=@s AND ProductType=@p AND StructureType=@st AND VoltageAyak=@v AND Foundation=@f",
                    new SqlParameter("@d", cmbDesign.Text), new SqlParameter("@s", cmbSector.Text), new SqlParameter("@p", cmbProductType.Text), new SqlParameter("@st", cmbStructureType.Text), new SqlParameter("@v", cmbVoltageAyak.Text), new SqlParameter("@f", cmbFoundation.Text));
            };

            // Buttons
            btnYeniUrun.Click -= BtnYeniUrun_Click;
            btnYeniUrun.Click += BtnYeniUrun_Click;

            btnUrunGetir.Click -= BtnUrunGetir_Click;
            btnUrunGetir.Click += BtnUrunGetir_Click;

            btnTasarimSearch.Click -= BtnTasarimSearch_Click;
            btnTasarimSearch.Click += BtnTasarimSearch_Click;

            txtTasarimSearch.KeyDown -= TxtTasarimSearch_KeyDown;
            txtTasarimSearch.KeyDown += TxtTasarimSearch_KeyDown;

            // DataGrid double-click
            dataGridView1.CellDoubleClick -= DataGridView1_CellDoubleClick;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void TxtTasarimSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTasarimSearch_Click(sender, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Normalize: trim + tüm ara boşlukları sil
        private string NormalizeRemoveSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", "");
        }

        private void BtnTasarimSearch_Click(object sender, EventArgs e)
        {
            string raw = txtTasarimSearch.Text ?? string.Empty;
            string withHyphen = NormalizeRemoveSpaces(raw); // YE H20-1 -> YEH20-1
            if (string.IsNullOrWhiteSpace(withHyphen))
            {
                MessageBox.Show("Arama metni giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string noHyphen = withHyphen.Replace("-", ""); // YEH201 

            PerformTasarimSearch(withHyphen, noHyphen);
        }

        // DB'den distinct design listesi
        private void LoadInitialDesigns()
        {
            FillComboBox(cmbDesign, "Design", null);
        }

        private void FillComboBox(ComboBox combo, string column, string whereClause, params SqlParameter[] parameters)
        {
            combo.Items.Clear();
            string sql = $"SELECT DISTINCT [{column}] FROM dbo.Urun";
            if (!string.IsNullOrWhiteSpace(whereClause)) sql += " WHERE " + whereClause;
            sql += $" ORDER BY [{column}]";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var v = reader[0]?.ToString();
                        if (!string.IsNullOrWhiteSpace(v)) combo.Items.Add(v);
                    }
                }
            }
        }

        private void ClearLowerCombos(int level)
        {
            if (level <= 1)
            {
                cmbSector.Items.Clear(); cmbSector.Text = "";
                cmbProductType.Items.Clear(); cmbProductType.Text = "";
                cmbStructureType.Items.Clear(); cmbStructureType.Text = "";
                cmbVoltageAyak.Items.Clear(); cmbVoltageAyak.Text = "";
                cmbFoundation.Items.Clear(); cmbFoundation.Text = "";
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }
            else if (level == 2)
            {
                cmbProductType.Items.Clear(); cmbProductType.Text = "";
                cmbStructureType.Items.Clear(); cmbStructureType.Text = "";
                cmbVoltageAyak.Items.Clear(); cmbVoltageAyak.Text = "";
                cmbFoundation.Items.Clear(); cmbFoundation.Text = "";
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }
            else if (level == 3)
            {
                cmbStructureType.Items.Clear(); cmbStructureType.Text = "";
                cmbVoltageAyak.Items.Clear(); cmbVoltageAyak.Text = "";
                cmbFoundation.Items.Clear(); cmbFoundation.Text = "";
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }
            else if (level == 4)
            {
                cmbVoltageAyak.Items.Clear(); cmbVoltageAyak.Text = "";
                cmbFoundation.Items.Clear(); cmbFoundation.Text = "";
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }
            else if (level == 5)
            {
                cmbFoundation.Items.Clear(); cmbFoundation.Text = "";
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }
            else if (level == 6)
            {
                cmbTower.Items.Clear(); cmbTower.Text = "";
            }

            dataGridView1.DataSource = null;
        }

        #region DataGrid / Get

        private void BtnUrunGetir_Click(object sender, EventArgs e)
        {
            LoadDataGrid();

            if (dataGridView1.Rows.Count > 0)
            {
                int last = dataGridView1.Rows.Count - 1;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[last].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = last;
            }
        }

        private void LoadDataGrid()
        {
            var whereParts = new System.Collections.Generic.List<string>();
            var pars = new System.Collections.Generic.List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(cmbDesign.Text)) { whereParts.Add("Design=@d"); pars.Add(new SqlParameter("@d", cmbDesign.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbSector.Text)) { whereParts.Add("Sector=@s"); pars.Add(new SqlParameter("@s", cmbSector.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbProductType.Text)) { whereParts.Add("ProductType=@p"); pars.Add(new SqlParameter("@p", cmbProductType.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbStructureType.Text)) { whereParts.Add("StructureType=@st"); pars.Add(new SqlParameter("@st", cmbStructureType.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbVoltageAyak.Text)) { whereParts.Add("VoltageAyak=@v"); pars.Add(new SqlParameter("@v", cmbVoltageAyak.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbFoundation.Text)) { whereParts.Add("Foundation=@f"); pars.Add(new SqlParameter("@f", cmbFoundation.Text)); }
            if (!string.IsNullOrWhiteSpace(cmbTower.Text)) { whereParts.Add("Tower=@t"); pars.Add(new SqlParameter("@t", cmbTower.Text)); }

            string sql = @"SELECT Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower, Height, Rev, Tasarim, UrunKodu
                           FROM dbo.Urun";
            if (whereParts.Count > 0) sql += " WHERE " + string.Join(" AND ", whereParts);
            sql += " ORDER BY Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (pars.Count > 0) cmd.Parameters.AddRange(pars.ToArray());
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                // Header names
                if (dataGridView1.Columns["Design"] != null) dataGridView1.Columns["Design"].HeaderText = "Design";
                if (dataGridView1.Columns["Sector"] != null) dataGridView1.Columns["Sector"].HeaderText = "Sector";
                if (dataGridView1.Columns["ProductType"] != null) dataGridView1.Columns["ProductType"].HeaderText = "Product Type";
                if (dataGridView1.Columns["StructureType"] != null) dataGridView1.Columns["StructureType"].HeaderText = "Structure Type";
                if (dataGridView1.Columns["VoltageAyak"] != null) dataGridView1.Columns["VoltageAyak"].HeaderText = "Voltage/Ayak";
                if (dataGridView1.Columns["Foundation"] != null) dataGridView1.Columns["Foundation"].HeaderText = "Foundation";
                if (dataGridView1.Columns["Tower"] != null) dataGridView1.Columns["Tower"].HeaderText = "Tower";
                if (dataGridView1.Columns["Height"] != null) dataGridView1.Columns["Height"].HeaderText = "Height";
                if (dataGridView1.Columns["Rev"] != null) dataGridView1.Columns["Rev"].HeaderText = "Rev";
                if (dataGridView1.Columns["Tasarim"] != null) dataGridView1.Columns["Tasarim"].HeaderText = "Tasarım";
                if (dataGridView1.Columns["UrunKodu"] != null) dataGridView1.Columns["UrunKodu"].HeaderText = "Ürün Kodu";

                dataGridView1.AutoResizeColumns();
            }
        }

        #endregion

        #region Tasarım Arama

        private void PerformTasarimSearch(string searchWithHyphen, string searchNoHyphen)
        {
            string sql = @"
SELECT Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower, Height, Rev, Tasarim, UrunKodu
FROM dbo.Urun
WHERE
    REPLACE(REPLACE(ISNULL(Tasarim, ''), ' ', ''), '-', '') = @noHyphen
    OR REPLACE(ISNULL(Tasarim, ''), ' ', '') = @withHyphen
    OR ISNULL(Tasarim, '') = @withHyphen
    OR REPLACE(REPLACE(ISNULL(UrunKodu, ''), ' ', ''), '-', '') = @noHyphen
ORDER BY Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower;";

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@withHyphen", System.Data.SqlDbType.NVarChar, 500) { Value = searchWithHyphen });
                    cmd.Parameters.Add(new SqlParameter("@noHyphen", System.Data.SqlDbType.NVarChar, 500) { Value = searchNoHyphen });

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns["Tasarim"] != null) dataGridView1.Columns["Tasarim"].HeaderText = "Tasarım";
                    if (dataGridView1.Columns["UrunKodu"] != null) dataGridView1.Columns["UrunKodu"].HeaderText = "Ürün Kodu";

                    dataGridView1.AutoResizeColumns();

                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Eşleşen kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL hatası (PerformTasarimSearch): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Yeni Ürün / Helpers

        private void BtnYeniUrun_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbDesign.Text)
                    || string.IsNullOrWhiteSpace(cmbSector.Text)
                    || string.IsNullOrWhiteSpace(cmbProductType.Text)
                    || string.IsNullOrWhiteSpace(cmbStructureType.Text)
                    || string.IsNullOrWhiteSpace(cmbVoltageAyak.Text)
                    || string.IsNullOrWhiteSpace(cmbFoundation.Text)
                    || string.IsNullOrWhiteSpace(cmbTower.Text))
                {
                    MessageBox.Show("Lütfen önce tüm kategori seçimlerini yapın (Design → ... → Tower).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string height = ShowInputDialog("Height giriniz:", "Yeni Ürün - Height");
                if (height == null) return;
                if (string.IsNullOrWhiteSpace(height)) { MessageBox.Show("Height boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string rev = ShowInputDialog("Rev giriniz:", "Yeni Ürün - Rev");
                if (rev == null) return;
                if (string.IsNullOrWhiteSpace(rev)) { MessageBox.Show("Rev boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string tasarim = ShowInputDialog("Tasarım giriniz:", "Yeni Ürün - Tasarım");
                if (tasarim == null) return;
                if (string.IsNullOrWhiteSpace(tasarim)) { MessageBox.Show("Tasarım boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string urunKodu = GenerateUrunKodu(cmbDesign.Text, cmbSector.Text, cmbProductType.Text, cmbStructureType.Text,
                                                   cmbVoltageAyak.Text, cmbFoundation.Text, cmbTower.Text, height, rev);

                if (ExistsUrunKodu(urunKodu))
                {
                    MessageBox.Show($"Aynı ürün kodu zaten mevcut: {urunKodu}.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertSql = @"INSERT INTO dbo.Urun (Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower, Height, Rev, Tasarim, UrunKodu)
                                     VALUES (@d,@s,@p,@st,@v,@f,@t,@h,@r,@tas,@kod)";

                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@d", cmbDesign.Text);
                    cmd.Parameters.AddWithValue("@s", cmbSector.Text);
                    cmd.Parameters.AddWithValue("@p", cmbProductType.Text);
                    cmd.Parameters.AddWithValue("@st", cmbStructureType.Text);
                    cmd.Parameters.AddWithValue("@v", cmbVoltageAyak.Text);
                    cmd.Parameters.AddWithValue("@f", cmbFoundation.Text);
                    cmd.Parameters.AddWithValue("@t", cmbTower.Text);
                    cmd.Parameters.AddWithValue("@h", height);
                    cmd.Parameters.AddWithValue("@r", rev);
                    cmd.Parameters.AddWithValue("@tas", tasarim);
                    cmd.Parameters.AddWithValue("@kod", urunKodu);

                    conn.Open();
                    int effected = cmd.ExecuteNonQuery();
                    if (effected > 0)
                    {
                        ShowInsertedProduct(urunKodu);
                        MessageBox.Show("Yeni ürün eklendi.\nÜrün Kodu: " + urunKodu, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ekleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ShowInputDialog(string promptText, string caption)
        {
            using (Form dialog = new Form())
            {
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Width = 380;
                dialog.Height = 160;
                dialog.Text = caption;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.ShowInTaskbar = false;

                Label lbl = new Label() { Left = 10, Top = 10, Text = promptText, AutoSize = true };
                TextBox txt = new TextBox() { Left = 10, Top = 35, Width = 340 };
                Button btnOk = new Button() { Text = "Tamam", Left = 190, Width = 80, Top = 70, DialogResult = DialogResult.OK };
                Button btnCancel = new Button() { Text = "İptal", Left = 275, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };

                dialog.Controls.Add(lbl);
                dialog.Controls.Add(txt);
                dialog.Controls.Add(btnOk);
                dialog.Controls.Add(btnCancel);

                dialog.AcceptButton = btnOk;
                dialog.CancelButton = btnCancel;

                var dr = dialog.ShowDialog();
                if (dr == DialogResult.OK)
                    return txt.Text?.Trim();
                else
                    return null;
            }
        }

        private string GenerateUrunKodu(string design, string sector, string productType, string structureType,
                                        string voltageAyak, string foundation, string tower, string height, string rev)
        {
            string Clean(string s)
            {
                if (string.IsNullOrWhiteSpace(s)) return "NA";
                s = s.Trim();
                s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");
                s = s.Replace("-", "_");
                return s;
            }

            return string.Join("-",
                Clean(design), Clean(sector), Clean(productType), Clean(structureType),
                Clean(voltageAyak), Clean(foundation), Clean(tower), Clean(height), Clean(rev));
        }

        private bool ExistsUrunKodu(string urunKodu)
        {
            if (string.IsNullOrWhiteSpace(urunKodu)) return false;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM dbo.Urun WHERE UrunKodu = @kod";
                    cmd.Parameters.Add(new SqlParameter("@kod", System.Data.SqlDbType.NVarChar, 500) { Value = urunKodu });
                    conn.Open();
                    object res = cmd.ExecuteScalar();
                    if (res == null || res == DBNull.Value) return false;
                    return Convert.ToInt32(res) > 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL hata (ExistsUrunKodu): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata (ExistsUrunKodu): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ShowInsertedProduct(string urunKodu)
        {
            string sql = @"SELECT Design, Sector, ProductType, StructureType, VoltageAyak, Foundation, Tower, Height, Rev, Tasarim, UrunKodu
                   FROM dbo.Urun WHERE UrunKodu = @kod";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@kod", System.Data.SqlDbType.NVarChar, 500) { Value = urunKodu });
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                }
            }
        }

        #endregion

        #region DataGrid DoubleClick (optional)

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // optional: open ProductDetails form
        }

        #endregion
    }
}
