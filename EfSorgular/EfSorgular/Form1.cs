using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfSorgular
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindVarliklar Vt = new NorthwindVarliklar();

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "-1";
            if (radioButton1.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.ToList();
            }
            if (radioButton2.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.OrderBy(u => u.UrunAdi).ToList();
            }
            if (radioButton3.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.OrderByDescending(u => u.UrunAdi).ToList();
            }
            if (radioButton4.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.OrderBy(u => u.UrunID).Take(3).ToList();
            }
            if (radioButton5.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.OrderByDescending(u => u.UrunID).Take(3).ToList();
            }
            if (radioButton6.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Where(u => u.UrunID == 77).ToList();
            }
            if (radioButton7.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Where(u => u.UrunAdi.StartsWith("A")).ToList();
            }
            if (radioButton8.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Where(u => u.UrunAdi.EndsWith("A")).ToList();
            }
            if (radioButton9.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Where(u => u.UrunAdi.Contains("A")).ToList();
            }
            if (radioButton10.Checked == true)
            {
                if (Vt.Urunler.Any(u => u.UrunID == 77))
                {
                    MessageBox.Show("Ürün Var.");

                }
                else
                {
                    MessageBox.Show("Ürün Yok.");
                }

            }
            if (radioButton11.Checked == true)
            {
                MessageBox.Show(Vt.Urunler.Count().ToString());
            }
            if (radioButton12.Checked == true)
            {
                MessageBox.Show(Vt.Urunler.Where(u => u.UrunAdi.EndsWith("A")).Sum(u => u.HedefStokDuzeyi).ToString());
            }
            if (radioButton13.Checked == true)
            {
                MessageBox.Show(Vt.Urunler.Where(u => u.UrunAdi.EndsWith("A")).Average(u => u.HedefStokDuzeyi).ToString());
            }
            if (radioButton14.Checked == true)
            {
                MessageBox.Show(Vt.Urunler.Max(u => u.BirimFiyati).ToString());
            }
            if (radioButton15.Checked == true)
            {
                MessageBox.Show(Vt.Urunler.Min(u => u.BirimFiyati).ToString());
            }
            if (radioButton16.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Select(u => new
                {
                    UrunAdi = u.UrunAdi,
                    Fiyat = u.BirimFiyati
                }
                ).ToList();

            }
            if (radioButton17.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Select(u => new
                {
                    ID = u.UrunID,
                    UrunAdi = u.UrunAdi,
                    Fiyat = u.BirimFiyati
                }
                ).Where(u => u.ID > 5 && u.UrunAdi.StartsWith("C")).ToList();
            }
            if (radioButton18.Checked == true)
            {
                dataGridView1.DataSource = Vt.Urunler.Select(u => new
                {

                    UrunAdi = u.UrunAdi,
                    Durum = u.Sonlandi == true ? "Evet" : "Hayır"
                }
                ).Where(u => u.Durum == "Evet").ToList();
            }
            if (radioButton19.Checked == true)
            {
                var sorgu = from m in Vt.Musteriler select m;
                dataGridView1.DataSource = sorgu.ToList();

            }
            if (radioButton20.Checked == true)
            {
                var sorgu = from m in Vt.Musteriler
                            join s in Vt.Satislar
                            on m.MusteriID equals s.MusteriID
                            select
                            new
                            {
                                m.MusteriUnvani,
                                m.MusteriAdi,
                                s.NakliyeUcreti,
                                s.SatisTarihi

                            };
                dataGridView1.DataSource = sorgu.ToList();
            }
            if (radioButton21.Checked == true)
            {
                var sorgu = Vt.Satislar.SelectMany(s => Vt.Musteriler.Where(m => m.MusteriID == s.MusteriID));
                dataGridView1.DataSource = sorgu.ToList();
            }
            if (radioButton22.Checked == true)
            {
                var sorgu = Vt.Satislar.SelectMany(s => Vt.Musteriler.Where(m => m.MusteriID == s.MusteriID), (s, m) => new
                {
                    m.MusteriUnvani,
                    m.MusteriAdi,
                    s.NakliyeUcreti,
                    s.SatisTarihi
                });

                dataGridView1.DataSource = sorgu.ToList();
            }
            if (radioButton23.Checked == true)
            {
                var sorgu = Vt.Urunler.OrderBy(U => U.UrunID).Skip(5).ToList();
                dataGridView1.DataSource = sorgu.ToList();
            }
            if (radioButton24.Checked == true)
            {
                var sorgu = Vt.Satislar.GroupBy(s => s.SevkSehri).Select(z => new
                {
                    Sehir = z.Key,
                    Toplam = z.Count()
                });
                dataGridView1.DataSource = sorgu.ToList();
            }
                label2.Text = dataGridView1.Rows.Count.ToString();


            }

        }
    }






