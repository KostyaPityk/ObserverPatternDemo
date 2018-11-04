using System;
using ObserverPatternDemo.Implemantation.Observable;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statisticWeather;

        public StatisticReport()
        {
            statisticWeather = new List<WeatherInfo>();
        }

        public StatisticReport(List<WeatherInfo> dataInfo) => statisticWeather = dataInfo;

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentException(nameof(sender), "can`t be null");
            }
            else if (ReferenceEquals(info, null))
            {
                throw new ArgumentException(nameof(info), "can`t be null");
            }

            statisticWeather.Add(info);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var weather in statisticWeather)
            {
                result.AppendLine(weather.ToString());
            }

            return result.ToString();
        }
    }
}
