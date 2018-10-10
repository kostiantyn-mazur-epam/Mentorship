using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEvent
{
    internal class ConsoleEventListener
    {
        internal delegate void ConsoleEventHandler(string message);

        internal event ConsoleEventHandler Quit;

        internal void Raise()
        {
            if (Quit != null)
            {
                Quit("Quit is written in the console");
            }
        }
    }
}
