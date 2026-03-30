# 🚗 Car Rental System

A full desktop application for managing a car rental business, built using **C# WinForms** and **SQL Server** with a clean layered architecture (DAL / BL / UI).

---

## 📌 Overview

This system allows managing all core operations of a car rental company, including customers, vehicles, bookings, payments, and return records.

The project focuses on applying real-world software engineering concepts such as separation of concerns, reusable components, and structured database design.

---

## ✨ Features

### 👤 Customer Management

* Add / Edit / Delete customers
* Link customers to personal information
* License management (class, expiry, issue date)

### 🚘 Vehicle Management

* Manage vehicles (Make, Model, Category, Fuel Type)
* Track mileage and rental cost per day
* Vehicle status (Available / Rented)

### 📅 Rental Booking System

* Create and manage rental bookings
* Track pickup and drop-off locations
* Booking status (Pending / Confirmed / Completed)

### 💳 Payment System

* Record initial payments
* Calculate total due amount
* Track remaining and refunded amounts

### 🔄 Return Records

* Handle vehicle returns
* Track actual return date
* Calculate additional charges
* Store final vehicle condition notes

---

## 🧱 Architecture

The project follows a **3-Tier Architecture**:

* **Presentation Layer (UI)** → WinForms (Forms + UserControls)
* **Business Logic Layer (BL)** → Classes like:

  * `clsCustomer`
  * `clsVehicle`
  * `clsRentalBooking`
  * `clsPayment`
* **Data Access Layer (DAL)** → SQL Server interaction using ADO.NET

---

## 🛠️ Technologies Used

* **C# (.NET WinForms)**
* **SQL Server**
* **ADO.NET**
* Object-Oriented Programming (OOP)

---

## 📊 Database Design

Key Tables:

* `People`
* `Customers`
* `Vehicles`
* `VehicleBookRecords`
* `Payments`
* `ReturnRecords`
* Lookup Tables:

  * Makes, Models, Categories, FuelTypes

---

## 🖼️ Screenshots

> (Add screenshots here later)

```md
![Screenshot](link_here)
```

---


## 👨‍💻 Author

**Alaa Mahmoud**

---

## ⭐ Future Improvements

* Add authentication & user roles
* Convert to Web API + Frontend (React / Angular)
* Reporting & analytics dashboard
* Online booking support

---

## 💡 Project Purpose

This project was built as a practical implementation of:

* Database design
* Layered architecture
* Real-world business logic

---

⭐ If you like this project, feel free to star the repo!
