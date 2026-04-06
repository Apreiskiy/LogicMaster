namespace Logic_Master.Views
{
    partial class FunctionTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionTableForm));
            FuncTablePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)FuncTablePictureBox).BeginInit();
            SuspendLayout();
            // 
            // FuncTablePictureBox
            // 
            FuncTablePictureBox.BackColor = Color.White;
            FuncTablePictureBox.BackgroundImage = Properties.Resources.FuncTable;
            FuncTablePictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            FuncTablePictureBox.Dock = DockStyle.Fill;
            FuncTablePictureBox.Location = new Point(0, 0);
            FuncTablePictureBox.Name = "FuncTablePictureBox";
            FuncTablePictureBox.Size = new Size(484, 561);
            FuncTablePictureBox.TabIndex = 0;
            FuncTablePictureBox.TabStop = false;
            // 
            // FunctionTableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(484, 561);
            Controls.Add(FuncTablePictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 790);
            MinimumSize = new Size(400, 550);
            Name = "FunctionTableForm";
            Text = "Все функции для двух аргументов";
            ((System.ComponentModel.ISupportInitialize)FuncTablePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox FuncTablePictureBox;
    }
}