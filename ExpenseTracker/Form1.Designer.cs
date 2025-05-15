namespace ExpenseTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ✅ Declare your ComboBox here
        private System.Windows.Forms.ComboBox cmbCategory;

        /// <summary>
        /// Clean up resources
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbCategory = new ComboBox();
            txtAmount = new TextBox();
            cmbType = new ComboBox();
            dtpDate = new DateTimePicker();
            txtNotes = new TextBox();
            btnAdd = new Button();
            dgvTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 40);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(168, 40);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 1;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.ForeColor = SystemColors.Window;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Income", "Expense" });
            cmbType.Location = new Point(274, 40);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 23);
            cmbType.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(401, 40);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 3;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(607, 40);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(100, 23);
            txtNotes.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(713, 42);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "button1";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(-13, 293);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.Size = new Size(1246, 374);
            dgvTransactions.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 668);
            Controls.Add(dgvTransactions);
            Controls.Add(btnAdd);
            Controls.Add(txtNotes);
            Controls.Add(dtpDate);
            Controls.Add(cmbType);
            Controls.Add(txtAmount);
            Controls.Add(cmbCategory);
            Name = "Form1";
            Text = "Expense Tracker";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAmount;
        private ComboBox cmbType;
        private DateTimePicker dtpDate;
        private TextBox txtNotes;
        private Button btnAdd;
        private DataGridView dgvTransactions;
    }
}
