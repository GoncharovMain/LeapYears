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
        {
            if (start_year <= end_year)
            {
                return GetLeapYearsRec(start_year + 1, end_year, count_leap_years += (IsLeap(start_year) ? 1 : 0));
            }
            return count_leap_years;

        }
        public static void Foo(int a = 5) // необязательный параметр
        {
            Console.WriteLine(a);
        }
        public static void Bar()
        {
            int a = 5;
            Console.WriteLine(a);
        }
        public static void Fizz()
        {
            Foo(6); // a => 6
            Foo(); // a => 5
            //Bar(6); // error - нельзя передать в метод
        }
        public static int Fact(int f)
        {
            if (f < 1)
                return f;
            return Fact(f - 1) * f;
        }
        public static void Main()
        {
            Console.WriteLine("count leap years: -> " + GetLeapYearsRec(2000, 2030));
        }
    }
}

// [2000 2001 2002 2003 2004 2005 2006 2007 2008 2009 2010 2011 2012]

