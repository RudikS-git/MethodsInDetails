using System;
using System.Diagnostics;

namespace MethodsInDetails
{
    public class AlgorithmGCD
    {
        static private int SearchViaRemainderTemplate(int firstNum, int secondNum)
        {
            if (firstNum == 0 && secondNum == 0)
            {
                throw new ArgumentException("Numbers must be nonzero!");
            }
            else if (firstNum == 0)
            {
                return secondNum < 0 ? Math.Abs(secondNum) : secondNum;
            }
            else if(secondNum == 0)
            {
                return firstNum < 0 ? Math.Abs(firstNum) : firstNum;
            }

            int temp;

            while (secondNum != 0)
            {
                temp = secondNum;
                secondNum = firstNum % secondNum;
                firstNum = temp;
            }

            return firstNum < 0? Math.Abs(firstNum): firstNum;
        }

        static public int SearchViaRemainder(int firstNum, int secondNum, out int mSec)
        {
            return SearchWithTimer(SearchViaRemainderTemplate, firstNum, secondNum, out mSec);
        }

        static public int SearchViaRemainder(int firstNum, int secondNum, int thirdNum, out int mSec)
        {
            return SearchWithTimer(SearchViaRemainderTemplate, 
                                   SearchViaRemainderTemplate(firstNum, secondNum),
                                   thirdNum, 
                                   out mSec); ;
        }

        static public int SearchViaRemainder(out int mSec, params int[] nums)
        {
            return SearchWithTimerArray(SearchViaRemainderTemplate, out mSec, nums);
        }

        static private int SearchViaBinaryTemplate(int firstNum, int secondNum)
        {
            if (firstNum < 0) firstNum = Math.Abs(firstNum);
            if (secondNum < 0) secondNum = Math.Abs(secondNum);

            if (firstNum == 0 && secondNum == 0)
            {
                throw new ArgumentException("Numbers must be nonzero!");
            }
            else if (firstNum == 0)
            {
                return secondNum;
            }
            else if (secondNum == 0)
            {
                return firstNum;
            }

            if((firstNum & 1) == 0)
            {
                return (secondNum & 1) == 1 ? SearchViaBinaryTemplate(firstNum >> 1, secondNum) :
                                              SearchViaBinaryTemplate(firstNum >> 1, secondNum >> 1) << 1;                      
            }
            else if((secondNum & 1) == 0)
            {
                return SearchViaBinaryTemplate(firstNum, secondNum >> 1);
            }
            else
            {
                return firstNum > secondNum ? SearchViaBinaryTemplate((firstNum - secondNum) >> 1, secondNum) :
                                              SearchViaBinaryTemplate((secondNum - firstNum) >> 1, firstNum);
            }
        }

        static public int SearchViaBinary(int firstNum, int secondNum, out int mSec)
        {
            return SearchWithTimer(SearchViaBinaryTemplate, firstNum, secondNum, out mSec);
        }

        static public int SearchViaBinary(int firstNum, int secondNum, int thirdNum, out int mSec)
        {
            return SearchWithTimer(SearchViaBinaryTemplate,
                                   SearchViaBinaryTemplate(firstNum, secondNum),
                                   thirdNum,
                                    out mSec);
        }

        static public int SearchViaBinary(out int mSec, params int[] nums)
        {
            return SearchWithTimerArray(SearchViaBinaryTemplate, out mSec, nums);
        }

        static private int SearchWithTimerArray(Func<int, int, int> SearchAlgorithm, out int mSec, params int[] nums)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            mSec = 0;

            if (nums.Length == 0)
            {
                throw new ArgumentException("Array must not be empty!");
            }

            int temp = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                temp = SearchAlgorithm(temp, nums[i]);
            }

            return temp;
        }

        static private int SearchWithTimer(Func<int, int, int> func, int firstNum, int secondNum, out int mSec)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            mSec = 0;

            int result = func(firstNum, secondNum);

            stopWatch.Stop();
            mSec = stopWatch.Elapsed.Milliseconds;

            return result;
        }
    }
}
