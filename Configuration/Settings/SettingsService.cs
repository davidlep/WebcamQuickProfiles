using System;
using System.IO;
using System.Text.Json;

namespace WebcamQuickProfiles.Configuration.Settings
{
    public class SettingsService
    {
        private Settings settings = new Settings();

        public Settings GetSettings()
        {
            return settings;
        }

        public void LoadSettings()
        {
            if (File.Exists(Paths.SettingsFilePath))
            {
                string json = File.ReadAllText(Paths.SettingsFilePath);
                settings = JsonSerializer.Deserialize<Settings>(json);
            }
        }

        public void SaveSettings(Settings settings)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(Paths.SettingsFilePath, json);
            this.settings = settings;
        }

        public void UpdateCurrentProfileId(Guid profileId)
        {
            settings.CurrentProfileId = profileId;
            SaveSettings(settings);
        }
    }
}
