using MouseClicker.cs;
using System.ComponentModel;
using System.Diagnostics;

namespace MouseClicker
{
    public partial class Form1 : Form
    {
        private MacroRecorder macroRecorder;
        private Macro? loadedMacro;

        public Form1()
        {
            InitializeComponent();

            macroRecorder = new MacroRecorder();
            loadedMacro = null;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            RecordMacroButton.Click += OnRecordMacroButtonPressed;
            BrowseButton.Click += OnBrowseButtonClick;

            Task.Run(GetClickedPoints);

            //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

            //backgroundWorker1.RunWorkerAsync();
        }

        private void GetClickedPoints()
        {
            /*
            MouseHandler mouseHandler = new MouseHandler();
            Stopwatch stopwatch = new Stopwatch();
            long elapsedTime = 0;

            stopwatch.Start();

            while (true)
            {
                if (mouseHandler.GetLeftMousePressed())
                {
                    stopwatch.Stop();

                    elapsedTime = stopwatch.ElapsedMilliseconds;
                    stopwatch.Reset();

                    Console.WriteLine(mouseHandler.GetCursorPosition());


                    TimedPoint timedPoint;
                    timedPoint.point = mouseHandler.GetCursorPosition();
                    timedPoint.milliseconds = elapsedTime;

                    stopwatch.Start();
                }
            }*/
        }

        private void OnRecordMacroButtonPressed(object sender, System.EventArgs e)
        {
            if (macroRecorder.isRecording)
            {
                Macro? macro = macroRecorder.StopRecording();

                if (macro is not null)
                {
                    string macroName;

                    SaveMacroDialog.ShowDialog();

                    macroName = SaveMacroDialog.FileName;
                    macro.name = macroName;

                    if ((macroName = MacroManager.SaveMacroToFile(macro)) != "")
                    {
                        loadedMacro = macro;
                        LoadedMacroTextBox.Text = loadedMacro.name;
                        Log("Saved macro as " + macroName);
                    }
                    else
                        Log("Macro has been discarded");
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

        private void OnBrowseButtonClick(object sender, System.EventArgs e)
        {
            LoadMacroDialog.ShowDialog();

            loadedMacro = MacroManager.LoadMacroFromFile(LoadMacroDialog.FileName);

            if (loadedMacro is not null)
            {
                LoadedMacroTextBox.Text = loadedMacro.name;
                Log("Loaded macro " + loadedMacro.name);
            }
            else
            {
                Log("Unable to load macro");
            }
        }

        private void Log(string message)
        {
            OutputTextBox.Text = message + "\n" + OutputTextBox.Text;
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        // This event handler is where the time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            MouseHandler mouseHander = new MouseHandler();
            int i = 1;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //INSERT TIME CONSUMING TASK HERE

                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(10);
                    worker.ReportProgress(i);
                }
            }
        }

        // This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Cancelled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
            */
        }
    }
}