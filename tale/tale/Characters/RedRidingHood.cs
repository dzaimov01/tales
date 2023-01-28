using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tale.Characters
{
    internal class RedRidingHood
    {
        public Edge Start{ get; set; }
        public Edge End { get; set; }

        public RedRidingHood(Edge start, Edge end)
        {
            this.Start = start;
            this.End = end;
        }


    }
}
