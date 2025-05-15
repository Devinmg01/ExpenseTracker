#  Expense Tracker - C# WinForms + SQLite 

A desktop expense tracking application built with **C# WinForms** and **SQLite**, featuring modern UX elements like chart-based dashboards, category management, and transaction editing. Perfect for personal budgeting, and a strong portfolio piece showcasing CRUD operations, data visualization, and local persistence.

---

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

