using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebcamQuickProfiles
{
    internal class SettingsProvider
    {
        public static string LocalAppDataFolder => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\WebcamQuickProfiles";
    }
}
