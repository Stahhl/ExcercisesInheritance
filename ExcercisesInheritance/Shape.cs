using System;
using System.Collections.Generic;
using System.Text;

namespace ExcercisesInheritance
{
    abstract class Shape
    {
        public double ShapeRadius { get; protected set; }
        public double ShapeBase { get; protected set; }
        public double ShapeHeight { get; protected set; }
        public ShapeCode MyShape { get; protected set; }

        public virtual string ShapeToString()
        {
            throw new NotImplementedException();
        }
        public virtual double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }
}
