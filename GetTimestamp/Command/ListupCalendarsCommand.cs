using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    /// <summary>
    /// exe --list-calendars
    /// </summary>
    public class ListupCalendarsCommand : Framework.ICommand
    {
        public void Execute()
        {
            this.ListupCurrentCultureCalendars();

            // https://msdn.microsoft.com/ja-jp/library/system.globalization.calendar(v=vs.110).aspx
            List<string> calendarNames = new List<string> {
                "ChineseLunisolarCalendar"
                , "EastAsianLunisolarCalendar"
                , "GregorianCalendar"
                , "HebrewCalendar"
                , "HijriCalendar"
                , "JapaneseCalendar"
                , "JapaneseLunisolarCalendar"
                , "JulianCalendar"
                , "KoreanCalendar"
                , "KoreanLunisolarCalendar"
                , "PersianCalendar"
                , "TaiwanCalendar"
                , "TaiwanLunisolarCalendar"
                , "ThaiBuddhistCalendar"
                , "UmAlQuraCalendar"
            };
            calendarNames.ForEach(n => System.Console.WriteLine("System.Globalization." + n));
        }

        private void ListupCurrentCultureCalendars()
        {
            System.Globalization.CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Console.WriteLine(cc.Name);

            foreach (var c in cc.OptionalCalendars)
            {
                System.Console.WriteLine(c.ToString());
                System.Diagnostics.Debug.WriteLine(c.ToString());
            }
            System.Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
