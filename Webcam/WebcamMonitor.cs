using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace WebcamQuickProfiles.Webcam
{
    internal class WebcamMonitor
    {
        private bool WebcamRunning = false;
        private readonly WebcamService webcamService;

        public WebcamMonitor(WebcamService webcamService)
        {
            this.webcamService = webcamService;
        }

        public async Task MonitorWebRunning()
        {
            while (true)
            {
                await Task.Delay(5 * 1000);

                if (!WebcamRunning && this.webcamService.IsWebcamInUse())
                {
                    WebcamRunning = true;
                    var currentVideoSource = webcamService.GetCurrentVideoSource();
                    webcamService.ApplyWebcamSettings(currentVideoSource, webcamService.SavedSettingsTEMP);
                    continue;
                }

                if (WebcamRunning && !this.webcamService.IsWebcamInUse())
                {
                    WebcamRunning = false;
                    continue;
                }
            }
        }
    }
}
