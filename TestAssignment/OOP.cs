namespace TestAssignment
{
    public abstract class Figure
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract bool IsValid();
    }

    public class Rectangle : Figure
    {
        public readonly double Width;
        public readonly double Height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => (Width + Height) * 2;
        public override bool IsValid() => Width > 0 && Height > 0;
    }

    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }

    public class Circle : Figure
    {
        public readonly double Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
        public override bool IsValid() => Radius > 0;
    }

    public class Rhombus : Figure
    {
        public readonly double Side;
        public readonly double Angle;

        public Rhombus(double x, double angle)
        {
            Side = x;
            Angle = angle;
        }

        public override double GetArea() => Side * Side * Math.Sin(Angle * Math.PI / 180);
        public override double GetPerimeter() => Side * 4;
        public override bool IsValid() => Side > 0 && Angle > 0 && Angle < 180;
    }
}
