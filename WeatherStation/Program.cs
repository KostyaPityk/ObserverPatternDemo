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
            WeatherInfo first_info = new WeatherInfo { Temperature = 15, Humidity = 90, Pressure = 34 };
            WeatherInfo second_info = new WeatherInfo { Temperature = 24, Humidity = 80, Pressure = 40 };

            CurrentConditionsReport currentConditionsInfo = new CurrentConditionsReport(first_info);

            List<WeatherInfo> info = new List<WeatherInfo>();
            info.Add(first_info);
            info.Add(second_info);

            StatisticReport statisticReportInfo = new StatisticReport(info);

            weatherData.Notify(weatherData, first_info);

            Console.WriteLine(currentConditionsInfo.ToString());
            Console.WriteLine(statisticReportInfo.ToString());

            first_info.Temperature = 25;
            first_info.Pressure = 80;
            first_info.Humidity = 41;

            weatherData.Notify(weatherData, first_info);

            Console.WriteLine(currentConditionsInfo.ToString());
            Console.WriteLine(statisticReportInfo.ToString());

            
            weatherData.Register(currentConditionsInfo);
            weatherData.Notify(null, second_info);
            Console.WriteLine(currentConditionsInfo.ToString());
            Console.WriteLine(statisticReportInfo.ToString());

            Console.ReadKey();
        }
    }
}
