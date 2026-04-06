using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Logic_Master.Models
{
    public partial class LogicFunction : ICloneable
    {
        public string Title { get; set; } = "LogicFunction"; 

        public const int LIMIT = 10240;
        public const int SPACE = 1;
        public const int FRAME = 10;

        public int[] FFunction { get; set; } = new int[LIMIT];
        public int FPosition;
        public int FPositionOld;
        public int FLength { get; set; }
        public string FSigns;

        public int FPositionError;
        public Error FError;
        public int FData;
        public int FBrackets;
        public int FCountVariable;

        public bool FRepaint;
        public Graphics FField;
        public Bitmap Fbitmap;
        public Color FFieldColor;
        public Rectangle FFieldRect;
        public int FFieldOffset;
        public bool FFieldCursor;
        public int FFontSize; //float

        public Font FFontCurrent;

        public int CountOperation
        {
            get
            {
                return FFunction.Count(f => (ArgumentType)(f >> 8) == ArgumentType.Operation);
            }
        }

        public int NegativeCountFunc
        {
            get
            {
                return FFunction.Count(f => (ArgumentType)(f >> 8) == ArgumentType.NVariable || (ArgumentType)(f >> 8) == ArgumentType.NBracketLeft);
            }
        }


        //LogicFunctionWork File

        public LogicFunction()
        {
            FRepaint = true;
            FPosition = 0;
            FPositionOld = 1;
            FLength = 0; //↓ заменил на букву o)))
            FSigns = " &+⊕→>/o≡←<";
            FPositionError = 0;
            FError = Error.Empty;
            FCountVariable = 0;
            FFieldOffset = FRAME;
            FFontSize = 11;
        }


        public object Clone()
        {
            LogicFunction clone = (LogicFunction)MemberwiseClone();
            if (FFunction != null)
            {
                clone.FFunction = (int[])FFunction.Clone();
            }
            if (Fbitmap != null)
            {
                clone.Fbitmap = new Bitmap(Fbitmap);
            }
            if (FField != null && FField is IDisposable disposable)
            {
                clone.FField = Graphics.FromImage(clone.Fbitmap);
            }
            return clone;
        }

        public bool SaveFunctionJSON(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, options: new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в JSON: {ex.Message}");
                return false;
            }
        }

        public bool LoadFunctionJSON(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Ошибка загрузки JSON: Файла не существует!");
                    return false;
                }
                else
                {
                    string json = File.ReadAllText(filePath);
                    LogicFunction? logicFunction = JsonSerializer.Deserialize<LogicFunction>(json);
                    if (logicFunction == null || logicFunction.Title != "LogicFunction")
                    {
                        MessageBox.Show($"Ошибка загрузки JSON: Неверный формат файла");
                        return false;
                    }
                    if (logicFunction.FLength > 1024)
                    {
                        MessageBox.Show("Ошибка загрузки файла JSON: Длина функции превысила допустимое значение");
                        return false;
                    }
                    Clear();
                    FLength = logicFunction.FLength;
                    FFunction = logicFunction.FFunction;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки файла JSON: {ex.Message}");
                return false;
            }
        }
    }
}
