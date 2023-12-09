namespace MouseClicker.cs
{
    public class MacroRunner
    {
        public bool isRunning { get; private set; }

        private Macro loadedMacro;
        private Task? macroExecutionTask;
        private MouseHandler mouseHandler;
        private KeyboardHandler keyboardHandler;
        private object mutex;

        public MacroRunner()
        {
            this.loadedMacro = new Macro();
            this.mouseHandler = new MouseHandler();
            this.keyboardHandler = new KeyboardHandler();
            mutex = new object();

            Task.Run(GrabSKeyPresses);
        }

        public bool LoadNewMacro(Macro macro)
        {
            lock (mutex)
            {
                if (macroExecutionTask is null)
                {
                    loadedMacro = macro;
                    return true;
                }
            }

            return false;
        }

        public void Start()
        {
            lock(mutex)
            {
                if (loadedMacro is not null)
                {
                    macroExecutionTask = Task.Run(_Execute);
                    isRunning = true;
                }
                else
                    throw new NullReferenceException("MacroRunner: no macro loaded");
            }
        }

        public void Stop()
        {
            lock(mutex)
            {
                if (isRunning)
                {
                    isRunning = false;
                    if (macroExecutionTask is not null)
                    {
                        macroExecutionTask.Wait();
                        macroExecutionTask = null;
                    }
                }
            }
        }

        private void _Execute()
        {
            TimedPoint[] timedPoints;

            lock (mutex)
            {
                if (loadedMacro is null)
                {
                    isRunning = false;
                    return;
                }
                    

                if (loadedMacro.GetPoints().Length <= 0)
                {
                    isRunning = false;
                    return;
                }
                    
                timedPoints = loadedMacro.GetPoints();
            }

            while(isRunning)
            {
                foreach(TimedPoint timedPoint in timedPoints)
                {
                    if(isRunning)
                    {
                        Thread.Sleep((int)timedPoint.milliseconds);
                        this.mouseHandler.Click(timedPoint.point);
                    }
                }
            }
        }

        private void GrabSKeyPresses()
        {
            while(true)
            {
                if(keyboardHandler.GetSKeyPressed())
                {
                    Stop();
                }
            }
        }
    }
}
