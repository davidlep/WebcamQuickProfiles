using System;
using System.IO;
using System.Text.Json;

namespace WebcamQuickProfiles.Configuration.Settings
{
    public class SettingsService
    {
        public Settings Settings { get; private set; }

        public void LoadSettings()
        {
            if (File.Exists(Paths.SettingsFilePath))
            {
                string json = File.ReadAllText(Paths.SettingsFilePath);
                Settings = JsonSerializer.Deserialize<Settings>(json);
                
                return;
            }
                
            Settings = new Settings();
        }

        public void UpdateCurrentProfileId(Guid profileId)
        {
            Settings.CurrentProfileId = profileId;
            SaveSettings(Settings);
        }
        
        private void SaveSettings(Settings settings)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(Paths.SettingsFilePath, json);
            Settings = settings;
        }
    }
}
