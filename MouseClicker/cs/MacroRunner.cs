namespace MouseClicker.cs
{
    public class MacroRunner
    {
        //Allows to check the state of this runner
        public bool isRunning { get; private set; }

        //Macro currently loaded in this runner that will be executed when requested
        private Macro loadedMacro;
        //Thread executing loaded macro, might be null if no execution is in progress
        private Task? macroExecutionTask;
        //Handler of mouse inputs
        private MouseHandler mouseHandler;
        //Handler of keyboard inputs
        private KeyboardHandler keyboardHandler;
        //Mutex to synchronize threads
        private object mutex;

        public MacroRunner()
        {
            this.loadedMacro = new Macro();
            this.mouseHandler = new MouseHandler();
            this.keyboardHandler = new KeyboardHandler();
            mutex = new object();

            //Instantly spawn a thread that checks for S key presses, to stop running macros when requested
            Task.Run(GrabSKeyPresses);
        }

        /// <summary>
        /// Loads a new macro in this runner.
        /// Can not load a new macro while there is an ongoing macro execution
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if load succeeds, otherwise <see langword="false"/>
        /// </returns>
        public bool LoadNewMacro(Macro macro)
        {
            lock (mutex)
            {
                //If there is no active thread...
                if (macroExecutionTask is null)
                {
                    //... proceed loading the new macro
                    loadedMacro = macro;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Starts executing the loaded macro by spawning a new thread.
        /// If there is a running thread already, this method fails
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if execution starts correctly, otherwise <see langword="false"/>
        /// </returns>
        public bool Start()
        {
            lock(mutex)
            {
                //If there is no running thread...
                if (macroExecutionTask is null)
                {
                    //... and the loaded macro is not null...
                    if (loadedMacro is not null)
                    {
                        //... and the loaded macro has at least one point...
                        if (loadedMacro.GetPoints().Length > 0)
                        {
                            //... start a new thread to execute that macro
                            macroExecutionTask = Task.Run(_Execute);
                            //Set isRunning to true to let this and other classes know the state of macro execution
                            isRunning = true;
                            return true;
                        }
                    }
                    else //In the absurd case where the loaded macro is null, throw an exception
                        throw new NullReferenceException("MacroRunner: no macro loaded");
                }
            }

            return false;
        }

        /// <summary>
        /// Stops executing the loaded macro by killing the active thread
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if execution is active and stops, otherwise <see langword="false"/>
        /// </returns>
        public bool Stop()
        {
            lock(mutex)
            {
                //If the state reports that an execution is happening...
                if (isRunning)
                {
                    //... set the state to stopped
                    isRunning = false;

                    //If there is an active thread running...
                    if (macroExecutionTask is not null)
                    {
                        //... wait for that thread to stop and exit, now that isRunning is false
                        macroExecutionTask.Wait();
                        //Delete the thread reference
                        macroExecutionTask = null;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Executes the loaded macro until stopped
        /// </summary>
        private void _Execute()
        {
            //List of points in the loaded macro
            TimedPoint[] timedPoints;

            lock (mutex)
            {
                //If the loaded macro is null, set the state to stopped and exit
                if (loadedMacro is null)
                {
                    isRunning = false;
                    return;
                }
                    
                //Do the same if the macro is empty
                if (loadedMacro.GetPoints().Length <= 0)
                {
                    isRunning = false;
                    return;
                }
                
                //Otherwise, get all the timed points from the macro
                timedPoints = loadedMacro.GetPoints();
            }

            //Condition that stops the thread if requested
            while(isRunning)
            {
                //For each thread in the array, wait its delay, then click it
                foreach(TimedPoint timedPoint in timedPoints)
                {
                    //Additional check to see if the thread should wait
                    if(isRunning)
                    {
                        Thread.Sleep((int)timedPoint.milliseconds);
                        //Additional check to see if the thread was requested to stop while sleeping
                        if(isRunning)
                            this.mouseHandler.Click(timedPoint.point);
                    }
                }
            }
        }

        /// <summary>
        /// Continuously checks for any S key inputs and stops the running thread if detects any such inputs
        /// </summary>
        private void GrabSKeyPresses()
        {
            //Never stops
            while(true)
            {
                //If S key is pressed, run the Stop method
                if(keyboardHandler.GetSKeyPressed())
                {
                    Stop();
                }
                //Sleep for better performance
                Thread.Sleep(500);
            }
        }
    }
}
