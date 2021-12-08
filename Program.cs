/*
	цикл (for)
		for_cycle - найти сумму целых чисел в диапазоне [start, end]
		CountLeapYearsFor - считает сколько высокосных годов в диапазоне [start_year, end_year]
	рекурсия
		for_rec - найти сумму целых чисел в диапазоне [start, end]
		CountLeapYearsRec - считает сколько высокосных годов в диапазоне [start_year, end_year]
		QuickSort - быстрая сортировка

    math
        CountLeapYearsMath - считает сколько высокосных годов в диапазоне [start_year, end_year]

	IsLeap - високосный год или нет
*/
using System.Diagnostics;

namespace Year
{
    class Program
    {

        public static bool IsLeap(int year)
        {
            return year % 4 == 0;
        }
        public static void Main()
        {

            Console.WriteLine("count leap years with for: -> " + CountLeapYearsFor(2000, 2030));

            Console.WriteLine("count leap years with rec: -> " + CountLeapYearsRec(2000, 2030));


            Console.WriteLine("get sum with rec:" + for_rec(1, 10));

            Console.WriteLine("get sum with for:" + for_cycle(1, 10));


            List<int> list = new List<int> { 5, 12, 50, -6, 17, 209, 10, -1 };

            list.ForEach(item => Console.Write(item + " "));

            Console.WriteLine();


            Console.WriteLine("Sort with quick sort");

            QuickSort(list).ForEach(item => Console.Write(item + " "));

            Console.WriteLine();


            Console.WriteLine("Sort with order by");

            list.OrderBy(item => item).ToList().ForEach(item => Console.Write(item + " "));

            Console.WriteLine();

            TestLeapYears();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Jenya");
                TestTime(CountLeapYearsMathJ);

                Console.WriteLine("Yura");
                TestTime(CountLeapYearsMath);


                Console.WriteLine();
            }

        }
        public static bool IsOdd(int number)
        {
            Console.WriteLine("Проверяем чило " + number);
            return number % 2 == 0;
        }

        public static void TestLeapYears()
        {

            List<int> biases = Enumerable.Range(1, 5).ToList();
            List<int> years = Enumerable.Range(2000, 16).ToList();

            using (StreamWriter writer = new StreamWriter("test.txt"))
            {
                biases.ForEach(bias =>
                {
                    writer.WriteLine($"bias: [{bias}]x");
                    years.ForEach(year =>
                    {
                        int leap_math = CountLeapYearsMathJ(year, year + bias);
                        int leap_for = CountLeapYearsFor(year, year + bias);

                        writer.WriteLine($"[{year},{year + bias}] => "
                        + $"{leap_math} == {leap_for} => {leap_math == leap_for}");
                    });
                    writer.WriteLine();
                });
            }
        }
        public delegate int function(int a, int b);
        public static void TestTime(function func)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 100000000 * 4; i++)
            {
                func(2001, 2065);
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);

        }

        public static int CountLeapYearsMathJ(int start_year, int end_year)
        {
            return (start_year % 4 != 0 & end_year % 4 != 0) ?
                (end_year / 4) - (start_year / 4)
                : ((end_year - start_year) / 4) + 1;
        }

        public static int CountLeapYearsMath(int start_year, int end_year)
        {
            int left_leap = (start_year % 4 > 0 ? 4 : 0) + (start_year / 4) * 4;
            int right_leap = (end_year / 4) * 4;

            return 1 + (right_leap - left_leap) / 4;
        }

        public static int CountLeapYearsFor(int start_year, int end_year)
        {
            int count_leap_years = 0;

            for (int year = start_year; year <= end_year; count_leap_years += IsLeap(year) ? 1 : 0, year++) ;

            return count_leap_years;
        }
        public static int for_cycle(int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; sum += i, i++) ;

            return sum;
        }
        public static int for_rec(int start, int end, int sum = 0) => start > end ? sum : for_rec(start + 1, end, sum + start);
        public static int CountLeapYearsRec(int start_year, int end_year, int count_leap_years = 0)
            => start_year <= end_year ?
                CountLeapYearsRec(start_year + 1, end_year, count_leap_years += (IsLeap(start_year) ? 1 : 0))
                : count_leap_years;
        public static List<int> QuickSort(List<int> list)
            => list.Count() >= 2 ?
                QuickSort(list.Where(item => item < list[0]).ToList())
                .Concat(new List<int> { list[0] })
                .Concat(QuickSort(list.Where(item => item > list[0]).ToList())).ToList()
                : list;

    }
}