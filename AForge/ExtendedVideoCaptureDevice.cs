using System;
using System.Reflection;
using System.Runtime.InteropServices;
using AForge.Video.DirectShow;
//Source: https://github.com/andrewkirillov/AForge.NET/pull/27/commits

namespace WebcamQuickProfiles.AForge;
public class ExtendedVideoCaptureDevice : VideoCaptureDevice
{
    private string deviceMoniker;
    private object sync;

    public ExtendedVideoCaptureDevice(string deviceMoniker) : base(deviceMoniker)
    {
        this.deviceMoniker = deviceMoniker;
        var syncType = typeof(VideoCaptureDevice).GetField("sync", BindingFlags.Instance | BindingFlags.NonPublic);
        sync = syncType.GetValue(this);
    }

    /// <summary>
    /// Sets a specified property on the video.
    /// </summary>
    /// 
    /// <param name="property">Specifies the property to set.</param>
    /// <param name="value">Specifies the new value of the property.</param>
    /// <param name="controlFlags">Specifies the desired control setting.</param>
    /// 
    /// <returns>Returns true on sucee or false otherwise.</returns>
    /// 
    /// <exception cref="ArgumentException">Video source is not specified - device moniker is not set.</exception>
    /// <exception cref="ApplicationException">Failed creating device object for moniker.</exception>
    /// <exception cref="NotSupportedException">The video source does not support video control.</exception>
    /// 
    public bool SetVideoProperty(VideoProcAmpProperty property, int value, VideoProcAmpFlags controlFlags)
    {
        bool ret = true;

        // check if source was set
        if ((deviceMoniker == null) || (string.IsNullOrEmpty(deviceMoniker)))
        {
            throw new ArgumentException("Video source is not specified.");
        }

        lock (sync)
        {
            object tempSourceObject = null;

            // create source device's object
            try
            {
                tempSourceObject = FilterInfo.CreateFilter(deviceMoniker);
            }
            catch
            {
                throw new ApplicationException("Failed creating device object for moniker.");
            }

            if (!(tempSourceObject is IAMVideoProcAmp))
            {
                throw new NotSupportedException("The video source does not support video control.");
            }

            IAMVideoProcAmp pCamControl = (IAMVideoProcAmp)tempSourceObject;
            int hr = pCamControl.Set(property, value, controlFlags);

            ret = (hr >= 0);

            Marshal.ReleaseComObject(tempSourceObject);
        }

        return ret;
    }

    /// <summary>
    /// Gets the current setting of a video property.
    /// </summary>
    /// 
    /// <param name="property">Specifies the property to retrieve.</param>
    /// <param name="value">Receives the value of the property.</param>
    /// <param name="controlFlags">Receives the value indicating whether the setting is controlled manually or automatically</param>
    /// 
    /// <returns>Returns true on sucee or false otherwise.</returns>
    /// 
    /// <exception cref="ArgumentException">Video source is not specified - device moniker is not set.</exception>
    /// <exception cref="ApplicationException">Failed creating device object for moniker.</exception>
    /// <exception cref="NotSupportedException">The video source does not support video control.</exception>
    /// 
    public bool GetVideoProperty(VideoProcAmpProperty property, out int value, out VideoProcAmpFlags controlFlags)
    {
        bool ret = true;

        // check if source was set
        if ((deviceMoniker == null) || (string.IsNullOrEmpty(deviceMoniker)))
        {
            throw new ArgumentException("Video source is not specified.");
        }

        lock (sync)
        {
            object tempSourceObject = null;

            // create source device's object
            try
            {
                tempSourceObject = FilterInfo.CreateFilter(deviceMoniker);
            }
            catch
            {
                throw new ApplicationException("Failed creating device object for moniker.");
            }

            if (!(tempSourceObject is IAMVideoProcAmp))
            {
                throw new NotSupportedException("The video source does not support video control.");
            }

            IAMVideoProcAmp pCamControl = (IAMVideoProcAmp)tempSourceObject;
            int hr = pCamControl.Get(property, out value, out controlFlags);

            ret = (hr >= 0);

            Marshal.ReleaseComObject(tempSourceObject);
        }

        return ret;
    }

    /// <summary>
    /// Gets the range and default value of a specified video property.
    /// </summary>
    /// 
    /// <param name="property">Specifies the property to query.</param>
    /// <param name="minValue">Receives the minimum value of the property.</param>
    /// <param name="maxValue">Receives the maximum value of the property.</param>
    /// <param name="stepSize">Receives the step size for the property.</param>
    /// <param name="defaultValue">Receives the default value of the property.</param>
    /// <param name="controlFlags">Receives a member of the <see cref="VideoProcAmpFlags"/> enumeration, indicating whether the property is controlled automatically or manually.</param>
    /// 
    /// <returns>Returns true on sucee or false otherwise.</returns>
    /// 
    /// <exception cref="ArgumentException">Video source is not specified - device moniker is not set.</exception>
    /// <exception cref="ApplicationException">Failed creating device object for moniker.</exception>
    /// <exception cref="NotSupportedException">The video source does not support video control.</exception>
    /// 
    public bool GetVideoPropertyRange(VideoProcAmpProperty property, out int minValue, out int maxValue, out int stepSize, out int defaultValue, out VideoProcAmpFlags controlFlags)
    {
        bool ret = true;

        // check if source was set
        if ((deviceMoniker == null) || (string.IsNullOrEmpty(deviceMoniker)))
        {
            throw new ArgumentException("Video source is not specified.");
        }

        lock (sync)
        {
            object tempSourceObject = null;

            // create source device's object
            try
            {
                tempSourceObject = FilterInfo.CreateFilter(deviceMoniker);
            }
            catch
            {
                throw new ApplicationException("Failed creating device object for moniker.");
            }

            if (!(tempSourceObject is IAMVideoProcAmp))
            {
                throw new NotSupportedException("The video source does not support video control.");
            }

            IAMVideoProcAmp pCamControl = (IAMVideoProcAmp)tempSourceObject;
            int hr = pCamControl.GetRange(property, out minValue, out maxValue, out stepSize, out defaultValue, out controlFlags);

            ret = (hr >= 0);

            Marshal.ReleaseComObject(tempSourceObject);
        }

        return ret;
    }
}