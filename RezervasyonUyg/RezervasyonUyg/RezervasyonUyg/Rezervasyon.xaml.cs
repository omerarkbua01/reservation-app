using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using System.Data.SqlClient;

namespace RezervasyonUyg
{
    public partial class Rezervasyon : ContentPage
    {
        private List<string> SecilebilirMasa;

        public Rezervasyon()
        {
            InitializeComponent();
            datePicker.Date = DateTime.Today;
            SecilebilirMasa = new List<string>
            {
                "Masa 1", "Masa 2", "Masa 3", "Masa 4", "Masa 5",
                "Masa 6", "Masa 7", "Masa 8", "Masa 9", "Masa 10"
            };
            tablePicker.ItemsSource = SecilebilirMasa;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string isim = nameEntry.Text;
            string soyisim = surnameEntry.Text;
            string telefon = phoneEntry.Text;
            string email = emailEntry.Text;
            string masa = tablePicker.SelectedItem?.ToString();
            DateTime selectedDate = Tarih.Date;

            try
            {
                string serverdbname = "RezerveKayıt";
                string servername = "192.168.0.27";
                string serverusername = "proje";
                string serverpassword = "proje123";

                string sqlconn = $"Server={servername};Database={serverdbname};User Id={serverusername};Password={serverpassword};";
                SqlConnection sqlConnection = new SqlConnection(sqlconn);
                {
                    sqlConnection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM RezerveKayıt WHERE Masa = @Masa AND CAST(Tarih AS DATE) = @Tarih";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@Masa", masa);
                        checkCmd.Parameters.AddWithValue("@Tarih", selectedDate.Date);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            DisplayAlert("Uyarı", "Seçtiğiniz masa bu tarih için zaten rezerve edilmiş.", "Tamam");
                            return;
                        }

                        string query = "INSERT INTO RezerveKayıt (İsim, Soyisim, Telefon, Email, Masa, Tarih) VALUES (@İsim, @Soyisim, @Telefon, @Email, @Masa, @Tarih)";

                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@İsim", isim);
                            sqlCommand.Parameters.AddWithValue("@Soyisim", soyisim);
                            sqlCommand.Parameters.AddWithValue("@Telefon", telefon);
                            sqlCommand.Parameters.AddWithValue("@Email", email);
                            sqlCommand.Parameters.AddWithValue("@Masa", masa);
                            sqlCommand.Parameters.AddWithValue("@Tarih", selectedDate);

                            sqlCommand.ExecuteNonQuery();
                        }

                        sqlConnection.Close();
                    }

                    string rezervasyondetay = $"İsim: {isim}\nSoyisim: {soyisim}\nTelefon: {telefon}\nEmail: {email}\nMasa: {masa}\nTarih: {selectedDate.ToShortDateString()}";
                    DisplayAlert("Rezervasyon Bilgileri", rezervasyondetay, "Tamam");

                    nameEntry.Text = string.Empty;
                    surnameEntry.Text = string.Empty;
                    phoneEntry.Text = string.Empty;
                    emailEntry.Text = string.Empty;
                    tablePicker.SelectedItem = null;
                    datePicker.Date = DateTime.Today;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }
    }
}





