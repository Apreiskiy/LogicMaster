namespace Logic_Master
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MainTabControl = new TabControl();
            HeaderTabPage = new TabPage();
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
            SettingButton = new Button();
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
            BazisComboBox = new ComboBox();
            label5 = new Label();
            BazisFunction = new TextBox();
            InitialFunctionBazisPictureBox = new PictureBox();
            SynthesisTabPage = new TabPage();
            tableLayoutPanel7 = new TableLayoutPanel();
            panel4 = new Panel();
            MinimizeFuncButton = new Button();
            button37 = new Button();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            DNSFTextBox = new TextBox();
            label7 = new Label();
            KNSFTextBox = new TextBox();
            InfoTabPage = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            InfoProgramLabel = new Label();
            VersionLabel = new Label();
            CursorTimer = new System.Windows.Forms.Timer(components);
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
            SynthesisTabPage.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            panel4.SuspendLayout();
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
            MainTabControl.Location = new Point(0, 0);
            MainTabControl.Name = "MainTabControl";
            MainTabControl.SelectedIndex = 0;
            MainTabControl.Size = new Size(782, 253);
            MainTabControl.TabIndex = 0;
            MainTabControl.KeyDown += Action_KeyDown;
            // 
            // HeaderTabPage
            // 
            HeaderTabPage.Controls.Add(HeaderLabel);
            HeaderTabPage.Location = new Point(4, 29);
            HeaderTabPage.Name = "HeaderTabPage";
            HeaderTabPage.Padding = new Padding(3);
            HeaderTabPage.Size = new Size(774, 220);
            HeaderTabPage.TabIndex = 0;
            HeaderTabPage.Text = "Заголовок";
            HeaderTabPage.UseVisualStyleBackColor = true;
            // 
            // HeaderLabel
            // 
            HeaderLabel.BackColor = Color.Silver;
            HeaderLabel.Dock = DockStyle.Fill;
            HeaderLabel.Location = new Point(3, 3);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(768, 214);
            HeaderLabel.TabIndex = 0;
            HeaderLabel.Text = "Програмнный комплекс для\r\nАнализа и синтеза логических функций";
            HeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AnalyzTabPage
            // 
            AnalyzTabPage.Controls.Add(tableLayoutPanel1);
            AnalyzTabPage.Location = new Point(4, 29);
            AnalyzTabPage.Name = "AnalyzTabPage";
            AnalyzTabPage.Padding = new Padding(3);
            AnalyzTabPage.Size = new Size(774, 220);
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
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(768, 214);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(762, 20);
            label1.TabIndex = 0;
            label1.Text = "Введите анализируемую функцию";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 20);
            label2.Name = "label2";
            label2.Size = new Size(762, 20);
            label2.TabIndex = 1;
            label2.Text = "Правая кнопка мыши открывает контекст";
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
            panel1.Location = new Point(3, 115);
            panel1.Name = "panel1";
            panel1.Size = new Size(762, 76);
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
            tableLayoutPanel5.Location = new Point(463, 41);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(124, 32);
            tableLayoutPanel5.TabIndex = 18;
            // 
            // SaveFileButton
            // 
            SaveFileButton.Location = new Point(62, 1);
            SaveFileButton.Margin = new Padding(0, 1, 1, 1);
            SaveFileButton.Name = "SaveFileButton";
            SaveFileButton.Size = new Size(30, 30);
            SaveFileButton.TabIndex = 22;
            SaveFileButton.Text = "button36";
            SaveFileButton.UseVisualStyleBackColor = true;
            SaveFileButton.Click += SaveFileButton_Click;
            SaveFileButton.KeyDown += Action_KeyDown;
            // 
            // ImageFunctionButton
            // 
            ImageFunctionButton.Location = new Point(94, 1);
            ImageFunctionButton.Margin = new Padding(1);
            ImageFunctionButton.Name = "ImageFunctionButton";
            ImageFunctionButton.Size = new Size(29, 30);
            ImageFunctionButton.TabIndex = 21;
            ImageFunctionButton.Text = "button35";
            ImageFunctionButton.UseVisualStyleBackColor = true;
            ImageFunctionButton.Click += ActionButton_Click;
            ImageFunctionButton.KeyDown += Action_KeyDown;
            // 
            // NewFunctionButton
            // 
            NewFunctionButton.Location = new Point(1, 1);
            NewFunctionButton.Margin = new Padding(1, 1, 0, 1);
            NewFunctionButton.Name = "NewFunctionButton";
            NewFunctionButton.Size = new Size(30, 30);
            NewFunctionButton.TabIndex = 20;
            NewFunctionButton.Text = "button34";
            NewFunctionButton.UseVisualStyleBackColor = true;
            NewFunctionButton.Click += NewFunctionButton_Click;
            NewFunctionButton.KeyDown += Action_KeyDown;
            // 
            // FileOpenButton
            // 
            FileOpenButton.Location = new Point(31, 1);
            FileOpenButton.Margin = new Padding(0, 1, 0, 1);
            FileOpenButton.Name = "FileOpenButton";
            FileOpenButton.Size = new Size(30, 30);
            FileOpenButton.TabIndex = 19;
            FileOpenButton.Text = "button33";
            FileOpenButton.UseVisualStyleBackColor = true;
            FileOpenButton.Click += FileOpenButton_Click;
            FileOpenButton.KeyDown += Action_KeyDown;
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
            tableLayoutPanel4.Location = new Point(61, 41);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(396, 32);
            tableLayoutPanel4.TabIndex = 17;
            // 
            // LessButton
            // 
            LessButton.Location = new Point(365, 1);
            LessButton.Margin = new Padding(0, 1, 1, 1);
            LessButton.Name = "LessButton";
            LessButton.Size = new Size(30, 30);
            LessButton.TabIndex = 28;
            LessButton.Text = "<";
            LessButton.UseVisualStyleBackColor = true;
            LessButton.Click += ArgumentAddButton_Click;
            LessButton.KeyDown += Action_KeyDown;
            // 
            // MoreButton
            // 
            MoreButton.Location = new Point(335, 1);
            MoreButton.Margin = new Padding(0, 1, 0, 1);
            MoreButton.Name = "MoreButton";
            MoreButton.Size = new Size(30, 30);
            MoreButton.TabIndex = 27;
            MoreButton.Text = ">";
            MoreButton.UseVisualStyleBackColor = true;
            MoreButton.Click += ArgumentAddButton_Click;
            MoreButton.KeyDown += Action_KeyDown;
            // 
            // ReverseImplicationButton
            // 
            ReverseImplicationButton.Location = new Point(305, 1);
            ReverseImplicationButton.Margin = new Padding(0, 1, 0, 1);
            ReverseImplicationButton.Name = "ReverseImplicationButton";
            ReverseImplicationButton.Size = new Size(30, 30);
            ReverseImplicationButton.TabIndex = 26;
            ReverseImplicationButton.Text = "←";
            ReverseImplicationButton.UseVisualStyleBackColor = true;
            ReverseImplicationButton.Click += ArgumentAddButton_Click;
            ReverseImplicationButton.KeyDown += Action_KeyDown;
            // 
            // ImplicationButton
            // 
            ImplicationButton.Location = new Point(275, 1);
            ImplicationButton.Margin = new Padding(0, 1, 0, 1);
            ImplicationButton.Name = "ImplicationButton";
            ImplicationButton.Size = new Size(30, 30);
            ImplicationButton.TabIndex = 25;
            ImplicationButton.Text = "→";
            ImplicationButton.UseVisualStyleBackColor = true;
            ImplicationButton.Click += ArgumentAddButton_Click;
            ImplicationButton.KeyDown += Action_KeyDown;
            // 
            // EquvalenceButton
            // 
            EquvalenceButton.Location = new Point(245, 1);
            EquvalenceButton.Margin = new Padding(0, 1, 0, 1);
            EquvalenceButton.Name = "EquvalenceButton";
            EquvalenceButton.Size = new Size(30, 30);
            EquvalenceButton.TabIndex = 24;
            EquvalenceButton.Text = "≡";
            EquvalenceButton.UseVisualStyleBackColor = true;
            EquvalenceButton.Click += ArgumentAddButton_Click;
            EquvalenceButton.KeyDown += Action_KeyDown;
            // 
            // VebbaButton
            // 
            VebbaButton.Location = new Point(215, 1);
            VebbaButton.Margin = new Padding(0, 1, 0, 1);
            VebbaButton.Name = "VebbaButton";
            VebbaButton.Size = new Size(30, 30);
            VebbaButton.TabIndex = 23;
            VebbaButton.Text = "o";
            VebbaButton.UseVisualStyleBackColor = true;
            VebbaButton.Click += ArgumentAddButton_Click;
            VebbaButton.KeyDown += Action_KeyDown;
            // 
            // ShefferButton
            // 
            ShefferButton.Location = new Point(185, 1);
            ShefferButton.Margin = new Padding(0, 1, 0, 1);
            ShefferButton.Name = "ShefferButton";
            ShefferButton.Size = new Size(30, 30);
            ShefferButton.TabIndex = 22;
            ShefferButton.Text = "/";
            ShefferButton.UseVisualStyleBackColor = true;
            ShefferButton.Click += ArgumentAddButton_Click;
            ShefferButton.KeyDown += Action_KeyDown;
            // 
            // ExclusiveOrButton
            // 
            ExclusiveOrButton.Location = new Point(155, 1);
            ExclusiveOrButton.Margin = new Padding(0, 1, 0, 1);
            ExclusiveOrButton.Name = "ExclusiveOrButton";
            ExclusiveOrButton.Size = new Size(30, 30);
            ExclusiveOrButton.TabIndex = 21;
            ExclusiveOrButton.Text = "Ꚛ";
            ExclusiveOrButton.UseVisualStyleBackColor = true;
            ExclusiveOrButton.Click += ArgumentAddButton_Click;
            ExclusiveOrButton.KeyDown += Action_KeyDown;
            // 
            // OrButton
            // 
            OrButton.Location = new Point(125, 1);
            OrButton.Margin = new Padding(0, 1, 0, 1);
            OrButton.Name = "OrButton";
            OrButton.Size = new Size(30, 30);
            OrButton.TabIndex = 20;
            OrButton.Text = "+";
            OrButton.UseVisualStyleBackColor = true;
            OrButton.Click += ArgumentAddButton_Click;
            OrButton.KeyDown += Action_KeyDown;
            // 
            // AndButton
            // 
            AndButton.Location = new Point(95, 1);
            AndButton.Margin = new Padding(1, 1, 0, 1);
            AndButton.Name = "AndButton";
            AndButton.Size = new Size(30, 30);
            AndButton.TabIndex = 19;
            AndButton.Text = "&";
            AndButton.UseVisualStyleBackColor = true;
            AndButton.Click += ArgumentAddButton_Click;
            AndButton.KeyDown += Action_KeyDown;
            // 
            // NegativeButton
            // 
            NegativeButton.Location = new Point(63, 1);
            NegativeButton.Margin = new Padding(1);
            NegativeButton.Name = "NegativeButton";
            NegativeButton.Size = new Size(30, 30);
            NegativeButton.TabIndex = 18;
            NegativeButton.Text = "!x";
            NegativeButton.UseVisualStyleBackColor = true;
            NegativeButton.Click += NegativeButton_Click;
            NegativeButton.KeyDown += Action_KeyDown;
            // 
            // RightBreacketButton
            // 
            RightBreacketButton.Location = new Point(31, 1);
            RightBreacketButton.Margin = new Padding(0, 1, 1, 1);
            RightBreacketButton.Name = "RightBreacketButton";
            RightBreacketButton.Size = new Size(30, 30);
            RightBreacketButton.TabIndex = 18;
            RightBreacketButton.Text = ")";
            RightBreacketButton.UseVisualStyleBackColor = true;
            RightBreacketButton.Click += ArgumentAddButton_Click;
            RightBreacketButton.KeyDown += Action_KeyDown;
            // 
            // LeftBracketButton
            // 
            LeftBracketButton.Location = new Point(1, 1);
            LeftBracketButton.Margin = new Padding(1, 1, 0, 1);
            LeftBracketButton.Name = "LeftBracketButton";
            LeftBracketButton.Size = new Size(30, 30);
            LeftBracketButton.TabIndex = 18;
            LeftBracketButton.Text = "(";
            LeftBracketButton.UseVisualStyleBackColor = true;
            LeftBracketButton.Click += ArgumentAddButton_Click;
            LeftBracketButton.KeyDown += Action_KeyDown;
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
            tableLayoutPanel3.Location = new Point(401, 3);
            tableLayoutPanel3.Margin = new Padding(1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(186, 32);
            tableLayoutPanel3.TabIndex = 16;
            // 
            // DeleteRightButton
            // 
            DeleteRightButton.Location = new Point(155, 1);
            DeleteRightButton.Margin = new Padding(0, 1, 1, 1);
            DeleteRightButton.Name = "DeleteRightButton";
            DeleteRightButton.Size = new Size(30, 30);
            DeleteRightButton.TabIndex = 17;
            DeleteRightButton.Text = "button19";
            DeleteRightButton.UseVisualStyleBackColor = true;
            DeleteRightButton.Click += CursorMoveButton_Click;
            DeleteRightButton.KeyDown += Action_KeyDown;
            // 
            // DeleteLeftButton
            // 
            DeleteLeftButton.Location = new Point(125, 1);
            DeleteLeftButton.Margin = new Padding(1, 1, 0, 1);
            DeleteLeftButton.Name = "DeleteLeftButton";
            DeleteLeftButton.Size = new Size(30, 30);
            DeleteLeftButton.TabIndex = 17;
            DeleteLeftButton.Text = "button18";
            DeleteLeftButton.UseVisualStyleBackColor = true;
            DeleteLeftButton.Click += CursorMoveButton_Click;
            DeleteLeftButton.KeyDown += Action_KeyDown;
            // 
            // EndCursorButton
            // 
            EndCursorButton.Location = new Point(93, 1);
            EndCursorButton.Margin = new Padding(0, 1, 1, 1);
            EndCursorButton.Name = "EndCursorButton";
            EndCursorButton.Size = new Size(30, 30);
            EndCursorButton.TabIndex = 17;
            EndCursorButton.Text = "button17";
            EndCursorButton.UseVisualStyleBackColor = true;
            EndCursorButton.Click += CursorMoveButton_Click;
            EndCursorButton.KeyDown += Action_KeyDown;
            // 
            // StartCursorButton
            // 
            StartCursorButton.Location = new Point(63, 1);
            StartCursorButton.Margin = new Padding(1, 1, 0, 1);
            StartCursorButton.Name = "StartCursorButton";
            StartCursorButton.Size = new Size(30, 30);
            StartCursorButton.TabIndex = 17;
            StartCursorButton.Text = "button16";
            StartCursorButton.UseVisualStyleBackColor = true;
            StartCursorButton.Click += CursorMoveButton_Click;
            StartCursorButton.KeyDown += Action_KeyDown;
            // 
            // RightCursorButton
            // 
            RightCursorButton.Location = new Point(31, 1);
            RightCursorButton.Margin = new Padding(0, 1, 1, 1);
            RightCursorButton.Name = "RightCursorButton";
            RightCursorButton.Size = new Size(30, 30);
            RightCursorButton.TabIndex = 17;
            RightCursorButton.Text = "button15";
            RightCursorButton.UseVisualStyleBackColor = true;
            RightCursorButton.Click += CursorMoveButton_Click;
            RightCursorButton.KeyDown += Action_KeyDown;
            // 
            // LeftCursorButton
            // 
            LeftCursorButton.Location = new Point(1, 1);
            LeftCursorButton.Margin = new Padding(1, 1, 0, 1);
            LeftCursorButton.Name = "LeftCursorButton";
            LeftCursorButton.Size = new Size(30, 30);
            LeftCursorButton.TabIndex = 17;
            LeftCursorButton.Text = "button14";
            LeftCursorButton.UseVisualStyleBackColor = true;
            LeftCursorButton.Click += CursorMoveButton_Click;
            LeftCursorButton.KeyDown += Action_KeyDown;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Controls.Add(SettingButton);
            panel3.Location = new Point(22, 41);
            panel3.Name = "panel3";
            panel3.Size = new Size(32, 32);
            panel3.TabIndex = 15;
            // 
            // SettingButton
            // 
            SettingButton.Location = new Point(1, 1);
            SettingButton.Margin = new Padding(1);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(30, 30);
            SettingButton.TabIndex = 1;
            SettingButton.Text = "button2";
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += ActionButton_Click;
            SettingButton.KeyDown += Action_KeyDown;
            // 
            // ButtonPaneli
            // 
            ButtonPaneli.BackColor = Color.Silver;
            ButtonPaneli.Controls.Add(GideButton);
            ButtonPaneli.Location = new Point(22, 3);
            ButtonPaneli.Name = "ButtonPaneli";
            ButtonPaneli.Size = new Size(32, 32);
            ButtonPaneli.TabIndex = 14;
            // 
            // GideButton
            // 
            GideButton.Image = Properties.Resources.icons8_support_16;
            GideButton.Location = new Point(1, 1);
            GideButton.Margin = new Padding(1);
            GideButton.Name = "GideButton";
            GideButton.Size = new Size(30, 30);
            GideButton.TabIndex = 0;
            GideButton.UseVisualStyleBackColor = true;
            GideButton.Click += ActionButton_Click;
            GideButton.KeyDown += Action_KeyDown;
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
            tableLayoutPanel2.Location = new Point(60, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(334, 32);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // X1FuncButton
            // 
            X1FuncButton.Image = Properties.Resources.icons8_subscript_50;
            X1FuncButton.Location = new Point(1, 1);
            X1FuncButton.Margin = new Padding(1, 1, 0, 1);
            X1FuncButton.Name = "X1FuncButton";
            X1FuncButton.Size = new Size(30, 30);
            X1FuncButton.TabIndex = 2;
            X1FuncButton.Text = "X₁";
            X1FuncButton.UseVisualStyleBackColor = true;
            X1FuncButton.Click += ArgumentAddButton_Click;
            X1FuncButton.KeyDown += Action_KeyDown;
            // 
            // UnitFuncButton
            // 
            UnitFuncButton.Location = new Point(303, 1);
            UnitFuncButton.Margin = new Padding(0, 1, 1, 1);
            UnitFuncButton.Name = "UnitFuncButton";
            UnitFuncButton.Size = new Size(30, 30);
            UnitFuncButton.TabIndex = 7;
            UnitFuncButton.Text = "button8";
            UnitFuncButton.UseVisualStyleBackColor = true;
            UnitFuncButton.Click += ArgumentAddButton_Click;
            UnitFuncButton.KeyDown += Action_KeyDown;
            // 
            // ZeroFuncButton
            // 
            ZeroFuncButton.Location = new Point(273, 1);
            ZeroFuncButton.Margin = new Padding(1, 1, 0, 1);
            ZeroFuncButton.Name = "ZeroFuncButton";
            ZeroFuncButton.Size = new Size(30, 30);
            ZeroFuncButton.TabIndex = 10;
            ZeroFuncButton.Text = "button11";
            ZeroFuncButton.UseVisualStyleBackColor = true;
            ZeroFuncButton.Click += ArgumentAddButton_Click;
            ZeroFuncButton.KeyDown += Action_KeyDown;
            // 
            // X7FuncButton
            // 
            X7FuncButton.Location = new Point(181, 1);
            X7FuncButton.Margin = new Padding(0, 1, 0, 1);
            X7FuncButton.Name = "X7FuncButton";
            X7FuncButton.Size = new Size(30, 30);
            X7FuncButton.TabIndex = 11;
            X7FuncButton.Text = "button12";
            X7FuncButton.UseVisualStyleBackColor = true;
            X7FuncButton.Click += ArgumentAddButton_Click;
            X7FuncButton.KeyDown += Action_KeyDown;
            // 
            // X9FuncButton
            // 
            X9FuncButton.Location = new Point(241, 1);
            X9FuncButton.Margin = new Padding(0, 1, 1, 1);
            X9FuncButton.Name = "X9FuncButton";
            X9FuncButton.Size = new Size(30, 30);
            X9FuncButton.TabIndex = 9;
            X9FuncButton.Text = "button10";
            X9FuncButton.UseVisualStyleBackColor = true;
            X9FuncButton.Click += ArgumentAddButton_Click;
            X9FuncButton.KeyDown += Action_KeyDown;
            // 
            // X6FuncButton
            // 
            X6FuncButton.Location = new Point(151, 1);
            X6FuncButton.Margin = new Padding(0, 1, 0, 1);
            X6FuncButton.Name = "X6FuncButton";
            X6FuncButton.Size = new Size(30, 30);
            X6FuncButton.TabIndex = 12;
            X6FuncButton.Text = "button13";
            X6FuncButton.UseVisualStyleBackColor = true;
            X6FuncButton.Click += ArgumentAddButton_Click;
            X6FuncButton.KeyDown += Action_KeyDown;
            // 
            // X8FuncButton
            // 
            X8FuncButton.Location = new Point(211, 1);
            X8FuncButton.Margin = new Padding(0, 1, 0, 1);
            X8FuncButton.Name = "X8FuncButton";
            X8FuncButton.Size = new Size(30, 30);
            X8FuncButton.TabIndex = 8;
            X8FuncButton.Text = "button9";
            X8FuncButton.UseVisualStyleBackColor = true;
            X8FuncButton.Click += ArgumentAddButton_Click;
            X8FuncButton.KeyDown += Action_KeyDown;
            // 
            // X2FuncButton
            // 
            X2FuncButton.Location = new Point(31, 1);
            X2FuncButton.Margin = new Padding(0, 1, 0, 1);
            X2FuncButton.Name = "X2FuncButton";
            X2FuncButton.Size = new Size(30, 30);
            X2FuncButton.TabIndex = 6;
            X2FuncButton.Text = "button7";
            X2FuncButton.UseVisualStyleBackColor = true;
            X2FuncButton.Click += ArgumentAddButton_Click;
            X2FuncButton.KeyDown += Action_KeyDown;
            // 
            // X3FuncButton
            // 
            X3FuncButton.Location = new Point(61, 1);
            X3FuncButton.Margin = new Padding(0, 1, 0, 1);
            X3FuncButton.Name = "X3FuncButton";
            X3FuncButton.Size = new Size(30, 30);
            X3FuncButton.TabIndex = 5;
            X3FuncButton.Text = "button6";
            X3FuncButton.UseVisualStyleBackColor = true;
            X3FuncButton.Click += ArgumentAddButton_Click;
            X3FuncButton.KeyDown += Action_KeyDown;
            // 
            // X4FuncButton
            // 
            X4FuncButton.Location = new Point(91, 1);
            X4FuncButton.Margin = new Padding(0, 1, 0, 1);
            X4FuncButton.Name = "X4FuncButton";
            X4FuncButton.Size = new Size(30, 30);
            X4FuncButton.TabIndex = 4;
            X4FuncButton.Text = "button5";
            X4FuncButton.UseVisualStyleBackColor = true;
            X4FuncButton.Click += ArgumentAddButton_Click;
            X4FuncButton.KeyDown += Action_KeyDown;
            // 
            // X5FuncButton
            // 
            X5FuncButton.Location = new Point(121, 1);
            X5FuncButton.Margin = new Padding(0, 1, 0, 1);
            X5FuncButton.Name = "X5FuncButton";
            X5FuncButton.Size = new Size(30, 30);
            X5FuncButton.TabIndex = 3;
            X5FuncButton.Text = "button4";
            X5FuncButton.UseVisualStyleBackColor = true;
            X5FuncButton.Click += ArgumentAddButton_Click;
            X5FuncButton.KeyDown += Action_KeyDown;
            // 
            // ErrorOutputLabel
            // 
            ErrorOutputLabel.Dock = DockStyle.Fill;
            ErrorOutputLabel.Location = new Point(3, 194);
            ErrorOutputLabel.Name = "ErrorOutputLabel";
            ErrorOutputLabel.Size = new Size(762, 20);
            ErrorOutputLabel.TabIndex = 4;
            ErrorOutputLabel.Text = "X₁ Функция не задана";
            ErrorOutputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FunctionPictureBox
            // 
            FunctionPictureBox.Dock = DockStyle.Fill;
            FunctionPictureBox.Location = new Point(3, 43);
            FunctionPictureBox.Name = "FunctionPictureBox";
            FunctionPictureBox.Size = new Size(762, 66);
            FunctionPictureBox.TabIndex = 5;
            FunctionPictureBox.TabStop = false;
            FunctionPictureBox.MouseDown += FunctionPictureBox_MouseDown;
            // 
            // BazisTabPage
            // 
            BazisTabPage.Controls.Add(tableLayoutPanel6);
            BazisTabPage.Location = new Point(4, 29);
            BazisTabPage.Name = "BazisTabPage";
            BazisTabPage.Size = new Size(774, 220);
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
            tableLayoutPanel6.Controls.Add(BazisFunction, 0, 3);
            tableLayoutPanel6.Controls.Add(InitialFunctionBazisPictureBox, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 4;
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle());
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(774, 220);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(768, 20);
            label4.TabIndex = 0;
            label4.Text = "Исходная функция";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(BazisComboBox);
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(768, 34);
            panel2.TabIndex = 2;
            // 
            // BazisComboBox
            // 
            BazisComboBox.FormattingEnabled = true;
            BazisComboBox.Items.AddRange(new object[] { "{ %, &, + }", "{ %, & }", "{ %, + }", "{ %, /}", "{ / }", "Ꚛ", "≡" });
            BazisComboBox.Location = new Point(255, 3);
            BazisComboBox.Name = "BazisComboBox";
            BazisComboBox.Size = new Size(144, 28);
            BazisComboBox.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 6);
            label5.Name = "label5";
            label5.Size = new Size(244, 20);
            label5.TabIndex = 0;
            label5.Text = "Представление функции в базисе";
            // 
            // BazisFunction
            // 
            BazisFunction.Dock = DockStyle.Fill;
            BazisFunction.Location = new Point(3, 143);
            BazisFunction.Multiline = true;
            BazisFunction.Name = "BazisFunction";
            BazisFunction.Size = new Size(768, 74);
            BazisFunction.TabIndex = 3;
            // 
            // InitialFunctionBazisPictureBox
            // 
            InitialFunctionBazisPictureBox.Dock = DockStyle.Fill;
            InitialFunctionBazisPictureBox.Location = new Point(3, 23);
            InitialFunctionBazisPictureBox.Name = "InitialFunctionBazisPictureBox";
            InitialFunctionBazisPictureBox.Size = new Size(768, 74);
            InitialFunctionBazisPictureBox.TabIndex = 4;
            InitialFunctionBazisPictureBox.TabStop = false;
            // 
            // SynthesisTabPage
            // 
            SynthesisTabPage.Controls.Add(tableLayoutPanel7);
            SynthesisTabPage.Location = new Point(4, 29);
            SynthesisTabPage.Name = "SynthesisTabPage";
            SynthesisTabPage.Size = new Size(774, 220);
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
            tableLayoutPanel7.Controls.Add(DNSFTextBox, 0, 2);
            tableLayoutPanel7.Controls.Add(label7, 0, 3);
            tableLayoutPanel7.Controls.Add(KNSFTextBox, 0, 4);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 5;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel7.Size = new Size(774, 220);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(MinimizeFuncButton);
            panel4.Controls.Add(button37);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(768, 38);
            panel4.TabIndex = 0;
            // 
            // MinimizeFuncButton
            // 
            MinimizeFuncButton.Anchor = AnchorStyles.Top;
            MinimizeFuncButton.Location = new Point(384, 3);
            MinimizeFuncButton.Name = "MinimizeFuncButton";
            MinimizeFuncButton.Size = new Size(30, 30);
            MinimizeFuncButton.TabIndex = 3;
            MinimizeFuncButton.Text = "button38";
            MinimizeFuncButton.UseVisualStyleBackColor = true;
            // 
            // button37
            // 
            button37.Anchor = AnchorStyles.Top;
            button37.Location = new Point(82, 3);
            button37.Name = "button37";
            button37.Size = new Size(30, 30);
            button37.TabIndex = 2;
            button37.Text = "button37";
            button37.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(420, 8);
            label9.Name = "label9";
            label9.Size = new Size(200, 20);
            label9.TabIndex = 1;
            label9.Text = "Минимизировать функцию";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(118, 8);
            label8.Name = "label8";
            label8.Size = new Size(199, 20);
            label8.TabIndex = 0;
            label8.Text = "Задать таблицу истинности";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 44);
            label6.Name = "label6";
            label6.Size = new Size(768, 44);
            label6.TabIndex = 1;
            label6.Text = "ДСНФ";
            // 
            // DNSFTextBox
            // 
            DNSFTextBox.Dock = DockStyle.Fill;
            DNSFTextBox.Location = new Point(3, 91);
            DNSFTextBox.Multiline = true;
            DNSFTextBox.Name = "DNSFTextBox";
            DNSFTextBox.Size = new Size(768, 38);
            DNSFTextBox.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 132);
            label7.Name = "label7";
            label7.Size = new Size(768, 44);
            label7.TabIndex = 3;
            label7.Text = "КСНФ";
            // 
            // KNSFTextBox
            // 
            KNSFTextBox.Dock = DockStyle.Fill;
            KNSFTextBox.Location = new Point(3, 179);
            KNSFTextBox.Multiline = true;
            KNSFTextBox.Name = "KNSFTextBox";
            KNSFTextBox.Size = new Size(768, 38);
            KNSFTextBox.TabIndex = 4;
            // 
            // InfoTabPage
            // 
            InfoTabPage.Controls.Add(tableLayoutPanel8);
            InfoTabPage.Location = new Point(4, 29);
            InfoTabPage.Name = "InfoTabPage";
            InfoTabPage.Size = new Size(774, 220);
            InfoTabPage.TabIndex = 4;
            InfoTabPage.Text = "О программе";
            InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Controls.Add(InfoProgramLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(VersionLabel, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(774, 220);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // InfoProgramLabel
            // 
            InfoProgramLabel.BackColor = Color.White;
            InfoProgramLabel.Dock = DockStyle.Fill;
            InfoProgramLabel.Location = new Point(3, 0);
            InfoProgramLabel.Name = "InfoProgramLabel";
            InfoProgramLabel.Size = new Size(768, 110);
            InfoProgramLabel.TabIndex = 0;
            InfoProgramLabel.Text = "Программный комплекс для\r\nАнализа и синтеза логических функций\r\n";
            InfoProgramLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.BackColor = Color.Silver;
            VersionLabel.Dock = DockStyle.Fill;
            VersionLabel.Location = new Point(3, 110);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(768, 110);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "Версия 3.0 (November  2024)\r\n\r\nСреда разработки Visual Studio, язык C#\r\n";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CursorTimer
            // 
            CursorTimer.Enabled = true;
            CursorTimer.Interval = 500;
            CursorTimer.Tick += CursorTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(782, 253);
            Controls.Add(MainTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "LogicMaster";
            MainTabControl.ResumeLayout(false);
            HeaderTabPage.ResumeLayout(false);
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
            SynthesisTabPage.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private Button SettingButton;
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
        private ComboBox BazisComboBox;
        private Label label5;
        private TextBox BazisFunction;
        private TableLayoutPanel tableLayoutPanel7;
        private Panel panel4;
        private Button button37;
        private Label label9;
        private Label label8;
        private Label label6;
        private TextBox DNSFTextBox;
        private Label label7;
        private TextBox KNSFTextBox;
        private Button MinimizeFuncButton;
        private Label InfoProgramLabel;
        private TableLayoutPanel tableLayoutPanel8;
        private Label VersionLabel;
        private PictureBox FunctionPictureBox;
        private System.Windows.Forms.Timer CursorTimer;
        private PictureBox InitialFunctionBazisPictureBox;
    }
}
