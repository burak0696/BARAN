using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BARAN
{
    public partial class galvaniz : Form
    {
        private int aktifMusteriID;
        private string aktifMusteriAdi;
        private int aktifTeklifID;
        private int urunSayac = 1;
        private decimal lmeDegeri = 0;
        private decimal maliyetDegeri = 0;
        private string connStr = "Server=localhost\\SQL;Database=LoginDB;Trusted_Connection=True;";

        public galvaniz()
        {
            InitializeComponent();
        }

        private void galvaniz_Load(object sender, EventArgs e)
        {
            MusteriListesiniGetir("");
        }

        private void MusteriListesiniGetir(string filtre)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT MusteriID, Ad, Soyad FROM Musteri WHERE LOWER(Ad) LIKE @filtre OR LOWER(Soyad) LIKE @filtre", conn);
                cmd.Parameters.AddWithValue("@filtre", "%" + filtre.ToLower() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMusteriler.DataSource = dt;
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
                aktifTeklifID = (int)cmd.ExecuteScalar();
            }

            pnlTeklif.Visible = true;
            KaplamaListesiniYukle();
            UrunListesiGuncelle();
        }

        private void KaplamaListesiniYukle()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT KaplamaAdi FROM Kaplamalar", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKaplama.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbKaplama.Items.Add(row["KaplamaAdi"].ToString());
                }
            }
        }
        private void btnTeklifKaydet_Click(object sender, EventArgs e)
        {
            // Girişler
            if (!decimal.TryParse(txtLME.Text, out decimal girilenLme) ||
                !decimal.TryParse(txtMaliyet.Text, out decimal girilenMaliyet))
            {
                MessageBox.Show("LME ve Maliyet değerlerini girin.");
                return;
            }

            // LME’ye +225 ekle
            decimal LME = girilenLme + 225m;
            decimal Maliyet = girilenMaliyet;
            DateTime now = DateTime.Now; // tarih/saat

            // Yeni teklif kaydı
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Teklifler (LME, Maliyet, Tarih) VALUES (@lme, @maliyet, @tarih); SELECT SCOPE_IDENTITY();",
                conn))
            {
                cmd.Parameters.AddWithValue("@lme", LME);
                cmd.Parameters.AddWithValue("@maliyet", Maliyet);
                cmd.Parameters.AddWithValue("@tarih", now);

                conn.Open();
                object yeniId = cmd.ExecuteScalar();
                aktifTeklifID = Convert.ToInt32(yeniId);
            }

            // Yeni kayıtta ürün sırası baştan başlasın
            urunSayac = 0;

            // Alttaki geçmiş teklifler gridini yenile
            GecmisTeklifleriYukle();
        }
        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT TeklifID, Tarih FROM Teklifler WHERE MusteriID=@mid", conn);
                cmd.Parameters.AddWithValue("@mid", aktifMusteriID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGecmisTeklifler.DataSource = dt;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void dgvGecmisTeklifler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int teklifID = Convert.ToInt32(dgvGecmisTeklifler.Rows[e.RowIndex].Cells["TeklifID"].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Teklifler WHERE TeklifID=@tid", conn);
                cmd.Parameters.AddWithValue("@tid", teklifID);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string detay = $"Teklif ID: {teklifID}\nTarih: {rdr["Tarih"]}\n";
                    for (int i = 1; i <= 10; i++)
                    {
                        string urun = rdr["Urun" + i]?.ToString();
                        string kg = rdr["Urun" + i + "Kg"]?.ToString();
                        string tutar = rdr["Urun" + i + "Tutar"]?.ToString();
                        if (!string.IsNullOrEmpty(urun))
                        {
                            detay += $"\nUrun{i}: {urun}, Kg: {kg}, Tutar: {tutar}";
                        }
                    }
                    lblDetay.Text = detay;
                    pnlDetay.Visible = true;
                }
            }
        }
        private void GecmisTeklifleriYukle()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT TeklifID, Tarih FROM Teklifler ORDER BY TeklifID DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGecmisTeklifler.DataSource = dt;
                dgvGecmisTeklifler.Visible = true;
            }
        }
      

        // SADECE mevcut DataGridView için (ör. dgvUrunler)
        // Ekstra grid yaratma YOK.
        private void HazirlaUrunGrid()
        {
            dgvUrunler.AutoGenerateColumns = false;
            dgvUrunler.Columns.Clear();

            dgvUrunler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Urun", HeaderText = "Ürün", Width = 220 });
            dgvUrunler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kg", HeaderText = "Kg", Width = 150 });
            dgvUrunler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tutar", HeaderText = "Tutar", Width = 180 });
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (aktifTeklifID <= 0)
            {
                MessageBox.Show("Önce Kaydet ile yeni teklif oluşturun.");
                return;
            }
            if (cmbKaplama.SelectedItem == null) { MessageBox.Show("Kaplama seçin."); return; }
            if (!decimal.TryParse(txtKg.Text, out decimal girilenKg) || girilenKg <= 0) { MessageBox.Show("Kg geçersiz."); return; }

            // LME ve Maliyet (gerekirse kutulardan veya bellektekinden)
            if (!decimal.TryParse(txtLME.Text, out decimal girilenLme) ||
                !decimal.TryParse(txtMaliyet.Text, out decimal girilenMaliyet))
            {
                MessageBox.Show("LME ve Maliyet değerlerini girin."); return;
            }

            decimal birimFiyat = (girilenLme + 225m) + girilenMaliyet;
            decimal toplamTutar = birimFiyat * girilenKg;

            // Sıradaki ürün numarası
            urunSayac++;

            string alanUrun = $"Urun{urunSayac}";
            string alanKg = $"Urun{urunSayac}Kg";
            string alanTutar = $"Urun{urunSayac}Tutar";
            string secilenKaplama = cmbKaplama.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(
                $"UPDATE Teklifler SET {alanUrun}=@u, {alanKg}=@kg, {alanTutar}=@tutar WHERE TeklifID=@tid", conn))
            {
                cmd.Parameters.AddWithValue("@u", secilenKaplama);
                cmd.Parameters.AddWithValue("@kg", girilenKg);
                cmd.Parameters.AddWithValue("@tutar", toplamTutar);
                cmd.Parameters.AddWithValue("@tid", aktifTeklifID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Grid’e etiketli satır ekle (tek grid)
            dgvUrunler.Rows.Add(
                $"Urun{urunSayac}: {secilenKaplama}",
                $"Urun{urunSayac}Kg: {girilenKg:N2}",
                $"Urun{urunSayac}Tutar: {toplamTutar:N2}"
            );

            txtKg.Clear();
        }
        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0) return;

            int index = dgvUrunler.SelectedRows[0].Index + 1; // Urun1 → index 1

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"UPDATE Teklifler SET Urun{index}=NULL, Urun{index}Kg=NULL, Urun{index}Tutar=NULL WHERE TeklifID=@tid", conn);
                cmd.Parameters.AddWithValue("@tid", aktifTeklifID);
                cmd.ExecuteNonQuery();
            }

            dgvUrunler.Rows.RemoveAt(index - 1);
        }

        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            if (lvUrunler.SelectedItems.Count == 0) return;
            int index = lvUrunler.SelectedIndices[0];
            cmbKaplama.Text = lvUrunler.Items[index].SubItems[0].Text;
            txtKg.Text = lvUrunler.Items[index].SubItems[1].Text;
            urunSayac = index + 1;
        }

        private void btnGecmisTeklifler_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT TeklifID, Tarih" +
                    "" +
                    "" +
                    "" +
                    " FROM Teklifler WHERE MusteriID=@mid", conn);
                cmd.Parameters.AddWithValue("@mid", aktifMusteriID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGecmisTeklifler.DataSource = dt;
                dgvGecmisTeklifler.Visible = true;
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF çıktısı alma özelliği için PdfSharp veya iTextSharp entegrasyonu yapılmalıdır.");
        }

        private void UrunListesiGuncelle()
        {
            lvUrunler.Items.Clear();
            dgvUrunler.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Teklifler WHERE TeklifID=@tid", conn);
                cmd.Parameters.AddWithValue("@tid", aktifTeklifID);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        string urun = rdr["Urun" + i]?.ToString();
                        string kg = rdr["Urun" + i + "Kg"]?.ToString();
                        string tutar = rdr["Urun" + i + "Tutar"]?.ToString();

                        if (!string.IsNullOrEmpty(urun))
                        {
                            lvUrunler.Items.Add(new ListViewItem(new[] {
                                urun,
                                string.IsNullOrEmpty(kg) ? "0" : Convert.ToDecimal(kg).ToString("N2"),
                                string.IsNullOrEmpty(tutar) ? "0" : Convert.ToDecimal(tutar).ToString("N2")
                            }));

                            dgvUrunler.Rows.Add(
                                urun,
                                string.IsNullOrEmpty(kg) ? "0" : Convert.ToDecimal(kg).ToString("N2"),
                                string.IsNullOrEmpty(tutar) ? "0" : Convert.ToDecimal(tutar).ToString("N2")
                            );
                        }
                    }
                }
            }
        }
    }
}