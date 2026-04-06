using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.StaticData
{
    public static class SaveTable
    {
        public static void SaveImageTable(DataGridView dataGrid, string fileName, DataGridViewCellPaintingEventHandler cellPainting)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                DataGridView copyDataGrid = new DataGridView();

                copyDataGrid.ColumnHeadersHeight = dataGrid.ColumnHeadersHeight;
                copyDataGrid.AllowUserToAddRows = false;

                copyDataGrid.CellPainting += cellPainting;

                foreach (DataGridViewColumn gridViewColumn in dataGrid.Columns)
                {
                    copyDataGrid.Columns.Add((DataGridViewColumn)gridViewColumn.Clone());
                }

                foreach (DataGridViewRow dataRow in dataGrid.Rows)
                {
                    if (!dataRow.IsNewRow)
                    {
                        DataGridViewRow dataGridView = (DataGridViewRow)dataRow.Clone();
                        copyDataGrid.Rows.Add(dataGridView);
                    }
                }

                saveFileDialog.FileName = fileName; //имя по умолчанию
                saveFileDialog.DefaultExt = ".png"; //формат по умолчанию
                saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp";
                saveFileDialog.Title = "Сохранить изображение";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    copyDataGrid.RowHeadersWidth = dataGrid.RowHeadersWidth;
                    copyDataGrid.ColumnHeadersVisible = dataGrid.ColumnHeadersVisible;

                    int originalHeight = copyDataGrid.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + copyDataGrid.ColumnHeadersHeight + copyDataGrid.RowCount / 3;
                    int originalWidth = copyDataGrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + copyDataGrid.ColumnCount * 3 + copyDataGrid.RowHeadersWidth;

                    if (copyDataGrid.Controls.OfType<ScrollBar>().Any(s => s is VScrollBar && s.Visible))
                    {
                        originalWidth += 50;
                    }

                    if (copyDataGrid.Controls.OfType<ScrollBar>().Any(s => s is HScrollBar && s.Visible))
                    {
                        originalHeight += 50;
                    }

                    copyDataGrid.Height = originalHeight;
                    copyDataGrid.Width = originalWidth;
                    Bitmap bitmap = new Bitmap(originalWidth, originalHeight);
                    copyDataGrid.DrawToBitmap(bitmap, new Rectangle(0, 0, originalWidth, originalHeight));
                    bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    bitmap.Dispose();
                }
            }
        }
    }
}
