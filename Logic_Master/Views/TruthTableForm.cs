using Logic_Master.Models;
using Logic_Master.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic_Master.Views
{
    public partial class TruthTableForm : Form
    {
        ContextMenuStrip menuStrip = new ContextMenuStrip();

        public TruthTableForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
        private void BuildTable() //File UnMTable
        {
            TruthTableData.CountX = (int)CountArgumentNumeric.Value;
            int cN = 1 << TruthTableData.CountX;
            TruthTableDataGrid.ColumnCount = TruthTableData.CountX + 1;

            if (cN == 0)
            {
                TruthTableDataGrid.RowCount = 2;
                return;
            }

            TruthTableDataGrid.RowCount = cN;
        }

        private void CountArgumentNumeric_ValueChanged(object sender, EventArgs e)
        {
            BuildTable();
        }

        private void TruthTableDataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Font font = new Font("Segoe UI Symbol", 11f);
            bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
            if (e.CellStyle != null && e.Graphics != null)
            {
                Color backColor = isSelected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;
                e.Graphics.FillRectangle(new SolidBrush(backColor), e.CellBounds);
                bool lastColumn = e.ColumnIndex == TruthTableData.CountX;
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    bool value = lastColumn ? TruthTableData.Table[e.RowIndex] : Convert.ToBoolean(e.RowIndex & (1 << (TruthTableData.CountX - (e.ColumnIndex + 1))));

                    float textX = e.CellBounds.Left + (e.CellBounds.Width - Properties.Resources.ZeroSymbol.Width) / 2;
                    float textY = e.CellBounds.Top + (e.CellBounds.Height - Properties.Resources.ZeroSymbol.Height) / 2;
                    if (value)
                    {
                        e.Graphics.DrawImage(Properties.Resources.OneSymbol, textX, textY, 30, 30);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.ZeroSymbol, textX, textY, 30, 30);
                    }
                }

                else if (e.ColumnIndex == -1 && e.RowIndex != -1)
                {
                    string text = e.RowIndex.ToString();
                    Brush textBrush = new SolidBrush(isSelected ? Color.Black : Color.Gray);
                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    float textX = e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2;
                    float textY = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, font, textBrush, textX, textY);
                }

                else if (e.ColumnIndex != -1 && e.RowIndex == -1)
                {
                    if (e.ColumnIndex == TruthTableData.CountX)
                    {
                        font = new Font(font, FontStyle.Bold);
                        string text = "𝑓";
                        Brush textBrush = new SolidBrush(Color.Navy);
                        SizeF textSize = e.Graphics.MeasureString(text, font);
                        float textX = e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2;
                        float textY = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;
                        e.Graphics.DrawString(text, font, textBrush, textX, textY);
                    }
                    else
                    {
                        Bitmap bitmap = Properties.Resources.x1;
                        switch (e.ColumnIndex)
                        {
                            case 0:
                                bitmap = Properties.Resources.x1;
                                break;
                            case 1:
                                bitmap = Properties.Resources.x2;
                                break;
                            case 2:
                                bitmap = Properties.Resources.x3;
                                break;
                            case 3:
                                bitmap = Properties.Resources.x4;
                                break;
                            case 4:
                                bitmap = Properties.Resources.x5;
                                break;
                            case 5:
                                bitmap = Properties.Resources.x6;
                                break;
                            case 6:
                                bitmap = Properties.Resources.x7;
                                break;
                            case 7:
                                bitmap = Properties.Resources.x8;
                                break;
                            case 8:
                                bitmap = Properties.Resources.x9;
                                break;

                        }
                        float textX = e.CellBounds.Left + (e.CellBounds.Width - bitmap.Width) / 2;
                        float textY = e.CellBounds.Top + (e.CellBounds.Height - bitmap.Height) / 2;
                        e.Graphics.DrawImage(bitmap, textX, textY, 30, 30);
                    }


                }
                Pen gridPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(gridPen, e.CellBounds);
                e.Handled = true;
            }
        }

        private void TruthTableDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == TruthTableData.CountX)
            {
                TruthTableData.Table[e.RowIndex] = !TruthTableData.Table[e.RowIndex];
                TruthTableDataGrid.Invalidate();
                TruthTableDataGrid.Update();
            }
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = TruthTableDataGrid.SelectedRows.Cast<DataGridViewRow>().ToList();

            foreach (DataGridViewRow row in rows)
            {
                TruthTableData.Table[row.Index] = false;
            }
            TruthTableDataGrid.Invalidate();
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = TruthTableDataGrid.SelectedRows.Cast<DataGridViewRow>().ToList();

            foreach (DataGridViewRow row in rows)
            {
                TruthTableData.Table[row.Index] = true;
            }
            TruthTableDataGrid.Invalidate();
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = TruthTableDataGrid.SelectedRows.Cast<DataGridViewRow>().ToList();

            foreach (DataGridViewRow row in rows)
            {
                TruthTableData.Table[row.Index] = !TruthTableData.Table[row.Index];
            }
            TruthTableDataGrid.Invalidate();
        }

        private void TruthTableForm_Load(object sender, EventArgs e)
        {
            CountArgumentNumeric.Value = TruthTableData.CountX;
            BuildTable();
            ToolStripMenuItem saveTableMenu = new ToolStripMenuItem("Сохранить таблицу истинности", Properties.Resources.SaveFile);
            saveTableMenu.Click += (sender, e) =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = ".json";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = "Сохранить таблицу истинности";
                saveFileDialog.FileName = "Truth Table";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (TruthTableData.SaveFunctionJSON(saveFileDialog.FileName))
                    {
                        MessageBox.Show($"Файл успешно сохранён в JSON");
                    }
                }
            };
            ToolStripMenuItem openFileMenu = new ToolStripMenuItem("Открыть таблицу истинности", Properties.Resources.FileOpen2);
            openFileMenu.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Открыть таблицу истинности";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (TruthTableData.LoadFunctionJSON(openFileDialog.FileName))
                    {
                        MessageBox.Show($"Файл успешно загружен");
                        CountArgumentNumeric.Value = TruthTableData.CountX;
                        TruthTableDataGrid.Invalidate();
                    }
                }
            };
            menuStrip.Items.AddRange(new ToolStripMenuItem[] { saveTableMenu, openFileMenu });
            TruthTableDataGrid.ContextMenuStrip = menuStrip;    
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Сохранение изображения таблицы
        /// </summary>
        private void SaveImageTruthTableButton_Click(object sender, EventArgs e)
        {
            SaveTable.SaveImageTable(TruthTableDataGrid, "Таблица истинности", TruthTableDataGrid_CellPainting);
        }


    }
}
