using System.Threading.Tasks;
using WebcamQuickProfiles.GUI;

namespace WebcamQuickProfiles.Webcam
{
    internal class WebcamMonitor
    {
        private bool WebcamRunning = false;
        private readonly WebcamService webcamService;
        private readonly FormsManager formsManager;

        public WebcamMonitor(
            WebcamService webcamService,
            FormsManager formsManager)
        {
            this.webcamService = webcamService;
            this.formsManager = formsManager;
        }

        public async Task MonitorWebcamRunning()
        {
            while (true)
            {
                await Task.Delay(5 * 1000);

                if (!WebcamRunning && this.webcamService.IsWebcamInUse())
                {
                    if (formsManager.IsFormOpen<ProfileEditForm>())
                    {
                        continue;
                    }

                    WebcamRunning = true;
                    //Load profile
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
