using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetTimestamp.Command
{
    public class ListupCulturesCommand : Framework.ICommand
    {
        public void Execute()
        {
            foreach (var c in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                if (String.IsNullOrWhiteSpace(c.Name)) { continue; }
                System.Console.WriteLine(c.Name);
                System.Diagnostics.Debug.WriteLine(c.Name);
            }
        }
    }
}
