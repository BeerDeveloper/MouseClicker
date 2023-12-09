using MouseClicker.cs;
using System.ComponentModel;
using System.Diagnostics;

namespace MouseClicker
{
    public partial class Form1 : Form
    {
        private List<TimedPoint> clickedPoints;
        private object mutex;

        public Form1()
        {
            InitializeComponent();

            clickedPoints = new List<TimedPoint>();
            mutex = new object();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            RefreshListButton.Click += onListRefreshButtonPressed;

            Task.Run(getClickedPoints);

            //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

            //backgroundWorker1.RunWorkerAsync();
        }

        private Point getClickedPoints()
        {
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

                    lock (mutex)
                    {
                        TimedPoint timedPoint;
                        timedPoint.point = mouseHandler.GetCursorPosition();
                        timedPoint.milliseconds = elapsedTime;
                        
                        clickedPoints.Add(timedPoint);
                    }

                    stopwatch.Start();
                }
            }
        }

        private void onListRefreshButtonPressed(object sender, System.EventArgs e)
        {
            Macro macro = new Macro();

            lock (mutex)
            {
                foreach (TimedPoint point in clickedPoints)
                {
                    macro.AddPoint(point);
                }

                string macroName;

                if ((macroName = MacroManager.SaveMacroToFile(macro)) != "")
                    OutputTextBox.Text = "Saved macro " + macroName ;
                else
                    OutputTextBox.Text = "Failed to save macro";

                clickedPoints.Clear();
            }

            OutputTextBox.Refresh();
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