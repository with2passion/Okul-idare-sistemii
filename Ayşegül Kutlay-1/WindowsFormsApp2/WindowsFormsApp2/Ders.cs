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
    public partial class Ders : Form
    {
        public Ders()
        {
            InitializeComponent();
        }
        WFormDBEntities db = new WFormDBEntities();

        void listele()
        {
            dataGridView1.DataSource = (from x in db.DersTab
                                        select new
                                        {
                                            x.Id,
                                            x.Ad,
                                            x.Kredi,
                                            x.OkulYonetimId

                                        }).ToList();

            //dataGridView1.Columns[4].Visible = false;

            var derslist = db.DersTab.ToList();
        }

        private void Ders_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DersTab ekle = new DersTab();
            ekle.Ad = txtad.Text;
            ekle.Kredi = Convert.ToInt32(txtkredi.Text);
            ekle.OkulYonetimId = Convert.ToInt32(txtoyid.Text);
            db.DersTab.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("İşlem başarılı");
            listele();

            txtid.Clear();
            txtad.Clear();
            txtkredi.Clear();
            txtoyid.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int DersId = Convert.ToInt32(txtid.Text);

            var guncelle = db.DersTab.Find(DersId);
            guncelle.Ad = txtad.Text;
            guncelle.Kredi = Convert.ToInt32(txtkredi.Text);
            guncelle.OkulYonetimId = Convert.ToInt32(txtoyid.Text);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int DersId = Convert.ToInt32(txtid.Text);

            var dersbul = db.DersTab.Find(DersId);
            db.DersTab.Remove(dersbul);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtkredi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtoyid.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            var degerler = from item in db.DersTab
                           where item.Ad.Contains(aranan)
                           // where item.Kredisi.ToString().Contains(aranan)
                           //  where item.OkulYonetimId.ToString().Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }
    }
}
