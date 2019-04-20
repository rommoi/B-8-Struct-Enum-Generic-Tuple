using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Lesson
    {
        public static void IntNeighbourExample()
        {
            Neighbor[] neighbors = new Neighbor[256];
            neighbors[0] = new Neighbor() { flatNumber = 3 };

            Array.Sort(neighbors, new Comparison<Neighbor>(
                (n1, n2) => n1.flatNumber.CompareTo(n2.flatNumber)));
        }

        public static void ObjectNeighbourExample()
        {
            NeighborO[] neighbors1 = new NeighborO[256];
            neighbors1[0] = new NeighborO() { flatNumber = 3 };

            NeighborO[] neighbors2 = new NeighborO[256];
            neighbors2[0] = new NeighborO() { flatNumber = "256b" };

            Array.Sort(neighbors1, new Comparison<NeighborO>(
                (n1, n2) => ((int)n1.flatNumber).CompareTo(n2.flatNumber)));

            Array.Sort(neighbors2, new Comparison<NeighborO>(
                (n1, n2) => ((string)n1.flatNumber).CompareTo(n2.flatNumber)));
        }

        public static void GenericNeighbourExample()
        {
            NeighborG<int>[] neighbors1 = new NeighborG<int>[256];
            neighbors1[0] = new NeighborG<int>() { flatNumber = 3 };

            NeighborG<string>[] neighbors2 = new NeighborG<string>[256];
            neighbors2[0] = new NeighborG<string>() { flatNumber = "256b" };

            Array.Sort(neighbors1, new Comparison<NeighborG<int>>(
                (n1, n2) => (n1.flatNumber).CompareTo(n2.flatNumber)));

            Array.Sort(neighbors2, new Comparison<NeighborG<string>>(
                (n1, n2) => (n1.flatNumber).CompareTo(n2.flatNumber)));
        }
    }


    public class Neighbor
    {
        public int flatNumber;
        public string name;
    }

    public class NeighborO
    {
        public object flatNumber;
        public string name;
    }

    public class NeighborG<TFlat>
    {
        public TFlat flatNumber;
        public string name;
    }
}

