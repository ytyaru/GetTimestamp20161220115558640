using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class TargetCalendarCommand : Framework.ICommand
    {
        public void Execute()
        {
            System.Globalization.CultureInfo culture = null;
            try
            {
                culture = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures).Where(c => c.Name.Equals(System.Environment.GetCommandLineArgs()[2], StringComparison.OrdinalIgnoreCase)).First();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
                return;
            }

            StringBuilder build = new StringBuilder();
            build.Append(culture.Name);
            build.Append(System.Environment.NewLine);
            foreach (var calendar in culture.OptionalCalendars)
            {
                try
                {
                    build.Append(calendar.ToString());
                    build.Append(System.Environment.NewLine);
                }
                catch(Exception e)
                {
                    build.Append(e.Message);
                    build.Append(System.Environment.NewLine);
                    build.Append(e.StackTrace);
                    build.Append(System.Environment.NewLine);
                }
            }
            System.Console.WriteLine(build.ToString());
        }
    }
}
