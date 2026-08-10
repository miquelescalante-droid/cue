namespace CUEORGBPluginGUI
{
    partial class CUEORGBPluginGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabPage = new TabControl();
            MainSubPage = new TabPage();
            generateConfigButton = new Button();
            uninstallPluginButton = new Button();
            installPluginButton = new Button();
            SettingsSubPage = new TabPage();
            selectOrgbPath = new Button();
            discoverOrgbPath = new Button();
            orgbPathLabel = new Label();
            orgbPathBox = new TextBox();
            selectIcuePath = new Button();
            discoverIcuePath = new Button();
            icuePathLabel = new Label();
            icuePathBox = new TextBox();
            LogSubPage = new TabPage();
            exportLogButton = new Button();
            logTxt = new TextBox();
            statusStrip1 = new StatusStrip();
            mainProgressBar = new ToolStripProgressBar();
            currentActionText = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            pluginStatusText = new ToolStripStatusLabel();
            TabPage.SuspendLayout();
            MainSubPage.SuspendLayout();
            SettingsSubPage.SuspendLayout();
            LogSubPage.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TabPage
            // 
            TabPage.Controls.Add(MainSubPage);
            TabPage.Controls.Add(SettingsSubPage);
            TabPage.Controls.Add(LogSubPage);
            TabPage.Location = new Point(10, 9);
            TabPage.Margin = new Padding(3, 2, 3, 2);
            TabPage.Name = "TabPage";
            TabPage.SelectedIndex = 0;
            TabPage.Size = new Size(957, 559);
            TabPage.TabIndex = 0;
            // 
            // MainSubPage
            // 
            MainSubPage.Controls.Add(generateConfigButton);
            MainSubPage.Controls.Add(uninstallPluginButton);
            MainSubPage.Controls.Add(installPluginButton);
            MainSubPage.Location = new Point(4, 24);
            MainSubPage.Margin = new Padding(3, 2, 3, 2);
            MainSubPage.Name = "MainSubPage";
            MainSubPage.Padding = new Padding(3, 2, 3, 2);
            MainSubPage.Size = new Size(949, 531);
            MainSubPage.TabIndex = 0;
            MainSubPage.Text = "Main";
            MainSubPage.UseVisualStyleBackColor = true;
            // 
            // generateConfigButton
            // 
            generateConfigButton.Location = new Point(6, 105);
            generateConfigButton.Margin = new Padding(3, 2, 3, 2);
            generateConfigButton.Name = "generateConfigButton";
            generateConfigButton.Size = new Size(178, 46);
            generateConfigButton.TabIndex = 2;
            generateConfigButton.Text = "(Re)Generate json from ORGB devices";
            generateConfigButton.UseVisualStyleBackColor = true;
            // 
            // uninstallPluginButton
            // 
            uninstallPluginButton.Location = new Point(5, 54);
            uninstallPluginButton.Margin = new Padding(3, 2, 3, 2);
            uninstallPluginButton.Name = "uninstallPluginButton";
            uninstallPluginButton.Size = new Size(178, 46);
            uninstallPluginButton.TabIndex = 1;
            uninstallPluginButton.Text = "Uninstall Plugin";
            uninstallPluginButton.UseVisualStyleBackColor = true;
            // 
            // installPluginButton
            // 
            installPluginButton.Location = new Point(5, 4);
            installPluginButton.Margin = new Padding(3, 2, 3, 2);
            installPluginButton.Name = "installPluginButton";
            installPluginButton.Size = new Size(178, 46);
            installPluginButton.TabIndex = 0;
            installPluginButton.Text = "(Re)Install Plugin";
            installPluginButton.UseVisualStyleBackColor = true;
            installPluginButton.Click += installPluginButton_Click;
            // 
            // SettingsSubPage
            // 
            SettingsSubPage.Controls.Add(selectOrgbPath);
            SettingsSubPage.Controls.Add(discoverOrgbPath);
            SettingsSubPage.Controls.Add(orgbPathLabel);
            SettingsSubPage.Controls.Add(orgbPathBox);
            SettingsSubPage.Controls.Add(selectIcuePath);
            SettingsSubPage.Controls.Add(discoverIcuePath);
            SettingsSubPage.Controls.Add(icuePathLabel);
            SettingsSubPage.Controls.Add(icuePathBox);
            SettingsSubPage.Location = new Point(4, 24);
            SettingsSubPage.Margin = new Padding(3, 2, 3, 2);
            SettingsSubPage.Name = "SettingsSubPage";
            SettingsSubPage.Padding = new Padding(3, 2, 3, 2);
            SettingsSubPage.Size = new Size(949, 531);
            SettingsSubPage.TabIndex = 2;
            SettingsSubPage.Text = "Settings";
            SettingsSubPage.UseVisualStyleBackColor = true;
            // 
            // selectOrgbPath
            // 
            selectOrgbPath.Location = new Point(696, 36);
            selectOrgbPath.Name = "selectOrgbPath";
            selectOrgbPath.Size = new Size(83, 23);
            selectOrgbPath.TabIndex = 7;
            selectOrgbPath.Text = "Select Path";
            selectOrgbPath.UseVisualStyleBackColor = true;
            // 
            // discoverOrgbPath
            // 
            discoverOrgbPath.Location = new Point(607, 36);
            discoverOrgbPath.Name = "discoverOrgbPath";
            discoverOrgbPath.Size = new Size(83, 23);
            discoverOrgbPath.TabIndex = 6;
            discoverOrgbPath.Text = "Discover";
            discoverOrgbPath.UseVisualStyleBackColor = true;
            discoverOrgbPath.Click += discoverOrgbPath_Click;
            // 
            // orgbPathLabel
            // 
            orgbPathLabel.AutoSize = true;
            orgbPathLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            orgbPathLabel.Location = new Point(6, 36);
            orgbPathLabel.Name = "orgbPathLabel";
            orgbPathLabel.Size = new Size(105, 20);
            orgbPathLabel.TabIndex = 5;
            orgbPathLabel.Text = "OpenRGB Path";
            // 
            // orgbPathBox
            // 
            orgbPathBox.Location = new Point(127, 36);
            orgbPathBox.Name = "orgbPathBox";
            orgbPathBox.ReadOnly = true;
            orgbPathBox.Size = new Size(474, 23);
            orgbPathBox.TabIndex = 4;
            // 
            // selectIcuePath
            // 
            selectIcuePath.Location = new Point(696, 7);
            selectIcuePath.Name = "selectIcuePath";
            selectIcuePath.Size = new Size(83, 23);
            selectIcuePath.TabIndex = 3;
            selectIcuePath.Text = "Select Path";
            selectIcuePath.UseVisualStyleBackColor = true;
            // 
            // discoverIcuePath
            // 
            discoverIcuePath.Location = new Point(607, 7);
            discoverIcuePath.Name = "discoverIcuePath";
            discoverIcuePath.Size = new Size(83, 23);
            discoverIcuePath.TabIndex = 2;
            discoverIcuePath.Text = "Discover";
            discoverIcuePath.UseVisualStyleBackColor = true;
            discoverIcuePath.Click += discoverIcuePath_Click;
            // 
            // icuePathLabel
            // 
            icuePathLabel.AutoSize = true;
            icuePathLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            icuePathLabel.Location = new Point(6, 7);
            icuePathLabel.Name = "icuePathLabel";
            icuePathLabel.Size = new Size(72, 20);
            icuePathLabel.TabIndex = 1;
            icuePathLabel.Text = "iCUE Path";
            // 
            // icuePathBox
            // 
            icuePathBox.Location = new Point(127, 7);
            icuePathBox.Name = "icuePathBox";
            icuePathBox.ReadOnly = true;
            icuePathBox.Size = new Size(474, 23);
            icuePathBox.TabIndex = 0;
            // 
            // LogSubPage
            // 
            LogSubPage.Controls.Add(exportLogButton);
            LogSubPage.Controls.Add(logTxt);
            LogSubPage.Location = new Point(4, 24);
            LogSubPage.Margin = new Padding(3, 2, 3, 2);
            LogSubPage.Name = "LogSubPage";
            LogSubPage.Padding = new Padding(3, 2, 3, 2);
            LogSubPage.Size = new Size(949, 531);
            LogSubPage.TabIndex = 1;
            LogSubPage.Text = "Log";
            LogSubPage.UseVisualStyleBackColor = true;
            // 
            // exportLogButton
            // 
            exportLogButton.Location = new Point(304, 495);
            exportLogButton.Margin = new Padding(3, 2, 3, 2);
            exportLogButton.Name = "exportLogButton";
            exportLogButton.Size = new Size(341, 32);
            exportLogButton.TabIndex = 1;
            exportLogButton.Text = "Export Log";
            exportLogButton.UseVisualStyleBackColor = true;
            exportLogButton.Click += exportLogButton_Click;
            // 
            // logTxt
            // 
            logTxt.Location = new Point(5, 4);
            logTxt.Margin = new Padding(3, 2, 3, 2);
            logTxt.Multiline = true;
            logTxt.Name = "logTxt";
            logTxt.ReadOnly = true;
            logTxt.ScrollBars = ScrollBars.Vertical;
            logTxt.Size = new Size(938, 487);
            logTxt.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { mainProgressBar, currentActionText, toolStripStatusLabel2, pluginStatusText });
            statusStrip1.Location = new Point(0, 564);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(967, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // mainProgressBar
            // 
            mainProgressBar.Name = "mainProgressBar";
            mainProgressBar.Size = new Size(262, 16);
            // 
            // currentActionText
            // 
            currentActionText.Name = "currentActionText";
            currentActionText.Size = new Size(120, 17);
            currentActionText.Text = "Current Action: None";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(205, 17);
            toolStripStatusLabel2.Text = "                                                                  ";
            // 
            // pluginStatusText
            // 
            pluginStatusText.Name = "pluginStatusText";
            pluginStatusText.Overflow = ToolStripItemOverflow.Never;
            pluginStatusText.Size = new Size(127, 17);
            pluginStatusText.Text = "Plugin Status: NA / NA";
            // 
            // CUEORGBPluginGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 586);
            Controls.Add(statusStrip1);
            Controls.Add(TabPage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "CUEORGBPluginGUI";
            Text = "CUEORGBPluginGUI";
            Load += CUEORGBPluginGUI_Load;
            TabPage.ResumeLayout(false);
            MainSubPage.ResumeLayout(false);
            SettingsSubPage.ResumeLayout(false);
            SettingsSubPage.PerformLayout();
            LogSubPage.ResumeLayout(false);
            LogSubPage.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TabPage;
        private TabPage MainSubPage;
        private TabPage LogSubPage;
        private TabPage SettingsSubPage;
        private Button installPluginButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel pluginStatusText;
        private Button uninstallPluginButton;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button exportLogButton;
        private Button discoverIcuePath;
        private Label icuePathLabel;
        private Button selectOrgbPath;
        private Button discoverOrgbPath;
        private Label orgbPathLabel;
        private Button selectIcuePath;
        private Button generateConfigButton;
        public TextBox icuePathBox;
        public TextBox orgbPathBox;
        public ToolStripProgressBar mainProgressBar;
        public ToolStripStatusLabel currentActionText;
        public TextBox logTxt;
    }
}
