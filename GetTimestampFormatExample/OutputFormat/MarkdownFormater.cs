using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestampFormatExample.OutputFormat
{
    class MarkdownFormater
    {
        public string Format(List<string> pattern, Func<string, string> execute)
        {
            DateTime start = DateTime.Now;
            string patternStr =
                "引数パターン" + "|" + "結果" + System.Environment.NewLine
                + "------------" + "|" + "----" + System.Environment.NewLine;
            pattern.ForEach(p => patternStr += p + "|" + execute(p) + System.Environment.NewLine);
            DateTime end = DateTime.Now;

            string metaStr = "メタ情報" + "|" + "値" + System.Environment.NewLine
                + "--------" + "|" + "--" + System.Environment.NewLine
                + "パターン数" + "|" + pattern.Count() + System.Environment.NewLine
                + "実行時間" + "|" + this.GetTimeSpanFormat(start, end) + System.Environment.NewLine
                + "開始日時" + "|" + start.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
                + "終了日時" + "|" + end.ToString("yyyy-MM-dd HH:mm:ss.ffffff") + System.Environment.NewLine
                + System.Environment.NewLine
                ;
            return metaStr + patternStr;
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
