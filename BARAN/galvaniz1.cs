using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BARAN
{
    public partial class galvaniz : Form
    {
        private int aktifMusteriID;
        private string aktifMusteriAdi;
        private int aktifTeklifID;
        private int urunSayac = 1;
        DataTable dt;

        private string connStr = "Server=localhost\\SQL;Database=LoginDB;Trusted_Connection=True;";

        public galvaniz()
        {
            InitializeComponent();

            // DataTable initialize ve dgvUrunler'e bağlama
            dt = new DataTable();
            dt.Columns.Add("colKaplama", typeof(string));
            dt.Columns.Add("colKg", typeof(decimal));
            dt.Columns.Add("colTonbasi", typeof(decimal));
            dt.Columns.Add("colTl", typeof(decimal));

            // Eğer tasarımda kolonlar zaten varsa AutoGenerateColumns false kalsın; biz DataSource ile çalışacağız.
            dgvUrunler.AutoGenerateColumns = false;
            dgvUrunler.DataSource = dt;
        }

        private void DgvUrunler_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // DataBoundItem varsa DataRow üzerinden, yoksa hücrelerden al
            if (dgvUrunler.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                DataRow row = drv.Row;
                decimal kg = row["colKg"] == DBNull.Value ? 0 : Convert.ToDecimal(row["colKg"]);
                decimal tl = row["colTl"] == DBNull.Value ? 0 : Convert.ToDecimal(row["colTl"]);

                row["colTonbasi"] = (kg > 0) ? (tl / kg) : 0m;
            }
            else
            {
                var kgCell = dgvUrunler.Rows[e.RowIndex].Cells["colKg"]?.Value;
                var tlCell = dgvUrunler.Rows[e.RowIndex].Cells["colTl"]?.Value;

                decimal kg = 0, tl = 0;
                decimal.TryParse(Convert.ToString(kgCell), NumberStyles.Any, CultureInfo.CurrentCulture, out kg);
                decimal.TryParse(Convert.ToString(tlCell), NumberStyles.Any, CultureInfo.CurrentCulture, out tl);

                dgvUrunler.Rows[e.RowIndex].Cells["colTonbasi"].Value = (kg > 0) ? (tl / kg).ToString("N2") : "0.00";
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
                tb.Leave += (s, ev) => dgvUrunler.EndEdit();
        }

        private void MusteriListesiniGetir(string filtre)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT MusteriID, Ad, Soyad FROM Musteri WHERE LOWER(Ad) LIKE @filtre OR LOWER(Soyad) LIKE @filtre", conn);
                cmd.Parameters.AddWithValue("@filtre", "%" + filtre.ToLower() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tmp = new DataTable();
                da.Fill(tmp);
                dgvMusteriler.DataSource = tmp;
            }
        }

        private void btnIleri_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.CurrentRow == null) return;

            aktifMusteriID = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells["MusteriID"].Value);
            string ad = dgvMusteriler.CurrentRow.Cells["Ad"].Value?.ToString() ?? "";
            string soyad = dgvMusteriler.CurrentRow.Cells["Soyad"].Value?.ToString() ?? "";
            aktifMusteriAdi = ad + " " + soyad;
            lblSecilenMusteri.Text = "Müşteri: " + aktifMusteriAdi;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Teklifler (MusteriID) OUTPUT INSERTED.TeklifID VALUES (@mid)", conn);
                cmd.Parameters.AddWithValue("@mid", aktifMusteriID);
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null)
                {
                    aktifTeklifID = Convert.ToInt32(res);
                }
            }

            pnlTeklif.Visible = true;
            KaplamaListesiniYukle();
        }

        private void KaplamaListesiniYukle()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT KaplamaAdi FROM Kaplamalar", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tmp = new DataTable();
                da.Fill(tmp);

                cmbKaplama.Items.Clear();
                foreach (DataRow row in tmp.Rows)
                {
                    cmbKaplama.Items.Add(row["KaplamaAdi"].ToString());
                }
            }
        }

        private void btnTeklifKaydet_Click(object sender, EventArgs e)
        {
            // 1) Girdiler
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen müşteri seçin.");
                return;
            }

            int musteriId = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);

            if (!decimal.TryParse(txtLME.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal girilenLme) ||
                !decimal.TryParse(txtMaliyet.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal girilenMaliyet))
            {
                MessageBox.Show("LME ve maliyet geçersiz.");
                return;
            }
            // Dolar kuru parse
            string textKur = txtdolar.Text.Replace(',', '.');
            if (!decimal.TryParse(textKur, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal girilenDolarKuru))
            {
                MessageBox.Show("Dolar kuru geçersiz.");
                return;
            }

            // 2) Kaydet + ID al
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Teklifler (MusteriID, LME, Maliyet, Tarih, [DolarKuru]) " +
                "VALUES (@mid, @lme, @maliyet, @tarih, @kur); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@mid", musteriId);
                cmd.Parameters.AddWithValue("@kur", girilenDolarKuru);
                cmd.Parameters.AddWithValue("@lme", girilenLme);
                cmd.Parameters.AddWithValue("@maliyet", girilenMaliyet);
                cmd.Parameters.AddWithValue("@tarih", DateTime.Now);

                conn.Open();
                object yeniId = cmd.ExecuteScalar();
                if (yeniId != null)
                    aktifTeklifID = Convert.ToInt32(yeniId);
            }

            MessageBox.Show("Teklif başlığı kaydedildi. Artık Ürün Ekle ile devam edebilirsiniz.");
        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT TeklifID, Tarih FROM Teklifler WHERE MusteriID=@mid", conn);
                cmd.Parameters.AddWithValue("@mid", aktifMusteriID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tmp = new DataTable();
                da.Fill(tmp);
                dgvGecmisTeklifler.DataSource = tmp;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void dgvGecmisTeklifler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int teklifId = Convert.ToInt32(dgvGecmisTeklifler.Rows[e.RowIndex].Cells["TeklifID"].Value);

            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen önce müşteri seçin.");
                return;
            }

            TeklifDetaylariniGoster(teklifId);

            // Üst bilgiler
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT LME, Maliyet, Tarih, [DolarKuru] FROM Teklifler WHERE TeklifID=@tid", conn))
            {
                cmd.Parameters.AddWithValue("@tid", teklifId);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        decimal lme = rdr["LME"] != DBNull.Value ? Convert.ToDecimal(rdr["LME"]) : 0;
                        decimal mali = rdr["Maliyet"] != DBNull.Value ? Convert.ToDecimal(rdr["Maliyet"]) : 0;
                        DateTime tar = rdr["Tarih"] != DBNull.Value ? Convert.ToDateTime(rdr["Tarih"]) : DateTime.MinValue;
                        decimal kur = rdr["DolarKuru"] != DBNull.Value ? Convert.ToDecimal(rdr["DolarKuru"]) : 0;

                        string ad = dgvMusteriler.SelectedRows[0].Cells["Ad"].Value?.ToString() ?? "";
                        string soyad = dgvMusteriler.SelectedRows[0].Cells["Soyad"].Value?.ToString() ?? "";

                        lblDetay.Text =
                            $"Müşteri: {ad} {soyad}\n" +
                            $"TeklifID: {teklifId}\n" +
                            $"Tarih: {tar:dd.MM.yyyy}\n" +
                            $"LME: {lme:N2}\n" +
                            $"Maliyet: {mali:N2}\n" +
                            $"Dolar Kuru: {kur:N4}";
                        pnlDetay.Visible = true;
                    }
                }
            }
        }

        private void TeklifDetaylariniGoster(int teklifId)
        {
            // Sadece satırları temizle, kolonları koru (designer kolonları kullanılıyor olabilir)
            dt.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Teklifler WHERE TeklifID=@tid", conn))
            {
                cmd.Parameters.AddWithValue("@tid", teklifId);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            object urun = rdr[$"Urun{i}"];
                            object kg = rdr[$"Urun{i}Kg"];
                            object tutar = rdr[$"Urun{i}Tutar"];
                            object tlKarsilik = rdr[$"Urun{i}TlKarsilik"];

                            if (urun != DBNull.Value && !string.IsNullOrWhiteSpace(urun.ToString()))
                            {
                                decimal kgVal = (kg != DBNull.Value) ? Convert.ToDecimal(kg) : 0m;
                                decimal tutarVal = (tutar != DBNull.Value) ? Convert.ToDecimal(tutar) : 0m;
                                decimal tlVal = (tlKarsilik != DBNull.Value) ? Convert.ToDecimal(tlKarsilik) : 0m;

                                DataRow newRow = dt.NewRow();
                                newRow["colKaplama"] = urun.ToString();
                                newRow["colKg"] = kgVal;
                                newRow["colTonbasi"] = tutarVal;
                                newRow["colTl"] = tlVal;
                                dt.Rows.Add(newRow);
                            }
                        }

                        // üst bilgiler zaten dgvGecmisTeklifler_CellDoubleClick tarafından gösteriliyor,
                        // burada ek bir işlem gerekirse ekleyebilirsiniz.
                    }
                }
            }
        }

        private void btnMusteriAra_Click(object sender, EventArgs e)
        {
            string aranan = txtMusteriAra.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MusteriID, Ad, Soyad, Email, Telefon, KayitTarihi " +
                "FROM Musteri " +
                "WHERE Ad LIKE @p OR Soyad LIKE @p", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@p", "%" + aranan + "%");

                DataTable tmp = new DataTable();
                da.Fill(tmp);

                dgvMusteriler.DataSource = tmp;
            }
        }

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0) return;

            int musteriId = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT TeklifID, Tarih FROM Teklifler WHERE MusteriID=@mid ORDER BY TeklifID DESC", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@mid", musteriId);
                DataTable tmp = new DataTable();
                da.Fill(tmp);
                dgvGecmisTeklifler.DataSource = tmp;
            }
        }

        private void GecmisTeklifleriYukle()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TeklifID, Tarih FROM Teklifler ORDER BY TeklifID DESC", conn);
                DataTable tmp = new DataTable();
                da.Fill(tmp);
                dgvGecmisTeklifler.DataSource = tmp;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void GetV()
        {
            txtKg.Clear();
        }

        // SADECE mevcut DataGridView için (ör. dgvUrunler)
        // Ekstra grid yaratma YOK.

        void KaydetSQL(string kaplama, decimal kg, decimal tlkarsilik, decimal tonbasi)
        {
            string sql = "INSERT INTO TeklifKalemleri (kaplama, kg, tlkarsilik, tonbasi) " +
                         "VALUES (@kaplama, @kg, @tlkarsilik, @tonbasi)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kaplama", kaplama);
                cmd.Parameters.AddWithValue("@kg", kg);
                cmd.Parameters.AddWithValue("@tlkarsilik", tlkarsilik);
                cmd.Parameters.AddWithValue("@tonbasi", tonbasi);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            // 1) Kontroller
            if (aktifTeklifID <= 0)
            {
                MessageBox.Show("Önce Teklif Kaydet yapın.");
                return;
            }
            if (cmbKaplama.SelectedItem == null)
            {
                MessageBox.Show("Kaplama seçin.");
                return;
            }

            if (!decimal.TryParse(txtKg.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal girilenKg) || girilenKg <= 0)
            {
                MessageBox.Show("Kg geçersiz.");
                return;
            }

            if (!decimal.TryParse(txtLME.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal girilenLme) ||
                !decimal.TryParse(txtMaliyet.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal girilenMaliyet))
            {
                MessageBox.Show("LME veya maliyet hatalı.");
                return;
            }

            string textKur = txtdolar.Text.Replace(',', '.');
            if (!decimal.TryParse(textKur, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal girilenDolarKuru) || girilenDolarKuru <= 0)
            {
                MessageBox.Show("Dolar kuru geçersiz.");
                return;
            }

            // Dinamik alan slot
            int slot = urunSayac;
            if (slot < 1 || slot > 10)
            {
                MessageBox.Show("Maksimum ürün adedine ulaşıldı (10).");
                return;
            }

            string alanUrun = $"Urun{slot}";
            string alanKg = $"Urun{slot}Kg";
            string alanTutar = $"Urun{slot}Tutar";        // TONBAŞI
            string alanTlKarsilik = $"Urun{slot}TlKarsilik";   // TL toplam

            string secilenKaplama = cmbKaplama.SelectedItem.ToString();

            // Kaplama içinden sayı yakala (Zn 8 => 8)
            var m = Regex.Match(secilenKaplama, @"\d+");
            if (!m.Success || !int.TryParse(m.Value, out int kaplamaDegeri))
            {
                MessageBox.Show("Kaplama değeri sayısal değil.");
                return;
            }

            // Hesaplamalar
            decimal sabit = 225m;
            decimal kaplamaOrani = kaplamaDegeri / 1000m;

            decimal galvanizmaliyeti = (sabit + girilenLme) * kaplamaOrani;
            decimal iscilik = girilenMaliyet - galvanizmaliyeti;
            decimal tonbasi = galvanizmaliyeti + iscilik;  // $/Ton

            decimal toplamTutar = (girilenKg / 1000m) * tonbasi;   // $ toplam
            decimal tlKarsilik = toplamTutar * girilenDolarKuru;   // TL toplam

            // SQL update Teklifler dinamik alanlara kaydet
            string sql =
                $"UPDATE Teklifler SET " +
                $" {alanUrun}=@u, " +
                $" {alanKg}=@kg, " +
                $" {alanTutar}=@tutar, " +
                $" {alanTlKarsilik}=@tlkarsilik " +
                $"WHERE TeklifID=@tid";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@u", secilenKaplama);
                cmd.Parameters.AddWithValue("@kg", girilenKg);
                cmd.Parameters.AddWithValue("@tutar", tonbasi);
                cmd.Parameters.AddWithValue("@tlkarsilik", tlKarsilik);
                cmd.Parameters.AddWithValue("@tid", aktifTeklifID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Opsiyonel: ayrı kalem tablosuna da kaydet
            KaydetSQL(secilenKaplama, girilenKg, tlKarsilik, tonbasi);

            // DataTable'a ekle (DataGridView otomatik güncellenecek)
            DataRow row = dt.NewRow();
            row["colKaplama"] = secilenKaplama;
            row["colKg"] = girilenKg;
            row["colTonbasi"] = tonbasi;
            row["colTl"] = tlKarsilik;
            dt.Rows.Add(row);

            // sonraki ürün için sayaç artır
            urunSayac++;
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0) return;

            int index = dgvUrunler.SelectedRows[0].Index + 1; // Urun1 → index 1

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"UPDATE Teklifler SET Urun{index}=NULL, Urun{index}Kg=NULL, Urun{index}Tutar=NULL, Urun{index}TlKarsilik=NULL WHERE TeklifID=@tid", conn);
                cmd.Parameters.AddWithValue("@tid", aktifTeklifID);
                cmd.ExecuteNonQuery();
            }

            // DataTable'dan sil
            if (index - 1 >= 0 && index - 1 < dt.Rows.Count)
                dt.Rows.RemoveAt(index - 1);
        }

        private void btnGecmisTeklifler_Click(object sender, EventArgs e)
        {
            if (dgvMusteriler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen önce bir müşteri seçin.");
                return;
            }

            int musteriId = Convert.ToInt32(dgvMusteriler.SelectedRows[0].Cells["MusteriID"].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT TeklifID, Tarih FROM Teklifler WHERE MusteriID=@mid ORDER BY TeklifID DESC", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@mid", musteriId);

                DataTable tmp = new DataTable();
                da.Fill(tmp);

                dgvGecmisTeklifler.DataSource = tmp;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MAAŞA ZAM İSTERİM AĞAM");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni Galvaniz formu oluştur
            galvaniz yeniForm = new galvaniz();

            // Yeni formu göster
            yeniForm.Show();

            // Mevcut formu kapat (istersen)
            this.Close();
        }

        private void pnlTeklif_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
