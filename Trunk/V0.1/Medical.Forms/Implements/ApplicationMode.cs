using System;

namespace Medical.Forms.Implements
{
    public class ApplicationMode
    {
        public static Boolean IsDebug { get; set; }

        public static void Out(String message, params object[] parameters)
        {
            if (!IsDebug) return;
            Console.WriteLine(message, parameters);
        }
    }
}
