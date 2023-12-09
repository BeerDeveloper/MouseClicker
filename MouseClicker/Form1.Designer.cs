namespace MouseClicker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            RecordMacroButton = new Button();
            OutputTextBox = new RichTextBox();
            LoadedMacroTextBox = new TextBox();
            BrowseButton = new Button();
            RecordOffPicture = new PictureBox();
            RecordOnPicture = new PictureBox();
            SaveMacroDialog = new SaveFileDialog();
            LoadMacroDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)RecordOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RecordOnPicture).BeginInit();
            SuspendLayout();
            // 
            // RecordMacroButton
            // 
            RecordMacroButton.Location = new Point(692, 165);
            RecordMacroButton.Name = "RecordMacroButton";
            RecordMacroButton.Size = new Size(96, 23);
            RecordMacroButton.TabIndex = 1;
            RecordMacroButton.Text = "Start recording";
            RecordMacroButton.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = Color.DimGray;
            OutputTextBox.BorderStyle = BorderStyle.FixedSingle;
            OutputTextBox.Cursor = Cursors.IBeam;
            OutputTextBox.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            OutputTextBox.ForeColor = Color.Transparent;
            OutputTextBox.Location = new Point(12, 239);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(776, 199);
            OutputTextBox.TabIndex = 3;
            OutputTextBox.Text = "";
            // 
            // LoadedMacroTextBox
            // 
            LoadedMacroTextBox.BackColor = Color.DimGray;
            LoadedMacroTextBox.BorderStyle = BorderStyle.FixedSingle;
            LoadedMacroTextBox.Cursor = Cursors.IBeam;
            LoadedMacroTextBox.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            LoadedMacroTextBox.ForeColor = Color.Transparent;
            LoadedMacroTextBox.Location = new Point(12, 203);
            LoadedMacroTextBox.Name = "LoadedMacroTextBox";
            LoadedMacroTextBox.ReadOnly = true;
            LoadedMacroTextBox.Size = new Size(674, 23);
            LoadedMacroTextBox.TabIndex = 4;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(692, 203);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(96, 23);
            BrowseButton.TabIndex = 5;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            // 
            // RecordOffPicture
            // 
            RecordOffPicture.BackgroundImageLayout = ImageLayout.Stretch;
            RecordOffPicture.Image = (Image)resources.GetObject("RecordOffPicture.Image");
            RecordOffPicture.InitialImage = (Image)resources.GetObject("RecordOffPicture.InitialImage");
            RecordOffPicture.Location = new Point(661, 165);
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
            RecordOnPicture.Location = new Point(661, 165);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(RecordOnPicture);
            Controls.Add(RecordOffPicture);
            Controls.Add(BrowseButton);
            Controls.Add(LoadedMacroTextBox);
            Controls.Add(OutputTextBox);
            Controls.Add(RecordMacroButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
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
        private TextBox LoadedMacroTextBox;
        private Button BrowseButton;
        private PictureBox RecordOffPicture;
        private PictureBox RecordOnPicture;
        private SaveFileDialog SaveMacroDialog;
        private OpenFileDialog LoadMacroDialog;
    }
}