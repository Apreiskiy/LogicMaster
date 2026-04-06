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
    public partial class TableCoeff : Form
    {

        private List<string> combinations = new List<string>();

        public TableCoeff()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void TableCoeff_Load(object sender, EventArgs e)
        {
            combinations = GenerateCombinations(TruthTableData.CountX);

            CoeffTableDataGrid.RowCount = 1 << TruthTableData.CountX;
            CoeffTableDataGrid.ColumnCount = (1 << TruthTableData.CountX) - 1;
            CoeffTableDataGrid.RowTemplate.Height = 120;
            int width = 30;
            int count = 0;
            CoeffTableDataGrid.RowHeadersWidth = 60 + TruthTableData.CountX * 10;

            foreach (DataGridViewColumn dataGrid in CoeffTableDataGrid.Columns)
            {
                if (count >= TruthTableData.CountX)
                {
                    width += 10;
                    count = 0;
                }
                dataGrid.Width = width;
                count++;
            }
        }
        private void CoeffTableDataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Font font = new Font("Segoe UI Symbol", 12f, FontStyle.Bold);
            Font smallFont = new Font("Segoe UI Symbol", 12f * 6.0f / 12f, FontStyle.Bold);
            //2 - red, 1 - blue, 3 - black

            if (e.CellStyle != null && e.Graphics != null)
            {

                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.CellBounds);

                if (e.RowIndex >= 0 && e.ColumnIndex == -1)
                {
                    string funcIcon = $"𝑓({Convert.ToString(e.RowIndex, 2).PadLeft(TruthTableData.CountX, '0')}) = {Convert.ToInt32(TruthTableData.Table[e.RowIndex])}";
                    SizeF sizeF = e.Graphics.MeasureString(funcIcon, font);
                    float x = e.CellBounds.Left + (e.CellBounds.Width - sizeF.Width) / 2;
                    float y = e.CellBounds.Top + (e.CellBounds.Height - sizeF.Height) / 2;
                    e.Graphics.DrawString(funcIcon, font, Brushes.Black, x, y);

                }
                else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int nColor = MinimizeData.Flags[e.ColumnIndex + 1][MinimizeData.Number(MinimizeData.Coefs[e.ColumnIndex+1], e.RowIndex)];
                    Brush brush;
                    if (nColor == 0)
                    {
                        brush = new SolidBrush(Color.FromArgb(12, 12, 12));
                    }
                    else if (nColor == 1)
                    {
                        brush = new SolidBrush(Color.FromArgb(0, 112, 192));
                    }
                    else
                    {
                        brush = new SolidBrush(Color.FromArgb(131, 60, 11));
                    }
                    string text = "K";

                    int[] vars = new int[TruthTableData.CountX]; 
                    for (int i = 0; i < TruthTableData.CountX; i++)
                    {
                        vars[i] = (e.RowIndex >> (TruthTableData.CountX - 1 - i)) & 1;
                    }
                    string combo = combinations[e.ColumnIndex % combinations.Count]; //нижний индекс
                    string upperIndex = ""; //Верхний индекс
                        foreach (char sy in combo)
                        {
                            upperIndex += vars[int.Parse(sy.ToString()) - 1];
                        }
                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    SizeF indexSize = e.Graphics.MeasureString(combo, smallFont);
                    float x1 = e.CellBounds.Left + (e.CellBounds.Width - (textSize.Width + indexSize.Width)) / 2;
                    float y1 = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, font, brush, x1, y1);
                    x1 += textSize.Width;
                    //y1 -= (textSize.Height +2);
                    e.Graphics.DrawString(upperIndex, smallFont, brush, x1, y1);
                    y1 += (indexSize.Height - 2);
                    e.Graphics.DrawString(combo, smallFont, brush, x1, y1);
                }
                Pen gridPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(gridPen, e.CellBounds);
                e.Handled = true;
            }
        }


        private List<string> GenerateCombinations(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                GenerateCombinationsRecursive("", 0, i, n, result);
            }
            return result;
        }

        private void GenerateCombinationsRecursive(string prefiks, int start, int size, int n, List<string> result)
        {
            if (prefiks.Length == size)
            {
                result.Add(prefiks);
                return;
            }
            for (int i = start; i < n; i++)
            {
                GenerateCombinationsRecursive(prefiks + (i + 1), i + 1, size, n, result);
            }
        }

        private void SaveImageCoeffTableButton_Click(object sender, EventArgs e)
        {
            SaveTable.SaveImageTable(CoeffTableDataGrid, "Таблица коэффициентов", CoeffTableDataGrid_CellPainting);

        }
    }
}
