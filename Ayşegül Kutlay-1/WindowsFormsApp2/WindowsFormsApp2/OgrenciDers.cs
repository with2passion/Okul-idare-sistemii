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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class OgrenciDers : Form
    {
        public OgrenciDers()
        {
            InitializeComponent();
        }
        WFormDBEntities db = new WFormDBEntities();

        void listele()
        {
            db = new WFormDBEntities();
            dataGridView1.DataSource = (from x in db.OgrenciDersTab
                                        select new
                                        {
                                            x.Id,
                                            x.DersTab.Ad,
                                            x.OgrenciTab.AdSoyad,
                                        }).ToList();
        }

        private void OgrenciDers_Load(object sender, EventArgs e)
        {
            listele();
            var ogrenciler = (from x in db.OgrenciTab
                              select new
                              {
                                  x.Id,
                                  x.AdSoyad

                              }).ToList();

            cmbogrenci.ValueMember = "Id";
            cmbogrenci.DisplayMember = "AdSoyad";
            cmbogrenci.DataSource = ogrenciler; listele();


            var dersler = (from x in db.DersTab
                           select new
                           {
                               x.Id,
                               x.Ad

                           }).ToList();

            cmbDers.ValueMember = "Id";
            cmbDers.DisplayMember = "Ad";
            cmbDers.DataSource = dersler; listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbDers.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            cmbogrenci.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult sor = new DialogResult();
            sor = MessageBox.Show("Seçilen Kayıt Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                int ogrencidersID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);


                var ogrencidersbul = db.OgrenciDersTab.Find(ogrencidersID);
                db.OgrenciDersTab.Remove(ogrencidersbul);
                db.SaveChanges();
                MessageBox.Show("Ders Ve Öğrenci İlişkisi Silinecektir. Onaylıyor musunuz?", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciDersTab ekle = new OgrenciDersTab();
            ekle.DersId = Convert.ToInt16(cmbDers.SelectedValue);
            ekle.OgrenciId = Convert.ToInt16(cmbogrenci.SelectedValue);
            db.OgrenciDersTab.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenciye Ders Ataması Yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int DersID = Convert.ToInt32(txtid.Text);

            var guncelle = db.OgrenciDersTab.Find(DersID);
            guncelle.Id = Convert.ToInt32(txtid.Text);
            guncelle.DersId = Convert.ToInt32(cmbDers.Text);
            guncelle.OgrenciId = Convert.ToInt16(cmbogrenci.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Ders Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtid.Text);

            var ogrencidersbul = db.OgrenciDersTab.Find(Id);
            db.OgrenciDersTab.Remove(ogrencidersbul);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            var degerler = from item in db.OgrenciDersTab
                           where item.DersId.ToString().Contains(aranan)
                           where item.OgrenciId.ToString().Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }
                

                
    }
}
