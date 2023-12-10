using System.Diagnostics;

namespace MouseClicker.cs
{
    public class MacroRecorder
    {
        //List that will hold all points 
        private List<TimedPoint> timedPoints;
        private Task? recordingThread;
        public bool isRecording { get; private set; }

        public MacroRecorder()
        {
            timedPoints = new List<TimedPoint>();
            recordingThread = null;
            isRecording = false;
        }

        /// <summary>
        /// Starts recording a macro, that will be wrapped up and saved when <see cref="StopRecording"/> is called
        /// </summary>
        public void StartRecording()
        {
            //If no thread is running...
            if (recordingThread is null)
            {
                //set isRecording to true
                isRecording = true;
                //and start recording by spawning a new thread
                recordingThread = Task.Run(RecordLeftMouseClickInputs);
            }
        }

        /// <summary>
        /// Stops the ongoing recording of a new macro and returns it if it contains at least one <see cref="TimedPoint"/>
        /// </summary>
        /// <returns>
        /// A <see cref="Macro"/> if it contains at least one point, otherwise null
        /// </returns>
        public Macro? StopRecording()
        {
            //If there is a running recording thread...
            if(recordingThread is not null)
            {
                //set isRecording to false, so that the thread will exit normally
                isRecording = false;
                //Wait for running thread to end, then set its reference to null
                recordingThread.Wait();
                recordingThread = null;

                /*
                 * Remove very first and last points, 
                 * as they are the ones the user added accidentally to start and stop recording
                 */
                if (timedPoints.Count > 1)
                {
                    timedPoints.RemoveAt(0);
                    timedPoints.RemoveAt(timedPoints.Count - 1);
                }
                else
                    return null;

                //New macro, filled later with recorder points
                Macro macro = new Macro();

                //Start adding points only if there is any in the collection
                if (timedPoints.Count > 0)
                {
                    foreach (TimedPoint timedPoint in timedPoints)
                    {
                        macro.AddPoint(timedPoint);
                    }

                    //Clear the collection for the next recording
                    timedPoints.Clear();

                    //Return newly created macro
                    return macro;
                }
                else
                    return null;
            }

            return null;
        }

        /// <summary>
        /// Grabs mouse clicks and saves all cursor positions until interrupted.
        /// </summary>
        private void RecordLeftMouseClickInputs()
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
