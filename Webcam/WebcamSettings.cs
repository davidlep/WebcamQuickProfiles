using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcamQuickProfiles.AForge;

namespace WebcamQuickProfiles.Webcam
{
    public class WebcamSettings
    {
        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public int Hue { get; set; }
        public int Saturation { get; set; }
        public int Sharpness { get; set; }
        public int Gamma { get; set; }
        public bool ColorEnable { get; set; }
        public int WhiteBalance { get; set; }
        public bool BacklightCompensation { get; set; }
        public int Gain { get; set; }

        public int Pan { get; set; }
        public int Tilt { get; set; }
        public int Roll { get; set; }
        public int Zoom { get; set; }
        public int Exposure { get; set; }
        public int Iris { get; set; }
        public int Focus { get; set; }

        public VideoProcAmpFlags BrightnessControlFlags { get; set; }
        public VideoProcAmpFlags ContrastControlFlags { get; set; }
        public VideoProcAmpFlags HueControlFlags { get; set; }
        public VideoProcAmpFlags SaturationControlFlags { get; set; }
        public VideoProcAmpFlags SharpnessControlFlags { get; set; }
        public VideoProcAmpFlags GammaControlFlags { get; set; }
        public VideoProcAmpFlags ColorEnableControlFlags { get; set; }
        public VideoProcAmpFlags WhiteBalanceControlFlags { get; set; }
        public VideoProcAmpFlags BacklightCompensationControlFlags { get; set; }
        public VideoProcAmpFlags GainControlFlags { get; set; }

        public CameraControlFlags PanControlFlags { get; set; }
        public CameraControlFlags TiltControlFlags { get; set; }
        public CameraControlFlags RollControlFlags { get; set; }
        public CameraControlFlags ZoomControlFlags { get; set; }
        public CameraControlFlags ExposureControlFlags { get; set; }
        public CameraControlFlags IrisControlFlags { get; set; }
        public CameraControlFlags FocusControlFlags { get; set; }
    }
}
