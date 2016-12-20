using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestampFormatExample.OutputFormat
{
    class MetaData
    {
        public string FormatMarkdown(int patternNum, DateTime start, DateTime end)
        {
            return "メタ情報" + "|" + "値" + System.Environment.NewLine
                + "--------" + "|" + "--" + System.Environment.NewLine
                + "パターン数" + "|" + patternNum + System.Environment.NewLine
                + "実行時間" + "|" + this.GetTimeSpanFormat(start, end) + System.Environment.NewLine
                + "開始日時" + "|" + start.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
                + "終了日時" + "|" + end.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
                + System.Environment.NewLine
                ;
        }

        public string FormatHtml(int patternNum, DateTime start, DateTime end)
        {
            return "<table>"
                + "<tr>"
                + "<th>" + "メタ情報" + "</th>"
                + "<th>" + "値" + "</th>"
                + "</tr>"
                + "<tr>"
                + "<td>" + "パターン数" + "</td>"
                + "<td>" + patternNum + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td>" + "実行時間" + "</td>"
                + "<td>" + this.GetTimeSpanFormat(start, end) + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td>" + "開始日時" + "</td>"
                + "<td>" + start.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + "</td>"
                + "</tr>"
                + "<tr>"
                + "<td>" + "終了日時" + "</td>"
                + "<td>" + end.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + "</td>"
                + "</tr>"
                + "</table>"
                ;
            //return "メタ情報" + "|" + "値" + System.Environment.NewLine
            //    + "--------" + "|" + "--" + System.Environment.NewLine
            //    + "パターン数" + "|" + patternNum + System.Environment.NewLine
            //    + "実行時間" + "|" + this.GetTimeSpanFormat(start, end) + System.Environment.NewLine
            //    + "開始日時" + "|" + start.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
            //    + "終了日時" + "|" + end.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
            //    + System.Environment.NewLine
            //    ;
        }

        private string GetTimeSpanFormat(DateTime start, DateTime end)
        {
            TimeSpan span = end - start;
            if (span.TotalMilliseconds < 1) { return span.ToString(@"\0\.ffffff\秒"); }
            if (span.TotalSeconds < 1) { return span.ToString(@"\0\.ffffff\秒"); }
            else if (span.TotalMinutes < 1) { return span.ToString(@"ss\.ffffff\秒"); }
            else if (span.TotalHours < 1) { return span.ToString(@"mm\:ss\.ffffff"); }
            else if (span.TotalDays < 1) { return span.ToString(@"hh\:mm\:ss\.ffffff"); }
            else { return span.ToString(@"%d\ \d\a\y\ hh\:mm\:ss\.ffffff"); }
        }
    }
}
