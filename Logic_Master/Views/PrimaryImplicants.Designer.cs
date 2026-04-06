namespace Logic_Master.Views
{
    partial class PrimaryImplicants
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryImplicants));
            tableLayoutPanel1 = new TableLayoutPanel();
            SaveTextImageButton = new Button();
            PrimaryImplicantsRichTextBox = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(SaveTextImageButton, 0, 0);
            tableLayoutPanel1.Controls.Add(PrimaryImplicantsRichTextBox, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(584, 261);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // SaveTextImageButton
            // 
            SaveTextImageButton.Anchor = AnchorStyles.Left;
            SaveTextImageButton.Location = new Point(3, 2);
            SaveTextImageButton.Margin = new Padding(3, 2, 3, 2);
            SaveTextImageButton.Name = "SaveTextImageButton";
            SaveTextImageButton.Size = new Size(262, 30);
            SaveTextImageButton.TabIndex = 0;
            SaveTextImageButton.Text = "Сохранить текст";
            SaveTextImageButton.UseVisualStyleBackColor = true;
            SaveTextImageButton.Click += SaveTextImageButton_Click;
            // 
            // PrimaryImplicantsRichTextBox
            // 
            PrimaryImplicantsRichTextBox.Dock = DockStyle.Fill;
            PrimaryImplicantsRichTextBox.Location = new Point(3, 36);
            PrimaryImplicantsRichTextBox.Margin = new Padding(3, 2, 3, 2);
            PrimaryImplicantsRichTextBox.Name = "PrimaryImplicantsRichTextBox";
            PrimaryImplicantsRichTextBox.ReadOnly = true;
            PrimaryImplicantsRichTextBox.Size = new Size(578, 223);
            PrimaryImplicantsRichTextBox.TabIndex = 1;
            PrimaryImplicantsRichTextBox.Text = "";
            // 
            // PrimaryImplicants
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 261);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(400, 200);
            Name = "PrimaryImplicants";
            Text = "Первичные импликанты";
            Load += PrimaryImplicantsForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button SaveTextImageButton;
        private RichTextBox PrimaryImplicantsRichTextBox;
    }
}