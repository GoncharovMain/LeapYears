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

        }

        public static void TestLeapYears()
        {

            List<int> biases = Enumerable.Range(1, 5).ToList();
            List<int> years = Enumerable.Range(2000, 16).ToList();

            Console.WriteLine(String.Join(" ", years));

            using (StreamWriter writer = new StreamWriter("test.txt"))
            {
                biases.ForEach(bias =>
                {
                    writer.WriteLine($"bias: [{bias}]");
                    years.ForEach(year =>
                    {
                        int leap_math = CountLeapYearsMath(year, year + bias);
                        int leap_for = CountLeapYearsFor(year, year + bias);

                        writer.WriteLine($"[{year},{year + bias}] => "
                        + $"{leap_math} == {leap_for} => {leap_math == leap_for}");
                    });
                    writer.WriteLine();
                });
            }
        }
        public static int CountLeapYearsMath(int start_year, int end_year)
        {
            int left_leap = (start_year % 4 > 0 ? 4 : 0) + ((int)(start_year / 4)) * 4;
            int right_leap = ((int)(end_year / 4)) * 4;

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