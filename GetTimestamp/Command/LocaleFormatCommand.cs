using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class LocaleFormatCommand : GetTimestamp.Framework.ICommand
    {
        public void Execute()
        {
            try
            {
                System.Console.Write(
                    DateTime.Now.ToString(
                        System.Environment.GetCommandLineArgs()[1],
                        this.GetCulture()));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
        }

        private System.Globalization.CultureInfo GetCulture()
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(System.Environment.GetCommandLineArgs()[2], true);

            Type t = Type.GetType(System.Environment.GetCommandLineArgs()[3]);
            if (t != null)
            {
                culture.DateTimeFormat.Calendar = (System.Globalization.Calendar)Activator.CreateInstance(t);
            }
            return culture;
        }
    }
}
