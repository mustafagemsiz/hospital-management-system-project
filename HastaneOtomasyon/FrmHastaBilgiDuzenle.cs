﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyon
{
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        public string TCNo;
        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCNo;
            SqlCommand komut = new SqlCommand("select * from Tbl_Hasta where HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
                
            }
            bgl.baglanti().Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hasta set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaCinsiyet=@p4, HastaSifre=@p5 where HastaTC=@p6",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", mskTC.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }
    }
}
