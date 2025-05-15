#  Expense Tracker - C# WinForms + SQLite 

A desktop expense tracking application built with **C# WinForms** and **SQLite**, featuring modern UX elements like chart-based dashboards, category management, and transaction editing. Perfect for personal budgeting, and a strong portfolio piece showcasing CRUD operations, data visualization, and local persistence.

---
![Transaction Form](screenshots/expense sc.png)

##  Features

###  Transaction Management
- Add income or expense transactions
- Assign categories and add notes
- Select transaction date
- Edit or delete any existing transaction

###  Category Support
- Pre-seeded categories: `Food`, `Rent`, `Salary`, `Entertainment`, `Utilities`, `Clothes`, `Other`
- "Refresh Categories" button to reload dropdown after updates

###  Data Grid
- View all transactions in a sortable grid
- Columns: Amount, Type, Category, Date, Notes
- Built-in summary of total income, expenses, and balance

###  Local Database
- Uses **SQLite** (`expenses.db`) stored in the project directory
- Tables:
  - `Categories`
  - `Transactions`
- Automatic table creation and seeding via `DatabaseInitializer`

---

## Project Structure
/ExpenseTracker
├── Form1.cs # Main UI logic
├── Form1.Designer.cs # WinForms layout
├── DatabaseInitializer.cs # SQLite setup & seeding
├── expenses.db # Local SQLite database
├── Program.cs # App entry point


---

##  Getting Started

###  Requirements
- Windows
- Visual Studio 2022+
- .NET 6 or 7

###  How to Run

1. Clone the repository
2. Open the `.sln` file in Visual Studio
3. Ensure `expenses.db` is set to: Copy to Output Directory → Copy if newe
4. Run the application (`F5`)

---

##  Tech Stack

- C# WinForms (.NET 6)
- SQLite (`System.Data.SQLite`)

---

##  Future Features

- [ ] Export to CSV
- [ ] Filter by month or date range
- [ ] Category manager (add/delete from UI)
- [ ] Theme toggle (light/dark)
- [ ] Login screen (optional user security)
- [ ] ASP.NET Razor version (web-based UI)

---

---

## Author

Devin Grace  
 



