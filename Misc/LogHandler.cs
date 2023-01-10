using MelonLoader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsingPc.Misc
{
    internal class LogHandler
    {
        public static void Pass(string message)
        {
           MelonLogger.Msg("[Pass] " + message);
        }

        public static void MSG(string message)
        {
            MelonLogger.Msg("[MSG] " + message);
        }

        public static void Alert(string message)
        {
            MelonLogger.Msg("[Alert] " + message);
        }
    }
}
