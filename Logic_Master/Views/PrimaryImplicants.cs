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
    public partial class PrimaryImplicants : Form
    {
        public PrimaryImplicants()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void PrimaryImplicantsForm_Load(object sender, EventArgs e)
        {
            PrimaryImplicantsRichTextBox.Text = MinimizeData.Implicants;
        }

        private void SaveTextImageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовой документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить первичные импликанты";
            saveFileDialog.FileName = "Первичные импликанты";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (PrimaryImplicantsRichTextBox != null)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    streamWriter.WriteLine(PrimaryImplicantsRichTextBox.Text);
                    streamWriter.Close();
                }
                else
                {
                    MessageBox.Show("Неизвестная ошибка программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}