using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestampFormatExample
{
    public class FormatExample
    {
        /// <summary>
        /// 日付フォーマットパターンをファイル出力する。
        /// </summary>
        public void Execute()
        {
            this.OutputStandardFormat();
            this.OutputCustomFormat();
            //this.OutputLocaleFormat();
            //this.OutputTargetCalendar();
            this.OutputTargetCalendarFormat();
            this.OutputHelp();
            this.OutputCultures();
            this.OutputCalendars();
            this.OutputCalendarJP();
        }

        /// <summary>
        /// 標準の日時書式指定文字列パターンを出力する。
        /// </summary>
        public void OutputStandardFormat()
        {
            // 標準の日時書式指定文字列
            // https://msdn.microsoft.com/ja-jp/library/az4se3k1(v=vs.110).aspx
            List<string> standardPattern = new List<string> {
                "d"
                ,"D"
                ,"f"
                ,"F"
                ,"g"
                ,"G"
                ,"m"
                ,"M"
                ,"o"
                ,"O"
                ,"r"
                ,"R"
                ,"s"
                ,"t"
                ,"T"
                ,"u"
                ,"U"
                ,"y"
                ,"Y"
            };
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("StandardPattern.md"))
            {
                sw.WriteLine("# [標準の日時書式指定文字列](https://msdn.microsoft.com/ja-jp/library/az4se3k1\\(v=vs.110\\).aspx)" + Environment.NewLine + Environment.NewLine + new OutputFormat.MarkdownFormater().Format(standardPattern, this.Run));
            }            
        }

        /// <summary>
        /// カスタム日時書式指定文字列パターンを出力する。
        /// </summary>
        public void OutputCustomFormat()
        {
            // カスタム日時書式指定文字列
            // https://msdn.microsoft.com/ja-jp/library/8kb3ddd4(v=vs.110).aspx
            List<string> pattern = new List<string> {
                "\"yyyy-MM-dd HH:mm:ss.ffffff\""
                ,"M月d日(ddd)"
                ,"dddd"
                ,"\"gyyyy M月d日\""
                ,"\"ggyyyy M月d日\""
                ,"\"t hh:mm\""
                ,"\"tt hh:mm\""
                ,"H時m分s秒"
                ,"\"HH:mm:ss K\""
                ,"\"MMM d\""
                ,"\"MMMM d\""
                ,"y/MM/dd"
                ,"yy/MM/dd"
                ,"yyy/MM/dd"
                ,"yyyy/MM/dd"
                ,"yyyyy/MM/dd"
                ,"\"HH:mm:ss z\""
                ,"\"HH:mm:ss zz\""
                ,"\"HH:mm:ss zzz\""
                ,"\"yyyy-MM-dd HH:mm:ss.ffffff\""
                ,@"""%y-%M-%d %H:%m:%s.%f"""
                ,@"""%yyyy-%MM-%dd %HH:%mm:%ss.%ffffff"""
                ,@"""%4y-%2M-%2d %2H:%2m:%2s.%6f"""
                ,@"""\y-\M-\d \H:\m:\s.\f"""
            };
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("CustomPattern.md"))
            {
                sw.WriteLine("# [カスタム日時書式指定文字列](https://msdn.microsoft.com/ja-jp/library/8kb3ddd4\\(v=vs.110\\).aspx)" + Environment.NewLine + Environment.NewLine + new OutputFormat.MarkdownFormater().Format(pattern, this.Run));
            }
        }

        /// <summary>
        /// ロケール設定した日時書式指定文字列"F"のパターンを出力する。
        /// </summary>
        public void OutputLocaleFormat()
        {
            List<string> pattern = new List<string>();
            foreach (var culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                string cultureCode = culture.Name;
                if (String.IsNullOrWhiteSpace(cultureCode)) { continue; }

                foreach (var calendar in culture.OptionalCalendars)
                {
                    pattern.Add("F" + " " + culture.Name + " " + calendar.ToString());
                }
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("LocalePattern.md"))
            {
                sw.WriteLine(@"# 日時書式指定文字列（ロケール）" + Environment.NewLine + Environment.NewLine + new OutputFormat.MarkdownFormater().Format(pattern, this.Run));
            }
        }

        public void OutputTargetCalendar()
        {
            DateTime start = DateTime.Now;
            StringBuilder html = new StringBuilder();
            html.Append("<table border='1'>");
            html.Append("<tr><th>Culture</th><th>OptionalCalendars</th></tr>");

            int count = 0;
            foreach (var culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                if (String.IsNullOrWhiteSpace(culture.Name)) { continue; }
                System.Console.WriteLine(culture.Name);
                System.Diagnostics.Debug.WriteLine(culture.Name);
                for (int i = 0; i < culture.OptionalCalendars.Length; i++ )
                {
                    html.Append("<tr>");
                    if (0 == i)
                    {
                        html.Append("<td rowspan='" 
                            + culture.OptionalCalendars.Length + "'>"
                            + culture.Name
                            + "</td>");
                    }
                    html.Append("<td>"
                        + culture.OptionalCalendars[i].ToString()
                        + "</td>" + "</tr>");
                }
                count += culture.OptionalCalendars.Length;
            }
            html.Append("</table>");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("OptionalCalendars.html"))
            {
                sw.WriteLine(@"<h1>CultureInfo.OptionalCalendars</h1>" 
                    + Environment.NewLine + Environment.NewLine
                    + new OutputFormat.MetaData().FormatHtml(count, start, DateTime.Now)
                    + html.ToString());
            }
        }

        public void OutputTargetCalendarFormat()
        {
            DateTime start = DateTime.Now;
            StringBuilder html = new StringBuilder();
            html.Append("<table border='1'>");
            html.Append("<tr><th>Culture</th><th>OptionalCalendars</th><th>F</th></tr>");

            int count = 0;
            foreach (var culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                if (String.IsNullOrWhiteSpace(culture.Name)) { continue; }
                System.Console.WriteLine(culture.Name);
                System.Diagnostics.Debug.WriteLine(culture.Name);
                for (int i = 0; i < culture.OptionalCalendars.Length; i++)
                {
                    html.Append("<tr>");
                    if (0 == i)
                    {
                        html.Append("<td rowspan='"
                            + culture.OptionalCalendars.Length + "'>"
                            + culture.Name
                            + "</td>");
                    }
                    html.Append("<td>"
                        + culture.OptionalCalendars[i].ToString()
                        + "</td>");
                    html.Append("<td>"
                        + this.Run("F" + " " + culture.Name + " " + culture.OptionalCalendars[i].ToString())
                        + "</td>");
                    html.Append("</tr>");
                }
                count += culture.OptionalCalendars.Length;
            }
            html.Append("</table>");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("OptionalCalendarsFormat.html"))
            {
                sw.WriteLine(@"<h1>CultureInfo.OptionalCalendars Format</h1>"
                    + Environment.NewLine + Environment.NewLine
                    + new OutputFormat.MetaData().FormatHtml(count, start, DateTime.Now) 
                    + html.ToString());
            }
        }

        public void OutputHelp()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Help.txt"))
            {
                sw.WriteLine(this.Run("--help"));
            }
        }

        public void OutputCultures()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Cultures.txt"))
            {
                sw.WriteLine(this.Run("--listup-cultures"));
            }
        }

        public void OutputCalendars()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Calendars.txt"))
            {
                sw.WriteLine(this.Run("--listup-calendars"));
            }
        }

        public void OutputCalendarJP()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("CalendarJP.txt"))
            {
                sw.WriteLine(this.Run("--listup-calendars ja-JP"));
            }
        }

        private string Run(string ArgsStr = null)
        {
            string cmdDir = @"../../../GetTimestamp\bin\Release\";
            //string cmdDir = @"C:\root\pj\Do\cs\GetTimestamp201612110815\GetTimestamp\bin\Debug\";
            string cmdName = @"GetTimestamp.exe";
            string command = System.IO.Path.Combine(cmdDir, cmdName);

            System.Diagnostics.ProcessStartInfo psInfo = new System.Diagnostics.ProcessStartInfo();
            psInfo.FileName = command;
            psInfo.CreateNoWindow = true;
            psInfo.UseShellExecute = false;
            psInfo.RedirectStandardOutput = true;
            if (!String.IsNullOrWhiteSpace(ArgsStr)) { psInfo.Arguments = ArgsStr; }
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psInfo);
            
            string output = p.StandardOutput.ReadToEnd();
            output = output.Replace("\r\r\n", "\n");
            return output;
        }
    }
}
