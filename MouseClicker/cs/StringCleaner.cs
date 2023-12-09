namespace MouseClicker.cs
{
    public static class StringCleaner
    {
        private static string forbidden = "/<>:\"\\|?*";

        public static string CleanString(string stringToClean)
        {
            foreach(char c in forbidden)
            {
                stringToClean.Replace(c.ToString(), "");
            }

            return stringToClean;
        }
    }
}
