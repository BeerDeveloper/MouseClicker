namespace MouseClicker.cs
{
    public static class MacroManager
    {
        public static string SaveMacroToFile(Macro macro)
        {
            try
            {
                //Overwrites the file if it already exists, practically updating that macro 
                File.WriteAllText(macro.name, macro.ToJSON());
                return macro.name;
            }
            catch(Exception)
            {
                return "";
            }
        }

        public static Macro? LoadMacroFromFile(string macroName)
        {
            try
            {
                if (File.Exists(macroName))
                {
                    string macroData = File.ReadAllText(macroName);

                    Macro macro = new Macro(macroName);
                    
                    if(macro.LoadFromJSON(macroData))
                        return macro;

                    return null;
                }

                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
