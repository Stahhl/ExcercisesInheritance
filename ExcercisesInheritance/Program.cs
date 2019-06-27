using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcercisesInheritance
{
    public enum ShapeCode
    {
        NULL,
        Circle, //Cirle
        Triangle, //Triangle
        Rectangle, //Rectangle
    }
    class Program
    {
        static List<Shape> allShapes = new List<Shape>();
        static ConsoleColor currentColor;
        static void Main()
        {
            double totalArea = 0;
            while(Loop())
            {

            }
            SetTextColor(ConsoleColor.Blue);
            Console.WriteLine();
            SummarizeShapes(allShapes);
            Console.WriteLine();
            foreach (Shape shape in allShapes)
            {
                Console.WriteLine(shape.ShapeToString());
            }
            Console.WriteLine();
            foreach (Shape shape in allShapes)
            {
                double shapeArea = shape.CalculateArea();
                totalArea = totalArea + shapeArea;
                Console.WriteLine($"{shape.MyShape} area = {shapeArea}");
            }
            Console.WriteLine("Total area = " + totalArea);
            Console.ReadLine();
            Console.Clear();
            Main();
        }
        static bool Loop()
        {
            SetTextColor(ConsoleColor.White);
            Console.Write("Select (T)riangle, (R)ectangle, (C)irlce (A)amount (D)one: ");
            string input = GreenInput().ToUpper();

            if (input == "D")
                return false;
            if (input == "A")
                Console.WriteLine("You have " + allShapes.Count() + " shapes in the list.");


            ShapeCode shapeCode = Enum.GetValues(typeof(ShapeCode)).Cast<ShapeCode>()
                .FirstOrDefault(code => SameFirstLetter(code.ToString(), input) == true);

            //Create a new shape matching the code
            if(shapeCode != ShapeCode.NULL)
            {
                switch(shapeCode)
                {
                    case ShapeCode.Circle:
                        CreateShape_Circle();
                        break;
                    case ShapeCode.Rectangle:
                        CreateShape_Rectangle();
                        break;
                    case ShapeCode.Triangle:
                        CreateShape_Triangle();
                        break;
                }
            }

            return true;
        }

        private static void CreateShape_Triangle()
        {
            Console.Write("Enter base of a triangle: ");
            bool one = double.TryParse(GreenInput(), out double Base);
            Console.Write("Enter height of a triangle: ");
            bool two = double.TryParse(GreenInput(), out double Height);

            if(one == true && two == true)
            {
                //New Triangle
                allShapes.Add(new Triangle(Height, Base));
            }
        }

        private static void CreateShape_Rectangle()
        {
            Console.Write("Enter base of a rectangle: ");
            bool one = double.TryParse(GreenInput(), out double Base);
            Console.Write("Enter height of a rectangle: ");
            bool two = double.TryParse(GreenInput(), out double Height);

            if(one == true && two == true)
            {
                //New Rectangle
                allShapes.Add(new Rectangle(Base, Height));
            }
        }
        private static void CreateShape_Circle()
        {
            Console.Write("Enter radius of a circle: ");
            bool one = double.TryParse(GreenInput(), out double Radius);
            if(one == true)
            {
                //New Circle
                allShapes.Add(new Circle(Radius));
            }
        }

        static void SetTextColor(ConsoleColor color)
        {
            currentColor = color;
            Console.ForegroundColor = currentColor;
        }
        static string GreenInput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = currentColor;
            input = input.Replace(',', '.');
            return input;
        }
        static bool SameFirstLetter(string one, string two)
        {
            one.ToUpper();
            two.ToUpper();

            if(one[0] == two[0])
            {
                return true;
            }

            return false;
        }
        static string NumberToText(int number)
        {
            //If the number is outside the range 0-9
            //Just return number.ToString() eg 12 not twelve
            string name = number.ToString();
            
            switch (number)
            {
                case 0:
                    name = "Zero";
                    break;
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }

            return name;
        }
        static string AddPluradSuffixIfMultiple(int number, string word)
        {
            if (number > 1)
                word = word + "s";

            return word;
        }
        static public void SummarizeShapes(List<Shape> allShapes)
        {
            Dictionary<ShapeCode, int> shapeToAmountMap = new Dictionary<ShapeCode, int>();
            List<KeyValuePair<ShapeCode, int>> kvpList = new List<KeyValuePair<ShapeCode, int>>();
            int nbTriangles = 1;
            int nbRectangles = 1;
            int nbCircles = 1;

            foreach (Shape shape in allShapes)
            {
                switch(shape.MyShape)
                {
                    case ShapeCode.Circle:
                        shapeToAmountMap[shape.MyShape] = nbCircles++;
                        break;
                    case ShapeCode.Rectangle:
                        shapeToAmountMap[shape.MyShape] = nbRectangles++;
                        break;
                    case ShapeCode.Triangle:
                        shapeToAmountMap[shape.MyShape] = nbTriangles++;
                        break;
                }
            }
            foreach (KeyValuePair<ShapeCode, int> item in shapeToAmountMap)
            {
                // do something with entry.Value or entry.Key
                kvpList.Add(item);
            }

            //Console.WriteLine(intArray[0] + "_" + intArray[1] + "_" + intArray[2]);
            //sb.Append("You selected ")
            if (kvpList.Count() == 1)
            {
                //Console.WriteLine("1!");
                Console.WriteLine($"You selected " +
                    $"{NumberToText(kvpList[0].Value).ToLower()} " +                                         //a
                    $"{AddPluradSuffixIfMultiple(kvpList[0].Value, kvpList[0].Key.ToString()).ToLower()}."); //a
            }
            if (kvpList.Count() == 2)
            {
                //Console.WriteLine("2!");
                Console.WriteLine($"You selected " +
                    $"{NumberToText(kvpList[0].Value).ToLower()} " +                                           //a
                    $"{AddPluradSuffixIfMultiple(kvpList[0].Value, kvpList[0].Key.ToString()).ToLower()} " +   //a
                    $"and {NumberToText(kvpList[1].Value).ToLower()} " +                                       //b                                               
                    $"{AddPluradSuffixIfMultiple(kvpList[1].Value, kvpList[1].Key.ToString()).ToLower()}. ");  //b
            }
            if (kvpList.Count() == 3)
            {
                //Console.WriteLine("3!");
                Console.WriteLine($"You selected " +
                    $"{NumberToText(kvpList[0].Value).ToLower()} " +                                           //a
                    $"{AddPluradSuffixIfMultiple(kvpList[0].Value, kvpList[0].Key.ToString()).ToLower()}, " +  //a
                    $"{NumberToText(kvpList[1].Value).ToLower()} " +                                           //b
                    $"{AddPluradSuffixIfMultiple(kvpList[1].Value, kvpList[1].Key.ToString()).ToLower()} " +   //b
                    $"and {NumberToText(kvpList[2].Value).ToLower()} " +                                       //c
                    $"{AddPluradSuffixIfMultiple(kvpList[2].Value, kvpList[2].Key.ToString()).ToLower()}. ");  //c
            }
        }
    }
}
