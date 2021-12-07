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
        }
        public static int for_cycle(int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; sum += i, i++) ;
            return sum;
        }
        public static int for_rec(int start, int end, int sum = 0)
            => start > end ? sum : for_rec(start + 1, end, sum + start);
    }
}