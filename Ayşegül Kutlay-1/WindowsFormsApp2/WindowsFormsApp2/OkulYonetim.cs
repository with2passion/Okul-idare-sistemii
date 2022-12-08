using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Models;

namespace WindowsFormsApp2
{
    public partial class OkulYonetim : Form
    {
        public OkulYonetim()
        {
            InitializeComponent();
        }
        WFormDBEntities db;

        void listele()
        {
            db = new WFormDBEntities();
            dataGridView1.DataSource = (from x in db.OkulYonetimTab
                                        select new
                                        {
                                            x.Id,
                                            x.AdSoyad,
                                            x.Gorevi,
                                            x.YonetimTip,
                                        }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OkulYonetimTab ekle = new OkulYonetimTab();
            ekle.AdSoyad = txtad.Text;
            ekle.Gorevi = txtgorev.Text;
            ekle.YonetimTip = Convert.ToInt32(txtip.Text);
            db.OkulYonetimTab.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("İşlem başarılı");
            listele();

            txtid.Clear();
            txtad.Clear();
            txtgorev.Clear();
            txtip.Clear();
        }

        private void OkulYonetim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int OkulYonetimId = Convert.ToInt32(txtid.Text);

            var guncelle = db.OkulYonetimTab.Find(OkulYonetimId);
            guncelle.AdSoyad = txtad.Text;
            guncelle.Gorevi = txtgorev.Text;
            guncelle.YonetimTip = Convert.ToInt32(txtip.Text);
            db.SaveChanges();
            MessageBox.Show("Okul Yonetim Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int OkulYonetimId = Convert.ToInt32(txtid.Text);

            var OkulYonetimbul = db.OkulYonetimTab.Find(OkulYonetimId);
            db.OkulYonetimTab.Remove(OkulYonetimbul);
            db.SaveChanges();
            MessageBox.Show("Okul Yonetim Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtgorev.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtip.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }
    }
}
