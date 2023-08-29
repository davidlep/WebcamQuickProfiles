using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcamQuickProfiles.AForge;

namespace WebcamQuickProfiles
{
    public class WebcamServices
    {
        public IDictionary<string, ExtendedVideoCaptureDevice> VideoSources { get; set; }

        public WebcamServices()
        {
            
        }

        public void Init()
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                throw new Exception("No video devices found.");
            }


            VideoSources = GetVideoSources(videoDevices)
                .ToDictionary(x => x.name, x => x.extendedVideoCaptureDevice);

        }

        private IEnumerable<(string name, ExtendedVideoCaptureDevice extendedVideoCaptureDevice)> GetVideoSources(FilterInfoCollection filterInfoCollection)
        {
            foreach (FilterInfo filterInfo in filterInfoCollection)
                yield return new (filterInfo.Name, new ExtendedVideoCaptureDevice(filterInfo.MonikerString));
        }
    }
}
