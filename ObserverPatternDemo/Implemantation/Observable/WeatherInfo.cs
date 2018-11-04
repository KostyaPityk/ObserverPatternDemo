namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        public override string ToString()
        {
            return string.Format("temperature: {0}, humidity: {1}, Pressure: {2}",Temperature,
                Humidity, Pressure);
        }
    }
}