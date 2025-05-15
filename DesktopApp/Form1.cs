using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
        private int editingId = -1;

        public Form1()
        {
            InitializeComponent();
            LoadCategories();
            LoadTransactions();
            CalculateSummary();
        }

        private void LoadCategories()
        {
            string connString = "Data Source=expenses.db";
            List<KeyValuePair<int, string>> categories = new List<KeyValuePair<int, string>>();

            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT Id, Name FROM Categories", conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        categories.Add(new KeyValuePair<int, string>(id, name));
                    }
                }

                // Bind to ComboBox
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "Value";
                cmbCategory.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse form inputs
                float amount = float.Parse(txtAmount.Text);
                string type = cmbType.SelectedItem.ToString();
                int categoryId = (int)cmbCategory.SelectedValue;
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                string notes = txtNotes.Text;

                string connString = "Data Source=expenses.db";

                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();

                    if (editingId == -1)
                    {
                        // Insert a new transaction
                        cmd.CommandText = @"
                        INSERT INTO Transactions (Amount, Type, CategoryId, Date, Notes)
                        VALUES (@amount, @type, @categoryId, @date, @notes);";
                    }
                    else
                    {
                        // Update existing transaction
                        cmd.CommandText = @"
                        UPDATE Transactions
                        SET Amount = @amount,
                        Type = @type,
                        CategoryId = @categoryId,
                        Date = @date,
                        Notes = @notes
                        WHERE Id = @id;";
                        cmd.Parameters.AddWithValue("@id", editingId);
                    }

                    // Shared parameters for both insert/update
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@notes", notes);
                    cmd.ExecuteNonQuery();
                }

                // Show success message
                MessageBox.Show(editingId == -1 ? "Transaction added!" : "Transaction updated!");

                // Reset form
                editingId = -1;
                grpTransactionInput.BackColor = Color.White;
                btnAdd.Text = "Add Transaction";
                ClearInputs();

                // Refresh display
                LoadTransactions();
                CalculateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void ClearInputs()
        {
            txtAmount.Text = "";
            cmbType.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            txtNotes.Text = "";
        }

        private void LoadTransactions()
        {
            string connString = "Data Source=expenses.db";

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
                    T.Id,              
                    T.Amount, 
                    T.Type, 
                    C.Name AS Category, 
                    T.Date, 
                    T.Notes
                    FROM Transactions T
                    JOIN Categories C ON T.CategoryId = C.Id
                    ORDER BY T.Date DESC";


                var adapter = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                dgvTransactions.DataSource = dt;
                dgvTransactions.Columns["Id"].Visible = false;
            }
        }

        private void CalculateSummary()
        {
            string connString = "Data Source=expenses.db";
            float income = 0, expenses = 0;

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                // Sum Income
                cmd.CommandText = "SELECT IFNULL(SUM(Amount), 0) FROM Transactions WHERE Type = 'Income'";
                income = Convert.ToSingle(cmd.ExecuteScalar());

                // Sum Expenses
                cmd.CommandText = "SELECT IFNULL(SUM(Amount), 0) FROM Transactions WHERE Type = 'Expense'";
                expenses = Convert.ToSingle(cmd.ExecuteScalar());
            }

            float balance = income - expenses;

            lblTotalIncome.Text = $"Income: ${income:F2}";
            lblTotalExpenses.Text = $"Expenses: ${expenses:F2}";
            lblBalance.Text = $"Balance: ${balance:F2}";
        }


        private void lblBalance_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalIncome_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            // Get the selected row’s ID
            int id = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["Id"].Value);

            string connString = "Data Source=expenses.db";
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Transactions WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadTransactions();
            CalculateSummary();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to edit.");
                return;
            }

            var row = dgvTransactions.SelectedRows[0];

            editingId = Convert.ToInt32(row.Cells["Id"].Value);
            txtAmount.Text = row.Cells["Amount"].Value.ToString();
            cmbType.SelectedItem = row.Cells["Type"].Value.ToString();
            cmbCategory.Text = row.Cells["Category"].Value.ToString();
            dtpDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
            txtNotes.Text = row.Cells["Notes"].Value.ToString();

            grpTransactionInput.BackColor = Color.LawnGreen;
            btnAdd.Text = "Update Transaction";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalExpenses_Click(object sender, EventArgs e)
        {

        }
    }
}
