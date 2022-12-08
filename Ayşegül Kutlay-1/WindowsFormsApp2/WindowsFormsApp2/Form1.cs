using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ders drs= new Ders();
            drs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OkulYonetim oy = new OkulYonetim();
            oy.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciDers od = new OgrenciDers();
            od.Show();
        }
    }
}
