namespace RezervasyonUyg
{
    // Veritabanı bağlantısı tek yerde. Gerçek sunucu bilgileri depoya yazılmaz:
    // yerelde çalıştırmak için kendi SQL Server bilgilerinizi buraya girin.
    internal static class DbConfig
    {
        public const string ConnectionString =
            "Server=<sql-server-host>;Database=RezerveKayıt;User Id=<user>;Password=<password>;";
    }
}
