using System;

namespace Coditity_Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(BinaryGap(81));

            //int[] array = new int[] { 3, 8, 9, 7, 6 };
            //int[] input1 = CyclicRotation(array, 3);
            //foreach (int i in input1)
            //{
            //    Console.WriteLine(i);
            //}
            //int[] a = new int[] { 3, 5, 1, 3, 4, 5, 1 };
            //Console.WriteLine(PairedOccurences(a));
            //int[] b = new int[] { 9, 3, 9, 3, 9, 7, 9 };
            //Console.WriteLine(PairedOccurences(b));
            //Console.WriteLine(FrogJump(60, 60, 80));
            //int[] a = { 1, 2,3,4,5,6,7,9 };
            //Console.WriteLine(MissingNumber(a));
            int[] a = { 9, 1, 1, 4, 9 };
            Console.WriteLine(TapeEquilibrium(a));
        }
        static int BinaryGap(int N)
        {
            if (Math.Log2(Convert.ToDouble(N)) % 1 == 0)
            {
                return 0;
            }
            string bin = Convert.ToString(N, 2);
            int count = 0;
            List<int> list = new List<int>();
            foreach (char i in bin)
            {
                if (i == '1')
                {
                    list.Add(count);
                    count = 0;
                }
                if (i == '0')
                {
                    count += 1;
                }
            }
            return list.Max();
        }
        static int[] CyclicRotation(int[] input, int rot)
        {
            int[] newarray = new int[input.Length];
            int[] oldarray = input;
            int first = 0;
            for (int i = 0; i < input.Length - rot; i++)
            {
                first = oldarray[0];
                Array.Copy(oldarray, 1, newarray, 0, oldarray.Length - 1);
                newarray[newarray.Length-1] = first;
                oldarray = newarray;
                newarray = new int[input.Length];
            }

            return oldarray;
        }
        static int PairedOccurences(int[] input)
        {
            List<int> checklist = new List<int> { };
            foreach(int i in input)
            {
                if (checklist.Contains(i)== false)
                {
                    checklist.Add(i);
                }
                else
                {
                    checklist.Remove(i);
                }
            }
            return checklist[0];
        }
        static int FrogJump(int start, int finish, int jump)
        {
            int number = 0;
            for(int i = start; i < finish; i= i + jump)
            {
                number = number + 1;
            }
            return number;
        }
        static int MissingNumber(int[] list)
        {
            List<int> count = new List<int> { };
            for(int i= 1; i < list.Length+2; i++)
            {
                count.Add(i);
            }
            foreach(int a in count)
            {
                Console.WriteLine(a);
            }
            foreach (int j in list)
            {
                if(count.Contains(j))
                {
                    count.Remove(j);
                }
            }
            return count[0];
        }
        static int TapeEquilibrium(int[] list)
        {
            List<int> totals = new List<int>();
            int start = 0;
            int sub = 0;
            for (int i =1; i <list.Length; i++)
            {
                start = 0;
                sub = 0;
                for (int j = 0; j < list.Length; j++)
                {
                    if( j < i)
                    {
                        start= start+list[j];
                    }
                    else
                    {
                        sub = sub +list[j];
                    }
                }
                totals.Add(Math.Abs(start-sub));
            }
            return totals.Min();
        }
    }
    
}