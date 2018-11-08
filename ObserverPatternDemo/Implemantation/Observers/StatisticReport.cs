using System;
using ObserverPatternDemo.Implemantation.Observable;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> statisticWeather;
        private IObservable<WeatherInfo> _observable;

        public StatisticReport(IObservable<WeatherInfo> observable)
        {
            statisticWeather = new List<WeatherInfo>();
            this._observable = observable;
            observable.Register(this);
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

            Show(ToString());
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

        public void Show(string message) => Console.WriteLine(message);
    }
}
