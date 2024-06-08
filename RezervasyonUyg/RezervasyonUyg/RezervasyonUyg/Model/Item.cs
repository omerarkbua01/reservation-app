using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RezervasyonUyg.Model
{
    public class Rezervasyon
    {
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string Masa { get; set; }
        public int Tarih { get; set; }


        public Rezervasyon(string isim, string soyisim, int telefon, string email, string masa, int kisisayisi, int tarih)
        {
            İsim = isim;
            Soyisim = soyisim;
            Telefon = telefon;
            Email = email;
            Masa = masa;
            Tarih = tarih;
        }
    }

    


}
