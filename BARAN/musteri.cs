// musteri.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BARAN
{
    public partial class musteri : Form
    {
        // Kendine göre düzelt:
        private readonly string ConnStr = @"Server=localhost\SQL;Database=LoginDB;Trusted_Connection=True;";

        public musteri()
        {
            InitializeComponent();
            AttachEvents();
            LoadCustomers();
        }

        private void AttachEvents()
        {
            // Tek noktadan bağla, önce çıkar sonra ekle (çift bağlamayı önler)
            btnYenile.Click -= BtnYenile_Click; btnYenile.Click += BtnYenile_Click;
            btnYeni.Click -= BtnYeni_Click; btnYeni.Click += BtnYeni_Click;
            btnDuzenle.Click -= BtnDuzenle_Click; btnDuzenle.Click += BtnDuzenle_Click;
            btnSil.Click -= BtnSil_Click; btnSil.Click += BtnSil_Click;

            txtSearch.KeyDown -= TxtSearch_KeyDown; txtSearch.KeyDown += TxtSearch_KeyDown;
            dataGridView1.CellDoubleClick -= DataGridView1_CellDoubleClick; dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        #region Load / Refresh

        private void LoadCustomers()
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("SELECT MusteriID, Ad, Soyad, Email, Telefon, KayitTarihi FROM dbo.Musteri ORDER BY Ad, Soyad", conn))
                {
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns["MusteriID"] != null) dataGridView1.Columns["MusteriID"].Visible = false;
                    if (dataGridView1.Columns["Ad"] != null) dataGridView1.Columns["Ad"].HeaderText = "Ad";
                    // Ön kısımda "VN" görünmesi isteniyor; arka planda sütun adı olarak "Soyad" kalıyor.
                    if (dataGridView1.Columns["Soyad"] != null) dataGridView1.Columns["Soyad"].HeaderText = "VN";
                    if (dataGridView1.Columns["Email"] != null) dataGridView1.Columns["Email"].HeaderText = "E-posta";
                    if (dataGridView1.Columns["Telefon"] != null) dataGridView1.Columns["Telefon"].HeaderText = "Telefon";
                    if (dataGridView1.Columns["KayitTarihi"] != null) dataGridView1.Columns["KayitTarihi"].HeaderText = "Kayıt Tarihi";

                    dataGridView1.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGridAfterChange()
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                PerformSearch(txtSearch.Text);
            else
                LoadCustomers();
        }

        #endregion

        #region Search

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; e.SuppressKeyPress = true;
                PerformSearch(txtSearch.Text);
            }
        }

        private void PerformSearch(string raw)
        {
            string q = (raw ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(q))
            {
                LoadCustomers();
                return;
            }

            // normalize: çoklu boşlukları tek boşluğa indir, ayrıca boşluksuz versiyon
            string normalized = System.Text.RegularExpressions.Regex.Replace(q, @"\s+", " ");
            string noSpaces = normalized.Replace(" ", "");

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
SELECT MusteriID, Ad, Soyad, Email, Telefon, KayitTarihi
FROM dbo.Musteri
WHERE
    Ad LIKE '%' + @norm + '%'
    OR Soyad LIKE '%' + @norm + '%'
    OR REPLACE(Ad, ' ', '') = @noSpaces
    OR REPLACE(Soyad, ' ', '') = @noSpaces
ORDER BY Ad, Soyad;";

                    cmd.Parameters.Add(new SqlParameter("@norm", SqlDbType.NVarChar, 200) { Value = normalized });
                    cmd.Parameters.Add(new SqlParameter("@noSpaces", SqlDbType.NVarChar, 200) { Value = noSpaces });

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns["MusteriID"] != null) dataGridView1.Columns["MusteriID"].Visible = false;
                    if (dataGridView1.Columns["Ad"] != null) dataGridView1.Columns["Ad"].HeaderText = "Ad";
                    // Arama sonuçlarında da başlık VN olarak gösterilsin
                    if (dataGridView1.Columns["Soyad"] != null) dataGridView1.Columns["Soyad"].HeaderText = "VN";
                    if (dataGridView1.Columns["Email"] != null) dataGridView1.Columns["Email"].HeaderText = "E-posta";

                    dataGridView1.AutoResizeColumns();

                    if (dt.Rows.Count == 0) MessageBox.Show("Aramaya uyan müşteri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CRUD

        private void BtnYenile_Click(object sender, EventArgs e) => LoadCustomers();

        private void BtnYeni_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Yeni Müşteri";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Width = 420; form.Height = 300;

                var lblAd = new Label() { Left = 10, Top = 10, Text = "Ad:", AutoSize = true };
                var txtAd = new TextBox() { Left = 110, Top = 8, Width = 280 };

                var lblSoyad = new Label() { Left = 10, Top = 45, Text = "Vergi No:", AutoSize = true };
                var txtSoyad = new TextBox() { Left = 110, Top = 43, Width = 280 };

                var lblEmail = new Label() { Left = 10, Top = 80, Text = "E-posta:", AutoSize = true };
                var txtEmail = new TextBox() { Left = 110, Top = 78, Width = 280 };

                var lblTel = new Label() { Left = 10, Top = 115, Text = "Telefon:", AutoSize = true };
                var txtTel = new TextBox() { Left = 110, Top = 113, Width = 280 };

                var btnOk = new Button() { Text = "Kaydet", Left = 210, Width = 90, Top = 200, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "İptal", Left = 305, Width = 90, Top = 200, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lblAd, txtAd, lblSoyad, txtSoyad, lblEmail, txtEmail, lblTel, txtTel, btnOk, btnCancel });
                form.AcceptButton = btnOk; form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    string ad = txtAd.Text.Trim();
                    string soyad = txtSoyad.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string tel = txtTel.Text.Trim();

                    if (string.IsNullOrWhiteSpace(ad) && string.IsNullOrWhiteSpace(soyad))
                    {
                        MessageBox.Show("Ad veya VN alanından en az birini doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        using (var conn = new SqlConnection(ConnStr))
                        using (var cmd = new SqlCommand(@"INSERT INTO dbo.Musteri (Ad, Soyad, Email, Telefon) VALUES (@ad,@soy,@email,@tel)", conn))
                        {
                            cmd.Parameters.AddWithValue("@ad", string.IsNullOrWhiteSpace(ad) ? (object)DBNull.Value : ad);
                            cmd.Parameters.AddWithValue("@soy", string.IsNullOrWhiteSpace(soyad) ? (object)DBNull.Value : soyad);
                            cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmd.Parameters.AddWithValue("@tel", string.IsNullOrWhiteSpace(tel) ? (object)DBNull.Value : tel);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        RefreshGridAfterChange();
                        MessageBox.Show("Müşteri eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL hatası (Ekleme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Beklenmeyen hata (Ekleme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) { MessageBox.Show("Düzenlemek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var row = dataGridView1.CurrentRow;
            int id = Convert.ToInt32(row.Cells["MusteriID"].Value);
            string curAd = row.Cells["Ad"].Value?.ToString() ?? "";
            // Arka planda sütun "Soyad" kalıyor; formda etiket olarak "Vergi No" gösteriliyor.
            string curSoyad = row.Cells["Soyad"].Value?.ToString() ?? "";
            string curEmail = row.Cells["Email"].Value?.ToString() ?? "";
            string curTel = row.Cells["Telefon"].Value?.ToString() ?? "";

            using (var form = new Form())
            {
                form.Text = "Müşteri Düzenle";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Width = 420; form.Height = 320;

                var lblAd = new Label() { Left = 10, Top = 10, Text = "Ad:", AutoSize = true };
                var txtAd = new TextBox() { Left = 110, Top = 8, Width = 280, Text = curAd };

                var lblSoyad = new Label() { Left = 10, Top = 45, Text = "Vergi No:", AutoSize = true };
                var txtSoyad = new TextBox() { Left = 110, Top = 43, Width = 280, Text = curSoyad };

                var lblEmail = new Label() { Left = 10, Top = 80, Text = "E-posta:", AutoSize = true };
                var txtEmail = new TextBox() { Left = 110, Top = 78, Width = 280, Text = curEmail };

                var lblTel = new Label() { Left = 10, Top = 115, Text = "Telefon:", AutoSize = true };
                var txtTel = new TextBox() { Left = 110, Top = 113, Width = 280, Text = curTel };

                var btnOk = new Button() { Text = "Kaydet", Left = 210, Width = 90, Top = 230, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "İptal", Left = 305, Width = 90, Top = 230, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lblAd, txtAd, lblSoyad, txtSoyad, lblEmail, txtEmail, lblTel, txtTel, btnOk, btnCancel });
                form.AcceptButton = btnOk; form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    string ad = txtAd.Text.Trim();
                    string soyad = txtSoyad.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string tel = txtTel.Text.Trim();

                    if (string.IsNullOrWhiteSpace(ad) && string.IsNullOrWhiteSpace(soyad))
                    {
                        MessageBox.Show("Ad veya VN alanından en az birini doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        using (var conn = new SqlConnection(ConnStr))
                        using (var cmd = new SqlCommand(@"UPDATE dbo.Musteri SET Ad=@ad, Soyad=@soy, Email=@email, Telefon=@tel WHERE MusteriID=@id", conn))
                        {
                            cmd.Parameters.AddWithValue("@ad", string.IsNullOrWhiteSpace(ad) ? (object)DBNull.Value : ad);
                            cmd.Parameters.AddWithValue("@soy", string.IsNullOrWhiteSpace(soyad) ? (object)DBNull.Value : soyad);
                            cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                            cmd.Parameters.AddWithValue("@tel", string.IsNullOrWhiteSpace(tel) ? (object)DBNull.Value : tel);
                            cmd.Parameters.AddWithValue("@id", id);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }

                        RefreshGridAfterChange();
                        MessageBox.Show("Müşteri güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL hatası (Güncelleme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Beklenmeyen hata (Güncelleme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) { MessageBox.Show("Silmek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var row = dataGridView1.CurrentRow;
            int id = Convert.ToInt32(row.Cells["MusteriID"].Value);
            // Ön yüzde "VN" görünür; arka planda değeri Soyad sütunundan alıyoruz.
            string name = (row.Cells["Ad"].Value?.ToString() ?? "") + " " + (row.Cells["Soyad"].Value?.ToString() ?? "");

            var ans = MessageBox.Show($"\"{name}\" adlı müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand("DELETE FROM dbo.Musteri WHERE MusteriID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                RefreshGridAfterChange();
                MessageBox.Show("Müşteri silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL hatası (Silme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata (Silme): " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helpers / Events

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // opsiyonel: çift tıklayınca düzenleme aç
            BtnDuzenle_Click(sender, EventArgs.Empty);
        }

        #endregion
    }
}
