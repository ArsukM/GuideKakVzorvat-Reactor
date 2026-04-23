using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Reactor
    {
        private float _temperature;
        private float _waterLevel;
        private int _radiation;
        internal Reactor(float temp, float water, int rad)
        {
            _temperature = temp;
            _waterLevel = water;
            _radiation = rad;
        }
        public float temperature { get; set; }
        public float water_level { get; set; }
        public int radiation { get; set; }
    }
    internal class ReactorResponse
    {
        public Reactor data { get; set; }
    }
    
}
