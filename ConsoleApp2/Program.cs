using SF2022User12Lib;

Calculations calculations = new Calculations();

TimeSpan[] spans = new TimeSpan[]
{
    new TimeSpan(10,0,0) , // 60
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


for (int i = 0; i < otvet.Length; i++)
{

    if(i%2==0)
    {
        Console.WriteLine("_______");
    }
    string? item = otvet[i];
    Console.WriteLine(item);
}

