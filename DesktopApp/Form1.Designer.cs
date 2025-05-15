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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cmbCategory = new ComboBox();
            txtAmount = new TextBox();
            cmbType = new ComboBox();
            dtpDate = new DateTimePicker();
            txtNotes = new TextBox();
            btnAdd = new Button();
            dgvTransactions = new DataGridView();
            lblTotalIncome = new Label();
            lblTotalExpenses = new Label();
            lblBalance = new Label();
            Category = new Label();
            amount = new Label();
            incomeExpense = new Label();
            lblDate = new Label();
            lblNotes = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            grpTransactionInput = new GroupBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            grpTransactionInput.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(6, 38);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(162, 38);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 1;
            txtAmount.TextChanged += txtAmount_TextChanged;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.ForeColor = SystemColors.InactiveCaptionText;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Income", "Expense" });
            cmbType.Location = new Point(268, 38);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 23);
            cmbType.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(395, 38);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 3;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(601, 38);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(100, 23);
            txtNotes.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(707, 37);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Submit";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.LightGray;
            dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransactions.BackgroundColor = Color.DarkGray;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(12, 293);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.Size = new Size(1221, 374);
            dgvTransactions.TabIndex = 6;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.BorderStyle = BorderStyle.FixedSingle;
            lblTotalIncome.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalIncome.Location = new Point(17, 46);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(121, 27);
            lblTotalIncome.TabIndex = 7;
            lblTotalIncome.Text = "Total Income\r\n";
            lblTotalIncome.Click += lblTotalIncome_Click;
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.AutoSize = true;
            lblTotalExpenses.BorderStyle = BorderStyle.FixedSingle;
            lblTotalExpenses.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalExpenses.Location = new Point(17, 73);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Size = new Size(136, 27);
            lblTotalExpenses.TabIndex = 8;
            lblTotalExpenses.Text = "Total Expenses";
            lblTotalExpenses.Click += lblTotalExpenses_Click;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.BorderStyle = BorderStyle.FixedSingle;
            lblBalance.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBalance.Location = new Point(17, 19);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(80, 27);
            lblBalance.TabIndex = 9;
            lblBalance.Text = "Balance";
            lblBalance.Click += lblBalance_Click;
            // 
            // Category
            // 
            Category.AutoSize = true;
            Category.Location = new Point(6, 20);
            Category.Name = "Category";
            Category.Size = new Size(55, 15);
            Category.TabIndex = 10;
            Category.Text = "Category";
            // 
            // amount
            // 
            amount.AutoSize = true;
            amount.Location = new Point(162, 19);
            amount.Name = "amount";
            amount.Size = new Size(51, 15);
            amount.TabIndex = 11;
            amount.Text = "Amount";
            amount.Click += label1_Click;
            // 
            // incomeExpense
            // 
            incomeExpense.AutoSize = true;
            incomeExpense.Location = new Point(268, 19);
            incomeExpense.Name = "incomeExpense";
            incomeExpense.Size = new Size(94, 15);
            incomeExpense.TabIndex = 12;
            incomeExpense.Text = "Income/Expense";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(395, 19);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 13;
            lblDate.Text = "Date";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(601, 19);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(38, 15);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "Notes";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(602, 216);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(324, 71);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(932, 216);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(301, 71);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Edit Selected";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // grpTransactionInput
            // 
            grpTransactionInput.BackColor = SystemColors.ButtonHighlight;
            grpTransactionInput.Controls.Add(cmbCategory);
            grpTransactionInput.Controls.Add(Category);
            grpTransactionInput.Controls.Add(txtAmount);
            grpTransactionInput.Controls.Add(lblNotes);
            grpTransactionInput.Controls.Add(amount);
            grpTransactionInput.Controls.Add(lblDate);
            grpTransactionInput.Controls.Add(cmbType);
            grpTransactionInput.Controls.Add(btnAdd);
            grpTransactionInput.Controls.Add(incomeExpense);
            grpTransactionInput.Controls.Add(dtpDate);
            grpTransactionInput.Controls.Add(txtNotes);
            grpTransactionInput.Location = new Point(1, 0);
            grpTransactionInput.Name = "grpTransactionInput";
            grpTransactionInput.Size = new Size(825, 162);
            grpTransactionInput.TabIndex = 17;
            grpTransactionInput.TabStop = false;
            grpTransactionInput.Text = "Transaction Details";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(lblBalance);
            groupBox1.Controls.Add(lblTotalIncome);
            groupBox1.Controls.Add(lblTotalExpenses);
            groupBox1.Location = new Point(12, 168);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 119);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Totals";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1233, 668);
            Controls.Add(groupBox1);
            Controls.Add(grpTransactionInput);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dgvTransactions);
            Name = "Form1";
            Text = "Expense Tracker";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            grpTransactionInput.ResumeLayout(false);
            grpTransactionInput.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtAmount;
        private ComboBox cmbType;
        private DateTimePicker dtpDate;
        private TextBox txtNotes;
        private Button btnAdd;
        private DataGridView dgvTransactions;
        private Label lblTotalIncome;
        private Label lblTotalExpenses;
        private Label lblBalance;
        private Label Category;
        private Label amount;
        private Label incomeExpense;
        private Label lblDate;
        private Label lblNotes;
        private Button btnDelete;
        private Button btnEdit;
        private GroupBox grpTransactionInput;
        private GroupBox groupBox1;
    }
}
