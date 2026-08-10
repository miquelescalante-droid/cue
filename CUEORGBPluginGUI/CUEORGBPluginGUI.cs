using System.Runtime.Intrinsics.Arm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace CUEORGBPluginGUI
{
    public partial class CUEORGBPluginGUI : Form
    {
        public CUEORGBPluginGUI()
        {
            InitializeComponent();
        }

        private void CUEORGBPluginGUI_Load(object sender, EventArgs e)
        {
            // Check if the plugin is installed and look for paths.
            PathHandler.discoverIcuePath(this);
            PathHandler.discoverOpenRGBPath(this);
            var pluginPath = PathHandler.discoverPluginPath(this);

            if (pluginPath != null)
            {
                pluginStatusText.Text = $"Plugin Status: Installed / NA";
            }
            else
            {
                pluginStatusText.Text = "Plugin Status: Not Installed / Not running";
            }
        }

        public void Log(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Log(message)));
                return;
            }

            string logLine = $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";

            logTxt.AppendText(logLine);
        }


        private void installPluginButton_Click(object sender, EventArgs e)
        {
            // Check if OpenRGB is installed, else download and move it to program files
            // Once ORGB is installed, somehow configure it to autostart while starting the server as well
            // Then install the plugin the the already discovered iCUE path
            // Ask the user to install another plugin in iCUE (pop up looping video). Then put confirm button.
            // Once done, taskkill iCUE
            // Scan devices from openrgb using command
            // Make json config file in the correct format 
            // Start iCUE

            // During all that update progress bar and status label as well as plugin status at the bottom
        }

        private void discoverIcuePath_Click(object sender, EventArgs e)
        {
            string icuePath = PathHandler.discoverIcuePath(this);
            if (icuePath == "0")
            {
                MessageBox.Show("iCUE not found. Please ensure iCUE is installed.");
            }
            else
            {
                icuePathBox.Text = icuePath;
            }
        }

        private async void discoverOrgbPath_Click(object sender, EventArgs e)
        {
            string orgbPath = PathHandler.discoverOpenRGBPath(this);
            if (orgbPath == null)
            {
                var doInstall = MessageBox.Show(
                    "OpenRGB not found. Would you like to download and install it now?",
                    "Install OpenRGB",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (doInstall == DialogResult.Yes)
                {
                    int result = await ORGBinstaller.InstallOrgb(this);


                }

            }
            else
            {
                orgbPathBox.Text = orgbPath;
            }
        }

        private void exportLogButton_Click(object sender, EventArgs e)
        {
            // Check if there is anything to export
            if (string.IsNullOrWhiteSpace(logTxt.Text))
            {
                MessageBox.Show("The log is empty. Nothing to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Log File";
                saveFileDialog.FileName = $"Log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Write all contents to the selected path
                        File.WriteAllText(saveFileDialog.FileName, logTxt.Text);
                        MessageBox.Show("Log exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
