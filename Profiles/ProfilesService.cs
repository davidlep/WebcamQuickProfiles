using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WebcamQuickProfiles.Profiles;

namespace WebcamQuickProfiles.Configuration
{
    public class ProfilesService
    {
        public static string LocalAppDataFolder => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\WebcamQuickProfiles";
        public static string ProfilesFolderPath = Path.Combine(LocalAppDataFolder, "Profiles");

        public void SaveProfile(Profile profile)
        {
            Directory.CreateDirectory(ProfilesFolderPath);

            var profileFilePath = Path.Combine(ProfilesFolderPath, $"{profile.Id}.json");
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(profile, jsonOptions);

            File.WriteAllText(profileFilePath, json);
        }

        public Profile LoadProfile(Guid profileId)
        {
            string profileFilePath = Path.Combine(ProfilesFolderPath, $"{profileId}.json");

            if (File.Exists(profileFilePath))
            {
                var json = File.ReadAllText(profileFilePath);
                return JsonSerializer.Deserialize<Profile>(json);
            }

            return null;
        }

        public IList<ProfileEntry> GetAllProfileEntries()
        {
            if (!Directory.Exists(ProfilesFolderPath))
            {
                return null;
            }

            var profileEntries = new List<ProfileEntry>();

            string[] profileFiles = Directory.GetFiles(ProfilesFolderPath, "*.json");

            foreach (string profileFile in profileFiles)
            {
                var json = File.ReadAllText(profileFile);
                var profileEntry = JsonSerializer.Deserialize<ProfileEntry>(json);
                profileEntries.Add(profileEntry);
            }

            return profileEntries;
        }
    }
}
