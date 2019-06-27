using System;
using System.Collections.Generic;
using System.Text;

namespace ExcercisesInheritance
{
    class Circle : Shape
    {
        public Circle(double Radius)
        {
            this.ShapeRadius = Radius;
            this.MyShape = ShapeCode.Circle;
        }
        public override string ShapeToString()
        {
            return $"I'm a circle with radius: {ShapeRadius}";
        }
        public override double CalculateArea()
        {
            return ShapeRadius * ShapeRadius * Math.PI;
        }
    }
}
