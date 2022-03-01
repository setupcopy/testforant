using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticAnts
{
    public class AntNavigation
    {
        private int _boundX;
        private int _boundY;
        public AntNavigation(int boundX,int boundY)
        {
            _boundX = boundX;
            _boundY = boundY;
        }

        public bool ExecuteOrder (Ant ant)
        {
            string str = ant.Order;
            for (int i = 0;i < str.Length;i ++) 
            {
                if (!str[i].ToString().Equals("m",StringComparison.InvariantCultureIgnoreCase))// if order is left or right
                {
                    //Do spin
                    Spin(ant,str[i].ToString());
                }
                else  //if order is move
                {
                    //Move forward
                    Move(ant);

                    //Over the bound
                    if (ant.X > _boundX || ant.X < 0 || 
                        ant.Y > _boundY || ant.Y < 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Spin(Ant ant,string direction)
        {
            switch (ant.CompassPoint)
            {
                case CompassPointEnum.North:
                    {
                        if (direction.Equals("l"))
                        {
                            ant.CompassPoint = CompassPointEnum.West;
                        }
                        else if (direction.Equals("r"))
                        {
                            ant.CompassPoint = CompassPointEnum.East;
                        }
                        break;
                    }
                case CompassPointEnum.East:
                    {
                        if (direction.Equals("l"))
                        {
                            ant.CompassPoint = CompassPointEnum.North;
                        }
                        else if (direction.Equals("r"))
                        {
                            ant.CompassPoint = CompassPointEnum.South;
                        }
                        break;
                    }
                case CompassPointEnum.South:
                    {
                        if (direction.Equals("l"))
                        {
                            ant.CompassPoint = CompassPointEnum.East;
                        }
                        else if (direction.Equals("r"))
                        {
                            ant.CompassPoint = CompassPointEnum.West;
                        }
                        break;
                    }
                case CompassPointEnum.West:
                    {
                        if (direction.Equals("l"))
                        {
                            ant.CompassPoint = CompassPointEnum.South;
                        }
                        else if (direction.Equals("r"))
                        {
                            ant.CompassPoint = CompassPointEnum.North;
                        }
                        break;
                    }
            }
        }

        private void Move(Ant ant)
        {
            switch (ant.CompassPoint)
            {
                case CompassPointEnum.North:
                    ant.Y ++;
                    break;
                case CompassPointEnum.East:
                    ant.X++;
                    break;
                case CompassPointEnum.South:
                    ant.Y --;
                    break;
                case CompassPointEnum.West:
                    ant.X --;
                    break;
            }
        }
    }
}
