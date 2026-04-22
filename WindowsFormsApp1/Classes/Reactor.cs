using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Reactor
    {
        private float _temperature;
        private float _waterLevel;
        private int _radiation;

        public float temperature { get { return _temperature; } set { _temperature = value; } }
        public float water_level { get { return _waterLevel; } set { _waterLevel = value; } }
        public int radiaton { get { return _radiation; } set { _radiation = value; } }


        Reactor(float temp, float water, int rad)
        {
            _temperature = temp;
            _waterLevel = water;
            _radiation = rad;
        }


    }
}
