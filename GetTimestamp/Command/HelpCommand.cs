using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class HelpCommand : Framework.ICommand
    {
        public void Execute()
        {
            string exe = System.IO.Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);

            StringBuilder help = new StringBuilder();
            help.Append("usage:");
            help.Append(Environment.NewLine);
            help.Append("  " + exe);
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " [format]");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " [format] [culture] [calendar]");
            help.Append(Environment.NewLine);
            help.Append(Environment.NewLine);
            help.Append("example:");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " --help");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " --listup-cultures");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " --listup-calendars");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " --listup-calendars ja-JP");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " F");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " U");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " yyyyMMddHHmmssffffff");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " yyyy-MM-dd");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " HH:mm:ss.fff");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " dddd");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " \"yyyy-MM-dd HH:mm:ss\"");
            help.Append(Environment.NewLine);
            help.Append("  " + exe + " \"ggyyyy年M月d日 H時m分s秒\" ja-JP System.Globalization.JapaneseCalendar");
            help.Append(Environment.NewLine);
            help.Append(Environment.NewLine);
            help.Append("powered by .NET Framework 4.0 (DateTime, CultureInfo, Calendar ...)");
            help.Append(Environment.NewLine);
            help.Append("format details:");
            help.Append(Environment.NewLine);
            help.Append("https://msdn.microsoft.com/ja-jp/library/az4se3k1(v=vs.110).aspx");
            help.Append(Environment.NewLine);
            help.Append("https://msdn.microsoft.com/ja-jp/library/8kb3ddd4(v=vs.110).aspx");
            help.Append(Environment.NewLine);
            System.Console.WriteLine(help.ToString());
        }
    }
}
