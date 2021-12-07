namespace Year
{
    class Program
    {

        public static bool IsLeap(int year)
        {
            return year % 4 == 0;
        }
        public static void GetCountLeapYears()
        {
            int count_leap_years = 0;
            for (int year = 2000; year < 2013; year++)
            {
                if (IsLeap(year))
                    count_leap_years++;
            }
            Console.WriteLine("количество високосных годов в дипазоне:" + count_leap_years);
        }
        public static int GetLeapYearsRec(int start_year, int end_year, int count_leap_years = 0)
            => start_year <= end_year ? GetLeapYearsRec(start_year + 1, end_year, count_leap_years += (IsLeap(start_year) ? 1 : 0)) : count_leap_years;
        public static void Main()
        {
            Console.WriteLine("count leap years: -> " + GetLeapYearsRec(2000, 2030));

            int sum = for_rec(1, 10);
            Console.WriteLine("get sum with rec:" + sum);

            sum = for_cycle(1, 10);
            Console.WriteLine("get sum with for:" + sum);


            var array = new List<int> { 5, 12, 50, -6, 17, 209, 10, -1 };
            var sort_array = QuickSort(array);

            array.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();
            sort_array.ForEach(item => Console.Write(item + " "));
        }
        public static int for_cycle(int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; sum += i, i++) ;
            return sum;
        }

        public static int for_rec(int start, int end, int sum = 0)
            => start > end ? sum : for_rec(start + 1, end, sum + start);

        public static List<int> QuickSort(List<int> array)
         => array.Count() >= 2 ?
                 QuickSort(array.Where(item => item > array[0]).ToList())
                .Concat(new List<int> { array[0] })
                .Concat(QuickSort(array.Where(item => item < array[0]).ToList())).ToList() : array;

    }
}