# Restaurant Reservation App

A cross-platform restaurant table-reservation app built with **Xamarin.Forms (C#)** as a team project in **June 2024**.
Customers can book a table for a date, see existing reservations and cancel a booking.

> **Status: archived.** This is an early learning project kept for reference; it is no longer maintained.

## ✅ Features

- **Create a reservation**: name, surname, phone, e-mail, table (Masa 1 to 10) and date
- **Double-booking guard**: a table can't be booked twice for the same date (checked before insert)
- **Reservation list**: all bookings with their details
- **Cancel a reservation**: by name, surname and phone
- Parameterised SQL queries (`SqlCommand.Parameters`) for every read / write

## 🛠️ Tech

- **Framework:** Xamarin.Forms 5 · .NET Standard 2.0 (shared project) + Android & iOS heads
- **Language:** C# + XAML
- **Data:** SQL Server via `System.Data.SqlClient`

## 🧭 What I'd do differently today

- Put an **API layer** between the app and the database instead of connecting the mobile client straight to SQL Server
- Keep connection settings out of source control entirely (environment / secure storage); this repository uses a placeholder in `DbConfig.cs`
- Move to **.NET MAUI**, the successor of Xamarin.Forms

## ▶️ Running locally

1. Open `RezervasyonUyg/RezervasyonUyg.sln` in Visual Studio with the Xamarin / mobile workload
2. Create a SQL Server database `RezerveKayıt` with a `RezerveKayıt` table (`İsim`, `Soyisim`, `Telefon`, `Email`, `Masa`, `Tarih`)
3. Put your own connection string in `RezervasyonUyg/RezervasyonUyg/RezervasyonUyg/DbConfig.cs`
4. Run the Android or iOS project
