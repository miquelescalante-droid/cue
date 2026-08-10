using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;


namespace CUEORGBPluginGUI
{
    internal static class PathHandler
    {

        public static string discoverIcuePath(CUEORGBPluginGUI gui)
        {

            // usually in C:\Program Files\Corsair\CORSAIR iCUE5 Software\iCUE.exe
            if (System.IO.File.Exists(@"C:\Program Files\Corsair\CORSAIR iCUE5 Software\iCUE.exe"))
            {
                gui.Log("Found iCUE at C:\\Program Files\\Corsair\\CORSAIR iCUE5 Software\\iCUE.exe");
                return "C:\\Program Files\\Corsair\\CORSAIR iCUE5 Software\\iCUE.exe";

            }
            else
            {
                gui.Log("iCUE not found");
                return "0";
            }


        }

        public static string discoverOpenRGBPath(CUEORGBPluginGUI gui)
        {
            // Can be wherever the user installed it
            // If the user lets the app install it, ill put in in program files
            // But we need to check everywhere



            string path = FindOpenRgbInCommonPaths(gui)
                  ?? FindRunningOpenRgbPath(gui)
                  ?? FindOpenRgbFromRegistry(gui);

            return path;
        }

        public static string discoverPluginPath(CUEORGBPluginGUI gui)
        {
            gui.Log("Checking if plugin is installed...");

            if (System.IO.File.Exists(@"C:\Program Files\Corsair\CORSAIR iCUE5 Software\plugins\OpenRGB\CUEORGBPlugin.dll"))
            {
                gui.Log("Found plugin at C:\\Program Files\\Corsair\\CORSAIR iCUE5 Software\\plugins\\OpenRGB\\CUEORGBPlugin.dll");
                return "C:\\Program Files\\Corsair\\CORSAIR iCUE5 Software\\plugins\\OpenRGB\\CUEORGBPlugin.dll";

            }
            else
            {
                gui.Log("Plugin not found");
                return "0";
            }

        }

        public static string FindRunningOpenRgbPath(CUEORGBPluginGUI gui)
        {

            gui.Log("Checking for running OpenRGB process...");
            var processes = Process.GetProcessesByName("OpenRGB");
            if (processes.Length > 0)
            {
                try
                {
                    gui.Log("Found running OpenRGB process at: " + processes[0].MainModule.FileName);
                    return processes[0].MainModule.FileName;
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // Access denied reading MainModule (rare, permissions issue)
                    gui.Log("No running OpenRGB process found or access denied.");
                    return null;
                }
            }
            return null;
        }

        public static string FindOpenRgbFromRegistry(CUEORGBPluginGUI gui)
        {
            string[] uninstallKeys = {
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

            gui.Log("Looking for OpenRGB in the registry...");

            foreach (var keyPath in uninstallKeys)
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    if (key == null) continue;
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            string displayName = subKey?.GetValue("DisplayName") as string;
                            if (displayName != null && displayName.Contains("OpenRGB"))
                            {
                                string installLocation = subKey.GetValue("InstallLocation") as string;
                                if (!string.IsNullOrEmpty(installLocation))
                                {
                                    string exePath = System.IO.Path.Combine(installLocation, "OpenRGB.exe");
                                    if (System.IO.File.Exists(exePath))
                                        gui.Log("OpenRGB found in registry at: " + exePath);
                                    return exePath;
                                }
                            }
                        }
                    }
                }
            }
            gui.Log("Could not find OpenRGB in the registry.");
            return null;
        }

        public static string FindOpenRgbInCommonPaths(CUEORGBPluginGUI gui)
        {
            string[] candidates = {
        @"C:\Program Files\OpenRGB\OpenRGB.exe",
        @"C:\Program Files (x86)\OpenRGB\OpenRGB.exe",
        System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            @"Downloads\OpenRGB\OpenRGB.exe"),
        System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "OpenRGB.exe"),
            };

            gui.Log("Searching for OpenRGB in common paths...");

            foreach (var path in candidates)
            {
                if (System.IO.File.Exists(path))
                {
                    gui.Log("OpenRGB found in common path: " + path);
                    return path;
                }
            }

            gui.Log("OpenRGB not found in common paths.");
                return null;
        }

    }
}
