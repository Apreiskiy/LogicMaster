namespace Logic_Master.Views
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainTabControl = new TabControl();
            HeaderTabPage = new TabPage();
            FixCheckBox = new CheckBox();
            HeaderLabel = new Label();
            AnalyzTabPage = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            SaveFileButton = new Button();
            ImageFunctionButton = new Button();
            NewFunctionButton = new Button();
            FileOpenButton = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            LessButton = new Button();
            MoreButton = new Button();
            ReverseImplicationButton = new Button();
            ImplicationButton = new Button();
            EquvalenceButton = new Button();
            VebbaButton = new Button();
            ShefferButton = new Button();
            ExclusiveOrButton = new Button();
            OrButton = new Button();
            AndButton = new Button();
            NegativeButton = new Button();
            RightBreacketButton = new Button();
            LeftBracketButton = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            DeleteRightButton = new Button();
            DeleteLeftButton = new Button();
            EndCursorButton = new Button();
            StartCursorButton = new Button();
            RightCursorButton = new Button();
            LeftCursorButton = new Button();
            panel3 = new Panel();
            TableFuncButton = new Button();
            ButtonPaneli = new Panel();
            GideButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            X1FuncButton = new Button();
            UnitFuncButton = new Button();
            ZeroFuncButton = new Button();
            X7FuncButton = new Button();
            X9FuncButton = new Button();
            X6FuncButton = new Button();
            X8FuncButton = new Button();
            X2FuncButton = new Button();
            X3FuncButton = new Button();
            X4FuncButton = new Button();
            X5FuncButton = new Button();
            ErrorOutputLabel = new Label();
            FunctionPictureBox = new PictureBox();
            BazisTabPage = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            label4 = new Label();
            panel2 = new Panel();
            BasisComboBox = new ComboBox();
            label5 = new Label();
            InitialFunctionBazisPictureBox = new PictureBox();
            BasisPictureBox = new PictureBox();
            SynthesisTabPage = new TabPage();
            tableLayoutPanel7 = new TableLayoutPanel();
            panel4 = new Panel();
            MinimizeFuncButton = new Button();
            TruthTableButton = new Button();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            DNSFPictureBox = new PictureBox();
            KSNFPictureBox = new PictureBox();
            InfoTabPage = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            InfoProgramLabel = new Label();
            VersionLabel = new Label();
            ImageListTabContol = new ImageList(components);
            CursorTimer = new System.Windows.Forms.Timer(components);
            PrintTimer = new System.Windows.Forms.Timer(components);
            PauseTimer = new System.Windows.Forms.Timer(components);
            MainTabControl.SuspendLayout();
            HeaderTabPage.SuspendLayout();
            AnalyzTabPage.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            ButtonPaneli.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FunctionPictureBox).BeginInit();
            BazisTabPage.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InitialFunctionBazisPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BasisPictureBox).BeginInit();
            SynthesisTabPage.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DNSFPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KSNFPictureBox).BeginInit();
            InfoTabPage.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabControl
            // 
            MainTabControl.Controls.Add(HeaderTabPage);
            MainTabControl.Controls.Add(AnalyzTabPage);
            MainTabControl.Controls.Add(BazisTabPage);
            MainTabControl.Controls.Add(SynthesisTabPage);
            MainTabControl.Controls.Add(InfoTabPage);
            MainTabControl.Dock = DockStyle.Fill;
            MainTabControl.ImageList = ImageListTabContol;
            MainTabControl.ImeMode = ImeMode.NoControl;
            MainTabControl.Location = new Point(0, 0);
            MainTabControl.Margin = new Padding(3, 2, 3, 2);
            MainTabControl.Name = "MainTabControl";
            MainTabControl.SelectedIndex = 0;
            MainTabControl.Size = new Size(683, 218);
            MainTabControl.TabIndex = 0;
            MainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
            MainTabControl.KeyDown += Action_KeyDown;
            // 
            // HeaderTabPage
            // 
            HeaderTabPage.BackgroundImageLayout = ImageLayout.None;
            HeaderTabPage.Controls.Add(FixCheckBox);
            HeaderTabPage.Controls.Add(HeaderLabel);
            HeaderTabPage.Location = new Point(4, 24);
            HeaderTabPage.Margin = new Padding(3, 2, 3, 2);
            HeaderTabPage.Name = "HeaderTabPage";
            HeaderTabPage.Padding = new Padding(3, 2, 3, 2);
            HeaderTabPage.Size = new Size(675, 190);
            HeaderTabPage.TabIndex = 0;
            HeaderTabPage.Text = "Заголовок";
            HeaderTabPage.UseVisualStyleBackColor = true;
            // 
            // FixCheckBox
            // 
            FixCheckBox.AutoSize = true;
            FixCheckBox.BackColor = Color.Silver;
            FixCheckBox.ForeColor = Color.Black;
            FixCheckBox.Location = new Point(8, 7);
            FixCheckBox.Name = "FixCheckBox";
            FixCheckBox.Size = new Size(236, 19);
            FixCheckBox.TabIndex = 2;
            FixCheckBox.Text = "Закрепить приложение поверх других";
            FixCheckBox.UseVisualStyleBackColor = false;
            FixCheckBox.CheckedChanged += FixCheckBox_CheckedChanged;
            // 
            // HeaderLabel
            // 
            HeaderLabel.BackColor = Color.Silver;
            HeaderLabel.BorderStyle = BorderStyle.Fixed3D;
            HeaderLabel.Dock = DockStyle.Fill;
            HeaderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            HeaderLabel.Location = new Point(3, 2);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(669, 186);
            HeaderLabel.TabIndex = 0;
            HeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AnalyzTabPage
            // 
            AnalyzTabPage.BackgroundImageLayout = ImageLayout.Zoom;
            AnalyzTabPage.Controls.Add(tableLayoutPanel1);
            AnalyzTabPage.ImageKey = "(нет)";
            AnalyzTabPage.Location = new Point(4, 24);
            AnalyzTabPage.Margin = new Padding(3, 2, 3, 2);
            AnalyzTabPage.Name = "AnalyzTabPage";
            AnalyzTabPage.Padding = new Padding(3, 2, 3, 2);
            AnalyzTabPage.Size = new Size(675, 190);
            AnalyzTabPage.TabIndex = 1;
            AnalyzTabPage.Text = "Анализ";
            AnalyzTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 3);
            tableLayoutPanel1.Controls.Add(ErrorOutputLabel, 0, 4);
            tableLayoutPanel1.Controls.Add(FunctionPictureBox, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 2);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(669, 186);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(474, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите анализируемую функцию (приоритеты выполнения операций отсутствуют)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(322, 15);
            label2.TabIndex = 1;
            label2.Text = "          (Правая кнопка мыши - вызов контекстного меню)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel5);
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(ButtonPaneli);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 97);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(663, 72);
            panel1.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.Silver;
            tableLayoutPanel5.ColumnCount = 4;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(SaveFileButton, 0, 0);
            tableLayoutPanel5.Controls.Add(ImageFunctionButton, 0, 0);
            tableLayoutPanel5.Controls.Add(NewFunctionButton, 0, 0);
            tableLayoutPanel5.Controls.Add(FileOpenButton, 0, 0);
            tableLayoutPanel5.Location = new Point(459, 38);
            tableLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel5.Size = new Size(124, 32);
            tableLayoutPanel5.TabIndex = 18;
            // 
            // SaveFileButton
            // 
            SaveFileButton.BackgroundImage = Properties.Resources.SaveFile;
            SaveFileButton.BackgroundImageLayout = ImageLayout.Zoom;
            SaveFileButton.Location = new Point(62, 1);
            SaveFileButton.Margin = new Padding(0, 1, 1, 1);
            SaveFileButton.Name = "SaveFileButton";
            SaveFileButton.Size = new Size(30, 29);
            SaveFileButton.TabIndex = 22;
            SaveFileButton.UseVisualStyleBackColor = true;
            SaveFileButton.Click += SaveFileButton_Click;
            SaveFileButton.KeyDown += Action_KeyDown;
            SaveFileButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ImageFunctionButton
            // 
            ImageFunctionButton.BackgroundImage = Properties.Resources.FileinImage2;
            ImageFunctionButton.BackgroundImageLayout = ImageLayout.Zoom;
            ImageFunctionButton.Location = new Point(94, 1);
            ImageFunctionButton.Margin = new Padding(1);
            ImageFunctionButton.Name = "ImageFunctionButton";
            ImageFunctionButton.Size = new Size(29, 29);
            ImageFunctionButton.TabIndex = 21;
            ImageFunctionButton.UseVisualStyleBackColor = true;
            ImageFunctionButton.Click += ImageFunctionButton_Click;
            ImageFunctionButton.KeyDown += Action_KeyDown;
            ImageFunctionButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // NewFunctionButton
            // 
            NewFunctionButton.BackgroundImage = Properties.Resources.newFile;
            NewFunctionButton.BackgroundImageLayout = ImageLayout.Zoom;
            NewFunctionButton.Location = new Point(1, 1);
            NewFunctionButton.Margin = new Padding(1, 1, 0, 1);
            NewFunctionButton.Name = "NewFunctionButton";
            NewFunctionButton.Size = new Size(30, 29);
            NewFunctionButton.TabIndex = 20;
            NewFunctionButton.UseVisualStyleBackColor = true;
            NewFunctionButton.Click += NewFunctionButton_Click;
            NewFunctionButton.KeyDown += Action_KeyDown;
            NewFunctionButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // FileOpenButton
            // 
            FileOpenButton.BackgroundImage = Properties.Resources.FileOpen2;
            FileOpenButton.BackgroundImageLayout = ImageLayout.Zoom;
            FileOpenButton.Location = new Point(31, 1);
            FileOpenButton.Margin = new Padding(0, 1, 0, 1);
            FileOpenButton.Name = "FileOpenButton";
            FileOpenButton.Size = new Size(30, 29);
            FileOpenButton.TabIndex = 19;
            FileOpenButton.UseVisualStyleBackColor = true;
            FileOpenButton.Click += FileOpenButton_Click;
            FileOpenButton.KeyDown += Action_KeyDown;
            FileOpenButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Silver;
            tableLayoutPanel4.ColumnCount = 13;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(LessButton, 12, 0);
            tableLayoutPanel4.Controls.Add(MoreButton, 11, 0);
            tableLayoutPanel4.Controls.Add(ReverseImplicationButton, 10, 0);
            tableLayoutPanel4.Controls.Add(ImplicationButton, 9, 0);
            tableLayoutPanel4.Controls.Add(EquvalenceButton, 8, 0);
            tableLayoutPanel4.Controls.Add(VebbaButton, 7, 0);
            tableLayoutPanel4.Controls.Add(ShefferButton, 6, 0);
            tableLayoutPanel4.Controls.Add(ExclusiveOrButton, 5, 0);
            tableLayoutPanel4.Controls.Add(OrButton, 4, 0);
            tableLayoutPanel4.Controls.Add(AndButton, 3, 0);
            tableLayoutPanel4.Controls.Add(NegativeButton, 2, 0);
            tableLayoutPanel4.Controls.Add(RightBreacketButton, 1, 0);
            tableLayoutPanel4.Controls.Add(LeftBracketButton, 0, 0);
            tableLayoutPanel4.Location = new Point(57, 38);
            tableLayoutPanel4.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(396, 32);
            tableLayoutPanel4.TabIndex = 17;
            // 
            // LessButton
            // 
            LessButton.Image = Properties.Resources.Less;
            LessButton.Location = new Point(365, 1);
            LessButton.Margin = new Padding(0, 1, 1, 1);
            LessButton.Name = "LessButton";
            LessButton.Size = new Size(30, 29);
            LessButton.TabIndex = 28;
            LessButton.UseVisualStyleBackColor = true;
            LessButton.Click += ArgumentAddButton_Click;
            LessButton.KeyDown += Action_KeyDown;
            LessButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // MoreButton
            // 
            MoreButton.Image = Properties.Resources.More;
            MoreButton.Location = new Point(335, 1);
            MoreButton.Margin = new Padding(0, 1, 0, 1);
            MoreButton.Name = "MoreButton";
            MoreButton.Size = new Size(30, 29);
            MoreButton.TabIndex = 27;
            MoreButton.UseVisualStyleBackColor = true;
            MoreButton.Click += ArgumentAddButton_Click;
            MoreButton.KeyDown += Action_KeyDown;
            MoreButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ReverseImplicationButton
            // 
            ReverseImplicationButton.Image = Properties.Resources.ReverseImplicatio;
            ReverseImplicationButton.Location = new Point(305, 1);
            ReverseImplicationButton.Margin = new Padding(0, 1, 0, 1);
            ReverseImplicationButton.Name = "ReverseImplicationButton";
            ReverseImplicationButton.Size = new Size(30, 29);
            ReverseImplicationButton.TabIndex = 26;
            ReverseImplicationButton.UseVisualStyleBackColor = true;
            ReverseImplicationButton.Click += ArgumentAddButton_Click;
            ReverseImplicationButton.KeyDown += Action_KeyDown;
            ReverseImplicationButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ImplicationButton
            // 
            ImplicationButton.Image = Properties.Resources.Implication;
            ImplicationButton.Location = new Point(275, 1);
            ImplicationButton.Margin = new Padding(0, 1, 0, 1);
            ImplicationButton.Name = "ImplicationButton";
            ImplicationButton.Size = new Size(30, 29);
            ImplicationButton.TabIndex = 25;
            ImplicationButton.UseVisualStyleBackColor = true;
            ImplicationButton.Click += ArgumentAddButton_Click;
            ImplicationButton.KeyDown += Action_KeyDown;
            ImplicationButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // EquvalenceButton
            // 
            EquvalenceButton.Image = Properties.Resources.Equvalence;
            EquvalenceButton.Location = new Point(245, 1);
            EquvalenceButton.Margin = new Padding(0, 1, 0, 1);
            EquvalenceButton.Name = "EquvalenceButton";
            EquvalenceButton.Size = new Size(30, 29);
            EquvalenceButton.TabIndex = 24;
            EquvalenceButton.UseVisualStyleBackColor = true;
            EquvalenceButton.Click += ArgumentAddButton_Click;
            EquvalenceButton.KeyDown += Action_KeyDown;
            EquvalenceButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // VebbaButton
            // 
            VebbaButton.Image = Properties.Resources.Vebba;
            VebbaButton.Location = new Point(215, 1);
            VebbaButton.Margin = new Padding(0, 1, 0, 1);
            VebbaButton.Name = "VebbaButton";
            VebbaButton.Size = new Size(30, 29);
            VebbaButton.TabIndex = 23;
            VebbaButton.UseVisualStyleBackColor = true;
            VebbaButton.Click += ArgumentAddButton_Click;
            VebbaButton.KeyDown += Action_KeyDown;
            VebbaButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ShefferButton
            // 
            ShefferButton.Image = Properties.Resources.Sheffer;
            ShefferButton.Location = new Point(185, 1);
            ShefferButton.Margin = new Padding(0, 1, 0, 1);
            ShefferButton.Name = "ShefferButton";
            ShefferButton.Size = new Size(30, 29);
            ShefferButton.TabIndex = 22;
            ShefferButton.UseVisualStyleBackColor = true;
            ShefferButton.Click += ArgumentAddButton_Click;
            ShefferButton.KeyDown += Action_KeyDown;
            ShefferButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ExclusiveOrButton
            // 
            ExclusiveOrButton.Image = Properties.Resources.ExclusiveOr;
            ExclusiveOrButton.Location = new Point(155, 1);
            ExclusiveOrButton.Margin = new Padding(0, 1, 0, 1);
            ExclusiveOrButton.Name = "ExclusiveOrButton";
            ExclusiveOrButton.Size = new Size(30, 29);
            ExclusiveOrButton.TabIndex = 21;
            ExclusiveOrButton.UseVisualStyleBackColor = true;
            ExclusiveOrButton.Click += ArgumentAddButton_Click;
            ExclusiveOrButton.KeyDown += Action_KeyDown;
            ExclusiveOrButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // OrButton
            // 
            OrButton.Image = Properties.Resources.Or;
            OrButton.Location = new Point(125, 1);
            OrButton.Margin = new Padding(0, 1, 0, 1);
            OrButton.Name = "OrButton";
            OrButton.Size = new Size(30, 29);
            OrButton.TabIndex = 20;
            OrButton.UseVisualStyleBackColor = true;
            OrButton.Click += ArgumentAddButton_Click;
            OrButton.KeyDown += Action_KeyDown;
            OrButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // AndButton
            // 
            AndButton.Image = Properties.Resources.And;
            AndButton.Location = new Point(95, 1);
            AndButton.Margin = new Padding(1, 1, 0, 1);
            AndButton.Name = "AndButton";
            AndButton.Size = new Size(30, 29);
            AndButton.TabIndex = 19;
            AndButton.UseVisualStyleBackColor = true;
            AndButton.Click += ArgumentAddButton_Click;
            AndButton.KeyDown += Action_KeyDown;
            AndButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // NegativeButton
            // 
            NegativeButton.Image = Properties.Resources.NegativeX;
            NegativeButton.Location = new Point(63, 1);
            NegativeButton.Margin = new Padding(1);
            NegativeButton.Name = "NegativeButton";
            NegativeButton.Size = new Size(30, 29);
            NegativeButton.TabIndex = 18;
            NegativeButton.UseVisualStyleBackColor = true;
            NegativeButton.Click += NegativeButton_Click;
            NegativeButton.KeyDown += Action_KeyDown;
            NegativeButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // RightBreacketButton
            // 
            RightBreacketButton.Image = Properties.Resources.RightBracket;
            RightBreacketButton.Location = new Point(31, 1);
            RightBreacketButton.Margin = new Padding(0, 1, 1, 1);
            RightBreacketButton.Name = "RightBreacketButton";
            RightBreacketButton.Size = new Size(30, 29);
            RightBreacketButton.TabIndex = 18;
            RightBreacketButton.UseVisualStyleBackColor = true;
            RightBreacketButton.Click += ArgumentAddButton_Click;
            RightBreacketButton.KeyDown += Action_KeyDown;
            RightBreacketButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // LeftBracketButton
            // 
            LeftBracketButton.Image = Properties.Resources.LeftBracket;
            LeftBracketButton.Location = new Point(1, 1);
            LeftBracketButton.Margin = new Padding(1, 1, 0, 1);
            LeftBracketButton.Name = "LeftBracketButton";
            LeftBracketButton.Size = new Size(30, 29);
            LeftBracketButton.TabIndex = 18;
            LeftBracketButton.UseVisualStyleBackColor = true;
            LeftBracketButton.Click += ArgumentAddButton_Click;
            LeftBracketButton.KeyDown += Action_KeyDown;
            LeftBracketButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Silver;
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(DeleteRightButton, 5, 0);
            tableLayoutPanel3.Controls.Add(DeleteLeftButton, 4, 0);
            tableLayoutPanel3.Controls.Add(EndCursorButton, 3, 0);
            tableLayoutPanel3.Controls.Add(StartCursorButton, 2, 0);
            tableLayoutPanel3.Controls.Add(RightCursorButton, 1, 0);
            tableLayoutPanel3.Controls.Add(LeftCursorButton, 0, 0);
            tableLayoutPanel3.Location = new Point(397, 2);
            tableLayoutPanel3.Margin = new Padding(1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(186, 32);
            tableLayoutPanel3.TabIndex = 16;
            // 
            // DeleteRightButton
            // 
            DeleteRightButton.BackColor = Color.White;
            DeleteRightButton.BackgroundImage = Properties.Resources.DeleteRight;
            DeleteRightButton.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteRightButton.Location = new Point(155, 1);
            DeleteRightButton.Margin = new Padding(0, 1, 1, 1);
            DeleteRightButton.Name = "DeleteRightButton";
            DeleteRightButton.Size = new Size(30, 29);
            DeleteRightButton.TabIndex = 17;
            DeleteRightButton.UseVisualStyleBackColor = false;
            DeleteRightButton.Click += CursorMoveButton_Click;
            DeleteRightButton.KeyDown += Action_KeyDown;
            DeleteRightButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // DeleteLeftButton
            // 
            DeleteLeftButton.BackColor = Color.White;
            DeleteLeftButton.BackgroundImage = Properties.Resources.DeleteLeft;
            DeleteLeftButton.BackgroundImageLayout = ImageLayout.Zoom;
            DeleteLeftButton.Location = new Point(125, 1);
            DeleteLeftButton.Margin = new Padding(1, 1, 0, 1);
            DeleteLeftButton.Name = "DeleteLeftButton";
            DeleteLeftButton.Size = new Size(30, 29);
            DeleteLeftButton.TabIndex = 17;
            DeleteLeftButton.UseVisualStyleBackColor = false;
            DeleteLeftButton.Click += CursorMoveButton_Click;
            DeleteLeftButton.KeyDown += Action_KeyDown;
            DeleteLeftButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // EndCursorButton
            // 
            EndCursorButton.BackColor = Color.White;
            EndCursorButton.BackgroundImage = Properties.Resources.LeftArrowCursor;
            EndCursorButton.BackgroundImageLayout = ImageLayout.Zoom;
            EndCursorButton.Location = new Point(93, 1);
            EndCursorButton.Margin = new Padding(0, 1, 1, 1);
            EndCursorButton.Name = "EndCursorButton";
            EndCursorButton.Size = new Size(30, 29);
            EndCursorButton.TabIndex = 17;
            EndCursorButton.UseVisualStyleBackColor = false;
            EndCursorButton.Click += CursorMoveButton_Click;
            EndCursorButton.KeyDown += Action_KeyDown;
            EndCursorButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // StartCursorButton
            // 
            StartCursorButton.BackColor = Color.White;
            StartCursorButton.BackgroundImage = Properties.Resources.RightArrorwCursor;
            StartCursorButton.BackgroundImageLayout = ImageLayout.Zoom;
            StartCursorButton.Location = new Point(63, 1);
            StartCursorButton.Margin = new Padding(1, 1, 0, 1);
            StartCursorButton.Name = "StartCursorButton";
            StartCursorButton.Size = new Size(30, 29);
            StartCursorButton.TabIndex = 17;
            StartCursorButton.UseVisualStyleBackColor = false;
            StartCursorButton.Click += CursorMoveButton_Click;
            StartCursorButton.KeyDown += Action_KeyDown;
            StartCursorButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // RightCursorButton
            // 
            RightCursorButton.BackColor = Color.White;
            RightCursorButton.BackgroundImage = Properties.Resources.CursorRight;
            RightCursorButton.BackgroundImageLayout = ImageLayout.Zoom;
            RightCursorButton.Location = new Point(31, 1);
            RightCursorButton.Margin = new Padding(0, 1, 1, 1);
            RightCursorButton.Name = "RightCursorButton";
            RightCursorButton.Size = new Size(30, 29);
            RightCursorButton.TabIndex = 17;
            RightCursorButton.UseVisualStyleBackColor = false;
            RightCursorButton.Click += CursorMoveButton_Click;
            RightCursorButton.KeyDown += Action_KeyDown;
            RightCursorButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // LeftCursorButton
            // 
            LeftCursorButton.BackColor = Color.White;
            LeftCursorButton.BackgroundImage = Properties.Resources.CursorLeft;
            LeftCursorButton.BackgroundImageLayout = ImageLayout.Zoom;
            LeftCursorButton.Location = new Point(1, 1);
            LeftCursorButton.Margin = new Padding(1, 1, 0, 1);
            LeftCursorButton.Name = "LeftCursorButton";
            LeftCursorButton.Size = new Size(30, 29);
            LeftCursorButton.TabIndex = 17;
            LeftCursorButton.UseVisualStyleBackColor = false;
            LeftCursorButton.Click += CursorMoveButton_Click;
            LeftCursorButton.KeyDown += Action_KeyDown;
            LeftCursorButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Controls.Add(TableFuncButton);
            panel3.Location = new Point(19, 38);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(32, 32);
            panel3.TabIndex = 15;
            // 
            // TableFuncButton
            // 
            TableFuncButton.BackgroundImage = Properties.Resources.TruthTableButton;
            TableFuncButton.BackgroundImageLayout = ImageLayout.Zoom;
            TableFuncButton.Location = new Point(1, 1);
            TableFuncButton.Margin = new Padding(1);
            TableFuncButton.Name = "TableFuncButton";
            TableFuncButton.Size = new Size(30, 30);
            TableFuncButton.TabIndex = 1;
            TableFuncButton.UseVisualStyleBackColor = true;
            TableFuncButton.Click += SettingButton_Click;
            TableFuncButton.KeyDown += Action_KeyDown;
            TableFuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ButtonPaneli
            // 
            ButtonPaneli.BackColor = Color.Silver;
            ButtonPaneli.Controls.Add(GideButton);
            ButtonPaneli.Location = new Point(19, 2);
            ButtonPaneli.Margin = new Padding(3, 2, 3, 2);
            ButtonPaneli.Name = "ButtonPaneli";
            ButtonPaneli.Size = new Size(32, 32);
            ButtonPaneli.TabIndex = 14;
            // 
            // GideButton
            // 
            GideButton.BackgroundImage = Properties.Resources.Information;
            GideButton.BackgroundImageLayout = ImageLayout.Zoom;
            GideButton.Location = new Point(1, 1);
            GideButton.Margin = new Padding(1);
            GideButton.Name = "GideButton";
            GideButton.Size = new Size(30, 30);
            GideButton.TabIndex = 0;
            GideButton.UseVisualStyleBackColor = true;
            GideButton.Click += GideButton_Click;
            GideButton.KeyDown += Action_KeyDown;
            GideButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Silver;
            tableLayoutPanel2.ColumnCount = 11;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(X1FuncButton, 0, 0);
            tableLayoutPanel2.Controls.Add(UnitFuncButton, 10, 0);
            tableLayoutPanel2.Controls.Add(ZeroFuncButton, 9, 0);
            tableLayoutPanel2.Controls.Add(X7FuncButton, 6, 0);
            tableLayoutPanel2.Controls.Add(X9FuncButton, 8, 0);
            tableLayoutPanel2.Controls.Add(X6FuncButton, 5, 0);
            tableLayoutPanel2.Controls.Add(X8FuncButton, 7, 0);
            tableLayoutPanel2.Controls.Add(X2FuncButton, 1, 0);
            tableLayoutPanel2.Controls.Add(X3FuncButton, 2, 0);
            tableLayoutPanel2.Controls.Add(X4FuncButton, 3, 0);
            tableLayoutPanel2.Controls.Add(X5FuncButton, 4, 0);
            tableLayoutPanel2.Location = new Point(57, 2);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.Size = new Size(334, 32);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // X1FuncButton
            // 
            X1FuncButton.BackColor = Color.White;
            X1FuncButton.BackgroundImageLayout = ImageLayout.Zoom;
            X1FuncButton.Image = Properties.Resources.x1;
            X1FuncButton.Location = new Point(1, 1);
            X1FuncButton.Margin = new Padding(1, 1, 0, 1);
            X1FuncButton.Name = "X1FuncButton";
            X1FuncButton.Size = new Size(30, 29);
            X1FuncButton.TabIndex = 2;
            X1FuncButton.TabStop = false;
            X1FuncButton.UseVisualStyleBackColor = false;
            X1FuncButton.Click += ArgumentAddButton_Click;
            X1FuncButton.KeyDown += Action_KeyDown;
            X1FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // UnitFuncButton
            // 
            UnitFuncButton.BackColor = Color.White;
            UnitFuncButton.Image = Properties.Resources.OneSymbol;
            UnitFuncButton.Location = new Point(303, 1);
            UnitFuncButton.Margin = new Padding(0, 1, 1, 1);
            UnitFuncButton.Name = "UnitFuncButton";
            UnitFuncButton.Size = new Size(30, 29);
            UnitFuncButton.TabIndex = 7;
            UnitFuncButton.UseVisualStyleBackColor = false;
            UnitFuncButton.Click += ArgumentAddButton_Click;
            UnitFuncButton.KeyDown += Action_KeyDown;
            UnitFuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ZeroFuncButton
            // 
            ZeroFuncButton.BackColor = Color.White;
            ZeroFuncButton.Image = Properties.Resources.ZeroSymbol;
            ZeroFuncButton.Location = new Point(273, 1);
            ZeroFuncButton.Margin = new Padding(1, 1, 0, 1);
            ZeroFuncButton.Name = "ZeroFuncButton";
            ZeroFuncButton.Size = new Size(30, 29);
            ZeroFuncButton.TabIndex = 10;
            ZeroFuncButton.UseVisualStyleBackColor = false;
            ZeroFuncButton.Click += ArgumentAddButton_Click;
            ZeroFuncButton.KeyDown += Action_KeyDown;
            ZeroFuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X7FuncButton
            // 
            X7FuncButton.BackColor = Color.White;
            X7FuncButton.Image = Properties.Resources.x7;
            X7FuncButton.Location = new Point(181, 1);
            X7FuncButton.Margin = new Padding(0, 1, 0, 1);
            X7FuncButton.Name = "X7FuncButton";
            X7FuncButton.Size = new Size(30, 29);
            X7FuncButton.TabIndex = 11;
            X7FuncButton.UseVisualStyleBackColor = false;
            X7FuncButton.Click += ArgumentAddButton_Click;
            X7FuncButton.KeyDown += Action_KeyDown;
            X7FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X9FuncButton
            // 
            X9FuncButton.BackColor = Color.White;
            X9FuncButton.Image = Properties.Resources.x9;
            X9FuncButton.Location = new Point(241, 1);
            X9FuncButton.Margin = new Padding(0, 1, 1, 1);
            X9FuncButton.Name = "X9FuncButton";
            X9FuncButton.Size = new Size(30, 29);
            X9FuncButton.TabIndex = 9;
            X9FuncButton.UseVisualStyleBackColor = false;
            X9FuncButton.Click += ArgumentAddButton_Click;
            X9FuncButton.KeyDown += Action_KeyDown;
            X9FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X6FuncButton
            // 
            X6FuncButton.BackColor = Color.White;
            X6FuncButton.Image = Properties.Resources.x6;
            X6FuncButton.Location = new Point(151, 1);
            X6FuncButton.Margin = new Padding(0, 1, 0, 1);
            X6FuncButton.Name = "X6FuncButton";
            X6FuncButton.Size = new Size(30, 29);
            X6FuncButton.TabIndex = 12;
            X6FuncButton.UseVisualStyleBackColor = false;
            X6FuncButton.Click += ArgumentAddButton_Click;
            X6FuncButton.KeyDown += Action_KeyDown;
            X6FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X8FuncButton
            // 
            X8FuncButton.BackColor = Color.White;
            X8FuncButton.Image = Properties.Resources.x8;
            X8FuncButton.Location = new Point(211, 1);
            X8FuncButton.Margin = new Padding(0, 1, 0, 1);
            X8FuncButton.Name = "X8FuncButton";
            X8FuncButton.Size = new Size(30, 29);
            X8FuncButton.TabIndex = 8;
            X8FuncButton.UseVisualStyleBackColor = false;
            X8FuncButton.Click += ArgumentAddButton_Click;
            X8FuncButton.KeyDown += Action_KeyDown;
            X8FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X2FuncButton
            // 
            X2FuncButton.BackColor = Color.White;
            X2FuncButton.BackgroundImageLayout = ImageLayout.Zoom;
            X2FuncButton.Image = Properties.Resources.x2;
            X2FuncButton.Location = new Point(31, 1);
            X2FuncButton.Margin = new Padding(0, 1, 0, 1);
            X2FuncButton.Name = "X2FuncButton";
            X2FuncButton.Size = new Size(30, 29);
            X2FuncButton.TabIndex = 6;
            X2FuncButton.TabStop = false;
            X2FuncButton.UseVisualStyleBackColor = false;
            X2FuncButton.Click += ArgumentAddButton_Click;
            X2FuncButton.KeyDown += Action_KeyDown;
            X2FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X3FuncButton
            // 
            X3FuncButton.BackColor = Color.White;
            X3FuncButton.Image = Properties.Resources.x3;
            X3FuncButton.Location = new Point(61, 1);
            X3FuncButton.Margin = new Padding(0, 1, 0, 1);
            X3FuncButton.Name = "X3FuncButton";
            X3FuncButton.Size = new Size(30, 29);
            X3FuncButton.TabIndex = 5;
            X3FuncButton.UseVisualStyleBackColor = false;
            X3FuncButton.Click += ArgumentAddButton_Click;
            X3FuncButton.KeyDown += Action_KeyDown;
            X3FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X4FuncButton
            // 
            X4FuncButton.BackColor = Color.White;
            X4FuncButton.Image = Properties.Resources.x4;
            X4FuncButton.Location = new Point(91, 1);
            X4FuncButton.Margin = new Padding(0, 1, 0, 1);
            X4FuncButton.Name = "X4FuncButton";
            X4FuncButton.Size = new Size(30, 29);
            X4FuncButton.TabIndex = 4;
            X4FuncButton.UseVisualStyleBackColor = false;
            X4FuncButton.Click += ArgumentAddButton_Click;
            X4FuncButton.KeyDown += Action_KeyDown;
            X4FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // X5FuncButton
            // 
            X5FuncButton.BackColor = Color.White;
            X5FuncButton.Image = Properties.Resources.x5;
            X5FuncButton.Location = new Point(121, 1);
            X5FuncButton.Margin = new Padding(0, 1, 0, 1);
            X5FuncButton.Name = "X5FuncButton";
            X5FuncButton.Size = new Size(30, 29);
            X5FuncButton.TabIndex = 3;
            X5FuncButton.UseVisualStyleBackColor = false;
            X5FuncButton.Click += ArgumentAddButton_Click;
            X5FuncButton.KeyDown += Action_KeyDown;
            X5FuncButton.PreviewKeyDown += AnyButton_PreviewKeyDown;
            // 
            // ErrorOutputLabel
            // 
            ErrorOutputLabel.Dock = DockStyle.Fill;
            ErrorOutputLabel.Location = new Point(3, 171);
            ErrorOutputLabel.Name = "ErrorOutputLabel";
            ErrorOutputLabel.Size = new Size(663, 15);
            ErrorOutputLabel.TabIndex = 4;
            ErrorOutputLabel.Text = "Функция не задана";
            ErrorOutputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FunctionPictureBox
            // 
            FunctionPictureBox.BorderStyle = BorderStyle.Fixed3D;
            FunctionPictureBox.Dock = DockStyle.Fill;
            FunctionPictureBox.Location = new Point(3, 32);
            FunctionPictureBox.Margin = new Padding(3, 2, 3, 2);
            FunctionPictureBox.Name = "FunctionPictureBox";
            FunctionPictureBox.Size = new Size(663, 61);
            FunctionPictureBox.TabIndex = 5;
            FunctionPictureBox.TabStop = false;
            FunctionPictureBox.MouseDown += FunctionPictureBox_MouseDown;
            // 
            // BazisTabPage
            // 
            BazisTabPage.BackgroundImageLayout = ImageLayout.Zoom;
            BazisTabPage.Controls.Add(tableLayoutPanel6);
            BazisTabPage.ImageKey = "(нет)";
            BazisTabPage.Location = new Point(4, 24);
            BazisTabPage.Margin = new Padding(3, 2, 3, 2);
            BazisTabPage.Name = "BazisTabPage";
            BazisTabPage.Size = new Size(675, 190);
            BazisTabPage.TabIndex = 2;
            BazisTabPage.Text = "Базисы";
            BazisTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(label4, 0, 0);
            tableLayoutPanel6.Controls.Add(panel2, 0, 2);
            tableLayoutPanel6.Controls.Add(InitialFunctionBazisPictureBox, 0, 1);
            tableLayoutPanel6.Controls.Add(BasisPictureBox, 0, 3);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 4;
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(675, 190);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(669, 15);
            label4.TabIndex = 0;
            label4.Text = "Исходная функция";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(BasisComboBox);
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 89);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(669, 27);
            panel2.TabIndex = 2;
            // 
            // BasisComboBox
            // 
            BasisComboBox.FormattingEnabled = true;
            BasisComboBox.Items.AddRange(new object[] { "{ %, &, + }", "{ %, & }", "{ %, + }", "{ %, /}", "{ / }", "{ %, o }", "{ o }", "{ & , +, Ꚛ, 1 }" });
            BasisComboBox.Location = new Point(223, 2);
            BasisComboBox.Margin = new Padding(3, 2, 3, 2);
            BasisComboBox.Name = "BasisComboBox";
            BasisComboBox.Size = new Size(126, 23);
            BasisComboBox.TabIndex = 1;
            BasisComboBox.SelectedIndexChanged += BasisComboBox_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 4);
            label5.Name = "label5";
            label5.Size = new Size(192, 15);
            label5.TabIndex = 0;
            label5.Text = "Представление функции в базисе";
            // 
            // InitialFunctionBazisPictureBox
            // 
            InitialFunctionBazisPictureBox.BorderStyle = BorderStyle.Fixed3D;
            InitialFunctionBazisPictureBox.Dock = DockStyle.Fill;
            InitialFunctionBazisPictureBox.Location = new Point(3, 17);
            InitialFunctionBazisPictureBox.Margin = new Padding(3, 2, 3, 2);
            InitialFunctionBazisPictureBox.Name = "InitialFunctionBazisPictureBox";
            InitialFunctionBazisPictureBox.Size = new Size(669, 68);
            InitialFunctionBazisPictureBox.TabIndex = 4;
            InitialFunctionBazisPictureBox.TabStop = false;
            // 
            // BasisPictureBox
            // 
            BasisPictureBox.BorderStyle = BorderStyle.Fixed3D;
            BasisPictureBox.Dock = DockStyle.Fill;
            BasisPictureBox.Location = new Point(3, 120);
            BasisPictureBox.Margin = new Padding(3, 2, 3, 2);
            BasisPictureBox.Name = "BasisPictureBox";
            BasisPictureBox.Size = new Size(669, 68);
            BasisPictureBox.TabIndex = 5;
            BasisPictureBox.TabStop = false;
            // 
            // SynthesisTabPage
            // 
            SynthesisTabPage.BackgroundImageLayout = ImageLayout.Zoom;
            SynthesisTabPage.Controls.Add(tableLayoutPanel7);
            SynthesisTabPage.ImageKey = "(нет)";
            SynthesisTabPage.Location = new Point(4, 24);
            SynthesisTabPage.Margin = new Padding(3, 2, 3, 2);
            SynthesisTabPage.Name = "SynthesisTabPage";
            SynthesisTabPage.Size = new Size(675, 190);
            SynthesisTabPage.TabIndex = 3;
            SynthesisTabPage.Text = "Синтез";
            SynthesisTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(panel4, 0, 0);
            tableLayoutPanel7.Controls.Add(label6, 0, 1);
            tableLayoutPanel7.Controls.Add(label7, 0, 3);
            tableLayoutPanel7.Controls.Add(DNSFPictureBox, 0, 2);
            tableLayoutPanel7.Controls.Add(KSNFPictureBox, 0, 4);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 5;
            tableLayoutPanel7.RowStyles.Add(new RowStyle());
            tableLayoutPanel7.RowStyles.Add(new RowStyle());
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle());
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(675, 190);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(MinimizeFuncButton);
            panel4.Controls.Add(TruthTableButton);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 2);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(669, 34);
            panel4.TabIndex = 0;
            // 
            // MinimizeFuncButton
            // 
            MinimizeFuncButton.Anchor = AnchorStyles.Top;
            MinimizeFuncButton.BackgroundImage = Properties.Resources.icons8_уценка_30;
            MinimizeFuncButton.BackgroundImageLayout = ImageLayout.Zoom;
            MinimizeFuncButton.Location = new Point(366, 2);
            MinimizeFuncButton.Margin = new Padding(3, 2, 3, 2);
            MinimizeFuncButton.Name = "MinimizeFuncButton";
            MinimizeFuncButton.Size = new Size(30, 30);
            MinimizeFuncButton.TabIndex = 3;
            MinimizeFuncButton.UseVisualStyleBackColor = true;
            MinimizeFuncButton.Click += MinimizeFuncButton_Click;
            // 
            // TruthTableButton
            // 
            TruthTableButton.Anchor = AnchorStyles.Top;
            TruthTableButton.BackgroundImage = Properties.Resources.TableIcon;
            TruthTableButton.BackgroundImageLayout = ImageLayout.Zoom;
            TruthTableButton.Location = new Point(102, 2);
            TruthTableButton.Margin = new Padding(3, 2, 3, 2);
            TruthTableButton.Name = "TruthTableButton";
            TruthTableButton.Size = new Size(30, 30);
            TruthTableButton.TabIndex = 2;
            TruthTableButton.UseVisualStyleBackColor = true;
            TruthTableButton.Click += TruthTableButton_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(403, 10);
            label9.Name = "label9";
            label9.Size = new Size(159, 15);
            label9.TabIndex = 1;
            label9.Text = "Минимизировать функцию";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(139, 10);
            label8.Name = "label8";
            label8.Size = new Size(158, 15);
            label8.TabIndex = 0;
            label8.Text = "Задать таблицу истинности";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 38);
            label6.Name = "label6";
            label6.Size = new Size(669, 15);
            label6.TabIndex = 1;
            label6.Text = "ДСНФ (Дизъюнктивная Совершенная Нормальная Форма)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 114);
            label7.Name = "label7";
            label7.Size = new Size(669, 15);
            label7.TabIndex = 3;
            label7.Text = "КСНФ (Конъюнктивная Совершенная Нормальная Форма)";
            // 
            // DNSFPictureBox
            // 
            DNSFPictureBox.BorderStyle = BorderStyle.Fixed3D;
            DNSFPictureBox.Dock = DockStyle.Fill;
            DNSFPictureBox.Location = new Point(3, 55);
            DNSFPictureBox.Margin = new Padding(3, 2, 3, 2);
            DNSFPictureBox.Name = "DNSFPictureBox";
            DNSFPictureBox.Size = new Size(669, 57);
            DNSFPictureBox.TabIndex = 5;
            DNSFPictureBox.TabStop = false;
            // 
            // KSNFPictureBox
            // 
            KSNFPictureBox.BorderStyle = BorderStyle.Fixed3D;
            KSNFPictureBox.Dock = DockStyle.Fill;
            KSNFPictureBox.Location = new Point(3, 131);
            KSNFPictureBox.Margin = new Padding(3, 2, 3, 2);
            KSNFPictureBox.Name = "KSNFPictureBox";
            KSNFPictureBox.Size = new Size(669, 57);
            KSNFPictureBox.TabIndex = 6;
            KSNFPictureBox.TabStop = false;
            // 
            // InfoTabPage
            // 
            InfoTabPage.BackgroundImageLayout = ImageLayout.Zoom;
            InfoTabPage.Controls.Add(tableLayoutPanel8);
            InfoTabPage.Location = new Point(4, 24);
            InfoTabPage.Margin = new Padding(3, 2, 3, 2);
            InfoTabPage.Name = "InfoTabPage";
            InfoTabPage.Size = new Size(675, 190);
            InfoTabPage.TabIndex = 4;
            InfoTabPage.Text = "О программе";
            InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel8.Controls.Add(InfoProgramLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(VersionLabel, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(675, 190);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // InfoProgramLabel
            // 
            InfoProgramLabel.BackColor = Color.White;
            InfoProgramLabel.Dock = DockStyle.Fill;
            InfoProgramLabel.Location = new Point(3, 0);
            InfoProgramLabel.Name = "InfoProgramLabel";
            InfoProgramLabel.Size = new Size(669, 95);
            InfoProgramLabel.TabIndex = 0;
            InfoProgramLabel.Text = "Программный комплекс для\r\nАнализа и синтеза логических функций\r\n";
            InfoProgramLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.BackColor = Color.Silver;
            VersionLabel.BorderStyle = BorderStyle.Fixed3D;
            VersionLabel.Dock = DockStyle.Fill;
            VersionLabel.Location = new Point(3, 95);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(669, 95);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "Версия 1.0 (November  2024)\r\n\r\nСреда разработки: Visual Studio, язык C#";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImageListTabContol
            // 
            ImageListTabContol.ColorDepth = ColorDepth.Depth32Bit;
            ImageListTabContol.ImageSize = new Size(15, 15);
            ImageListTabContol.TransparentColor = Color.Transparent;
            // 
            // CursorTimer
            // 
            CursorTimer.Enabled = true;
            CursorTimer.Interval = 500;
            CursorTimer.Tick += CursorTimer_Tick;
            // 
            // PrintTimer
            // 
            PrintTimer.Tick += PrintTimer_Tick;
            // 
            // PauseTimer
            // 
            PauseTimer.Tick += PauseTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(683, 218);
            Controls.Add(MainTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(620, 243);
            Name = "MainForm";
            Text = "Logic Master";
            Load += MainForm_Load;
            SizeChanged += MainForm_SizeChanged;
            MainTabControl.ResumeLayout(false);
            HeaderTabPage.ResumeLayout(false);
            HeaderTabPage.PerformLayout();
            AnalyzTabPage.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ButtonPaneli.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FunctionPictureBox).EndInit();
            BazisTabPage.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InitialFunctionBazisPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)BasisPictureBox).EndInit();
            SynthesisTabPage.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DNSFPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)KSNFPictureBox).EndInit();
            InfoTabPage.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainTabControl;
        private TabPage HeaderTabPage;
        private TabPage AnalyzTabPage;
        private TabPage BazisTabPage;
        private TabPage SynthesisTabPage;
        private TabPage InfoTabPage;
        private Label HeaderLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Button X6FuncButton;
        private Button X7FuncButton;
        private Button ZeroFuncButton;
        private Button X9FuncButton;
        private Button X8FuncButton;
        private Button UnitFuncButton;
        private Button X2FuncButton;
        private Button X3FuncButton;
        private Button X4FuncButton;
        private Button X5FuncButton;
        private Button X1FuncButton;
        private Button TableFuncButton;
        private Button GideButton;
        private Label ErrorOutputLabel;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel ButtonPaneli;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel3;
        private Button DeleteRightButton;
        private Button DeleteLeftButton;
        private Button EndCursorButton;
        private Button StartCursorButton;
        private Button RightCursorButton;
        private Button LeftCursorButton;
        private TableLayoutPanel tableLayoutPanel4;
        private Button LessButton;
        private Button MoreButton;
        private Button ReverseImplicationButton;
        private Button ImplicationButton;
        private Button EquvalenceButton;
        private Button VebbaButton;
        private Button ShefferButton;
        private Button ExclusiveOrButton;
        private Button OrButton;
        private Button AndButton;
        private Button NegativeButton;
        private Button RightBreacketButton;
        private Button LeftBracketButton;
        private TableLayoutPanel tableLayoutPanel5;
        private Button SaveFileButton;
        private Button ImageFunctionButton;
        private Button NewFunctionButton;
        private Button FileOpenButton;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label4;
        private Panel panel2;
        private ComboBox BasisComboBox;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel7;
        private Panel panel4;
        private Button TruthTableButton;
        private Label label9;
        private Label label8;
        private Label label6;
        private Label label7;
        private Button MinimizeFuncButton;
        private Label InfoProgramLabel;
        private TableLayoutPanel tableLayoutPanel8;
        private Label VersionLabel;
        private PictureBox FunctionPictureBox;
        private System.Windows.Forms.Timer CursorTimer;
        private PictureBox InitialFunctionBazisPictureBox;
        private PictureBox BasisPictureBox;
        private PictureBox DNSFPictureBox;
        private PictureBox KSNFPictureBox;
        private System.Windows.Forms.Timer PrintTimer;
        private System.Windows.Forms.Timer PauseTimer;
        private ImageList ImageListTabContol;
        private CheckBox FixCheckBox;
    }
}
