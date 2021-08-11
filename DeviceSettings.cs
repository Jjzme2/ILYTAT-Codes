using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceSettings
{
    public static DeviceType GetDeviceType => SystemInfo.deviceType;
    public static float GetBatteryLevelPercentage => SystemInfo.batteryLevel * 100;
    public static string GetDeviceModel => SystemInfo.deviceModel;
    public static string GetDeviceUniqueID => SystemInfo.deviceUniqueIdentifier;
    public static float GetScreenWidth => Screen.width;

    public static float GetScreenHeight => Screen.height;
    public static bool SoundEnabled(bool isEnabled)
    {
        return isEnabled;
    }
}
