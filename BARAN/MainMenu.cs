using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace BARAN
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        private void btnGalvaniz_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new galvaniz())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this); // modal açılır
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Galvaniz formu açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnMusteri_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new musteri())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this); // veya frm.Show(); isterseniz modeless açar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri formu açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunAra_Click(object sender, EventArgs e)
        {
            UrunAra urunForm = new UrunAra();
            urunForm.ShowDialog();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // sadece kullanıcı kapattıysa
                Application.Exit(); // tüm uygulamayı kapat
        }
    }
}
