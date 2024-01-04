namespace MouseClicker.cs
{
    public static class MacroFileManager
    {
        /// <summary>
        /// Saves a macro to file
        /// </summary>
        /// <param name="macro">The macro to save to file</param>
        /// <returns>
        /// The name of the newly created or overwritten file if successful, otherwise an empty string
        /// </returns>
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

        /// <summary>
        /// Loads a macro from file
        /// </summary>
        /// <param name="macroName">The macro file name used to load the macro from</param>
        /// <returns>
        /// A <see cref="Macro"/> containing the instance of the loaded macro if successful, otherwise null
        /// </returns>
        public static Macro? LoadMacroFromFile(string macroName)
        {
            try
            {
                if (File.Exists(macroName))
                {
                    string macroData = File.ReadAllText(macroName);

                    Macro macro = new Macro(macroName);
                    
                    //If the macro has been parsed correctly, return it
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
