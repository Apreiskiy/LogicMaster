namespace Logic_Master.Views
{
    partial class TableCoeff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableCoeff));
            tableLayoutPanel1 = new TableLayoutPanel();
            SaveImageCoeffTableButton = new Button();
            CoeffTableDataGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CoeffTableDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(SaveImageCoeffTableButton, 0, 0);
            tableLayoutPanel1.Controls.Add(CoeffTableDataGrid, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 1, 4);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(pictureBox2, 0, 3);
            tableLayoutPanel1.Controls.Add(pictureBox3, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(734, 361);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SaveImageCoeffTableButton
            // 
            tableLayoutPanel1.SetColumnSpan(SaveImageCoeffTableButton, 2);
            SaveImageCoeffTableButton.Location = new Point(3, 2);
            SaveImageCoeffTableButton.Margin = new Padding(3, 2, 3, 2);
            SaveImageCoeffTableButton.Name = "SaveImageCoeffTableButton";
            SaveImageCoeffTableButton.Size = new Size(262, 30);
            SaveImageCoeffTableButton.TabIndex = 0;
            SaveImageCoeffTableButton.Text = "Сохранить изображение";
            SaveImageCoeffTableButton.UseVisualStyleBackColor = true;
            SaveImageCoeffTableButton.Click += SaveImageCoeffTableButton_Click;
            // 
            // CoeffTableDataGrid
            // 
            CoeffTableDataGrid.AllowUserToAddRows = false;
            CoeffTableDataGrid.AllowUserToDeleteRows = false;
            CoeffTableDataGrid.AllowUserToResizeColumns = false;
            CoeffTableDataGrid.AllowUserToResizeRows = false;
            CoeffTableDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CoeffTableDataGrid.ColumnHeadersVisible = false;
            tableLayoutPanel1.SetColumnSpan(CoeffTableDataGrid, 2);
            CoeffTableDataGrid.Dock = DockStyle.Fill;
            CoeffTableDataGrid.Location = new Point(3, 36);
            CoeffTableDataGrid.Margin = new Padding(3, 2, 3, 2);
            CoeffTableDataGrid.Name = "CoeffTableDataGrid";
            CoeffTableDataGrid.ReadOnly = true;
            CoeffTableDataGrid.RowHeadersWidth = 100;
            CoeffTableDataGrid.Size = new Size(728, 221);
            CoeffTableDataGrid.TabIndex = 1;
            CoeffTableDataGrid.CellPainting += CoeffTableDataGrid_CellPainting;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(39, 259);
            label1.Name = "label1";
            label1.Size = new Size(692, 34);
            label1.TabIndex = 2;
            label1.Text = "Минимальное покрытие";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(39, 293);
            label2.Name = "label2";
            label2.Size = new Size(692, 34);
            label2.TabIndex = 3;
            label2.Text = "Коэффициенты, не вошедшие в минимальное покрытие";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(39, 327);
            label3.Name = "label3";
            label3.Size = new Size(692, 34);
            label3.TabIndex = 4;
            label3.Text = "Коэффициенты, не входящие в ДСНФ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.RedCoeffK;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 261);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.BlueCoeffK;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(3, 295);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.BlackCoeffK;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Location = new Point(3, 329);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // TableCoeff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(734, 361);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(600, 300);
            Name = "TableCoeff";
            Text = "Таблица коэффициентов";
            Load += TableCoeff_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CoeffTableDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button SaveImageCoeffTableButton;
        private DataGridView CoeffTableDataGrid;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}