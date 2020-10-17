using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentRetry
{
    class SampleArray
    {
        static void DisplayArray(string[] arr) => Console.WriteLine(string.Join(" ", arr));


        static void ChangeArray(string[] arr) => Array.Reverse(arr);


        static void Main()
        {
            try
            {
                int days;
                string[] weekDays = new string[7];
                Console.WriteLine("How many days are there in a week?");
                days = Int32.Parse(Console.ReadLine());

                if (days != 7)
                {
                    Console.WriteLine("Oops, wrong answer!!! Please try again");

                }
                else
                {


                    Console.WriteLine("Enter the days of a week in order:");
                    for (int day = 0; day < days; day++)
                    {
                        Console.WriteLine("Enter day:");
                        weekDays[day] = Console.ReadLine();

                    }

                    Console.WriteLine("Before");
                    DisplayArray(weekDays);
                    Console.WriteLine();


                    ChangeArray(weekDays);

                    Console.WriteLine("After:");
                    DisplayArray(weekDays);
                    Console.WriteLine();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}