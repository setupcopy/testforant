using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticAnts
{
    public enum CompassPointEnum
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
    public class Ant
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CompassPointEnum CompassPoint { get;set;}
        public string Order { get; set; }
    }
}
