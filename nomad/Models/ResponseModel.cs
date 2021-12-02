using System;
namespace nomad.Models
{
    public class ResponseModel
    {
        public string City { get; set; }
        public int Time { get; set; }
        public double Temperature { get; set; }
        public double Wind_Speed { get; set; }
        public string Weather { get; set; }

        public ResponseModel(string _city, int _time, double _temperature, double _wing_speed, string _weather)
        {
            City = _city;
            Time = _time;
            Temperature = _temperature;
            Wind_Speed = _wing_speed;
            Weather = _weather;
        }
    }
}
