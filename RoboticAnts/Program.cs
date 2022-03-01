using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RoboticAnts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial the upper-right coordinates
            Console.WriteLine("Input the upper-right coordinates:");
            string upperBoundStr = Console.ReadLine();
            string[] upperBoundArray = upperBoundStr.Split(" ");
            if (upperBoundArray.Length <= 1 || !VerifyNumbersOfInput(upperBoundArray)) //If invalid input,exit
            {
                Console.WriteLine("Invalid upper-right coordinates");
                Console.ReadLine();
                Environment.Exit(0);
            }
            int boundX = Convert.ToInt32(upperBoundArray[0]);
            int boundY = Convert.ToInt32(upperBoundArray[1]);

            //Initial ant numbers
            List<Ant> antList = InitialAnts();

            if (antList == null)
            {
                Console.WriteLine("Invalid input");
                Console.ReadLine();
                Environment.Exit(0);
            }

            AntNavigation antNavigation = new AntNavigation(boundX, boundY);

            foreach (var ant in antList)
            {
                if (!antNavigation.ExecuteOrder(ant))
                {
                    Console.WriteLine($"ant id={ant.Id}: Over bound");
                }
                else
                {
                    Console.WriteLine($"ant id={ant.Id}: {ant.X} {ant.Y} {ant.CompassPoint}");
                }               
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Initial ants
        /// </summary>
        /// <returns></returns>
        private static List<Ant> InitialAnts()
        {
            //Initial ant numbers
            Console.WriteLine("How many ants do you have:");
            string antNumberStr = Console.ReadLine();
            string[] atnArraryForValdiation = new string[] { antNumberStr };// string array for validaton
            if (!VerifyNumbersOfInput(atnArraryForValdiation)) //If invalid input,exit
            {
                Console.WriteLine("Invalid number");
                Console.ReadLine();
                Environment.Exit(0);
            }

            int antNumber = Convert.ToInt32(antNumberStr);

            var antList = new List<Ant>();
            for (int i = 0; i < antNumber; i++)
            {
                //Initial position
                Console.WriteLine($"A position of ant (number:{i + 1}):");
                string position = Console.ReadLine();
                string[] positionArray = position.Split(" ");

                if (positionArray.Length < 3 || !VerifyPositionOfInput(positionArray)) //If invalid input,exit
                {
                    Console.WriteLine("Invalid number");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                var ant = new Ant();
                ant.Id = i + 1;
                ant.X = Convert.ToInt32(positionArray[0]);
                ant.Y = Convert.ToInt32(positionArray[1]);
                GetCompassPoint(positionArray[2], ant);

                //Order
                Console.WriteLine($"The order for the ant  (number:{i + 1}):");
                string orderStr = Console.ReadLine();
                if (!VerifyOrderOfInput(orderStr))
                {
                    return null;
                }
                ant.Order = orderStr;
                
                antList.Add(ant);
            }

            return antList;
        }

        /// <summary>
        /// Initial the point of the ant
        /// </summary>
        /// <param name="compassPoint"></param>
        /// <param name="ant"></param>
        private static void GetCompassPoint (string compassPoint,Ant ant)
        {
            switch (compassPoint)
            {
                case "N":
                case "n":
                    ant.CompassPoint = CompassPointEnum.North;
                    break;
                case "E":
                case "e":
                    ant.CompassPoint = CompassPointEnum.East;
                    break;
                case "S":
                case "s":
                    ant.CompassPoint = CompassPointEnum.South;
                    break;
                case "W":
                case "w":
                    ant.CompassPoint = CompassPointEnum.West;
                    break;
            }
        }

        /// <summary>
        /// Verify numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static bool VerifyNumbersOfInput(string[] numbers)
        {
            var verifyNumber = new Regex(@"^[0-9]\d*$");
            foreach (string number in numbers)
            {
                if(!verifyNumber.IsMatch(number))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verify order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static bool VerifyOrderOfInput(string order)
        {
            var verifyNumber = new Regex(@"^[lrmLRM]*$");
            return verifyNumber.IsMatch(order);
        }

        /// <summary>
        /// Verify position
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        private static bool VerifyPositionOfInput(string[] positions)
        {
            var verifyPosition = new Regex(@"^[a-zA-Z0-9]*$");
            foreach (string position in positions)
            {
                if (!verifyPosition.IsMatch(position))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
