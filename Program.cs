using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2Etgar
{
    class Program
    {
        static double FindPath(int numberOfTimes)
        {
            double startNum = 1000;
            double distNum = (double)100 / numberOfTimes;
            for (int i = numberOfTimes; i >= 1; i--)
            {
                //Console.WriteLine("startNum: " + startNum + " distNum: " + distNum + " numberOfTimes: " + i);
                if (i == 1)
                {
                    double temp = UpdateStartNum(startNum, distNum, i);
                    if (startNum >= 100 && 100 - distNum > temp)
                        return 100 - distNum;
                    else
                        return temp;
                }
                startNum = UpdateStartNum(startNum, distNum, i);
            }
            return 0;
        }
        //Getting StackOverFlow Error - Don't use this function.
        static double FindPathRecursive(double startNum, double distNum, int numberOfTimes)
        {
            //Console.WriteLine("startNum: " + startNum + " distNum: " + distNum + " numberOfTimes: " + numberOfTimes);
            if (numberOfTimes == 1)
            {
                double temp = UpdateStartNum(startNum, distNum, numberOfTimes);
                if (startNum >= 100 && 100 - distNum > temp)
                    return 100 - distNum;
                else
                    return temp;

            }
            startNum = UpdateStartNum(startNum, distNum, numberOfTimes);
            numberOfTimes -= 1;
            return FindPathRecursive(startNum, distNum, numberOfTimes);
        }
        static double UpdateStartNum(double startNum, double distNum, int numberOfTimes)
        {
            if (startNum % 100 == 0)
            {
                int turns = (int)(startNum / 100) - 1;
                startNum = (turns * 100) - (turns * distNum * 2);
                startNum += 100 - distNum;
            }
            else if (startNum % 100 <= distNum)
            {
                int turns = (int)startNum / 100 - 1;
                double whatLeft = startNum % 100 + 100;
                double whatLeftHalf = whatLeft / 2;
                startNum = (turns * 100) - (turns * distNum * 2);
                startNum += whatLeftHalf - (distNum * 2);
                startNum += whatLeftHalf - distNum;
            }
            else
            {
                int turns = (int)startNum / 100;
                double whatLeft = startNum % 100;
                startNum = (turns * 100) - (turns * distNum * 2);
                startNum += whatLeft - distNum;
            }
            return startNum;
        }
        static void SearchForTheHighestScore(int from, int to)
        {
            double highest = 0;
            int highestIndex = 0;
            for (int i = from; i <= to; i++)
            {
                double temp = FindPath(i);
                if (temp > highest)
                {
                    highest = temp;
                    highestIndex = i;
                }
            }
            Console.WriteLine("index: " + highestIndex);
            Console.WriteLine("highest: " + highest);
        }

        static void Main(string[] args)
        {
            //default settings of the search are from 3 to 10000
            //int from = 3; 
            //int to = 10000;
            //SearchForTheHighestScore(from, to);
            Console.WriteLine(FindPath(1000000000));
        }
    }
}
