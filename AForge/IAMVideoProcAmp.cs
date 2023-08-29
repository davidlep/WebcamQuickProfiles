using System.Runtime.InteropServices;

namespace WebcamQuickProfiles.AForge;
[ComImport, System.Security.SuppressUnmanagedCodeSecurity,
Guid("C6E13360-30AC-11d0-A18C-00A0C9118956"),
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IAMVideoProcAmp
{
    [PreserveSig]
    int GetRange(
        [In] VideoProcAmpProperty Property,
        [Out] out int pMin,
        [Out] out int pMax,
        [Out] out int pSteppingDelta,
        [Out] out int pDefault,
        [Out] out VideoProcAmpFlags pCapsFlags
        );

    [PreserveSig]
    int Set(
        [In] VideoProcAmpProperty Property,
        [In] int lValue,
        [In] VideoProcAmpFlags Flags
        );

    [PreserveSig]
    int Get(
        [In] VideoProcAmpProperty Property,
        [Out] out int lValue,
        [Out] out VideoProcAmpFlags Flags
        );
}