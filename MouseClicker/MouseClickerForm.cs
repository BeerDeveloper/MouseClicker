using MouseClicker.cs;
using System.ComponentModel;

namespace MouseClicker
{
    public partial class MouseClickerForm : Form
    {
        private MacroRecorder macroRecorder;
        private MacroRunner macroRunner;

        public MouseClickerForm()
        {
            InitializeComponent();

            macroRecorder = new MacroRecorder();
            macroRunner = new MacroRunner();

            StartMacroButton.Click += OnStartMacroButtonPressed;
            StopMacroButton.Click += OnStopMacroButtonPressed;
            RecordMacroButton.Click += OnRecordMacroButtonPressed;
            BrowseButton.Click += OnBrowseButtonClick;
        }

        private void OnStartMacroButtonPressed(object sender, System.EventArgs e)
        {
            if (!macroRecorder.isRecording)
            {
                if (macroRunner.Start())
                    Log("Macro has started looping: you can stop it by either clicking on Stop Macro or by pressing the S key");
            }
        }

        private void OnStopMacroButtonPressed(object sender, System.EventArgs e)
        {
            macroRunner.Stop();
        }

        private void OnRecordMacroButtonPressed(object sender, System.EventArgs e)
        {
            if (!macroRunner.isRunning)
            {
                if (macroRecorder.isRecording)
                {
                    Macro? macro = macroRecorder.StopRecording();

                    if (macro is not null)
                    {
                        DialogResult dialogResult = SaveMacroDialog.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            string macroName;

                            macroName = SaveMacroDialog.FileName;
                            macro.name = macroName;

                            if ((macroName = MacroFileManager.SaveMacroToFile(macro)) != "")
                            {
                                SetLoadedMacro(macro);
                                Log("Saved macro as " + macroName);
                            }
                            else
                                Log("Macro has been discarded");
                        }
                    }
                    else
                    {
                        Log("Macro is empty");
                    }

                    OutputTextBox.Refresh();
                    RecordMacroButton.Text = "Start recording";
                    RecordOffPicture.Show();
                    RecordOnPicture.Hide();
                }
                else
                {
                    macroRecorder.StartRecording();
                    RecordMacroButton.Text = "Stop recording";
                    RecordOffPicture.Hide();
                    RecordOnPicture.Show();
                }
            }
        }

        private void OnBrowseButtonClick(object sender, System.EventArgs e)
        {
            if (!macroRunner.isRunning && !macroRecorder.isRecording)
            {
                DialogResult dialogResult = LoadMacroDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Macro? macro = MacroFileManager.LoadMacroFromFile(LoadMacroDialog.FileName);

                    if (macro is not null)
                    {
                        SetLoadedMacro(macro);
                        Log("Loaded macro " + macro.name);
                    }
                    else
                    {
                        Log("Unable to load macro");
                    }
                }
            }
        }

        private void SetLoadedMacro(Macro macro)
        {
            this.macroRunner.LoadNewMacro(macro);
            LoadedMacroPathTextBox.Text = macro.name;
            LoadedMacroDataTextBox.Text = macro.ToString();
        }

        public void Log(string message)
        {
            string time = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "]";
            OutputTextBox.Text = time + " - " + message + "\n\n" + OutputTextBox.Text;
        }        
    }
}