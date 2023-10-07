using System;
using System.Threading.Tasks;
using WebcamQuickProfiles.Configuration.Settings;
using WebcamQuickProfiles.GUI;

namespace WebcamQuickProfiles.Webcam
{
    internal class WebcamMonitor
    {
        private bool WebcamRunning = false;
        private readonly WebcamService webcamService;
        private readonly SettingsService settingsService;
        private readonly FormsManager formsManager;

        public WebcamMonitor(
            WebcamService webcamService,
            SettingsService settingsService,
            FormsManager formsManager)
        {
            this.webcamService = webcamService;
            this.settingsService = settingsService;
            this.formsManager = formsManager;
        }

        public async Task MonitorWebcamRunning()
        {
            while (true)
            {
                var settings = settingsService.GetSettings();

                await Task.Delay(3 * 1000);

                if (!settings.AutomaticProfile)
                    continue;

                if (!WebcamRunning && this.webcamService.IsWebcamInUse())
                {
                    if (formsManager.IsFormOpen<ProfileEditForm>())
                    {
                        continue;
                    }

                    WebcamRunning = true;
                    ApplyCurrentProfile();

                    continue;
                }

                if (WebcamRunning && !this.webcamService.IsWebcamInUse())
                {
                    WebcamRunning = false;
                    continue;
                }
            }
        }

        private void ApplyCurrentProfile()
        {
            var settings = settingsService.GetSettings();
            webcamService.ApplyProfile(settings.CurrentProfileId);
        }
    }
}
