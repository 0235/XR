using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.AgvCar
{
    public class EmptyCar : ICar
    {
        public Car Car;
        public EmptyCar(Car car)
        {
            this.Car = car;
        }
        public void RequestNextStation()
        {
            Console.WriteLine("empty car request next station,next station is min distance load station");
        }
    }
}
