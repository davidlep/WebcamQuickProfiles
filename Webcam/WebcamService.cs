using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcamQuickProfiles.AForge;
using WebcamQuickProfiles.Configuration.Profiles;

namespace WebcamQuickProfiles.Webcam
{
    public class WebcamService
    {
        private readonly ProfilesService profilesService;
        public IDictionary<string, ExtendedVideoCaptureDevice> VideoSources { get; set; }

        public WebcamService(ProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }

        public void Init()
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)
            {
                VideoSources = new Dictionary<string, ExtendedVideoCaptureDevice>();
                return;
            }

            VideoSources = GetVideoSources(videoDevices)
                .Where(x => x.extendedVideoCaptureDevice.VideoCapabilities.Any())
                .ToDictionary(x => x.name, x => x.extendedVideoCaptureDevice);

        }

        public WebcamSettings GetWebcamSettings(ExtendedVideoCaptureDevice videoSource)
        {
            var profile = new WebcamSettings();

            foreach (CameraControlProperty property in Enum.GetValues(typeof(CameraControlProperty)))
            {
                if (videoSource.GetCameraProperty(property, out int value, out CameraControlFlags flags))
                {
                    SetWebcamSettingValue(profile, property, value, flags);
                }
            }

            foreach (VideoProcAmpProperty property in Enum.GetValues(typeof(VideoProcAmpProperty)))
            {
                if (videoSource.GetVideoProperty(property, out int value, out VideoProcAmpFlags flags))
                {
                    SetWebcamSettingValue(profile, property, value, flags);
                }
            }

            return profile;
        }

        public void ApplyProfile(Guid profileId)
        {
            var profile = profilesService.LoadProfile(profileId);

            if (profile is null)
                return;

            var videoSource = this.VideoSources[profile.VideoSourceId];
            this.ApplyWebcamSettings(videoSource, profile.WebcamSettings);
        }

        public void ApplyWebcamSettings(ExtendedVideoCaptureDevice videoSource, WebcamSettings settings)
        {
            foreach (CameraControlProperty property in Enum.GetValues(typeof(CameraControlProperty)))
            {
                SetCameraProperty(videoSource, settings, property);
            }

            foreach (VideoProcAmpProperty property in Enum.GetValues(typeof(VideoProcAmpProperty)))
            {
                SetVideoProcAmpProperty(videoSource, settings, property);
            }
        }

        private void SetWebcamSettingValue(WebcamSettings webcamSettings, CameraControlProperty property, int value, CameraControlFlags flags)
        {
            switch (property)
            {
                case CameraControlProperty.Pan:
                    webcamSettings.Pan = value;
                    webcamSettings.PanControlFlags = flags;
                    break;
                case CameraControlProperty.Tilt:
                    webcamSettings.Tilt = value;
                    webcamSettings.TiltControlFlags = flags;
                    break;
                case CameraControlProperty.Roll:
                    webcamSettings.Roll = value;
                    webcamSettings.RollControlFlags = flags;
                    break;
                case CameraControlProperty.Zoom:
                    webcamSettings.Zoom = value;
                    webcamSettings.ZoomControlFlags = flags;
                    break;
                case CameraControlProperty.Exposure:
                    webcamSettings.Exposure = value;
                    webcamSettings.ExposureControlFlags = flags;
                    break;
                case CameraControlProperty.Iris:
                    webcamSettings.Iris = value;
                    webcamSettings.IrisControlFlags = flags;
                    break;
                case CameraControlProperty.Focus:
                    webcamSettings.Focus = value;
                    webcamSettings.FocusControlFlags = flags;
                    break;
                default:
                    break;
            }
        }

        private void SetWebcamSettingValue(WebcamSettings webcamSettings, VideoProcAmpProperty property, int value, VideoProcAmpFlags flags)
        {
            switch (property)
            {
                case VideoProcAmpProperty.Brightness:
                    webcamSettings.Brightness = value;
                    webcamSettings.BrightnessControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Contrast:
                    webcamSettings.Contrast = value;
                    webcamSettings.ContrastControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Hue:
                    webcamSettings.Hue = value;
                    webcamSettings.HueControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Saturation:
                    webcamSettings.Saturation = value;
                    webcamSettings.SaturationControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Sharpness:
                    webcamSettings.Sharpness = value;
                    webcamSettings.SharpnessControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Gamma:
                    webcamSettings.Gamma = value;
                    webcamSettings.GammaControlFlags = flags;
                    break;
                case VideoProcAmpProperty.ColorEnable:
                    webcamSettings.ColorEnable = value != 0;
                    webcamSettings.ColorEnableControlFlags = flags;
                    break;
                case VideoProcAmpProperty.WhiteBalance:
                    webcamSettings.WhiteBalance = value;
                    webcamSettings.WhiteBalanceControlFlags = flags;
                    break;
                case VideoProcAmpProperty.BacklightCompensation:
                    webcamSettings.BacklightCompensation = value != 0;
                    webcamSettings.BacklightCompensationControlFlags = flags;
                    break;
                case VideoProcAmpProperty.Gain:
                    webcamSettings.Gain = value;
                    webcamSettings.GainControlFlags = flags;
                    break;
                default:
                    break;
            }
        }

        private void SetCameraProperty(ExtendedVideoCaptureDevice videoSource, WebcamSettings settings, CameraControlProperty property)
        {
            int value;
            CameraControlFlags flags;

            switch (property)
            {
                case CameraControlProperty.Pan:
                    value = settings.Pan;
                    flags = settings.PanControlFlags;
                    break;
                case CameraControlProperty.Tilt:
                    value = settings.Tilt;
                    flags = settings.TiltControlFlags;
                    break;
                case CameraControlProperty.Roll:
                    value = settings.Roll;
                    flags = settings.RollControlFlags;
                    break;
                case CameraControlProperty.Zoom:
                    value = settings.Zoom;
                    flags = settings.ZoomControlFlags;
                    break;
                case CameraControlProperty.Exposure:
                    value = settings.Exposure;
                    flags = settings.ExposureControlFlags;
                    break;
                case CameraControlProperty.Iris:
                    value = settings.Iris;
                    flags = settings.IrisControlFlags;
                    break;
                case CameraControlProperty.Focus:
                    value = settings.Focus;
                    flags = settings.FocusControlFlags;
                    break;
                default:
                    return;
            }

            videoSource.SetCameraProperty(property, value, flags);
        }

        private void SetVideoProcAmpProperty(ExtendedVideoCaptureDevice videoSource, WebcamSettings settings, VideoProcAmpProperty property)
        {
            int value;
            VideoProcAmpFlags flags;

            switch (property)
            {
                case VideoProcAmpProperty.Brightness:
                    value = settings.Brightness;
                    flags = settings.BrightnessControlFlags;
                    break;
                case VideoProcAmpProperty.Contrast:
                    value = settings.Contrast;
                    flags = settings.ContrastControlFlags;
                    break;
                case VideoProcAmpProperty.Hue:
                    value = settings.Hue;
                    flags = settings.HueControlFlags;
                    break;
                case VideoProcAmpProperty.Saturation:
                    value = settings.Saturation;
                    flags = settings.SaturationControlFlags;
                    break;
                case VideoProcAmpProperty.Sharpness:
                    value = settings.Sharpness;
                    flags = settings.SharpnessControlFlags;
                    break;
                case VideoProcAmpProperty.Gamma:
                    value = settings.Gamma;
                    flags = settings.GammaControlFlags;
                    break;
                case VideoProcAmpProperty.ColorEnable:
                    value = settings.ColorEnable ? 1 : 0;
                    flags = settings.ColorEnableControlFlags;
                    break;
                case VideoProcAmpProperty.WhiteBalance:
                    value = settings.WhiteBalance;
                    flags = settings.WhiteBalanceControlFlags;
                    break;
                case VideoProcAmpProperty.BacklightCompensation:
                    value = settings.BacklightCompensation ? 1 : 0;
                    flags = settings.BacklightCompensationControlFlags;
                    break;
                case VideoProcAmpProperty.Gain:
                    value = settings.Gain;
                    flags = settings.GainControlFlags;
                    break;
                default:
                    return;
            }

            videoSource.SetVideoProperty(property, value, flags);
        }

        private IEnumerable<(string name, ExtendedVideoCaptureDevice extendedVideoCaptureDevice)> GetVideoSources(FilterInfoCollection filterInfoCollection)
        {
            foreach (FilterInfo filterInfo in filterInfoCollection)
                yield return new(filterInfo.Name, new ExtendedVideoCaptureDevice(filterInfo.MonikerString));
        }

        public bool IsWebcamInUse()
        {
            //https://stackoverflow.com/questions/63650097/get-current-state-of-webcam-in-c-sharp

            return IsWebcamInUse(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam") ||
                    IsWebcamInUse(@"SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam\NonPackaged");
        }

        private bool IsWebcamInUse(string registryPath)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(registryPath))
            {
                foreach (var subKeyName in key.GetSubKeyNames())
                {
                    using (var subKey = key.OpenSubKey(subKeyName))
                    {
                        if (subKey.GetValueNames().Contains("LastUsedTimeStop"))
                        {
                            var endTime = subKey.GetValue("LastUsedTimeStop") is long ? (long)subKey.GetValue("LastUsedTimeStop") : -1;
                            if (endTime <= 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
