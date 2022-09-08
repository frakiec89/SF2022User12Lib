using SF2022User12Lib;

Calculations calculations = new Calculations();

TimeSpan[] spans = new TimeSpan[]
{
    new TimeSpan(10,0,0) , // 60   8-10  11/30 -15/00 15-40 16/50 17-30-18
    new TimeSpan(11,0,0),  //30
    new TimeSpan(15,0,0) ,  //10
    new TimeSpan(15,30,0),   //10
    new TimeSpan(16,50,0)    //40
};

int[] Ints = new int[]
{
    60,
    30,
    10,
    10,
    40
};

TimeSpan start = new TimeSpan(8, 0, 0);
TimeSpan end = new TimeSpan(18, 0, 0);

int interval = 30;

string[] otvet = calculations.AvailablePeriods(spans , Ints , start , end, interval);


foreach (string v in otvet)
{
    Console.WriteLine(v);
}

