using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Test.Windsor
{
    public class Test: ITest
    {
        public void Speak(string content)
        {
            Console.WriteLine("People said: " + content);
        }
    }
}
