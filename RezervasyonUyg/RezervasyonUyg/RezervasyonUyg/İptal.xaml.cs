using System;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RezervasyonUyg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class İptal : ContentPage
    {
        public İptal()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string isim = nameEntry.Text;
            string soyisim = surnameEntry.Text;
            string telefon = phoneEntry.Text;

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

                    string deleteQuery = "DELETE FROM RezerveKayıt WHERE İsim = @İsim AND Soyisim = @Soyisim AND Telefon = @Telefon";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, sqlConnection))
                    {
                        deleteCmd.Parameters.AddWithValue("@İsim", isim);
                        deleteCmd.Parameters.AddWithValue("@Soyisim", soyisim);
                        deleteCmd.Parameters.AddWithValue("@Telefon", telefon);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DisplayAlert("Başarılı", "Rezervasyon başarıyla iptal edildi.", "Tamam");
                        }
                        else
                        {
                            DisplayAlert("Hata", "Girilen bilgilerle eşleşen bir rezervasyon bulunamadı.", "Tamam");
                        }
                    }

                    sqlConnection.Close();
                }

                nameEntry.Text = string.Empty;
                surnameEntry.Text = string.Empty;
                phoneEntry.Text = string.Empty;
            }
            catch (Exception ex)
            {
                DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }
    }
}