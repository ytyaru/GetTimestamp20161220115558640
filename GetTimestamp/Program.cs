using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CommandRouter router = new CommandRouter();
            Framework.ICommand cmd = router.Route(args);
            cmd.Execute();
        }
    }
}
