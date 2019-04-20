using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Lesson
    {
        public static void EnumExample()
        {
            var today = (Days)(((int)DateTime.Today.DayOfWeek + 1)%7);
            var fishDay = Days.Thu;

            if(today == fishDay) {
                Console.Write("Сегодня в меню рыба!");
            }
        }

        public static void EnumArrayExample()
        {
            Days[] meetingDays = new Days[] {
                Days.Tue ,
                Days.Thu
            };

            Days[] holidays = new Days[] {
                Days.Sun ,
                Days.Sat
            };

            var today = (Days)(((int)DateTime.Today.DayOfWeek + 1) % 7);
            if(Array.IndexOf(meetingDays, today) >= 0){
                //Созываем всех на митинг
            }
        }

        public static void EnumFlagsExample()
        {
            Day meetingDays = Day.Tuesday | Day.Thursday;
            Day holidays = Day.Sunday | Day.Saturday;


            var today = (Day)DateTime.Today.DayOfWeek;

            if((meetingDays & today) == today){
                //Созываем всех на митинг
            }
        }

    }

    enum Mark
    {
        Good = 3,
        Better = 4,
        Best = 5
    }

    enum Days { Sat, Sun, Mon, Tue, Wed, Thu, Fri };

    enum Days1 { Sat = 0, Sun = 1, Mon = 2, Tue = 3, Wed = 4, Thu = 5, Fri = 6 };

    enum Days2 { Sat = 6, Sun, Mon = 1, Tue, Wed, Thu, Fri };

    [Flags]//Данный атрибут не обязателен
    enum Day
    {
        Sunday = 0b00000001,  //1
        Monday = 0b00000010,  //2
        Tuesday = 0b00000100,  //4
        Wednesday = 0b00001000,  //8
        Thursday = 0b00010000,  //16
        Friday = 0b00100000,  //32
        Saturday = 0b01000000   //64
    };
}

