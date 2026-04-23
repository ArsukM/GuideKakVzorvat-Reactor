using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class reactorResponse
    {
        public dataInfo data { get; set; }
    }
    internal class dataInfo
    {
        public Reactor reactor_state { get; set; }
    }
    internal class Reactor
    {
       
        internal Reactor(float temp, float water, float rad)
        {
            _temperature = temp;
            _waterLevel = water;
            _radiation = rad;
        }
        private float _temperature;
        private float _waterLevel;
        private float _radiation;
        public float temperature { get; set; }
        public float water_level { get; set; }
        public float radiation { get; set; }
        public Reactor()
        {

        }
    }

}

