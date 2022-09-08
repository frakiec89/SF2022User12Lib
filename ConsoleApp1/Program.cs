
using SF2022User12Lib;

TimeSpan[] timeSpans = new TimeSpan[]
{
    new TimeSpan(10, 0, 0) ,
    new TimeSpan(11, 0, 0) ,
    new TimeSpan(15, 0, 0) ,
    new TimeSpan(15, 30, 0) ,
    new TimeSpan(16, 50, 0) ,
};

int[] ints = new int[]
{
    60 , 30, 10, 10, 40 
};

TimeSpan start = new TimeSpan(17, 0, 0);
TimeSpan end = new TimeSpan(18, 0, 0);

int interval = 30;

Calculations calculations = new Calculations();
try
{
    var s = calculations.AvailablePeriods(timeSpans, ints, start, end, interval);
    foreach (var item in s)
    {
        Console.WriteLine(item);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
    




