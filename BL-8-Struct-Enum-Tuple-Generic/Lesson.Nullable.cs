namespace BL_8_Struct_Enum_Tuple_Generic
{
    partial class Lesson
    {
        public static void NullableExample()
        {
            #region defenition

            int? age = null;
            int? age1 = 10;

            bool? vactinated = null;
            bool? vactinated2 = false;

            #endregion

            #region value check

            if (age.HasValue) { }
            if (age != null) { }

            if (age.HasValue && age.Value == 18) {}
            if (age == 18) {}

            #endregion

            #region boxing and uboxing

            bool? b = null;
            object o = b;

            bool? b1 = false;
            int? i = 44;
            object bBoxed = b1;
            object iBoxed = i;

            object bb = (object)false;
            object ii = (object)1;

            bool? ub1 = (bool?)bb;
            bool ub2 = (bool)bb;

            int? ui1 = (int?)ii;
            int ui2 = (int)ii;

            #endregion

            #region operations

            int a = 10;
            int? b2 = null;
            var c = a + b2; //null

            int? aa = null;
            int? bbb = 34;
            var cc = aa / bbb;

            #endregion
        }
    }
}

