using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.AgvCar
{
    public class NotFullCar : ICar
    {
        public Car Car;
        public NotFullCar(Car car)
        {
            this.Car = car;
        }
        public void RequestNextStation()
        {
            Console.WriteLine("not full car request next station,next station is min distance station");
        }
    }
}
