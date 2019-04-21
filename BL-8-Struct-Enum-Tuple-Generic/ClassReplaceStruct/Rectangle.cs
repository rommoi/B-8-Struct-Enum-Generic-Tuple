using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic.ClassReplaceStruct
{
    class Rectangle
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public Point Coordinate { get; private set; }

        public Rectangle(Point p, double height, double width)
        {
            Height = height > 0 ? height : 0;
            Width = width > 0 ? width : 0;
            Coordinate = p;
        }
        public bool Equals(Rectangle r)
        {
            if (Height == r.Height &&
                        Width == r.Width &&
                        Coordinate.X == r.Coordinate.X &&
                        Coordinate.Y == r.Coordinate.Y &&
                        Coordinate.Z == r.Coordinate.Z)
            {
                return true;

            }
            return false ;
        }
    }
}
