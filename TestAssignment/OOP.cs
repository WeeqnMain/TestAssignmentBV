namespace TestAssignment
{
    public abstract class Figure
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract bool IsValid();

        protected void EnsureFigureIsValid()
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("Figure parameters are invalid");
            }
        }
    }

    public class Rectangle : Figure
    {
        public readonly double Side;
        public readonly double OtherSide;

        public Rectangle(double side, double otherSide)
        {
            Side = side;
            OtherSide = otherSide;

            EnsureFigureIsValid();
        }

        public override double GetArea() => Side * OtherSide;
        public override double GetPerimeter() => (Side + OtherSide) * 2;
        public override bool IsValid() => Side > 0 && OtherSide > 0;
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

            EnsureFigureIsValid();
        }

        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
        public override bool IsValid() => Radius > 0;
    }

    public class Rhombus : Figure
    {
        public readonly double Side;
        public readonly double Angle;

        public Rhombus(double side, double angle)
        {
            Side = side;
            Angle = angle;

            EnsureFigureIsValid();
        }

        public override double GetArea() => Side * Side * Math.Sin(Angle * Math.PI / 180);
        public override double GetPerimeter() => Side * 4;
        public override bool IsValid() => Side > 0 && Angle > 0 && Angle < 180;
    }
}
