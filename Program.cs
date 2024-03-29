﻿namespace StepWiseBuilder;

class Program
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(WheelSize)}: {WheelSize}";
        }
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
        {
            private Car car = new Car();

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                }

                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }

    static void Main(string[] args)
    {
        var car = CarBuilder.Create().OfType(CarType.Sedan).WithWheels(15).Build();
        System.Console.WriteLine(car);
    }
}
