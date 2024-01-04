namespace MouseClicker
{
    partial class MouseClickerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseClickerForm));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            RecordMacroButton = new Button();
            OutputTextBox = new RichTextBox();
            LoadedMacroPathTextBox = new TextBox();
            BrowseButton = new Button();
            RecordOffPicture = new PictureBox();
            RecordOnPicture = new PictureBox();
            SaveMacroDialog = new SaveFileDialog();
            LoadMacroDialog = new OpenFileDialog();
            LoadedMacroDataTextBox = new RichTextBox();
            StartMacroButton = new Button();
            StopMacroButton = new Button();
            ((System.ComponentModel.ISupportInitialize)RecordOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RecordOnPicture).BeginInit();
            SuspendLayout();
            // 
            // RecordMacroButton
            // 
            RecordMacroButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RecordMacroButton.Location = new Point(48, 181);
            RecordMacroButton.Name = "RecordMacroButton";
            RecordMacroButton.Size = new Size(243, 23);
            RecordMacroButton.TabIndex = 1;
            RecordMacroButton.Text = "Start recording";
            RecordMacroButton.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = Color.DimGray;
            OutputTextBox.BorderStyle = BorderStyle.FixedSingle;
            OutputTextBox.Cursor = Cursors.No;
            OutputTextBox.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            OutputTextBox.ForeColor = Color.Transparent;
            OutputTextBox.Location = new Point(12, 239);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(279, 199);
            OutputTextBox.TabIndex = 3;
            OutputTextBox.Text = "";
            // 
            // LoadedMacroPathTextBox
            // 
            LoadedMacroPathTextBox.BackColor = Color.DimGray;
            LoadedMacroPathTextBox.BorderStyle = BorderStyle.FixedSingle;
            LoadedMacroPathTextBox.Cursor = Cursors.No;
            LoadedMacroPathTextBox.Font = new Font("Consolas", 8F, FontStyle.Bold, GraphicsUnit.Point);
            LoadedMacroPathTextBox.ForeColor = Color.Transparent;
            LoadedMacroPathTextBox.Location = new Point(12, 210);
            LoadedMacroPathTextBox.Name = "LoadedMacroPathTextBox";
            LoadedMacroPathTextBox.ReadOnly = true;
            LoadedMacroPathTextBox.Size = new Size(215, 20);
            LoadedMacroPathTextBox.TabIndex = 4;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(233, 210);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(57, 23);
            BrowseButton.TabIndex = 5;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            // 
            // RecordOffPicture
            // 
            RecordOffPicture.BackgroundImageLayout = ImageLayout.Stretch;
            RecordOffPicture.Image = (Image)resources.GetObject("RecordOffPicture.Image");
            RecordOffPicture.InitialImage = (Image)resources.GetObject("RecordOffPicture.InitialImage");
            RecordOffPicture.Location = new Point(11, 181);
            RecordOffPicture.Name = "RecordOffPicture";
            RecordOffPicture.Size = new Size(25, 23);
            RecordOffPicture.SizeMode = PictureBoxSizeMode.Zoom;
            RecordOffPicture.TabIndex = 6;
            RecordOffPicture.TabStop = false;
            // 
            // RecordOnPicture
            // 
            RecordOnPicture.BackgroundImageLayout = ImageLayout.Stretch;
            RecordOnPicture.Image = (Image)resources.GetObject("RecordOnPicture.Image");
            RecordOnPicture.InitialImage = (Image)resources.GetObject("RecordOnPicture.InitialImage");
            RecordOnPicture.Location = new Point(11, 181);
            RecordOnPicture.Name = "RecordOnPicture";
            RecordOnPicture.Size = new Size(25, 23);
            RecordOnPicture.SizeMode = PictureBoxSizeMode.Zoom;
            RecordOnPicture.TabIndex = 7;
            RecordOnPicture.TabStop = false;
            RecordOnPicture.Visible = false;
            // 
            // SaveMacroDialog
            // 
            SaveMacroDialog.Filter = "MouseClicker macro file|*.mcm";
            SaveMacroDialog.OkRequiresInteraction = true;
            // 
            // LoadMacroDialog
            // 
            LoadMacroDialog.Filter = "MouseClicker macro file|*.mcm";
            LoadMacroDialog.OkRequiresInteraction = true;
            LoadMacroDialog.ShowReadOnly = true;
            // 
            // LoadedMacroDataTextBox
            // 
            LoadedMacroDataTextBox.BackColor = Color.DimGray;
            LoadedMacroDataTextBox.BorderStyle = BorderStyle.FixedSingle;
            LoadedMacroDataTextBox.Cursor = Cursors.No;
            LoadedMacroDataTextBox.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LoadedMacroDataTextBox.ForeColor = Color.Transparent;
            LoadedMacroDataTextBox.Location = new Point(12, 75);
            LoadedMacroDataTextBox.Name = "LoadedMacroDataTextBox";
            LoadedMacroDataTextBox.ReadOnly = true;
            LoadedMacroDataTextBox.Size = new Size(279, 100);
            LoadedMacroDataTextBox.TabIndex = 8;
            LoadedMacroDataTextBox.Text = "";
            // 
            // StartMacroButton
            // 
            StartMacroButton.Location = new Point(12, 12);
            StartMacroButton.Name = "StartMacroButton";
            StartMacroButton.Size = new Size(132, 57);
            StartMacroButton.TabIndex = 9;
            StartMacroButton.Text = "Start Macro";
            StartMacroButton.UseVisualStyleBackColor = true;
            // 
            // StopMacroButton
            // 
            StopMacroButton.Location = new Point(159, 12);
            StopMacroButton.Name = "StopMacroButton";
            StopMacroButton.Size = new Size(132, 57);
            StopMacroButton.TabIndex = 10;
            StopMacroButton.Text = "Stop Macro (S)";
            StopMacroButton.UseVisualStyleBackColor = true;
            // 
            // MouseClickerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(302, 445);
            Controls.Add(StopMacroButton);
            Controls.Add(StartMacroButton);
            Controls.Add(LoadedMacroDataTextBox);
            Controls.Add(RecordOnPicture);
            Controls.Add(RecordOffPicture);
            Controls.Add(BrowseButton);
            Controls.Add(LoadedMacroPathTextBox);
            Controls.Add(OutputTextBox);
            Controls.Add(RecordMacroButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            Name = "MouseClickerForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "MouseClicker";
            ((System.ComponentModel.ISupportInitialize)RecordOffPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)RecordOnPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button RecordMacroButton;
        private RichTextBox OutputTextBox;
        private TextBox LoadedMacroPathTextBox;
        private Button BrowseButton;
        private PictureBox RecordOffPicture;
        private PictureBox RecordOnPicture;
        private SaveFileDialog SaveMacroDialog;
        private OpenFileDialog LoadMacroDialog;
        private RichTextBox LoadedMacroDataTextBox;
        private Button StartMacroButton;
        private Button StopMacroButton;
    }
}