using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo _weatherInfo;

        public CurrentConditionsReport(WeatherInfo observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentException(nameof(observable), "can`t be null");
            }

            this._weatherInfo = observable;
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentException(nameof(info), "can`t be null");
            }

            _weatherInfo = info;
        }

        public override string ToString()
        {
            return $"Current weather: {this._weatherInfo.ToString()}";
        }
    }
}