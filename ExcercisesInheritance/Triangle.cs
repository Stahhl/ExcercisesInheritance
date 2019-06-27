using System;
using System.Collections.Generic;
using System.Text;

namespace ExcercisesInheritance
{
    class Triangle : Shape
    {
        public Triangle(double Height, double Base)
        {
            this.ShapeHeight = Height;
            this.ShapeBase = Base;
            this.MyShape = ShapeCode.Triangle;
        }
        public override string ShapeToString()
        {
            return $"I'm a triangle with base: {ShapeBase} and height: {ShapeHeight}";
        }
        public override double CalculateArea()
        {
            return ShapeBase * ShapeHeight;
        }
    }
}
