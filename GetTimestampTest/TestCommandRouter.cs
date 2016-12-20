using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GetTimestampTest
{
    [TestFixture]
    public class TestCommandRouter
    {
        //
        // 正常系
        //

        [Test]
        public void TestDefault()
        {
            Assert.IsInstanceOf<GetTimestamp.Command.DefaultCommand>((GetTimestamp.Command.DefaultCommand)new GetTimestamp.CommandRouter().Route(new string[] { }));
        }
        [Test, TestCaseSource(typeof(HelpTestCaseSource), "Cases")]
        public void TestHelp(string args)
        {
            Assert.IsInstanceOf<GetTimestamp.Command.HelpCommand>(
                (GetTimestamp.Command.HelpCommand)new GetTimestamp.CommandRouter().Route(new string[] { args }));
        }

        [Test, TestCaseSource(typeof(ListupCulturesTestCaseSource), "Cases")]
        public void TestListupCultures(string args)
        {
            Assert.IsInstanceOf<GetTimestamp.Command.ListupCulturesCommand>(
                (GetTimestamp.Command.ListupCulturesCommand)new GetTimestamp.CommandRouter().Route(new string[] { args }));
        }
        
        [Test, TestCaseSource(typeof(ListupCalendarsTestCaseSource), "Cases")]
        public void TestListupCalendars(string args)
        {
            Assert.IsInstanceOf<GetTimestamp.Command.ListupCalendarsCommand>(
                (GetTimestamp.Command.ListupCalendarsCommand)new GetTimestamp.CommandRouter().Route(new string[] { args }));
        }

        [Test, TestCaseSource(typeof(ListupCalendarsTestCaseSource), "Cases")]
        public void TestTargetCalendar(string args)
        {
            Assert.IsInstanceOf<GetTimestamp.Command.TargetCalendarCommand>(
                (GetTimestamp.Command.TargetCalendarCommand)new GetTimestamp.CommandRouter().Route(new string[] { args, "ja_JP" }));
        }

        //
        // 異常系
        //
        [Test]
        public void TestInvalidBy1Augs()
        {
            Assert.IsInstanceOf<GetTimestamp.Command.FormatCommand>((GetTimestamp.Command.FormatCommand)new GetTimestamp.CommandRouter().Route(new string[] { "ThisIsInvalidCommand." }));
        }

        [Test]
        public void TestInvalidBy2Augs()
        {
            Assert.IsInstanceOf<GetTimestamp.Command.HelpCommand>((GetTimestamp.Command.HelpCommand)new GetTimestamp.CommandRouter().Route(new string[] { "ThisIsInvalidCommand.", "ThisIsInvalidCommand." }));
        }

        [Test]
        public void TestInvalidBy2AugsForCalendar()
        {
            Assert.IsInstanceOf<GetTimestamp.Command.TargetCalendarCommand>((GetTimestamp.Command.TargetCalendarCommand)new GetTimestamp.CommandRouter().Route(new string[] { "--listup-calendars", "ThisIsInvalidCulture." }));
        }

        [Test]
        public void TestInvalidBy3AugsForCalendar()
        {
            Assert.IsInstanceOf<GetTimestamp.Command.LocaleFormatCommand>((GetTimestamp.Command.LocaleFormatCommand)new GetTimestamp.CommandRouter().Route(new string[] { "ThisIsInvalidCommand.", "ThisIsInvalidCommand.", "ThisIsInvalidCommand." }));
        }
    }
    class HelpTestCaseSource
    {
        public static List<string> Cases = new List<string> { "?", "-?", "/?", "-h", "--help", "/h", "/help", "-H", "--HELP", "/H", "/HELP", "--Help", "/Help" };
    }
    class ListupCulturesTestCaseSource
    {
        public static List<string> Cases = new List<string> { "--listup-cultures", "--cultures", "--LISTUP-CULTURES", "--CULTURES", "--Listup-Cultures", "--Cultures" };
    }
    class ListupCalendarsTestCaseSource
    {
        public static List<string> Cases = new List<string> { "--listup-calendars", "--calendars", "--LISTUP-CALENDARS", "--CALENDARS", "--Listup-Calendars", "--Calendars" };
    }
}
