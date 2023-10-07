using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace WebcamQuickProfiles
{
    public class VersionService
    {
        private readonly IMemoryCache memoryCache;

        public VersionService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public async Task<bool> IsNewReleaseAvailable()
        {
            var release = await GetLatestRelease();

            if (release is null)
                return false;

            return
                release.TagName != GetCurrentVersion();
        }

        public string GetCurrentVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public async Task<Release> GetLatestRelease()
        {
            if (memoryCache.TryGetValue("LatestRelease", out Release latestRelease))
            {
                return latestRelease;
            }

            var client = new GitHubClient(new ProductHeaderValue("WebcamQuickProfiles"));

            try
            {
                latestRelease = (await client.Repository.Release.GetAll("davidlep", "WebcamQuickProfiles"))[0];
            }
            catch (NotFoundException)
            {
                latestRelease = null;
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            };

            memoryCache.Set("LatestRelease", latestRelease, cacheEntryOptions);

            return latestRelease;
        }
    }
}
