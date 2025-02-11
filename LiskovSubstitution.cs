using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     *  This file demonstrates use of Liskov principle
     *  
     *  In this scenatio when class SquareOne inherits class Rectangle, it violates Liskov substitution.
     *  However, When class SquareTwo inherits class RectangelTwo, it follows Liskov substitution.
     */
    internal class LiskovSubstitution
    {
        public int Area(Rectangle r) => r.Width * r.Height;
        public int AreaTwo(RectangleTwo r) => r.Width * r.Height;

        public void Start()
        {
            Rectangle rc = new Rectangle(2, 4);
            Console.WriteLine(($"{rc} has area of {Area(rc)}"));

            SquareOne sq1 = new SquareOne();
            sq1.Width = 4;
            Console.WriteLine(($"{sq1} has area of {Area(sq1)}"));

            Rectangle sq11 = new SquareOne();
            sq1.Width = 4;
            Console.WriteLine(($"{sq11} has area of {Area(sq11)}"));

            RectangleTwo sq2 = new SquareTwo();
            sq2.Width = 4;
            Console.WriteLine(($"{sq2} has area of {AreaTwo(sq2)}"));
        }

    }

    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
            
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class SquareOne : Rectangle
    {
        /*public SquareOne(int width, int height) : base(width, height)
        {
            this.Width = width;
            this.Height = height;
        }*/

        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Height = base.Width = value; }
        }
    }

    public class RectangleTwo
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public RectangleTwo()
        {

        }

        public RectangleTwo(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class SquareTwo : RectangleTwo
    {
        /*public SquareOne(int width, int height) : base(width, height)
        {
            this.Width = width;
            this.Height = height;
        }*/

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Height = base.Width = value; }
        }
    }

}