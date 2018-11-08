namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int Pressure { get; set; }

        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
        public override string ToString()
        {
            return string.Format("temperature: {0}, humidity: {1}, Pressure: {2}",Temperature,
                Humidity, Pressure);
        }
    }
}