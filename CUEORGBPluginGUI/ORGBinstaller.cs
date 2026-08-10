using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;


namespace CUEORGBPluginGUI
{
    internal class ORGBinstaller
    {

        public static async Task<int> InstallOrgb(CUEORGBPluginGUI gui)    
        {
            try
            {
                gui.currentActionText.Text = "Current Action: Downloading OpenRGB...";
                gui.Log("Downloading OpenRGB installer...");

                var progress = new Progress<int>(percent =>
                {
                    gui.mainProgressBar.Value = (int)(percent * 0.4);
                    gui.currentActionText.Text = $"Current Action: Downloading OpenRGB... {percent}%";
                });

                string msiPath = await ORGBinstaller.DownloadOpenRgbInstallerAsync(progress);

                await Task.Delay(100);

                gui.mainProgressBar.Value = 40;
                gui.currentActionText.Text = "Current Action: Launching installer...";
                gui.Log("Current Action: Launching OpenRGB installer...");

                ORGBinstaller.RunInstaller(msiPath);

                return 0;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Download failed: {ex.Message}");
                gui.currentActionText.Text = "Download of ORGB failed.";
                gui.Log("Download of OpenRGB failed: " + ex.Message);

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
                gui.currentActionText.Text = "Error installing ORGB.";
                gui.Log("Unexpected error while downloading OpenRGB: " + ex.Message);

                return 1;
            }

        }

        public static void RunInstaller(string msiPath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "msiexec.exe",
                Arguments = $"/i \"{msiPath}\" /qn /norestart",
                UseShellExecute = true, // required for UAC prompt to appear
                Verb = "runas"
            };

            using (Process process = Process.Start(psi))
            {
                if (process != null)
                {
                    process.WaitForExit();
                }
            }

            Process.Start(psi);
        }

        public static async Task<string> DownloadOpenRgbInstallerAsync(IProgress<int> progress)
        {
            string url = "https://codeberg.org/OpenRGB/OpenRGB/releases/download/release_candidate_1.0rc3/OpenRGB_1.0rc3_Windows_64_6fbcf62.msi";
            string tempPath = Path.Combine(Path.GetTempPath(), "OpenRGB_Installer.msi");

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                long? totalBytes = response.Content.Headers.ContentLength;
                long downloadedBytes = 0;

                using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        downloadedBytes += bytesRead;

                        if (totalBytes.HasValue)
                        {
                            int percent = (int)((downloadedBytes * 100) / totalBytes.Value);
                            progress?.Report(percent);
                        }
                    }
                }
            }

            return tempPath;
        }
    }
}
