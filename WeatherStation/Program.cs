using System;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport(weatherData);

            StatisticReport statisticReport = new StatisticReport(weatherData);

            weatherData.WeatherGenerateInfo();
            Console.ReadKey();
        }
    }
}
