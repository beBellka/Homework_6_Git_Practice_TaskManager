using System;
using System.IO;

namespace TaskTracker.Services
{
    public class ConfigReader
    {
        private string configPath;

        public ConfigReader()
        {
            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "config.txt");
        }

        public string GetMode()
        {
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Файл конфигурации не найден. Используется режим Production.");
                return "Production";
            }

            string[] lines = File.ReadAllLines(configPath);
            if (lines.Length == 0)
            {
                return "Production";
            }

            return lines[0].Trim();
        }

        public bool IsProductionMode()
        {
            return GetMode() == "Production";
        }
    }
}
