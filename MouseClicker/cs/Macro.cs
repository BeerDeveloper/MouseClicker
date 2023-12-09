using Newtonsoft.Json;

namespace MouseClicker.cs
{
    public class Macro
    {
        public string name { get; private set; }
        private List<TimedPoint> points;

        public Macro()
        {
            this.name = "NewMacro";
            this.points = new List<TimedPoint>();
        }

        public Macro(string name)
        {
            string cleanedName = StringCleaner.CleanString(name);

            if (cleanedName != "")
                this.name = cleanedName;
            else
                this.name = "NewMacro";

            this.points = new List<TimedPoint>();
        }

        public void AddPoint(Point point, long millisecondsFromPreviousPoint)
        {
            TimedPoint timedPoint;
            timedPoint.point = point;
            timedPoint.milliseconds = millisecondsFromPreviousPoint;

            this.points.Add(timedPoint);
        }

        public void AddPoint(TimedPoint timedPoint)
        {
            this.points.Add(timedPoint);
        }

        public TimedPoint[] GetPoints()
        {
            return this.points.ToArray();
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(points);
        }

        public bool LoadFromJSON(string jsonString)
        {
            try
            {
                if (jsonString is not null)
                {
                    TimedPoint[]? points = JsonConvert.DeserializeObject<TimedPoint[]>(jsonString);
                    if (points is not null)
                    {
                        this.points = points.ToList<TimedPoint>();
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
    }
}
