using System;
using System.Collections.Generic;
using System.Text;

namespace ExcercisesInheritance
{
    class Rectangle : Shape
    {
        public Rectangle(double Base, double Height)
        {
            this.ShapeBase = Base;
            this.ShapeHeight = Height;
            this.MyShape = ShapeCode.Rectangle;
        }
        public override string ShapeToString()
        {
            return $"I'm a rectanlge with base: {ShapeBase} and height: {ShapeHeight}";
        }
        public override double CalculateArea()
        {
            return ShapeBase * ShapeHeight;
        }
    }
}
