using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp
{
    /// <summary>
    /// 起動引数を受けて実行するコマンドを決定する。
    /// </summary>
    public class CommandRouter
    {
        public Framework.ICommand Route(string[] args)
        {
            Framework.ICommand cmd = null;
            if (0 == args.Length)
            {
                cmd = new Command.DefaultCommand();
            }
            else if (1 == args.Length)
            {
                cmd = this.GetCommandBy1Augs(args[0]);
            }
            else if (2 == args.Length)
            {
                cmd = this.GetCommandBy2Augs(args);
            }
            else if (3 == args.Length)
            {
                cmd = new Command.LocaleFormatCommand();
            }
            else
            {
                cmd = new Command.HelpCommand();
            }
            return cmd;
        }

        private Framework.ICommand GetCommandBy1Augs(string arg)
        {
            if (this.IsHelp(arg)) { return new Command.HelpCommand(); }
            else if (this.IsListupCulturesRoute(arg)) { return new Command.ListupCulturesCommand(); }
            else if (this.IsListupCalendars(arg)) { return new Command.ListupCalendarsCommand(); }
            else { return new Command.FormatCommand(); }
        }

        private bool IsHelp(string arg)
        {
            return new string[] { "?", "-?", "/?", "-h", "--help", "/h", "/help" }.Any(k => k.Equals(arg, StringComparison.OrdinalIgnoreCase));
        }
        private bool IsListupCulturesRoute(string arg)
        {
            return new string[] { "--listup-cultures", "--cultures" }.Any(k => k.Equals(arg, StringComparison.OrdinalIgnoreCase));
        }
        private bool IsListupCalendars(string arg)
        {
            return new string[] { "--listup-calendars", "--calendars" }.Any(k => k.Equals(arg, StringComparison.OrdinalIgnoreCase));
        }

        private Framework.ICommand GetCommandBy2Augs(string[] args)
        {
            if (IsListupCalendars(args[0])) { return new Command.TargetCalendarCommand(); }
            else { return new Command.HelpCommand(); }
        }
    }
}
