using Logic_Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic_Master.StaticData
{
    public static class TruthTableData
    {
        public static string Title = "TruthTable";
        public static int CountX = 2;
        public static bool[] Table = new bool[512];

        public static bool SaveFunctionJSON(string filePath)
        {
            try
            {
                var dataTable = new { Title = TruthTableData.Title, CountX = TruthTableData.CountX, Table = TruthTableData.Table };
                string json = JsonSerializer.Serialize(dataTable, options: new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в JSON: {ex.Message}");
                return false;
            }
        }

        public static bool LoadFunctionJSON(string filePath)
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
                    var truthTable = JsonSerializer.Deserialize<dynamic>(json);
                    //string title = JsonSerializer.Deserialize<string>(truthTable.Title);
                    JsonDocument document = JsonDocument.Parse(json);
                    JsonElement element = document.RootElement; 

                    if (!element.TryGetProperty("Title", out JsonElement title) || title.GetString()!= "TruthTable")
                    {
                        MessageBox.Show($"Ошибка загрузки JSON: Неверный формат файла");
                        return false;
                    }
                    TruthTableData.CountX = element.GetProperty("CountX").GetInt32();
                    TruthTableData.Table = JsonSerializer.Deserialize<bool[]>(element.GetProperty("Table").GetRawText()); 
                    //TruthTableData.Table = JsonSerializer.Deserialize<bool[]>(truthTable?.Table.ToString());
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
