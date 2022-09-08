using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace SF2022User12Lib
{
    /// <summary>
    /// Класс  который делает  магию
    /// </summary>
    public class Calculations
    {
        public string[] AvailablePeriods 
            (  TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime
            )
        {
            #region валидации 
            if (startTimes.Length != durations.Length)
            {
                throw new ArgumentException("Массивы разной  длинны");
            }

            if (beginWorkingTime > endWorkingTime)
            {
                throw new ArgumentException("начало  работы больше  окончания");
            }

            if (consultationTime <= 0)
            {
                throw new ArgumentException("некорректный интервал  операции");
            }

            #endregion

            TimeSpan interval = new TimeSpan(0, consultationTime, 0); // consultationTime В TimeSpan

            List<TimeSpan> startedIterator = new List<TimeSpan>() ; // времена  начала интервалов 
            // например 8-00 иди 11-30 

            if (beginWorkingTime + interval <= startTimes.First()) //проверка помещается  ли начало  работы в  интервал 
                startedIterator.Add(beginWorkingTime);

            for (int i = 0; i < startTimes.Length -1 ; i++) // перебираем массив  startTimes кроме последней 
            {
                var  tim = startTimes[i]  + new TimeSpan( 0, durations[i], 0); // конец интервала например 10-00 +60  ->11-00
                if (tim + interval <= startTimes[i + 1]) // если между остановками помещается интервал значит это  и есть начало работы 
                {
                    startedIterator.Add(tim); // добавим  в  список начал  работы
                }
            }

            var last = startTimes.Last() + new TimeSpan(0, durations.Last(), 0); // найдем  последнию остановку

            if (last + interval <= endWorkingTime) // если  после остановки  достаточно  времяни  до  конца раб дня
                startedIterator.Add(last); // тоже  добавим  в  наш список 

            List<TimeSpan> tryTime = new List<TimeSpan>() ; // сюда будем складывать начала наших искомых  отрезков

            foreach (var st in startedIterator) // переберем наши интервалы -- те точки  откуда начинаем работу 
            {
                TimeSpan stop=st; // ищим крайнюю точку  в наших мини-отрезках
                foreach (var t  in startTimes) // перебирам точки  остановок 
                {
                    if(st <= t) // и  ищем  ближайшую   к старту
                    {
                        stop = t; // нашли точку остановки
                        break;
                    }

                    if(t == startTimes.Last())
                    {
                        stop = endWorkingTime; // смотрим   является ли конец рабочего дня крайней точкой работы
                    }
                }

                tryTime.AddRange(GenereticDate(st, stop, interval)); // ищим массив наших интервалов
            }

            string [] resultat = new string [tryTime.Count] ; // переведем  в  строчное  представление 

            for (int i = 0; i < tryTime.Count; i++)
            {
                var next = tryTime[i]+interval ; // конечная точка сектора 8:00-8:30

                   resultat[i] = $"{MyPars( tryTime[i].Hours.ToString())}" +
                   $":{MyPars(tryTime[i].Minutes.ToString())}-{MyPars(next.Hours.ToString())}" +
                   $":{MyPars(next.Minutes.ToString())}"; // Собираем  в  искомов  формате
            }

            return resultat; 
        }
        
        /// <summary>
        /// добавляет   0 в строке  в  1 символ - например 9 будет  как 09
        /// </summary>
        /// <param name="sumbol"></param>
        /// <returns></returns>
        private string MyPars(string sumbol)
        {
            if (sumbol.Length == 1)
                return "0" + sumbol;
            else
                return sumbol;
        }


        /// <summary>
        /// Генерирует  все точки  интервалов  от  старта работы  до  окончания  по  интервалу 
        /// </summary>
        /// <param name="start">Например 8-00</param>
        /// <param name="stop">Например 10-00</param>
        /// <param name="interval">например 30 мину </param>
        /// <returns>8-00/8-30/9-00/9-30</returns>
        private List<TimeSpan> GenereticDate(TimeSpan start, TimeSpan stop, TimeSpan interval)
        {
            List<TimeSpan> result = new List<TimeSpan>() ; // сюда будем  складывать  
            var s = start; // сохраним стартовое  значение 

            while (s+interval<=stop) 
            {
                result.Add(s); // добавим значние
                s+=interval; 
            }
            return result;  
        }
    }
}
