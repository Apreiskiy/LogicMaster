using Logic_Master.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Master.StaticData
{
    public static class ApplicationConfiguration
    {
        public static void Initialize()
        {
            // Устанавливаем режим DPI-Awareness
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Включаем визуальные стили
            Application.EnableVisualStyles();

            // Устанавливаем совместимый рендеринг текста
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
