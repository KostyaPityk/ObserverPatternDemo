using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo _weatherInfo;
        private IObservable<WeatherInfo> _observable;

        public CurrentConditionsReport(IObservable<WeatherInfo> observable)
        {
            if (ReferenceEquals(observable, null))
            {
                throw new ArgumentException(nameof(observable), "can`t be null");
            }

            this._observable = observable;
            observable.Register(this);
        }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentException(nameof(info), "can`t be null");
            }
            else if (ReferenceEquals(sender, null))
            {
                throw new ArgumentException(nameof(info), "can`t be null");
            }

            _weatherInfo = info;
            Show(ToString());
        }

        public override string ToString()
        {
            return $"Current weather: {this._weatherInfo.ToString()}";
        }

        public void Show(string message) => Console.WriteLine(message);
    }
}