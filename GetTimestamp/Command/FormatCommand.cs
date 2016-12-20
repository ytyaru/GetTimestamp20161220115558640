using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class FormatCommand : GetTimestamp.Framework.ICommand
    {
        public void Execute()
        {
            try
            {
                System.Console.Write(DateTime.Now.ToString(System.Environment.GetCommandLineArgs()[1]));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine(e.StackTrace);
            }
        }
    }
}
