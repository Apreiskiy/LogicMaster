using Logic_Master.Models;
using System.Windows.Forms;

namespace Logic_Master
{
    public partial class Form1 : Form
    {
        LogicFunction logicFunction;
        bool cursorVisible;


        public Form1()
        {
            InitializeComponent();
            cursorVisible = true;
            //Graphics g = FunctionPictureBox.CreateGraphics();
            logicFunction = new LogicFunction();
            logicFunction.SetOutput(FunctionPictureBox.ClientRectangle);
            FunctionPictureBox.Image = logicFunction.Fbitmap;
            //logicFunction = new LogicFunction(FunctionPictureBox.Width, FunctionPictureBox.Height);
            Paint();
        }

        private void Paint()
        {
            if (!logicFunction.Update(true))
            {
                logicFunction.Paint();

                FunctionPictureBox.Refresh();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Formula formula = new Formula();
            bool res = formula.Solve("x1.1x2", new bool[]
            {
                true, false
            });
            MessageBox.Show(res.ToString());
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
                logicFunction.AddArgument(ArgumentType.Operation, 4);
            }
            else if (button == VebbaButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 5);
            }
            else if (button == EquvalenceButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 6);
            }
            else if (button == ImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 7);
            }
            else if (button == ReverseImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 8);
            }
            else if (button == MoreButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 9);
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



        private void ActionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button == GideButton)
            {
                //пока оставим
            }
            else if (button == SettingButton)
            {
                //пока оставим
            }
            else if (button == X1FuncButton)
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
                logicFunction.AddArgument(ArgumentType.Operation, 4);
            }
            else if (button == VebbaButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 5);
            }
            else if (button == EquvalenceButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 6);
            }
            else if (button == ImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 7);
            }
            else if (button == ReverseImplicationButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 8);
            }
            else if (button == MoreButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 9);
            }
            else if (button == LessButton)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 10);
            }



            else if (button == NewFunctionButton)
            {

            }
            else if (button == FileOpenButton)
            {

            }
            else if (button == SaveFileButton)
            {

            }
            else if (button == ImageFunctionButton)
            {

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

            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) //реагирование к нумпаду
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
            else if (e.Control == true && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 0);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Control == true && e.KeyCode == Keys.D1)
            {
                logicFunction.AddArgument(ArgumentType.FixedValue, 1);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }


            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                logicFunction.AddArgument(ArgumentType.BracketLeft);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.OemCloseBrackets)
            {
                logicFunction.AddArgument(ArgumentType.BracketRight);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.Shift && e.KeyCode == Keys.D1)
            {
                logicFunction.Negative();
            }
            else if (e.Shift && (e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 1);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }

            else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 2);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Control && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 3);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.Divide)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 4);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.O)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 5);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Shift && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add))
            {
                logicFunction.AddArgument(ArgumentType.Operation, 6);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Control && e.KeyCode == Keys.OemPeriod)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 7);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.Control && e.KeyCode == Keys.Oemcomma)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 8);
                logicFunction.Align(Aligment.Cursor);
                Paint();
            }
            else if (e.KeyCode == Keys.OemPeriod)
            {
                logicFunction.AddArgument(ArgumentType.Operation, 9);
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
            }
            else if (e.KeyCode == Keys.Delete)
            {
                logicFunction.DelArgumentRight();
            }

            else if (e.Control && e.KeyCode == Keys.N)
            {

            }
            else if (e.Control && e.KeyCode == Keys.O)
            {

            }
            else if (e.Control && e.KeyCode == Keys.S)
            {

            }
            else if (e.Control && e.KeyCode == Keys.E)
            {

            }

            e.SuppressKeyPress = true;
        }

        private void FunctionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void CursorTimer_Tick(object sender, EventArgs e) //Таймер для тиков курсора
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



        private void NewFunctionButton_Click(object sender, EventArgs e) //создание новой функции
        {
            logicFunction.Clear();
            Paint();
        }

        private void SaveFileButton_Click(object sender, EventArgs e) //сохранение файла функции
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Сохранить логическую функцию";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (logicFunction.SaveFunctionJSON(saveFileDialog.FileName))
                {
                    MessageBox.Show($"Файл успешно сохранён в JSON");
                }
            }
        }

        private void FileOpenButton_Click(object sender, EventArgs e) //загрузка сохраненных файлов
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.Title = "Открыть логическую функцию";
            if (openFileDialog.ShowDialog()== DialogResult.OK)
            {
                if (logicFunction.LoadFunctionJSON(openFileDialog.FileName))
                {
                    MessageBox.Show($"Файл успешно загружен");
                    Paint();
                }
            }
            
        }
    }
}