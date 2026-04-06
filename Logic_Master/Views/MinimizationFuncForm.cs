using Logic_Master.Models;
using Logic_Master.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic_Master.Views
{
    public partial class MinimizationFuncForm : Form
    {
        private LogicFunction logicFunctionMDNF = new LogicFunction();
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
        public MinimizationFuncForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            contextMenuStrip.Items.Clear();

            ToolStripMenuItem analysResult = new ToolStripMenuItem("Анализировать результат", Properties.Resources.FuncImageTabControl);
            analysResult.Click += (sender, e) =>
            {
                LogicFunctionData.LogicFunction = (LogicFunction)logicFunctionMDNF.Clone();
                LogicFunctionData.LogicFunction.SetCursor(true);
                DialogResult = DialogResult.OK;
                Close();
            };
            ToolStripMenuItem truthTableMenu = new ToolStripMenuItem("Построить таблицу истиности", Properties.Resources.TruthTableButton);
            truthTableMenu.Click += (sender, e) =>
            {
                TruthTableForm truthTable = new TruthTableForm();
                truthTable.ShowDialog();
            };
            ToolStripMenuItem saveFile = new ToolStripMenuItem("Сохранить в файл", Properties.Resources.SaveFile);
            saveFile.Click += SaveFileMDNF;
            ToolStripMenuItem saveImage = new ToolStripMenuItem("Сохранить изображение", Properties.Resources.FileinImage2);
            saveImage.Click += SaveImageMDNF;
            ToolStripMenuItem lenghtFunc = new ToolStripMenuItem("Размер функции", Properties.Resources.FuncSize);
            lenghtFunc.Click += FuncLenght;
            contextMenuStrip.Items.Add(analysResult);
            contextMenuStrip.Items.Add(truthTableMenu);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(saveImage);
            contextMenuStrip.Items.Add(saveFile);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(lenghtFunc);
            MDNFPictureBox.ContextMenuStrip = contextMenuStrip; //привязка

            logicFunctionMDNF.SetOutput(MDNFPictureBox.ClientRectangle);
            logicFunctionMDNF.SetCursor(false);
            MDNFPictureBox.Image = logicFunctionMDNF.Fbitmap;
        }

        private void MinimizationFuncForm_Load(object sender, EventArgs e)
        {
            switch (TruthTableData.CountX)
            {
                case 1:
                    MinimizeData.Limit = 2;
                    break;
                case 2:
                    MinimizeData.Limit = 4;
                    break;
                case 3:
                    MinimizeData.Limit = 12;
                    break;
                case 4:
                    MinimizeData.Limit = 48;
                    break;
                case 5:
                    MinimizeData.Limit = 160;
                    break;
                case 6:
                    MinimizeData.Limit = 480;
                    break;
                case 7:
                    MinimizeData.Limit = 1680;
                    break;
                case 8:
                    MinimizeData.Limit = 5376;
                    break;
                case 9:
                    MinimizeData.Limit = 16128;
                    break;
            }
            MinimizeData.All = new int[MinimizeData.Limit];
            MinimizeData.AllM = new int[MinimizeData.Limit];
            MinimizeData.Impls = new int[MinimizeData.Limit];
            MinimizeData.ImplsM = new int[MinimizeData.Limit];
            MinimizeData.First = new int[MinimizeData.Limit];
            MinimizeData.FirstM = new bool[MinimizeData.Limit];
            MinimizeData.Second = new int[MinimizeData.Limit];
            MinimizeData.Red = new int[MinimizeData.Limit];

            MinimizeData.Coefs = new int[1 << TruthTableData.CountX];
            MinimizeData.Flags = new int[1 << TruthTableData.CountX][];

            MinimizeData.Flags[0] = new int[1 << TruthTableData.CountX];
            int l = 1;
            for (int i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                MinimizeData.Flags[0][i] = 0;
            }
            for (int i = 1; i <= TruthTableData.CountX; i++)
            {
                for (int j = (1 << TruthTableData.CountX) - 1; j > 0; j--)
                {
                    if (MinimizeData.Kol(j) == i)
                    {
                        MinimizeData.Coefs[l] = j;
                        MinimizeData.Flags[l] = new int[1 << i];
                        for (int k = 0; k < (1 << i); k++)
                        {
                            MinimizeData.Flags[l][k] = 1;
                        }
                        l++;
                    }
                }
            }

            Minimize();
        }

        private void Minimize()
        {
            //Минимизация методом Квайна Мак-Класки
            FindImplicants();
            SetFlags();

            if (MakKlaskiRadioButton.Checked)
            {
                BuildMDNFMakKlaski();
            }
            else
            {
                BuildMDNFCoeff();
            }
        }

        /// <summary>
        /// Поиск первичных импликантов
        /// </summary>
        private void FindImplicants()
        {
            MinimizeData.Implicants = string.Empty;
            int i;
            int j;
            int dif;
            int n;
            MinimizeData.Implicants += "Исходные минитермы (ДСНФ)\n";
            MinimizeData.AllCount = 0;
            MinimizeData.ImplsCount = 0;
            MinimizeData.FirstCount = 0;
            MinimizeData.SecondCount = 0;

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (TruthTableData.Table[i])
                {
                    MinimizeData.First[MinimizeData.FirstCount] = i;
                    MinimizeData.FirstM[MinimizeData.FirstCount] = false;
                    MinimizeData.FirstCount++;
                    if (MinimizeData.FirstCount > MinimizeData.Limit)
                    {
                        Error();
                    }
                    MinimizeData.All[MinimizeData.AllCount] = i;
                    MinimizeData.AllCount++;
                }
            }
            for (n = 1; n <= TruthTableData.CountX; n++)
            {
                for (i = 0; i < MinimizeData.FirstCount; i++)
                {
                    for (j = i + 1; j < MinimizeData.FirstCount; j++)
                    {
                        if ((MinimizeData.First[i] >> 16) == (MinimizeData.First[j] >> 16))
                        {
                            dif = MinimizeData.First[i] ^ MinimizeData.First[j];
                            if (MinimizeData.Kol(dif) == 1)
                            {
                                if (n != TruthTableData.CountX)
                                {
                                    MinimizeData.FirstM[i] = true;
                                    MinimizeData.FirstM[j] = true;
                                }
                                MinimizeData.Second[MinimizeData.SecondCount] = MinimizeData.First[i] < MinimizeData.First[j] ? MinimizeData.First[i] : MinimizeData.First[j];
                                MinimizeData.Second[MinimizeData.SecondCount] |= dif << 16;
                                MinimizeData.SecondCount++;
                                if (MinimizeData.SecondCount > MinimizeData.Limit)
                                {
                                    Error();
                                }
                            }
                        }
                    }

                    if (!MinimizeData.FirstM[i])
                    {
                        MinimizeData.Impls[MinimizeData.ImplsCount] = MinimizeData.First[i];
                        MinimizeData.ImplsCount++;
                    }
                }

                Input(n - 1);

                if (n != TruthTableData.CountX)
                {
                    MinimizeData.Implicants += $"Минитермы {n}-го ранга:\n";
                    MinimizeData.FirstCount = 0;

                    for (i = 0; i < MinimizeData.SecondCount; i++)
                    {
                        MinimizeData.First[MinimizeData.FirstCount] = MinimizeData.Second[i];
                        MinimizeData.FirstM[MinimizeData.FirstCount] = false;
                        MinimizeData.FirstCount++;

                        for (j = i + 1; j < MinimizeData.SecondCount; j++)
                        {
                            if (MinimizeData.Second[i] == MinimizeData.Second[j])
                            {
                                MinimizeData.FirstCount--;
                                break;
                            }
                        }
                    }

                    MinimizeData.SecondCount = 0;

                }
            }

            MinimizeData.FirstCount = 0;
            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                MinimizeData.First[MinimizeData.FirstCount] = MinimizeData.Impls[i];
                MinimizeData.FirstCount++;
                for (j = i + 1; j < MinimizeData.ImplsCount; j++)
                {
                    if (MinimizeData.Impls[i] == MinimizeData.Impls[j])
                    {
                        MinimizeData.FirstCount--;
                        break;
                    }
                }
            }
            MinimizeData.ImplsCount = MinimizeData.FirstCount;
            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                MinimizeData.Impls[i] = MinimizeData.First[i];
            }

            MinimizeData.Implicants += "Первчиные импликанты\n";
            InputImpls();
        }

        private void InputImpls()
        {
            string s;
            int i;
            int j;
            if (MinimizeData.ImplsCount != 0)
            {
                s = "\t";
            }
            else
            {
                s = "\tотсутствует";
            }
            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                if (i != 0)
                {
                    s += ", ";
                }
                for (j = TruthTableData.CountX - 1; j >= 0; j--)
                {
                    if (Convert.ToBoolean(MinimizeData.Impls[i] & 0xFFFF & (1 << j)))
                    {
                        s += "1";
                    }
                    else if (Convert.ToBoolean((MinimizeData.Impls[i] >> 16) & (1 << j)))
                    {
                        s += "-";
                    }
                    else
                    {
                        s += "0";
                    }
                }
            }
            MinimizeData.Implicants += $"{s}\n";
        }

        private void Input(int n)
        {
            string s;
            string ss;
            int i;
            int j;
            int k;
            bool fl;
            for (i = 0; i <= TruthTableData.CountX - n; i++)
            {
                s = $"\t{i}";
                if (i == 3)
                {
                    s += "-ья";
                }
                else
                {
                    s += "-ая";
                }
                s += " группа: ";
                fl = false;
                for (j = 0; j < MinimizeData.FirstCount; j++)
                {
                    if (MinimizeData.Kol(MinimizeData.First[j] & 0xFFFF) == i)
                    {
                        ss = string.Empty;
                        for (k = TruthTableData.CountX - 1; k >= 0; k--)
                        {
                            if (Convert.ToBoolean(MinimizeData.First[j] & 0xFFFF & (1 << k)))
                            {
                                ss += "1";
                            }
                            else if (Convert.ToBoolean((MinimizeData.First[j] >> 16) & (1 << k)))
                            {
                                ss += "-";
                            }
                            else
                            {
                                ss += "0";
                            }
                        }
                        if (fl)
                        {
                            s += $", {ss}";
                        }
                        else
                        {
                            s += ss;
                        }
                        if (MinimizeData.FirstM[j])
                        {
                            s += "*";
                        }
                        else
                        {
                            s += " ";
                        }
                        if (s.Length > 240)
                        {
                            MinimizeData.Implicants += $"{s}\n";
                            s = "\t\t\t\t";
                            fl = false;
                        }
                        else
                        {
                            fl = true;
                        }

                    }
                }
                if (!fl)
                {
                    s += "отсутствует";
                }
                if (s != "\t\t\t\t")
                {
                    MinimizeData.Implicants += $"{s}\n";
                }
            }
        }

        /// <summary>
        /// Вывод ошибки
        /// </summary>
        private void Error()
        {
            MessageBox.Show("Недостаточно выделено пвамяти", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        private void TableTagsButton_Click(object sender, EventArgs e)
        {
            TableTagsForm tableTagsForm = new TableTagsForm();
            tableTagsForm.ShowDialog();
        }

        private void ImplikantiButton_Click(object sender, EventArgs e)
        {
            PrimaryImplicants primaryImplicants = new PrimaryImplicants();
            primaryImplicants.ShowDialog();
        }

        private void TableCoeffButton_Click(object sender, EventArgs e)
        {
            TableCoeff tableCoeff = new TableCoeff();
            tableCoeff.ShowDialog();
        }


        private void BuildMDNFMakKlaski()
        {
            int i;
            int j;
            bool firstMDNF = true;
            bool firstArg;
            logicFunctionMDNF.Clear();

            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                if (MinimizeData.ImplsM[i] != 2)
                {
                    if (firstMDNF)
                    {
                        firstMDNF = false;
                    }
                    else
                    {
                        logicFunctionMDNF.AddArgument(ArgumentType.Operation, 2);
                    }

                    logicFunctionMDNF.AddArgument(ArgumentType.BracketLeft);
                    firstArg = true;

                    for (j = 1; j <= TruthTableData.CountX; j++)
                    {
                        if ((MinimizeData.Impls[i] & (1 << 16 << (TruthTableData.CountX - j))) == 0)
                        {
                            if (!firstArg)
                            {
                                logicFunctionMDNF.AddArgument(ArgumentType.Operation, 1);
                            }
                            else
                            {
                                firstArg = false;
                            }
                            if ((MinimizeData.Impls[i] & (1 << (TruthTableData.CountX - j))) == 0)
                            {
                                logicFunctionMDNF.AddArgument(ArgumentType.NVariable, j);
                            }
                            else
                            {
                                logicFunctionMDNF.AddArgument(ArgumentType.Variable, j);
                            }
                        }
                    }

                    logicFunctionMDNF.AddArgument(ArgumentType.BracketRight);
                }

            }

            if (DeleteBracketsCheckBox.Checked)
            {
                logicFunctionMDNF.Optimization();
            }

            logicFunctionMDNF.Paint();
            MDNFPictureBox.Refresh();
        }

        private void MakKlaskiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MakKlaskiRadioButton.Checked)
            {
                BuildMDNFMakKlaski();
            }
            else
            {
                BuildMDNFCoeff();
            }
        }


        /// <summary>
        /// Нахождение значений коэффициентов
        /// </summary>
        private void SetFlags()
        {
            int i;
            int j;
            int k;
            bool kill;

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (!TruthTableData.Table[i])
                {
                    for (j = 1; j < (1 << TruthTableData.CountX); j++)
                    {
                        MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] = 0;
                    }
                }
            }
            //Все первые невычеркнутые коэффициенты
            for (i = 0; i < (1 << TruthTableData.CountX); i++) //строки
            {
                if (TruthTableData.Table[i])
                {
                    for (j = 1; j < (1 << TruthTableData.CountX); j++) //столбцы
                    {
                        if (MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] == 2)
                        {
                            break;
                        }
                        if (MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] == 1)
                        {
                            MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] = 2;
                            for (k = 0; k < (1 << TruthTableData.CountX); k++)
                            {
                                if (MinimizeData.Number(MinimizeData.Coefs[j], k) == MinimizeData.Number(MinimizeData.Coefs[j], i))
                                {
                                    MinimizeData.Flags[0][k]++;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            MinimizeData.MinPokritie = string.Empty;
            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                MinimizeData.MinPokritie += $"{i} - {MinimizeData.Flags[0][i]}\n";
            }
            MinimizeData.MinPokritie += "\n";

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (TruthTableData.Table[i])
                {
                    for (j = 1; j < (1 << TruthTableData.CountX); j++)
                    {
                        if (MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] == 2)
                        {
                            kill = true;
                            for (k = 0; k < (1 << TruthTableData.CountX); k++)
                            {
                                if (MinimizeData.Number(MinimizeData.Coefs[j], k) == MinimizeData.Number(MinimizeData.Coefs[j], i))
                                {
                                    if (MinimizeData.Flags[0][k] == 1)
                                    {
                                        kill = false;
                                        MinimizeData.MinPokritie += $"{MinimizeData.Flags[0][k]}-{k}-{i}-{j}  -skiped\n";
                                        break;
                                    }
                                }
                            }
                            if (kill)
                            {
                                MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] = 1;
                                MinimizeData.MinPokritie += $"{i}-{k} #{j}  -killed\n";

                                for (k = 0; k < (1 << TruthTableData.CountX); k++)
                                {
                                    if (MinimizeData.Number(MinimizeData.Coefs[j], k) == MinimizeData.Number(MinimizeData.Coefs[j], i))
                                    {
                                        MinimizeData.Flags[0][k]--;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            MinimizeData.MinPokritie += "\n";

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                MinimizeData.MinPokritie += $"{i} - {MinimizeData.Flags[0][i]}\n";
            }
        }

        private void BuildMDNFCoeff()
        {
            int i;
            int j;
            int k;
            bool firstMDNF = true;
            bool firstArg;
            logicFunctionMDNF.Clear();

            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (TruthTableData.Table[i])
                {
                    for (j = 1; j < (1 << TruthTableData.CountX); j++)
                    {
                        if (MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] == 2)
                        {
                            MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] = 3;
                            if (firstMDNF)
                            {
                                firstMDNF = false;
                            }
                            else
                            {
                                logicFunctionMDNF.AddArgument(ArgumentType.Operation, 2);
                            }
                            logicFunctionMDNF.AddArgument(ArgumentType.BracketLeft);
                            firstArg = true;
                            for (k = TruthTableData.CountX - 1; k >= 0; k--)
                            {
                                if ((MinimizeData.Coefs[j] & (1 << k)) != 0)
                                {
                                    if (!firstArg)
                                    {
                                        logicFunctionMDNF.AddArgument(ArgumentType.Operation, 1);
                                    }
                                    else
                                    {
                                        firstArg = false;
                                    }
                                    if ((i & (1 << k)) != 0)
                                    {
                                        logicFunctionMDNF.AddArgument(ArgumentType.Variable, TruthTableData.CountX - k);
                                    }
                                    else
                                    {
                                        logicFunctionMDNF.AddArgument(ArgumentType.NVariable, TruthTableData.CountX - k);
                                    }
                                }
                            }
                            logicFunctionMDNF.AddArgument(ArgumentType.BracketRight);
                        }
                    }
                }
            }
            for (i = 0; i < (1 << TruthTableData.CountX); i++)
            {
                if (TruthTableData.Table[i])
                {
                    for (j = 1; j < (1 << TruthTableData.CountX); j++)
                    {
                        if (MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] == 3)
                        {
                            MinimizeData.Flags[j][MinimizeData.Number(MinimizeData.Coefs[j], i)] = 2;
                        }
                    }
                }
            }
            if (DeleteBracketsCheckBox.Checked)
            {
                logicFunctionMDNF.Optimization();
                logicFunctionMDNF.Paint();
                MDNFPictureBox.Refresh();
            }
        }



        private void DeleteBracketsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteBracketsCheckBox.Checked)
            {
                logicFunctionMDNF.Optimization();
                logicFunctionMDNF.Paint();
                MDNFPictureBox.Refresh();
            }
            else if (MakKlaskiRadioButton.Checked)
            {
                BuildMDNFMakKlaski();
            }
            else
            {
                BuildMDNFCoeff();
            }
        }

        private void MinimizationFuncForm_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rectangle = MDNFPictureBox.ClientRectangle;

            logicFunctionMDNF.SetRectangle(rectangle);
            MDNFPictureBox.Image = logicFunctionMDNF.Fbitmap;
            logicFunctionMDNF.Paint();
            MDNFPictureBox.Refresh();
        }

        private void SaveImageMDNF(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "Изображение МДНФ функции"; 
                saveFileDialog.DefaultExt = ".png"; 
                saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                saveFileDialog.Title = "Сохранить изображение функции";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (MDNFPictureBox.Image != null)
                    {
                        MDNFPictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else
                    {
                        MessageBox.Show("Нет изобрежения для сохранения");
                    }
                }
            }
        }
        private void FuncLenght(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во символов:\n\t= {logicFunctionMDNF.FLength} (максимум={LogicFunction.LIMIT} символов)\n\nКол-во знаков операции:\n\t= {logicFunctionMDNF.CountOperation}\n\nКоличество отрицаний:\n\t= {logicFunctionMDNF.NegativeCountFunc}", "Размер функции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveFileMDNF(object sender, EventArgs e) //сохранение файла функции
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Сохранить логическую функцию";
            saveFileDialog.FileName = "NDNF_Function";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (logicFunctionMDNF.SaveFunctionJSON(saveFileDialog.FileName))
                {
                    MessageBox.Show($"Файл успешно сохранён в JSON");
                }
            }
        }
    }
}
