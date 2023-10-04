using System;
using System.IO;
using System.Text.Json;

namespace WebcamQuickProfiles.Configuration.Settings
{
    public class SettingsService
    {
        private Settings Settings { get; set; }

        public Settings GetSettings()
        {
            if (Settings == null)
            {
                LoadSettings();
            }

            return Settings;
        }

        public void UpdateCurrentProfileId(Guid profileId)
        {
            Settings.CurrentProfileId = profileId;
            SaveSettings(Settings);
        }

        public void UpdateAutomaticProfile(bool automaticProfile)
        {
            Settings.AutomaticProfile = automaticProfile;
            SaveSettings(Settings);
        }

        private void LoadSettings()
        {
            if (File.Exists(Paths.SettingsFilePath))
            {
                string json = File.ReadAllText(Paths.SettingsFilePath);
                Settings = JsonSerializer.Deserialize<Settings>(json);

                return;
            }

            Settings = new Settings();
        }

        private void SaveSettings(Settings settings)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(settings, jsonOptions);
            File.WriteAllText(Paths.SettingsFilePath, json);
            Settings = settings;
        }
    }
}
