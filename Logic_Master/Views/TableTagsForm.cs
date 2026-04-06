using Logic_Master.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic_Master.Views
{
    //Рисование таблицы меток
    public partial class TableTagsForm : Form
    {
        public TableTagsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void TableTagsForm_Load(object sender, EventArgs e)
        {
            SetMetki();
            TableTagsDataGrid.RowCount = MinimizeData.ImplsCount;
            TableTagsDataGrid.ColumnCount = MinimizeData.AllCount;
            TableTagsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            TableTagsDataGrid.ColumnHeadersHeight = TruthTableData.CountX * 20;
            TableTagsDataGrid.RowHeadersWidth = TruthTableData.CountX * 20;
            TableTagsDataGrid.RowTemplate.Height = 30;
            foreach (DataGridViewColumn dataColumn in TableTagsDataGrid.Columns)
            {
                dataColumn.Width = 30;   
            }
        }

        private void SetMetki()
        {
            int i;
            int j;
            int k;
            int m;
            int n;
            int y = 0;

            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                MinimizeData.ImplsM[i] = 2;
            }
            for (i = 0; i < MinimizeData.AllCount; i++)
            {
                MinimizeData.AllM[i] = 2;
            }

            for (j = 0; j < MinimizeData.AllCount; j++)
            {
                k = 0;

                for (i = 0; i < MinimizeData.ImplsCount; i++)
                {
                    if (Enter(MinimizeData.Impls[i], MinimizeData.All[j]))
                    {
                        k++;
                        if (k == 1)
                        {
                            y = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (k == 1)
                {
                    MinimizeData.ImplsM[y] = 0;
                }
            }

            for (i = 0; i < MinimizeData.ImplsCount; i++)
            {
                for (j = 0; j < MinimizeData.AllCount; j++)
                {
                    if (MinimizeData.ImplsM[i] == 0 && Enter(MinimizeData.Impls[i], MinimizeData.All[j]))
                    {
                        MinimizeData.AllM[j] = 0;
                    }
                }
            }

            while (true)
            {
                n = 0;
                m = 0;
                y = -1;
                for (i = 0; i < MinimizeData.ImplsCount; i++)
                {
                    if (MinimizeData.ImplsM[i] == 2)
                    {
                        k = 0;
                        for (j = 0; j < MinimizeData.AllCount; j++)
                        {
                            if (MinimizeData.AllM[j] == 2 && Enter(MinimizeData.Impls[i], MinimizeData.All[j]))
                            {
                                k++;
                            }
                        }
                        if (k == n && k != 0 && MinimizeData.Kol(MinimizeData.Impls[i] >> 16) > m)
                        {
                            m = MinimizeData.Kol(MinimizeData.Impls[i] >> 16);
                            y = i;
                        }
                        else if (k > n)
                        {
                            n = k;
                            m = MinimizeData.Kol(MinimizeData.Impls[i] >> 16);
                            y = i;
                        }
                    }
                }

                if (y == -1)
                {
                    break;
                }
                MinimizeData.ImplsM[y] = 1;

                for (i = 0; i < MinimizeData.AllCount; i++)
                {
                    if (MinimizeData.AllM[i] == 2 && Enter(MinimizeData.Impls[y], MinimizeData.All[i]))
                    {
                        MinimizeData.AllM[i] = 1;
                    }
                }
            }
        }

        private bool Enter(int a, int b)
        {
            return ((b & ~(a >> 16)) == (a & 0xFFFF));
        }

        private void TableTagsDataGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Font font = new Font("Segoe UI Symbol", 11f);
            if (e.CellStyle != null && e.Graphics != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.CellBounds);
                if (e.RowIndex >= 0 && e.ColumnIndex == -1)
                {
                    string text = "";

                    for (int j = TruthTableData.CountX - 1; j >= 0; j--)
                    {
                        if ((MinimizeData.Impls[e.RowIndex] & 0xFFFF & 1 << j) != 0)
                        {
                            text += "1";
                        }
                        else if (((MinimizeData.Impls[e.RowIndex] >> 16) & (1 << j)) != 0) 
                        {
                            text += "-";
                        }
                        else
                        {
                            text += "0";
                        }
                    }
                    Brush textBrush;


                    if (MinimizeData.ImplsM[e.RowIndex] == 0)
                    {
                        textBrush = new SolidBrush(Color.FromArgb(255, 255, 0));
                    }
                    else if (MinimizeData.ImplsM[e.RowIndex] == 1)
                    {
                        textBrush = new SolidBrush(Color.FromArgb(0, 112, 192));
                    }
                    else if (MinimizeData.ImplsM[e.RowIndex] == 2)
                    {
                        textBrush = new SolidBrush(Color.FromArgb(12, 12, 12));
                    }
                    else
                    {
                        textBrush = new SolidBrush(Color.FromArgb(131, 60, 11));
                    }

                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    float textX = e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2;
                    float textY = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, font, textBrush, textX, textY);             
                }
                else if (e.RowIndex == -1 && e.ColumnIndex >= 0)
                {
                    string text = "";

                    for (int j = TruthTableData.CountX - 1; j >= 0; j--)
                    {
                        if ((MinimizeData.All[e.ColumnIndex] & 0xFFFF & (1 << j)) != 0)
                        {
                            text += "1";
                        }
                        else
                        {
                            text += "0";
                        }
                    }
                    Brush textBrush = new SolidBrush(Color.Yellow);

                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    float centerX = e.CellBounds.Left + e.CellBounds.Width / 2;
                    float centerY = e.ClipBounds.Top + e.CellBounds.Height / 2;
                    GraphicsState graphicsState = e.Graphics.Save();
                    e.Graphics.TranslateTransform(centerX, centerY);
                    e.Graphics.RotateTransform(-90f);
                    float textX = -textSize.Width / 2;
                    float textY = -textSize.Height / 2;
                    e.Graphics.DrawString(text, font, textBrush, textX, textY);
                    e.Graphics.Restore(graphicsState);
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    Console.WriteLine(TableTagsDataGrid.Columns[0].Width);
                    Console.WriteLine(TableTagsDataGrid.Rows[0].Height);

                    //если 0 - желтая метка
                    //1 blue
                    //если 2 - черная метка
                    //3 red
                    if (Enter(MinimizeData.Impls[e.RowIndex], MinimizeData.All[e.ColumnIndex]))
                    {
                        Bitmap metka;


                        if (MinimizeData.ImplsM[e.RowIndex] == 0)
                        {
                            metka = Properties.Resources.YellowImp;
                        }
                        else if (MinimizeData.ImplsM[e.RowIndex] == 1)
                        {
                            metka = Properties.Resources.BlueImp;
                        }
                        else if (MinimizeData.ImplsM[e.RowIndex] == 2)
                        {
                            metka = Properties.Resources.BlackImp;
                        }
                        else
                        {
                            metka = Properties.Resources.RedImp;
                        }
                        float metkaX = e.CellBounds.Left + (e.CellBounds.Width - metka.Width) / 2;
                        float metkaY = e.CellBounds.Top + (e.CellBounds.Height - metka.Height) / 2;
                        e.Graphics.DrawImage(metka, metkaX, metkaY, 20, 20);
                    }
                }

                Pen gridPen = new Pen(Color.Black);
                e.Graphics.DrawRectangle(gridPen, e.CellBounds);
                e.Handled = true;
            }
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            SaveTable.SaveImageTable(TableTagsDataGrid, "Таблица меток", TableTagsDataGrid_CellPainting);
        }
    }
}
