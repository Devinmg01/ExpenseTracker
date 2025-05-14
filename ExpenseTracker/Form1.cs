using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;


namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadCategories();
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
                    cmd.CommandText = @"
                INSERT INTO Transactions (Amount, Type, CategoryId, Date, Notes)
                VALUES (@amount, @type, @categoryId, @date, @notes);";
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@notes", notes);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Transaction added successfully!");
                ClearInputs(); 
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

    }
}
