using Newtonsoft.Json; //Install from NuGet

namespace MouseClicker.cs
{
    public class Macro
    {
        //File name, comprehensive of path
        public string name;
        //Macro points
        private List<TimedPoint> points;

        public Macro()
        {
            this.name = "";
            this.points = new List<TimedPoint>();
        }


        /// <param name="name">Path to the file containing the macro to/from which save/load it</param>
        public Macro(string name)
        {
            this.name = name;
            this.points = new List<TimedPoint>();
        }

        /// <summary>
        /// Adds a new <see cref="TimedPoint"/> to this macro
        /// </summary>
        /// <param name="point">Coordinates of the new point to add</param>
        /// <param name="millisecondsFromPreviousPoint">Time in milliseconds to wait before clicking this new point</param>
        public void AddPoint(Point point, long millisecondsFromPreviousPoint)
        {
            TimedPoint timedPoint;
            timedPoint.point = point;
            timedPoint.milliseconds = millisecondsFromPreviousPoint;

            this.points.Add(timedPoint);
        }

        /// <summary>
        /// Adds a new <see cref="TimedPoint"/> to this macro
        /// </summary>
        /// <param name="timedPoint">A <see cref="TimedPoint"/> containing coordinates to click and a delay in milliseconds, to add to this macro</param>
        public void AddPoint(TimedPoint timedPoint)
        {
            this.points.Add(timedPoint);
        }

        /// <summary>
        /// Returns an array containing all <see cref="TimedPoint"/>s in this macro
        /// </summary>
        /// <param name="point">Coordinates of the new point to add</param>
        /// <param name="millisecondsFromPreviousPoint">Time in milliseconds to wait before clicking this new point</param>
        /// <returns>
        /// A <see cref="TimedPoint"/> array containing all <see cref="TimedPoint"/>s in this macro
        /// </returns>
        public TimedPoint[] GetPoints()
        {
            return this.points.ToArray();
        }

        /// <summary>
        /// Returns a JSON representation of this macro
        /// </summary>
        /// <returns>
        /// A beautyfied <see cref="string"/> containing this macro in JSON format
        /// </returns>
        public string ToJSON()
        {
            //Using JSON.NET (Newtonsoft.Net)
            return JsonConvert.SerializeObject(points, Formatting.Indented);
        }

        /// <summary>
        /// Overwrites this macro with one read from a JSON string
        /// </summary>
        /// <param name="jsonString">A <see cref="string"/> containing the macro data to load, as JSON format</param>
        /// <returns>
        /// <see langword="true"/> if macro has been loaded correctly, otherwise <see langword="false"/>
        /// </returns>
        public bool LoadFromJSON(string jsonString)
        {
            try
            {
                if (jsonString is not null)
                {
                    //Checking first if points have been loaded correctly
                    TimedPoint[]? points = JsonConvert.DeserializeObject<TimedPoint[]>(jsonString);
                    if (points is not null)
                    {
                        //Then adding them to the actual macro collection
                        this.points = points.ToList<TimedPoint>();

                        //Return true if succeeded
                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Overridden method, returning a fancy representation of this macro
        /// </summary>
        /// <returns>
        /// A formatted <see cref="string"/> representing this macro
        /// </returns>
        public override string ToString()
        {
            string macroDesc = "";

            if(this.points.Count > 0)
            {
                macroDesc += "-------------------------\n";
                int i = 1;

                foreach (TimedPoint timedPoint in this.points)
                {

                    macroDesc += "Point " + i++ + "\n";
                    macroDesc += "X: " + timedPoint.point.X + " - Y: " + timedPoint.point.Y + "\n";
                    macroDesc += "Delay: " + timedPoint.milliseconds + " milliseconds" + "\n";
                    macroDesc += "-------------------------\n";
                }
            }

            return macroDesc;
        }
    }
}
