using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BL_8_Struct_Enum_Tuple_Generic.ClassReplaceStruct;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Practice
    {
        public static Random random = new Random();

        public struct Point
        {
            public double x;
            public double y;
            public double z;
            public Point(double x = 0, double y = 0, double z = 0)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        public struct Rectangle
        {
            public double height;
            public double width;
            public Point coordinate;

            public Rectangle(Point p, double height = 0, double width = 0)
            {
                
                this.height = height > 0 ? height : 0;
                this.width = width > 0 ? width : 0;
                coordinate = p;
                
            }
        }

        /// <summary>
        /// BL8-P1/3. Cоздать структуру 2DRectangle, которая будет содержать ширину, высоту и координату.
        /// </summary>
        public static void Lb8_P1_3()
        {

            Rectangle rect = new Rectangle(new Point(123.123, 345.345, -456.456), 46, -789);

            Console.WriteLine($"Height : {rect.height}");
            Console.WriteLine($"Width : {rect.width}");
            Console.WriteLine($"Coordinate : ({rect.coordinate.y} ; {rect.coordinate.y} ; {rect.coordinate.z})");

        }


        /// <summary>
        /// BL8-P2/3. Cоздать случайный массив квадратов с количеством элементов 100. 
        /// Используйте класс Random(10), чтоб установить значения сторон. 
        /// </summary>
        public static void Lb8_P2_3()
        {
            Random rnd = new Random();
            int _randomLimit = 2;

            Rectangle[] rectArr = new Rectangle[10];
            for (int i = 0; i < 10; i++)
            {
                rectArr[i] = new Rectangle(new Point(), rnd.Next(_randomLimit), rnd.Next(_randomLimit));
            }
            int o = 0;
            foreach (var item in rectArr)
            {
                
                Console.WriteLine($"{o}: Height : {item.height}. Width : {item.width}. Coordinate : ({item.coordinate.x} ; {item.coordinate.y} ; {item.coordinate.z})");
                o++;
            }

            Dictionary<Rectangle, int> duplicateList = new Dictionary<Rectangle, int>();
            List<Rectangle> l = rectArr.ToList();
            
            for (int i = 0; i < rectArr.Length; i++)
            {
                if (!duplicateList.Keys.Contains(rectArr[i]))
                {
                    duplicateList.Add(rectArr[i], 0);
                    int counter = 0;
                    for (int j = i+1; j < rectArr.Length; j++)
                    {
                        if (StructFieldEquality(rectArr[i], rectArr[j]))
                        {
                            counter++;
                            //l.Remove(l[j]);
                        }


                    }
                    duplicateList[rectArr[i]] = counter;

                }
            }
            foreach (var item in duplicateList.Keys)
            {
                Console.WriteLine($"Rectangle: height : {item.height}. width : {item.width}. coordinates : {item.coordinate.x};{item.coordinate.y};{item.coordinate.z}. Duplicates number: {duplicateList[item]}");
            }
            //////////////////
            Console.WriteLine(new String('|', 50));
            //////////////////
            ClassReplaceStruct.Rectangle[] rectArrClass = new ClassReplaceStruct.Rectangle[10];
            for (int i = 0; i < 10; i++)
            {
                rectArrClass[i] = new ClassReplaceStruct.Rectangle(new ClassReplaceStruct.Point(), rnd.Next(_randomLimit), rnd.Next(_randomLimit));
            }
            foreach (var item in rectArrClass)
            {

                Console.WriteLine($"Height : {item.Height}. Width : {item.Width}. Coordinate : ({item.Coordinate.X} ; {item.Coordinate.Y} ; {item.Coordinate.Z})");
            }

            Dictionary<ClassReplaceStruct.Rectangle, int> duplicateListClass = new Dictionary<ClassReplaceStruct.Rectangle, int>();
            List<ClassReplaceStruct.Rectangle> lClass = rectArrClass.ToList();
            
            for (int i = 0; i < rectArrClass.Length; i++)
            {
                if (!duplicateListClass.Keys.Contains(rectArrClass[i]))
                {
                    duplicateListClass.Add(rectArrClass[i], 0);
                    int counter = 0;
                    for (int j = i + 1; j < rectArrClass.Length; j++)
                    {

                        if (rectArrClass[i].Equals(rectArrClass[j]))
                        {
                            counter++;
                            //lClass.Remove(lClass[j]);
                        }

                    }
                    duplicateListClass[rectArrClass[i]] = counter;
                }
            }
            foreach (var item in duplicateListClass.Keys)
            {
                Console.WriteLine($"Rectangle: height : {item.Height}. width : {item.Width}. coordinates : {item.Coordinate.X};{item.Coordinate.Y};{item.Coordinate.Z}. Duplicates number: {duplicateListClass[item]}");
            }

        }

        /// <summary>
        /// BL8-P3/3.Anonymous. Создать метод GetSongData, 
        /// который принимает обьекта типа Song и возвращает анонимный тип, 
        /// который содержит Title, Minutes, Seconds и AlbumYear. 
        /// </summary>
        public static void Lb8_P3_3_Anonymous()
        {
            var data = GetSongData(new Song_Simple()
            {
                Title = "blablabla",
                MinutesDuration = 5.345354,
                SecondDuration = 234.567567,
                AlbumYear = DateTime.MinValue,
                Genre = "Jesus rock"
            });
            PropertyInfo[] listOfprop = data.GetType().GetProperties();
            foreach (var item in listOfprop)
            {
                Console.WriteLine($"{item.ToString().Split(' ')[1]}: {item.GetValue(data)}");
            }
        }


        private static bool StructFieldEquality(Rectangle r1, Rectangle r2)
        {
            if (r1.height == r2.height &&
                        r1.width == r2.width &&
                        r1.coordinate.x == r2.coordinate.x &&
                        r1.coordinate.y == r2.coordinate.y &&
                        r1.coordinate.z == r2.coordinate.z)
            {
                return true;

            }
            return false;
        }

        private static object GetSongData(Song_Simple s)
        {
            var songData = new
            {
                Title = s.Title,
                Minutes = s.MinutesDuration,
                Seconds = s.SecondDuration,
                AlYear = s.AlbumYear,
                Genre = s.Genre
            };
            return songData;
        }

        class Song_Simple
        {
            public string Title { get; set; }
            public double MinutesDuration { get; set; }
            public double SecondDuration { get; set; }
            public DateTime AlbumYear { get; set; }
            public string Genre { get; set; }
        }
    }
}
