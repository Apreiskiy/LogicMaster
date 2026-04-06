using Logic_Master.Models;
using Logic_Master.StaticData;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Logic_Master.Views
{
    public partial class MainForm : Form
    {
        LogicFunction logicFunction = new LogicFunction();
        LogicFunction logicFunctionSource = new LogicFunction();
        LogicFunction logicFunctionBasis = new LogicFunction();
        LogicFunction logicFunctionDSNF = new LogicFunction();
        LogicFunction logicFunctionKSNF = new LogicFunction();
        private string fullText = "Программный комплекс для\nАнализа и синтеза логических функций";
        private int currentIndex = 0;
        bool cursorVisible;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        ContextMenuStrip contextMenuBasis = new ContextMenuStrip();
        ContextMenuStrip contextMenuKSNF = new ContextMenuStrip();


        public MainForm()
        {
            InitializeComponent();

            ImageListTabContol.Images.Add(Properties.Resources.TitleTabControl);
            ImageListTabContol.Images.Add(Properties.Resources.BasisTabControl);
            ImageListTabContol.Images.Add(Properties.Resources.FuncImageTabControl);
            ImageListTabContol.Images.Add(Properties.Resources.SintezTabControl);
            ImageListTabContol.Images.Add(Properties.Resources.Information);
            MainTabControl.TabPages[0].ImageIndex = 0;
            MainTabControl.TabPages[1].ImageIndex = 2;
            MainTabControl.TabPages[2].ImageIndex = 1;
            MainTabControl.TabPages[3].ImageIndex = 3;
            MainTabControl.TabPages[4].ImageIndex = 4;



            StartPosition = FormStartPosition.CenterScreen;
            //ButtonImage();
            PrintTimer.Start();
            BasisComboBox.SelectedIndex = 0;
            cursorVisible = true;

            logicFunction.SetOutput(FunctionPictureBox.ClientRectangle);
            FunctionPictureBox.Image = logicFunction.Fbitmap;

            logicFunctionSource.SetOutput(InitialFunctionBazisPictureBox.ClientRectangle);
            InitialFunctionBazisPictureBox.Image = logicFunctionSource.Fbitmap;


            logicFunctionBasis.SetOutput(BasisPictureBox.ClientRectangle);
            BasisPictureBox.Image = logicFunctionBasis.Fbitmap;


            logicFunctionDSNF.SetOutput(DNSFPictureBox.ClientRectangle);
            DNSFPictureBox.Image = logicFunctionDSNF.Fbitmap;


            logicFunctionKSNF.SetOutput(KSNFPictureBox.ClientRectangle);
            KSNFPictureBox.Image = logicFunctionKSNF.Fbitmap;



            Paint();
        }

        private void Paint()
        {
            if (!logicFunction.Update(true))
            {
                logicFunction.Paint();

                FunctionPictureBox.Refresh();

                contextMenuStrip.Items.Clear();
                if (logicFunction.FLength == 0)
                {
                    ToolStripMenuItem openFileMenu = new ToolStripMenuItem("Открыть файл", Properties.Resources.FileOpen2);
                    openFileMenu.Click += FileOpenButton_Click;
                    ToolStripMenuItem lenghtFunc = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                    lenghtFunc.Click += FuncLenght;
                    contextMenuStrip.Items.Add(openFileMenu);
                    contextMenuStrip.Items.Add(new ToolStripSeparator());
                    contextMenuStrip.Items.Add(lenghtFunc);

                }
                else
                {
                    ToolStripMenuItem truthTableMenu = new ToolStripMenuItem("Построить таблицу истинности", Properties.Resources.TruthTableButton);
                    truthTableMenu.Click += TruthTableButton_Click;
                    ToolStripMenuItem sintezMenu = new ToolStripMenuItem("Синтезировать СНФ", Properties.Resources.SintezTabControl);
                    sintezMenu.Click += (sender, e) => MainTabControl.SelectedIndex = 3;
                    ToolStripMenuItem minimizeMenu = new ToolStripMenuItem("Минимизировать функцию", Properties.Resources.icons8_уценка_30);
                    minimizeMenu.Click += MinimizeFuncButton_Click;
                    ToolStripMenuItem deleteBracketsMenu = new ToolStripMenuItem("Удалить лишние скобки", Properties.Resources.DeleteBrackets);
                    deleteBracketsMenu.Click += (sender, e) =>
                    {
                        logicFunction.Optimization();
                        Paint();
                    };
                    contextMenuStrip.Items.AddRange(new ToolStripMenuItem[] {truthTableMenu, sintezMenu, minimizeMenu, deleteBracketsMenu });
                    contextMenuStrip.Items.Add(new ToolStripSeparator());

                    ToolStripMenuItem saveFileMenu = new ToolStripMenuItem("Сохранить в файл", Properties.Resources.SaveFile);
                    saveFileMenu.Click += SaveFileButton_Click;
                    ToolStripMenuItem exportImageMenu = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
                    exportImageMenu.Click += ImageFunctionButton_Click;
                    contextMenuStrip.Items.AddRange(new ToolStripMenuItem[] { saveFileMenu, exportImageMenu});
                    contextMenuStrip.Items.Add(new ToolStripSeparator());


                    ToolStripMenuItem openFileMenu = new ToolStripMenuItem("Открыть файл", Properties.Resources.FileOpen2);
                    openFileMenu.Click += FileOpenButton_Click;
                    ToolStripMenuItem lenghtFunc = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                    lenghtFunc.Click += FuncLenght;
                    contextMenuStrip.Items.Add(openFileMenu);
                    contextMenuStrip.Items.Add(new ToolStripSeparator());
                    contextMenuStrip.Items.Add(lenghtFunc);
                }

                FunctionPictureBox.ContextMenuStrip = contextMenuStrip;

                string message;
                switch (logicFunction.GetError())
                {
                    case Error.NoError:
                        message = "Нет ошибок";
                        break;
                    case Error.Empty:
                        message = "Функция не задана";
                        break;
                    case Error.UnknownArgument:
                        message = "Неверный аргумент";
                        break;
                    case Error.AbsentValue:
                        message = "Отсутствует переменная или числовое значение";
                        break;
                    case Error.AbsentOperation:
                        message = "Отсуствует знак операции";
                        break;
                    case Error.AbsentBracketLeft:
                        message = "Отсутвует открывающая скобка";
                        break;
                    case Error.AbsentBracketRight:
                        message = "Отсутвует закрывающая скобка";
                        break;
                    default:
                        message = "Неизвестная ошибка";
                        break;
                }
                ErrorOutputLabel.Text = message;
            }
            else
            {
                FunctionPictureBox.Refresh();
            }
        }

        private void ArgumentAddButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button == X1FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 1);
            }
            else if (button == X2FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 2);
            }
            else if (button == X3FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 3);
            }
            else if (button == X4FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 4);
            }
            else if (button == X5FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 5);
            }
            else if (button == X6FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 6);
            }
            else if (button == X7FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 7);
            }
            else if (button == X8FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 8);
            }
            else if (button == X9FuncButton)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 9);
            }
            else if (button == ZeroFuncButton)
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 0);
            }
            else if (button == UnitFuncButton)
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 1);
            }


            else if (button == LeftBracketButton)
            {
                logicFunction.AddArgument(ArgumentType.BracketLeft);
            }
            else if (button == RightBreacketButton)
            {
                logicFunction.AddArgument(ArgumentType.BracketRight);
            }

            else if (button == AndButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 1);
            }
            else if (button == OrButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 2);
            }
            else if (button == ExclusiveOrButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 3);
            }
            else if (button == ShefferButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 6);
            }
            else if (button == VebbaButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 7);
            }
            else if (button == EquvalenceButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 8);
            }
            else if (button == ImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 4);
            }
            else if (button == ReverseImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 9);
            }
            else if (button == MoreButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 5);
            }
            else if (button == LessButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 10);
            }

            logicFunction.Align(Aligment.Cursor);
            Paint();

        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            logicFunction.Negative();
            Paint();
        }

        private void ImageFunctionButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "Изображение функции"; //имя по умолчанию
                saveFileDialog.DefaultExt = ".png"; //формат по умолчанию
                saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                saveFileDialog.Title = "Сохранить изображение функции";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (FunctionPictureBox.Image != null)
                    {
                        FunctionPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        MessageBox.Show("Нет изобрежения для сохранения");
                    }
                }
            }
        }
        private void GideButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 4;
        }

        private void CursorMoveButton_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            if (button == LeftCursorButton)
            {
                logicFunction.SetPosition(Direction.Left);
            }
            else if (button == RightCursorButton)
            {
                logicFunction.SetPosition(Direction.Right);
            }
            else if (button == StartCursorButton)
            {
                logicFunction.SetPosition(Direction.Begin);
            }
            else if (button == EndCursorButton)
            {
                logicFunction.SetPosition(Direction.End);
            }
            else if (button == DeleteLeftButton)
            {
                logicFunction.DelArgumentLeft();
            }
            else if (button == DeleteRightButton)
            {
                logicFunction.DelArgumentRight();
            }

            logicFunction.Align(Aligment.Cursor);
            Paint();
        }


        private void Action_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainTabControl.SelectedTab != AnalyzTabPage)
            {
                return;
            }

            if (e.Shift == true && e.KeyCode == Keys.D9)
            {
                logicFunction.AddArgument(ArgumentType.BracketLeft);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Shift == true && e.KeyCode == Keys.D0)
            {
                logicFunction.AddArgument(ArgumentType.BracketRight);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Shift == true && e.KeyCode == Keys.D1)
            {
                logicFunction.Negative();
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Shift && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 8);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }


            else if (e.Control == true && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 0);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Control == true && (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1))
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 1);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Control && e.KeyCode == Keys.N)
            {
                NewFunctionButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                FileOpenButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveFileButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                ImageFunctionButton_Click(sender, e);
            }
            else if (e.Control && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 3);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Shift && (e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 1);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Control && e.KeyCode == Keys.OemPeriod)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 4);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Control && e.KeyCode == Keys.Oemcomma)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 9);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Control && e.KeyCode == Keys.F)
            {
                FunctionTableForm functionTableForm = new FunctionTableForm();
                functionTableForm.ShowDialog();
            }


            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 1);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 2);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 3);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 4);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 5);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 6);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 7);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 8);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                logicFunction.AddArgument(ArgumentType.Variable, 9);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }


            else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 2);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.Oem2)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 6);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.O)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 7);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.OemPeriod)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 5);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.Oemcomma)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 10);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            ///
            else if (e.KeyCode == Keys.Left)
            {
                logicFunction.SetPosition(Direction.Left);
            }
            else if (e.KeyCode == Keys.Right)
            {
                logicFunction.SetPosition(Direction.Right);
            }
            else if (e.KeyCode == Keys.Home || e.KeyCode == Keys.Up)
            {
                logicFunction.SetPosition(Direction.Begin);
            }
            else if (e.KeyCode == Keys.Home || e.KeyCode == Keys.Down)
            {
                logicFunction.SetPosition(Direction.End);
            }

            else if (e.KeyCode == Keys.Back)
            {
                logicFunction.DelArgumentLeft();
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                logicFunction.DelArgumentRight();
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            e.SuppressKeyPress = true;
        }

        private void FunctionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }


        /// <summary>
        /// Таймер для тиков курсора
        /// </summary>
        private void CursorTimer_Tick(object sender, EventArgs e)
        {
            bool visible = true;

            if (MainTabControl.SelectedTab == AnalyzTabPage)
            {
                cursorVisible = !cursorVisible;
                logicFunction.Update(cursorVisible);
                visible = true;
            }
            else if (visible)
            {
                logicFunction.Update(false);
                visible = false;
            }
            FunctionPictureBox.Refresh();
        }

        private void FunctionPictureBox_MouseDown(object sender, MouseEventArgs e) //для изменения курсора при нажатии
        {
            if (e.Button == MouseButtons.Left)
            {
                logicFunction.SetPositionXY(e.X, e.Y);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
        }


        /// <summary>
        /// создание новой функции
        /// </summary>
        private void NewFunctionButton_Click(object sender, EventArgs e) 
        {
            logicFunction.Clear();
            Paint();
        }

        /// <summary>
        /// сохранение файла функции
        /// </summary>
        private void SaveFileButton_Click(object sender, EventArgs e) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Сохранить логическую функцию";
            saveFileDialog.FileName = "Function";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (logicFunction.SaveFunctionJSON(saveFileDialog.FileName))
                {
                    MessageBox.Show($"Файл успешно сохранён в JSON");
                }
            }
        }

        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.Title = "Открыть логическую функцию";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (logicFunction.LoadFunctionJSON(openFileDialog.FileName))
                {
                    MessageBox.Show($"Файл успешно загружен");
                    Paint();
                }
            }

        }


        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 1)
            {
                FunctionPictureBox.Image = logicFunction.Fbitmap;
                Paint();
            }

            else if (MainTabControl.SelectedIndex == 2)
            {
                if (logicFunction.GetError() != Error.NoError)
                {
                    MainTabControl.SelectedIndex = 1;
                    MessageBox.Show("Страница базиса недоступна!\nФункция не задана или содержит ошибки.", "Ошибка страницы базиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Контекстное меню для исходной функции в базисе
                    contextMenuStrip.Items.Clear();
                    ToolStripMenuItem truthTableMenu = new ToolStripMenuItem("Построить таблицу истиности", Properties.Resources.TruthTableButton);
                    truthTableMenu.Click += TruthTableButton_Click;
                    ToolStripMenuItem saveFile = new ToolStripMenuItem("Сохранить в файлы", Properties.Resources.SaveFile);
                    saveFile.Click += SaveFileButton_Click;
                    ToolStripMenuItem saveImage = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
                    saveImage.Click += (sender, e) =>
                    {
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.FileName = "Изображение исходной функции"; //имя по умолчанию
                            saveFileDialog.DefaultExt = ".png"; //формат по умолчанию
                            saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                            saveFileDialog.Title = "Сохранить изображение функции";

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                if (InitialFunctionBazisPictureBox.Image != null)
                                {
                                    InitialFunctionBazisPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                }
                                else
                                {
                                    MessageBox.Show("Нет изобрежения для сохранения");
                                }
                            }
                        }
                    };
                    ToolStripMenuItem lenghtFunc = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                    lenghtFunc.Click += FuncLenght;
                    contextMenuStrip.Items.Add(truthTableMenu);
                    //contextMenuStrip.Items.Add(new ToolStripSeparator());
                    contextMenuStrip.Items.Add(saveFile);
                    contextMenuStrip.Items.Add(saveImage);
                    contextMenuStrip.Items.Add(new ToolStripSeparator());
                    contextMenuStrip.Items.Add(lenghtFunc);
                    InitialFunctionBazisPictureBox.ContextMenuStrip = contextMenuStrip;

                    //-----------------------------------------------------------------------------------------------//

                    //Контекстное меню для базиса
                    contextMenuBasis.Items.Clear();
                    ToolStripMenuItem analysMenu = new ToolStripMenuItem("Анализировать результат", Properties.Resources.FuncImageTabControl);
                    analysMenu.Click += (sender, e) =>
                    {
                        logicFunction = (LogicFunction)logicFunctionBasis.Clone();
                        logicFunction.SetCursor(true);
                        MainTabControl.SelectedIndex = 1;
                    };
                    ToolStripMenuItem saveFileMenu = new ToolStripMenuItem("Сохранить в файл", Properties.Resources.SaveFile);
                    saveFileMenu.Click += (sender, e) =>
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                        saveFileDialog.DefaultExt = ".json";
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.Title = "Сохранить логическую функцию";
                        saveFileDialog.FileName = "Basis Function";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (logicFunctionBasis.SaveFunctionJSON(saveFileDialog.FileName))
                            {
                                MessageBox.Show($"Файл успешно сохранён в JSON");
                            }
                        }
                    };
                    ToolStripMenuItem saveImageMenu = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
                    saveImageMenu.Click += (sender, e) =>
                    {
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.FileName = "Изображение функции в базисе"; //имя по умолчанию
                            saveFileDialog.DefaultExt = ".png"; //формат по умолчанию
                            saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                            saveFileDialog.Title = "Сохранить изображение функции в базисе";

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                if (BasisPictureBox.Image != null)
                                {
                                    BasisPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                }
                                else
                                {
                                    MessageBox.Show("Нет изображения для сохранения");
                                }
                            }
                        }
                    };
                    ToolStripMenuItem funcLenghtBasisMenu = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                    funcLenghtBasisMenu.Click += BasisFuncLenght;
                    contextMenuBasis.Items.Add(analysMenu);
                    contextMenuBasis.Items.Add(truthTableMenu);
                    contextMenuBasis.Items.Add(new ToolStripSeparator());
                    contextMenuBasis.Items.Add(saveFileMenu);
                    contextMenuBasis.Items.Add(saveImageMenu);
                    contextMenuBasis.Items.Add(new ToolStripSeparator());
                    contextMenuBasis.Items.Add(funcLenghtBasisMenu);

                    BasisPictureBox.ContextMenuStrip = contextMenuBasis;

                    logicFunctionSource = (LogicFunction)logicFunction.Clone();
                    logicFunctionSource.SetCursor(false);
                    InitialFunctionBazisPictureBox.Image = logicFunctionSource.Fbitmap;
                    logicFunctionSource.Paint();
                    InitialFunctionBazisPictureBox.Refresh();
                    BasisChange();
                }
            }

            else if (MainTabControl.SelectedIndex == 3)
            {
                contextMenuStrip.Items.Clear();

                ToolStripMenuItem analysResultDSNF = new ToolStripMenuItem("Анализировать результат", Properties.Resources.FuncImageTabControl);
                analysResultDSNF.Click += (sender, e) =>
                {
                    logicFunction = (LogicFunction)logicFunctionDSNF.Clone();
                    logicFunction.SetCursor(true);
                    MainTabControl.SelectedIndex = 1;
                };
                ToolStripMenuItem truthTableMenu = new ToolStripMenuItem("Построить таблицу истиности", Properties.Resources.TruthTableButton);
                truthTableMenu.Click += TruthTableButton_Click;
                ToolStripMenuItem saveFileDSNFMenu = new ToolStripMenuItem("Сохранить в файлы", Properties.Resources.SaveFile);
                saveFileDSNFMenu.Click += (sender, e) =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                    saveFileDialog.DefaultExt = ".json";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Title = "Сохранить ДСНФ функцию";
                    saveFileDialog.FileName = "DSNF Function";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (logicFunctionDSNF.SaveFunctionJSON(saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Файл успешно сохранён в JSON");
                        }
                    }
                };
                ToolStripMenuItem saveImageDSNFMenu = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
                saveImageDSNFMenu.Click += (sender, e) =>
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = "Изображение ДСНФ";
                        saveFileDialog.DefaultExt = ".png";
                        saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                        saveFileDialog.Title = "Сохранить изображение ДСНФ";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (DNSFPictureBox.Image != null)
                            {
                                DNSFPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            else
                            {
                                MessageBox.Show("Нет изображения для сохранения");
                            }
                        }
                    }
                };
                ToolStripMenuItem lenghtFuncDSNFMenu = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                lenghtFuncDSNFMenu.Click += DNSFFuncLenght;
                //Контекстное меню ДСНФ
                contextMenuStrip.Items.Add(analysResultDSNF);
                contextMenuStrip.Items.Add(truthTableMenu);
                contextMenuStrip.Items.Add(new ToolStripSeparator());
                contextMenuStrip.Items.Add(saveFileDSNFMenu);
                contextMenuStrip.Items.Add(saveImageDSNFMenu);
                contextMenuStrip.Items.Add(new ToolStripSeparator());
                contextMenuStrip.Items.Add(lenghtFuncDSNFMenu);
                DNSFPictureBox.ContextMenuStrip = contextMenuStrip;

                //------------------------------------------------------//

                contextMenuKSNF.Items.Clear();
                ToolStripMenuItem analysResultKSNF = new ToolStripMenuItem("Анализировать результат", Properties.Resources.FuncImageTabControl);
                analysResultKSNF.Click += (sender, e) =>
                {
                    logicFunction = (LogicFunction)logicFunctionKSNF.Clone();
                    logicFunction.SetCursor(true);
                    MainTabControl.SelectedIndex = 1;
                };
                ToolStripMenuItem truthTableMenuKSNF = new ToolStripMenuItem("Построить таблицу истиности", Properties.Resources.TruthTableButton);
                truthTableMenu.Click += TruthTableButton_Click;
                ToolStripMenuItem saveFileKSNFMenu = new ToolStripMenuItem("Сохранить в файлы", Properties.Resources.SaveFile);
                saveFileKSNFMenu.Click += (sender, e) =>
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                    saveFileDialog.DefaultExt = ".json";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Title = "Сохранить КСНФ функцию";
                    saveFileDialog.FileName = "KSNF Function";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (logicFunctionKSNF.SaveFunctionJSON(saveFileDialog.FileName))
                        {
                            MessageBox.Show($"Файл успешно сохранён в JSON");
                        }
                    }
                };
                ToolStripMenuItem saveImageKSNFMenu = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
                saveImageKSNFMenu.Click += (sender, e) =>
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.FileName = "Изображение КСНФ";
                        saveFileDialog.DefaultExt = ".png";
                        saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                        saveFileDialog.Title = "Сохранить изображение КСНФ";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (KSNFPictureBox.Image != null)
                            {
                                KSNFPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            else
                            {
                                MessageBox.Show("Нет изобрежения для сохранения");
                            }
                        }
                    }
                };
                ToolStripMenuItem lenghtFuncKSNFMenu = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
                lenghtFuncDSNFMenu.Click += KNSFFuncLenght;
                //Контекстное меню КСНФ
                contextMenuKSNF.Items.Add(analysResultKSNF);
                contextMenuKSNF.Items.Add(truthTableMenuKSNF);
                contextMenuKSNF.Items.Add(new ToolStripSeparator());
                contextMenuKSNF.Items.Add(saveFileKSNFMenu);
                contextMenuKSNF.Items.Add(saveImageKSNFMenu);
                contextMenuKSNF.Items.Add(new ToolStripSeparator());
                contextMenuKSNF.Items.Add(lenghtFuncKSNFMenu);
                KSNFPictureBox.ContextMenuStrip = contextMenuKSNF;

                BuildKSNF();
            }
        }


        public void BasisChange()
        {
            if (logicFunctionSource != null)
            {
                logicFunctionBasis = (LogicFunction)logicFunctionSource.Clone();
                logicFunctionBasis.SetCursor(false);
                BasisPictureBox.Image = logicFunctionBasis.Fbitmap;
                logicFunctionBasis.Optimization();

                if (logicFunctionBasis.Basis(BasisComboBox.SelectedIndex))
                {

                }
                logicFunctionBasis.Optimization();
                logicFunctionBasis.Paint();
                BasisPictureBox.Refresh();
            }
        }

        private void BasisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasisChange();
        }

        /// <summary>
        /// Кнопка открытия формы таблицы истинности
        /// </summary>
        private void TruthTableButton_Click(object sender, EventArgs e)
        {
            TruthTableForm truthTable = new TruthTableForm();
            truthTable.ShowDialog();
            BuildKSNF();
        }
        /// <summary>
        /// Кнопка открытия формы минимизации функции
        /// </summary>
        private void MinimizeFuncButton_Click(object sender, EventArgs e)
        {
            MinimizationFuncForm minimizationFunc = new MinimizationFuncForm();
            
            if (minimizationFunc.ShowDialog() == DialogResult.OK)
            {
                if (LogicFunctionData.LogicFunction != null)
                {
                    logicFunction = (LogicFunction)LogicFunctionData.LogicFunction.Clone();
                    logicFunction.SetOutput(FunctionPictureBox.ClientRectangle);
                    FunctionPictureBox.Image = logicFunction.Fbitmap;
                }
                MainTabControl.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// РегуДирование размеров формы
        /// </summary>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rectangle = FunctionPictureBox.ClientRectangle;

            if (MainTabControl.SelectedIndex == 1)
            {
                rectangle = FunctionPictureBox.ClientRectangle;
            }
            else if (MainTabControl.SelectedIndex == 2)
            {
                rectangle = InitialFunctionBazisPictureBox.ClientRectangle;
            }
            else if (MainTabControl.SelectedIndex == 3)
            {
                rectangle = DNSFPictureBox.ClientRectangle;
            }

            logicFunction.SetRectangle(rectangle);
            logicFunctionSource.SetRectangle(rectangle);
            logicFunctionBasis.SetRectangle(rectangle);
            logicFunctionDSNF.SetRectangle(rectangle);
            logicFunctionKSNF.SetRectangle(rectangle);


            if (MainTabControl.SelectedIndex == 1)
            {
                rectangle = FunctionPictureBox.ClientRectangle;
                FunctionPictureBox.Image = logicFunction.Fbitmap;
                Paint();
            }
            else if (MainTabControl.SelectedIndex == 2)
            {
                rectangle = InitialFunctionBazisPictureBox.ClientRectangle;
                InitialFunctionBazisPictureBox.Image = logicFunctionSource.Fbitmap;
                BasisPictureBox.Image = logicFunctionBasis.Fbitmap;
                logicFunctionSource.Paint();
                logicFunctionBasis.Paint();
                InitialFunctionBazisPictureBox.Refresh();
                BasisPictureBox.Refresh();
            }
            else if (MainTabControl.SelectedIndex == 3)
            {
                rectangle = DNSFPictureBox.ClientRectangle;
                DNSFPictureBox.Image = logicFunctionDSNF.Fbitmap;
                KSNFPictureBox.Image = logicFunctionKSNF.Fbitmap;
                logicFunctionDSNF.Paint();
                DNSFPictureBox.Refresh();

                logicFunctionKSNF.Paint();
                KSNFPictureBox.Refresh();

            }

        }



        //private void ButtonImage()
        //{
        //    Bitmap bitmap2 = new Bitmap(X1FuncButton.Width, X1FuncButton.Height);

        //    for (int i = 1; i <= 1; i++)
        //    {
        //        Bitmap bitmap1 = new Bitmap(30, 30);
        //        using (Graphics graphics = Graphics.FromImage(bitmap1))
        //        {
        //            graphics.Clear(Color.White);
        //            Font font = new Font("Segoe UI Symbol", 12f, FontStyle.Bold);
        //            Font smallFont = new Font("Segoe UI Symbol", 12f * 6.0f / 12, FontStyle.Bold);
        //            Brush brush = new SolidBrush(Color.FromArgb(131, 60, 11));
        //            string symbol = "К";
        //            string numSymbol0 = "0";
        //            string numSymbol1 = "1";
        //            SizeF sizeF = graphics.MeasureString(symbol, font);
        //            SizeF sizeSmallF = graphics.MeasureString(numSymbol0, smallFont);
        //            //float x = (X1FuncButton.Width / 2) - ((sizeF.Width / 2));
        //            //float y = (X1FuncButton.Height - sizeF.Height) / 2;
        //            float x = -1;
        //            float y = 1;
        //            graphics.DrawString(symbol, font, brush, x, y);
        //            graphics.DrawString(numSymbol0, smallFont, brush, x + sizeF.Width - 3, 2);
        //            graphics.DrawString(numSymbol1, smallFont, brush, x + sizeF.Width - 3, 13);
        //            //graphics.DrawLine(new Pen(brush), new PointF(x, 6f), new PointF(x + sizeF.Width, 6f));
        //            //graphics.FillRectangle(brushLiNA, x, 7f, sizeF.Width, 2f);
        //            //NewFunctionButton.Image = bitmap1;

        //            bitmap1.Save($"RedCoeffK.png", System.Drawing.Imaging.ImageFormat.Png);

        //            //{
        //            //    textBrush = new SolidBrush(Color.FromArgb(255, 255, 0));
        //            //}
        //            //else if (MinimizeData.ImplsM[e.RowIndex] == 1)
        //            //{
        //            //    textBrush = new SolidBrush(Color.FromArgb(0, 112, 192));
        //            //}
        //            //else if (MinimizeData.ImplsM[e.RowIndex] == 2)
        //            //{
        //            //    textBrush = new SolidBrush(Color.FromArgb(12, 12, 12));
        //            //}
        //            //else
        //            //{
        //            //    textBrush = new SolidBrush(Color.FromArgb(131, 60, 11));
        //            //}
        //        }
        //    }
        //}


        /// <summary>
        /// Страница синтез
        /// </summary>
        private void BuildKSNF()
        {
            int i;
            int j;
            bool firstDSNF = true;
            bool firstKSNF = true;

            logicFunctionDSNF = new LogicFunction();
            logicFunctionDSNF.SetOutput(DNSFPictureBox.ClientRectangle);
            logicFunctionDSNF.SetCursor(false);
            DNSFPictureBox.Image = logicFunctionDSNF.Fbitmap;

            logicFunctionKSNF = new LogicFunction();
            logicFunctionKSNF.SetOutput(KSNFPictureBox.ClientRectangle);
            logicFunctionKSNF.SetCursor(false);
            KSNFPictureBox.Image = logicFunctionKSNF.Fbitmap;

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (TruthTableData.Table[i])
                {
                    if (firstDSNF)
                    {
                        firstDSNF = false;
                    }
                    else
                    {
                        logicFunctionDSNF.AddArgument(ArgumentType.Operation, 2);
                    }
                    logicFunctionDSNF.AddArgument(ArgumentType.BracketLeft);
                    for (j = 1; j <= TruthTableData.CountX; j++)
                    {
                        if (j != 1)
                        {
                            logicFunctionDSNF.AddArgument(ArgumentType.Operation, 1);
                        }
                        if ((i & (1 << (TruthTableData.CountX - j))) == 0)
                        {
                            logicFunctionDSNF.AddArgument(ArgumentType.NVariable, j);
                        }
                        else
                        {
                            logicFunctionDSNF.AddArgument(ArgumentType.Variable, j);
                        }
                    }
                    logicFunctionDSNF.AddArgument(ArgumentType.BracketRight);

                }
                else
                {
                    if (firstKSNF)
                    {
                        firstKSNF = false;
                    }
                    else
                    {
                        logicFunctionKSNF.AddArgument(ArgumentType.Operation, 1);
                    }
                    logicFunctionKSNF.AddArgument(ArgumentType.BracketLeft);

                    for (j = 1; j <= TruthTableData.CountX; j++)
                    {
                        if (j != 1)
                        {
                            logicFunctionKSNF.AddArgument(ArgumentType.Operation, 2);
                        }
                        if ((i & (1 << (TruthTableData.CountX - j))) == 0)
                        {
                            logicFunctionKSNF.AddArgument(ArgumentType.Variable, j);
                        }
                        else
                        {
                            logicFunctionKSNF.AddArgument(ArgumentType.NVariable, j);
                        }
                    }
                    logicFunctionKSNF.AddArgument(ArgumentType.BracketRight);
                }
            }

            logicFunctionDSNF.Paint();
            DNSFPictureBox.Refresh();

            logicFunctionKSNF.Paint();
            KSNFPictureBox.Refresh();
        }

        private void PrintTimer_Tick(object sender, EventArgs e)
        {
            if (currentIndex < fullText.Length)
            {
                HeaderLabel.Text += fullText[currentIndex];
                currentIndex++;
            }
            else
            {
                PrintTimer.Stop();
                PauseTimer.Interval = 6000;
                PauseTimer.Start();
            }
        }

        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            PauseTimer.Stop();
            HeaderLabel.Text = "";
            currentIndex = 0;
            PrintTimer.Start();
        }

        /// <summary>
        /// Всплывающая подсказка при наведении на кнопки
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            //Ряд 1
            toolTip.SetToolTip(GideButton, "Страница 'О программе'");
            toolTip.SetToolTip(X1FuncButton, "Переменная Х1 (Кнопка: 1)");
            toolTip.SetToolTip(X2FuncButton, "Переменная Х2 (Кнопка: 2)");
            toolTip.SetToolTip(X3FuncButton, "Переменная Х3 (Кнопка: 3)");
            toolTip.SetToolTip(X4FuncButton, "Переменная Х4 (Кнопка: 4)");
            toolTip.SetToolTip(X5FuncButton, "Переменная Х5 (Кнопка: 5)");
            toolTip.SetToolTip(X6FuncButton, "Переменная Х6 (Кнопка: 6)");
            toolTip.SetToolTip(X7FuncButton, "Переменная Х7 (Кнопка: 7)");
            toolTip.SetToolTip(X8FuncButton, "Переменная Х8 (Кнопка: 8)");
            toolTip.SetToolTip(X9FuncButton, "Переменная Х9 (Кнопка: 9)");
            toolTip.SetToolTip(LeftCursorButton, "Курсор влево (Кнопка: Left)");
            toolTip.SetToolTip(RightCursorButton, "Курсор вправо (Кнопка: Right)");
            toolTip.SetToolTip(StartCursorButton, "Курсор в начало (Кнопка: Top)");
            toolTip.SetToolTip(EndCursorButton, "Курсор в конец (Кнопка: Down)");
            toolTip.SetToolTip(DeleteLeftButton, "Удалить символ слева (Кнопка:Backspace )");
            toolTip.SetToolTip(DeleteRightButton, "Удалить символ справа (Кнопка: Del)");

            //Ряд 2
            toolTip.SetToolTip(ZeroFuncButton, "Константа 'Ноль' (Кнопка: Ctrl+0)");
            toolTip.SetToolTip(UnitFuncButton, "Константа 'Едииница' (Кнопка: Ctrl+1)");
            toolTip.SetToolTip(LeftBracketButton, "Открывающая скобка (Кнопка: Shift+9)");
            toolTip.SetToolTip(RightBreacketButton, "Закрывающая скобка (Кнопка: Shift+0)");
            toolTip.SetToolTip(NegativeButton, "Отрицание (Кнопка: Shift+1)");
            toolTip.SetToolTip(AndButton, "Конъюнкций [И] (Кнопка: Shift+7)");
            toolTip.SetToolTip(OrButton, "Дизъюнкиция [ИЛИ] (Кнопка: +)");
            toolTip.SetToolTip(ExclusiveOrButton, "Сложение по модулю 2 [Исключающее ИЛИ] (Кнопка: Shift+'+')");
            toolTip.SetToolTip(ShefferButton, "Функция Шеффера [И-НЕ] (Кнопка: /)");
            toolTip.SetToolTip(VebbaButton, "Функция Вебба [ИЛИ-НЕ] (Кнопка: o)");
            toolTip.SetToolTip(EquvalenceButton, "Эквивалентность [Исключающее ИЛИ-НЕ] (Кнопка: =)");
            toolTip.SetToolTip(ImplicationButton, "Импликация (Кнопка: Ctrl+>)");
            toolTip.SetToolTip(ReverseImplicationButton, "Обратная импликация (Кнопка: Ctrl+<)");
            toolTip.SetToolTip(MoreButton, "Больше [Вычитание] (Кнопка: >)");
            toolTip.SetToolTip(LessButton, "Меньше [] (Кнопка: <)");
            toolTip.SetToolTip(NewFunctionButton, "Создать новую функцию (Кнопка: Ctrl+N)");
            toolTip.SetToolTip(FileOpenButton, "Открыть существующую функцию (Кнопка: Ctrl+O)");
            toolTip.SetToolTip(SaveFileButton, "Сохранить функцию (Кнопка: Ctrl+S)");
            toolTip.SetToolTip(ImageFunctionButton, "Сохранить изобрежание функции (Кнопка: Ctrl+E)");
            toolTip.SetToolTip(TableFuncButton, "Все функции для двух аргументов (Кнопка: Ctrl+F)");
        }

        private void AnyButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            FunctionTableForm form = new FunctionTableForm();
            form.ShowDialog();
        }

        private void FixCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FixCheckBox.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }


        private void FuncLenght(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во символов:\n\t= {logicFunction.FLength} (максимум={LogicFunction.LIMIT} символов)\n\nКол-во знаков операции:\n\t= {logicFunction.CountOperation}\n\nКоличество отрицаний:\n\t= {logicFunction.NegativeCountFunc}", "Размер функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BasisFuncLenght(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во символов:\n\t= {logicFunctionBasis.FLength} (максимум={LogicFunction.LIMIT} символов)\n\nКол-во знаков операции:\n\t= {logicFunctionBasis.CountOperation}\n\nКоличество отрицаний:\n\t= {logicFunctionBasis.NegativeCountFunc}", "Размер функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DNSFFuncLenght(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во символов:\n\t= {logicFunctionDSNF.FLength} (максимум={LogicFunction.LIMIT} символов)\n\nКол-во знаков операции:\n\t= {logicFunctionDSNF.CountOperation}\n\nКоличество отрицаний:\n\t= {logicFunctionDSNF.NegativeCountFunc}", "Размер функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void KNSFFuncLenght(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во символов:\n\t= {logicFunctionKSNF.FLength} (максимум={LogicFunction.LIMIT} символов)\n\nКол-во знаков операции:\n\t= {logicFunctionKSNF.CountOperation}\n\nКоличество отрицаний:\n\t= {logicFunctionKSNF.NegativeCountFunc}", "Размер функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}