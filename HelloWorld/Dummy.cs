using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Dummy
    {

        public string Text { get; set; }
        public int Wiederholung { get; set; }

        public override string ToString()
        {
            string start = string.Empty;
            for (int i = 0; i < Wiederholung; i++)
            {
                start += $"{Text}, ";
            }
            return start;
        }
    }
}
