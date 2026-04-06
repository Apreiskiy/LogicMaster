namespace Logic_Master.Views
{
    partial class TruthTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TruthTableForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            CountArgumentNumeric = new NumericUpDown();
            tableLayoutPanel3 = new TableLayoutPanel();
            ZeroButton = new Button();
            OneButton = new Button();
            NegativeButton = new Button();
            SaveImageTruthTableButton = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            OKButton = new Button();
            TruthTableDataGrid = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CountArgumentNumeric).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TruthTableDataGrid).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 3);
            tableLayoutPanel1.Controls.Add(TruthTableDataGrid, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(334, 311);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 2, 0);
            tableLayoutPanel2.Controls.Add(CountArgumentNumeric, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(328, 27);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 27);
            label1.TabIndex = 0;
            label1.Text = "Таблица для";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(160, 0);
            label2.Name = "label2";
            label2.Size = new Size(165, 27);
            label2.TabIndex = 1;
            label2.Text = " переменных";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CountArgumentNumeric
            // 
            CountArgumentNumeric.Dock = DockStyle.Fill;
            CountArgumentNumeric.Location = new Point(84, 2);
            CountArgumentNumeric.Margin = new Padding(3, 2, 3, 2);
            CountArgumentNumeric.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            CountArgumentNumeric.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            CountArgumentNumeric.Name = "CountArgumentNumeric";
            CountArgumentNumeric.Size = new Size(70, 23);
            CountArgumentNumeric.TabIndex = 2;
            CountArgumentNumeric.Value = new decimal(new int[] { 2, 0, 0, 0 });
            CountArgumentNumeric.ValueChanged += CountArgumentNumeric_ValueChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(ZeroButton, 0, 0);
            tableLayoutPanel3.Controls.Add(OneButton, 1, 0);
            tableLayoutPanel3.Controls.Add(NegativeButton, 2, 0);
            tableLayoutPanel3.Controls.Add(SaveImageTruthTableButton, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 33);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(328, 34);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // ZeroButton
            // 
            ZeroButton.Dock = DockStyle.Fill;
            ZeroButton.Image = Properties.Resources.ZeroSymbol;
            ZeroButton.Location = new Point(3, 2);
            ZeroButton.Margin = new Padding(3, 2, 3, 2);
            ZeroButton.Name = "ZeroButton";
            ZeroButton.Size = new Size(30, 30);
            ZeroButton.TabIndex = 0;
            ZeroButton.UseVisualStyleBackColor = true;
            ZeroButton.Click += ZeroButton_Click;
            // 
            // OneButton
            // 
            OneButton.Dock = DockStyle.Fill;
            OneButton.Image = Properties.Resources.OneSymbol;
            OneButton.Location = new Point(39, 2);
            OneButton.Margin = new Padding(3, 2, 3, 2);
            OneButton.Name = "OneButton";
            OneButton.Size = new Size(30, 30);
            OneButton.TabIndex = 1;
            OneButton.UseVisualStyleBackColor = true;
            OneButton.Click += OneButton_Click;
            // 
            // NegativeButton
            // 
            NegativeButton.Dock = DockStyle.Fill;
            NegativeButton.Image = Properties.Resources.NegativeX;
            NegativeButton.Location = new Point(75, 2);
            NegativeButton.Margin = new Padding(3, 2, 3, 2);
            NegativeButton.Name = "NegativeButton";
            NegativeButton.Size = new Size(30, 30);
            NegativeButton.TabIndex = 2;
            NegativeButton.UseVisualStyleBackColor = true;
            NegativeButton.Click += NegativeButton_Click;
            // 
            // SaveImageTruthTableButton
            // 
            SaveImageTruthTableButton.BackgroundImage = Properties.Resources.SaveFile;
            SaveImageTruthTableButton.BackgroundImageLayout = ImageLayout.Zoom;
            SaveImageTruthTableButton.Location = new Point(111, 2);
            SaveImageTruthTableButton.Margin = new Padding(3, 2, 3, 2);
            SaveImageTruthTableButton.Name = "SaveImageTruthTableButton";
            SaveImageTruthTableButton.Size = new Size(30, 30);
            SaveImageTruthTableButton.TabIndex = 3;
            SaveImageTruthTableButton.UseVisualStyleBackColor = true;
            SaveImageTruthTableButton.Click += SaveImageTruthTableButton_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.AutoSize = true;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel5.Controls.Add(OKButton, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 275);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(328, 34);
            tableLayoutPanel5.TabIndex = 3;
            // 
            // OKButton
            // 
            OKButton.Anchor = AnchorStyles.Top;
            OKButton.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OKButton.ForeColor = Color.Navy;
            OKButton.Location = new Point(33, 2);
            OKButton.Margin = new Padding(3, 2, 3, 2);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(262, 30);
            OKButton.TabIndex = 4;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // TruthTableDataGrid
            // 
            TruthTableDataGrid.AllowUserToAddRows = false;
            TruthTableDataGrid.AllowUserToDeleteRows = false;
            TruthTableDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            TruthTableDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            TruthTableDataGrid.ColumnHeadersHeight = 24;
            TruthTableDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.SkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            TruthTableDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            TruthTableDataGrid.Dock = DockStyle.Fill;
            TruthTableDataGrid.Location = new Point(3, 71);
            TruthTableDataGrid.Margin = new Padding(3, 2, 3, 2);
            TruthTableDataGrid.Name = "TruthTableDataGrid";
            TruthTableDataGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            TruthTableDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            TruthTableDataGrid.RowHeadersWidth = 51;
            TruthTableDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TruthTableDataGrid.Size = new Size(328, 200);
            TruthTableDataGrid.TabIndex = 4;
            TruthTableDataGrid.CellDoubleClick += TruthTableDataGrid_CellDoubleClick;
            TruthTableDataGrid.CellPainting += TruthTableDataGrid_CellPainting;
            // 
            // TruthTableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 311);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(320, 320);
            Name = "TruthTableForm";
            Text = "Таблица истинности";
            Load += TruthTableForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CountArgumentNumeric).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TruthTableDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridView TruthTableDataGrid;
        private Label label1;
        private Label label2;
        private NumericUpDown CountArgumentNumeric;
        private Button ZeroButton;
        private Button OneButton;
        private Button NegativeButton;
        private Button OKButton;
        private Button SaveImageTruthTableButton;
    }
}