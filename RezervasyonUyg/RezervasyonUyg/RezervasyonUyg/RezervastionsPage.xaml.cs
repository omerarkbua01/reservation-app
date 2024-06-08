using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xamarin.Forms;

namespace RezervasyonUyg
{
    public partial class ReservationsPage : ContentPage
    {
        public ReservationsPage()
        {
            InitializeComponent();
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                string serverdbname = "RezerveKayıt";
                string servername = "192.168.0.27";
                string serverusername = "proje";
                string serverpassword = "proje123";

                string sqlconn = $"Server={servername};Database={serverdbname};User Id={serverusername};Password={serverpassword};";
                using (SqlConnection sqlConnection = new SqlConnection(sqlconn))
                {
                    sqlConnection.Open();
                    string query = "SELECT İsim, Soyisim, Telefon, Email, Masa, Tarih FROM RezerveKayıt";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        var reservations = new List<Reservation>();
                        while (reader.Read())
                        {
                            var reservation = new Reservation
                            {
                                İsim = reader["İsim"].ToString(),
                                Soyisim = reader["Soyisim"].ToString(),
                                Telefon = reader["Telefon"].ToString(),
                                Email = reader["Email"].ToString(),
                                Masa = reader["Masa"].ToString(),
                                Tarih = Convert.ToDateTime(reader["Tarih"]).ToShortDateString(),
                                Detay = $"İsim: {reader["İsim"]}, Soyisim: {reader["Soyisim"]}, Telefon: {reader["Telefon"]}, Email: {reader["Email"]}, Masa: {reader["Masa"]}, Tarih: {Convert.ToDateTime(reader["Tarih"]).ToShortDateString()}"
                            };
                            reservations.Add(reservation);
                        }

                        reservationsCollectionView.ItemsSource = reservations;
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }

    public class Reservation
    {
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Masa { get; set; }
        public string Tarih { get; set; }
        public string Detay { get; set; }
    }
}