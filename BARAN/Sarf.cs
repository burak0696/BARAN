using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BARAN
{
    public partial class Sarf : Form
    {
        // VERİTABANI BAĞLANTISI (Kendi bilgisayarına göre ayarla)
        string connStr = "Server=localhost\\SQL;Database=LoginDB;Trusted_Connection=True;";
        DataTable dtTalep = new DataTable();

        public Sarf()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // SEPET YAPISI
            dtTalep.Columns.Add("UrunId", typeof(int));
            dtTalep.Columns.Add("Barkod");
            dtTalep.Columns.Add("UrunAdi");
            dtTalep.Columns.Add("Miktar", typeof(int));
            dtTalep.Columns.Add("Birim");
            dgvTalepSepet.DataSource = dtTalep;

            // Gizli ID kolonunu sakla
            if (dgvTalepSepet.Columns["UrunId"] != null) dgvTalepSepet.Columns["UrunId"].Visible = false;

            // LOG FİLTRELERİ
            cmbIslemTuru.Items.Clear();
            cmbIslemTuru.Items.AddRange(new object[] { "Tümü", "Talepler", "Teklifler", "Girişler", "Çıkışlar" });
            cmbIslemTuru.SelectedIndex = 0;

            dtpBaslangic.Value = DateTime.Now.AddDays(-30);
            dtpBitis.Value = DateTime.Now;

            SayfaGoster(pnlTalepSayfasi, "1. TALEP OLUŞTURMA");
        }

        private void SayfaGoster(Panel pnl, string baslik)
        {
            pnlTalepSayfasi.Visible = false; pnlTeklifSayfasi.Visible = false;
            pnlOnaySayfasi.Visible = false; pnlStokSayfasi.Visible = false;
            pnlDusumSayfasi.Visible = false; pnlLogSayfasi.Visible = false;

            pnl.Visible = true;
            pnl.Dock = DockStyle.Fill;
            lblBaslik.Text = baslik;
        }

        // --- MENÜLER ---
        private void btnMenuTalep_Click(object sender, EventArgs e) => SayfaGoster(pnlTalepSayfasi, "1. TALEP OLUŞTURMA");
        private void btnMenuTeklif_Click(object sender, EventArgs e) { SayfaGoster(pnlTeklifSayfasi, "2. TEKLİF & FİYAT GİRİŞİ"); TeklifListesiYukle(); }
        private void btnMenuOnay_Click(object sender, EventArgs e) { SayfaGoster(pnlOnaySayfasi, "3. YÖNETİCİ ONAY EKRANI"); OnayListesiYukle(); }
        private void btnMenuStok_Click(object sender, EventArgs e) { SayfaGoster(pnlStokSayfasi, "4. DEPO MAL KABUL"); GirisListesiYukle(); }
        private void btnMenuDusum_Click(object sender, EventArgs e) { SayfaGoster(pnlDusumSayfasi, "5. SARF / STOK DÜŞÜM"); StokDurumListesiYukle(); }
        private void btnMenuLog_Click(object sender, EventArgs e) { SayfaGoster(pnlLogSayfasi, "6. HAREKET LOGLARI"); LoglariGetir(); }
        private void btnMenuCikis_Click(object sender, EventArgs e) => Application.Exit();

        private void ListeleriYukle(DataGridView dgv, string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;

                    // Teknik ID kolonlarını kullanıcıdan gizle ama erişilebilir olsun
                    if (dgv.Columns["KayitId"] != null) dgv.Columns["KayitId"].Visible = false;
                    if (dgv.Columns["UrunId"] != null) dgv.Columns["UrunId"].Visible = false;
                    if (dgv.Columns["TalepNo"] != null) dgv.Columns["TalepNo"].Visible = false; // Gizli ama erişilebilir
                }
            }
            catch (Exception ex) { MessageBox.Show("Veri Listeleme Hatası: " + ex.Message); }
        }

        // ================= 1. TALEP MODÜLÜ =================
        private void btnUrunBul_Click(object sender, EventArgs e) => UrunAra(txtArama.Text);
        private void txtArama_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) UrunAra(txtArama.Text); }

        private void UrunAra(string txt)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Urunler WHERE Barkod LIKE @p OR UrunAdi LIKE @p", con);
                da.SelectCommand.Parameters.AddWithValue("@p", "%" + txt + "%");
                DataTable dt = new DataTable(); da.Fill(dt);

                UrunSecimFormu f = new UrunSecimFormu(dt);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    da.SelectCommand.CommandText = "SELECT * FROM Urunler WHERE Id=" + f.SecilenId;
                    DataTable t = new DataTable(); da.Fill(t);
                    if (t.Rows.Count > 0) UrunSec(t.Rows[0]);
                }
                else if (f.YeniEkleIstegi)
                {
                    pnlPopup.Visible = true; pnlPopup.BringToFront(); txtPopBarkod.Text = txt;
                }
            }
        }
        private void UrunSec(DataRow r) { lblGizliId.Text = r["Id"].ToString(); lblGizliBirim.Text = r["Birim"].ToString(); lblUrunBilgi.Text = r["UrunAdi"].ToString() + " (" + r["Birim"] + ")"; txtArama.Text = ""; }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblGizliId.Text)) return;
            string urunAdi = lblUrunBilgi.Text.Contains("(") ? lblUrunBilgi.Text.Split('(')[0].Trim() : lblUrunBilgi.Text;
            dtTalep.Rows.Add(int.Parse(lblGizliId.Text), "-", urunAdi, numMiktar.Value, lblGizliBirim.Text);
            lblGizliId.Text = ""; lblUrunBilgi.Text = "..."; numMiktar.Value = 1;
        }

        private void btnTalepGonder_Click(object sender, EventArgs e)
        {
            if (dtTalep.Rows.Count == 0) return;

            // Benzersiz Talep No (Saniye + Random)
            string no = "TLP-" + DateTime.Now.ToString("yyMMdd-HHmmss") + "-" + new Random().Next(10, 99).ToString();

            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Talepler (TalepNo,TalepEden,Aciklama,AsamaKodu,Durum,Tarih) VALUES (@n,@t,@a,1,'Talep',GETDATE())", con);
                    cmd.Parameters.AddWithValue("@n", no); cmd.Parameters.AddWithValue("@t", txtTalepEden.Text); cmd.Parameters.AddWithValue("@a", txtAciklama.Text);
                    cmd.ExecuteNonQuery();

                    int sira = 1;
                    foreach (DataRow r in dtTalep.Rows)
                    {
                        string ozelTeklifNo = no + "/" + sira;
                        // OnayDurumu 0: Yeni Talep
                        new SqlCommand($"INSERT INTO TalepDetay (TalepNo,UrunId,Miktar,OnayDurumu,TeklifSira,TeklifNo) VALUES ('{no}',{r["UrunId"]},{r["Miktar"]},0,{sira},'{ozelTeklifNo}')", con).ExecuteNonQuery();
                        sira++;
                    }
                }
                MessageBox.Show("Talep Oluşturuldu. No: " + no); dtTalep.Rows.Clear(); txtAciklama.Text = ""; txtTalepEden.Text = "";
            }
            catch (Exception ex) { MessageBox.Show("Kayıt Hatası: " + ex.Message); }
        }

        // ================= 2. TEKLİF & FİYAT MODÜLÜ (KRİTİK DÜZELTME) =================
        private void TeklifListesiYukle()
        {
            dgvTeklifListesi.DataSource = null; dgvTeklifListesi.Columns.Clear();

            // "TalepNo Not Found" hatası için SQL'e T.TalepNo EKLENDİ.
            // Ayrıca OnayDurumu 3 (Yönetici Bekleyen) olanlar da görünsün ki kaybolmasın.
            string sql = @"SELECT TD.Id as KayitId, T.TalepNo, TD.TeklifSira as [Sira], TD.TeklifNo, T.TalepEden, U.UrunAdi, TD.Marka, TD.Miktar, TD.BirimFiyat, TD.ParaBirimi, TD.Tedarikci,
                           CASE WHEN TD.OnayDurumu=3 THEN 'ONAY BEKLİYOR' ELSE 'YENİ' END as Durum
                           FROM TalepDetay TD 
                           JOIN Talepler T ON TD.TalepNo=T.TalepNo 
                           JOIN Urunler U ON TD.UrunId=U.Id 
                           WHERE T.AsamaKodu IN(1,2) AND (TD.OnayDurumu=0 OR TD.OnayDurumu=3)
                           ORDER BY T.TalepNo DESC, TD.TeklifSira ASC";

            ListeleriYukle(dgvTeklifListesi, sql);

            // Para Birimi Combobox
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "P.Birimi"; cmb.Name = "cmbParaBirimi"; cmb.Items.AddRange("TL", "USD", "EUR"); cmb.DataPropertyName = "ParaBirimi";

            if (dgvTeklifListesi.Columns.Count > 10) dgvTeklifListesi.Columns.Insert(10, cmb); else dgvTeklifListesi.Columns.Add(cmb);
            dgvTeklifListesi.Columns["ParaBirimi"].Visible = false;

            dgvTeklifListesi.ReadOnly = false;
            foreach (DataGridViewColumn c in dgvTeklifListesi.Columns)
                if (c.Name != "BirimFiyat" && c.Name != "Tedarikci" && c.Name != "cmbParaBirimi" && c.Name != "Marka") c.ReadOnly = true;
        }

        private void mnuSatirCogalt_Click(object sender, EventArgs e)
        {
            if (dgvTeklifListesi.SelectedRows.Count == 0) return;
            // Kayıt ID yoksa işlem yapma
            if (dgvTeklifListesi.SelectedRows[0].Cells["KayitId"].Value == null) return;

            int id = Convert.ToInt32(dgvTeklifListesi.SelectedRows[0].Cells["KayitId"].Value);
            string yeniNo = "ALT-" + new Random().Next(1000, 9999);

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmdSira = new SqlCommand("SELECT ISNULL(MAX(TeklifSira),0) + 1 FROM TalepDetay WHERE TalepNo=(SELECT TalepNo FROM TalepDetay WHERE Id=" + id + ") AND UrunId=(SELECT UrunId FROM TalepDetay WHERE Id=" + id + ")", con);
                int yeniSira = (int)cmdSira.ExecuteScalar();
                new SqlCommand($"INSERT INTO TalepDetay (TalepNo,UrunId,Miktar,BirimFiyat,ParaBirimi,Tedarikci,OnayDurumu,TeklifSira,TeklifNo) SELECT TalepNo,UrunId,Miktar,0,'TL','YENİ TEDARİKÇİ',0,{yeniSira},'{yeniNo}' FROM TalepDetay WHERE Id=" + id, con).ExecuteNonQuery();
            }
            TeklifListesiYukle();
        }

        private void btnFiyatKaydet_Click(object sender, EventArgs e)
        {
            if (dgvTeklifListesi.SelectedRows.Count == 0) { MessageBox.Show("Lütfen onaya gönderilecek satırları seçiniz."); return; }
            dgvTeklifListesi.EndEdit();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                foreach (DataGridViewRow r in dgvTeklifListesi.SelectedRows)
                {
                    if (r.Cells["KayitId"].Value == null) continue;

                    int kid = Convert.ToInt32(r.Cells["KayitId"].Value);
                    decimal f = 0; decimal.TryParse(r.Cells["BirimFiyat"].Value?.ToString(), out f);
                    string t = r.Cells["Tedarikci"].Value?.ToString();
                    string p = r.Cells["cmbParaBirimi"].Value?.ToString();
                    string m = r.Cells["Marka"].Value?.ToString();

                    // OnayDurumu = 3 (Yönetici Onayı Bekliyor)
                    SqlCommand cmd = new SqlCommand("UPDATE TalepDetay SET BirimFiyat=@f, Tedarikci=@t, ParaBirimi=@p, Marka=@m, OnayDurumu=3 WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@f", f);
                    cmd.Parameters.AddWithValue("@t", t ?? "");
                    cmd.Parameters.AddWithValue("@p", p ?? "TL");
                    cmd.Parameters.AddWithValue("@m", m ?? "");
                    cmd.Parameters.AddWithValue("@id", kid);
                    cmd.ExecuteNonQuery();

                    // Ana Talebin Durumunu Güncelle (Eğer TalepNo kolonu gridde varsa)
                    if (r.Cells["TalepNo"].Value != null)
                    {
                        string talepNo = r.Cells["TalepNo"].Value.ToString();
                        new SqlCommand($"UPDATE Talepler SET AsamaKodu=2, Durum='Onay Bekliyor' WHERE TalepNo='{talepNo}'", con).ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Seçilen teklifler onaya gönderildi.");
            TeklifListesiYukle();
        }

        // ================= 3. YÖNETİCİ ONAYI =================
        private void OnayListesiYukle()
        {
            // Sadece OnayBekleyen(3) veya Yeni(0) kayıtlar
            // TalepNo burada da lazım olabilir, ekliyoruz.
            string sql = @"SELECT TD.Id as KayitId, TD.TeklifNo, T.TalepNo, T.TalepEden, U.UrunAdi, TD.Marka, TD.Miktar, TD.BirimFiyat, TD.ParaBirimi, TD.Tedarikci,
                           CASE WHEN TD.OnayDurumu=3 THEN 'ONAY BEKLİYOR' ELSE 'YENİ' END as Durum 
                           FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id 
                           WHERE T.AsamaKodu=2 AND (TD.OnayDurumu=3 OR TD.OnayDurumu=0)
                           ORDER BY T.TalepNo DESC";
            ListeleriYukle(dgvOnayListesi, sql);
        }
        private void btnOnayla_Click(object sender, EventArgs e) => OnayIslem(1);
        private void btnReddet_Click(object sender, EventArgs e) => OnayIslem(2);
        private void btnBeklemeyeAl_Click(object sender, EventArgs e) => OnayIslem(3);

        private void OnayIslem(int durum)
        {
            if (dgvOnayListesi.SelectedRows.Count == 0) { MessageBox.Show("Lütfen satır seçin."); return; }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                foreach (DataGridViewRow r in dgvOnayListesi.SelectedRows)
                {
                    int id = Convert.ToInt32(r.Cells["KayitId"].Value);
                    new SqlCommand($"UPDATE TalepDetay SET OnayDurumu={durum} WHERE Id={id}", con).ExecuteNonQuery();
                }
            }
            OnayListesiYukle();
        }

        // ================= 4. DEPO MAL KABUL (BELGESİZ DE KAYIT İMKANI) =================
        private void GirisListesiYukle()
        {
            // IrsaliyeNo BOŞ olanları getir
            string sql = @"SELECT TD.Id as KayitId, TD.TeklifNo, T.TalepNo, U.UrunAdi, TD.Marka, TD.Miktar 
                           FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id 
                           WHERE TD.OnayDurumu=1 AND (TD.IrsaliyeNo IS NULL OR TD.IrsaliyeNo='')";
            ListeleriYukle(dgvStokListesi, sql);
        }

        private void btnStogaIsle_Click(object sender, EventArgs e)
        {
            if (dgvStokListesi.SelectedRows.Count == 0) { MessageBox.Show("Lütfen listeden ürün seçiniz."); return; }

            // Belge No boşsa "BELGESİZ" yaz
            string girilenFatura = string.IsNullOrWhiteSpace(txtFaturaNo.Text) ? "BELGESİZ" : txtFaturaNo.Text;
            string girilenIrsaliye = string.IsNullOrWhiteSpace(txtIrsaliyeNo.Text) ? "BELGESİZ" : txtIrsaliyeNo.Text;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                foreach (DataGridViewRow r in dgvStokListesi.SelectedRows)
                {
                    int did = Convert.ToInt32(r.Cells["KayitId"].Value);

                    SqlDataReader dr = new SqlCommand("SELECT UrunId, Miktar, Marka FROM TalepDetay WHERE Id=" + did, con).ExecuteReader();

                    if (dr.Read())
                    {
                        int uid = (int)dr["UrunId"];
                        int m = (int)dr["Miktar"];
                        string mrk = dr["Marka"].ToString();
                        dr.Close();

                        // 1. Bilgileri Güncelle
                        SqlCommand cmdFat = new SqlCommand("UPDATE TalepDetay SET FaturaNo=@f, IrsaliyeNo=@i WHERE Id=@id", con);
                        cmdFat.Parameters.AddWithValue("@f", girilenFatura);
                        cmdFat.Parameters.AddWithValue("@i", girilenIrsaliye);
                        cmdFat.Parameters.AddWithValue("@id", did);
                        cmdFat.ExecuteNonQuery();

                        // 2. Stoğu Arttır
                        new SqlCommand($"UPDATE Urunler SET StokMiktari=StokMiktari+{m} WHERE Id={uid}", con).ExecuteNonQuery();

                        // 3. Log
                        string aciklama = $"Depo Girişi: {mrk} - {girilenIrsaliye}";
                        new SqlCommand($"INSERT INTO StokHareketleri (UrunId, Miktar, IslemTuru, TeslimAlan, Aciklama, Tarih) VALUES ({uid}, {m}, 'Giriş', '{girilenIrsaliye}', '{aciklama}', GETDATE())", con).ExecuteNonQuery();
                    }
                    else { dr.Close(); }
                }
            }
            MessageBox.Show("Seçilen ürünler stoğa işlendi.");
            txtFaturaNo.Clear(); txtIrsaliyeNo.Clear();
            GirisListesiYukle();
        }

        // ================= 5. DÜŞÜM =================
        private void StokDurumListesiYukle() { ListeleriYukle(dgvStokDurumu, "SELECT Id, Barkod, UrunAdi, StokMiktari, Birim FROM Urunler"); }
        private void TemizleDusum() { txtDusumBarkod.Clear(); lblDusumUrun.Text = "..."; lblDusumGizliId.Text = ""; numDusumMiktar.Value = 1; StokDurumListesiYukle(); }

        private void btnCikisBul_Click(object sender, EventArgs e)
        {
            string aranan = txtDusumBarkod.Text;
            if (string.IsNullOrEmpty(aranan)) return;
            ListeleriYukle(dgvStokDurumu, $"SELECT Id, Barkod, UrunAdi, StokMiktari, Birim FROM Urunler WHERE Barkod LIKE '%{aranan}%' OR UrunAdi LIKE '%{aranan}%'");
            if (dgvStokDurumu.Rows.Count > 0) dgvStokDurumu_CellClick(null, new DataGridViewCellEventArgs(0, 0));
        }
        private void btnTumunuGoster_Click(object sender, EventArgs e) { StokDurumListesiYukle(); }
        private void txtDusumBarkod_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCikisBul_Click(null, null); }

        private void dgvStokDurumu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStokDurumu.CurrentRow != null)
            {
                var r = dgvStokDurumu.CurrentRow;
                lblDusumGizliId.Text = r.Cells["Id"].Value.ToString();
                lblDusumUrun.Text = r.Cells["UrunAdi"].Value.ToString() + " (Stok: " + r.Cells["StokMiktari"].Value.ToString() + ")";
            }
        }

        private void btnDusumYap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblDusumGizliId.Text)) { MessageBox.Show("Ürün Seçiniz"); return; }
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                new SqlCommand($"UPDATE Urunler SET StokMiktari=StokMiktari-{numDusumMiktar.Value} WHERE Id={lblDusumGizliId.Text}", con).ExecuteNonQuery();
                new SqlCommand($"INSERT INTO StokHareketleri (UrunId, Miktar, IslemTuru, TeslimAlan, Aciklama, Tarih) VALUES ({lblDusumGizliId.Text}, {numDusumMiktar.Value}, 'Çıkış', '{txtDusumKime.Text}', '{txtDusumNeden.Text}', GETDATE())", con).ExecuteNonQuery();
            }
            MessageBox.Show("Stoktan Düşüldü."); TemizleDusum();
        }

        // --- 6. LOG (DÜZELTİLMİŞ) ---
        private void btnLogListele_Click(object sender, EventArgs e) { LoglariGetir(); }

        private void LoglariGetir()
        {
            string tarihFiltresi = "Tarih BETWEEN @t1 AND @t2";
            string urunFiltresi = string.IsNullOrEmpty(txtLogArama.Text) ? "" : $" AND UrunAdi LIKE '%{txtLogArama.Text}%'";
            string secim = cmbIslemTuru.Text;
            string sql = "";

            // RAKAM YERİNE MARKA GÖSTERİLECEK
            if (secim == "Girişler" || secim == "Çıkışlar")
            {
                sql = $@"SELECT 'Stok Hareket' as Tur, SH.Tarih, U.UrunAdi, SH.IslemTuru, SH.Miktar, SH.TeslimAlan as [Kişi/Firma], SH.Aciklama 
                         FROM StokHareketleri SH JOIN Urunler U ON SH.UrunId = U.Id 
                         WHERE {tarihFiltresi} AND IslemTuru LIKE '%{secim.Substring(0, 5)}%' {urunFiltresi}";
            }
            else if (secim == "Talepler")
            {
                sql = $@"SELECT 'Talep' as Tur, T.Tarih, U.UrunAdi, T.Durum, TD.Miktar, T.TalepEden as [Kişi/Firma], T.Aciklama 
                         FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id 
                         WHERE {tarihFiltresi} {urunFiltresi}";
            }
            else if (secim == "Teklifler")
            {
                // SADECE GÜNCEL TEKLİFLERİ DEĞİL, REDDEDİLENLERİ DE GÖSTERİR
                sql = $@"SELECT 'Teklif' as Tur, T.Tarih, U.UrunAdi, TD.Marka,
                         CASE WHEN TD.OnayDurumu=1 THEN 'ONAY' WHEN TD.OnayDurumu=2 THEN 'RED' ELSE 'BEKLIYOR' END as Durum, 
                         TD.BirimFiyat as Fiyat, TD.Tedarikci as [Kişi/Firma], 'Teklif No: ' + ISNULL(TD.TeklifNo,'-') as Aciklama 
                         FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id 
                         WHERE T.AsamaKodu >= 2 AND {tarihFiltresi} {urunFiltresi}";
            }
            else
            { // TÜMÜ
                sql = $@"
                    SELECT 'Stok' as Tur, SH.Tarih, U.UrunAdi, '-' as Marka, SH.IslemTuru as Durum, SH.Miktar, SH.TeslimAlan, SH.Aciklama FROM StokHareketleri SH JOIN Urunler U ON SH.UrunId=U.Id WHERE {tarihFiltresi} {urunFiltresi}
                    UNION ALL
                    SELECT 'Talep', T.Tarih, U.UrunAdi, '-' as Marka, T.Durum, TD.Miktar, T.TalepEden, T.Aciklama FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id WHERE {tarihFiltresi} {urunFiltresi}
                    UNION ALL
                    SELECT 'Teklif', T.Tarih, U.UrunAdi, TD.Marka, CASE WHEN TD.OnayDurumu=1 THEN 'ONAY' ELSE 'RED/BEKLE' END, TD.Miktar, TD.Tedarikci, CAST(TD.BirimFiyat as varchar) + ' ' + TD.ParaBirimi FROM TalepDetay TD JOIN Talepler T ON TD.TalepNo=T.TalepNo JOIN Urunler U ON TD.UrunId=U.Id WHERE T.AsamaKodu>=2 AND {tarihFiltresi} {urunFiltresi}
                    ORDER BY Tarih DESC";
            }

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@t1", dtpBaslangic.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@t2", dtpBitis.Value.Date.AddDays(1));
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLogListesi.DataSource = dt;
            }
        }



        // POPUP
        private void btnPopKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr)) { con.Open(); new SqlCommand($"INSERT INTO Urunler (Barkod,UrunAdi,StokMiktari,Birim) VALUES ('{txtPopBarkod.Text}','{txtPopAd.Text}',0,'{cmbPopBirim.Text}')", con).ExecuteNonQuery(); }
            pnlPopup.Visible = false;
        }
        private void btnPopKapat_Click(object sender, EventArgs e) => pnlPopup.Visible = false;
        private void btnYeniUrun_Click(object sender, EventArgs e) { pnlPopup.Visible = true; pnlPopup.BringToFront(); }
    }
}