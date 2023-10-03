using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WebcamQuickProfiles.Configuration.Profiles
{
    public class ProfilesService
    {
        public void SaveProfile(Profile profile)
        {
            Directory.CreateDirectory(Paths.ProfilesFolderPath);

            var profileFilePath = Path.Combine(Paths.ProfilesFolderPath, $"{profile.Id}.json");
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(profile, jsonOptions);

            File.WriteAllText(profileFilePath, json);
        }

        public Profile LoadProfile(Guid profileId)
        {
            string profileFilePath = Path.Combine(Paths.ProfilesFolderPath, $"{profileId}.json");

            if (File.Exists(profileFilePath))
            {
                var json = File.ReadAllText(profileFilePath);
                return JsonSerializer.Deserialize<Profile>(json);
            }

            return null;
        }

        public void DeleteProfile(Guid profileId)
        {
            string profileFilePath = Path.Combine(Paths.ProfilesFolderPath, $"{profileId}.json");

            if (File.Exists(profileFilePath))
            {
                File.Delete(profileFilePath);
            }
        }

        public IList<ProfileEntry> GetAllProfileEntries()
        {
            if (!Directory.Exists(Paths.ProfilesFolderPath))
            {
                return null;
            }

            var profileEntries = new List<ProfileEntry>();

            string[] profileFiles = Directory.GetFiles(Paths.ProfilesFolderPath, "*.json");

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
