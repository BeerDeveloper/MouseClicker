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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            RefreshListButton = new Button();
            OutputTextBox = new TextBox();
            SuspendLayout();
            // 
            // RefreshListButton
            // 
            RefreshListButton.Location = new Point(692, 203);
            RefreshListButton.Name = "RefreshListButton";
            RefreshListButton.Size = new Size(96, 23);
            RefreshListButton.TabIndex = 1;
            RefreshListButton.Text = "RefreshList";
            RefreshListButton.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            OutputTextBox.Location = new Point(12, 12);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.Size = new Size(656, 23);
            OutputTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OutputTextBox);
            Controls.Add(RefreshListButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button RefreshListButton;
        private TextBox OutputTextBox;
    }
}