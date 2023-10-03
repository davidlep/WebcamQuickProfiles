using System;
using System.IO;

namespace WebcamQuickProfiles.Configuration
{
    public static class Paths
    {
        public static string LocalAppDataFolder => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\WebcamQuickProfiles";
        public static string ProfilesFolderPath = Path.Combine(LocalAppDataFolder, "Profiles");
        public static string SettingsFilePath = Path.Combine(LocalAppDataFolder, "Settings.json");
    }
}
