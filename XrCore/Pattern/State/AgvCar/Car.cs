using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.State.AgvCar
{
    public class Car : ICar, IActionHandler
    {
        public ICar FullCar;
        public ICar NotFullCar;
        public ICar EmptyCar;
        public ICar CarState;
        public CarInfo CarInfo;
        public Car(CarInfo carInfo)
        {
            this.CarInfo = carInfo;
            FullCar = new FullCar(this);
            NotFullCar = new NotFullCar(this);
            EmptyCar = new EmptyCar(this);
            if (CarInfo.CurCount == 0)
                CarState = EmptyCar;
            else if (CarInfo.CurCount < CarInfo.MaxCount)
                CarState = NotFullCar;
            else
                CarState = FullCar;
        }

        public void RequestNextStation() => CarState.RequestNextStation();

        public void StartLoad()
        {
            Console.WriteLine($"{CarState.GetType().Name} start load");
        }

        public void FinishLoad()
        {
            Console.WriteLine($"{CarState.GetType().Name} finish load");
            CarInfo.CurCount++;
            if (CarInfo.CurCount == CarInfo.MaxCount)
            {
                CarState = FullCar;
                Console.WriteLine($"{CarState.GetType().Name} became FullCar");
            }
            else
            {
                CarState = NotFullCar;
                Console.WriteLine($"{CarState.GetType().Name} became NotFullCar");
            }
        }

        public void StartUnload()
        {
            Console.WriteLine($"{CarState.GetType().Name} start unload");
        }

        public void FinishUnload()
        {
            CarInfo.CurCount++;
            if (CarInfo.CurCount > 0)
            {
                CarState = NotFullCar;
                Console.WriteLine($"{CarState.GetType().Name} became NotFullCar");
            }
            else
            {
                CarState = EmptyCar;
                Console.WriteLine($"{CarState.GetType().Name} became EmptyCar");
            }
        }
    }
}
