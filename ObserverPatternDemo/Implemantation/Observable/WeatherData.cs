using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers;

        public WeatherData()
        {
            observers = new List<IObserver<WeatherInfo>>();
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

            observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentException(nameof(observer), "can`t be null");
            }

            observers.Remove(observer);
        }
    }
}