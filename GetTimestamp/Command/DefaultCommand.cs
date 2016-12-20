using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class DefaultCommand : GetTimestamp.Framework.ICommand
    {
        public void Execute()
        {
            System.Console.Write(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }
    }
}
