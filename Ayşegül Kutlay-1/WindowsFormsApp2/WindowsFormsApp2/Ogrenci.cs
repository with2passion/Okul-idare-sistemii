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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }
        WFormDBEntities db;

        void listele()
        {
            db = new WFormDBEntities();
            dataGridView1.DataSource = (from x in db.OgrenciTab
                                        select new
                                        {
                                            x.Id,
                                            x.AdSoyad,
                                            x.KayitTarih,
                                            x.OgrenciNo,
                                            x.DTarih,
                                            x.Bolum,
                                        }).ToList();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            OgrenciTab ekle = new OgrenciTab();
            ekle.AdSoyad = txtad.Text;
            ekle.KayitTarih = txtkayit.Text;
            ekle.OgrenciNo = Convert.ToInt32(txtno.Text);
            ekle.DTarih = txtdogum.Text;
            ekle.Bolum = txtbolum.Text;
            db.OgrenciTab.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("İşlem başarılı");
            listele();

            txtid.Clear();
            txtad.Clear();
            txtkayit.Clear();
            txtno.Clear();
            txtdogum.Clear();
            txtbolum.Clear();
        }

        private void Ogrenci_Load_1(object sender, EventArgs e)
        {
            listele();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var guncelle = db.OgrenciTab.Find(OgrenciId);
            guncelle.AdSoyad = txtad.Text;
            guncelle.KayitTarih = txtkayit.Text;
            guncelle.OgrenciNo = Convert.ToInt32(txtno.Text);
            guncelle.DTarih = txtdogum.Text;
            guncelle.Bolum = txtbolum.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }


        private void btnSil_Click_1(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var ogrencibul = db.OgrenciTab.Find(OgrenciId);
            db.OgrenciTab.Remove(ogrencibul);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }



        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtkayit.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtno.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtdogum.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtbolum.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            var degerler = from item in db.OgrenciTab
                           where item.AdSoyad.Contains(aranan)
                           // where item.KayitTarih.ToString().Contains(aranan)
                           // where item.OgrenciNo.ToString().Contains(aranan)
                           // where item.DTarih.ToString().Contains(aranan)
                           // where item.Bolum.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
