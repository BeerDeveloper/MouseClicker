namespace MouseClicker.cs
{
    public static class MacroManager
    {
        private const string macroFormat = ".json";
        private const string macroPath = "macro";

        public static string SaveMacroToFile(Macro macro)
        {
            string macroName;

            macroName = Path.Combine(macroPath, macro.name + macroFormat);

            try
            {
                if (!Directory.Exists(macroPath))
                    Directory.CreateDirectory(macroPath);

                //Overwrites the file if it already exists, practically updating that macro 
                File.WriteAllText(macroName, macro.ToJSON());
                return macroName;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public static Macro loadMacroFromFile(string macroName)
        {
            try
            {
                string fullName = Path.Combine(macroPath, macroName + macroFormat);
                if (File.Exists(fullName))
                {
                    string macroData = File.ReadAllText(fullName);

                    Macro macro = new Macro(macroName);
                    macro.LoadFromJSON(macroData);

                    return macro;
                }

                return new Macro();
            }
            catch(Exception)
            {
                return new Macro();
            }
        }
    }
}
