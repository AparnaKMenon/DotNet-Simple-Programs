using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomNumber
{
    public static void Main(string[] args)
    {
        int low = 1;
        int high = 52;
        Console.WriteLine("Numbers 1 to 52 Randomly Listed:");
        generateRandomNumArray(low, high);

        char condition = '1';

        while ('0' != condition)
        {
            Console.WriteLine("\n\nEnter the Range for Generating a random Number.\nLower Value:");
            string strLow = Console.ReadLine();
            Console.WriteLine("Higher Value:");
            string strHigh = Console.ReadLine();
            try
            {
                low = Convert.ToInt32(strLow);
                high = Convert.ToInt32(strHigh);
                Console.WriteLine("Random Number: " + generateRandomNum(low, high));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Entry!\nEnter numbers between -2147483648 and 2147483647");
            }
            finally
            {
                Console.WriteLine("Enter 0 to quit, any other key to continue");
                string strCondition = Console.ReadLine();
                if (!String.IsNullOrEmpty(strCondition))
                {
                    condition = (strCondition)[0];
                }
            }
        }
    }

    public static void generateRandomNumArray(int firstNum, int lastNum)
    {
        List<int> lstNumbers = new List<int>();

        for (int index = firstNum; index <= lastNum; index++)
        {
            lstNumbers.Add(index);
        }

        int nArrSize = lstNumbers.Count;
        List<int> lstRandNumbers = new List<int>();

        while (lstNumbers.Count > 0)
        {
            int rand = generateRandomNum(0, lstNumbers.Count - 1);
            lstRandNumbers.Add(lstNumbers[rand]);
            lstNumbers.RemoveAt(rand);
        }

        for (int index = 0; index < nArrSize; index++)
            Console.Write(" " + lstRandNumbers[index] + " ");
    }

    //Function to generate a Random Number from in between the range
    //The uniqueness of "System.Guid" is used for generating Randomness
    public static int generateRandomNum(int low, int high)
    {
        int nRandom = low;
        do
        {
            //If high and low are in the wrong order, swap them first
            if (high < low)
            {
                Console.WriteLine("High and Low are interchanged!");
                int temp = low;
                low = high;
                high = temp;
            }

            int range = high - low;

            //If the lower and upper values are the same, quit from the do while loop
            //and return the nRandom which is same as low or high
            if (range == 0)
                break;

            //Using the trailing characters of "System.Guid" for generating random numbers
            //as they are unique everytime. The number of trailing digits to be used 
            //will depend on the range in which the the Random numbers are needed.
            String strGuid = Guid.NewGuid().ToString();
            int numDigits = 1;
            String strHexNum = "0xF";
            int nHexNum;
            for (; numDigits < 8; numDigits++, strHexNum += "F")
            {
                nHexNum = Convert.ToInt32(strHexNum, 16);
                if (range < nHexNum)
                {
                    break;
                }
            }

            String strHex = strGuid.Substring(strGuid.Length - numDigits, numDigits);
            uint uRandom = Convert.ToUInt32(strHex, 16);

            //Handling the case where the random number obtained is greater than what Int32 can hold
            if (uRandom > Int32.MaxValue)
            {
                nRandom = generateRandomNum(low, high);
                break;
            }

            nRandom = (int)uRandom;

            //Ensuring that the Random number is within the range.
            if (nRandom > range)
            {
                nRandom %= range;
            }
            //Handling +ve and -ve numbers separately
            if (low >= 0)
            {
                if (nRandom < low)
                    nRandom += low;
            }
            else
            {
                if (nRandom > high)
                    nRandom = high - nRandom;
            }
        } while (false);

        return nRandom;
    }
}