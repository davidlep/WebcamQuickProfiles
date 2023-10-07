# Webcam Quick Profiles (for Windows)

Simple application that runs in the background (as a tray application) and enables you to store webcam profiles (presets of webcam settings) and restore them manually or automatically when the webcam is in use. This application solves the issue where modifications made to the webcam's settings are reverted to their default values after each webcam usage.

This app uses the [AForge.NET](https://github.com/andrewkirillov/AForge.NET) library ([with community modifications](https://github.com/andrewkirillov/AForge.NET/pull/27)).

![ConfigUIScreen](https://github.com/davidlep/WebcamQuickProfiles/assets/10562856/7ca2aa33-9fb9-434a-a94b-37f7a84d3c21)


## Functionalities

When you start the application, it will continue the run in the background. You can access the functionalities of the application by right clicking the related menu in the tray notification of Windows.

![TrayIconScreen](https://github.com/davidlep/WebcamQuickProfiles/assets/10562856/ddbf0ce9-a0c5-4a45-84f0-a74f72f21ab5)

### Profiles
The Profiles option enables you to select an active profile. Selecting a profile instantly restore the related webcam settings, you've configured (in the Configure option). If the option to automatically restore an active profile was selected in the configuration menu, the selected active profile will be restored automatically each time the webcam is in use.

### Configure
The Configure option opens the configuration menu where you can configure new and existing profiles. 
On the profile selection dialog, you can use the 🎥 button to open the Windows Camera app, and then click on "Edit Webcam Settings," to have visual feedback of your changes.
