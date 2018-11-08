using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;

        public Action<WeatherData, WeatherInfo> OnWeatherChange;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
        }

        public void WeatherGenerateInfo()
        {
            Random random = new Random();
            while (true)
            {
                WeatherInfo weatherInfo = new WeatherInfo(random.Next(-25, 25), random.Next(0, 300), random.Next(90));
                OnWeatherChange?.Invoke(this, weatherInfo);
                Thread.Sleep(5000);
            }          
        }

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (ReferenceEquals(info, null))
            {
                throw new ArgumentException(nameof(info), "can`t be null");
            }

            foreach (IObserver<WeatherInfo> observer in observers)
            {
                observer.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentException(nameof(observer), "can`t be null");
            }
            else if (observers.Contains(observer))
            {
                throw new ArgumentException(nameof(observer), "observer already contains");
            }
            OnWeatherChange += observer.Update;
            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentException(nameof(observer), "can`t be null");
            }

            OnWeatherChange -= observer.Update;
            observers.Remove(observer);
        }
    }
}