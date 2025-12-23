using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BARAN
{
    public partial class galvanizteklif : Form
    {
        // --------------------------------------------------------------------------
        // 1. AYARLAR VE DEĞİŞKENLER
        // --------------------------------------------------------------------------
        string connectionString = "Server=localhost\\SQL;Database=LoginDB;Trusted_Connection=True;";

        private int secilenMusteriID = -1;
        private string secilenMusteriTamAd = "";

        private int aktifMusteriID = -1;
        private string aktifMusteriAdi = "";

        private int aktifTeklifID = -1;

        // Grid Verisi İçin Tablo
        DataTable dtUrunler;

        // Yazdırma Nesneleri
        PrintDocument printDocument1 = new PrintDocument();
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public galvanizteklif()
        {
            InitializeComponent();

            // ----------------------------------------------------------------------
            // 2. DATATABLE OLUŞTURMA
            // ----------------------------------------------------------------------
            dtUrunler = new DataTable();

            // Görünen Sütunlar
            dtUrunler.Columns.Add("colKaplama", typeof(string));
            dtUrunler.Columns.Add("colKg", typeof(decimal));
            dtUrunler.Columns.Add("colTonbasi", typeof(string)); // Tonbaşı Maliyet (Kar Hariç)
            dtUrunler.Columns.Add("colTl", typeof(string));
            dtUrunler.Columns.Add("colKar", typeof(string));     // Satış Fiyatı (Karlı)
            dtUrunler.Columns.Add("colKDVdolar", typeof(string));
            dtUrunler.Columns.Add("colKDVTL", typeof(string));

            // Gizli Ham Veriler 
            dtUrunler.Columns.Add("rawTonFiyati", typeof(decimal));   // Satış Fiyatı (Karlı)
            dtUrunler.Columns.Add("rawTonMaliyeti", typeof(decimal)); // Saf Maliyet (Karsız)
            dtUrunler.Columns.Add("rawToplamTutar", typeof(decimal)); // Satış Toplamı ($)
            dtUrunler.Columns.Add("rawTLKarsilik", typeof(decimal));

            dgvUrunler.AutoGenerateColumns = true;
            dgvUrunler.DataSource = dtUrunler;

            GridDuzenle();
            InitializeCustomEvents();
        }

        private void GridDuzenle()
        {
            if (dgvUrunler.Columns["colKaplama"] != null) dgvUrunler.Columns["colKaplama"].HeaderText = "Kaplama Türü";
            if (dgvUrunler.Columns["colKg"] != null) dgvUrunler.Columns["colKg"].HeaderText = "KG";
            if (dgvUrunler.Columns["colTonbasi"] != null) dgvUrunler.Columns["colTonbasi"].HeaderText = "Maliyet ($/Ton)";
            if (dgvUrunler.Columns["colTl"] != null) dgvUrunler.Columns["colTl"].HeaderText = "TL Tutar";
            if (dgvUrunler.Columns["colKar"] != null) dgvUrunler.Columns["colKar"].HeaderText = "Satış Fiyatı ($/Ton)";
            if (dgvUrunler.Columns["colKDVdolar"] != null) dgvUrunler.Columns["colKDVdolar"].HeaderText = "KDV Dahil ($)";
            if (dgvUrunler.Columns["colKDVTL"] != null) dgvUrunler.Columns["colKDVTL"].HeaderText = "KDV Dahil (TL)";

            // Gizli Sütunları Sakla
            if (dgvUrunler.Columns["rawTonFiyati"] != null) dgvUrunler.Columns["rawTonFiyati"].Visible = false;
            if (dgvUrunler.Columns["rawTonMaliyeti"] != null) dgvUrunler.Columns["rawTonMaliyeti"].Visible = false;
            if (dgvUrunler.Columns["rawToplamTutar"] != null) dgvUrunler.Columns["rawToplamTutar"].Visible = false;
            if (dgvUrunler.Columns["rawTLKarsilik"] != null) dgvUrunler.Columns["rawTLKarsilik"].Visible = false;
        }

        private void InitializeCustomEvents()
        {
            this.Load += Galvanizteklif_Load;
            btnMusteriAra.Click += BtnMusteriAra_Click;
            dgvMusteriler.CellClick += DgvMusteriler_CellClick;
            btnIleri.Click += BtnIleri_Click;
            btnUrunEkle.Click += BtnUrunEkle_Click;

            // Teklife Başla
            if (this.Controls.Find("btnTeklifKaydet", true).Length > 0)
                this.Controls.Find("btnTeklifKaydet", true)[0].Click += BtnTeklifBaslat_Click;
       

            // Son Kayıt
            if (this.Controls.Find("btnUrunKaydet", true).Length > 0)
                this.Controls.Find("btnUrunKaydet", true)[0].Click += BtnUrunleriDBYeKaydet_Click;

            // Sil
            if (this.Controls.Find("btnUrunSil", true).Length > 0)
                this.Controls.Find("btnUrunSil", true)[0].Click += BtnUrunSil_Click;

            // PDF
            if (this.Controls.Find("btnPdf", true).Length > 0)
                this.Controls.Find("btnPdf", true)[0].Click += BtnPdf_Click;
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            // Geçmiş
            btnGecmisTeklifler.Click += BtnGecmisTeklifler_Click;
            dgvGecmisTeklifler.CellDoubleClick += DgvGecmisTeklifler_CellDoubleClick;

            // Hesapla Butonu (Normal Kümülatif)
            if (this.Controls.Find("btnHesapla", true).Length > 0)
                this.Controls.Find("btnHesapla", true)[0].Click += BtnHesapla_Click;

            // *** YENİ: KARLI KÜMÜLATİF BUTONU ***
            if (this.Controls.Find("btnKarli", true).Length > 0)
                this.Controls.Find("btnKarli", true)[0].Click += BtnKarli_Click;
        }

        private void Galvanizteklif_Load(object sender, EventArgs e)
        {
            MusterileriGetir();
            KaplamalariGetir();
            pnlDetay.Visible = false;
        }

        private decimal ParseDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            string normalized = text.Replace(',', '.');
            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;
            return 0;
        }

        // --------------------------------------------------------------------------
        // 3. MÜŞTERİ SEÇİM
        // --------------------------------------------------------------------------
        private void MusterileriGetir(string aranan = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MusteriID, Ad, Soyad, Telefon FROM Musteri";
                    if (!string.IsNullOrEmpty(aranan)) query += " WHERE Ad LIKE @p OR Soyad LIKE @p";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    if (!string.IsNullOrEmpty(aranan)) da.SelectCommand.Parameters.AddWithValue("@p", "%" + aranan + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMusteriler.DataSource = dt;
                    if (dgvMusteriler.Columns.Contains("MusteriID")) dgvMusteriler.Columns["MusteriID"].Visible = false;
                }
                catch { }
            }
        }
        private void DgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenMusteriID = Convert.ToInt32(dgvMusteriler.Rows[e.RowIndex].Cells["MusteriID"].Value);
                secilenMusteriTamAd = dgvMusteriler.Rows[e.RowIndex].Cells["Ad"].Value + " " + dgvMusteriler.Rows[e.RowIndex].Cells["Soyad"].Value;
            }
        }
        private void BtnMusteriAra_Click(object sender, EventArgs e) => MusterileriGetir(txtMusteriAra.Text);
        private void BtnIleri_Click(object sender, EventArgs e)
        {
            if (secilenMusteriID == -1 && dgvMusteriler.CurrentRow != null)
            {
                secilenMusteriID = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells["MusteriID"].Value);
                secilenMusteriTamAd = dgvMusteriler.CurrentRow.Cells["Ad"].Value + " " + dgvMusteriler.CurrentRow.Cells["Soyad"].Value;
            }
            if (secilenMusteriID == -1) { MessageBox.Show("Müşteri seçin."); return; }

            aktifMusteriID = secilenMusteriID;
            aktifMusteriAdi = secilenMusteriTamAd;
            lblSecilenMusteri.Text = "Seçilen: " + aktifMusteriAdi;
            pnlTeklif.Visible = true;
            dgvGecmisTeklifler.Visible = false;
            pnlDetay.Visible = false;

            dtUrunler.Rows.Clear();
            aktifTeklifID = -1;

            // Label temizliği
            if (this.Controls.Find("lblKumulatif", true).Length > 0)
                this.Controls.Find("lblKumulatif", true)[0].Text = "Kümülatif: 0.00";
            if (this.Controls.Find("lblKumulatifkarli", true).Length > 0)
                this.Controls.Find("lblKumulatifkarli", true)[0].Text = "Karlı Kümülatif: 0.00";
        }

        // --------------------------------------------------------------------------
        // 4. TEKLİFE BAŞLA
        // --------------------------------------------------------------------------
        private void BtnTeklifBaslat_Click(object sender, EventArgs e)
        {
            if (aktifMusteriID == -1) { MessageBox.Show("Müşteri seçili değil."); return; }
            if (string.IsNullOrEmpty(txtLME.Text)) { MessageBox.Show("LME giriniz."); return; }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO teklifler (MusteriID, Ad, Tarih, LME, Maliyet, DolarKuru) 
                                   VALUES (@mid, @ad, @tarih, @lme, @maliyet, @kur); 
                                   SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@mid", aktifMusteriID);
                    cmd.Parameters.AddWithValue("@ad", aktifMusteriAdi);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                    cmd.Parameters.AddWithValue("@lme", ParseDecimal(txtLME.Text));
                    cmd.Parameters.AddWithValue("@maliyet", ParseDecimal(txtMaliyet.Text));
                    cmd.Parameters.AddWithValue("@kur", ParseDecimal(txtdolar.Text));

                    aktifTeklifID = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show($"Teklif No: {aktifTeklifID} oluşturuldu.");
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        // --------------------------------------------------------------------------
        // 5. ÜRÜN EKLE
        // --------------------------------------------------------------------------
        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            if (aktifTeklifID == -1) { MessageBox.Show("Önce 'Teklife Başla' butonuna basınız."); return; }
            if (string.IsNullOrEmpty(txtKg.Text)) { MessageBox.Show("KG giriniz."); return; }

            try
            {
                string secilenKaplamaAdi = cmbKaplama.SelectedItem.ToString();
                decimal kg = ParseDecimal(txtKg.Text);
                decimal lme = ParseDecimal(txtLME.Text);
                decimal maliyet = ParseDecimal(txtMaliyet.Text);
                decimal dolar = ParseDecimal(txtdolar.Text);
                decimal karYuzde = ParseDecimal(textBox1.Text);

                // DB'den Kalınlık
                decimal kaplamaDegeri = 50;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT KalinlikYuzde FROM Kaplamalar WHERE KaplamaAdi=@ad", conn);
                    cmd.Parameters.AddWithValue("@ad", secilenKaplamaAdi);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value) kaplamaDegeri = Convert.ToDecimal(result);
                }

                // --- HESAPLAMA ---
                decimal iscilik = maliyet - (((lme + 225m) * 6m) / 100m);
                decimal tonbasiMaliyet = (((lme + 225m) * kaplamaDegeri) / 100m) + iscilik; // SAF MALİYET
                decimal karliTonFiyati = tonbasiMaliyet * (1 + (karYuzde / 100m));
                decimal toplamTutarDolar = (karliTonFiyati / 1000m) * kg;
                decimal tlKarsilik = toplamTutarDolar * dolar;
                decimal kdvDolar = toplamTutarDolar * 1.20m;
                decimal kdvTL = tlKarsilik * 1.20m;

                // GRİD'E EKLE
                DataRow row = dtUrunler.NewRow();
                row["colKaplama"] = secilenKaplamaAdi;
                row["colKg"] = kg;
                row["colTonbasi"] = tonbasiMaliyet.ToString("N2");
                row["colTl"] = tlKarsilik.ToString("N2");
                row["colKar"] = karliTonFiyati.ToString("N2");
                row["colKDVdolar"] = kdvDolar.ToString("N2");
                row["colKDVTL"] = kdvTL.ToString("N2");

                // GİZLİ VERİLER
                row["rawTonFiyati"] = karliTonFiyati;
                row["rawTonMaliyeti"] = tonbasiMaliyet;    // KÜMÜLATİF İÇİN
                row["rawToplamTutar"] = toplamTutarDolar;
                row["rawTLKarsilik"] = tlKarsilik;

                dtUrunler.Rows.Add(row);
                txtKg.Clear();
                txtKg.Focus();
            }
            catch (Exception ex) { MessageBox.Show("Hesap Hatası: " + ex.Message); }
        }

        // --------------------------------------------------------------------------
        // 6. btnHesapla: NORMAL KÜMÜLATİF (KARSIZ)
        // --------------------------------------------------------------------------
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if (aktifTeklifID == -1) { MessageBox.Show("Aktif teklif yok."); return; }
            if (dtUrunler.Rows.Count == 0) return;

            try
            {
                decimal toplamSafMaliyet = 0;
                decimal toplamKg = 0;

                foreach (DataRow row in dtUrunler.Rows)
                {
                    decimal kg = Convert.ToDecimal(row["colKg"]);
                    // Saf Maliyeti al
                    decimal tonMaliyeti = (row["rawTonMaliyeti"] != DBNull.Value) ? Convert.ToDecimal(row["rawTonMaliyeti"]) : ParseDecimal(row["colTonbasi"].ToString());

                    toplamSafMaliyet += (tonMaliyeti / 1000m) * kg;
                    toplamKg += kg;
                }

                decimal kumulatifSonuc = 0;
                if (toplamKg > 0) kumulatifSonuc = toplamSafMaliyet / (toplamKg / 1000m);

                if (this.Controls.Find("lblKumulatif", true).Length > 0)
                    this.Controls.Find("lblKumulatif", true)[0].Text = "Kümülatif: " + kumulatifSonuc.ToString("N2") + " $/Ton";

                // DB Update
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sKumulatif = kumulatifSonuc.ToString(CultureInfo.InvariantCulture);
                    string sql = $"UPDATE teklifler SET kumulatif='{sKumulatif}' WHERE TeklifID={aktifTeklifID}";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        // --------------------------------------------------------------------------
        // 7. btnKarli: KARLI KÜMÜLATİF (YENİ İSTEK)
        // --------------------------------------------------------------------------
        private void BtnKarli_Click(object sender, EventArgs e)
        {
            if (aktifTeklifID == -1) { MessageBox.Show("Aktif teklif yok."); return; }
            if (dtUrunler.Rows.Count == 0) return;

            try
            {
                // 1. Önce Saf Kümülatifi Bul (Hesapla butonuyla aynı mantık)
                decimal toplamSafMaliyet = 0;
                decimal toplamKg = 0;

                foreach (DataRow row in dtUrunler.Rows)
                {
                    decimal kg = Convert.ToDecimal(row["colKg"]);
                    decimal tonMaliyeti = (row["rawTonMaliyeti"] != DBNull.Value) ? Convert.ToDecimal(row["rawTonMaliyeti"]) : ParseDecimal(row["colTonbasi"].ToString());

                    toplamSafMaliyet += (tonMaliyeti / 1000m) * kg;
                    toplamKg += kg;
                }

                decimal kumulatifSaf = 0;
                if (toplamKg > 0) kumulatifSaf = toplamSafMaliyet / (toplamKg / 1000m);

                // 2. Kar Marjını Uygula
                decimal karYuzde = ParseDecimal(textBox1.Text);
                decimal karliKumulatif = kumulatifSaf * (1 + (karYuzde / 100m));

                // 3. Label'a Yaz
                if (this.Controls.Find("lblKumulatifkarli", true).Length > 0)
                    this.Controls.Find("lblKumulatifkarli", true)[0].Text = "Karlı Kümülatif: " + karliKumulatif.ToString("N2") + " $/Ton";

                // 4. DB Update (karlikumulatif sütununa)
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sKarli = karliKumulatif.ToString(CultureInfo.InvariantCulture);
                    string sql = $"UPDATE teklifler SET karlikumulatif='{sKarli}' WHERE TeklifID={aktifTeklifID}";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show("Karlı Hesap Hatası: " + ex.Message); }
        }

        // --------------------------------------------------------------------------
        // 8. KAYDET (VERİTABANINA DÖK)
        // --------------------------------------------------------------------------
        private void BtnUrunleriDBYeKaydet_Click(object sender, EventArgs e)
        {
            if (aktifTeklifID == -1) { MessageBox.Show("Teklif başlatılmamış."); return; }
            if (dtUrunler.Rows.Count == 0) { MessageBox.Show("Listede ürün yok."); return; }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sql = "UPDATE teklifler SET ";
                    decimal grandTotal = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        int slot = i + 1;
                        if (i < dtUrunler.Rows.Count)
                        {
                            DataRow row = dtUrunler.Rows[i];
                            string k = row["colKaplama"].ToString();
                            string kg = Convert.ToDecimal(row["colKg"]).ToString(CultureInfo.InvariantCulture);
                            string tutar = Convert.ToDecimal(row["rawTonFiyati"]).ToString(CultureInfo.InvariantCulture);
                            string tl = Convert.ToDecimal(row["rawTLKarsilik"]).ToString(CultureInfo.InvariantCulture);

                            grandTotal += Convert.ToDecimal(row["rawToplamTutar"]);

                            sql += $"Urun{slot}='{k}', Urun{slot}Kg='{kg}', Urun{slot}Tutar='{tutar}', Urun{slot}TlKarsilik='{tl}', ";
                        }
                        else
                        {
                            sql += $"Urun{slot}=NULL, Urun{slot}Kg=NULL, Urun{slot}Tutar=NULL, Urun{slot}TlKarsilik=NULL, ";
                        }
                    }

                    string sTotal = grandTotal.ToString(CultureInfo.InvariantCulture);
                    sql += $"TeklifTotal='{sTotal}' WHERE TeklifID={aktifTeklifID}";

                    SqlCommand cmd = new SqlCommand(sql, conn, trans);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Teklif kaydedildi.");
                    dtUrunler.Rows.Clear();
                    pnlTeklif.Visible = false;
                    aktifTeklifID = -1;
                }
                catch (Exception ex) { trans.Rollback(); MessageBox.Show("Kayıt hatası: " + ex.Message); }
            }
        }
     
        private void BtnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
                foreach (DataGridViewRow row in dgvUrunler.SelectedRows)
                    if (!row.IsNewRow) dgvUrunler.Rows.RemoveAt(row.Index);
        }

        // --------------------------------------------------------------------------
        // 9. GEÇMİŞ VE DETAY (GÜNCELLENDİ: KARLI KÜMÜLATİF GÖSTERİMİ)
        // --------------------------------------------------------------------------
        private void BtnGecmisTeklifler_Click(object sender, EventArgs e)
        {
            if (aktifMusteriID == -1) { MessageBox.Show("Müşteri seçin."); return; }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TeklifID, Tarih FROM teklifler WHERE MusteriID=@mid ORDER BY Tarih DESC", conn);
                da.SelectCommand.Parameters.AddWithValue("@mid", aktifMusteriID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGecmisTeklifler.DataSource = dt;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void DgvGecmisTeklifler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvGecmisTeklifler.Rows[e.RowIndex].Cells["TeklifID"].Value);
            aktifTeklifID = id;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // karlikumulatif de çekiliyor
                string query = "SELECT *, karlikumulatif FROM teklifler WHERE TeklifID=@tid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tid", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // 1. ÖNCE PARAMETRELER
                    txtLME.Text = dr["LME"].ToString();
                    txtMaliyet.Text = dr["Maliyet"].ToString();
                    txtdolar.Text = dr["DolarKuru"].ToString();

                    string sKumulatif = dr["kumulatif"] != DBNull.Value ? Convert.ToDecimal(dr["kumulatif"]).ToString("N2") : "0";

                    // YENİ: Karlı Kümülatifi çek
                    string sKarliKumulatif = "0";
                    // Veritabanında karlikumulatif sütunu varsa oku, yoksa hata vermesin diye try
                    try { if (dr["karlikumulatif"] != DBNull.Value) sKarliKumulatif = Convert.ToDecimal(dr["karlikumulatif"]).ToString("N2"); } catch { }

                    string sTarih = Convert.ToDateTime(dr["Tarih"]).ToString("dd.MM.yyyy HH:mm");

                    lblDetay.Text = $"Teklif No: {id}\n" +
                                    $"Tarih: {sTarih}\n" +
                                    $"LME: {dr["LME"]} | Maliyet: {dr["Maliyet"]} | Kur: {dr["DolarKuru"]}\n" +
                                    $"-------------------\n" +
                                    $"Kümülatif Maliyet: {sKumulatif} $/Ton\n" +
                                    $"Karlı Kümülatif: {sKarliKumulatif} $/Ton\n" + // Detaya eklendi
                                    $"-------------------\n" +
                                    $"TOPLAM: {dr["TeklifTotal"]} $";
                    pnlDetay.Visible = true;

                    if (this.Controls.Find("lblKumulatif", true).Length > 0)
                        this.Controls.Find("lblKumulatif", true)[0].Text = "Kümülatif: " + sKumulatif;

                    if (this.Controls.Find("lblKumulatifkarli", true).Length > 0)
                        this.Controls.Find("lblKumulatifkarli", true)[0].Text = "Karlı Kümülatif: " + sKarliKumulatif;

                    // 2. ÜRÜNLERİ GRİDE DOLDUR
                    dtUrunler.Rows.Clear();
                    pnlTeklif.Visible = true;

                    for (int i = 1; i <= 10; i++)
                    {
                        string uAd = dr[$"Urun{i}"].ToString();
                        if (!string.IsNullOrEmpty(uAd))
                        {
                            decimal uKg = Convert.ToDecimal(dr[$"Urun{i}Kg"]);

                            decimal lme = ParseDecimal(txtLME.Text);
                            decimal maliyet = ParseDecimal(txtMaliyet.Text);
                            decimal dolar = ParseDecimal(txtdolar.Text);

                            decimal kaplamaDegeri = 50;
                            var m = Regex.Match(uAd, @"\d+");
                            if (m.Success) kaplamaDegeri = decimal.Parse(m.Value);

                            // HESAPLAMA (Görünüm için)
                            decimal iscilik = maliyet - (((lme + 225m) * 6m) / 100m);
                            decimal tonbasiMaliyet = (((lme + 225m) * kaplamaDegeri) / 100m) + iscilik;

                            decimal satisFiyati = Convert.ToDecimal(dr[$"Urun{i}Tutar"]);
                            decimal satisToplamiDolar = (satisFiyati / 1000m) * uKg;
                            decimal tlKarsilik = Convert.ToDecimal(dr[$"Urun{i}TlKarsilik"]);

                            decimal kdvDolar = satisToplamiDolar * 1.20m;
                            decimal kdvTL = tlKarsilik * 1.20m;

                            DataRow row = dtUrunler.NewRow();
                            row["colKaplama"] = uAd;
                            row["colKg"] = uKg;
                            row["colTonbasi"] = tonbasiMaliyet.ToString("N2");
                            row["colTl"] = tlKarsilik.ToString("N2");
                            row["colKar"] = satisFiyati.ToString("N2");
                            row["colKDVdolar"] = kdvDolar.ToString("N2");
                            row["colKDVTL"] = kdvTL.ToString("N2");

                            row["rawTonFiyati"] = satisFiyati;
                            row["rawTonMaliyeti"] = tonbasiMaliyet;
                            row["rawToplamTutar"] = satisToplamiDolar;
                            row["rawTLKarsilik"] = tlKarsilik;

                            dtUrunler.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            if (dtUrunler.Rows.Count == 0) return;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // --- 1. AYARLAR VE FONTLAR ---
            int startX = 40;
            int startY = 40;
            int margin = 40;
            int pageWidth = e.PageBounds.Width;
            int tableWidth = pageWidth - (margin * 2);
            int y = startY;

            // Renkler ve Kalemler
            Pen blackPen = new Pen(Color.Black, 1);
            Pen grayPen = new Pen(Color.Gray, 1);
            SolidBrush headerBrush = new SolidBrush(Color.FromArgb(240, 240, 240)); // Tablo başlığı gri zemin
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            // Fontlar
            Font titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
            Font companyFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font subHeaderFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font tableHeaderFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font cellFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font totalFont = new Font("Segoe UI", 12, FontStyle.Bold);

            // Hizalama (Sayılar sağa, Metinler sola)
            StringFormat centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            StringFormat leftFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

            // --- 2. ÜST BİLGİ (HEADER) ---

            // Şirket Adı / Logo Yeri (Sol Üst)
            e.Graphics.DrawString("BARAN ÇELİK GALVANİZ SAN. LTD. ŞTİ.", titleFont, Brushes.DarkBlue, startX, y);
            y += 35;
            e.Graphics.DrawString("Adres: Saray Mahallesi Dağyaka Caddesi No:4 Kahramankazan / ANKARA", new Font("Segoe UI", 9), Brushes.Gray, startX, y);
            y += 15;
            e.Graphics.DrawString("Tel: (0312) 815 53 52 | Web: www.barancelik.com.tr", new Font("Segoe UI", 9), Brushes.Gray, startX, y);

            // Teklif Bilgileri (Sağ Üst)
            int infoBoxX = pageWidth - 250;
            int infoBoxY = startY;
            e.Graphics.DrawString($"TARİH: {DateTime.Now:dd.MM.yyyy}", companyFont, blackBrush, infoBoxX, infoBoxY);
            e.Graphics.DrawString($"TEKLİF NO: #{aktifTeklifID}", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Red, infoBoxX, infoBoxY + 20);

            y += 40;
            e.Graphics.DrawLine(blackPen, startX, y, pageWidth - margin, y); // Ayırıcı Çizgi
            y += 20;

            // --- 3. MÜŞTERİ BİLGİSİ ---
            e.Graphics.DrawString("SAYIN:", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Gray, startX, y);
            y += 15;
            e.Graphics.DrawString(aktifMusteriAdi.ToUpper(), subHeaderFont, blackBrush, startX, y);
            y += 40;

            // --- 4. TABLO BAŞLIKLARI ---

            // Sütun Genişlikleri ve Konumları (Toplam genişlik ~750px)
            int col1_X = startX; int col1_W = 250; // Kaplama
            int col2_X = col1_X + col1_W; int col2_W = 100; // KG
            int col3_X = col2_X + col2_W; int col3_W = 150; // Birim Fiyat
            int col4_X = col3_X + col3_W; int col4_W = 150; // Tutar

            int rowHeight = 30;

            // Başlık Arka Planı
            e.Graphics.FillRectangle(headerBrush, startX, y, tableWidth, rowHeight);
            e.Graphics.DrawRectangle(blackPen, startX, y, tableWidth, rowHeight);

            // Başlık Yazıları
            e.Graphics.DrawString("ÜRÜN / HİZMET", tableHeaderFont, blackBrush, new RectangleF(col1_X + 5, y, col1_W, rowHeight), leftFormat);
            e.Graphics.DrawString("MİKTAR (KG)", tableHeaderFont, blackBrush, new RectangleF(col2_X, y, col2_W, rowHeight), centerFormat);
            e.Graphics.DrawString("BİRİM ($/TON)", tableHeaderFont, blackBrush, new RectangleF(col3_X, y, col3_W, rowHeight), centerFormat);
            e.Graphics.DrawString("TUTAR ($)", tableHeaderFont, blackBrush, new RectangleF(col4_X - 5, y, col4_W, rowHeight), rightFormat);

            y += rowHeight;

            // --- 5. ÜRÜNLERİ LİSTELEME ---
            decimal genelToplam = 0;

            foreach (DataRow row in dtUrunler.Rows)
            {
                string urun = row["colKaplama"].ToString();
                string kg = row["colKg"].ToString();

                // Verileri alırken formatlayalım
                decimal dKar = Convert.ToDecimal(row["rawTonFiyati"]);
                decimal dTot = Convert.ToDecimal(row["rawToplamTutar"]);
                genelToplam += dTot;

                string birimFiyat = dKar.ToString("N2");
                string satirTutar = dTot.ToString("N2");

                // Satır Çizgisi
                e.Graphics.DrawRectangle(grayPen, startX, y, tableWidth, rowHeight);

                // Hücreleri Yazdır
                e.Graphics.DrawString(urun, cellFont, blackBrush, new RectangleF(col1_X + 5, y, col1_W, rowHeight), leftFormat);
                e.Graphics.DrawString(kg, cellFont, blackBrush, new RectangleF(col2_X, y, col2_W, rowHeight), centerFormat);
                e.Graphics.DrawString(birimFiyat, cellFont, blackBrush, new RectangleF(col3_X, y, col3_W, rowHeight), centerFormat);
                e.Graphics.DrawString(satirTutar, cellFont, blackBrush, new RectangleF(col4_X - 5, y, col4_W, rowHeight), rightFormat);

                y += rowHeight;
            }

            // --- 6. TOPLAM KISMI ---
            y += 10;
            int totalBoxX = col3_X; // Son iki sütunun altına gelsin

            // Ara Toplam
            e.Graphics.DrawString("ARA TOPLAM:", tableHeaderFont, blackBrush, new RectangleF(totalBoxX, y, col3_W, rowHeight), rightFormat);
            e.Graphics.DrawString(genelToplam.ToString("N2") + " $", cellFont, blackBrush, new RectangleF(col4_X - 5, y, col4_W, rowHeight), rightFormat);
            y += 25;

            // KDV (%20 Örnek)
            decimal kdvTutar = genelToplam * 0.20m;
            e.Graphics.DrawString("KDV (%20):", tableHeaderFont, blackBrush, new RectangleF(totalBoxX, y, col3_W, rowHeight), rightFormat);
            e.Graphics.DrawString(kdvTutar.ToString("N2") + " $", cellFont, blackBrush, new RectangleF(col4_X - 5, y, col4_W, rowHeight), rightFormat);
            y += 25;

            // Genel Toplam (Koyu ve Büyük)
            decimal grandTotal = genelToplam + kdvTutar;
            e.Graphics.FillRectangle(headerBrush, totalBoxX, y, col3_W + col4_W, 40); // Arka plan
            e.Graphics.DrawString("GENEL TOPLAM:", totalFont, Brushes.DarkBlue, new RectangleF(totalBoxX, y, col3_W, 40), rightFormat);
            e.Graphics.DrawString(grandTotal.ToString("N2") + " $", totalFont, Brushes.DarkBlue, new RectangleF(col4_X - 5, y, col4_W, 40), rightFormat);

            // --- 7. ALT BİLGİ (FOOTER) ---
            int pageBottom = e.PageBounds.Height - 100;
            e.Graphics.DrawLine(blackPen, startX, pageBottom, pageWidth - margin, pageBottom);
            e.Graphics.DrawString("Notlar:", new Font("Segoe UI", 9, FontStyle.Bold), blackBrush, startX, pageBottom + 10);
            e.Graphics.DrawString("\n- Teklifimiz 3 gün geçerlidir.\n- Malzeme sevkinden önce peşin ödeme sonucu teslim edilir.", new Font("Segoe UI", 8), Brushes.Gray, startX, pageBottom + 30);

            // Sayfa No (En alt sağ)
            e.Graphics.DrawString("Sayfa 1/1", new Font("Segoe UI", 8), Brushes.Black, pageWidth - margin - 50, pageBottom + 60);
        }
        private void KaplamalariGetir()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try { conn.Open(); SqlCommand cmd = new SqlCommand("SELECT KaplamaAdi FROM Kaplamalar", conn); SqlDataReader dr = cmd.ExecuteReader(); cmbKaplama.Items.Clear(); while (dr.Read()) cmbKaplama.Items.Add(dr[0].ToString()); if (cmbKaplama.Items.Count > 0) cmbKaplama.SelectedIndex = 0; } catch { }
            }
        }
    }
}