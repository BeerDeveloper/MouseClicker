using System.Diagnostics;

namespace MouseClicker.cs
{
    public class MacroRecorder
    {
        private List<TimedPoint> timedPoints;
        private Task? recordingThread;
        public bool isRecording { get; private set; }

        public MacroRecorder()
        {
            timedPoints = new List<TimedPoint>();
            recordingThread = null;
            isRecording = false;
        }

        public void StartRecording()
        {
            if (recordingThread is null)
            {
                isRecording = true;
                recordingThread = Task.Run(RecordLeftMouseClickInputs);
            }
        }

        public Macro? StopRecording()
        {
            if(recordingThread is not null)
            {
                isRecording = false;
                recordingThread.Wait();
                recordingThread = null;

                Macro macro = new Macro();

                if (timedPoints.Count > 1)
                {
                    timedPoints.RemoveAt(0);
                    timedPoints.RemoveAt(timedPoints.Count - 1);
                }
                else
                    return null;

                if (timedPoints.Count > 0)
                {
                    foreach (TimedPoint timedPoint in timedPoints)
                    {
                        macro.AddPoint(timedPoint);
                    }

                    timedPoints.Clear();

                    return macro;
                }
                else
                    return null;
            }

            return null;
        }

        public void RecordLeftMouseClickInputs()
        {
            MouseHandler mouseHandler = new MouseHandler();
            Stopwatch stopwatch = new Stopwatch();
            long elapsedTime = 0;

            stopwatch.Start();

            while (isRecording)
            {
                if (mouseHandler.GetLeftMousePressed())
                {
                    stopwatch.Stop();

                    elapsedTime = stopwatch.ElapsedMilliseconds;
                    stopwatch.Reset();

                    TimedPoint timedPoint;
                    timedPoint.point = mouseHandler.GetCursorPosition();
                    timedPoint.milliseconds = elapsedTime;

                    this.timedPoints.Add(timedPoint);

                    stopwatch.Start();
                }
            }
        }
    }
}
